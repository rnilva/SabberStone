from pysabberstone.model.enums import CardClass, FormatType

import pysabberstone.core
from SabberStoneCore.Config import Deck as _Deck, DeckSerializer as _DeckSerializer
from SabberStoneCore.Enums import CardClass as _CardClass, FormatType as _FormatType
from SabberStoneCore.Model import Card as _Card, Cards as _Cards
from System import ArgumentException as _ArgumentException
from System.Collections.Generic import Dictionary as _Dictionary, List as _List


class Deck:
    def __init__(
        self,
        cards: list[str],
        hero_class: CardClass,
        format_type: FormatType = FormatType.FT_CLASSIC,
    ) -> None:
        self.cards = cards
        self.hero_class = hero_class
        self.format_type = format_type
        self._deck = None

    @classmethod
    def from_deckstring(cls, deckstring: str):
        try:
            _deck = _DeckSerializer.Deserialize(deckstring)
        except _ArgumentException:
            raise ValueError("Invalid deckstring.")

        _hero_card = _deck.GetHero()

        cards = []
        for card_count_pair in _deck.GetCards():
            card = card_count_pair.Key.Name
            for _ in range(card_count_pair.Value):
                cards.append(card)
            if _hero_card is None and int(card_count_pair.Key.Class) != int(
                CardClass.NEUTRAL
            ):
                _hero_card = card_count_pair.Key

        hero_class = _hero_card.Class
        format_type = FormatType(int(_deck.Format))

        deck = cls(cards, hero_class, format_type)
        deck._deck = _deck
        return deck

    def _to_core_type(self) -> _Deck:
        if self._deck is not None:
            return self._deck

        _ft = _FormatType(int(self.format_type))
        _ids = _Dictionary[int, int]()
        for card in self.cards:
            _card = _Cards.FromName(card, _ft)
            id = _card.AssetId
            if _ids.ContainsKey(id):
                _ids[id] += 1
            else:
                _ids.Add(id, 1)

        _deck = _Deck()
        _deck.CardDbfIds = _ids
        _deck.HeroDbfId = _Cards.HeroCard(_CardClass(int(self.hero_class))).AssetId
        _deck.Format = _ft

        self._deck = _deck
        return _deck

    def _to_core_class_and_cards(self) -> tuple[_CardClass, _List[_Card]]:
        _deck = self._to_core_type()
        _tuple = _deck.ToClassAndCards()
        return _tuple.Item1, _tuple.Item2


if __name__ == "__main__":
    ds = "AAEDAa0GBq+WBLmXBLehBJOiBJiiBNaiBAzLlQTNlQTQlQSAlwS3lwT6oASAoQSpogSXowSrowStowTEowQA"

    d = Deck.from_deckstring(ds)
    print(d.cards)
