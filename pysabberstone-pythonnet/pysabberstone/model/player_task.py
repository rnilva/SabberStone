from dataclasses import dataclass
from enum import IntEnum

import pysabberstone.core
from SabberStoneCore.Tasks.PlayerTasks import PlayerTaskType as _PlayerTaskType
from SabberStoneCore.Tasks.PlayerTasks.Lite import PlayerTaskLite as _PlayerTaskLite


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
            _PlayerTaskType(self.type.value),
            self.source_position,
            self.target_position,
            self.zone_position,
            self.choose_one,
            False,
        )

    @classmethod
    def from_core_type(cls, core_task: _PlayerTaskLite):
        return cls(
            type=PlayerTaskType(int(core_task.Type)),
            source_position=core_task.SourcePosition,
            target_position=core_task.TargetPosition,
            zone_position=core_task.ZonePosition,
            choose_one=core_task.ChooseOne,
        )
