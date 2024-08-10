from pysabberstone.model.entity import Entity


class Zone:
    def __init__(self, _zone) -> None:
        self._zone = _zone

    def __len__(self) -> int:
        return self._zone.Count

    def __iter__(self):
        yield from map(Entity, self._zone)

    def __getitem__(self, idx: int):
        return Entity(self._zone[idx])

    def __repr__(self) -> str:
        return repr(list(self))
