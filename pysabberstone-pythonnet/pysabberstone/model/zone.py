import pysabberstone.core
from pysabberstone.model.entity import Entity

from SabberStoneCore.Model.Zones import Zone as _Zone


class Zone:
    def __init__(self, _zone: _Zone) -> None:
        self._zone = _zone

    def __iter__(self):
        yield from map(Entity, self._zone)

    def __getitem__(self, idx: int):
        return Entity(self._zone[idx])

    def __repr__(self) -> str:
        return repr(list(self))
