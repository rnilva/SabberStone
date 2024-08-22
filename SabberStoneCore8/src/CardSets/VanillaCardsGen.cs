using System.Collections.Generic;
using SabberStoneCore.Actions;
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
using SabberStoneCore.Conditions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Zones;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;
using SabberStoneCore.Tasks.SimpleTasks;
using SabberStoneCore.Triggers;
using SabberStoneCore.src.Loader;
// ReSharper disable RedundantEmptyObjectOrCollectionInitializer

namespace SabberStoneCore.CardSets.Classic
{
	public class VanillaCardsGen
	{
		private static void Druid(IDictionary<string, CardDef> cards)
		{
			// ----------------------------------------- MINION - DRUID
			// [VAN_EX1_573] Cenarius - COST:9 [ATK:5/HP:8] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Choose One -</b> Give your other minions +2/+2; or Summon two 2/2 Treants with <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - CHOOSE_ONE = 1
			// - 858 = 36
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_573", new CardDef(new Power
			{
				// TODO [VAN_EX1_573] Cenarius && Test: Cenarius_VAN_EX1_573
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - DRUID
			// [VAN_CS2_232] Ironbark Protector - COST:8 [ATK:8/HP:8] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 205
			// --------------------------------------------------------
			cards.Add("VAN_CS2_232", new CardDef(new Power
			{
				// TODO [VAN_CS2_232] Ironbark Protector && Test: Ironbark Protector_VAN_CS2_232
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - DRUID
			// [VAN_EX1_166] Keeper of the Grove - COST:4 [ATK:2/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Choose One -</b> Deal_2_damage; or <b>Silence</b> a minion.
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 601
			// --------------------------------------------------------
			// RefTag:
			// - SILENCE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_166", new CardDef(new Power
			{
				// TODO [VAN_EX1_166] Keeper of the Grove && Test: Keeper of the Grove_VAN_EX1_166
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - DRUID
			// [VAN_EX1_165] Druid of the Claw - COST:5 [ATK:4/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Choose One -</b> <b>Charge</b>; or +2 Health and <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 692
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// - CHARGE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_165", new CardDef(new Power
			{
				// TODO [VAN_EX1_165] Druid of the Claw && Test: Druid of the Claw_VAN_EX1_165
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - DRUID
			// [VAN_EX1_178] Ancient of War - COST:7 [ATK:5/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Choose One -</b>
			//       +5 Attack; or +5 Health and <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 1035
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_178", new CardDef(new Power
			{
				// TODO [VAN_EX1_178] Ancient of War && Test: Ancient of War_VAN_EX1_178
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - DRUID
			// [VAN_NEW1_008] Ancient of Lore - COST:7 [ATK:5/HP:5] 
			// - Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Choose One -</b> Draw 2 cards; or Restore #5 Health.
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 920
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_008", new CardDef(new Power
			{
				// TODO [VAN_NEW1_008] Ancient of Lore && Test: Ancient of Lore_VAN_NEW1_008
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_155] Mark of Nature - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Choose One -</b> Give a minion +4 Attack; or +4 Health and <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 151
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_155", new CardDef(new Power
			{
				// TODO [VAN_EX1_155] Mark of Nature && Test: Mark of Nature_VAN_EX1_155
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_173] Starfire - COST:6 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $5 damage.
			//       Draw a card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 823
			// --------------------------------------------------------
			cards.Add("VAN_EX1_173", new CardDef(new Power
			{
				// TODO [VAN_EX1_173] Starfire && Test: Starfire_VAN_EX1_173
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_CS2_008] Moonfire - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $1 damage. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 467
			// --------------------------------------------------------
			cards.Add("VAN_CS2_008", new CardDef(new Power
			{
				// TODO [VAN_CS2_008] Moonfire && Test: Moonfire_VAN_CS2_008
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_CS2_009] Mark of the Wild - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a minion <b>Taunt</b> and +2/+2.<i>
			//       (+2 Attack/+2 Health)</i>
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 213
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_009", new CardDef(new Power
			{
				// TODO [VAN_CS2_009] Mark of the Wild && Test: Mark of the Wild_VAN_CS2_009
				InfoCardId = "VAN_CS2_009e",
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_571] Force of Nature - COST:6 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Summon three 2/2 Treants with
			//       <b>Charge</b> that die at the end of the turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 493
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 71310
			// --------------------------------------------------------
			// RefTag:
			// - CHARGE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_571", new CardDef(new Power
			{
				// TODO [VAN_EX1_571] Force of Nature && Test: Force of Nature_VAN_EX1_571
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_160] Power of the Wild - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Choose One -</b> Give your minions +1/+1; or Summon a 3/2 Panther.
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 503
			// --------------------------------------------------------
			cards.Add("VAN_EX1_160", new CardDef(new Power
			{
				// TODO [VAN_EX1_160] Power of the Wild && Test: Power of the Wild_VAN_EX1_160
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_CS2_007] Healing Touch - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Restore #8 Health.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 773
			// --------------------------------------------------------
			cards.Add("VAN_CS2_007", new CardDef(new Power
			{
				// TODO [VAN_CS2_007] Healing Touch && Test: Healing Touch_VAN_CS2_007
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_154] Wrath - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Choose One -</b>
			//       Deal $3 damage to a minion; or $1 damage
			//       and draw a card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 836
			// --------------------------------------------------------
			cards.Add("VAN_EX1_154", new CardDef(new Power
			{
				// TODO [VAN_EX1_154] Wrath && Test: Wrath_VAN_EX1_154
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_578] Savagery - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal damage equal to your hero's Attack to a minion. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - AFFECTED_BY_SPELL_POWER = 1
			// - 858 = 481
			// --------------------------------------------------------
			cards.Add("VAN_EX1_578", new CardDef(new Power
			{
				// TODO [VAN_EX1_578] Savagery && Test: Savagery_VAN_EX1_578
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_CS2_011] Savage Roar - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give your characters +2_Attack this turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 742
			// --------------------------------------------------------
			cards.Add("VAN_CS2_011", new CardDef(new Power
			{
				// TODO [VAN_CS2_011] Savage Roar && Test: Savage Roar_VAN_CS2_011
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_164] Nourish - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Choose One -</b> Gain 2_Mana Crystals; or Draw 3 cards.
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 95
			// --------------------------------------------------------
			cards.Add("VAN_EX1_164", new CardDef(new Power
			{
				// TODO [VAN_EX1_164] Nourish && Test: Nourish_VAN_EX1_164
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_158] Soul of the Forest - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Give your minions "<b>Deathrattle:</b> Summon a 2/2 Treant."
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 381
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 600
			// --------------------------------------------------------
			// RefTag:
			// - DEATHRATTLE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_158", new CardDef(new Power
			{
				// TODO [VAN_EX1_158] Soul of the Forest && Test: Soul of the Forest_VAN_EX1_158
				InfoCardId = "VAN_EX1_158e",
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_CS2_013] Wild Growth - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Gain an empty Mana Crystal.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1124
			// --------------------------------------------------------
			cards.Add("VAN_CS2_013", new CardDef(new Power
			{
				// TODO [VAN_CS2_013] Wild Growth && Test: Wild Growth_VAN_CS2_013
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_570] Bite - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Give your hero +4_Attack this turn. Gain 4 Armor.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 577
			// --------------------------------------------------------
			cards.Add("VAN_EX1_570", new CardDef(new Power
			{
				// TODO [VAN_EX1_570] Bite && Test: Bite_VAN_EX1_570
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_161] Naturalize - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Destroy a minion.
			//       Your opponent draws 2_cards.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 233
			// --------------------------------------------------------
			cards.Add("VAN_EX1_161", new CardDef(new Power
			{
				// TODO [VAN_EX1_161] Naturalize && Test: Naturalize_VAN_EX1_161
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_NEW1_007] Starfall - COST:5 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Choose One -</b>
			//       Deal $5 damage to a minion; or $2 damage to all enemy minions. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - CHOOSE_ONE = 1
			// - 858 = 86
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_007", new CardDef(new Power
			{
				// TODO [VAN_NEW1_007] Starfall && Test: Starfall_VAN_NEW1_007
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_EX1_169] Innervate - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Gain 2 Mana Crystals this turn only.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 254
			// --------------------------------------------------------
			cards.Add("VAN_EX1_169", new CardDef(new Power
			{
				// TODO [VAN_EX1_169] Innervate && Test: Innervate_VAN_EX1_169
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_CS2_005] Claw - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give your hero +2_Attack this turn. Gain 2 Armor.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1050
			// --------------------------------------------------------
			cards.Add("VAN_CS2_005", new CardDef(new Power
			{
				// TODO [VAN_CS2_005] Claw && Test: Claw_VAN_CS2_005
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - DRUID
			// [VAN_CS2_012] Swipe - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $4 damage to an enemy and $1 damage to all other enemies. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 64
			// --------------------------------------------------------
			cards.Add("VAN_CS2_012", new CardDef(new Power
			{
				// TODO [VAN_CS2_012] Swipe && Test: Swipe_VAN_CS2_012
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Hunter(IDictionary<string, CardDef> cards)
		{
			// ---------------------------------------- MINION - HUNTER
			// [VAN_DS1_178] Tundra Rhino - COST:5 [ATK:2/HP:5] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Your Beasts have <b>Charge</b>.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 699
			// --------------------------------------------------------
			// RefTag:
			// - CHARGE = 1
			// --------------------------------------------------------
			cards.Add("VAN_DS1_178", new CardDef(new Power
			{
				// TODO [VAN_DS1_178] Tundra Rhino && Test: Tundra Rhino_VAN_DS1_178
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - HUNTER
			// [VAN_EX1_543] King Krush - COST:9 [ATK:8/HP:8] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - CHARGE = 1
			// - 858 = 1144
			// --------------------------------------------------------
			cards.Add("VAN_EX1_543", new CardDef(new Power
			{
				// TODO [VAN_EX1_543] King Krush && Test: King Krush_VAN_EX1_543
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - HUNTER
			// [VAN_DS1_175] Timber Wolf - COST:1 [ATK:1/HP:1] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Your other Beasts have +1_Attack.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 606
			// --------------------------------------------------------
			cards.Add("VAN_DS1_175", new CardDef(new Power
			{
				// TODO [VAN_DS1_175] Timber Wolf && Test: Timber Wolf_VAN_DS1_175
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - HUNTER
			// [VAN_EX1_531] Scavenging Hyena - COST:2 [ATK:2/HP:2] 
			// - Race: beast, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Whenever a friendly Beast dies, gain +2/+1.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1281
			// --------------------------------------------------------
			cards.Add("VAN_EX1_531", new CardDef(new Power
			{
				// TODO [VAN_EX1_531] Scavenging Hyena && Test: Scavenging Hyena_VAN_EX1_531
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - HUNTER
			// [VAN_CS2_237] Starving Buzzard - COST:2 [ATK:2/HP:1] 
			// - Race: beast, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Whenever you summon a Beast, draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1241
			// --------------------------------------------------------
			cards.Add("VAN_CS2_237", new CardDef(new Power
			{
				// TODO [VAN_CS2_237] Starving Buzzard && Test: Starving Buzzard_VAN_CS2_237
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - HUNTER
			// [VAN_EX1_534] Savannah Highmane - COST:6 [ATK:6/HP:5] 
			// - Race: beast, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Deathrattle:</b> Summon two 2/2 Hyenas.
			// --------------------------------------------------------
			// GameTag:
			// - DEATHRATTLE = 1
			// - 858 = 1261
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1624
			// - 1584 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_534", new CardDef(new Power
			{
				// TODO [VAN_EX1_534] Savannah Highmane && Test: Savannah Highmane_VAN_EX1_534
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - HUNTER
			// [VAN_DS1_070] Houndmaster - COST:4 [ATK:4/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a friendly Beast +2/+2 and <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1003
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_DS1_070", new CardDef(new Power
			{
				// TODO [VAN_DS1_070] Houndmaster && Test: Houndmaster_VAN_DS1_070
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_533] Misdirection - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When an enemy attacks your hero, instead it attacks another random character.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 1091
			// --------------------------------------------------------
			cards.Add("VAN_EX1_533", new CardDef(new Power
			{
				// TODO [VAN_EX1_533] Misdirection && Test: Misdirection_VAN_EX1_533
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_DS1_185] Arcane Shot - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $2 damage. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 877
			// --------------------------------------------------------
			cards.Add("VAN_DS1_185", new CardDef(new Power
			{
				// TODO [VAN_DS1_185] Arcane Shot && Test: Arcane Shot_VAN_DS1_185
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_NEW1_031] Animal Companion - COST:3 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Summon a random Beast Companion.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 437
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_031", new CardDef(new Power
			{
				// TODO [VAN_NEW1_031] Animal Companion && Test: Animal Companion_VAN_NEW1_031
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_609] Snipe - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Secret:</b> After your opponent plays a minion, deal $4 damage to it. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 814
			// --------------------------------------------------------
			cards.Add("VAN_EX1_609", new CardDef(new Power
			{
				// TODO [VAN_EX1_609] Snipe && Test: Snipe_VAN_EX1_609
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_537] Explosive Shot - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal $5 damage to a minion and $2 damage to adjacent ones. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 394
			// --------------------------------------------------------
			cards.Add("VAN_EX1_537", new CardDef(new Power
			{
				// TODO [VAN_EX1_537] Explosive Shot && Test: Explosive Shot_VAN_EX1_537
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_538] Unleash the Hounds - COST:3 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: For each enemy minion, summon a 1/1 Hound with <b>Charge</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1243
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1715
			// --------------------------------------------------------
			// RefTag:
			// - CHARGE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_538", new CardDef(new Power
			{
				// TODO [VAN_EX1_538] Unleash the Hounds && Test: Unleash the Hounds_VAN_EX1_538
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_544] Flare - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: All minions lose <b>Stealth</b>. Destroy all enemy <b>Secrets</b>. Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 896
			// --------------------------------------------------------
			// RefTag:
			// - STEALTH = 1
			// - SECRET = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_544", new CardDef(new Power
			{
				// TODO [VAN_EX1_544] Flare && Test: Flare_VAN_EX1_544
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_610] Explosive Trap - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When your hero is attacked, deal $2 damage to all enemies. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 585
			// --------------------------------------------------------
			cards.Add("VAN_EX1_610", new CardDef(new Power
			{
				// TODO [VAN_EX1_610] Explosive Trap && Test: Explosive Trap_VAN_EX1_610
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_DS1_183] Multi-Shot - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $3 damage to two random enemy minions. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 292
			// --------------------------------------------------------
			cards.Add("VAN_DS1_183", new CardDef(new Power
			{
				// TODO [VAN_DS1_183] Multi-Shot && Test: Multi-Shot_VAN_DS1_183
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_549] Bestial Wrath - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Give a Beast +2 Attack and <b>Immune</b> this turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 903
			// --------------------------------------------------------
			// RefTag:
			// - IMMUNE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_549", new CardDef(new Power
			{
				// TODO [VAN_EX1_549] Bestial Wrath && Test: Bestial Wrath_VAN_EX1_549
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_554] Snake Trap - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When one of your minions is attacked, summon three 1/1 Snakes.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 455
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 71306
			// --------------------------------------------------------
			cards.Add("VAN_EX1_554", new CardDef(new Power
			{
				// TODO [VAN_EX1_554] Snake Trap && Test: Snake Trap_VAN_EX1_554
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_CS2_084] Hunter's Mark - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Change a minion's Health to 1.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 141
			// --------------------------------------------------------
			cards.Add("VAN_CS2_084", new CardDef(new Power
			{
				// TODO [VAN_CS2_084] Hunter's Mark && Test: Hunter's Mark_VAN_CS2_084
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_539] Kill Command - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $3 damage. If you control a Beast, deal
			//       $5 damage instead. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 296
			// --------------------------------------------------------
			cards.Add("VAN_EX1_539", new CardDef(new Power
			{
				// TODO [VAN_EX1_539] Kill Command && Test: Kill Command_VAN_EX1_539
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_611] Freezing Trap - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When an enemy minion attacks, return it to its owner's hand. It costs (2) more.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 519
			// --------------------------------------------------------
			cards.Add("VAN_EX1_611", new CardDef(new Power
			{
				// TODO [VAN_EX1_611] Freezing Trap && Test: Freezing Trap_VAN_EX1_611
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_EX1_617] Deadly Shot - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Destroy a random enemy minion.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1093
			// --------------------------------------------------------
			cards.Add("VAN_EX1_617", new CardDef(new Power
			{
				// TODO [VAN_EX1_617] Deadly Shot && Test: Deadly Shot_VAN_EX1_617
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - HUNTER
			// [VAN_DS1_184] Tracking - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Look at the top 3 cards of your deck. Draw one and discard the others.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1047
			// --------------------------------------------------------
			cards.Add("VAN_DS1_184", new CardDef(new Power
			{
				// TODO [VAN_DS1_184] Tracking && Test: Tracking_VAN_DS1_184
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- WEAPON - HUNTER
			// [VAN_DS1_188] Gladiator's Longbow - COST:7 [ATK:5/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Your hero is <b>Immune</b> while attacking.
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 2
			// - 858 = 311
			// --------------------------------------------------------
			// RefTag:
			// - IMMUNE = 1
			// --------------------------------------------------------
			cards.Add("VAN_DS1_188", new CardDef(new Power
			{
				// TODO [VAN_DS1_188] Gladiator's Longbow && Test: Gladiator's Longbow_VAN_DS1_188
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- WEAPON - HUNTER
			// [VAN_EX1_536] Eaglehorn Bow - COST:3 [ATK:3/HP:0] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever a <b>Secret</b> is revealed, gain +1 Durability.
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 2
			// - 858 = 1662
			// --------------------------------------------------------
			// RefTag:
			// - SECRET = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_536", new CardDef(new Power
			{
				// TODO [VAN_EX1_536] Eaglehorn Bow && Test: Eaglehorn Bow_VAN_EX1_536
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Mage(IDictionary<string, CardDef> cards)
		{
			// ------------------------------------------ MINION - MAGE
			// [VAN_CS2_033] Water Elemental - COST:4 [ATK:3/HP:6] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Freeze</b> any character damaged by this minion.
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - 858 = 395
			// --------------------------------------------------------
			cards.Add("VAN_CS2_033", new CardDef(new Power
			{
				// TODO [VAN_CS2_033] Water Elemental && Test: Water Elemental_VAN_CS2_033
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ MINION - MAGE
			// [VAN_NEW1_012] Mana Wyrm - COST:1 [ATK:1/HP:3] 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Whenever you cast a spell, gain +1 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 405
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_012", new CardDef(new Power
			{
				// TODO [VAN_NEW1_012] Mana Wyrm && Test: Mana Wyrm_VAN_NEW1_012
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ MINION - MAGE
			// [VAN_EX1_612] Kirin Tor Mage - COST:3 [ATK:4/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: [x]<b>Battlecry:</b> The next <b>Secret</b>
			//       you play this turn costs (0).
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 748
			// --------------------------------------------------------
			// RefTag:
			// - SECRET = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_612", new CardDef(new Power
			{
				// TODO [VAN_EX1_612] Kirin Tor Mage && Test: Kirin Tor Mage_VAN_EX1_612
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ MINION - MAGE
			// [VAN_EX1_608] Sorcerer's Apprentice - COST:2 [ATK:3/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Your spells cost (1) less.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 614
			// --------------------------------------------------------
			cards.Add("VAN_EX1_608", new CardDef(new Power
			{
				// TODO [VAN_EX1_608] Sorcerer's Apprentice && Test: Sorcerer's Apprentice_VAN_EX1_608
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ MINION - MAGE
			// [VAN_EX1_559] Archmage Antonidas - COST:7 [ATK:5/HP:7] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: Whenever you cast a spell, add a 'Fireball' spell to_your hand.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 1080
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 68326
			// --------------------------------------------------------
			cards.Add("VAN_EX1_559", new CardDef(new Power
			{
				// TODO [VAN_EX1_559] Archmage Antonidas && Test: Archmage Antonidas_VAN_EX1_559
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ MINION - MAGE
			// [VAN_EX1_274] Ethereal Arcanist - COST:4 [ATK:3/HP:3] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: If you control a <b>Secret</b> at_the end of your turn, gain +2/+2.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1737
			// --------------------------------------------------------
			// RefTag:
			// - SECRET = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_274", new CardDef(new Power
			{
				// TODO [VAN_EX1_274] Ethereal Arcanist && Test: Ethereal Arcanist_VAN_EX1_274
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_025] Arcane Explosion - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $1 damage to all enemy minions. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 447
			// --------------------------------------------------------
			cards.Add("VAN_CS2_025", new CardDef(new Power
			{
				// TODO [VAN_CS2_025] Arcane Explosion && Test: Arcane Explosion_VAN_CS2_025
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_024] Frostbolt - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $3 damage to a_character and <b>Freeze</b> it. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - 858 = 662
			// --------------------------------------------------------
			cards.Add("VAN_CS2_024", new CardDef(new Power
			{
				// TODO [VAN_CS2_024] Frostbolt && Test: Frostbolt_VAN_CS2_024
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_026] Frost Nova - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Freeze</b> all enemy minions.
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - 858 = 587
			// --------------------------------------------------------
			cards.Add("VAN_CS2_026", new CardDef(new Power
			{
				// TODO [VAN_CS2_026] Frost Nova && Test: Frost Nova_VAN_CS2_026
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_tt_010] Spellbender - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When an enemy casts a spell on a minion, summon a 1/3 as the new target.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 366
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 71307
			// --------------------------------------------------------
			cards.Add("VAN_tt_010", new CardDef(new Power
			{
				// TODO [VAN_tt_010] Spellbender && Test: Spellbender_VAN_tt_010
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_028] Blizzard - COST:6 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal $2 damage to all enemy minions and <b>Freeze</b> them. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - 858 = 457
			// --------------------------------------------------------
			cards.Add("VAN_CS2_028", new CardDef(new Power
			{
				// TODO [VAN_CS2_028] Blizzard && Test: Blizzard_VAN_CS2_028
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_022] Polymorph - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Transform a minion
			//       into a 1/1 Sheep.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 77
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 68419
			// --------------------------------------------------------
			cards.Add("VAN_CS2_022", new CardDef(new Power
			{
				// TODO [VAN_CS2_022] Polymorph && Test: Polymorph_VAN_CS2_022
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_032] Flamestrike - COST:7 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $4 damage to all enemy minions. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1004
			// --------------------------------------------------------
			cards.Add("VAN_CS2_032", new CardDef(new Power
			{
				// TODO [VAN_CS2_032] Flamestrike && Test: Flamestrike_VAN_CS2_032
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_279] Pyroblast - COST:10 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Deal $10 damage. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1087
			// --------------------------------------------------------
			cards.Add("VAN_EX1_279", new CardDef(new Power
			{
				// TODO [VAN_EX1_279] Pyroblast && Test: Pyroblast_VAN_EX1_279
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_594] Vaporize - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When a minion attacks your hero, destroy it.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 286
			// --------------------------------------------------------
			cards.Add("VAN_EX1_594", new CardDef(new Power
			{
				// TODO [VAN_EX1_594] Vaporize && Test: Vaporize_VAN_EX1_594
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_023] Arcane Intellect - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Draw 2 cards.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 555
			// --------------------------------------------------------
			cards.Add("VAN_CS2_023", new CardDef(new Power
			{
				// TODO [VAN_CS2_023] Arcane Intellect && Test: Arcane Intellect_VAN_CS2_023
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_027] Mirror Image - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Summon two 0/2 minions with <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1084
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 68418
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_027", new CardDef(new Power
			{
				// TODO [VAN_CS2_027] Mirror Image && Test: Mirror Image_VAN_CS2_027
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_294] Mirror Entity - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: [x]<b>Secret:</b> When
			//       your opponent plays a
			//       minion, summon a copy
			//       of it.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 195
			// --------------------------------------------------------
			cards.Add("VAN_EX1_294", new CardDef(new Power
			{
				// TODO [VAN_EX1_294] Mirror Entity && Test: Mirror Entity_VAN_EX1_294
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_277] Arcane Missiles - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $3 damage randomly split among all enemy characters. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - ImmuneToSpellpower = 1
			// - 858 = 564
			// --------------------------------------------------------
			cards.Add("VAN_EX1_277", new CardDef(new Power
			{
				// TODO [VAN_EX1_277] Arcane Missiles && Test: Arcane Missiles_VAN_EX1_277
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_029] Fireball - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $6 damage. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 315
			// --------------------------------------------------------
			cards.Add("VAN_CS2_029", new CardDef(new Power
			{
				// TODO [VAN_CS2_029] Fireball && Test: Fireball_VAN_CS2_029
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_287] Counterspell - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When your opponent casts a spell, <b>Counter</b> it.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 113
			// --------------------------------------------------------
			// RefTag:
			// - COUNTER = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_287", new CardDef(new Power
			{
				// TODO [VAN_EX1_287] Counterspell && Test: Counterspell_VAN_EX1_287
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_CS2_031] Ice Lance - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Freeze</b> a character. If it was already <b>Frozen</b>, deal $4 damage instead. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - 858 = 172
			// --------------------------------------------------------
			cards.Add("VAN_CS2_031", new CardDef(new Power
			{
				// TODO [VAN_CS2_031] Ice Lance && Test: Ice Lance_VAN_CS2_031
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_289] Ice Barrier - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: [x]<b>Secret:</b> As soon as your
			//       hero is attacked, gain
			//       8 Armor.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 621
			// --------------------------------------------------------
			cards.Add("VAN_EX1_289", new CardDef(new Power
			{
				// TODO [VAN_EX1_289] Ice Barrier && Test: Ice Barrier_VAN_EX1_289
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_295] Ice Block - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When your hero takes fatal damage, prevent it and become <b>Immune</b> this turn.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 192
			// --------------------------------------------------------
			// RefTag:
			// - IMMUNE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_295", new CardDef(new Power
			{
				// TODO [VAN_EX1_295] Ice Block && Test: Ice Block_VAN_EX1_295
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------- SPELL - MAGE
			// [VAN_EX1_275] Cone of Cold - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Freeze</b> a minion and the minions next to it, and deal $1 damage to them. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - 858 = 430
			// --------------------------------------------------------
			cards.Add("VAN_EX1_275", new CardDef(new Power
			{
				// TODO [VAN_EX1_275] Cone of Cold && Test: Cone of Cold_VAN_EX1_275
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Paladin(IDictionary<string, CardDef> cards)
		{
			// --------------------------------------- MINION - PALADIN
			// [VAN_EX1_362] Argent Protector - COST:2 [ATK:2/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a friendly minion <b>Divine Shield</b>.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1022
			// --------------------------------------------------------
			// RefTag:
			// - DIVINE_SHIELD = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_362", new CardDef(new Power
			{
				// TODO [VAN_EX1_362] Argent Protector && Test: Argent Protector_VAN_EX1_362
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - PALADIN
			// [VAN_EX1_383] Tirion Fordring - COST:8 [ATK:6/HP:6] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b><b>Divine Shield</b>,</b> <b>Taunt</b> <b>Deathrattle:</b> Equip a 5/3_Ashbringer.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - TAUNT = 1
			// - DIVINE_SHIELD = 1
			// - DEATHRATTLE = 1
			// - 858 = 890
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1730
			// --------------------------------------------------------
			cards.Add("VAN_EX1_383", new CardDef(new Power
			{
				// TODO [VAN_EX1_383] Tirion Fordring && Test: Tirion Fordring_VAN_EX1_383
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - PALADIN
			// [VAN_EX1_382] Aldor Peacekeeper - COST:3 [ATK:3/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Change an_enemy minion's Attack to 1.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1167
			// --------------------------------------------------------
			cards.Add("VAN_EX1_382", new CardDef(new Power
			{
				// TODO [VAN_EX1_382] Aldor Peacekeeper && Test: Aldor Peacekeeper_VAN_EX1_382
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - PALADIN
			// [VAN_CS2_088] Guardian of Kings - COST:7 [ATK:5/HP:6] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Restore #6 Health to your hero.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1068
			// --------------------------------------------------------
			cards.Add("VAN_CS2_088", new CardDef(new Power
			{
				// TODO [VAN_CS2_088] Guardian of Kings && Test: Guardian of Kings_VAN_CS2_088
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_CS2_093] Consecration - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $2 damage to all enemies. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 476
			// --------------------------------------------------------
			cards.Add("VAN_CS2_093", new CardDef(new Power
			{
				// TODO [VAN_CS2_093] Consecration && Test: Consecration_VAN_CS2_093
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_CS2_087] Blessing of Might - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a minion +3_Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 70
			// --------------------------------------------------------
			cards.Add("VAN_CS2_087", new CardDef(new Power
			{
				// TODO [VAN_CS2_087] Blessing of Might && Test: Blessing of Might_VAN_CS2_087
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_132] Eye for an Eye - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When your hero takes damage, deal_that much damage to the enemy hero.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 462
			// --------------------------------------------------------
			cards.Add("VAN_EX1_132", new CardDef(new Power
			{
				// TODO [VAN_EX1_132] Eye for an Eye && Test: Eye for an Eye_VAN_EX1_132
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_379] Repentance - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Secret:</b> After your opponent plays a minion, reduce its Health to 1.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 232
			// --------------------------------------------------------
			cards.Add("VAN_EX1_379", new CardDef(new Power
			{
				// TODO [VAN_EX1_379] Repentance && Test: Repentance_VAN_EX1_379
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_355] Blessed Champion - COST:5 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Double a minion's Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1522
			// --------------------------------------------------------
			cards.Add("VAN_EX1_355", new CardDef(new Power
			{
				// TODO [VAN_EX1_355] Blessed Champion && Test: Blessed Champion_VAN_EX1_355
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_360] Humility - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Change a minion's Attack to 1.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 854
			// --------------------------------------------------------
			cards.Add("VAN_EX1_360", new CardDef(new Power
			{
				// TODO [VAN_EX1_360] Humility && Test: Humility_VAN_EX1_360
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_354] Lay on Hands - COST:8 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Restore #8 Health. Draw_3 cards.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 594
			// --------------------------------------------------------
			cards.Add("VAN_EX1_354", new CardDef(new Power
			{
				// TODO [VAN_EX1_354] Lay on Hands && Test: Lay on Hands_VAN_EX1_354
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_CS2_094] Hammer of Wrath - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $3 damage.
			//       Draw a card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 250
			// --------------------------------------------------------
			cards.Add("VAN_CS2_094", new CardDef(new Power
			{
				// TODO [VAN_CS2_094] Hammer of Wrath && Test: Hammer of Wrath_VAN_CS2_094
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_363] Blessing of Wisdom - COST:1 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Choose a minion. Whenever it attacks, draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1373
			// --------------------------------------------------------
			cards.Add("VAN_EX1_363", new CardDef(new Power
			{
				// TODO [VAN_EX1_363] Blessing of Wisdom && Test: Blessing of Wisdom_VAN_EX1_363
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_349] Divine Favor - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Draw cards until you have as many in hand as your opponent.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 679
			// --------------------------------------------------------
			cards.Add("VAN_EX1_349", new CardDef(new Power
			{
				// TODO [VAN_EX1_349] Divine Favor && Test: Divine Favor_VAN_EX1_349
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_371] Hand of Protection - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a minion <b>Divine Shield</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 727
			// --------------------------------------------------------
			// RefTag:
			// - DIVINE_SHIELD = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_371", new CardDef(new Power
			{
				// TODO [VAN_EX1_371] Hand of Protection && Test: Hand of Protection_VAN_EX1_371
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_CS2_089] Holy Light - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Restore #6 Health.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 291
			// --------------------------------------------------------
			cards.Add("VAN_CS2_089", new CardDef(new Power
			{
				// TODO [VAN_CS2_089] Holy Light && Test: Holy Light_VAN_CS2_089
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_136] Redemption - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When a friendly minion dies, return it to life with 1 Health.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 140
			// --------------------------------------------------------
			cards.Add("VAN_EX1_136", new CardDef(new Power
			{
				// TODO [VAN_EX1_136] Redemption && Test: Redemption_VAN_EX1_136
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_CS2_092] Blessing of Kings - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a minion +4/+4. <i>(+4 Attack/+4 Health)</i>
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 943
			// --------------------------------------------------------
			cards.Add("VAN_CS2_092", new CardDef(new Power
			{
				// TODO [VAN_CS2_092] Blessing of Kings && Test: Blessing of Kings_VAN_CS2_092
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_365] Holy Wrath - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Draw a card and deal_damage equal to_its Cost. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - AFFECTED_BY_SPELL_POWER = 1
			// - 858 = 435
			// --------------------------------------------------------
			cards.Add("VAN_EX1_365", new CardDef(new Power
			{
				// TODO [VAN_EX1_365] Holy Wrath && Test: Holy Wrath_VAN_EX1_365
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_619] Equality - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Change the Health of ALL minions to 1.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 756
			// --------------------------------------------------------
			cards.Add("VAN_EX1_619", new CardDef(new Power
			{
				// TODO [VAN_EX1_619] Equality && Test: Equality_VAN_EX1_619
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_384] Avenging Wrath - COST:6 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Deal $8 damage randomly split among all enemy characters. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - ImmuneToSpellpower = 1
			// - 858 = 1174
			// --------------------------------------------------------
			cards.Add("VAN_EX1_384", new CardDef(new Power
			{
				// TODO [VAN_EX1_384] Avenging Wrath && Test: Avenging Wrath_VAN_EX1_384
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - PALADIN
			// [VAN_EX1_130] Noble Sacrifice - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Secret:</b> When an enemy attacks, summon a 2/1 Defender as the new target.
			// --------------------------------------------------------
			// GameTag:
			// - SECRET = 1
			// - 858 = 584
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 71411
			// --------------------------------------------------------
			cards.Add("VAN_EX1_130", new CardDef(new Power
			{
				// TODO [VAN_EX1_130] Noble Sacrifice && Test: Noble Sacrifice_VAN_EX1_130
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- WEAPON - PALADIN
			// [VAN_EX1_366] Sword of Justice - COST:3 [ATK:1/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: After you summon a minion, give it +1/+1 and this loses 1_Durability.
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 5
			// - 858 = 643
			// --------------------------------------------------------
			cards.Add("VAN_EX1_366", new CardDef(new Power
			{
				// TODO [VAN_EX1_366] Sword of Justice && Test: Sword of Justice_VAN_EX1_366
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- WEAPON - PALADIN
			// [VAN_CS2_097] Truesilver Champion - COST:4 [ATK:4/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Whenever your hero attacks, restore #2_Health to it.
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 2
			// - 858 = 847
			// --------------------------------------------------------
			cards.Add("VAN_CS2_097", new CardDef(new Power
			{
				// TODO [VAN_CS2_097] Truesilver Champion && Test: Truesilver Champion_VAN_CS2_097
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- WEAPON - PALADIN
			// [VAN_CS2_091] Light's Justice - COST:1 [ATK:1/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 4
			// - 858 = 383
			// --------------------------------------------------------
			cards.Add("VAN_CS2_091", new CardDef(new Power
			{
				// TODO [VAN_CS2_091] Light's Justice && Test: Light's Justice_VAN_CS2_091
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Priest(IDictionary<string, CardDef> cards)
		{
			// ---------------------------------------- MINION - PRIEST
			// [VAN_EX1_341] Lightwell - COST:2 [ATK:0/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: At the start of your turn, restore #3 Health to a damaged friendly character.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 797
			// --------------------------------------------------------
			cards.Add("VAN_EX1_341", new CardDef(new Power
			{
				// TODO [VAN_EX1_341] Lightwell && Test: Lightwell_VAN_EX1_341
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - PRIEST
			// [VAN_EX1_623] Temple Enforcer - COST:6 [ATK:6/HP:6] 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a friendly minion +3 Health.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1364
			// --------------------------------------------------------
			cards.Add("VAN_EX1_623", new CardDef(new Power
			{
				// TODO [VAN_EX1_623] Temple Enforcer && Test: Temple Enforcer_VAN_EX1_623
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - PRIEST
			// [VAN_EX1_335] Lightspawn - COST:4 [ATK:0/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: This minion's Attack is always equal to its Health.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 886
			// --------------------------------------------------------
			cards.Add("VAN_EX1_335", new CardDef(new Power
			{
				// TODO [VAN_EX1_335] Lightspawn && Test: Lightspawn_VAN_EX1_335
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - PRIEST
			// [VAN_EX1_591] Auchenai Soulpriest - COST:4 [ATK:3/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Your cards and powers that restore Health now deal damage instead.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 237
			// --------------------------------------------------------
			cards.Add("VAN_EX1_591", new CardDef(new Power
			{
				// TODO [VAN_EX1_591] Auchenai Soulpriest && Test: Auchenai Soulpriest_VAN_EX1_591
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - PRIEST
			// [VAN_EX1_091] Cabal Shadow Priest - COST:6 [ATK:4/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Take control of an enemy minion that has 2 or less Attack.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 272
			// --------------------------------------------------------
			cards.Add("VAN_EX1_091", new CardDef(new Power
			{
				// TODO [VAN_EX1_091] Cabal Shadow Priest && Test: Cabal Shadow Priest_VAN_EX1_091
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - PRIEST
			// [VAN_EX1_350] Prophet Velen - COST:7 [ATK:7/HP:7] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: Double the damage and healing of your spells and Hero Power.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 9
			// --------------------------------------------------------
			cards.Add("VAN_EX1_350", new CardDef(new Power
			{
				// TODO [VAN_EX1_350] Prophet Velen && Test: Prophet Velen_VAN_EX1_350
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - PRIEST
			// [VAN_CS2_235] Northshire Cleric - COST:1 [ATK:1/HP:3] 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Whenever a minion is healed, draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1650
			// --------------------------------------------------------
			cards.Add("VAN_CS2_235", new CardDef(new Power
			{
				// TODO [VAN_CS2_235] Northshire Cleric && Test: Northshire Cleric_VAN_CS2_235
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_DS1_233] Mind Blast - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Deal $5 damage to the enemy hero. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 545
			// --------------------------------------------------------
			cards.Add("VAN_DS1_233", new CardDef(new Power
			{
				// TODO [VAN_DS1_233] Mind Blast && Test: Mind Blast_VAN_DS1_233
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS1_112] Holy Nova - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $2 damage to all enemies. Restore #2 Health to all friendly characters. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 841
			// --------------------------------------------------------
			cards.Add("VAN_CS1_112", new CardDef(new Power
			{
				// TODO [VAN_CS1_112] Holy Nova && Test: Holy Nova_VAN_CS1_112
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_345] Mindgames - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Put a copy of
			//       a random minion from
			//       your opponent's deck into the battlefield.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 145
			// --------------------------------------------------------
			cards.Add("VAN_EX1_345", new CardDef(new Power
			{
				// TODO [VAN_EX1_345] Mindgames && Test: Mindgames_VAN_EX1_345
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS2_003] Mind Vision - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Put a copy of a random card in your opponent's hand into your hand.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1099
			// --------------------------------------------------------
			cards.Add("VAN_CS2_003", new CardDef(new Power
			{
				// TODO [VAN_CS2_003] Mind Vision && Test: Mind Vision_VAN_CS2_003
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_625] Shadowform - COST:3 
			// - Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Your Hero Power becomes 'Deal 2 damage.' If already in Shadowform: 3 damage.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1368
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1622
			// --------------------------------------------------------
			cards.Add("VAN_EX1_625", new CardDef(new Power
			{
				// TODO [VAN_EX1_625] Shadowform && Test: Shadowform_VAN_EX1_625
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS1_113] Mind Control - COST:10 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Take control of an enemy minion.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 8
			// --------------------------------------------------------
			cards.Add("VAN_CS1_113", new CardDef(new Power
			{
				// TODO [VAN_CS1_113] Mind Control && Test: Mind Control_VAN_CS1_113
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_626] Mass Dispel - COST:4 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Silence</b> all enemy minions. Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - SILENCE = 1
			// - 858 = 1366
			// --------------------------------------------------------
			cards.Add("VAN_EX1_626", new CardDef(new Power
			{
				// TODO [VAN_EX1_626] Mass Dispel && Test: Mass Dispel_VAN_EX1_626
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_622] Shadow Word: Death - COST:3 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Destroy a minion with 5_or more Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1363
			// --------------------------------------------------------
			cards.Add("VAN_EX1_622", new CardDef(new Power
			{
				// TODO [VAN_EX1_622] Shadow Word: Death && Test: Shadow Word: Death_VAN_EX1_622
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_332] Silence - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Silence</b> a minion.
			// --------------------------------------------------------
			// GameTag:
			// - SILENCE = 1
			// - 858 = 1189
			// --------------------------------------------------------
			cards.Add("VAN_EX1_332", new CardDef(new Power
			{
				// TODO [VAN_EX1_332] Silence && Test: Silence_VAN_EX1_332
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_339] Thoughtsteal - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Copy 2 cards in your opponent's deck and add them to your hand.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 30
			// --------------------------------------------------------
			cards.Add("VAN_EX1_339", new CardDef(new Power
			{
				// TODO [VAN_EX1_339] Thoughtsteal && Test: Thoughtsteal_VAN_EX1_339
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS1_129] Inner Fire - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Change a minion's Attack to be equal to its Health.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 376
			// --------------------------------------------------------
			cards.Add("VAN_CS1_129", new CardDef(new Power
			{
				// TODO [VAN_CS1_129] Inner Fire && Test: Inner Fire_VAN_CS1_129
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_621] Circle of Healing - COST:0 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Restore #4 Health to ALL_minions.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1362
			// --------------------------------------------------------
			cards.Add("VAN_EX1_621", new CardDef(new Power
			{
				// TODO [VAN_EX1_621] Circle of Healing && Test: Circle of Healing_VAN_EX1_621
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_624] Holy Fire - COST:6 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal $5 damage. Restore #5 Health to your hero. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1365
			// --------------------------------------------------------
			cards.Add("VAN_EX1_624", new CardDef(new Power
			{
				// TODO [VAN_EX1_624] Holy Fire && Test: Holy Fire_VAN_EX1_624
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS1_130] Holy Smite - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $2 damage. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 279
			// --------------------------------------------------------
			cards.Add("VAN_CS1_130", new CardDef(new Power
			{
				// TODO [VAN_CS1_130] Holy Smite && Test: Holy Smite_VAN_CS1_130
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_EX1_334] Shadow Madness - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Gain control of an enemy minion with 3 or less Attack until end of turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 220
			// --------------------------------------------------------
			cards.Add("VAN_EX1_334", new CardDef(new Power
			{
				// TODO [VAN_EX1_334] Shadow Madness && Test: Shadow Madness_VAN_EX1_334
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS2_234] Shadow Word: Pain - COST:2 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Destroy a minion with 3_or less Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1367
			// --------------------------------------------------------
			cards.Add("VAN_CS2_234", new CardDef(new Power
			{
				// TODO [VAN_CS2_234] Shadow Word: Pain && Test: Shadow Word: Pain_VAN_CS2_234
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS2_236] Divine Spirit - COST:2 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Double a minion's Health.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1361
			// --------------------------------------------------------
			cards.Add("VAN_CS2_236", new CardDef(new Power
			{
				// TODO [VAN_CS2_236] Divine Spirit && Test: Divine Spirit_VAN_CS2_236
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - PRIEST
			// [VAN_CS2_004] Power Word: Shield - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a minion +2_Health.
			//       Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 613
			// --------------------------------------------------------
			cards.Add("VAN_CS2_004", new CardDef(new Power
			{
				// TODO [VAN_CS2_004] Power Word: Shield && Test: Power Word: Shield_VAN_CS2_004
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Rogue(IDictionary<string, CardDef> cards)
		{
			// ----------------------------------------- MINION - ROGUE
			// [VAN_EX1_522] Patient Assassin - COST:2 [ATK:1/HP:1] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Stealth</b>. Destroy any minion damaged by this minion.
			// --------------------------------------------------------
			// GameTag:
			// - STEALTH = 1
			// - 858 = 1133
			// - 1944 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_522", new CardDef(new Power
			{
				// TODO [VAN_EX1_522] Patient Assassin && Test: Patient Assassin_VAN_EX1_522
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - ROGUE
			// [VAN_NEW1_005] Kidnapper - COST:6 [ATK:5/HP:3] 
			// - Race: undead, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Combo:</b> Return a minion to_its owner's hand.
			// --------------------------------------------------------
			// GameTag:
			// - COMBO = 1
			// - 858 = 287
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_005", new CardDef(new Power
			{
				// TODO [VAN_NEW1_005] Kidnapper && Test: Kidnapper_VAN_NEW1_005
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - ROGUE
			// [VAN_NEW1_014] Master of Disguise - COST:4 [ATK:4/HP:4] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a friendly minion <b>Stealth</b>.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 887
			// --------------------------------------------------------
			// RefTag:
			// - STEALTH = 1
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_014", new CardDef(new Power
			{
				// TODO [VAN_NEW1_014] Master of Disguise && Test: Master of Disguise_VAN_NEW1_014
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - ROGUE
			// [VAN_EX1_131] Defias Ringleader - COST:2 [ATK:2/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Combo:</b> Summon a 2/1 Defias Bandit.
			// --------------------------------------------------------
			// GameTag:
			// - COMBO = 1
			// - 858 = 201
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 488
			// --------------------------------------------------------
			cards.Add("VAN_EX1_131", new CardDef(new Power
			{
				// TODO [VAN_EX1_131] Defias Ringleader && Test: Defias Ringleader_VAN_EX1_131
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - ROGUE
			// [VAN_EX1_613] Edwin VanCleef - COST:3 [ATK:2/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Combo:</b> Gain +2/+2 for each card played earlier this turn.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - COMBO = 1
			// - 858 = 306
			// --------------------------------------------------------
			cards.Add("VAN_EX1_613", new CardDef(new Power
			{
				// TODO [VAN_EX1_613] Edwin VanCleef && Test: Edwin VanCleef_VAN_EX1_613
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- MINION - ROGUE
			// [VAN_EX1_134] SI:7 Agent - COST:3 [ATK:3/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Combo:</b> Deal 2 damage.
			// --------------------------------------------------------
			// GameTag:
			// - COMBO = 1
			// - 858 = 1117
			// --------------------------------------------------------
			cards.Add("VAN_EX1_134", new CardDef(new Power
			{
				// TODO [VAN_EX1_134] SI:7 Agent && Test: SI:7 Agent_VAN_EX1_134
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_278] Shiv - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $1 damage.
			//       Draw a card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 573
			// --------------------------------------------------------
			cards.Add("VAN_EX1_278", new CardDef(new Power
			{
				// TODO [VAN_EX1_278] Shiv && Test: Shiv_VAN_EX1_278
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_NEW1_004] Vanish - COST:6 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Return all minions to their owner's hand.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 196
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_004", new CardDef(new Power
			{
				// TODO [VAN_NEW1_004] Vanish && Test: Vanish_VAN_NEW1_004
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_124] Eviscerate - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Deal $2 damage. <b>Combo:</b> Deal $4 damage instead. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - COMBO = 1
			// - 858 = 904
			// --------------------------------------------------------
			cards.Add("VAN_EX1_124", new CardDef(new Power
			{
				// TODO [VAN_EX1_124] Eviscerate && Test: Eviscerate_VAN_EX1_124
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_145] Preparation - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: The next spell you cast this turn costs (3) less.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1158
			// --------------------------------------------------------
			cards.Add("VAN_EX1_145", new CardDef(new Power
			{
				// TODO [VAN_EX1_145] Preparation && Test: Preparation_VAN_EX1_145
				InfoCardId = "VAN_EX1_145e",
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_CS2_233] Blade Flurry - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Destroy your weapon and deal its damage to all enemies. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - AFFECTED_BY_SPELL_POWER = 1
			// - 858 = 1064
			// --------------------------------------------------------
			cards.Add("VAN_CS2_233", new CardDef(new Power
			{
				// TODO [VAN_CS2_233] Blade Flurry && Test: Blade Flurry_VAN_CS2_233
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_144] Shadowstep - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Return a friendly minion to your hand. It_costs (2) less.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 365
			// --------------------------------------------------------
			cards.Add("VAN_EX1_144", new CardDef(new Power
			{
				// TODO [VAN_EX1_144] Shadowstep && Test: Shadowstep_VAN_EX1_144
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_126] Betrayal - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Force an enemy minion to deal its damage to the minions next to it.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 282
			// --------------------------------------------------------
			cards.Add("VAN_EX1_126", new CardDef(new Power
			{
				// TODO [VAN_EX1_126] Betrayal && Test: Betrayal_VAN_EX1_126
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_CS2_075] Sinister Strike - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $3 damage to the_enemy hero. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 710
			// --------------------------------------------------------
			cards.Add("VAN_CS2_075", new CardDef(new Power
			{
				// TODO [VAN_CS2_075] Sinister Strike && Test: Sinister Strike_VAN_CS2_075
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_137] Headcrack - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal $2 damage to the enemy hero. <b>Combo:</b> Return this to your hand next turn. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - COMBO = 1
			// - 858 = 708
			// --------------------------------------------------------
			cards.Add("VAN_EX1_137", new CardDef(new Power
			{
				// TODO [VAN_EX1_137] Headcrack && Test: Headcrack_VAN_EX1_137
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_128] Conceal - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Give your minions <b>Stealth</b> until your next_turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 990
			// --------------------------------------------------------
			// RefTag:
			// - STEALTH = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_128", new CardDef(new Power
			{
				// TODO [VAN_EX1_128] Conceal && Test: Conceal_VAN_EX1_128
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_CS2_076] Assassinate - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Destroy an enemy minion.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 345
			// --------------------------------------------------------
			cards.Add("VAN_CS2_076", new CardDef(new Power
			{
				// TODO [VAN_CS2_076] Assassinate && Test: Assassinate_VAN_CS2_076
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_581] Sap - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Return an enemy minion to your opponent's hand.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 461
			// --------------------------------------------------------
			cards.Add("VAN_EX1_581", new CardDef(new Power
			{
				// TODO [VAN_EX1_581] Sap && Test: Sap_VAN_EX1_581
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_CS2_072] Backstab - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $2 damage to an undamaged minion. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 180
			// --------------------------------------------------------
			cards.Add("VAN_CS2_072", new CardDef(new Power
			{
				// TODO [VAN_CS2_072] Backstab && Test: Backstab_VAN_CS2_072
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_CS2_073] Cold Blood - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Give a minion +2 Attack. <b>Combo:</b> +4 Attack instead.
			// --------------------------------------------------------
			// GameTag:
			// - COMBO = 1
			// - 858 = 268
			// --------------------------------------------------------
			cards.Add("VAN_CS2_073", new CardDef(new Power
			{
				// TODO [VAN_CS2_073] Cold Blood && Test: Cold Blood_VAN_CS2_073
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_CS2_074] Deadly Poison - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give your weapon +2_Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 459
			// --------------------------------------------------------
			cards.Add("VAN_CS2_074", new CardDef(new Power
			{
				// TODO [VAN_CS2_074] Deadly Poison && Test: Deadly Poison_VAN_CS2_074
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_CS2_077] Sprint - COST:7 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Draw 4 cards.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 630
			// --------------------------------------------------------
			cards.Add("VAN_CS2_077", new CardDef(new Power
			{
				// TODO [VAN_CS2_077] Sprint && Test: Sprint_VAN_CS2_077
				//PowerTask = null,
				//Trigger = null,
			}));

			// ------------------------------------------ SPELL - ROGUE
			// [VAN_EX1_129] Fan of Knives - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $1 damage to all enemy minions. Draw_a card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 667
			// --------------------------------------------------------
			cards.Add("VAN_EX1_129", new CardDef(new Power
			{
				// TODO [VAN_EX1_129] Fan of Knives && Test: Fan of Knives_VAN_EX1_129
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- WEAPON - ROGUE
			// [VAN_EX1_133] Perdition's Blade - COST:3 [ATK:2/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 1 damage. <b>Combo:</b> Deal 2 instead.
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 2
			// - BATTLECRY = 1
			// - COMBO = 1
			// - 858 = 391
			// --------------------------------------------------------
			cards.Add("VAN_EX1_133", new CardDef(new Power
			{
				// TODO [VAN_EX1_133] Perdition's Blade && Test: Perdition's Blade_VAN_EX1_133
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- WEAPON - ROGUE
			// [VAN_CS2_080] Assassin's Blade - COST:5 [ATK:3/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 4
			// - 858 = 421
			// --------------------------------------------------------
			cards.Add("VAN_CS2_080", new CardDef(new Power
			{
				// TODO [VAN_CS2_080] Assassin's Blade && Test: Assassin's Blade_VAN_CS2_080
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Shaman(IDictionary<string, CardDef> cards)
		{
			// ---------------------------------------- MINION - SHAMAN
			// [VAN_NEW1_010] Al'Akir the Windlord - COST:8 [ATK:3/HP:5] 
			// - Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Charge, Divine Shield, Taunt, Windfury</b>
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - WINDFURY = 1
			// - TAUNT = 1
			// - DIVINE_SHIELD = 1
			// - CHARGE = 1
			// - 858 = 32
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_010", new CardDef(new Power
			{
				// TODO [VAN_NEW1_010] Al'Akir the Windlord && Test: Al'Akir the Windlord_VAN_NEW1_010
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - SHAMAN
			// [VAN_EX1_243] Dust Devil - COST:1 [ATK:3/HP:1] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Windfury</b>. <b>Overload:</b> (2)
			// --------------------------------------------------------
			// GameTag:
			// - WINDFURY = 1
			// - OVERLOAD = 2
			// - 858 = 618
			// --------------------------------------------------------
			cards.Add("VAN_EX1_243", new CardDef(new Power
			{
				// TODO [VAN_EX1_243] Dust Devil && Test: Dust Devil_VAN_EX1_243
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - SHAMAN
			// [VAN_EX1_565] Flametongue Totem - COST:2 [ATK:0/HP:3] 
			// - Race: totem, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Adjacent minions have +2_Attack.
			// --------------------------------------------------------
			// GameTag:
			// - ADJACENT_BUFF = 1
			// - AURA = 1
			// - 858 = 1008
			// --------------------------------------------------------
			cards.Add("VAN_EX1_565", new CardDef(new Power
			{
				// TODO [VAN_EX1_565] Flametongue Totem && Test: Flametongue Totem_VAN_EX1_565
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - SHAMAN
			// [VAN_EX1_587] Windspeaker - COST:4 [ATK:3/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a friendly minion <b>Windfury</b>.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 178
			// --------------------------------------------------------
			// RefTag:
			// - WINDFURY = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_587", new CardDef(new Power
			{
				// TODO [VAN_EX1_587] Windspeaker && Test: Windspeaker_VAN_EX1_587
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - SHAMAN
			// [VAN_CS2_042] Fire Elemental - COST:6 [ATK:6/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 3 damage.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 189
			// --------------------------------------------------------
			cards.Add("VAN_CS2_042", new CardDef(new Power
			{
				// TODO [VAN_CS2_042] Fire Elemental && Test: Fire Elemental_VAN_CS2_042
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - SHAMAN
			// [VAN_EX1_250] Earth Elemental - COST:5 [ATK:7/HP:8] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Taunt</b>. <b><b>Overload</b>:</b> (3)
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - OVERLOAD = 3
			// - 858 = 1141
			// --------------------------------------------------------
			cards.Add("VAN_EX1_250", new CardDef(new Power
			{
				// TODO [VAN_EX1_250] Earth Elemental && Test: Earth Elemental_VAN_EX1_250
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - SHAMAN
			// [VAN_EX1_258] Unbound Elemental - COST:3 [ATK:2/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Whenever you play a card_with <b>Overload</b>, gain_+1/+1.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 774
			// --------------------------------------------------------
			// RefTag:
			// - OVERLOAD = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_258", new CardDef(new Power
			{
				// TODO [VAN_EX1_258] Unbound Elemental && Test: Unbound Elemental_VAN_EX1_258
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- MINION - SHAMAN
			// [VAN_EX1_575] Mana Tide Totem - COST:3 [ATK:0/HP:3] 
			// - Race: totem, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: At the end of your turn, draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 513
			// --------------------------------------------------------
			cards.Add("VAN_EX1_575", new CardDef(new Power
			{
				// TODO [VAN_EX1_575] Mana Tide Totem && Test: Mana Tide Totem_VAN_EX1_575
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_CS2_053] Far Sight - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Draw a card. That card costs (3) less.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 818
			// --------------------------------------------------------
			cards.Add("VAN_CS2_053", new CardDef(new Power
			{
				// TODO [VAN_CS2_053] Far Sight && Test: Far Sight_VAN_CS2_053
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_246] Hex - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Transform a minion into a 0/1 Frog with <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 766
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 548
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_246", new CardDef(new Power
			{
				// TODO [VAN_EX1_246] Hex && Test: Hex_VAN_EX1_246
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_CS2_045] Rockbiter Weapon - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a friendly character +3 Attack this turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 239
			// --------------------------------------------------------
			cards.Add("VAN_CS2_045", new CardDef(new Power
			{
				// TODO [VAN_CS2_045] Rockbiter Weapon && Test: Rockbiter Weapon_VAN_CS2_045
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_245] Earth Shock - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Silence</b> a minion, then deal $1 damage to it. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - SILENCE = 1
			// - 858 = 767
			// --------------------------------------------------------
			cards.Add("VAN_EX1_245", new CardDef(new Power
			{
				// TODO [VAN_EX1_245] Earth Shock && Test: Earth Shock_VAN_EX1_245
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_238] Lightning Bolt - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Deal $3 damage. <b>Overload:</b> (1) @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - OVERLOAD = 1
			// - 858 = 505
			// --------------------------------------------------------
			cards.Add("VAN_EX1_238", new CardDef(new Power
			{
				// TODO [VAN_EX1_238] Lightning Bolt && Test: Lightning Bolt_VAN_EX1_238
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_251] Forked Lightning - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Deal $2 damage to 2_random enemy minions. <b>Overload:</b> (2) @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - OVERLOAD = 2
			// - 858 = 299
			// --------------------------------------------------------
			cards.Add("VAN_EX1_251", new CardDef(new Power
			{
				// TODO [VAN_EX1_251] Forked Lightning && Test: Forked Lightning_VAN_EX1_251
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_CS2_038] Ancestral Spirit - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Choose a minion. When that minion is destroyed, return it to the battlefield.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 404
			// --------------------------------------------------------
			// RefTag:
			// - DEATHRATTLE = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_038", new CardDef(new Power
			{
				// TODO [VAN_CS2_038] Ancestral Spirit && Test: Ancestral Spirit_VAN_CS2_038
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_241] Lava Burst - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal $5 damage. <b>Overload:</b> (2) @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - OVERLOAD = 2
			// - 858 = 864
			// --------------------------------------------------------
			cards.Add("VAN_EX1_241", new CardDef(new Power
			{
				// TODO [VAN_EX1_241] Lava Burst && Test: Lava Burst_VAN_EX1_241
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_CS2_039] Windfury - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a minion <b>Windfury</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 51
			// --------------------------------------------------------
			// RefTag:
			// - WINDFURY = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_039", new CardDef(new Power
			{
				// TODO [VAN_CS2_039] Windfury && Test: Windfury_VAN_CS2_039
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_CS2_041] Ancestral Healing - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Restore a minion
			//       to full Health and
			//       give it <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 149
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_041", new CardDef(new Power
			{
				// TODO [VAN_CS2_041] Ancestral Healing && Test: Ancestral Healing_VAN_CS2_041
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_CS2_037] Frost Shock - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $1 damage to an enemy character and <b>Freeze</b> it. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - 858 = 971
			// --------------------------------------------------------
			cards.Add("VAN_CS2_037", new CardDef(new Power
			{
				// TODO [VAN_CS2_037] Frost Shock && Test: Frost Shock_VAN_CS2_037
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_259] Lightning Storm - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal $2-$3 damage to all enemy minions. <b>Overload:</b> (2) @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - OVERLOAD = 2
			// - 858 = 629
			// --------------------------------------------------------
			cards.Add("VAN_EX1_259", new CardDef(new Power
			{
				// TODO [VAN_EX1_259] Lightning Storm && Test: Lightning Storm_VAN_EX1_259
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_248] Feral Spirit - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Summon two 2/3 Spirit Wolves with <b>Taunt</b>. <b>Overload:</b> (2)
			// --------------------------------------------------------
			// GameTag:
			// - OVERLOAD = 2
			// - 858 = 238
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 70065
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_248", new CardDef(new Power
			{
				// TODO [VAN_EX1_248] Feral Spirit && Test: Feral Spirit_VAN_EX1_248
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_EX1_244] Totemic Might - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give your Totems +2_Health.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 830
			// --------------------------------------------------------
			cards.Add("VAN_EX1_244", new CardDef(new Power
			{
				// TODO [VAN_EX1_244] Totemic Might && Test: Totemic Might_VAN_EX1_244
				//PowerTask = null,
				//Trigger = null,
			}));

			// ----------------------------------------- SPELL - SHAMAN
			// [VAN_CS2_046] Bloodlust - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give your minions +3_Attack this turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1171
			// --------------------------------------------------------
			cards.Add("VAN_CS2_046", new CardDef(new Power
			{
				// TODO [VAN_CS2_046] Bloodlust && Test: Bloodlust_VAN_CS2_046
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- WEAPON - SHAMAN
			// [VAN_EX1_567] Doomhammer - COST:5 [ATK:2/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Windfury, Overload:</b> (2)
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 8
			// - WINDFURY = 1
			// - OVERLOAD = 2
			// - 858 = 352
			// --------------------------------------------------------
			cards.Add("VAN_EX1_567", new CardDef(new Power
			{
				// TODO [VAN_EX1_567] Doomhammer && Test: Doomhammer_VAN_EX1_567
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- WEAPON - SHAMAN
			// [VAN_EX1_247] Stormforged Axe - COST:2 [ATK:2/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Overload:</b> (1)
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 3
			// - OVERLOAD = 1
			// - 858 = 960
			// --------------------------------------------------------
			cards.Add("VAN_EX1_247", new CardDef(new Power
			{
				// TODO [VAN_EX1_247] Stormforged Axe && Test: Stormforged Axe_VAN_EX1_247
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Warlock(IDictionary<string, CardDef> cards)
		{
			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_319] Flame Imp - COST:1 [ATK:3/HP:2] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 3 damage to your hero.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1090
			// - 1965 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_319", new CardDef(new Power
			{
				// TODO [VAN_EX1_319] Flame Imp && Test: Flame Imp_VAN_EX1_319
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_CS2_059] Blood Imp - COST:1 [ATK:0/HP:1] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: [x]  <b>Stealth</b>. At the end of your  
			//       turn, give another random
			//        friendly minion +1 Health.
			// --------------------------------------------------------
			// GameTag:
			// - STEALTH = 1
			// - 858 = 469
			// - 1965 = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_059", new CardDef(new Power
			{
				// TODO [VAN_CS2_059] Blood Imp && Test: Blood Imp_VAN_CS2_059
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_CS2_065] Voidwalker - COST:1 [ATK:1/HP:3] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 48
			// --------------------------------------------------------
			cards.Add("VAN_CS2_065", new CardDef(new Power
			{
				// TODO [VAN_CS2_065] Voidwalker && Test: Voidwalker_VAN_CS2_065
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_301] Felguard - COST:3 [ATK:3/HP:5] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			//       <b>Battlecry:</b> Destroy one of your Mana Crystals.
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - BATTLECRY = 1
			// - 858 = 517
			// --------------------------------------------------------
			cards.Add("VAN_EX1_301", new CardDef(new Power
			{
				// TODO [VAN_EX1_301] Felguard && Test: Felguard_VAN_EX1_301
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_CS2_064] Dread Infernal - COST:6 [ATK:6/HP:6] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 1 damage to ALL other characters.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1019
			// --------------------------------------------------------
			cards.Add("VAN_CS2_064", new CardDef(new Power
			{
				// TODO [VAN_CS2_064] Dread Infernal && Test: Dread Infernal_VAN_CS2_064
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_315] Summoning Portal - COST:4 [ATK:0/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Your minions cost (2) less, but not less than (1).
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 969
			// --------------------------------------------------------
			cards.Add("VAN_EX1_315", new CardDef(new Power
			{
				// TODO [VAN_EX1_315] Summoning Portal && Test: Summoning Portal_VAN_EX1_315
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_313] Pit Lord - COST:4 [ATK:5/HP:6] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 5 damage to your hero.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 783
			// --------------------------------------------------------
			cards.Add("VAN_EX1_313", new CardDef(new Power
			{
				// TODO [VAN_EX1_313] Pit Lord && Test: Pit Lord_VAN_EX1_313
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_304] Void Terror - COST:3 [ATK:3/HP:3] 
			// - Race: demon, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: [x]<b>Battlecry:</b> Destroy both
			//       adjacent minions and gain
			//        their Attack and Health.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1221
			// - 1576 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_304", new CardDef(new Power
			{
				// TODO [VAN_EX1_304] Void Terror && Test: Void Terror_VAN_EX1_304
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_306] Felstalker - COST:2 [ATK:4/HP:3] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Discard a random card.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 592
			// - DISCARD_CARDS = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_306", new CardDef(new Power
			{
				// TODO [VAN_EX1_306] Felstalker && Test: Felstalker_VAN_EX1_306
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_323] Lord Jaraxxus - COST:9 [ATK:3/HP:15] 
			// - Race: demon, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy your hero and replace it with Lord Jaraxxus.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - HERO_POWER = 1178
			// - 858 = 777
			// --------------------------------------------------------
			cards.Add("VAN_EX1_323", new CardDef(new Power
			{
				// TODO [VAN_EX1_323] Lord Jaraxxus && Test: Lord Jaraxxus_VAN_EX1_323
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARLOCK
			// [VAN_EX1_310] Doomguard - COST:5 [ATK:5/HP:7] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Charge</b>. <b>Battlecry:</b> Discard two random cards.
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - BATTLECRY = 1
			// - 858 = 631
			// - DISCARD_CARDS = 2
			// --------------------------------------------------------
			cards.Add("VAN_EX1_310", new CardDef(new Power
			{
				// TODO [VAN_EX1_310] Doomguard && Test: Doomguard_VAN_EX1_310
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_303] Shadowflame - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Destroy a friendly minion and deal its Attack damage to all enemy minions. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - AFFECTED_BY_SPELL_POWER = 1
			// - 858 = 147
			// --------------------------------------------------------
			cards.Add("VAN_EX1_303", new CardDef(new Power
			{
				// TODO [VAN_EX1_303] Shadowflame && Test: Shadowflame_VAN_EX1_303
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_CS2_061] Drain Life - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $2 damage. Restore #2 Health to your hero. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 919
			// --------------------------------------------------------
			cards.Add("VAN_CS2_061", new CardDef(new Power
			{
				// TODO [VAN_CS2_061] Drain Life && Test: Drain Life_VAN_CS2_061
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_317] Sense Demons - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Draw 2 Demons
			//       from your deck.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 860
			// --------------------------------------------------------
			cards.Add("VAN_EX1_317", new CardDef(new Power
			{
				// TODO [VAN_EX1_317] Sense Demons && Test: Sense Demons_VAN_EX1_317
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_316] Power Overwhelming - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Give a friendly minion +4/+4 until end of turn. Then, it dies. Horribly.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 846
			// --------------------------------------------------------
			cards.Add("VAN_EX1_316", new CardDef(new Power
			{
				// TODO [VAN_EX1_316] Power Overwhelming && Test: Power Overwhelming_VAN_EX1_316
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_CS2_063] Corruption - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Choose an enemy minion. At the start of your turn, destroy it.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 982
			// --------------------------------------------------------
			cards.Add("VAN_CS2_063", new CardDef(new Power
			{
				// TODO [VAN_CS2_063] Corruption && Test: Corruption_VAN_CS2_063
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_CS2_062] Hellfire - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $3 damage to ALL_characters. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 950
			// --------------------------------------------------------
			cards.Add("VAN_CS2_062", new CardDef(new Power
			{
				// TODO [VAN_CS2_062] Hellfire && Test: Hellfire_VAN_CS2_062
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_302] Mortal Coil - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $1 damage to a minion. If that kills it, draw a card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1092
			// --------------------------------------------------------
			cards.Add("VAN_EX1_302", new CardDef(new Power
			{
				// TODO [VAN_EX1_302] Mortal Coil && Test: Mortal Coil_VAN_EX1_302
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_309] Siphon Soul - COST:6 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Destroy a minion. Restore #3 Health to_your hero.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1100
			// --------------------------------------------------------
			cards.Add("VAN_EX1_309", new CardDef(new Power
			{
				// TODO [VAN_EX1_309] Siphon Soul && Test: Siphon Soul_VAN_EX1_309
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_312] Twisting Nether - COST:8 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Destroy all minions.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 859
			// --------------------------------------------------------
			cards.Add("VAN_EX1_312", new CardDef(new Power
			{
				// TODO [VAN_EX1_312] Twisting Nether && Test: Twisting Nether_VAN_EX1_312
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_596] Demonfire - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Deal $2 damage to a minion. If it’s a friendly Demon, give it +2/+2 instead. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1142
			// --------------------------------------------------------
			cards.Add("VAN_EX1_596", new CardDef(new Power
			{
				// TODO [VAN_EX1_596] Demonfire && Test: Demonfire_VAN_EX1_596
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_320] Bane of Doom - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Deal $2 damage to_a character. If that kills it, summon a random Demon. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 23
			// --------------------------------------------------------
			cards.Add("VAN_EX1_320", new CardDef(new Power
			{
				// TODO [VAN_EX1_320] Bane of Doom && Test: Bane of Doom_VAN_EX1_320
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_CS2_057] Shadow Bolt - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $4 damage
			//       to a minion. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 914
			// --------------------------------------------------------
			cards.Add("VAN_CS2_057", new CardDef(new Power
			{
				// TODO [VAN_CS2_057] Shadow Bolt && Test: Shadow Bolt_VAN_CS2_057
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_NEW1_003] Sacrificial Pact - COST:0 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Destroy a Demon. Restore #5 Health to your hero.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 163
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_003", new CardDef(new Power
			{
				// TODO [VAN_NEW1_003] Sacrificial Pact && Test: Sacrificial Pact_VAN_NEW1_003
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARLOCK
			// [VAN_EX1_308] Soulfire - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: [x]Deal $4 damage.
			//       Discard a random card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 974
			// - DISCARD_CARDS = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_308", new CardDef(new Power
			{
				// TODO [VAN_EX1_308] Soulfire && Test: Soulfire_VAN_EX1_308
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Warrior(IDictionary<string, CardDef> cards)
		{
			// --------------------------------------- MINION - WARRIOR
			// [VAN_EX1_604] Frothing Berserker - COST:3 [ATK:2/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever a minion takes damage, gain +1 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 654
			// --------------------------------------------------------
			cards.Add("VAN_EX1_604", new CardDef(new Power
			{
				// TODO [VAN_EX1_604] Frothing Berserker && Test: Frothing Berserker_VAN_EX1_604
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARRIOR
			// [VAN_NEW1_011] Kor'kron Elite - COST:4 [ATK:4/HP:3] 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - 858 = 28
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_011", new CardDef(new Power
			{
				// TODO [VAN_NEW1_011] Kor'kron Elite && Test: Kor'kron Elite_VAN_NEW1_011
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARRIOR
			// [VAN_EX1_398] Arathi Weaponsmith - COST:4 [ATK:3/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Equip a 2/2_weapon.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 538
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1707
			// --------------------------------------------------------
			cards.Add("VAN_EX1_398", new CardDef(new Power
			{
				// TODO [VAN_EX1_398] Arathi Weaponsmith && Test: Arathi Weaponsmith_VAN_EX1_398
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARRIOR
			// [VAN_EX1_603] Cruel Taskmaster - COST:2 [ATK:2/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 1 damage to a minion and give it +2_Attack.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 285
			// --------------------------------------------------------
			cards.Add("VAN_EX1_603", new CardDef(new Power
			{
				// TODO [VAN_EX1_603] Cruel Taskmaster && Test: Cruel Taskmaster_VAN_EX1_603
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARRIOR
			// [VAN_EX1_084] Warsong Commander - COST:3 [ATK:2/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Whenever you summon a minion with 3 or less Attack, give it <b>Charge</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1009
			// --------------------------------------------------------
			// RefTag:
			// - CHARGE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_084", new CardDef(new Power
			{
				// TODO [VAN_EX1_084] Warsong Commander && Test: Warsong Commander_VAN_EX1_084
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARRIOR
			// [VAN_EX1_414] Grommash Hellscream - COST:8 [ATK:4/HP:9] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			//       <b>Enrage:</b> +6 Attack
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - CHARGE = 1
			// - 858 = 338
			// --------------------------------------------------------
			// RefTag:
			// - ENRAGED = 1
			// - 1954 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_414", new CardDef(new Power
			{
				// TODO [VAN_EX1_414] Grommash Hellscream && Test: Grommash Hellscream_VAN_EX1_414
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - WARRIOR
			// [VAN_EX1_402] Armorsmith - COST:2 [ATK:1/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever a friendly minion_takes damage, gain 1 Armor.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 596
			// --------------------------------------------------------
			cards.Add("VAN_EX1_402", new CardDef(new Power
			{
				// TODO [VAN_EX1_402] Armorsmith && Test: Armorsmith_VAN_EX1_402
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_408] Mortal Strike - COST:4 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Deal $4 damage. If you have 12 or less Health, deal $6 instead. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 804
			// --------------------------------------------------------
			cards.Add("VAN_EX1_408", new CardDef(new Power
			{
				// TODO [VAN_EX1_408] Mortal Strike && Test: Mortal Strike_VAN_EX1_408
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_392] Battle Rage - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Draw a card for each damaged friendly character.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 400
			// --------------------------------------------------------
			cards.Add("VAN_EX1_392", new CardDef(new Power
			{
				// TODO [VAN_EX1_392] Battle Rage && Test: Battle Rage_VAN_EX1_392
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_607] Inner Rage - COST:0 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Deal $1 damage to a minion and give it +2_Attack. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 22
			// --------------------------------------------------------
			cards.Add("VAN_EX1_607", new CardDef(new Power
			{
				// TODO [VAN_EX1_607] Inner Rage && Test: Inner Rage_VAN_EX1_607
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_CS2_114] Cleave - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: [x]Deal $2 damage to
			//       two random enemy
			//       minions. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 940
			// --------------------------------------------------------
			cards.Add("VAN_CS2_114", new CardDef(new Power
			{
				// TODO [VAN_CS2_114] Cleave && Test: Cleave_VAN_CS2_114
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_409] Upgrade! - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: If you have a weapon, give it +1/+1. Otherwise equip a 1/3 weapon.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 511
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1661
			// --------------------------------------------------------
			cards.Add("VAN_EX1_409", new CardDef(new Power
			{
				// TODO [VAN_EX1_409] Upgrade! && Test: Upgrade!_VAN_EX1_409
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_391] Slam - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Deal $2 damage to a minion. If it survives, draw a card. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1074
			// --------------------------------------------------------
			cards.Add("VAN_EX1_391", new CardDef(new Power
			{
				// TODO [VAN_EX1_391] Slam && Test: Slam_VAN_EX1_391
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_CS2_104] Rampage - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Give a damaged minion +3/+3.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1108
			// --------------------------------------------------------
			cards.Add("VAN_CS2_104", new CardDef(new Power
			{
				// TODO [VAN_CS2_104] Rampage && Test: Rampage_VAN_CS2_104
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_CS2_103] Charge - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give a friendly minion +2 Attack and <b>Charge</b>.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 344
			// --------------------------------------------------------
			// RefTag:
			// - CHARGE = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_103", new CardDef(new Power
			{
				// TODO [VAN_CS2_103] Charge && Test: Charge_VAN_CS2_103
				InfoCardId = "VAN_CS2_103e2",
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_CS2_108] Execute - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Destroy a damaged enemy minion.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 785
			// --------------------------------------------------------
			cards.Add("VAN_CS2_108", new CardDef(new Power
			{
				// TODO [VAN_CS2_108] Execute && Test: Execute_VAN_CS2_108
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_NEW1_036] Commanding Shout - COST:2 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Your minions can't be reduced below 1 Health this turn. Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1026
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_036", new CardDef(new Power
			{
				// TODO [VAN_NEW1_036] Commanding Shout && Test: Commanding Shout_VAN_NEW1_036
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_CS2_105] Heroic Strike - COST:2 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Give your hero +4_Attack this turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1007
			// --------------------------------------------------------
			cards.Add("VAN_CS2_105", new CardDef(new Power
			{
				// TODO [VAN_CS2_105] Heroic Strike && Test: Heroic Strike_VAN_CS2_105
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_400] Whirlwind - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Deal $1 damage to ALL_minions. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 636
			// --------------------------------------------------------
			cards.Add("VAN_EX1_400", new CardDef(new Power
			{
				// TODO [VAN_EX1_400] Whirlwind && Test: Whirlwind_VAN_EX1_400
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_606] Shield Block - COST:3 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Gain 5 Armor.
			//       Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1023
			// --------------------------------------------------------
			cards.Add("VAN_EX1_606", new CardDef(new Power
			{
				// TODO [VAN_EX1_606] Shield Block && Test: Shield Block_VAN_EX1_606
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_410] Shield Slam - COST:1 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Deal 1 damage to a minion for each Armor you have. @spelldmg
			// --------------------------------------------------------
			// GameTag:
			// - AFFECTED_BY_SPELL_POWER = 1
			// - 858 = 546
			// --------------------------------------------------------
			cards.Add("VAN_EX1_410", new CardDef(new Power
			{
				// TODO [VAN_EX1_410] Shield Slam && Test: Shield Slam_VAN_EX1_410
				//PowerTask = null,
				//Trigger = null,
			}));

			// ---------------------------------------- SPELL - WARRIOR
			// [VAN_EX1_407] Brawl - COST:5 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Destroy all minions except one. <i>(chosen randomly)</i>
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 75
			// --------------------------------------------------------
			cards.Add("VAN_EX1_407", new CardDef(new Power
			{
				// TODO [VAN_EX1_407] Brawl && Test: Brawl_VAN_EX1_407
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- WEAPON - WARRIOR
			// [VAN_EX1_411] Gorehowl - COST:7 [ATK:7/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Attacking a minion costs 1 Attack instead of 1 Durability.
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 1
			// - 858 = 810
			// --------------------------------------------------------
			cards.Add("VAN_EX1_411", new CardDef(new Power
			{
				// TODO [VAN_EX1_411] Gorehowl && Test: Gorehowl_VAN_EX1_411
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- WEAPON - WARRIOR
			// [VAN_CS2_106] Fiery War Axe - COST:2 [ATK:3/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 2
			// - 858 = 401
			// --------------------------------------------------------
			cards.Add("VAN_CS2_106", new CardDef(new Power
			{
				// TODO [VAN_CS2_106] Fiery War Axe && Test: Fiery War Axe_VAN_CS2_106
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- WEAPON - WARRIOR
			// [VAN_CS2_112] Arcanite Reaper - COST:5 [ATK:5/HP:0] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - DURABILITY = 2
			// - 858 = 304
			// --------------------------------------------------------
			cards.Add("VAN_CS2_112", new CardDef(new Power
			{
				// TODO [VAN_CS2_112] Arcanite Reaper && Test: Arcanite Reaper_VAN_CS2_112
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		private static void Neutral(IDictionary<string, CardDef> cards)
		{
			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_048] Spellbreaker - COST:4 [ATK:4/HP:3] 
			// - Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> <b>Silence</b> a_minion.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 754
			// --------------------------------------------------------
			// RefTag:
			// - SILENCE = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_048", new CardDef(new Power
			{
				// TODO [VAN_EX1_048] Spellbreaker && Test: Spellbreaker_VAN_EX1_048
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_044] Questing Adventurer - COST:3 [ATK:2/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever you play a card, gain +1/+1.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 791
			// --------------------------------------------------------
			cards.Add("VAN_EX1_044", new CardDef(new Power
			{
				// TODO [VAN_EX1_044] Questing Adventurer && Test: Questing Adventurer_VAN_EX1_044
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_004] Young Priestess - COST:1 [ATK:2/HP:1] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: At the end of your turn, give another random friendly minion +1 Health.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1634
			// --------------------------------------------------------
			cards.Add("VAN_EX1_004", new CardDef(new Power
			{
				// TODO [VAN_EX1_004] Young Priestess && Test: Young Priestess_VAN_EX1_004
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_067] Argent Commander - COST:6 [ATK:4/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			//       <b>Divine Shield</b>
			// --------------------------------------------------------
			// GameTag:
			// - DIVINE_SHIELD = 1
			// - CHARGE = 1
			// - 858 = 281
			// --------------------------------------------------------
			cards.Add("VAN_EX1_067", new CardDef(new Power
			{
				// TODO [VAN_EX1_067] Argent Commander && Test: Argent Commander_VAN_EX1_067
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_168] Murloc Raider - COST:1 [ATK:2/HP:1] 
			// - Race: murloc, Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 191
			// --------------------------------------------------------
			cards.Add("VAN_CS2_168", new CardDef(new Power
			{
				// TODO [VAN_CS2_168] Murloc Raider && Test: Murloc Raider_VAN_CS2_168
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_018] Bloodsail Raider - COST:2 [ATK:2/HP:3] 
			// - Race: pirate, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Gain Attack equal to the Attack
			//       of your weapon.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 999
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_018", new CardDef(new Power
			{
				// TODO [VAN_NEW1_018] Bloodsail Raider && Test: Bloodsail Raider_VAN_NEW1_018
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_399] Gurubashi Berserker - COST:5 [ATK:2/HP:7] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Whenever this minion takes damage, gain +3_Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 768
			// --------------------------------------------------------
			cards.Add("VAN_EX1_399", new CardDef(new Power
			{
				// TODO [VAN_EX1_399] Gurubashi Berserker && Test: Gurubashi Berserker_VAN_EX1_399
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_506] Murloc Tidehunter - COST:2 [ATK:2/HP:1] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Summon a 1/1_Murloc Scout.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 976
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 68469
			// --------------------------------------------------------
			cards.Add("VAN_EX1_506", new CardDef(new Power
			{
				// TODO [VAN_EX1_506] Murloc Tidehunter && Test: Murloc Tidehunter_VAN_EX1_506
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_021] Thrallmar Farseer - COST:3 [ATK:2/HP:3] 
			// - Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Windfury</b>
			// --------------------------------------------------------
			// GameTag:
			// - WINDFURY = 1
			// - 858 = 765
			// --------------------------------------------------------
			cards.Add("VAN_EX1_021", new CardDef(new Power
			{
				// TODO [VAN_EX1_021] Thrallmar Farseer && Test: Thrallmar Farseer_VAN_EX1_021
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_121] Frostwolf Grunt - COST:2 [ATK:2/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 41
			// --------------------------------------------------------
			cards.Add("VAN_CS2_121", new CardDef(new Power
			{
				// TODO [VAN_CS2_121] Frostwolf Grunt && Test: Frostwolf Grunt_VAN_CS2_121
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_150] Stormpike Commando - COST:5 [ATK:4/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 2 damage.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 413
			// --------------------------------------------------------
			cards.Add("VAN_CS2_150", new CardDef(new Power
			{
				// TODO [VAN_CS2_150] Stormpike Commando && Test: Stormpike Commando_VAN_CS2_150
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_030] Deathwing - COST:10 [ATK:12/HP:12] 
			// - Race: dragon, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy all other minions and discard your_hand.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 834
			// - DISCARD_CARDS = 10
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_030", new CardDef(new Power
			{
				// TODO [VAN_NEW1_030] Deathwing && Test: Deathwing_VAN_NEW1_030
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_298] Ragnaros the Firelord - COST:8 [ATK:8/HP:8] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: Can't attack. At the end of your turn, deal 8 damage to a random enemy.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - CANT_ATTACK = 1
			// - 858 = 374
			// - 1932 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_298", new CardDef(new Power
			{
				// TODO [VAN_EX1_298] Ragnaros the Firelord && Test: Ragnaros the Firelord_VAN_EX1_298
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_172] Bloodfen Raptor - COST:2 [ATK:3/HP:2] 
			// - Race: beast, Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 216
			// --------------------------------------------------------
			cards.Add("VAN_CS2_172", new CardDef(new Power
			{
				// TODO [VAN_CS2_172] Bloodfen Raptor && Test: Bloodfen Raptor_VAN_CS2_172
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_046] Dark Iron Dwarf - COST:4 [ATK:4/HP:4] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a minion +2_Attack this turn.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 348
			// --------------------------------------------------------
			cards.Add("VAN_EX1_046", new CardDef(new Power
			{
				// TODO [VAN_EX1_046] Dark Iron Dwarf && Test: Dark Iron Dwarf_VAN_EX1_046
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_201] Core Hound - COST:7 [ATK:9/HP:5] 
			// - Race: beast, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1687
			// --------------------------------------------------------
			cards.Add("VAN_CS2_201", new CardDef(new Power
			{
				// TODO [VAN_CS2_201] Core Hound && Test: Core Hound_VAN_CS2_201
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_007] Acolyte of Pain - COST:3 [ATK:1/HP:3] 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Whenever this minion takes damage, draw a_card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1659
			// --------------------------------------------------------
			cards.Add("VAN_EX1_007", new CardDef(new Power
			{
				// TODO [VAN_EX1_007] Acolyte of Pain && Test: Acolyte of Pain_VAN_EX1_007
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_147] Gnomish Inventor - COST:4 [ATK:2/HP:4] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 308
			// --------------------------------------------------------
			cards.Add("VAN_CS2_147", new CardDef(new Power
			{
				// TODO [VAN_CS2_147] Gnomish Inventor && Test: Gnomish Inventor_VAN_CS2_147
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_189] Elven Archer - COST:1 [ATK:1/HP:1] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 1 damage.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 389
			// --------------------------------------------------------
			cards.Add("VAN_CS2_189", new CardDef(new Power
			{
				// TODO [VAN_CS2_189] Elven Archer && Test: Elven Archer_VAN_CS2_189
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_125] Ironfur Grizzly - COST:3 [ATK:3/HP:3] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 1182
			// --------------------------------------------------------
			cards.Add("VAN_CS2_125", new CardDef(new Power
			{
				// TODO [VAN_CS2_125] Ironfur Grizzly && Test: Ironfur Grizzly_VAN_CS2_125
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_118] Magma Rager - COST:3 [ATK:5/HP:1] 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1653
			// --------------------------------------------------------
			cards.Add("VAN_CS2_118", new CardDef(new Power
			{
				// TODO [VAN_CS2_118] Magma Rager && Test: Magma Rager_VAN_CS2_118
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_PRO_001] Elite Tauren Chieftain - COST:5 [ATK:5/HP:5] 
			// - Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give both players the power to ROCK! (with a Power Chord card)
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 1754
			// --------------------------------------------------------
			cards.Add("VAN_PRO_001", new CardDef(new Power
			{
				// TODO [VAN_PRO_001] Elite Tauren Chieftain && Test: Elite Tauren Chieftain_VAN_PRO_001
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_076] Pint-Sized Summoner - COST:2 [ATK:2/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: The first minion you play each turn costs (1) less.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 37
			// --------------------------------------------------------
			cards.Add("VAN_EX1_076", new CardDef(new Power
			{
				// TODO [VAN_EX1_076] Pint-Sized Summoner && Test: Pint-Sized Summoner_VAN_EX1_076
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_412] Raging Worgen - COST:3 [ATK:3/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Enrage:</b> <b>Windfury</b> and +1 Attack
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1155
			// --------------------------------------------------------
			// RefTag:
			// - WINDFURY = 1
			// - ENRAGED = 1
			// - 1954 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_412", new CardDef(new Power
			{
				// TODO [VAN_EX1_412] Raging Worgen && Test: Raging Worgen_VAN_EX1_412
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_222] Stormwind Champion - COST:7 [ATK:6/HP:6] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Your other minions have +1/+1.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 753
			// --------------------------------------------------------
			cards.Add("VAN_CS2_222", new CardDef(new Power
			{
				// TODO [VAN_CS2_222] Stormwind Champion && Test: Stormwind Champion_VAN_CS2_222
				InfoCardId = "VAN_CS2_222o",
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_023] Faerie Dragon - COST:2 [ATK:3/HP:2] 
			// - Race: dragon, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Elusive</b>
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 609
			// - 1211 = 1
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_023", new CardDef(new Power
			{
				// TODO [VAN_NEW1_023] Faerie Dragon && Test: Faerie Dragon_VAN_NEW1_023
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_021] Doomsayer - COST:2 [ATK:0/HP:7] 
			// - Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: At the start of your turn, destroy ALL minions.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 138
			// - 886 = 1
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_021", new CardDef(new Power
			{
				// TODO [VAN_NEW1_021] Doomsayer && Test: Doomsayer_VAN_NEW1_021
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_010] Worgen Infiltrator - COST:1 [ATK:2/HP:1] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Stealth</b>
			// --------------------------------------------------------
			// GameTag:
			// - STEALTH = 1
			// - 858 = 994
			// --------------------------------------------------------
			cards.Add("VAN_EX1_010", new CardDef(new Power
			{
				// TODO [VAN_EX1_010] Worgen Infiltrator && Test: Worgen Infiltrator_VAN_EX1_010
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_062] Old Murk-Eye - COST:4 [ATK:2/HP:4] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Charge</b>. Has +1 Attack for each other Murloc on the battlefield.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - CHARGE = 1
			// - 858 = 736
			// --------------------------------------------------------
			cards.Add("VAN_EX1_062", new CardDef(new Power
			{
				// TODO [VAN_EX1_062] Old Murk-Eye && Test: Old Murk-Eye_VAN_EX1_062
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS1_042] Goldshire Footman - COST:1 [ATK:1/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 922
			// --------------------------------------------------------
			cards.Add("VAN_CS1_042", new CardDef(new Power
			{
				// TODO [VAN_CS1_042] Goldshire Footman && Test: Goldshire Footman_VAN_CS1_042
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_083] Tinkmaster Overspark - COST:3 [ATK:3/HP:3] 
			// - Fac: alliance, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: [x]<b>Battlecry:</b> Transform
			//       another random minion
			//       into a 5/5 Devilsaur
			//        or a 1/1 Squirrel.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 570
			// --------------------------------------------------------
			cards.Add("VAN_EX1_083", new CardDef(new Power
			{
				// TODO [VAN_EX1_083] Tinkmaster Overspark && Test: Tinkmaster Overspark_VAN_EX1_083
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_188] Abusive Sergeant - COST:1 [ATK:2/HP:1] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a minion +2_Attack this turn.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 242
			// --------------------------------------------------------
			cards.Add("VAN_CS2_188", new CardDef(new Power
			{
				// TODO [VAN_CS2_188] Abusive Sergeant && Test: Abusive Sergeant_VAN_CS2_188
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_015] Novice Engineer - COST:2 [ATK:1/HP:1] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 284
			// --------------------------------------------------------
			cards.Add("VAN_EX1_015", new CardDef(new Power
			{
				// TODO [VAN_EX1_015] Novice Engineer && Test: Novice Engineer_VAN_EX1_015
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_577] The Beast - COST:6 [ATK:9/HP:7] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: [x]<b>Deathrattle:</b> Summon a
			//       3/3 Pip Quickwit for
			//       your opponent.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - DEATHRATTLE = 1
			// - 858 = 962
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1006
			// - 1594 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_577", new CardDef(new Power
			{
				// TODO [VAN_EX1_577] The Beast && Test: The Beast_VAN_EX1_577
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_396] Mogu'shan Warden - COST:4 [ATK:1/HP:7] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 700
			// --------------------------------------------------------
			cards.Add("VAN_EX1_396", new CardDef(new Power
			{
				// TODO [VAN_EX1_396] Mogu'shan Warden && Test: Mogu'shan Warden_VAN_EX1_396
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_096] Loot Hoarder - COST:2 [ATK:2/HP:1] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Deathrattle:</b> Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - DEATHRATTLE = 1
			// - 858 = 251
			// --------------------------------------------------------
			cards.Add("VAN_EX1_096", new CardDef(new Power
			{
				// TODO [VAN_EX1_096] Loot Hoarder && Test: Loot Hoarder_VAN_EX1_096
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_572] Ysera - COST:9 [ATK:4/HP:12] 
			// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: At the end of your turn, add_a Dream Card to_your hand.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 1186
			// --------------------------------------------------------
			cards.Add("VAN_EX1_572", new CardDef(new Power
			{
				// TODO [VAN_EX1_572] Ysera && Test: Ysera_VAN_EX1_572
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_170] Emperor Cobra - COST:3 [ATK:2/HP:3] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Destroy any minion damaged by this minion.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1098
			// - 1944 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_170", new CardDef(new Power
			{
				// TODO [VAN_EX1_170] Emperor Cobra && Test: Emperor Cobra_VAN_EX1_170
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_173] Bluegill Warrior - COST:2 [ATK:2/HP:1] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - 858 = 739
			// --------------------------------------------------------
			cards.Add("VAN_CS2_173", new CardDef(new Power
			{
				// TODO [VAN_CS2_173] Bluegill Warrior && Test: Bluegill Warrior_VAN_CS2_173
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_151] Silver Hand Knight - COST:5 [ATK:4/HP:4] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Summon a 2/2_Squire.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 69
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 482
			// --------------------------------------------------------
			cards.Add("VAN_CS2_151", new CardDef(new Power
			{
				// TODO [VAN_CS2_151] Silver Hand Knight && Test: Silver Hand Knight_VAN_CS2_151
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_043] Twilight Drake - COST:4 [ATK:4/HP:1] 
			// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Gain +1 Health for each card in your hand.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1037
			// --------------------------------------------------------
			cards.Add("VAN_EX1_043", new CardDef(new Power
			{
				// TODO [VAN_EX1_043] Twilight Drake && Test: Twilight Drake_VAN_EX1_043
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_562] Onyxia - COST:9 [ATK:8/HP:8] 
			// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Summon 1/1 Whelps until your side of the battlefield is full.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 363
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 54
			// --------------------------------------------------------
			cards.Add("VAN_EX1_562", new CardDef(new Power
			{
				// TODO [VAN_EX1_562] Onyxia && Test: Onyxia_VAN_EX1_562
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_024] Captain Greenskin - COST:5 [ATK:5/HP:4] 
			// - Race: pirate, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give your weapon +1/+1.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 456
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_024", new CardDef(new Power
			{
				// TODO [VAN_NEW1_024] Captain Greenskin && Test: Captain Greenskin_VAN_NEW1_024
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_171] Stonetusk Boar - COST:1 [ATK:1/HP:1] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - 858 = 648
			// --------------------------------------------------------
			cards.Add("VAN_CS2_171", new CardDef(new Power
			{
				// TODO [VAN_CS2_171] Stonetusk Boar && Test: Stonetusk Boar_VAN_CS2_171
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_227] Venture Co. Mercenary - COST:5 [ATK:7/HP:6] 
			// - Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Your minions cost (3) more.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 1122
			// --------------------------------------------------------
			cards.Add("VAN_CS2_227", new CardDef(new Power
			{
				// TODO [VAN_CS2_227] Venture Co. Mercenary && Test: Venture Co. Mercenary_VAN_CS2_227
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_027] Southsea Captain - COST:3 [ATK:3/HP:3] 
			// - Race: pirate, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Your other Pirates have +1/+1.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 680
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_027", new CardDef(new Power
			{
				// TODO [VAN_NEW1_027] Southsea Captain && Test: Southsea Captain_VAN_NEW1_027
				InfoCardId = "VAN_NEW1_027e",
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_017] Hungry Crab - COST:1 [ATK:1/HP:2] 
			// - Race: beast, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy a Murloc and gain +2/+2.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 443
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_017", new CardDef(new Power
			{
				// TODO [VAN_NEW1_017] Hungry Crab && Test: Hungry Crab_VAN_NEW1_017
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_012] Bloodmage Thalnos - COST:2 [ATK:1/HP:1] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Spell Damage +1</b>
			//       <b>Deathrattle:</b> Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - SPELLPOWER = 1
			// - DEATHRATTLE = 1
			// - 858 = 749
			// --------------------------------------------------------
			cards.Add("VAN_EX1_012", new CardDef(new Power
			{
				// TODO [VAN_EX1_012] Bloodmage Thalnos && Test: Bloodmage Thalnos_VAN_EX1_012
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_105] Mountain Giant - COST:12 [ATK:8/HP:8] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Costs (1) less for each other card in your hand.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 993
			// --------------------------------------------------------
			cards.Add("VAN_EX1_105", new CardDef(new Power
			{
				// TODO [VAN_EX1_105] Mountain Giant && Test: Mountain Giant_VAN_EX1_105
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_586] Sea Giant - COST:10 [ATK:8/HP:8] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Costs (1) less for each other minion on the battlefield.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 211
			// --------------------------------------------------------
			cards.Add("VAN_EX1_586", new CardDef(new Power
			{
				// TODO [VAN_EX1_586] Sea Giant && Test: Sea Giant_VAN_EX1_586
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_016] Captain's Parrot - COST:2 [ATK:1/HP:1] 
			// - Race: beast, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Draw a Pirate from your deck.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 530
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_016", new CardDef(new Power
			{
				// TODO [VAN_NEW1_016] Captain's Parrot && Test: Captain's Parrot_VAN_NEW1_016
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_049] Youthful Brewmaster - COST:2 [ATK:3/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Return a friendly minion from the battlefield to your hand.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 415
			// --------------------------------------------------------
			cards.Add("VAN_EX1_049", new CardDef(new Power
			{
				// TODO [VAN_EX1_049] Youthful Brewmaster && Test: Youthful Brewmaster_VAN_EX1_049
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_509] Murloc Tidecaller - COST:1 [ATK:1/HP:2] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever a Murloc is summoned, gain +1 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 475
			// --------------------------------------------------------
			cards.Add("VAN_EX1_509", new CardDef(new Power
			{
				// TODO [VAN_EX1_509] Murloc Tidecaller && Test: Murloc Tidecaller_VAN_EX1_509
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_001] Lightwarden - COST:1 [ATK:1/HP:2] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever a character is healed, gain +2 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1655
			// --------------------------------------------------------
			cards.Add("VAN_EX1_001", new CardDef(new Power
			{
				// TODO [VAN_EX1_001] Lightwarden && Test: Lightwarden_VAN_EX1_001
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_019] Shattered Sun Cleric - COST:3 [ATK:3/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give a friendly minion +1/+1.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 608
			// --------------------------------------------------------
			cards.Add("VAN_EX1_019", new CardDef(new Power
			{
				// TODO [VAN_EX1_019] Shattered Sun Cleric && Test: Shattered Sun Cleric_VAN_EX1_019
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_119] Oasis Snapjaw - COST:4 [ATK:2/HP:7] 
			// - Race: beast, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1370
			// --------------------------------------------------------
			cards.Add("VAN_CS2_119", new CardDef(new Power
			{
				// TODO [VAN_CS2_119] Oasis Snapjaw && Test: Oasis Snapjaw_VAN_CS2_119
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_023] Silvermoon Guardian - COST:4 [ATK:3/HP:3] 
			// - Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Divine Shield</b>
			// --------------------------------------------------------
			// GameTag:
			// - DIVINE_SHIELD = 1
			// - 858 = 34
			// --------------------------------------------------------
			cards.Add("VAN_EX1_023", new CardDef(new Power
			{
				// TODO [VAN_EX1_023] Silvermoon Guardian && Test: Silvermoon Guardian_VAN_EX1_023
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_127] Silverback Patriarch - COST:3 [ATK:1/HP:4] 
			// - Race: beast, Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 67
			// --------------------------------------------------------
			cards.Add("VAN_CS2_127", new CardDef(new Power
			{
				// TODO [VAN_CS2_127] Silverback Patriarch && Test: Silverback Patriarch_VAN_CS2_127
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_050] Coldlight Oracle - COST:3 [ATK:2/HP:2] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Each player draws 2 cards.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1016
			// --------------------------------------------------------
			cards.Add("VAN_EX1_050", new CardDef(new Power
			{
				// TODO [VAN_EX1_050] Coldlight Oracle && Test: Coldlight Oracle_VAN_EX1_050
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_560] Nozdormu - COST:9 [ATK:8/HP:8] 
			// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: Players only have 15 seconds to take their_turns.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 411
			// --------------------------------------------------------
			cards.Add("VAN_EX1_560", new CardDef(new Power
			{
				// TODO [VAN_EX1_560] Nozdormu && Test: Nozdormu_VAN_EX1_560
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_102] Demolisher - COST:3 [ATK:1/HP:4] 
			// - Race: mechanical, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: At the start of your turn, deal 2 damage to a random enemy.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 979
			// --------------------------------------------------------
			cards.Add("VAN_EX1_102", new CardDef(new Power
			{
				// TODO [VAN_EX1_102] Demolisher && Test: Demolisher_VAN_EX1_102
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_117] Earthen Ring Farseer - COST:3 [ATK:3/HP:3] 
			// - Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Restore #3_Health.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1651
			// --------------------------------------------------------
			cards.Add("VAN_CS2_117", new CardDef(new Power
			{
				// TODO [VAN_CS2_117] Earthen Ring Farseer && Test: Earthen Ring Farseer_VAN_CS2_117
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_155] Archmage - COST:6 [ATK:4/HP:7] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Spell Damage +1</b>
			// --------------------------------------------------------
			// GameTag:
			// - SPELLPOWER = 1
			// - 858 = 525
			// --------------------------------------------------------
			cards.Add("VAN_CS2_155", new CardDef(new Power
			{
				// TODO [VAN_CS2_155] Archmage && Test: Archmage_VAN_CS2_155
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_025] Bloodsail Corsair - COST:1 [ATK:1/HP:2] 
			// - Race: pirate, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: [x]<b>Battlecry:</b> Remove
			//       1 Durability from your
			//       opponent's weapon.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 997
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_025", new CardDef(new Power
			{
				// TODO [VAN_NEW1_025] Bloodsail Corsair && Test: Bloodsail Corsair_VAN_NEW1_025
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_032] Sunwalker - COST:6 [ATK:4/HP:5] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			//       <b>Divine Shield</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - DIVINE_SHIELD = 1
			// - 858 = 759
			// --------------------------------------------------------
			cards.Add("VAN_EX1_032", new CardDef(new Power
			{
				// TODO [VAN_EX1_032] Sunwalker && Test: Sunwalker_VAN_EX1_032
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_019] Knife Juggler - COST:2 [ATK:3/HP:2] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: [x]After you summon a
			//       minion, deal 1 damage
			//       to a random enemy.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1073
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_019", new CardDef(new Power
			{
				// TODO [VAN_NEW1_019] Knife Juggler && Test: Knife Juggler_VAN_NEW1_019
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_213] Reckless Rocketeer - COST:6 [ATK:5/HP:2] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - 858 = 445
			// --------------------------------------------------------
			cards.Add("VAN_CS2_213", new CardDef(new Power
			{
				// TODO [VAN_CS2_213] Reckless Rocketeer && Test: Reckless Rocketeer_VAN_CS2_213
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_058] Sunfury Protector - COST:2 [ATK:2/HP:3] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give adjacent minions <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 891
			// - 1576 = 1
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_058", new CardDef(new Power
			{
				// TODO [VAN_EX1_058] Sunfury Protector && Test: Sunfury Protector_VAN_EX1_058
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_597] Imp Master - COST:3 [ATK:1/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: [x]At the end of your turn, deal
			//       1 damage to this minion
			//        and summon a 1/1 Imp.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 926
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 76
			// --------------------------------------------------------
			cards.Add("VAN_EX1_597", new CardDef(new Power
			{
				// TODO [VAN_EX1_597] Imp Master && Test: Imp Master_VAN_EX1_597
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_040] Hogger - COST:6 [ATK:4/HP:4] 
			// - Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: At the end of your turn, summon a 2/2 Gnoll with_<b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 640
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 460
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_040", new CardDef(new Power
			{
				// TODO [VAN_NEW1_040] Hogger && Test: Hogger_VAN_NEW1_040
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_029] Leper Gnome - COST:1 [ATK:2/HP:1] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Deathrattle:</b> Deal 2 damage to the enemy_hero.
			// --------------------------------------------------------
			// GameTag:
			// - DEATHRATTLE = 1
			// - 858 = 658
			// --------------------------------------------------------
			cards.Add("VAN_EX1_029", new CardDef(new Power
			{
				// TODO [VAN_EX1_029] Leper Gnome && Test: Leper Gnome_VAN_EX1_029
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_616] Mana Wraith - COST:2 [ATK:2/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: ALL minions cost (1) more.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 715
			// --------------------------------------------------------
			cards.Add("VAN_EX1_616", new CardDef(new Power
			{
				// TODO [VAN_EX1_616] Mana Wraith && Test: Mana Wraith_VAN_EX1_616
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_161] Ravenholdt Assassin - COST:7 [ATK:7/HP:5] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Stealth</b>
			// --------------------------------------------------------
			// GameTag:
			// - STEALTH = 1
			// - 858 = 134
			// --------------------------------------------------------
			cards.Add("VAN_CS2_161", new CardDef(new Power
			{
				// TODO [VAN_CS2_161] Ravenholdt Assassin && Test: Ravenholdt Assassin_VAN_CS2_161
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_582] Dalaran Mage - COST:3 [ATK:1/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Spell Damage +1</b>
			// --------------------------------------------------------
			// GameTag:
			// - SPELLPOWER = 1
			// - 858 = 175
			// --------------------------------------------------------
			cards.Add("VAN_EX1_582", new CardDef(new Power
			{
				// TODO [VAN_EX1_582] Dalaran Mage && Test: Dalaran Mage_VAN_EX1_582
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_045] Ancient Watcher - COST:2 [ATK:4/HP:5] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Can't attack.
			// --------------------------------------------------------
			// GameTag:
			// - CANT_ATTACK = 1
			// - 858 = 605
			// --------------------------------------------------------
			cards.Add("VAN_EX1_045", new CardDef(new Power
			{
				// TODO [VAN_EX1_045] Ancient Watcher && Test: Ancient Watcher_VAN_EX1_045
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_558] Harrison Jones - COST:5 [ATK:5/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy your opponent's weapon and draw cards equal to its Durability.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 912
			// --------------------------------------------------------
			cards.Add("VAN_EX1_558", new CardDef(new Power
			{
				// TODO [VAN_EX1_558] Harrison Jones && Test: Harrison Jones_VAN_EX1_558
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_508] Grimscale Oracle - COST:1 [ATK:1/HP:1] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: ALL other Murlocs have +1 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 510
			// --------------------------------------------------------
			cards.Add("VAN_EX1_508", new CardDef(new Power
			{
				// TODO [VAN_EX1_508] Grimscale Oracle && Test: Grimscale Oracle_VAN_EX1_508
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_014] King Mukla - COST:3 [ATK:5/HP:5] 
			// - Race: beast, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give your opponent 2 Bananas.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 1693
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1694
			// --------------------------------------------------------
			cards.Add("VAN_EX1_014", new CardDef(new Power
			{
				// TODO [VAN_EX1_014] King Mukla && Test: King Mukla_VAN_EX1_014
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_037] Master Swordsmith - COST:2 [ATK:1/HP:3] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: At the end of your turn, give another random friendly minion +1 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 351
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_037", new CardDef(new Power
			{
				// TODO [VAN_NEW1_037] Master Swordsmith && Test: Master Swordsmith_VAN_NEW1_037
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_112] Gelbin Mekkatorque - COST:6 [ATK:6/HP:6] 
			// - Fac: alliance, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Summon an AWESOME invention.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 858
			// --------------------------------------------------------
			cards.Add("VAN_EX1_112", new CardDef(new Power
			{
				// TODO [VAN_EX1_112] Gelbin Mekkatorque && Test: Gelbin Mekkatorque_VAN_EX1_112
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_022] Dread Corsair - COST:4 [ATK:3/HP:3] 
			// - Race: pirate, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			//       Costs (1) less per Attack of_your weapon.
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 878
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_022", new CardDef(new Power
			{
				// TODO [VAN_NEW1_022] Dread Corsair && Test: Dread Corsair_VAN_NEW1_022
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_181] Injured Blademaster - COST:3 [ATK:4/HP:7] 
			// - Fac: horde, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 4 damage to HIMSELF.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1109
			// --------------------------------------------------------
			cards.Add("VAN_CS2_181", new CardDef(new Power
			{
				// TODO [VAN_CS2_181] Injured Blademaster && Test: Injured Blademaster_VAN_CS2_181
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_141] Ironforge Rifleman - COST:3 [ATK:2/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 1 damage.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 339
			// --------------------------------------------------------
			cards.Add("VAN_CS2_141", new CardDef(new Power
			{
				// TODO [VAN_CS2_141] Ironforge Rifleman && Test: Ironforge Rifleman_VAN_CS2_141
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_182] Chillwind Yeti - COST:4 [ATK:4/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 90
			// --------------------------------------------------------
			cards.Add("VAN_CS2_182", new CardDef(new Power
			{
				// TODO [VAN_CS2_182] Chillwind Yeti && Test: Chillwind Yeti_VAN_CS2_182
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_097] Abomination - COST:5 [ATK:4/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Taunt</b>. <b>Deathrattle:</b> Deal 2
			//       damage to ALL characters.
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - DEATHRATTLE = 1
			// - 858 = 440
			// --------------------------------------------------------
			cards.Add("VAN_EX1_097", new CardDef(new Power
			{
				// TODO [VAN_EX1_097] Abomination && Test: Abomination_VAN_EX1_097
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_556] Harvest Golem - COST:3 [ATK:2/HP:3] 
			// - Race: mechanical, Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Deathrattle:</b> Summon a 2/1 Damaged Golem.
			// --------------------------------------------------------
			// GameTag:
			// - DEATHRATTLE = 1
			// - 858 = 778
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 471
			// --------------------------------------------------------
			cards.Add("VAN_EX1_556", new CardDef(new Power
			{
				// TODO [VAN_EX1_556] Harvest Golem && Test: Harvest Golem_VAN_EX1_556
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_028] Stranglethorn Tiger - COST:5 [ATK:5/HP:5] 
			// - Race: beast, Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Stealth</b>
			// --------------------------------------------------------
			// GameTag:
			// - STEALTH = 1
			// - 858 = 68
			// - 1584 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_028", new CardDef(new Power
			{
				// TODO [VAN_EX1_028] Stranglethorn Tiger && Test: Stranglethorn Tiger_VAN_EX1_028
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_563] Malygos - COST:9 [ATK:4/HP:12] 
			// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Spell Damage +5</b>
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - SPELLPOWER = 5
			// - 858 = 436
			// --------------------------------------------------------
			cards.Add("VAN_EX1_563", new CardDef(new Power
			{
				// TODO [VAN_EX1_563] Malygos && Test: Malygos_VAN_EX1_563
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_020] Scarlet Crusader - COST:3 [ATK:3/HP:1] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Divine Shield</b>
			// --------------------------------------------------------
			// GameTag:
			// - DIVINE_SHIELD = 1
			// - 858 = 642
			// --------------------------------------------------------
			cards.Add("VAN_EX1_020", new CardDef(new Power
			{
				// TODO [VAN_EX1_020] Scarlet Crusader && Test: Scarlet Crusader_VAN_EX1_020
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_020] Wild Pyromancer - COST:2 [ATK:3/HP:2] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: After you cast a spell, deal 1 damage to ALL minions.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1014
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_020", new CardDef(new Power
			{
				// TODO [VAN_NEW1_020] Wild Pyromancer && Test: Wild Pyromancer_VAN_NEW1_020
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_059] Crazed Alchemist - COST:2 [ATK:2/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Swap the Attack and Health of a minion.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 801
			// --------------------------------------------------------
			cards.Add("VAN_EX1_059", new CardDef(new Power
			{
				// TODO [VAN_EX1_059] Crazed Alchemist && Test: Crazed Alchemist_VAN_EX1_059
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_393] Amani Berserker - COST:2 [ATK:2/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Enrage:</b> +3 Attack
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 790
			// --------------------------------------------------------
			// RefTag:
			// - ENRAGED = 1
			// - 1954 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_393", new CardDef(new Power
			{
				// TODO [VAN_EX1_393] Amani Berserker && Test: Amani Berserker_VAN_EX1_393
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_614] Illidan Stormrage - COST:6 [ATK:7/HP:5] 
			// - Race: demon, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: Whenever you play a card, summon a 2/1 Flame of Azzinoth.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 556
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 70500
			// --------------------------------------------------------
			cards.Add("VAN_EX1_614", new CardDef(new Power
			{
				// TODO [VAN_EX1_614] Illidan Stormrage && Test: Illidan Stormrage_VAN_EX1_614
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_200] Boulderfist Ogre - COST:6 [ATK:6/HP:7] 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1686
			// --------------------------------------------------------
			cards.Add("VAN_CS2_200", new CardDef(new Power
			{
				// TODO [VAN_CS2_200] Boulderfist Ogre && Test: Boulderfist Ogre_VAN_CS2_200
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_006] Alarm-o-Bot - COST:3 [ATK:0/HP:3] 
			// - Race: mechanical, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: [x]At the start of your turn,
			//       swap this minion with a
			//          random one in your hand.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1658
			// --------------------------------------------------------
			cards.Add("VAN_EX1_006", new CardDef(new Power
			{
				// TODO [VAN_EX1_006] Alarm-o-Bot && Test: Alarm-o-Bot_VAN_EX1_006
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_057] Ancient Brewmaster - COST:4 [ATK:5/HP:4] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Return a friendly minion from the battlefield to your hand.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 186
			// --------------------------------------------------------
			cards.Add("VAN_EX1_057", new CardDef(new Power
			{
				// TODO [VAN_EX1_057] Ancient Brewmaster && Test: Ancient Brewmaster_VAN_EX1_057
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_tt_004] Flesheating Ghoul - COST:3 [ATK:2/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Whenever a minion dies, gain +1 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 397
			// --------------------------------------------------------
			cards.Add("VAN_tt_004", new CardDef(new Power
			{
				// TODO [VAN_tt_004] Flesheating Ghoul && Test: Flesheating Ghoul_VAN_tt_004
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_089] Arcane Golem - COST:3 [ATK:4/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Charge</b>. <b>Battlecry:</b> Give your opponent a Mana Crystal.
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - BATTLECRY = 1
			// - 858 = 466
			// --------------------------------------------------------
			cards.Add("VAN_EX1_089", new CardDef(new Power
			{
				// TODO [VAN_EX1_089] Arcane Golem && Test: Arcane Golem_VAN_EX1_089
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_249] Baron Geddon - COST:7 [ATK:7/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: At the end of your turn, deal 2 damage to ALL other characters.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 336
			// --------------------------------------------------------
			cards.Add("VAN_EX1_249", new CardDef(new Power
			{
				// TODO [VAN_EX1_249] Baron Geddon && Test: Baron Geddon_VAN_EX1_249
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_146] Southsea Deckhand - COST:1 [ATK:2/HP:1] 
			// - Race: pirate, Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Has <b>Charge</b> while you have a weapon equipped.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 724
			// --------------------------------------------------------
			// RefTag:
			// - CHARGE = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_146", new CardDef(new Power
			{
				// TODO [VAN_CS2_146] Southsea Deckhand && Test: Southsea Deckhand_VAN_CS2_146
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_038] Gruul - COST:8 [ATK:7/HP:7] 
			// - Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: At the end of each turn, gain +1/+1 .
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 526
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_038", new CardDef(new Power
			{
				// TODO [VAN_NEW1_038] Gruul && Test: Gruul_VAN_NEW1_038
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_011] Voodoo Doctor - COST:1 [ATK:2/HP:1] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Restore #2_Health.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 132
			// --------------------------------------------------------
			cards.Add("VAN_EX1_011", new CardDef(new Power
			{
				// TODO [VAN_EX1_011] Voodoo Doctor && Test: Voodoo Doctor_VAN_EX1_011
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_390] Tauren Warrior - COST:3 [ATK:2/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Taunt</b>. <b>Enrage:</b> +3 Attack
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 45
			// --------------------------------------------------------
			// RefTag:
			// - ENRAGED = 1
			// - 1954 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_390", new CardDef(new Power
			{
				// TODO [VAN_EX1_390] Tauren Warrior && Test: Tauren Warrior_VAN_EX1_390
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_080] Secretkeeper - COST:1 [ATK:1/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever a <b>Secret</b> is played, gain +1/+1.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 158
			// --------------------------------------------------------
			// RefTag:
			// - SECRET = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_080", new CardDef(new Power
			{
				// TODO [VAN_EX1_080] Secretkeeper && Test: Secretkeeper_VAN_EX1_080
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_284] Azure Drake - COST:5 [ATK:4/HP:4] 
			// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Spell Damage +1</b>
			//       <b>Battlecry:</b> Draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - SPELLPOWER = 1
			// - BATTLECRY = 1
			// - 858 = 825
			// --------------------------------------------------------
			cards.Add("VAN_EX1_284", new CardDef(new Power
			{
				// TODO [VAN_EX1_284] Azure Drake && Test: Azure Drake_VAN_EX1_284
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_283] Frost Elemental - COST:6 [ATK:5/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> <b>Freeze</b> a_character.
			// --------------------------------------------------------
			// GameTag:
			// - FREEZE = 1
			// - BATTLECRY = 1
			// - 858 = 512
			// --------------------------------------------------------
			cards.Add("VAN_EX1_283", new CardDef(new Power
			{
				// TODO [VAN_EX1_283] Frost Elemental && Test: Frost Elemental_VAN_EX1_283
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_595] Cult Master - COST:4 [ATK:4/HP:2] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: After a friendly minion dies, draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 811
			// --------------------------------------------------------
			cards.Add("VAN_EX1_595", new CardDef(new Power
			{
				// TODO [VAN_EX1_595] Cult Master && Test: Cult Master_VAN_EX1_595
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_197] Ogre Magi - COST:4 [ATK:4/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Spell Damage +1</b>
			// --------------------------------------------------------
			// GameTag:
			// - SPELLPOWER = 1
			// - 858 = 995
			// --------------------------------------------------------
			cards.Add("VAN_CS2_197", new CardDef(new Power
			{
				// TODO [VAN_CS2_197] Ogre Magi && Test: Ogre Magi_VAN_CS2_197
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_095] Gadgetzan Auctioneer - COST:5 [ATK:4/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever you cast a spell, draw a card.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 932
			// --------------------------------------------------------
			cards.Add("VAN_EX1_095", new CardDef(new Power
			{
				// TODO [VAN_EX1_095] Gadgetzan Auctioneer && Test: Gadgetzan Auctioneer_VAN_EX1_095
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_221] Spiteful Smith - COST:5 [ATK:4/HP:6] 
			// - Race: undead, Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Enrage:</b> Your weapon has +2 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 61
			// --------------------------------------------------------
			// RefTag:
			// - ENRAGED = 1
			// - 1954 = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_221", new CardDef(new Power
			{
				// TODO [VAN_CS2_221] Spiteful Smith && Test: Spiteful Smith_VAN_CS2_221
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_103] Coldlight Seer - COST:3 [ATK:2/HP:3] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give ALL other Murlocs +2 Health.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 453
			// --------------------------------------------------------
			cards.Add("VAN_EX1_103", new CardDef(new Power
			{
				// TODO [VAN_EX1_103] Coldlight Seer && Test: Coldlight Seer_VAN_EX1_103
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_590] Blood Knight - COST:3 [ATK:3/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> All minions lose <b>Divine Shield</b>. Gain +3/+3 for each Shield lost.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 755
			// --------------------------------------------------------
			// RefTag:
			// - DIVINE_SHIELD = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_590", new CardDef(new Power
			{
				// TODO [VAN_EX1_590] Blood Knight && Test: Blood Knight_VAN_EX1_590
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_009] Angry Chicken - COST:1 [ATK:1/HP:1] 
			// - Race: beast, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Enrage:</b> +5 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1688
			// --------------------------------------------------------
			// RefTag:
			// - ENRAGED = 1
			// - 1954 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_009", new CardDef(new Power
			{
				// TODO [VAN_EX1_009] Angry Chicken && Test: Angry Chicken_VAN_EX1_009
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_124] Wolfrider - COST:3 [ATK:3/HP:1] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - 858 = 289
			// --------------------------------------------------------
			cards.Add("VAN_CS2_124", new CardDef(new Power
			{
				// TODO [VAN_CS2_124] Wolfrider && Test: Wolfrider_VAN_CS2_124
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_066] Acidic Swamp Ooze - COST:2 [ATK:3/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy your opponent's weapon.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 906
			// --------------------------------------------------------
			cards.Add("VAN_EX1_066", new CardDef(new Power
			{
				// TODO [VAN_EX1_066] Acidic Swamp Ooze && Test: Acidic Swamp Ooze_VAN_EX1_066
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_120] River Crocolisk - COST:2 [ATK:2/HP:3] 
			// - Race: beast, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1369
			// --------------------------------------------------------
			cards.Add("VAN_CS2_120", new CardDef(new Power
			{
				// TODO [VAN_CS2_120] River Crocolisk && Test: River Crocolisk_VAN_CS2_120
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_179] Sen'jin Shieldmasta - COST:4 [ATK:3/HP:5] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 635
			// --------------------------------------------------------
			cards.Add("VAN_CS2_179", new CardDef(new Power
			{
				// TODO [VAN_CS2_179] Sen'jin Shieldmasta && Test: Sen'jin Shieldmasta_VAN_CS2_179
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_564] Faceless Manipulator - COST:5 [ATK:3/HP:3] 
			// - Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Choose a minion and become a copy of it.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 531
			// - TECH_LEVEL = 6
			// --------------------------------------------------------
			cards.Add("VAN_EX1_564", new CardDef(new Power
			{
				// TODO [VAN_EX1_564] Faceless Manipulator && Test: Faceless Manipulator_VAN_EX1_564
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_196] Razorfen Hunter - COST:3 [ATK:2/HP:3] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Summon a 1/1_Boar.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 257
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 298
			// --------------------------------------------------------
			cards.Add("VAN_CS2_196", new CardDef(new Power
			{
				// TODO [VAN_CS2_196] Razorfen Hunter && Test: Razorfen Hunter_VAN_CS2_196
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_620] Molten Giant - COST:20 [ATK:8/HP:8] 
			// - Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: Costs (1) less for each damage your hero has taken.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1372
			// --------------------------------------------------------
			cards.Add("VAN_EX1_620", new CardDef(new Power
			{
				// TODO [VAN_EX1_620] Molten Giant && Test: Molten Giant_VAN_EX1_620
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_025] Dragonling Mechanic - COST:4 [ATK:2/HP:4] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Summon a 2/1 Mechanical Dragonling.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 523
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 59
			// --------------------------------------------------------
			cards.Add("VAN_EX1_025", new CardDef(new Power
			{
				// TODO [VAN_EX1_025] Dragonling Mechanic && Test: Dragonling Mechanic_VAN_EX1_025
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_561] Alexstrasza - COST:9 [ATK:8/HP:8] 
			// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Set a hero's remaining Health to 15.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 581
			// --------------------------------------------------------
			cards.Add("VAN_EX1_561", new CardDef(new Power
			{
				// TODO [VAN_EX1_561] Alexstrasza && Test: Alexstrasza_VAN_EX1_561
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_169] Young Dragonhawk - COST:1 [ATK:1/HP:1] 
			// - Race: beast, Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Windfury</b>
			// --------------------------------------------------------
			// GameTag:
			// - WINDFURY = 1
			// - 858 = 641
			// --------------------------------------------------------
			cards.Add("VAN_CS2_169", new CardDef(new Power
			{
				// TODO [VAN_CS2_169] Young Dragonhawk && Test: Young Dragonhawk_VAN_CS2_169
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_131] Stormwind Knight - COST:4 [ATK:2/HP:5] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Charge</b>
			// --------------------------------------------------------
			// GameTag:
			// - CHARGE = 1
			// - 858 = 622
			// --------------------------------------------------------
			cards.Add("VAN_CS2_131", new CardDef(new Power
			{
				// TODO [VAN_CS2_131] Stormwind Knight && Test: Stormwind Knight_VAN_CS2_131
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_005] Big Game Hunter - COST:3 [ATK:4/HP:2] 
			// - Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy a minion with 7 or more Attack.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1657
			// --------------------------------------------------------
			cards.Add("VAN_EX1_005", new CardDef(new Power
			{
				// TODO [VAN_EX1_005] Big Game Hunter && Test: Big Game Hunter_VAN_EX1_005
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_405] Shieldbearer - COST:1 [ATK:0/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 866
			// --------------------------------------------------------
			cards.Add("VAN_EX1_405", new CardDef(new Power
			{
				// TODO [VAN_EX1_405] Shieldbearer && Test: Shieldbearer_VAN_EX1_405
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_029] Millhouse Manastorm - COST:2 [ATK:4/HP:4] 
			// - Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Enemy spells cost (0) next turn.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 855
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_029", new CardDef(new Power
			{
				// TODO [VAN_NEW1_029] Millhouse Manastorm && Test: Millhouse Manastorm_VAN_NEW1_029
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_187] Booty Bay Bodyguard - COST:5 [ATK:5/HP:4] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 1140
			// --------------------------------------------------------
			cards.Add("VAN_CS2_187", new CardDef(new Power
			{
				// TODO [VAN_CS2_187] Booty Bay Bodyguard && Test: Booty Bay Bodyguard_VAN_CS2_187
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_008] Argent Squire - COST:1 [ATK:1/HP:1] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Divine Shield</b>
			// --------------------------------------------------------
			// GameTag:
			// - DIVINE_SHIELD = 1
			// - 858 = 757
			// --------------------------------------------------------
			cards.Add("VAN_EX1_008", new CardDef(new Power
			{
				// TODO [VAN_EX1_008] Argent Squire && Test: Argent Squire_VAN_EX1_008
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS1_069] Fen Creeper - COST:5 [ATK:3/HP:6] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 602
			// --------------------------------------------------------
			cards.Add("VAN_CS1_069", new CardDef(new Power
			{
				// TODO [VAN_CS1_069] Fen Creeper && Test: Fen Creeper_VAN_CS1_069
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_100] Lorewalker Cho - COST:2 [ATK:0/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: Whenever a player casts a spell, put a copy into the other player’s hand.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 1135
			// --------------------------------------------------------
			cards.Add("VAN_EX1_100", new CardDef(new Power
			{
				// TODO [VAN_EX1_100] Lorewalker Cho && Test: Lorewalker Cho_VAN_EX1_100
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_026] Violet Teacher - COST:4 [ATK:3/HP:5] 
			// - Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever you cast a spell, summon a 1/1 Violet Apprentice.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 1029
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 71308
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_026", new CardDef(new Power
			{
				// TODO [VAN_NEW1_026] Violet Teacher && Test: Violet Teacher_VAN_NEW1_026
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_033] Windfury Harpy - COST:6 [ATK:4/HP:5] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Windfury</b>
			// --------------------------------------------------------
			// GameTag:
			// - WINDFURY = 1
			// - 858 = 567
			// --------------------------------------------------------
			cards.Add("VAN_EX1_033", new CardDef(new Power
			{
				// TODO [VAN_EX1_033] Windfury Harpy && Test: Windfury Harpy_VAN_EX1_033
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_082] Mad Bomber - COST:2 [ATK:3/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Deal 3 damage randomly split between all other characters.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 762
			// --------------------------------------------------------
			cards.Add("VAN_EX1_082", new CardDef(new Power
			{
				// TODO [VAN_EX1_082] Mad Bomber && Test: Mad Bomber_VAN_EX1_082
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_017] Jungle Panther - COST:3 [ATK:4/HP:2] 
			// - Race: beast, Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Stealth</b>
			// --------------------------------------------------------
			// GameTag:
			// - STEALTH = 1
			// - 858 = 921
			// - 1584 = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_017", new CardDef(new Power
			{
				// TODO [VAN_EX1_017] Jungle Panther && Test: Jungle Panther_VAN_EX1_017
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_186] War Golem - COST:7 [ATK:7/HP:7] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 712
			// --------------------------------------------------------
			cards.Add("VAN_CS2_186", new CardDef(new Power
			{
				// TODO [VAN_CS2_186] War Golem && Test: War Golem_VAN_CS2_186
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_593] Nightblade - COST:5 [ATK:4/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry: </b>Deal 3 damage to the enemy hero.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 670
			// --------------------------------------------------------
			cards.Add("VAN_EX1_593", new CardDef(new Power
			{
				// TODO [VAN_EX1_593] Nightblade && Test: Nightblade_VAN_EX1_593
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_116] Leeroy Jenkins - COST:4 [ATK:6/HP:2] 
			// - Fac: alliance, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Charge</b>. <b>Battlecry:</b> Summon two 1/1 Whelps for your opponent.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - CHARGE = 1
			// - BATTLECRY = 1
			// - 858 = 559
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 1912
			// --------------------------------------------------------
			cards.Add("VAN_EX1_116", new CardDef(new Power
			{
				// TODO [VAN_EX1_116] Leeroy Jenkins && Test: Leeroy Jenkins_VAN_EX1_116
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_016] Sylvanas Windrunner - COST:6 [ATK:5/HP:5] 
			// - Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Deathrattle:</b> Take
			//       control of a random
			//       enemy minion.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - DEATHRATTLE = 1
			// - 858 = 1721
			// --------------------------------------------------------
			cards.Add("VAN_EX1_016", new CardDef(new Power
			{
				// TODO [VAN_EX1_016] Sylvanas Windrunner && Test: Sylvanas Windrunner_VAN_EX1_016
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_162] Lord of the Arena - COST:6 [ATK:6/HP:5] 
			// - Fac: alliance, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Taunt</b>
			// --------------------------------------------------------
			// GameTag:
			// - TAUNT = 1
			// - 858 = 157
			// --------------------------------------------------------
			cards.Add("VAN_CS2_162", new CardDef(new Power
			{
				// TODO [VAN_CS2_162] Lord of the Arena && Test: Lord of the Arena_VAN_CS2_162
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_093] Defender of Argus - COST:4 [ATK:2/HP:3] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give adjacent minions +1/+1 and <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 763
			// - 1576 = 1
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_093", new CardDef(new Power
			{
				// TODO [VAN_EX1_093] Defender of Argus && Test: Defender of Argus_VAN_EX1_093
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_507] Murloc Warleader - COST:3 [ATK:3/HP:3] 
			// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: epic
			// --------------------------------------------------------
			// Text: ALL other murlocs have +2/+1.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 1063
			// --------------------------------------------------------
			cards.Add("VAN_EX1_507", new CardDef(new Power
			{
				// TODO [VAN_EX1_507] Murloc Warleader && Test: Murloc Warleader_VAN_EX1_507
				InfoCardId = "VAN_EX1_507e",
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_055] Mana Addict - COST:2 [ATK:1/HP:3] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: Whenever you cast a spell, gain +2 Attack this turn.
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 12
			// --------------------------------------------------------
			cards.Add("VAN_EX1_055", new CardDef(new Power
			{
				// TODO [VAN_EX1_055] Mana Addict && Test: Mana Addict_VAN_EX1_055
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_NEW1_041] Stampeding Kodo - COST:5 [ATK:3/HP:5] 
			// - Race: beast, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy a random enemy minion with 2 or less Attack.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 1371
			// --------------------------------------------------------
			cards.Add("VAN_NEW1_041", new CardDef(new Power
			{
				// TODO [VAN_NEW1_041] Stampeding Kodo && Test: Stampeding Kodo_VAN_NEW1_041
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_110] Cairne Bloodhoof - COST:6 [ATK:4/HP:5] 
			// - Fac: alliance, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Deathrattle:</b> Summon a 4/5 Baine Bloodhoof.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - DEATHRATTLE = 1
			// - 858 = 420
			// - COLLECTION_RELATED_CARD_DATABASE_ID = 70473
			// --------------------------------------------------------
			cards.Add("VAN_EX1_110", new CardDef(new Power
			{
				// TODO [VAN_EX1_110] Cairne Bloodhoof && Test: Cairne Bloodhoof_VAN_EX1_110
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_203] Ironbeak Owl - COST:2 [ATK:2/HP:1] 
			// - Race: beast, Fac: horde, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> <b>Silence</b> a_minion.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 290
			// --------------------------------------------------------
			// RefTag:
			// - SILENCE = 1
			// --------------------------------------------------------
			cards.Add("VAN_CS2_203", new CardDef(new Power
			{
				// TODO [VAN_CS2_203] Ironbeak Owl && Test: Ironbeak Owl_VAN_CS2_203
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_226] Frostwolf Warlord - COST:5 [ATK:4/HP:4] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Gain +1/+1 for each other friendly minion on the battlefield.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 496
			// --------------------------------------------------------
			cards.Add("VAN_CS2_226", new CardDef(new Power
			{
				// TODO [VAN_CS2_226] Frostwolf Warlord && Test: Frostwolf Warlord_VAN_CS2_226
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_162] Dire Wolf Alpha - COST:2 [ATK:2/HP:2] 
			// - Race: beast, Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: Adjacent minions have +1_Attack.
			// --------------------------------------------------------
			// GameTag:
			// - ADJACENT_BUFF = 1
			// - AURA = 1
			// - 858 = 985
			// --------------------------------------------------------
			cards.Add("VAN_EX1_162", new CardDef(new Power
			{
				// TODO [VAN_EX1_162] Dire Wolf Alpha && Test: Dire Wolf Alpha_VAN_EX1_162
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_584] Ancient Mage - COST:4 [ATK:2/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Give adjacent_minions <b>Spell_Damage +1</b>.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 915
			// - 1576 = 1
			// --------------------------------------------------------
			// RefTag:
			// - SPELLPOWER = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_584", new CardDef(new Power
			{
				// TODO [VAN_EX1_584] Ancient Mage && Test: Ancient Mage_VAN_EX1_584
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_557] Nat Pagle - COST:2 [ATK:0/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: At the start of your turn, you have a 50% chance to draw an extra card.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - 858 = 1147
			// --------------------------------------------------------
			cards.Add("VAN_EX1_557", new CardDef(new Power
			{
				// TODO [VAN_EX1_557] Nat Pagle && Test: Nat Pagle_VAN_EX1_557
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_085] Mind Control Tech - COST:3 [ATK:3/HP:3] 
			// - Fac: alliance, Set: vanilla, Rarity: rare
			// --------------------------------------------------------
			// Text: [x]<b>Battlecry:</b> If your opponent
			//       has 4 or more minions, take
			//        control of one at random.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 734
			// --------------------------------------------------------
			cards.Add("VAN_EX1_085", new CardDef(new Power
			{
				// TODO [VAN_EX1_085] Mind Control Tech && Test: Mind Control Tech_VAN_EX1_085
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_002] The Black Knight - COST:6 [ATK:4/HP:5] 
			// - Set: vanilla, Rarity: legendary
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Destroy an enemy minion with <b>Taunt</b>.
			// --------------------------------------------------------
			// GameTag:
			// - ELITE = 1
			// - BATTLECRY = 1
			// - 858 = 1656
			// --------------------------------------------------------
			// RefTag:
			// - TAUNT = 1
			// --------------------------------------------------------
			cards.Add("VAN_EX1_002", new CardDef(new Power
			{
				// TODO [VAN_EX1_002] The Black Knight && Test: The Black Knight_VAN_EX1_002
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_EX1_583] Priestess of Elune - COST:6 [ATK:5/HP:4] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Restore #4 Health to your hero.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 424
			// --------------------------------------------------------
			cards.Add("VAN_EX1_583", new CardDef(new Power
			{
				// TODO [VAN_EX1_583] Priestess of Elune && Test: Priestess of Elune_VAN_EX1_583
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_122] Raid Leader - COST:3 [ATK:2/HP:2] 
			// - Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: Your other minions have +1 Attack.
			// --------------------------------------------------------
			// GameTag:
			// - AURA = 1
			// - 858 = 1401
			// --------------------------------------------------------
			cards.Add("VAN_CS2_122", new CardDef(new Power
			{
				// TODO [VAN_CS2_122] Raid Leader && Test: Raid Leader_VAN_CS2_122
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_142] Kobold Geomancer - COST:2 [ATK:2/HP:2] 
			// - Fac: horde, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Spell Damage +1</b>
			// --------------------------------------------------------
			// GameTag:
			// - SPELLPOWER = 1
			// - 858 = 672
			// --------------------------------------------------------
			cards.Add("VAN_CS2_142", new CardDef(new Power
			{
				// TODO [VAN_CS2_142] Kobold Geomancer && Test: Kobold Geomancer_VAN_CS2_142
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_DS1_055] Darkscale Healer - COST:5 [ATK:4/HP:5] 
			// - Fac: neutral, Set: vanilla, Rarity: free
			// --------------------------------------------------------
			// Text: <b>Battlecry:</b> Restore #2 Health to all friendly characters.
			// --------------------------------------------------------
			// GameTag:
			// - BATTLECRY = 1
			// - 858 = 582
			// --------------------------------------------------------
			cards.Add("VAN_DS1_055", new CardDef(new Power
			{
				// TODO [VAN_DS1_055] Darkscale Healer && Test: Darkscale Healer_VAN_DS1_055
				//PowerTask = null,
				//Trigger = null,
			}));

			// --------------------------------------- MINION - NEUTRAL
			// [VAN_CS2_231] Wisp - COST:0 [ATK:1/HP:1] 
			// - Fac: neutral, Set: vanilla, Rarity: common
			// --------------------------------------------------------
			// GameTag:
			// - 858 = 179
			// --------------------------------------------------------
			cards.Add("VAN_CS2_231", new CardDef(new Power
			{
				// TODO [VAN_CS2_231] Wisp && Test: Wisp_VAN_CS2_231
				//PowerTask = null,
				//Trigger = null,
			}));

		}

		public static void AddAll(Dictionary<string, CardDef> cards)
		{
			Druid(cards);
			Hunter(cards);
			Mage(cards);
			Paladin(cards);
			Priest(cards);
			Rogue(cards);
			Shaman(cards);
			Warlock(cards);
			Warrior(cards);
			Neutral(cards);
		}
	}
}
