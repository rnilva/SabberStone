import pysabberstone.core
from pysabberstone.model.enums import CardClass
from pysabberstone.model.entity import Entity
from pysabberstone.model.zone import Zone

from SabberStoneCore.Model.Entities import Controller as _Controller


class Player:
    def __init__(self, _controller: _Controller) -> None:
        self._controller = _controller
        self.name: str = _controller.Name
        self.base_class = CardClass(int(_controller.BaseClass))
        self.hero = Entity(_controller.Hero)
        self.hero_power = Entity(_controller.Hero.HeroPower)
        self.deck = Zone(_controller.DeckZone)
        self.hand = Zone(_controller.HandZone)
        self.board = Zone(_controller.BoardZone)
        self.graveyard = Zone(_controller.GraveyardZone)
        self.secrets = Zone(_controller.SecretZone)

    @property
    def weapon(self):
        w = self._controller.Hero.Weapon
        return Entity(w) if w is not None else None

    @property
    def hero_class(self):
        return CardClass(int(self._controller.HeroClass))

    @property
    def remaining_mana(self) -> int:
        return self._controller.RemainingMana

    @property
    def base_mana(self) -> int:
        return self._controller.BaseMana

    @property
    def overload_owed_mana(self) -> int:
        return self._controller.OverloadOwed

    @property
    def overload_locked_mana(self) -> int:
        return self._controller.OverloadLocked
