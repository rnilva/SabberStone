import pysabberstone.core
from pysabberstone.py_types import Deck, CardClass

from SabberStoneCore.Enums import CardClass as _CardClass
from SabberStoneCore.Model import Card as _Card, Cards as _Cards
from System.Collections.Generic import List


def convert_deck(deck: Deck) -> tuple[_CardClass, List[_Card]]:
    card_class: _CardClass
    cards: List[_Card]
    if isinstance(deck, tuple):
        py_card_class, card_names = deck
        card_class = _CardClass(py_card_class)
        cards = List[_Card](len(card_names))
        for name in card_names:
            cards.Add(_Cards.FromName(name))
    else:
        raise NotImplementedError()

    return card_class, cards


if __name__ == "__main__":
    deck = (
        _CardClass.MAGE,
        [
            "Arcane Missiles",
            "Arcane Missiles",
            "Arcane Explosion",
            "Arcane Explosion",
            "Mana Wyrm",
            "Mana Wyrm",
            "Sorcerer's Apprentice",
            "Sorcerer's Apprentice",
            "Counterspell",
            "Counterspell",
            "Kirin Tor Mage",
            "Kirin Tor Mage",
            "Mirror Entity",
            "Mirror Entity",
            "Vaporize",
            "Vaporize",
            "Fireball",
            "Fireball",
            "Polymorph",
            "Polymorph",
            "Water Elemental",
            "Water Elemental",
            "Kobold Geomancer",
            "Kobold Geomancer",
            "Mana Addict",
            "Mana Addict",
            "Azure Drake",
            "Azure Drake",
            "Frost Elemental",
            "Frost Elemental",
        ],
    )

    cls, core_deck = convert_deck(deck)
    print(cls)
    for card in core_deck:
        print(card)
