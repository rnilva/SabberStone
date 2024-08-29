from pysabberstone.model.enums import FormatType
from pysabberstone.py_types import Deck, CardClass

import pysabberstone.core
from SabberStoneCore.Config import DeckSerializer as _DeckSerializer
from SabberStoneCore.Enums import CardClass as _CardClass, FormatType as _FormatType
from SabberStoneCore.Model import Card as _Card, Cards as _Cards
from System import ArgumentException as _ArgumentException
from System.Collections.Generic import List as _List


def convert_deck(deck: Deck, format: FormatType) -> tuple[_CardClass, _List[_Card]]:
    card_class: _CardClass
    cards: _List[_Card]
    if isinstance(deck, tuple):
        py_card_class, card_names = deck
        card_class = _CardClass(py_card_class)
        cards = _List[_Card](len(card_names))
        for name in card_names:
            cards.Add(_Cards.FromName(name, _FormatType(int(format))))
    else:
        try:
            _deck = _DeckSerializer.Deserialize(deck)
        except _ArgumentException:
            raise ValueError("Invalid deckstring.")

        card_class = _deck.GetHero().Class
        cards = _List[_Card](30)
        for card_count_pair in _deck.GetCards():
            for _ in range(card_count_pair.Value):
                cards.Add(card_count_pair.Key)

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

    deck = "AAEDAaIHBvuWBPqgBIahBLWhBNyhBKWjBAz8lQT9lQTclgTqlgT4oATUoQTdoQTfoQTkoQTnoQTooQSTogQA"

    cls, core_deck = convert_deck(deck, FormatType.FT_CLASSIC)
    print(cls)
    for card in core_deck:
        print(card)
