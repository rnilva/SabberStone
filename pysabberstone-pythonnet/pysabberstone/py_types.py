from enum import IntEnum
from typing import TypeAlias


class CardClass(IntEnum):
    # Custom enums for easy syntax.
    ANOTHER_CLASS = -2
    OP_CLASS = -1

    INVALID = 0
    DEATHKNIGHT = 1
    DRUID = 2
    HUNTER = 3
    MAGE = 4
    PALADIN = 5
    PRIEST = 6
    ROGUE = 7
    SHAMAN = 8
    WARLOCK = 9
    WARRIOR = 10
    DREAM = 11
    NEUTRAL = 12
    WHIZBANG = 13


Deck: TypeAlias = tuple[CardClass, list[str]] | str
"""A deck can represented as a tuple of CardClass and list of card names or a deckstring."""
