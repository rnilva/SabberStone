import random
import traceback
from abc import ABC, abstractmethod
from collections import Counter
from dataclasses import dataclass
from pathlib import Path
from pprint import pprint
from typing import Callable

from pysabberstone.model.enums import PlayState, CardClass
from pysabberstone.model.game import Game, GameConfig
from pysabberstone.model.player import Player
from pysabberstone.model.player_task import PlayerTask
from pysabberstone.interface.deck import Deck

import pysabberstone.core
from SabberStoneCore.Enums import FormatType as _FormatType
from SabberStoneBasicAI import IAgent as _IAgent, Match as _Match
from System import Func


class Agent(ABC):
    @abstractmethod
    def get_action(self, game: Game, player: Player) -> PlayerTask: ...

    @abstractmethod
    def mulligan(self, game: Game, player: Player) -> list[int]: ...

    def on_match_started(self):
        return

    def on_game_started(self):
        return

    def on_game_finished(self):
        return


class DotNetAgentWrapper(Agent):
    def __init__(self, _agent) -> None:
        super().__init__()
        self._agent = _agent

    def get_action(self, game: Game, player: Player) -> PlayerTask:
        _task = self._agent.GetAction(game._game, player._controller)
        return PlayerTask.from_core_type(_task)

    def mulligan(self, game: Game, player: Player) -> list[int]:
        _choose_task = self._agent.Mulligan(game._game, player._controller)
        return list(_choose_task.Choices)


class RandomAgent(Agent):
    def __init__(self, seed: int) -> None:
        super().__init__()
        self.rng = random.Random(seed)

    def get_action(self, game: Game, player: Player) -> PlayerTask:
        options = game.get_options()
        return self.rng.choice(options)

    def mulligan(self, game: Game, player: Player) -> list[int]:
        return []


@dataclass
class MatchConfig:
    skip_mulligan: bool = True
    seed: int | None = None
    log_dir: str | Path | None = None
    verbose: bool = False


def run_games(
    agent1: Agent,
    agent2: Agent,
    deck1: Deck,
    deck2: Deck,
    num_games: int,
    config: MatchConfig,
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

    agents = (agent1, agent2)
    for agent in agents:
        agent.on_match_started()

    win_counter = Counter()
    for i in range(num_games):
        try:
            for agent in agents:
                agent.on_game_started()

            game = Game(deck1, deck2, game_config)

            if not game_config.skip_mulligan:
                for pid, agent in zip((1, 2), agents):
                    game.send_mulligan(pid, agent.mulligan(game, game.players[pid - 1]))
                game._game.MainBegin(True)

            while not game.done():
                player = game.current_player
                action = agents[player.id - 1].get_action(game, player)
                game.process(action)
                if config.verbose:
                    logs = game.get_log_entries(flush=True)
                    for l in logs:
                        print(l)

            for agent in agents:
                agent.on_game_finished()
        except Exception as e:
            import time

            with open(f"error_{time.strftime('%d%m-%H%M%S')}.txt", "w") as f:
                print("Exception raised during the run.", file=f)
                print("Deck1:", file=f)
                pprint(deck1, f)
                print("-" * 20, file=f)
                print("Deck2:", file=f)
                pprint(deck2, f)
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

        if log_dir is not None:
            file_path = log_dir / f"{i + 1}.txt"
            with file_path.open("w") as f:
                for log in game.get_log_entries():
                    f.write(log)
                    f.write("\n")

    return win_counter


def run_parallel_games(
    agent_factory1: Callable[[], DotNetAgentWrapper],
    agent_factory2: Callable[[], DotNetAgentWrapper],
    deck1: Deck,
    deck2: Deck,
    num_games: int,
    config: MatchConfig,
):
    fac1 = Func[_IAgent](lambda: agent_factory1()._agent)
    fac2 = Func[_IAgent](lambda: agent_factory2()._agent)

    # print(fac1())
    # quit()

    _result = _Match.RunParallelGames[_IAgent, _IAgent](
        fac1,
        fac2,
        deck1._to_core_type(),
        deck2._to_core_type(),
        num_games,
        _Match.Config(config.skip_mulligan, None, "", _FormatType.FT_CLASSIC),
    )

    result = Counter({i + 1: _result[i] for i in range(2)})
    return result


if __name__ == "__main__":
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

    agent1 = RandomAgent(17)
    agent2 = RandomAgent(41)

    result = run_games(
        agent1,
        agent2,
        mage_expert_deck,
        mage_expert_deck,
        10,
        MatchConfig(skip_mulligan=True, seed=7, log_dir="./test_logs/"),
    )

    print(result)

    from pysabberstone.load_external_agents import load

    agents = load()
    agent = list(agents.values())[0]

    fac = lambda: agent(18)

    result = run_parallel_games(
        fac,
        fac,
        mage_expert_deck,
        mage_expert_deck,
        100,
        MatchConfig(skip_mulligan=True),
    )
    print(result)
