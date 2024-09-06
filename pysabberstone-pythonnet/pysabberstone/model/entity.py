import pysabberstone.core
from pysabberstone.model.enums import CardClass, CardType

from SabberStoneCore.Enums import CardType as _CardType


class Entity:
    def __init__(self, _playable) -> None:
        self._playable = _playable

    @property
    def name(self) -> str:
        return self._playable.Card.Name

    @property
    def text(self) -> str:
        return self._playable.Card.Text

    @property
    def card_class(self) -> CardClass:
        return CardClass(int(self._playable.Card.Class))

    @property
    def card_type(self) -> CardType:
        return CardType(int(self._playable.Card.Type))

    @property
    def cost(self) -> int:
        return self._playable.Cost

    def is_character(self):
        _type = self._playable.Card.Type
        return _type == _CardType.MINION or _type == _CardType.HERO

    def is_minion(self):
        return self._playable.Card.Type == _CardType.MINION

    def is_weapon(self):
        return self._playable.Card.Type == _CardType.WEAPON

    @property
    def attack(self) -> int | None:
        return (
            None
            if self.card_type not in (CardType.HERO, CardType.MINION, CardType.WEAPON)
            else self._playable.AttackDamage
        )

    @property
    def health(self) -> int | None:
        if self.is_character():
            return self._playable.Health
        elif self.is_weapon():
            return self._playable.Durability
        else:
            return None

    @property
    def base_health(self) -> int | None:
        return self._playable.BaseHealth if self.is_character() else None

    @property
    def damage(self) -> int | None:
        return self._playable.Damage if self.is_character() else None

    @property
    def exhausted(self) -> bool:
        return self._playable.IsExhausted

    @property
    def spell_power(self) -> int | None:
        return self._playable.SpellPower if self.is_character() else None

    @property
    def taunt(self) -> bool | None:
        return self._playable.HasTaunt if self.is_character() else None

    @property
    def immune(self) -> bool | None:
        return self._playable.IsImmune if self.is_character() else None

    @property
    def frozen(self) -> bool | None:
        return self._playable.IsFrozen if self.is_character() else None

    @property
    def windfury(self) -> bool | None:
        return self._playable.HasWindfury if self.is_character() else None

    @property
    def poisonous(self) -> bool | None:
        return self._playable.Poisonous if self.is_character() else None

    @property
    def stealth(self) -> bool | None:
        return self._playable.HasStealth if self.is_character() else None

    @property
    def elusive(self) -> bool | None:
        return self._playable.CantBeTargetedBySpells if self.is_character() else None

    @property
    def divine_shield(self) -> bool | None:
        return self._playable.HasDivineShield if self.is_minion() else None

    @property
    def charge(self) -> bool | None:
        return self._playable.HasCharge if self.is_minion() else None

    @property
    def deathrattle(self) -> bool | None:
        return self._playable.HasDeathrattle if self.is_minion() else None

    @property
    def silenced(self) -> bool | None:
        return self._playable.IsSilenced if self.is_minion() else None

    @property
    def num_attacks_this_turn(self) -> int | None:
        return self._playable.NumAttacksThisTurn if self.is_character() else None

    def __repr__(self) -> str:
        return str(self._playable)
