import traceback
import logging
from collections import Counter
from contextlib import nullcontext
from dataclasses import dataclass
from datetime import datetime, timedelta
from pathlib import Path
from pprint import pprint
from typing import Callable, Iterable

from tqdm import tqdm

from pysabberstone.model.enums import PlayState, CardClass
from pysabberstone.model.game import Game, GameConfig
from pysabberstone.interface.agent import Agent, _to_core_agent
from pysabberstone.interface.deck import Deck

import pysabberstone.core
from SabberStoneCore.Config import Deck as _Deck  # type: ignore
from SabberStoneCore.Enums import FormatType as _FormatType  # type: ignore
from SabberStoneBasicAI import IAgent as _IAgent, Match as _Match  # type: ignore
from SabberStoneBasicAI import ProgressMonitor as _ProgressMonitor  # type: ignore
from System import Action as _Action, Func as _Func, Array as _Array, Int64 as _Int64  # type: ignore
from System.Collections.Generic import List as _List  # type: ignore


@dataclass
class MatchConfig:
    skip_mulligan: bool = True
    seed: int | None = None
    log_dir: str | None = None
    error_dir: str | None = None
    out_dir: str | None = None
    verbose: bool = False
    progress_bar: bool = False


@dataclass
class GameResult:
    agent1: str
    agent2: str
    deck1: str
    deck2: str
    winner: int
    duration: timedelta
    seed: int
    error: str | None

    @classmethod
    def _from_core_type(cls, _r):
        return GameResult(
            agent1=_r.Agent1,
            agent2=_r.Agent2,
            deck1=_r.Deck1,
            deck2=_r.Deck2,
            winner=_r.Winner,
            duration=timedelta(milliseconds=_r.Duration.TotalMilliseconds),
            seed=_r.Seed,
            error=_r.Error if _r.Error is not None else str(_r.Error)
        )


@dataclass
class MatchResult:
    total_games: int
    agent1_wins: int
    agent2_wins: int
    errors: int
    average_duration: timedelta

    @classmethod
    def _from_core_type(cls, _r):
        return MatchResult(
            total_games=_r.TotalGames,
            agent1_wins=_r.Agent1Wins,
            agent2_wins=_r.Agent2Wins,
            errors=_r.Errors,
            average_duration=timedelta(
                milliseconds=_r.AverageDuration.TotalMilliseconds
            ),
        )


def run_games(
    agent1: Agent,
    agent2: Agent,
    deck1: Deck,
    deck2: Deck,
    num_games: int,
    config: MatchConfig,
    progressbar: bool = True,
    log_level: int = logging.INFO,
):
    # TODO: seed

    game_config = GameConfig(skip_mulligan=config.skip_mulligan)

    if config.log_dir is not None:
        game_config.logging = True
        log_dir = Path(config.log_dir)
        log_dir.mkdir(parents=True, exist_ok=True)
    else:
        log_dir = None

    if config.verbose:
        game_config.logging = True

    total_duration = timedelta()

    agents = (agent1, agent2)
    for agent in agents:
        agent.on_match_started()

    win_counter = Counter()
    maybe_tqdm = tqdm(total=num_games) if progressbar else nullcontext()
    with maybe_tqdm as pbar:
        for i in range(num_games):
            try:
                for agent in agents:
                    agent.on_game_started()

                start_time = datetime.now()

                game = Game(deck1, deck2, game_config)

                if not game_config.skip_mulligan:
                    for pid, agent in zip((1, 2), agents):
                        game.send_mulligan(
                            pid, agent.mulligan(game, game.players[pid - 1])
                        )
                    game._game.MainBegin(True)

                while not game.done():
                    player = game.current_player
                    action = agents[player.id - 1].get_action(game, player)
                    game.process(action)
                    if config.verbose:
                        logs = game.get_log_entries(flush=True)
                        for l in logs:
                            if pbar:
                                pbar.write(l)
                            else:
                                print(l)

                end_time = datetime.now()
                duration = end_time - start_time
                total_duration += duration

                for agent in agents:
                    agent.on_game_finished()

            except Exception as e:
                import time

                with open(f"error_{time.strftime('%d%m-%H%M%S')}.txt", "w") as f:
                    print("Exception raised during the run.", file=f)
                    print("Deck1:", file=f)
                    pprint(deck1.cards, f)
                    print("-" * 20, file=f)
                    print("Deck2:", file=f)
                    pprint(deck2.cards, f)
                    print("-" * 20, file=f)
                    print("Exception", file=f)
                    print(traceback.format_exc(), file=f)
                    print("-" * 20, file=f)
                win_counter[-1] += 1
                continue

            winner = (
                1
                if game.players[0].play_state == PlayState.WON
                else 2 if game.players[1].play_state == PlayState.WON else -1
            )
            win_counter[winner] += 1

            if pbar:
                total = win_counter[1] + win_counter[2]
                win_rate = 100 * (win_counter[1] / total) if total > 0 else 0
                pbar.set_postfix_str(
                    f"Agent1 Wins: {win_counter[1]}, Agent2 Wins: {win_counter[2]}"
                    f", Ties: {win_counter[-1]}, Win Rate: {win_rate:.2f}%"
                )
                pbar.update(1)

            if log_dir is not None:
                file_path = log_dir / f"{i + 1}.txt"
                with file_path.open("w") as f:
                    for log in game.get_log_entries():
                        f.write(log)
                        f.write("\n")

    return win_counter


def run_multideck_parallel_games(
    agent_factory1: Callable[[], Agent],
    agent_factory2: Callable[[], Agent],
    decks1: Iterable[Deck],
    decks2: Iterable[Deck],
    num_games: int,
    config: MatchConfig,
    max_degree_of_parallelism: int = -1,
    out_dir: str | None = None,
):
    if config.progress_bar:
        num_pairs = sum(1 for _ in decks1) * sum(1 for _ in decks2) * num_games
        pbar = tqdm(total=num_pairs)

        last_update = [0]  # Using list to store mutable state

        def progress_callback(current_progress):
            delta = current_progress - last_update[0]
            if delta > 0:
                pbar.update(delta)
                last_update[0] = current_progress

        callback_delegate = _Action[_Int64](progress_callback)
        progress_monitor = _ProgressMonitor(num_pairs, callback_delegate)
    else:
        pbar = None
        progress_monitor = None

    _fac1 = _Func[_IAgent](lambda: _to_core_agent(agent_factory1()))
    _fac2 = _Func[_IAgent](lambda: _to_core_agent(agent_factory2()))
    _decks1 = _Array[_Deck](d._to_core_type() for d in decks1)
    _decks2 = _Array[_Deck](d._to_core_type() for d in decks2)

    _result = _Match.RunParallelGames(
        _fac1,
        _fac2,
        _decks1,
        _decks2,
        num_games,
        _Match.Config(
            config.skip_mulligan,
            config.seed,
            _FormatType.FT_CLASSIC,
            config.log_dir,
            config.error_dir,
            out_dir,
            False,
        ),
        max_degree_of_parallelism,
        False,
        progress_monitor,
    )

    if pbar is not None:
        pbar.refresh()
        pbar.close()

    _result_by_pairs = _result.Item1
    _total_result = _result.Item2
    _game_results = _result.Item3

    result_by_pairs: dict[tuple[str, str], MatchResult] = {}
    for kvp in _result_by_pairs:
        _deck_pair, _deck_result = kvp.Key, kvp.Value
        deck_pair = _deck_pair.Item1, _deck_pair.Item2
        deck_result = MatchResult._from_core_type(_deck_result)
        result_by_pairs[deck_pair] = deck_result
    
    total_result = MatchResult._from_core_type(_total_result)

    game_results = [GameResult._from_core_type(_r) for _r in _game_results]

    return result_by_pairs, total_result, game_results


if __name__ == "__main__":
    from pysabberstone.interface.agent import RandomAgent

    mage_expert_deck = Deck(
        [
            "Arcane Missiles",
            "Arcane Missiles",
            "Arcane Explosion",
            "Arcane Explosion",
            "Mana Wyrm",
            "Mana Wyrm",
            "Sorcerer's Apprentice",
            "Sorcerer's Apprentice",
            "Counterspell",
            "Counterspell",
            "Kirin Tor Mage",
            "Kirin Tor Mage",
            "Mirror Entity",
            "Mirror Entity",
            "Vaporize",
            "Vaporize",
            "Fireball",
            "Fireball",
            "Polymorph",
            "Polymorph",
            "Water Elemental",
            "Water Elemental",
            "Kobold Geomancer",
            "Kobold Geomancer",
            "Mana Addict",
            "Mana Addict",
            "Azure Drake",
            "Azure Drake",
            "Frost Elemental",
            "Frost Elemental",
        ],
        CardClass.MAGE,
    )

    fac1 = lambda: RandomAgent(18)
    fac2 = lambda: RandomAgent(374)

    result = run_multideck_parallel_games(
        fac1,
        fac2,
        [mage_expert_deck],
        [mage_expert_deck],
        16,
        MatchConfig(skip_mulligan=True, seed=123564, progress_bar=True),
    )
    print(result[1])
