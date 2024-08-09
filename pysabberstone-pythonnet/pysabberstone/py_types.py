from typing import TypeAlias

from pysabberstone.model.enums import CardClass

Deck: TypeAlias = tuple[CardClass, list[str]] | str
"""A deck can represented as a tuple of CardClass and list of card names or a deckstring."""
