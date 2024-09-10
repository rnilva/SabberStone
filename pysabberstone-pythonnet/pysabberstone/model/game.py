from dataclasses import dataclass
from typing import Literal, Generator

import pysabberstone.utils as utils
from pysabberstone.model.enums import LogLevel, FormatType
from pysabberstone.model.player import Player
from pysabberstone.model.player_task import PlayerTask
from pysabberstone.py_types import CardClass
from pysabberstone.interface.deck import Deck

import pysabberstone.core
from System.Collections.Generic import List as _List
from SabberStoneCore.Config import GameConfig as _GameConfig
from SabberStoneCore.Enums import State as _State, FormatType as _FormatType
from SabberStoneCore.Model import Game as _Game
from SabberStoneCore.Tasks.PlayerTasks import ChooseTask as _ChooseTask
from SabberStoneCore.Tasks.PlayerTasks.Lite import (
    PlayerTaskLiteContainer as _OptionBuffer,
)


@dataclass
class GameConfig:
    start_player: Literal[-1, 1, 2] = -1
    """The index of the starting player. This value is 1-based and -1 means random."""
    skip_mulligan: bool = False
    """Skip the Mulligan phase."""
    logging: bool = False
    """Generate logs."""
    format_type: FormatType = FormatType.FT_CLASSIC
    """The format of decks, which defines the pool of available cards."""

    def _to_core_config(self):
        c = _GameConfig()
        c.FormatType = _FormatType(int(self.format_type))
        c.StartPlayer = self.start_player
        c.SkipMulligan = self.skip_mulligan
        c.Logging = self.logging
        return c


class Game:
    def __init__(self, p1_deck: Deck, p2_deck: Deck, config: GameConfig) -> None:
        _c = config._to_core_config()
        _c.Player1HeroClass, _c.Player1Deck = p1_deck._to_core_class_and_cards()
        _c.Player2HeroClass, _c.Player2Deck = p2_deck._to_core_class_and_cards()
        self._game = _Game(_c)
        self._game.StartGame()
        self._option_buffer = _OptionBuffer()
        self.players = [Player(self._game.Player1), Player(self._game.Player2)]

    @property
    def current_player(self) -> Player:
        return self.players[self._game.CurrentPlayer.PlayerId - 1]

    @property
    def current_opponent(self) -> Player:
        return self.players[2 - self._game.CurrentPlayer.PlayerId]

    def get_options(self) -> list[PlayerTask]:
        self._game.CurrentPlayer.Options(self._option_buffer)
        options = []
        for _core_task in self._option_buffer:
            options.append(PlayerTask.from_core_type(_core_task))
        return options

    def process(self, player_task: PlayerTask):
        _player_task = player_task._to_core_type()
        self._game.Process(_player_task)

    def send_mulligan(self, player_id: int, choices: list[int]):
        _choices = _List[int]()
        for i in choices:
            _choices.Add(i)
        _task = _ChooseTask.Mulligan(self._game.ControllerByPlayerId(player_id))
        self._game.Process(_task)

    def done(self):
        return self._game.State == _State.COMPLETE

    @property
    def turn(self):
        return self._game.Turn

    def get_log_entries(
        self, loglevel: LogLevel = LogLevel.INFO, flush: bool = False
    ) -> Generator[str, None, None]:
        _log_entries = self._game.Logs
        for _item in _log_entries:
            if int(_item.Level) <= loglevel.value:
                yield _item.ToString()
        if flush:
            self._game.Logs.Clear()

    @classmethod
    def from_core_type(cls, _game: _Game):
        game = object.__new__(cls)
        game._game = _game
        game._option_buffer = _OptionBuffer()
        game.players = [Player(_game.Player1), Player(_game.Player2)]
        return game


if __name__ == "__main__":
    import random

    mage_expert_deck = [
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
    ]

    config = GameConfig()
    game = Game(
        (CardClass.MAGE, mage_expert_deck), (CardClass.MAGE, mage_expert_deck), config
    )
    while not game.done():
        options = game.get_options()
        option = random.choice(options)
        print(option)
        game.process(option)
