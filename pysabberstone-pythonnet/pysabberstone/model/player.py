import pysabberstone.core
from SabberStoneCore.Model.Entities import Controller as _Controller


class Player:
    def __init__(self, _controller: _Controller) -> None:
        self._controller = _controller
        