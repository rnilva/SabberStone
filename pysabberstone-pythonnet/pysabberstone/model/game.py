from dataclasses import dataclass
from enum import IntEnum
from re import A
from typing import Literal

import pysabberstone.core
import pysabberstone.utils as utils
from pysabberstone.model.player import Player
from pysabberstone.model.player_task import PlayerTask
from pysabberstone.py_types import Deck, CardClass

from SabberStoneCore.Config import GameConfig as _GameConfig
from SabberStoneCore.Enums import State as _State
from SabberStoneCore.Model import Game as _Game
from SabberStoneCore.Tasks.PlayerTasks.Lite import (
    PlayerTaskLiteContainer as _OptionBuffer,
)


@dataclass
class GameConfig:
    start_player: Literal[-1, 1, 2] = -1
    """The index of the starting player. This value is 1-based and -1 means random."""

    def _to_core_config(self):
        c = _GameConfig()
        c.StartPlayer = self.start_player
        return c


class Game:
    def __init__(self, p1_deck: Deck, p2_deck: Deck, config: GameConfig) -> None:
        _c = config._to_core_config()
        _c.Player1HeroClass, _c.Player1Deck = utils.convert_deck(p1_deck)
        _c.Player2HeroClass, _c.Player2Deck = utils.convert_deck(p2_deck)
        self._game = _Game(_c)
        self._game.StartGame()
        self._option_buffer = _OptionBuffer()
        self.players = [Player(self._game.Player1), Player(self._game.Player2)]

    @property
    def current_player(self):
        return self.players[self._game.CurrentPlayer.PlayerId - 1]

    @property
    def current_opponent(self):
        return self.players[2 - self._game.CurrentPlayer.PlayerId]

    def get_options(self):
        self._game.CurrentPlayer.Options(self._option_buffer)
        options = []
        for _core_task in self._option_buffer:
            options.append(PlayerTask.from_core_task(_core_task))
        return options

    def process(self, player_task: PlayerTask):
        _player_task = player_task._to_core_type()
        self._game.Process(_player_task)

    def done(self):
        return self._game.State == _State.COMPLETE


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
