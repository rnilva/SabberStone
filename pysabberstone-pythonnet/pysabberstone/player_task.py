from dataclasses import dataclass
from enum import IntEnum

import pysabberstone.core
from SabberStoneCore.Tasks.PlayerTasks import _PlayerTaskType
from SabberStoneCore.Tasks.PlayerTasks.Lite import _PlayerTaskLite


class PlayerTaskType(IntEnum):
    CHOOSE = 0
    CONCEDE = 1
    END_TURN = 2
    HERO_ATTACK = 3
    HERO_POWER = 4
    MINION_ATTACK = 5
    PLAY_CARD = 6


@dataclass
class PlayerTask:
    type: PlayerTaskType
    source_position: int
    target_position: int
    zone_position: int
    choose_one: int

    def _to_core_type(self):
        return _PlayerTaskLite(
            _PlayerTaskType(self.type),
            self.source_position,
            self.target_position,
            self.zone_position,
            self.choose_one,
            False,
        )
