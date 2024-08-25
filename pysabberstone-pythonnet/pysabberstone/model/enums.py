from enum import IntEnum


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


class CardType(IntEnum):
    INVALID = 0
    GAME = 1
    PLAYER = 2
    HERO = 3
    MINION = 4
    SPELL = 5
    ENCHANTMENT = 6
    WEAPON = 7
    ITEM = 8
    TOKEN = 9
    HERO_POWER = 10
    BLANK = 11
    GAME_MODE_BUTTON = 12
    MOVE_MINION_HOVER_TARGET = 22


class PlayState(IntEnum):
    INVALID = 0
    PLAYING = 1
    WINNING = 2
    LOSING = 3
    WON = 4
    LOST = 5
    TIED = 6
    DISCONNECTED = 7
    CONCEDED = 8


class LogLevel(IntEnum):
    DUMP = 0
    ERROR = 1
    WARNING = 2
    INFO = 3
    VERBOSE = 4
    DEBUG = 5


class FormatType(IntEnum):
    FT_UNKNOWN = 0
    FT_WILD = 1
    FT_STANDARD = 2
    FT_CLASSIC = 3