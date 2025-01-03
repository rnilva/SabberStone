from dataclasses import dataclass
from enum import IntEnum
from typing import ClassVar, Literal

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


HistoryEntryType = Literal["PLAY", "ATTACK", "CHOOSE", "END"]


@dataclass
class PlayerTaskHistoryEntry:
    player_id: int
    turn: int
    type: HistoryEntryType
    source_name: str
    target_name: str | None = None
    zone_position: int = -1

    _type_map: ClassVar[dict[PlayerTaskType, HistoryEntryType]] = {
        PlayerTaskType.CHOOSE: "CHOOSE",
        PlayerTaskType.CONCEDE: "END",
        PlayerTaskType.END_TURN: "END",
        PlayerTaskType.HERO_ATTACK: "ATTACK",
        PlayerTaskType.HERO_POWER: "PLAY",
        PlayerTaskType.MINION_ATTACK: "ATTACK",
        PlayerTaskType.PLAY_CARD: "PLAY",
    }

    @classmethod
    def from_core_task(cls, turn: int, _core_task: _PlayerTaskLite, _controller):
        task_type = PlayerTaskType(int(_core_task.Type))
        _target_character = None
        if task_type == PlayerTaskType.MINION_ATTACK:
            source = _core_task.GetAttackSource(_controller).Card.Name
            _target_character = _core_task.GetTarget(_controller)
        elif task_type == PlayerTaskType.HERO_ATTACK:
            source = "HERO"
            _target_character = _core_task.GetTarget(_controller)
        elif task_type == PlayerTaskType.PLAY_CARD:
            source = _core_task.GetPlaySource(_controller).Card.Name
            _target_character = _core_task.GetTarget(_controller)
        elif task_type == PlayerTaskType.HERO_POWER:
            source = "HERO POWER"
            _target_character = _core_task.GetTarget(_controller)
        else:
            source = ""
        if _target_character is not None:
            target = _target_character.Card.Name
        else:
            target = None

        if _core_task.ZonePosition >= 0 and task_type == PlayerTaskType.PLAY_CARD:
            pos = _core_task.ZonePosition
        else:
            pos = -1

        return cls(
            player_id=_controller.Id,
            turn=turn,
            type=cls._type_map[task_type],
            source_name=source,
            target_name=target,
            zone_position=pos,
        )

    def __repr__(self):
        repr = f"[{self.type}]"
        if self.source_name:
            repr += f" [{self.source_name}]"
        if self.zone_position >= 0:
            repr += f" (Pos: {self.zone_position})"
        if self.target_name:
            repr += f" => [{self.target_name}]"
        return repr
