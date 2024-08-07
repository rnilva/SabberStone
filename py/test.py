import pythonnet; pythonnet.load("coreclr")
import clr; clr.AddReference("SabberStoneCore")

from System import String, Random
from System.Collections.Generic import List
from SabberStoneCore.Model import Game, Card, Cards
from SabberStoneCore.Config import GameConfig
from SabberStoneCore.Enums import CardClass, State as GameState
from SabberStoneCore.Tasks.PlayerTasks.Lite import PlayerTaskLiteContainer as Options


mage_expert_deck = [
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
]

deck1 = List[Card]()
deck2 = List[Card]()

for card_name in mage_expert_deck:
    card = Cards.FromName(card_name)
    deck1.Add(card)
    deck2.Add(card)

config = GameConfig()
config.Player1HeroClass = CardClass.MAGE
config.Player2HeroClass = CardClass.MAGE
config.Player1Deck = deck1
config.Player2Deck = deck2
config.Shuffle = True
config.Logging = True
config.History = False

g = Game(config)

options = Options()

rnd = Random()

game = g.Clone()
game.StartGame()
while game.State != GameState.COMPLETE:
    game.CurrentPlayer.Options(options)
    option = options.GetRandom(rnd)
    print(option)
    game.Process(option)
