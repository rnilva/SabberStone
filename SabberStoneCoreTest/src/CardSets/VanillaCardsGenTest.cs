using Xunit;
using SabberStoneCore.Actions;
using SabberStoneCore.Auras;
using SabberStoneCore.Enums;
using SabberStoneCore.Config;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SabberStoneCoreTest.CardSets.Classic
{
	public class HeroPowersVanillaTest
	{
		// ------------------------------------ HERO_POWER - HUNTER
		// [VAN_HERO_05bp] Steady Shot (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Deal $2 damage to the enemy hero.@<b>Hero Power</b>
		//       Deal $2 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 229
		// - 1086 = 2738
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void SteadyShot_VAN_HERO_05bp()
		{
			// TODO SteadyShot_VAN_HERO_05bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Steady Shot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Steady Shot");
		}

		// ------------------------------------- HERO_POWER - ROGUE
		// [VAN_HERO_03bp] Dagger Mastery (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Equip a 1/2 Dagger.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 730
		// - 1086 = 2743
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void DaggerMastery_VAN_HERO_03bp()
		{
			// TODO DaggerMastery_VAN_HERO_03bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dagger Mastery", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Dagger Mastery");
		}

		// ----------------------------------- HERO_POWER - WARRIOR
		// [VAN_CS2_102_H3] Armor Up! (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Gain 2 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 58799
		// - 1086 = 59348
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ArmorUp_VAN_CS2_102_H3()
		{
			// TODO ArmorUp_VAN_CS2_102_H3 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Armor Up!", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Armor Up!");
		}

		// ------------------------------------- HERO_POWER - ROGUE
		// [VAN_HERO_03bp2] Poisoned Daggers (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Equip a 2/2 Weapon.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2743
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void PoisonedDaggers_VAN_HERO_03bp2()
		{
			// TODO PoisonedDaggers_VAN_HERO_03bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Poisoned Daggers", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Poisoned Daggers");
		}

		// ------------------------------------- HERO_POWER - DRUID
		// [VAN_HERO_06bp] Shapeshift (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       +1 Attack this turn.
		//       +1 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1123
		// - 1086 = 2737
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Shapeshift_VAN_HERO_06bp()
		{
			// TODO Shapeshift_VAN_HERO_06bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shapeshift", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Shapeshift");
		}

		// ----------------------------------- HERO_POWER - PALADIN
		// [VAN_HERO_04bp] Reinforce (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Summon a 1/1 Silver Hand Recruit.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 472
		// - 1086 = 2740
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Reinforce_VAN_HERO_04bp()
		{
			// TODO Reinforce_VAN_HERO_04bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Reinforce", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Reinforce");
		}

		// ------------------------------------- HERO_POWER - DRUID
		// [VAN_HERO_06bp2] Dire Shapeshift (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       +2 Attack this turn.
		//       +2 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2737
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void DireShapeshift_VAN_HERO_06bp2()
		{
			// TODO DireShapeshift_VAN_HERO_06bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dire Shapeshift", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Dire Shapeshift");
		}

		// ------------------------------------ HERO_POWER - SHAMAN
		// [VAN_HERO_02bp2] Totemic Slam (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Summon a Totem of your choice.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2742
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void TotemicSlam_VAN_HERO_02bp2()
		{
			// TODO TotemicSlam_VAN_HERO_02bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Totemic Slam", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Totemic Slam");
		}

		// ------------------------------------ HERO_POWER - PRIEST
		// [VAN_HERO_09bp2] Heal (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Restore #4 Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2741
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Heal_VAN_HERO_09bp2()
		{
			// TODO Heal_VAN_HERO_09bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Heal", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Heal");
		}

		// ----------------------------------- HERO_POWER - WARLOCK
		// [VAN_HERO_07bp2] Soul Tap (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2744
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void SoulTap_VAN_HERO_07bp2()
		{
			// TODO SoulTap_VAN_HERO_07bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Soul Tap", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Soul Tap");
		}

		// ----------------------------------- HERO_POWER - WARLOCK
		// [VAN_EX1_tk33] INFERNO! (*) - COST:2 
		// - Fac: neutral, Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Summon a 6/6 Infernal.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1178
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Inferno_VAN_EX1_tk33()
		{
			// TODO Inferno_VAN_EX1_tk33 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("INFERNO!", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("INFERNO!");
		}

		// ----------------------------------- HERO_POWER - WARLOCK
		// [VAN_HERO_07bp] Life Tap (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Draw a card and take $2_damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 300
		// - 1086 = 2744
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void LifeTap_VAN_HERO_07bp()
		{
			// TODO LifeTap_VAN_HERO_07bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Life Tap", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Life Tap");
		}

		// ----------------------------------- HERO_POWER - WARRIOR
		// [VAN_HERO_01bp2] Tank Up! (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Gain 4 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2745
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void TankUp_VAN_HERO_01bp2()
		{
			// TODO TankUp_VAN_HERO_01bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Tank Up!", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Tank Up!");
		}

		// -------------------------------------- HERO_POWER - MAGE
		// [VAN_HERO_08bp] Fireblast (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Deal $1 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 807
		// - 1086 = 2739
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Fireblast_VAN_HERO_08bp()
		{
			// TODO Fireblast_VAN_HERO_08bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Fireblast", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Fireblast");
		}

		// ----------------------------------- HERO_POWER - WARRIOR
		// [VAN_HERO_01bp] Armor Up! (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Gain 2 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 725
		// - 1086 = 2745
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ArmorUp_VAN_HERO_01bp()
		{
			// TODO ArmorUp_VAN_HERO_01bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Armor Up!", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Armor Up!");
		}

		// -------------------------------------- HERO_POWER - MAGE
		// [VAN_HERO_08bp2] Fireblast Rank 2 (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Deal $2 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2739
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void FireblastRank2_VAN_HERO_08bp2()
		{
			// TODO FireblastRank2_VAN_HERO_08bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Fireblast Rank 2", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Fireblast Rank 2");
		}

		// ------------------------------------ HERO_POWER - PRIEST
		// [VAN_HERO_09bp] Lesser Heal (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: [x]<b>Hero Power</b>
		//       Restore #2 Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 479
		// - 1086 = 2741
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void LesserHeal_VAN_HERO_09bp()
		{
			// TODO LesserHeal_VAN_HERO_09bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lesser Heal", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Lesser Heal");
		}

		// ----------------------------------- HERO_POWER - PALADIN
		// [VAN_HERO_04bp2] The Silver Hand (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Summon two 1/1 Recruits.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2740
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void TheSilverHand_VAN_HERO_04bp2()
		{
			// TODO TheSilverHand_VAN_HERO_04bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("The Silver Hand", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("The Silver Hand");
		}

		// ------------------------------------ HERO_POWER - HUNTER
		// [VAN_HERO_05bp2] Ballista Shot (*) - COST:2 
		// - Set: vanilla, 
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Deal $3 damage to the enemy hero.@<b>Hero Power</b>
		//       Deal $3 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 2738
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BallistaShot_VAN_HERO_05bp2()
		{
			// TODO BallistaShot_VAN_HERO_05bp2 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ballista Shot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Ballista Shot");
		}

		// ------------------------------------ HERO_POWER - SHAMAN
		// [VAN_HERO_02bp] Totemic Call (*) - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: <b>Hero Power</b>
		//       Summon a random basic Totem.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 687
		// - 1086 = 2742
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void TotemicCall_VAN_HERO_02bp()
		{
			// TODO TotemicCall_VAN_HERO_02bp test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Totemic Call", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Hero_power testCard = game.ProcessCard<Hero_power>("Totemic Call");
		}

	}

	public class DruidVanillaTest
	{
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
		[Fact(Skip = "ignore")]
		public void AncientOfWar_VAN_EX1_178()
		{
			// TODO AncientOfWar_VAN_EX1_178 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ancient of War", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ancient of War");
		}

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
		[Fact(Skip = "ignore")]
		public void DruidOfTheClaw_VAN_EX1_165()
		{
			// TODO DruidOfTheClaw_VAN_EX1_165 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Druid of the Claw", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Druid of the Claw");
		}

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
		[Fact(Skip = "ignore")]
		public void Cenarius_VAN_EX1_573()
		{
			// TODO Cenarius_VAN_EX1_573 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cenarius", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Cenarius");
		}

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
		[Fact(Skip = "ignore")]
		public void AncientOfLore_VAN_NEW1_008()
		{
			// TODO AncientOfLore_VAN_NEW1_008 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ancient of Lore", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ancient of Lore");
		}

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
		[Fact(Skip = "ignore")]
		public void KeeperOfTheGrove_VAN_EX1_166()
		{
			// TODO KeeperOfTheGrove_VAN_EX1_166 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Keeper of the Grove", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Keeper of the Grove");
		}

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
		[Fact(Skip = "ignore")]
		public void IronbarkProtector_VAN_CS2_232()
		{
			// TODO IronbarkProtector_VAN_CS2_232 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ironbark Protector", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ironbark Protector");
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_CS2_005] Claw - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give your hero +2_Attack this turn. Gain 2 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1050
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Claw_VAN_CS2_005()
		{
			// TODO Claw_VAN_CS2_005 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Claw", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Claw");
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_CS2_008] Moonfire - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $1 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 467
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Moonfire_VAN_CS2_008()
		{
			// TODO Moonfire_VAN_CS2_008 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Moonfire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Moonfire");
		}

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
		[Fact]
		public void ForceOfNature_VAN_EX1_571()
		{
			// TODO ForceOfNature_VAN_EX1_571 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Force of Nature", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;

			Spell testCard = game.ProcessCard<Spell>("Force of Nature");
			Assert.Equal(3, game.CurrentPlayer.BoardZone.Count);

			foreach (var m in game.CurrentPlayer.BoardZone)
				m.Attack(game.CurrentOpponent.Hero);
			Assert.Equal(6, game.CurrentOpponent.Hero.Damage);

			game.EndTurn();
			Assert.Empty(game.CurrentOpponent.BoardZone);
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_CS2_012] Swipe - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $4 damage to an enemy and $1 damage to all other enemies. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 64
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Swipe_VAN_CS2_012()
		{
			// TODO Swipe_VAN_CS2_012 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Swipe", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Swipe");
		}

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
		[Fact(Skip = "ignore")]
		public void Naturalize_VAN_EX1_161()
		{
			// TODO Naturalize_VAN_EX1_161 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Naturalize", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Naturalize");
		}

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
		[Fact(Skip = "ignore")]
		public void Nourish_VAN_EX1_164()
		{
			// TODO Nourish_VAN_EX1_164 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Nourish", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Nourish");
		}

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
		[Fact(Skip = "ignore")]
		public void MarkOfTheWild_VAN_CS2_009()
		{
			// TODO MarkOfTheWild_VAN_CS2_009 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mark of the Wild", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mark of the Wild");
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_EX1_169] Innervate - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Gain 2 Mana Crystals this turn only.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 254
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Innervate_VAN_EX1_169()
		{
			// TODO Innervate_VAN_EX1_169 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Innervate", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Innervate");
		}

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
		[Fact(Skip = "ignore")]
		public void Starfall_VAN_NEW1_007()
		{
			// TODO Starfall_VAN_NEW1_007 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Starfall", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Starfall");
		}

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
		[Fact(Skip = "ignore")]
		public void Savagery_VAN_EX1_578()
		{
			// TODO Savagery_VAN_EX1_578 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Savagery", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Savagery");
		}

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
		[Fact(Skip = "ignore")]
		public void MarkOfNature_VAN_EX1_155()
		{
			// TODO MarkOfNature_VAN_EX1_155 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mark of Nature", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mark of Nature");
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_CS2_007] Healing Touch - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Restore #8 Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 773
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void HealingTouch_VAN_CS2_007()
		{
			// TODO HealingTouch_VAN_CS2_007 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Healing Touch", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Healing Touch");
		}

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
		[Fact(Skip = "ignore")]
		public void SoulOfTheForest_VAN_EX1_158()
		{
			// TODO SoulOfTheForest_VAN_EX1_158 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Soul of the Forest", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Soul of the Forest");
		}

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
		[Fact(Skip = "ignore")]
		public void Starfire_VAN_EX1_173()
		{
			// TODO Starfire_VAN_EX1_173 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Starfire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Starfire");
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_EX1_570] Bite - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Give your hero +4_Attack this turn. Gain 4 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 577
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Bite_VAN_EX1_570()
		{
			// TODO Bite_VAN_EX1_570 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bite", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Bite");
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_CS2_011] Savage Roar - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give your characters +2_Attack this turn.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 742
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void SavageRoar_VAN_CS2_011()
		{
			// TODO SavageRoar_VAN_CS2_011 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Savage Roar", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Savage Roar");
		}

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
		[Fact(Skip = "ignore")]
		public void PowerOfTheWild_VAN_EX1_160()
		{
			// TODO PowerOfTheWild_VAN_EX1_160 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Power of the Wild", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Power of the Wild");
		}

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
		[Fact(Skip = "ignore")]
		public void Wrath_VAN_EX1_154()
		{
			// TODO Wrath_VAN_EX1_154 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Wrath", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Wrath");
		}

		// ------------------------------------------ SPELL - DRUID
		// [VAN_CS2_013] Wild Growth - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Gain an empty Mana Crystal.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1124
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void WildGrowth_VAN_CS2_013()
		{
			// TODO WildGrowth_VAN_CS2_013 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.DRUID,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Wild Growth", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.DRUID,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Wild Growth");
		}

	}

	public class HunterVanillaTest
	{
		// ---------------------------------------- MINION - HUNTER
		// [VAN_CS2_237] Starving Buzzard - COST:2 [ATK:2/HP:1] 
		// - Race: beast, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Whenever you summon a Beast, draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1241
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void StarvingBuzzard_VAN_CS2_237()
		{
			// TODO StarvingBuzzard_VAN_CS2_237 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Starving Buzzard", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Starving Buzzard");
		}

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
		[Fact(Skip = "ignore")]
		public void Houndmaster_VAN_DS1_070()
		{
			// TODO Houndmaster_VAN_DS1_070 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Houndmaster", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Houndmaster");
		}

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
		[Fact(Skip = "ignore")]
		public void TimberWolf_VAN_DS1_175()
		{
			// TODO TimberWolf_VAN_DS1_175 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Timber Wolf", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Timber Wolf");
		}

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
		[Fact(Skip = "ignore")]
		public void KingKrush_VAN_EX1_543()
		{
			// TODO KingKrush_VAN_EX1_543 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("King Krush", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("King Krush");
		}

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
		[Fact(Skip = "ignore")]
		public void SavannahHighmane_VAN_EX1_534()
		{
			// TODO SavannahHighmane_VAN_EX1_534 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Savannah Highmane", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Savannah Highmane");
		}

		// ---------------------------------------- MINION - HUNTER
		// [VAN_EX1_531] Scavenging Hyena - COST:2 [ATK:2/HP:2] 
		// - Race: beast, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Whenever a friendly Beast dies, gain +2/+1.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1281
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ScavengingHyena_VAN_EX1_531()
		{
			// TODO ScavengingHyena_VAN_EX1_531 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Scavenging Hyena", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Scavenging Hyena");
		}

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
		[Fact(Skip = "ignore")]
		public void TundraRhino_VAN_DS1_178()
		{
			// TODO TundraRhino_VAN_DS1_178 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Tundra Rhino", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Tundra Rhino");
		}

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
		[Fact(Skip = "ignore")]
		public void KillCommand_VAN_EX1_539()
		{
			// TODO KillCommand_VAN_EX1_539 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Kill Command", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Kill Command");
		}

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
		[Fact(Skip = "ignore")]
		public void FreezingTrap_VAN_EX1_611()
		{
			// TODO FreezingTrap_VAN_EX1_611 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Freezing Trap", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Freezing Trap");
		}

		// ----------------------------------------- SPELL - HUNTER
		// [VAN_DS1_184] Tracking - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Look at the top 3 cards of your deck. Draw one and discard the others.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1047
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Tracking_VAN_DS1_184()
		{
			// TODO Tracking_VAN_DS1_184 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Tracking", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Tracking");
		}

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
		[Fact(Skip = "ignore")]
		public void BestialWrath_VAN_EX1_549()
		{
			// TODO BestialWrath_VAN_EX1_549 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bestial Wrath", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Bestial Wrath");
		}

		// ----------------------------------------- SPELL - HUNTER
		// [VAN_NEW1_031] Animal Companion - COST:3 
		// - Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Summon a random Beast Companion.
		// --------------------------------------------------------
		// Entourage: NEW1_032, NEW1_033, NEW1_034
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 437
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void AnimalCompanion_VAN_NEW1_031()
		{
			// TODO AnimalCompanion_VAN_NEW1_031 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Animal Companion", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Animal Companion");
		}

		// ----------------------------------------- SPELL - HUNTER
		// [VAN_DS1_183] Multi-Shot - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $3 damage to two random enemy minions. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 292
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MultiShot_VAN_DS1_183()
		{
			// TODO MultiShot_VAN_DS1_183 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Multi-Shot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Multi-Shot");
		}

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
		[Fact(Skip = "ignore")]
		public void Misdirection_VAN_EX1_533()
		{
			// TODO Misdirection_VAN_EX1_533 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Misdirection", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Misdirection");
		}

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
		[Fact(Skip = "ignore")]
		public void UnleashTheHounds_VAN_EX1_538()
		{
			// TODO UnleashTheHounds_VAN_EX1_538 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Unleash the Hounds", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Unleash the Hounds");
		}

		// ----------------------------------------- SPELL - HUNTER
		// [VAN_DS1_185] Arcane Shot - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $2 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 877
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ArcaneShot_VAN_DS1_185()
		{
			// TODO ArcaneShot_VAN_DS1_185 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Arcane Shot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Arcane Shot");
		}

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
		[Fact(Skip = "ignore")]
		public void SnakeTrap_VAN_EX1_554()
		{
			// TODO SnakeTrap_VAN_EX1_554 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Snake Trap", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Snake Trap");
		}

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
		[Fact(Skip = "ignore")]
		public void Flare_VAN_EX1_544()
		{
			// TODO Flare_VAN_EX1_544 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Flare", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Flare");
		}

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
		[Fact(Skip = "ignore")]
		public void Snipe_VAN_EX1_609()
		{
			// TODO Snipe_VAN_EX1_609 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Snipe", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Snipe");
		}

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
		[Fact(Skip = "ignore")]
		public void ExplosiveTrap_VAN_EX1_610()
		{
			// TODO ExplosiveTrap_VAN_EX1_610 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Explosive Trap", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Explosive Trap");
		}

		// ----------------------------------------- SPELL - HUNTER
		// [VAN_EX1_537] Explosive Shot - COST:5 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Deal $5 damage to a minion and $2 damage to adjacent ones. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 394
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ExplosiveShot_VAN_EX1_537()
		{
			// TODO ExplosiveShot_VAN_EX1_537 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Explosive Shot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Explosive Shot");
		}

		// ----------------------------------------- SPELL - HUNTER
		// [VAN_EX1_617] Deadly Shot - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Destroy a random enemy minion.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1093
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void DeadlyShot_VAN_EX1_617()
		{
			// TODO DeadlyShot_VAN_EX1_617 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Deadly Shot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Deadly Shot");
		}

		// ----------------------------------------- SPELL - HUNTER
		// [VAN_CS2_084] Hunter's Mark - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Change a minion's Health to 1.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 141
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void HuntersMark_VAN_CS2_084()
		{
			// TODO HuntersMark_VAN_CS2_084 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Hunter's Mark", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Hunter's Mark");
		}

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
		[Fact(Skip = "ignore")]
		public void EaglehornBow_VAN_EX1_536()
		{
			// TODO EaglehornBow_VAN_EX1_536 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Eaglehorn Bow", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Eaglehorn Bow");
		}

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
		[Fact(Skip = "ignore")]
		public void GladiatorsLongbow_VAN_DS1_188()
		{
			// TODO GladiatorsLongbow_VAN_DS1_188 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.HUNTER,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Gladiator's Longbow", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.HUNTER,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Gladiator's Longbow");
		}

	}

	public class MageVanillaTest
	{
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
		[Fact(Skip = "ignore")]
		public void KirinTorMage_VAN_EX1_612()
		{
			// TODO KirinTorMage_VAN_EX1_612 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Kirin Tor Mage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Kirin Tor Mage");
		}

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
		[Fact(Skip = "ignore")]
		public void ArchmageAntonidas_VAN_EX1_559()
		{
			// TODO ArchmageAntonidas_VAN_EX1_559 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Archmage Antonidas", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Archmage Antonidas");
		}

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
		[Fact(Skip = "ignore")]
		public void WaterElemental_VAN_CS2_033()
		{
			// TODO WaterElemental_VAN_CS2_033 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Water Elemental", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Water Elemental");
		}

		// ------------------------------------------ MINION - MAGE
		// [VAN_NEW1_012] Mana Wyrm - COST:1 [ATK:1/HP:3] 
		// - Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Whenever you cast a spell, gain +1 Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 405
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ManaWyrm_VAN_NEW1_012()
		{
			// TODO ManaWyrm_VAN_NEW1_012 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mana Wyrm", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Mana Wyrm");
		}

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
		[Fact(Skip = "ignore")]
		public void SorcerersApprentice_VAN_EX1_608()
		{
			// TODO SorcerersApprentice_VAN_EX1_608 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sorcerer's Apprentice", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Sorcerer's Apprentice");
		}

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
		[Fact(Skip = "ignore")]
		public void EtherealArcanist_VAN_EX1_274()
		{
			// TODO EtherealArcanist_VAN_EX1_274 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ethereal Arcanist", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ethereal Arcanist");
		}

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
		[Fact(Skip = "ignore")]
		public void IceBarrier_VAN_EX1_289()
		{
			// TODO IceBarrier_VAN_EX1_289 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ice Barrier", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Ice Barrier");
		}

		// ------------------------------------------- SPELL - MAGE
		// [VAN_EX1_279] Pyroblast - COST:10 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Deal $10 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1087
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Pyroblast_VAN_EX1_279()
		{
			// TODO Pyroblast_VAN_EX1_279 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Pyroblast", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Pyroblast");
		}

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
		[Fact(Skip = "ignore")]
		public void Frostbolt_VAN_CS2_024()
		{
			// TODO Frostbolt_VAN_CS2_024 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Frostbolt", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Frostbolt");
		}

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
		[Fact(Skip = "ignore")]
		public void ConeOfCold_VAN_EX1_275()
		{
			// TODO ConeOfCold_VAN_EX1_275 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cone of Cold", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Cone of Cold");
		}

		// ------------------------------------------- SPELL - MAGE
		// [VAN_CS2_023] Arcane Intellect - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Draw 2 cards.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 555
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ArcaneIntellect_VAN_CS2_023()
		{
			// TODO ArcaneIntellect_VAN_CS2_023 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Arcane Intellect", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Arcane Intellect");
		}

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
		[Fact(Skip = "ignore")]
		public void Counterspell_VAN_EX1_287()
		{
			// TODO Counterspell_VAN_EX1_287 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Counterspell", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Counterspell");
		}

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
		[Fact(Skip = "ignore")]
		public void Vaporize_VAN_EX1_594()
		{
			// TODO Vaporize_VAN_EX1_594 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Vaporize", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Vaporize");
		}

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
		[Fact(Skip = "ignore")]
		public void FrostNova_VAN_CS2_026()
		{
			// TODO FrostNova_VAN_CS2_026 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Frost Nova", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Frost Nova");
		}

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
		[Fact(Skip = "ignore")]
		public void MirrorEntity_VAN_EX1_294()
		{
			// TODO MirrorEntity_VAN_EX1_294 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mirror Entity", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mirror Entity");
		}

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
		[Fact(Skip = "ignore")]
		public void Spellbender_VAN_tt_010()
		{
			// TODO Spellbender_VAN_tt_010 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Spellbender", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Spellbender");
		}

		// ------------------------------------------- SPELL - MAGE
		// [VAN_CS2_025] Arcane Explosion - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $1 damage to all enemy minions. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 447
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ArcaneExplosion_VAN_CS2_025()
		{
			// TODO ArcaneExplosion_VAN_CS2_025 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Arcane Explosion", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Arcane Explosion");
		}

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
		[Fact(Skip = "ignore")]
		public void Blizzard_VAN_CS2_028()
		{
			// TODO Blizzard_VAN_CS2_028 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blizzard", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Blizzard");
		}

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
		[Fact(Skip = "ignore")]
		public void IceLance_VAN_CS2_031()
		{
			// TODO IceLance_VAN_CS2_031 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ice Lance", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Ice Lance");
		}

		// ------------------------------------------- SPELL - MAGE
		// [VAN_CS2_032] Flamestrike - COST:7 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $4 damage to all enemy minions. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1004
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Flamestrike_VAN_CS2_032()
		{
			// TODO Flamestrike_VAN_CS2_032 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Flamestrike", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Flamestrike");
		}

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
		[Fact(Skip = "ignore")]
		public void MirrorImage_VAN_CS2_027()
		{
			// TODO MirrorImage_VAN_CS2_027 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mirror Image", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mirror Image");
		}

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
		[Fact(Skip = "ignore")]
		public void IceBlock_VAN_EX1_295()
		{
			// TODO IceBlock_VAN_EX1_295 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ice Block", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Ice Block");
		}

		// ------------------------------------------- SPELL - MAGE
		// [VAN_CS2_029] Fireball - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $6 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 315
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Fireball_VAN_CS2_029()
		{
			// TODO Fireball_VAN_CS2_029 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Fireball", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Fireball");
		}

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
		[Fact(Skip = "ignore")]
		public void Polymorph_VAN_CS2_022()
		{
			// TODO Polymorph_VAN_CS2_022 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Polymorph", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Polymorph");
		}

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
		[Fact(Skip = "ignore")]
		public void ArcaneMissiles_VAN_EX1_277()
		{
			// TODO ArcaneMissiles_VAN_EX1_277 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Arcane Missiles", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Arcane Missiles");
		}

	}

	public class PaladinVanillaTest
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
		[Fact(Skip = "ignore")]
		public void ArgentProtector_VAN_EX1_362()
		{
			// TODO ArgentProtector_VAN_EX1_362 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Argent Protector", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Argent Protector");
		}

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
		[Fact(Skip = "ignore")]
		public void TirionFordring_VAN_EX1_383()
		{
			// TODO TirionFordring_VAN_EX1_383 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Tirion Fordring", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Tirion Fordring");
		}

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
		[Fact(Skip = "ignore")]
		public void GuardianOfKings_VAN_CS2_088()
		{
			// TODO GuardianOfKings_VAN_CS2_088 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Guardian of Kings", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Guardian of Kings");
		}

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
		[Fact(Skip = "ignore")]
		public void AldorPeacekeeper_VAN_EX1_382()
		{
			// TODO AldorPeacekeeper_VAN_EX1_382 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Aldor Peacekeeper", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Aldor Peacekeeper");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_CS2_092] Blessing of Kings - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give a minion +4/+4. <i>(+4 Attack/+4 Health)</i>
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 943
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BlessingOfKings_VAN_CS2_092()
		{
			// TODO BlessingOfKings_VAN_CS2_092 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blessing of Kings", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Blessing of Kings");
		}

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
		[Fact(Skip = "ignore")]
		public void NobleSacrifice_VAN_EX1_130()
		{
			// TODO NobleSacrifice_VAN_EX1_130 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Noble Sacrifice", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Noble Sacrifice");
		}

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
		[Fact(Skip = "ignore")]
		public void HammerOfWrath_VAN_CS2_094()
		{
			// TODO HammerOfWrath_VAN_CS2_094 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Hammer of Wrath", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Hammer of Wrath");
		}

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
		[Fact(Skip = "ignore")]
		public void HandOfProtection_VAN_EX1_371()
		{
			// TODO HandOfProtection_VAN_EX1_371 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Hand of Protection", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Hand of Protection");
		}

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
		[Fact(Skip = "ignore")]
		public void EyeForAnEye_VAN_EX1_132()
		{
			// TODO EyeForAnEye_VAN_EX1_132 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Eye for an Eye", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Eye for an Eye");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_EX1_363] Blessing of Wisdom - COST:1 
		// - Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Choose a minion. Whenever it attacks, draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1373
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BlessingOfWisdom_VAN_EX1_363()
		{
			// TODO BlessingOfWisdom_VAN_EX1_363 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blessing of Wisdom", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Blessing of Wisdom");
		}

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
		[Fact(Skip = "ignore")]
		public void Repentance_VAN_EX1_379()
		{
			// TODO Repentance_VAN_EX1_379 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Repentance", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Repentance");
		}

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
		[Fact(Skip = "ignore")]
		public void HolyWrath_VAN_EX1_365()
		{
			// TODO HolyWrath_VAN_EX1_365 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Holy Wrath", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Holy Wrath");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_EX1_355] Blessed Champion - COST:5 
		// - Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Double a minion's Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1522
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BlessedChampion_VAN_EX1_355()
		{
			// TODO BlessedChampion_VAN_EX1_355 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blessed Champion", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Blessed Champion");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_EX1_360] Humility - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Change a minion's Attack to 1.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 854
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Humility_VAN_EX1_360()
		{
			// TODO Humility_VAN_EX1_360 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Humility", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Humility");
		}

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
		[Fact(Skip = "ignore")]
		public void Redemption_VAN_EX1_136()
		{
			// TODO Redemption_VAN_EX1_136 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Redemption", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Redemption");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_CS2_089] Holy Light - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Restore #6 Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 291
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void HolyLight_VAN_CS2_089()
		{
			// TODO HolyLight_VAN_CS2_089 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Holy Light", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Holy Light");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_EX1_354] Lay on Hands - COST:8 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Restore #8 Health. Draw_3 cards.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 594
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void LayOnHands_VAN_EX1_354()
		{
			// TODO LayOnHands_VAN_EX1_354 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lay on Hands", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Lay on Hands");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_EX1_349] Divine Favor - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Draw cards until you have as many in hand as your opponent.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 679
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void DivineFavor_VAN_EX1_349()
		{
			// TODO DivineFavor_VAN_EX1_349 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Divine Favor", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Divine Favor");
		}

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
		[Fact(Skip = "ignore")]
		public void AvengingWrath_VAN_EX1_384()
		{
			// TODO AvengingWrath_VAN_EX1_384 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Avenging Wrath", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Avenging Wrath");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_CS2_093] Consecration - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $2 damage to all enemies. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 476
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Consecration_VAN_CS2_093()
		{
			// TODO Consecration_VAN_CS2_093 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Consecration", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Consecration");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_CS2_087] Blessing of Might - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give a minion +3_Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 70
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BlessingOfMight_VAN_CS2_087()
		{
			// TODO BlessingOfMight_VAN_CS2_087 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blessing of Might", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Blessing of Might");
		}

		// ---------------------------------------- SPELL - PALADIN
		// [VAN_EX1_619] Equality - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Change the Health of ALL minions to 1.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 756
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Equality_VAN_EX1_619()
		{
			// TODO Equality_VAN_EX1_619 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Equality", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Equality");
		}

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
		[Fact(Skip = "ignore")]
		public void TruesilverChampion_VAN_CS2_097()
		{
			// TODO TruesilverChampion_VAN_CS2_097 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Truesilver Champion", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Truesilver Champion");
		}

		// --------------------------------------- WEAPON - PALADIN
		// [VAN_CS2_091] Light's Justice - COST:1 [ATK:1/HP:0] 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - DURABILITY = 4
		// - 858 = 383
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void LightsJustice_VAN_CS2_091()
		{
			// TODO LightsJustice_VAN_CS2_091 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Light's Justice", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Light's Justice");
		}

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
		[Fact(Skip = "ignore")]
		public void SwordOfJustice_VAN_EX1_366()
		{
			// TODO SwordOfJustice_VAN_EX1_366 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PALADIN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sword of Justice", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PALADIN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Sword of Justice");
		}

	}

	public class PriestVanillaTest
	{
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
		[Fact(Skip = "ignore")]
		public void TempleEnforcer_VAN_EX1_623()
		{
			// TODO TempleEnforcer_VAN_EX1_623 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Temple Enforcer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Temple Enforcer");
		}

		// ---------------------------------------- MINION - PRIEST
		// [VAN_EX1_341] Lightwell - COST:2 [ATK:0/HP:5] 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: At the start of your turn, restore #3 Health to a damaged friendly character.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 797
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Lightwell_VAN_EX1_341()
		{
			// TODO Lightwell_VAN_EX1_341 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lightwell", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Lightwell");
		}

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
		[Fact(Skip = "ignore")]
		public void CabalShadowPriest_VAN_EX1_091()
		{
			// TODO CabalShadowPriest_VAN_EX1_091 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cabal Shadow Priest", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Cabal Shadow Priest");
		}

		// ---------------------------------------- MINION - PRIEST
		// [VAN_CS2_235] Northshire Cleric - COST:1 [ATK:1/HP:3] 
		// - Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Whenever a minion is healed, draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1650
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void NorthshireCleric_VAN_CS2_235()
		{
			// TODO NorthshireCleric_VAN_CS2_235 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Northshire Cleric", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Northshire Cleric");
		}

		// ---------------------------------------- MINION - PRIEST
		// [VAN_EX1_335] Lightspawn - COST:4 [ATK:0/HP:5] 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: This minion's Attack is always equal to its Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 886
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Lightspawn_VAN_EX1_335()
		{
			// TODO Lightspawn_VAN_EX1_335 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lightspawn", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Lightspawn");
		}

		// ---------------------------------------- MINION - PRIEST
		// [VAN_EX1_591] Auchenai Soulpriest - COST:4 [ATK:3/HP:5] 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Your cards and powers that restore Health now deal damage instead.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 237
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void AuchenaiSoulpriest_VAN_EX1_591()
		{
			// TODO AuchenaiSoulpriest_VAN_EX1_591 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Auchenai Soulpriest", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Auchenai Soulpriest");
		}

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
		[Fact(Skip = "ignore")]
		public void ProphetVelen_VAN_EX1_350()
		{
			// TODO ProphetVelen_VAN_EX1_350 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Prophet Velen", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Prophet Velen");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_DS1_233] Mind Blast - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Deal $5 damage to the enemy hero. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 545
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MindBlast_VAN_DS1_233()
		{
			// TODO MindBlast_VAN_DS1_233 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mind Blast", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mind Blast");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_CS1_113] Mind Control - COST:10 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Take control of an enemy minion.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 8
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MindControl_VAN_CS1_113()
		{
			// TODO MindControl_VAN_CS1_113 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mind Control", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mind Control");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_EX1_334] Shadow Madness - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Gain control of an enemy minion with 3 or less Attack until end of turn.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 220
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ShadowMadness_VAN_EX1_334()
		{
			// TODO ShadowMadness_VAN_EX1_334 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shadow Madness", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shadow Madness");
		}

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
		[Fact(Skip = "ignore")]
		public void Shadowform_VAN_EX1_625()
		{
			// TODO Shadowform_VAN_EX1_625 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shadowform", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shadowform");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_EX1_622] Shadow Word: Death - COST:3 
		// - Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Destroy a minion with 5_or more Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1363
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ShadowWordDeath_VAN_EX1_622()
		{
			// TODO ShadowWordDeath_VAN_EX1_622 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shadow Word: Death", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shadow Word: Death");
		}

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
		[Fact(Skip = "ignore")]
		public void Silence_VAN_EX1_332()
		{
			// TODO Silence_VAN_EX1_332 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Silence", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Silence");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_CS2_003] Mind Vision - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Put a copy of a random card in your opponent's hand into your hand.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1099
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MindVision_VAN_CS2_003()
		{
			// TODO MindVision_VAN_CS2_003 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mind Vision", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mind Vision");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_EX1_339] Thoughtsteal - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Copy 2 cards in your opponent's deck and add them to your hand.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 30
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Thoughtsteal_VAN_EX1_339()
		{
			// TODO Thoughtsteal_VAN_EX1_339 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Thoughtsteal", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Thoughtsteal");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_CS1_130] Holy Smite - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $2 damage. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 279
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void HolySmite_VAN_CS1_130()
		{
			// TODO HolySmite_VAN_CS1_130 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Holy Smite", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Holy Smite");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_CS2_234] Shadow Word: Pain - COST:2 
		// - Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Destroy a minion with 3_or less Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1367
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ShadowWordPain_VAN_CS2_234()
		{
			// TODO ShadowWordPain_VAN_CS2_234 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shadow Word: Pain", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shadow Word: Pain");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_EX1_624] Holy Fire - COST:6 
		// - Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Deal $5 damage. Restore #5 Health to your hero. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1365
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void HolyFire_VAN_EX1_624()
		{
			// TODO HolyFire_VAN_EX1_624 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Holy Fire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Holy Fire");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_EX1_621] Circle of Healing - COST:0 
		// - Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Restore #4 Health to ALL_minions.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1362
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void CircleOfHealing_VAN_EX1_621()
		{
			// TODO CircleOfHealing_VAN_EX1_621 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Circle of Healing", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Circle of Healing");
		}

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
		[Fact(Skip = "ignore")]
		public void PowerWordShield_VAN_CS2_004()
		{
			// TODO PowerWordShield_VAN_CS2_004 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Power Word: Shield", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Power Word: Shield");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_CS2_236] Divine Spirit - COST:2 
		// - Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Double a minion's Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1361
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void DivineSpirit_VAN_CS2_236()
		{
			// TODO DivineSpirit_VAN_CS2_236 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Divine Spirit", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Divine Spirit");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_CS1_112] Holy Nova - COST:5 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $2 damage to all enemies. Restore #2 Health to all friendly characters. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 841
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void HolyNova_VAN_CS1_112()
		{
			// TODO HolyNova_VAN_CS1_112 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Holy Nova", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Holy Nova");
		}

		// ----------------------------------------- SPELL - PRIEST
		// [VAN_CS1_129] Inner Fire - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Change a minion's Attack to be equal to its Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 376
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void InnerFire_VAN_CS1_129()
		{
			// TODO InnerFire_VAN_CS1_129 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Inner Fire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Inner Fire");
		}

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
		[Fact(Skip = "ignore")]
		public void Mindgames_VAN_EX1_345()
		{
			// TODO Mindgames_VAN_EX1_345 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mindgames", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mindgames");
		}

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
		[Fact(Skip = "ignore")]
		public void MassDispel_VAN_EX1_626()
		{
			// TODO MassDispel_VAN_EX1_626 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.PRIEST,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mass Dispel", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.PRIEST,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mass Dispel");
		}

	}

	public class RogueVanillaTest
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
		[Fact(Skip = "ignore")]
		public void PatientAssassin_VAN_EX1_522()
		{
			// TODO PatientAssassin_VAN_EX1_522 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Patient Assassin", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Patient Assassin");
		}

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
		[Fact(Skip = "ignore")]
		public void EdwinVancleef_VAN_EX1_613()
		{
			// TODO EdwinVancleef_VAN_EX1_613 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Edwin VanCleef", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Edwin VanCleef");
		}

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
		[Fact(Skip = "ignore")]
		public void Si7Agent_VAN_EX1_134()
		{
			// TODO Si7Agent_VAN_EX1_134 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("SI:7 Agent", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("SI:7 Agent");
		}

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
		[Fact(Skip = "ignore")]
		public void DefiasRingleader_VAN_EX1_131()
		{
			// TODO DefiasRingleader_VAN_EX1_131 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Defias Ringleader", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Defias Ringleader");
		}

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
		[Fact]
		public void MasterOfDisguise_VAN_NEW1_014()
		{
			// TODO MasterOfDisguise_VAN_NEW1_014 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Master of Disguise", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			MinionInPlay target = game.ProcessCard<MinionInPlay>("Wisp");
			Minion testCard = game.ProcessCard<Minion>("Master of Disguise", target);

			Assert.True(target.HasStealth);
			game.EndTurn();

			Assert.True(target.HasStealth);
			game.EndTurn();

			Assert.True(target.HasStealth);
			game.EndTurn();

			Assert.True(target.HasStealth);
			game.EndTurn();

			Assert.True(target.HasStealth);
			target.Attack(game.CurrentOpponent.Hero);
			Assert.False(target.HasStealth);
		}

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
		[Fact(Skip = "ignore")]
		public void Kidnapper_VAN_NEW1_005()
		{
			// TODO Kidnapper_VAN_NEW1_005 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Kidnapper", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Kidnapper");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_EX1_145] Preparation - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: The next spell you cast this turn costs (3) less.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1158
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Preparation_VAN_EX1_145()
		{
			// TODO Preparation_VAN_EX1_145 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Preparation", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Preparation");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_CS2_077] Sprint - COST:7 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Draw 4 cards.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 630
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Sprint_VAN_CS2_077()
		{
			// TODO Sprint_VAN_CS2_077 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sprint", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Sprint");
		}

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
		[Fact(Skip = "ignore")]
		public void Headcrack_VAN_EX1_137()
		{
			// TODO Headcrack_VAN_EX1_137 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Headcrack", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Headcrack");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_EX1_126] Betrayal - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Force an enemy minion to deal its damage to the minions next to it.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 282
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Betrayal_VAN_EX1_126()
		{
			// TODO Betrayal_VAN_EX1_126 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Betrayal", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Betrayal");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_EX1_129] Fan of Knives - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $1 damage to all enemy minions. Draw_a card. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 667
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void FanOfKnives_VAN_EX1_129()
		{
			// TODO FanOfKnives_VAN_EX1_129 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Fan of Knives", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Fan of Knives");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_CS2_075] Sinister Strike - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $3 damage to the_enemy hero. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 710
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void SinisterStrike_VAN_CS2_075()
		{
			// TODO SinisterStrike_VAN_CS2_075 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sinister Strike", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Sinister Strike");
		}

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
		[Fact(Skip = "ignore")]
		public void Eviscerate_VAN_EX1_124()
		{
			// TODO Eviscerate_VAN_EX1_124 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Eviscerate", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Eviscerate");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_EX1_581] Sap - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Return an enemy minion to your opponent's hand.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 461
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Sap_VAN_EX1_581()
		{
			// TODO Sap_VAN_EX1_581 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sap", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Sap");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_CS2_076] Assassinate - COST:5 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Destroy an enemy minion.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 345
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Assassinate_VAN_CS2_076()
		{
			// TODO Assassinate_VAN_CS2_076 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Assassinate", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Assassinate");
		}

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
		[Fact(Skip = "ignore")]
		public void ColdBlood_VAN_CS2_073()
		{
			// TODO ColdBlood_VAN_CS2_073 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cold Blood", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Cold Blood");
		}

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
		[Fact(Skip = "ignore")]
		public void BladeFlurry_VAN_CS2_233()
		{
			// TODO BladeFlurry_VAN_CS2_233 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blade Flurry", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Blade Flurry");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_CS2_074] Deadly Poison - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give your weapon +2_Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 459
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void DeadlyPoison_VAN_CS2_074()
		{
			// TODO DeadlyPoison_VAN_CS2_074 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Deadly Poison", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Deadly Poison");
		}

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
		[Fact(Skip = "ignore")]
		public void Shiv_VAN_EX1_278()
		{
			// TODO Shiv_VAN_EX1_278 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shiv", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shiv");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_CS2_072] Backstab - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $2 damage to an undamaged minion. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 180
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Backstab_VAN_CS2_072()
		{
			// TODO Backstab_VAN_CS2_072 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Backstab", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Backstab");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_NEW1_004] Vanish - COST:6 
		// - Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Return all minions to their owner's hand.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 196
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Vanish_VAN_NEW1_004()
		{
			// TODO Vanish_VAN_NEW1_004 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Vanish", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Vanish");
		}

		// ------------------------------------------ SPELL - ROGUE
		// [VAN_EX1_144] Shadowstep - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Return a friendly minion to your hand. It_costs (2) less.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 365
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Shadowstep_VAN_EX1_144()
		{
			// TODO Shadowstep_VAN_EX1_144 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shadowstep", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shadowstep");
		}

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
		[Fact(Skip = "ignore")]
		public void Conceal_VAN_EX1_128()
		{
			// TODO Conceal_VAN_EX1_128 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Conceal", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Conceal");
		}

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
		[Fact(Skip = "ignore")]
		public void PerditionsBlade_VAN_EX1_133()
		{
			// TODO PerditionsBlade_VAN_EX1_133 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Perdition's Blade", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Perdition's Blade");
		}

		// ----------------------------------------- WEAPON - ROGUE
		// [VAN_CS2_080] Assassin's Blade - COST:5 [ATK:3/HP:0] 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - DURABILITY = 4
		// - 858 = 421
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void AssassinsBlade_VAN_CS2_080()
		{
			// TODO AssassinsBlade_VAN_CS2_080 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.ROGUE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Assassin's Blade", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.ROGUE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Assassin's Blade");
		}

	}

	public class ShamanVanillaTest
	{
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
		[Fact(Skip = "ignore")]
		public void FireElemental_VAN_CS2_042()
		{
			// TODO FireElemental_VAN_CS2_042 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Fire Elemental", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Fire Elemental");
		}

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
		[Fact(Skip = "ignore")]
		public void EarthElemental_VAN_EX1_250()
		{
			// TODO EarthElemental_VAN_EX1_250 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Earth Elemental", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Earth Elemental");
		}

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
		[Fact(Skip = "ignore")]
		public void UnboundElemental_VAN_EX1_258()
		{
			// TODO UnboundElemental_VAN_EX1_258 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Unbound Elemental", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Unbound Elemental");
		}

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
		[Fact(Skip = "ignore")]
		public void Windspeaker_VAN_EX1_587()
		{
			// TODO Windspeaker_VAN_EX1_587 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Windspeaker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Windspeaker");
		}

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
		[Fact(Skip = "ignore")]
		public void FlametongueTotem_VAN_EX1_565()
		{
			// TODO FlametongueTotem_VAN_EX1_565 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Flametongue Totem", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Flametongue Totem");
		}

		// ---------------------------------------- MINION - SHAMAN
		// [VAN_EX1_575] Mana Tide Totem - COST:3 [ATK:0/HP:3] 
		// - Race: totem, Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: At the end of your turn, draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 513
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ManaTideTotem_VAN_EX1_575()
		{
			// TODO ManaTideTotem_VAN_EX1_575 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mana Tide Totem", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Mana Tide Totem");
		}

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
		[Fact(Skip = "ignore")]
		public void AlakirTheWindlord_VAN_NEW1_010()
		{
			// TODO AlakirTheWindlord_VAN_NEW1_010 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Al'Akir the Windlord", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Al'Akir the Windlord");
		}

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
		[Fact(Skip = "ignore")]
		public void DustDevil_VAN_EX1_243()
		{
			// TODO DustDevil_VAN_EX1_243 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dust Devil", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Dust Devil");
		}

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
		[Fact(Skip = "ignore")]
		public void LavaBurst_VAN_EX1_241()
		{
			// TODO LavaBurst_VAN_EX1_241 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lava Burst", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Lava Burst");
		}

		// ----------------------------------------- SPELL - SHAMAN
		// [VAN_CS2_045] Rockbiter Weapon - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give a friendly character +3 Attack this turn.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 239
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void RockbiterWeapon_VAN_CS2_045()
		{
			// TODO RockbiterWeapon_VAN_CS2_045 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Rockbiter Weapon", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Rockbiter Weapon");
		}

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
		[Fact(Skip = "ignore")]
		public void ForkedLightning_VAN_EX1_251()
		{
			// TODO ForkedLightning_VAN_EX1_251 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Forked Lightning", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Forked Lightning");
		}

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
		[Fact(Skip = "ignore")]
		public void EarthShock_VAN_EX1_245()
		{
			// TODO EarthShock_VAN_EX1_245 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Earth Shock", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Earth Shock");
		}

		// ----------------------------------------- SPELL - SHAMAN
		// [VAN_CS2_053] Far Sight - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Draw a card. That card costs (3) less.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 818
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void FarSight_VAN_CS2_053()
		{
			// TODO FarSight_VAN_CS2_053 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Far Sight", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Far Sight");
		}

		// ----------------------------------------- SPELL - SHAMAN
		// [VAN_CS2_046] Bloodlust - COST:5 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give your minions +3_Attack this turn.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1171
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Bloodlust_VAN_CS2_046()
		{
			// TODO Bloodlust_VAN_CS2_046 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bloodlust", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Bloodlust");
		}

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
		[Fact(Skip = "ignore")]
		public void Hex_VAN_EX1_246()
		{
			// TODO Hex_VAN_EX1_246 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Hex", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Hex");
		}

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
		[Fact(Skip = "ignore")]
		public void AncestralHealing_VAN_CS2_041()
		{
			// TODO AncestralHealing_VAN_CS2_041 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ancestral Healing", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Ancestral Healing");
		}

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
		[Fact(Skip = "ignore")]
		public void FeralSpirit_VAN_EX1_248()
		{
			// TODO FeralSpirit_VAN_EX1_248 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Feral Spirit", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Feral Spirit");
		}

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
		[Fact(Skip = "ignore")]
		public void LightningStorm_VAN_EX1_259()
		{
			// TODO LightningStorm_VAN_EX1_259 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lightning Storm", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Lightning Storm");
		}

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
		[Fact(Skip = "ignore")]
		public void Windfury_VAN_CS2_039()
		{
			// TODO Windfury_VAN_CS2_039 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Windfury", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Windfury");
		}

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
		[Fact(Skip = "ignore")]
		public void LightningBolt_VAN_EX1_238()
		{
			// TODO LightningBolt_VAN_EX1_238 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lightning Bolt", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Lightning Bolt");
		}

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
		[Fact(Skip = "ignore")]
		public void FrostShock_VAN_CS2_037()
		{
			// TODO FrostShock_VAN_CS2_037 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Frost Shock", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Frost Shock");
		}

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
		[Fact(Skip = "ignore")]
		public void AncestralSpirit_VAN_CS2_038()
		{
			// TODO AncestralSpirit_VAN_CS2_038 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ancestral Spirit", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Ancestral Spirit");
		}

		// ----------------------------------------- SPELL - SHAMAN
		// [VAN_EX1_244] Totemic Might - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give your Totems +2_Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 830
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void TotemicMight_VAN_EX1_244()
		{
			// TODO TotemicMight_VAN_EX1_244 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Totemic Might", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Totemic Might");
		}

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
		[Fact(Skip = "ignore")]
		public void Doomhammer_VAN_EX1_567()
		{
			// TODO Doomhammer_VAN_EX1_567 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Doomhammer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Doomhammer");
		}

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
		[Fact(Skip = "ignore")]
		public void StormforgedAxe_VAN_EX1_247()
		{
			// TODO StormforgedAxe_VAN_EX1_247 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.SHAMAN,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Stormforged Axe", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.SHAMAN,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Stormforged Axe");
		}

	}

	public class WarlockVanillaTest
	{
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
		[Fact(Skip = "ignore")]
		public void BloodImp_VAN_CS2_059()
		{
			// TODO BloodImp_VAN_CS2_059 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blood Imp", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Blood Imp");
		}

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
		[Fact(Skip = "ignore")]
		public void PitLord_VAN_EX1_313()
		{
			// TODO PitLord_VAN_EX1_313 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Pit Lord", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Pit Lord");
		}

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
		[Fact(Skip = "ignore")]
		public void LordJaraxxus_VAN_EX1_323()
		{
			// TODO LordJaraxxus_VAN_EX1_323 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lord Jaraxxus", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Lord Jaraxxus");
		}

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
		[Fact(Skip = "ignore")]
		public void Doomguard_VAN_EX1_310()
		{
			// TODO Doomguard_VAN_EX1_310 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Doomguard", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Doomguard");
		}

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
		[Fact(Skip = "ignore")]
		public void SummoningPortal_VAN_EX1_315()
		{
			// TODO SummoningPortal_VAN_EX1_315 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Summoning Portal", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Summoning Portal");
		}

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
		[Fact(Skip = "ignore")]
		public void DreadInfernal_VAN_CS2_064()
		{
			// TODO DreadInfernal_VAN_CS2_064 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dread Infernal", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Dread Infernal");
		}

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
		[Fact(Skip = "ignore")]
		public void Felstalker_VAN_EX1_306()
		{
			// TODO Felstalker_VAN_EX1_306 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Felstalker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Felstalker");
		}

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
		[Fact(Skip = "ignore")]
		public void Felguard_VAN_EX1_301()
		{
			// TODO Felguard_VAN_EX1_301 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Felguard", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Felguard");
		}

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
		[Fact(Skip = "ignore")]
		public void Voidwalker_VAN_CS2_065()
		{
			// TODO Voidwalker_VAN_CS2_065 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Voidwalker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Voidwalker");
		}

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
		[Fact(Skip = "ignore")]
		public void VoidTerror_VAN_EX1_304()
		{
			// TODO VoidTerror_VAN_EX1_304 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Void Terror", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Void Terror");
		}

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
		[Fact(Skip = "ignore")]
		public void FlameImp_VAN_EX1_319()
		{
			// TODO FlameImp_VAN_EX1_319 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Flame Imp", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Flame Imp");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_CS2_061] Drain Life - COST:3 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $2 damage. Restore #2 Health to your hero. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 919
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void DrainLife_VAN_CS2_061()
		{
			// TODO DrainLife_VAN_CS2_061 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Drain Life", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Drain Life");
		}

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
		[Fact(Skip = "ignore")]
		public void ShadowBolt_VAN_CS2_057()
		{
			// TODO ShadowBolt_VAN_CS2_057 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shadow Bolt", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shadow Bolt");
		}

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
		[Fact(Skip = "ignore")]
		public void Shadowflame_VAN_EX1_303()
		{
			// TODO Shadowflame_VAN_EX1_303 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shadowflame", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shadowflame");
		}

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
		[Fact(Skip = "ignore")]
		public void Soulfire_VAN_EX1_308()
		{
			// TODO Soulfire_VAN_EX1_308 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Soulfire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Soulfire");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_EX1_596] Demonfire - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Deal $2 damage to a minion. If it’s a friendly Demon, give it +2/+2 instead. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1142
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Demonfire_VAN_EX1_596()
		{
			// TODO Demonfire_VAN_EX1_596 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Demonfire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Demonfire");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_EX1_312] Twisting Nether - COST:8 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Destroy all minions.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 859
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void TwistingNether_VAN_EX1_312()
		{
			// TODO TwistingNether_VAN_EX1_312 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Twisting Nether", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Twisting Nether");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_CS2_063] Corruption - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Choose an enemy minion. At the start of your turn, destroy it.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 982
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Corruption_VAN_CS2_063()
		{
			// TODO Corruption_VAN_CS2_063 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Corruption", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Corruption");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_EX1_320] Bane of Doom - COST:5 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Deal $2 damage to_a character. If that kills it, summon a random Demon. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 23
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BaneOfDoom_VAN_EX1_320()
		{
			// TODO BaneOfDoom_VAN_EX1_320 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bane of Doom", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Bane of Doom");
		}

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
		[Fact(Skip = "ignore")]
		public void SenseDemons_VAN_EX1_317()
		{
			// TODO SenseDemons_VAN_EX1_317 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sense Demons", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Sense Demons");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_EX1_309] Siphon Soul - COST:6 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Destroy a minion. Restore #3 Health to_your hero.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1100
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void SiphonSoul_VAN_EX1_309()
		{
			// TODO SiphonSoul_VAN_EX1_309 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Siphon Soul", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Siphon Soul");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_EX1_316] Power Overwhelming - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Give a friendly minion +4/+4 until end of turn. Then, it dies. Horribly.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 846
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void PowerOverwhelming_VAN_EX1_316()
		{
			// TODO PowerOverwhelming_VAN_EX1_316 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Power Overwhelming", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Power Overwhelming");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_NEW1_003] Sacrificial Pact - COST:0 
		// - Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Destroy a Demon. Restore #5 Health to your hero.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 163
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void SacrificialPact_VAN_NEW1_003()
		{
			// TODO SacrificialPact_VAN_NEW1_003 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sacrificial Pact", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Sacrificial Pact");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_EX1_302] Mortal Coil - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $1 damage to a minion. If that kills it, draw a card. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1092
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MortalCoil_VAN_EX1_302()
		{
			// TODO MortalCoil_VAN_EX1_302 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mortal Coil", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mortal Coil");
		}

		// ---------------------------------------- SPELL - WARLOCK
		// [VAN_CS2_062] Hellfire - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $3 damage to ALL_characters. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 950
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Hellfire_VAN_CS2_062()
		{
			// TODO Hellfire_VAN_CS2_062 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARLOCK,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Hellfire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARLOCK,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Hellfire");
		}

	}

	public class WarriorVanillaTest
	{
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
		[Fact(Skip = "ignore")]
		public void GrommashHellscream_VAN_EX1_414()
		{
			// TODO GrommashHellscream_VAN_EX1_414 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Grommash Hellscream", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Grommash Hellscream");
		}

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
		[Fact]
		public void WarsongCommander_VAN_EX1_084()
		{
			// TODO WarsongCommander_VAN_EX1_084 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Warsong Commander", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			Minion testCard = game.ProcessCard<Minion>("Warsong Commander");

			MinionInPlay m1 = game.ProcessCard<MinionInPlay>("Wisp");
			Assert.True(m1.HasCharge);

			MinionInPlay m2 = game.ProcessCard<MinionInPlay>("Chillwind Yeti");
			Assert.False(m2.HasCharge);
		}

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
		[Fact(Skip = "ignore")]
		public void CruelTaskmaster_VAN_EX1_603()
		{
			// TODO CruelTaskmaster_VAN_EX1_603 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cruel Taskmaster", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Cruel Taskmaster");
		}

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
		[Fact(Skip = "ignore")]
		public void KorkronElite_VAN_NEW1_011()
		{
			// TODO KorkronElite_VAN_NEW1_011 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Kor'kron Elite", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Kor'kron Elite");
		}

		// --------------------------------------- MINION - WARRIOR
		// [VAN_EX1_604] Frothing Berserker - COST:3 [ATK:2/HP:4] 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Whenever a minion takes damage, gain +1 Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 654
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void FrothingBerserker_VAN_EX1_604()
		{
			// TODO FrothingBerserker_VAN_EX1_604 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Frothing Berserker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Frothing Berserker");
		}

		// --------------------------------------- MINION - WARRIOR
		// [VAN_EX1_402] Armorsmith - COST:2 [ATK:1/HP:4] 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Whenever a friendly minion_takes damage, gain 1 Armor.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 596
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Armorsmith_VAN_EX1_402()
		{
			// TODO Armorsmith_VAN_EX1_402 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Armorsmith", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Armorsmith");
		}

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
		[Fact(Skip = "ignore")]
		public void ArathiWeaponsmith_VAN_EX1_398()
		{
			// TODO ArathiWeaponsmith_VAN_EX1_398 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Arathi Weaponsmith", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Arathi Weaponsmith");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_CS2_108] Execute - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Destroy a damaged enemy minion.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 785
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Execute_VAN_CS2_108()
		{
			// TODO Execute_VAN_CS2_108 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Execute", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Execute");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_NEW1_036] Commanding Shout - COST:2 
		// - Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Your minions can't be reduced below 1 Health this turn. Draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1026
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void CommandingShout_VAN_NEW1_036()
		{
			// TODO CommandingShout_VAN_NEW1_036 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Commanding Shout", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Commanding Shout");
		}

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
		[Fact(Skip = "ignore")]
		public void ShieldSlam_VAN_EX1_410()
		{
			// TODO ShieldSlam_VAN_EX1_410 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shield Slam", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shield Slam");
		}

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
		[Fact(Skip = "ignore")]
		public void ShieldBlock_VAN_EX1_606()
		{
			// TODO ShieldBlock_VAN_EX1_606 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shield Block", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Shield Block");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_CS2_105] Heroic Strike - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Give your hero +4_Attack this turn.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1007
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void HeroicStrike_VAN_CS2_105()
		{
			// TODO HeroicStrike_VAN_CS2_105 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Heroic Strike", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Heroic Strike");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_EX1_408] Mortal Strike - COST:4 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Deal $4 damage. If you have 12 or less Health, deal $6 instead. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 804
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MortalStrike_VAN_EX1_408()
		{
			// TODO MortalStrike_VAN_EX1_408 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mortal Strike", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Mortal Strike");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_EX1_400] Whirlwind - COST:1 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Deal $1 damage to ALL_minions. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 636
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Whirlwind_VAN_EX1_400()
		{
			// TODO Whirlwind_VAN_EX1_400 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Whirlwind", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Whirlwind");
		}

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
		[Fact]
		public void Charge_VAN_CS2_103()
		{
			// TODO Charge_VAN_CS2_103 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Charge", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;

			MinionInPlay m = game.ProcessCard<MinionInPlay>("Wisp");
			Spell testCard = game.ProcessCard<Spell>("Charge", m);

			Assert.Equal(m.Card.ATK + 2, m.AttackDamage);
			Assert.True(m.HasCharge);

			m.Attack(game.CurrentOpponent.Hero);
			Assert.Equal(m.AttackDamage, game.CurrentOpponent.Hero.Damage);
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_CS2_104] Rampage - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Give a damaged minion +3/+3.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1108
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Rampage_VAN_CS2_104()
		{
			// TODO Rampage_VAN_CS2_104 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Rampage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Rampage");
		}

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
		[Fact(Skip = "ignore")]
		public void Cleave_VAN_CS2_114()
		{
			// TODO Cleave_VAN_CS2_114 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cleave", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Cleave");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_EX1_392] Battle Rage - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Draw a card for each damaged friendly character.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 400
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BattleRage_VAN_EX1_392()
		{
			// TODO BattleRage_VAN_EX1_392 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Battle Rage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Battle Rage");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_EX1_391] Slam - COST:2 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Deal $2 damage to a minion. If it survives, draw a card. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1074
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Slam_VAN_EX1_391()
		{
			// TODO Slam_VAN_EX1_391 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Slam", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Slam");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_EX1_407] Brawl - COST:5 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Destroy all minions except one. <i>(chosen randomly)</i>
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 75
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Brawl_VAN_EX1_407()
		{
			// TODO Brawl_VAN_EX1_407 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Brawl", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Brawl");
		}

		// ---------------------------------------- SPELL - WARRIOR
		// [VAN_EX1_607] Inner Rage - COST:0 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Deal $1 damage to a minion and give it +2_Attack. @spelldmg
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 22
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void InnerRage_VAN_EX1_607()
		{
			// TODO InnerRage_VAN_EX1_607 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Inner Rage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Inner Rage");
		}

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
		[Fact(Skip = "ignore")]
		public void Upgrade_VAN_EX1_409()
		{
			// TODO Upgrade_VAN_EX1_409 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Upgrade!", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Spell testCard = game.ProcessCard<Spell>("Upgrade!");
		}

		// --------------------------------------- WEAPON - WARRIOR
		// [VAN_CS2_106] Fiery War Axe - COST:2 [ATK:3/HP:0] 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - DURABILITY = 2
		// - 858 = 401
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void FieryWarAxe_VAN_CS2_106()
		{
			// TODO FieryWarAxe_VAN_CS2_106 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Fiery War Axe", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Fiery War Axe");
		}

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
		[Fact(Skip = "ignore")]
		public void Gorehowl_VAN_EX1_411()
		{
			// TODO Gorehowl_VAN_EX1_411 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Gorehowl", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Gorehowl");
		}

		// --------------------------------------- WEAPON - WARRIOR
		// [VAN_CS2_112] Arcanite Reaper - COST:5 [ATK:5/HP:0] 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - DURABILITY = 2
		// - 858 = 304
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ArcaniteReaper_VAN_CS2_112()
		{
			// TODO ArcaniteReaper_VAN_CS2_112 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.WARRIOR,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Arcanite Reaper", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.WARRIOR,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Weapon testCard = game.ProcessCard<Weapon>("Arcanite Reaper");
		}

	}

	public class NeutralVanillaTest
	{
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
		[Fact(Skip = "ignore")]
		public void AncientBrewmaster_VAN_EX1_057()
		{
			// TODO AncientBrewmaster_VAN_EX1_057 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ancient Brewmaster", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ancient Brewmaster");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_tt_004] Flesheating Ghoul - COST:3 [ATK:2/HP:3] 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Whenever a minion dies, gain +1 Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 397
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void FlesheatingGhoul_VAN_tt_004()
		{
			// TODO FlesheatingGhoul_VAN_tt_004 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Flesheating Ghoul", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Flesheating Ghoul");
		}

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
		[Fact(Skip = "ignore")]
		public void EmperorCobra_VAN_EX1_170()
		{
			// TODO EmperorCobra_VAN_EX1_170 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Emperor Cobra", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Emperor Cobra");
		}

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
		[Fact(Skip = "ignore")]
		public void ElvenArcher_VAN_CS2_189()
		{
			// TODO ElvenArcher_VAN_CS2_189 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Elven Archer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Elven Archer");
		}

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
		[Fact]
		public void ColdlightSeer_VAN_EX1_103()
		{
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Coldlight Seer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;

			MinionInPlay m1 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			MinionInPlay m2 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			game.EndTurn();

			MinionInPlay m3 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			MinionInPlay testCard = game.ProcessCard<MinionInPlay>("Coldlight Seer");

			foreach (var m in new[] {m1, m2, m3})
			{
				Assert.Equal(m.Card.Health + 2, m.Health);
			}
		}

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
		[Fact(Skip = "ignore")]
		public void BloodmageThalnos_VAN_EX1_012()
		{
			// TODO BloodmageThalnos_VAN_EX1_012 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bloodmage Thalnos", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Bloodmage Thalnos");
		}

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
		[Fact(Skip = "ignore")]
		public void ThrallmarFarseer_VAN_EX1_021()
		{
			// TODO ThrallmarFarseer_VAN_EX1_021 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Thrallmar Farseer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Thrallmar Farseer");
		}

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
		[Fact(Skip = "ignore")]
		public void ImpMaster_VAN_EX1_597()
		{
			// TODO ImpMaster_VAN_EX1_597 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Imp Master", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Imp Master");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_620] Molten Giant - COST:20 [ATK:8/HP:8] 
		// - Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Costs (1) less for each damage your hero has taken.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1372
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MoltenGiant_VAN_EX1_620()
		{
			// TODO MoltenGiant_VAN_EX1_620 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Molten Giant", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Molten Giant");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_118] Magma Rager - COST:3 [ATK:5/HP:1] 
		// - Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1653
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MagmaRager_VAN_CS2_118()
		{
			// TODO MagmaRager_VAN_CS2_118 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Magma Rager", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Magma Rager");
		}

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
		[Fact(Skip = "ignore")]
		public void Gruul_VAN_NEW1_038()
		{
			// TODO Gruul_VAN_NEW1_038 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Gruul", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Gruul");
		}

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
		[Fact(Skip = "ignore")]
		public void HarrisonJones_VAN_EX1_558()
		{
			// TODO HarrisonJones_VAN_EX1_558 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Harrison Jones", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Harrison Jones");
		}

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
		[Fact(Skip = "ignore")]
		public void FrostwolfWarlord_VAN_CS2_226()
		{
			// TODO FrostwolfWarlord_VAN_CS2_226 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Frostwolf Warlord", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Frostwolf Warlord");
		}

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
		[Fact(Skip = "ignore")]
		public void NoviceEngineer_VAN_EX1_015()
		{
			// TODO NoviceEngineer_VAN_EX1_015 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Novice Engineer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Novice Engineer");
		}

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
		[Fact(Skip = "ignore")]
		public void AzureDrake_VAN_EX1_284()
		{
			// TODO AzureDrake_VAN_EX1_284 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Azure Drake", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Azure Drake");
		}

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
		[Fact(Skip = "ignore")]
		public void OldMurkEye_VAN_EX1_062()
		{
			// TODO OldMurkEye_VAN_EX1_062 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Old Murk-Eye", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Old Murk-Eye");
		}

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
		[Fact(Skip = "ignore")]
		public void IllidanStormrage_VAN_EX1_614()
		{
			// TODO IllidanStormrage_VAN_EX1_614 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Illidan Stormrage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Illidan Stormrage");
		}

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
		[Fact(Skip = "ignore")]
		public void GnomishInventor_VAN_CS2_147()
		{
			// TODO GnomishInventor_VAN_CS2_147 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Gnomish Inventor", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Gnomish Inventor");
		}

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
		[Fact(Skip = "ignore")]
		public void SunfuryProtector_VAN_EX1_058()
		{
			// TODO SunfuryProtector_VAN_EX1_058 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sunfury Protector", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Sunfury Protector");
		}

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
		[Fact(Skip = "ignore")]
		public void Archmage_VAN_CS2_155()
		{
			// TODO Archmage_VAN_CS2_155 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Archmage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Archmage");
		}

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
		[Fact(Skip = "ignore")]
		public void FacelessManipulator_VAN_EX1_564()
		{
			// TODO FacelessManipulator_VAN_EX1_564 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Faceless Manipulator", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Faceless Manipulator");
		}

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
		[Fact(Skip = "ignore")]
		public void NatPagle_VAN_EX1_557()
		{
			// TODO NatPagle_VAN_EX1_557 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Nat Pagle", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Nat Pagle");
		}

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
		[Fact(Skip = "ignore")]
		public void FrostwolfGrunt_VAN_CS2_121()
		{
			// TODO FrostwolfGrunt_VAN_CS2_121 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Frostwolf Grunt", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Frostwolf Grunt");
		}

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
		[Fact(Skip = "ignore")]
		public void StranglethornTiger_VAN_EX1_028()
		{
			// TODO StranglethornTiger_VAN_EX1_028 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Stranglethorn Tiger", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Stranglethorn Tiger");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_172] Bloodfen Raptor - COST:2 [ATK:3/HP:2] 
		// - Race: beast, Fac: horde, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 216
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BloodfenRaptor_VAN_CS2_172()
		{
			// TODO BloodfenRaptor_VAN_CS2_172 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bloodfen Raptor", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Bloodfen Raptor");
		}

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
		[Fact(Skip = "ignore")]
		public void StormpikeCommando_VAN_CS2_150()
		{
			// TODO StormpikeCommando_VAN_CS2_150 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Stormpike Commando", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Stormpike Commando");
		}

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
		[Fact(Skip = "ignore")]
		public void BloodKnight_VAN_EX1_590()
		{
			// TODO BloodKnight_VAN_EX1_590 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Blood Knight", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Blood Knight");
		}

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
		[Fact(Skip = "ignore")]
		public void AlarmOBot_VAN_EX1_006()
		{
			// TODO AlarmOBot_VAN_EX1_006 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Alarm-o-Bot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Alarm-o-Bot");
		}

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
		[Fact(Skip = "ignore")]
		public void EarthenRingFarseer_VAN_CS2_117()
		{
			// TODO EarthenRingFarseer_VAN_CS2_117 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Earthen Ring Farseer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Earthen Ring Farseer");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_055] Mana Addict - COST:2 [ATK:1/HP:3] 
		// - Fac: alliance, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Whenever you cast a spell, gain +2 Attack this turn.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 12
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ManaAddict_VAN_EX1_055()
		{
			// TODO ManaAddict_VAN_EX1_055 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mana Addict", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Mana Addict");
		}

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
		[Fact(Skip = "ignore")]
		public void Onyxia_VAN_EX1_562()
		{
			// TODO Onyxia_VAN_EX1_562 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Onyxia", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Onyxia");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_186] War Golem - COST:7 [ATK:7/HP:7] 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 712
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void WarGolem_VAN_CS2_186()
		{
			// TODO WarGolem_VAN_CS2_186 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("War Golem", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("War Golem");
		}

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
		[Fact(Skip = "ignore")]
		public void OgreMagi_VAN_CS2_197()
		{
			// TODO OgreMagi_VAN_CS2_197 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ogre Magi", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ogre Magi");
		}

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
		[Fact(Skip = "ignore")]
		public void KnifeJuggler_VAN_NEW1_019()
		{
			// TODO KnifeJuggler_VAN_NEW1_019 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Knife Juggler", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Knife Juggler");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_105] Mountain Giant - COST:12 [ATK:8/HP:8] 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Costs (1) less for each other card in your hand.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 993
		// --------------------------------------------------------
		[Fact]
		public void MountainGiant_VAN_EX1_105()
		{
			// TODO MountainGiant_VAN_EX1_105 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mountain Giant", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;

			Minion testCard = game.ProcessCard<Minion>("Mountain Giant");
			Assert.Null(testCard.OngoingEffect);
		}

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
		[Fact(Skip = "ignore")]
		public void CaptainsParrot_VAN_NEW1_016()
		{
			// TODO CaptainsParrot_VAN_NEW1_016 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Captain's Parrot", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Captain's Parrot");
		}

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
		[Fact(Skip = "ignore")]
		public void SpitefulSmith_VAN_CS2_221()
		{
			// TODO SpitefulSmith_VAN_CS2_221 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Spiteful Smith", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Spiteful Smith");
		}

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
		[Fact(Skip = "ignore")]
		public void WorgenInfiltrator_VAN_EX1_010()
		{
			// TODO WorgenInfiltrator_VAN_EX1_010 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Worgen Infiltrator", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Worgen Infiltrator");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_595] Cult Master - COST:4 [ATK:4/HP:2] 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: After a friendly minion dies, draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 811
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void CultMaster_VAN_EX1_595()
		{
			// TODO CultMaster_VAN_EX1_595 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cult Master", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Cult Master");
		}

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
		[Fact(Skip = "ignore")]
		public void BloodsailRaider_VAN_NEW1_018()
		{
			// TODO BloodsailRaider_VAN_NEW1_018 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bloodsail Raider", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Bloodsail Raider");
		}

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
		[Fact(Skip = "ignore")]
		public void ArgentCommander_VAN_EX1_067()
		{
			// TODO ArgentCommander_VAN_EX1_067 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Argent Commander", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Argent Commander");
		}

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
		[Fact(Skip = "ignore")]
		public void IronbeakOwl_VAN_CS2_203()
		{
			// TODO IronbeakOwl_VAN_CS2_203 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ironbeak Owl", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ironbeak Owl");
		}

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
		[Fact(Skip = "ignore")]
		public void Sunwalker_VAN_EX1_032()
		{
			// TODO Sunwalker_VAN_EX1_032 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sunwalker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Sunwalker");
		}

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
		[Fact(Skip = "ignore")]
		public void BaronGeddon_VAN_EX1_249()
		{
			// TODO BaronGeddon_VAN_EX1_249 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Baron Geddon", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Baron Geddon");
		}

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
		[Fact(Skip = "ignore")]
		public void YoungDragonhawk_VAN_CS2_169()
		{
			// TODO YoungDragonhawk_VAN_CS2_169 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Young Dragonhawk", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Young Dragonhawk");
		}

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
		[Fact(Skip = "ignore")]
		public void MindControlTech_VAN_EX1_085()
		{
			// TODO MindControlTech_VAN_EX1_085 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mind Control Tech", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Mind Control Tech");
		}

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
		[Fact(Skip = "ignore")]
		public void SouthseaCaptain_VAN_NEW1_027()
		{
			// TODO SouthseaCaptain_VAN_NEW1_027 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Southsea Captain", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Southsea Captain");
		}

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
		[Fact]
		public void MurlocWarleader_VAN_EX1_507()
		{
			// TODO MurlocWarleader_VAN_EX1_507 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Murloc Warleader", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			Minion testCard = game.ProcessCard<Minion>("Murloc Warleader");
			Assert.Equal(testCard.Card.ATK, testCard.AttackDamage);
			Assert.Equal(testCard.Card.Health, testCard.Health);

			MinionInPlay m1 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			Assert.Equal(m1.Card.ATK + 2, m1.AttackDamage);
			Assert.Equal(m1.Card.Health + 1, m1.Health);

			game.EndTurn();
			MinionInPlay m2 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			Assert.Equal(m2.Card.ATK + 2, m2.AttackDamage);
			Assert.Equal(m2.Card.Health + 1, m2.Health);
		}

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
		[Fact(Skip = "ignore")]
		public void AbusiveSergeant_VAN_CS2_188()
		{
			// TODO AbusiveSergeant_VAN_CS2_188 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Abusive Sergeant", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Abusive Sergeant");
		}

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
		[Fact(Skip = "ignore")]
		public void MillhouseManastorm_VAN_NEW1_029()
		{
			// TODO MillhouseManastorm_VAN_NEW1_029 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Millhouse Manastorm", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Millhouse Manastorm");
		}

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
		[Fact(Skip = "ignore")]
		public void LorewalkerCho_VAN_EX1_100()
		{
			// TODO LorewalkerCho_VAN_EX1_100 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lorewalker Cho", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Lorewalker Cho");
		}

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
		[Fact(Skip = "ignore")]
		public void VioletTeacher_VAN_NEW1_026()
		{
			// TODO VioletTeacher_VAN_NEW1_026 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Violet Teacher", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Violet Teacher");
		}

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
		[Fact(Skip = "ignore")]
		public void RecklessRocketeer_VAN_CS2_213()
		{
			// TODO RecklessRocketeer_VAN_CS2_213 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Reckless Rocketeer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Reckless Rocketeer");
		}

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
		[Fact(Skip = "ignore")]
		public void ScarletCrusader_VAN_EX1_020()
		{
			// TODO ScarletCrusader_VAN_EX1_020 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Scarlet Crusader", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Scarlet Crusader");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_119] Oasis Snapjaw - COST:4 [ATK:2/HP:7] 
		// - Race: beast, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1370
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void OasisSnapjaw_VAN_CS2_119()
		{
			// TODO OasisSnapjaw_VAN_CS2_119 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Oasis Snapjaw", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Oasis Snapjaw");
		}

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
		[Fact(Skip = "ignore")]
		public void FaerieDragon_VAN_NEW1_023()
		{
			// TODO FaerieDragon_VAN_NEW1_023 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Faerie Dragon", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Faerie Dragon");
		}

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
		[Fact(Skip = "ignore")]
		public void ManaWraith_VAN_EX1_616()
		{
			// TODO ManaWraith_VAN_EX1_616 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mana Wraith", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Mana Wraith");
		}

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
		[Fact(Skip = "ignore")]
		public void FenCreeper_VAN_CS1_069()
		{
			// TODO FenCreeper_VAN_CS1_069 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Fen Creeper", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Fen Creeper");
		}

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
		[Fact(Skip = "ignore")]
		public void MadBomber_VAN_EX1_082()
		{
			// TODO MadBomber_VAN_EX1_082 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mad Bomber", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Mad Bomber");
		}

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
		[Fact(Skip = "ignore")]
		public void VentureCoMercenary_VAN_CS2_227()
		{
			// TODO VentureCoMercenary_VAN_CS2_227 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Venture Co. Mercenary", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Venture Co. Mercenary");
		}

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
		[Fact(Skip = "ignore")]
		public void DragonlingMechanic_VAN_EX1_025()
		{
			// TODO DragonlingMechanic_VAN_EX1_025 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dragonling Mechanic", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Dragonling Mechanic");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_112] Gelbin Mekkatorque - COST:6 [ATK:6/HP:6] 
		// - Fac: alliance, Set: vanilla, Rarity: legendary
		// --------------------------------------------------------
		// Text: <b>Battlecry:</b> Summon an AWESOME invention.
		// --------------------------------------------------------
		// Entourage: Mekka1, Mekka2, Mekka3, Mekka4
		// --------------------------------------------------------
		// GameTag:
		// - ELITE = 1
		// - BATTLECRY = 1
		// - 858 = 858
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void GelbinMekkatorque_VAN_EX1_112()
		{
			// TODO GelbinMekkatorque_VAN_EX1_112 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Gelbin Mekkatorque", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Gelbin Mekkatorque");
		}

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
		[Fact(Skip = "ignore")]
		public void Shieldbearer_VAN_EX1_405()
		{
			// TODO Shieldbearer_VAN_EX1_405 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shieldbearer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Shieldbearer");
		}

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
		[Fact(Skip = "ignore")]
		public void SouthseaDeckhand_VAN_CS2_146()
		{
			// TODO SouthseaDeckhand_VAN_CS2_146 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Southsea Deckhand", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Southsea Deckhand");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_509] Murloc Tidecaller - COST:1 [ATK:1/HP:2] 
		// - Race: murloc, Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Whenever a Murloc is summoned, gain +1 Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 475
		// --------------------------------------------------------
		[Fact]
		public void MurlocTidecaller_VAN_EX1_509()
		{
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Murloc Tidecaller", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			MinionInPlay testCard = game.ProcessCard<MinionInPlay>("Murloc Tidecaller");
			Assert.Equal(testCard.Card.ATK, testCard.AttackDamage);

			game.ProcessCard("Murloc Raider");
			Assert.Equal(testCard.Card.ATK + 1, testCard.AttackDamage);

			game.ProcessCard("Murloc Raider");
			Assert.Equal(testCard.Card.ATK + 2, testCard.AttackDamage);

			game.EndTurn();
			game.ProcessCard("Murloc Raider");
			Assert.Equal(testCard.Card.ATK + 3, testCard.AttackDamage);
		}

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
		[Fact(Skip = "ignore")]
		public void GoldshireFootman_VAN_CS1_042()
		{
			// TODO GoldshireFootman_VAN_CS1_042 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Goldshire Footman", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Goldshire Footman");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_044] Questing Adventurer - COST:3 [ATK:2/HP:2] 
		// - Fac: alliance, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Whenever you play a card, gain +1/+1.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 791
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void QuestingAdventurer_VAN_EX1_044()
		{
			// TODO QuestingAdventurer_VAN_EX1_044 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Questing Adventurer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Questing Adventurer");
		}

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
		[Fact(Skip = "ignore")]
		public void RavenholdtAssassin_VAN_CS2_161()
		{
			// TODO RavenholdtAssassin_VAN_CS2_161 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ravenholdt Assassin", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ravenholdt Assassin");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_095] Gadgetzan Auctioneer - COST:5 [ATK:4/HP:4] 
		// - Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Whenever you cast a spell, draw a card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 932
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void GadgetzanAuctioneer_VAN_EX1_095()
		{
			// TODO GadgetzanAuctioneer_VAN_EX1_095 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Gadgetzan Auctioneer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Gadgetzan Auctioneer");
		}

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
		[Fact(Skip = "ignore")]
		public void HarvestGolem_VAN_EX1_556()
		{
			// TODO HarvestGolem_VAN_EX1_556 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Harvest Golem", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Harvest Golem");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_120] River Crocolisk - COST:2 [ATK:2/HP:3] 
		// - Race: beast, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1369
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void RiverCrocolisk_VAN_CS2_120()
		{
			// TODO RiverCrocolisk_VAN_CS2_120 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("River Crocolisk", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("River Crocolisk");
		}

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
		[Fact(Skip = "ignore")]
		public void ArgentSquire_VAN_EX1_008()
		{
			// TODO ArgentSquire_VAN_EX1_008 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Argent Squire", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Argent Squire");
		}

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
		[Fact(Skip = "ignore")]
		public void YouthfulBrewmaster_VAN_EX1_049()
		{
			// TODO YouthfulBrewmaster_VAN_EX1_049 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Youthful Brewmaster", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Youthful Brewmaster");
		}

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
		[Fact(Skip = "ignore")]
		public void StampedingKodo_VAN_NEW1_041()
		{
			// TODO StampedingKodo_VAN_NEW1_041 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Stampeding Kodo", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Stampeding Kodo");
		}

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
		[Fact(Skip = "ignore")]
		public void SilverHandKnight_VAN_CS2_151()
		{
			// TODO SilverHandKnight_VAN_CS2_151 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Silver Hand Knight", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Silver Hand Knight");
		}

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
		[Fact(Skip = "ignore")]
		public void ArcaneGolem_VAN_EX1_089()
		{
			// TODO ArcaneGolem_VAN_EX1_089 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Arcane Golem", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Arcane Golem");
		}

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
		[Fact(Skip = "ignore")]
		public void Nozdormu_VAN_EX1_560()
		{
			// TODO Nozdormu_VAN_EX1_560 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Nozdormu", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Nozdormu");
		}

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
		[Fact(Skip = "ignore")]
		public void Nightblade_VAN_EX1_593()
		{
			// TODO Nightblade_VAN_EX1_593 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Nightblade", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Nightblade");
		}

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
		[Fact(Skip = "ignore")]
		public void BigGameHunter_VAN_EX1_005()
		{
			// TODO BigGameHunter_VAN_EX1_005 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Big Game Hunter", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Big Game Hunter");
		}

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
		[Fact(Skip = "ignore")]
		public void DalaranMage_VAN_EX1_582()
		{
			// TODO DalaranMage_VAN_EX1_582 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dalaran Mage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Dalaran Mage");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_231] Wisp - COST:0 [ATK:1/HP:1] 
		// - Fac: neutral, Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 179
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Wisp_VAN_CS2_231()
		{
			// TODO Wisp_VAN_CS2_231 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Wisp", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Wisp");
		}

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
		[Fact(Skip = "ignore")]
		public void TheBlackKnight_VAN_EX1_002()
		{
			// TODO TheBlackKnight_VAN_EX1_002 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("The Black Knight", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("The Black Knight");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_200] Boulderfist Ogre - COST:6 [ATK:6/HP:7] 
		// - Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1686
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void BoulderfistOgre_VAN_CS2_200()
		{
			// TODO BoulderfistOgre_VAN_CS2_200 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Boulderfist Ogre", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Boulderfist Ogre");
		}

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
		[Fact(Skip = "ignore")]
		public void WindfuryHarpy_VAN_EX1_033()
		{
			// TODO WindfuryHarpy_VAN_EX1_033 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Windfury Harpy", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Windfury Harpy");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_168] Murloc Raider - COST:1 [ATK:2/HP:1] 
		// - Race: murloc, Fac: alliance, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 191
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MurlocRaider_VAN_CS2_168()
		{
			// TODO MurlocRaider_VAN_CS2_168 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Murloc Raider", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Murloc Raider");
		}

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
		[Fact(Skip = "ignore")]
		public void SilvermoonGuardian_VAN_EX1_023()
		{
			// TODO SilvermoonGuardian_VAN_EX1_023 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Silvermoon Guardian", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Silvermoon Guardian");
		}

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
		[Fact(Skip = "ignore")]
		public void AncientMage_VAN_EX1_584()
		{
			// TODO AncientMage_VAN_EX1_584 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ancient Mage", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ancient Mage");
		}

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
		[Fact(Skip = "ignore")]
		public void CairneBloodhoof_VAN_EX1_110()
		{
			// TODO CairneBloodhoof_VAN_EX1_110 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Cairne Bloodhoof", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Cairne Bloodhoof");
		}

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
		[Fact(Skip = "ignore")]
		public void ColdlightOracle_VAN_EX1_050()
		{
			// TODO ColdlightOracle_VAN_EX1_050 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Coldlight Oracle", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Coldlight Oracle");
		}

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
		[Fact(Skip = "ignore")]
		public void DireWolfAlpha_VAN_EX1_162()
		{
			// TODO DireWolfAlpha_VAN_EX1_162 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dire Wolf Alpha", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Dire Wolf Alpha");
		}

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
		[Fact(Skip = "ignore")]
		public void IronfurGrizzly_VAN_CS2_125()
		{
			// TODO IronfurGrizzly_VAN_CS2_125 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ironfur Grizzly", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ironfur Grizzly");
		}

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
		[Fact(Skip = "ignore")]
		public void DarkIronDwarf_VAN_EX1_046()
		{
			// TODO DarkIronDwarf_VAN_EX1_046 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dark Iron Dwarf", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Dark Iron Dwarf");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_399] Gurubashi Berserker - COST:5 [ATK:2/HP:7] 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// Text: Whenever this minion takes damage, gain +3_Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 768
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void GurubashiBerserker_VAN_EX1_399()
		{
			// TODO GurubashiBerserker_VAN_EX1_399 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Gurubashi Berserker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Gurubashi Berserker");
		}

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
		[Fact(Skip = "ignore")]
		public void DarkscaleHealer_VAN_DS1_055()
		{
			// TODO DarkscaleHealer_VAN_DS1_055 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Darkscale Healer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Darkscale Healer");
		}

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
		[Fact(Skip = "ignore")]
		public void BloodsailCorsair_VAN_NEW1_025()
		{
			// TODO BloodsailCorsair_VAN_NEW1_025 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bloodsail Corsair", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Bloodsail Corsair");
		}

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
		[Fact(Skip = "ignore")]
		public void DefenderOfArgus_VAN_EX1_093()
		{
			// TODO DefenderOfArgus_VAN_EX1_093 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Defender of Argus", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Defender of Argus");
		}

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
		[Fact(Skip = "ignore")]
		public void RaidLeader_VAN_CS2_122()
		{
			// TODO RaidLeader_VAN_CS2_122 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Raid Leader", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Raid Leader");
		}

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
		[Fact(Skip = "ignore")]
		public void DreadCorsair_VAN_NEW1_022()
		{
			// TODO DreadCorsair_VAN_NEW1_022 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Dread Corsair", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Dread Corsair");
		}

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
		[Fact(Skip = "ignore")]
		public void CaptainGreenskin_VAN_NEW1_024()
		{
			// TODO CaptainGreenskin_VAN_NEW1_024 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Captain Greenskin", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Captain Greenskin");
		}

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
		[Fact(Skip = "ignore")]
		public void FrostElemental_VAN_EX1_283()
		{
			// TODO FrostElemental_VAN_EX1_283 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Frost Elemental", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Frost Elemental");
		}

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
		[Fact(Skip = "ignore")]
		public void SylvanasWindrunner_VAN_EX1_016()
		{
			// TODO SylvanasWindrunner_VAN_EX1_016 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sylvanas Windrunner", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Sylvanas Windrunner");
		}

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
		[Fact(Skip = "ignore")]
		public void Doomsayer_VAN_NEW1_021()
		{
			// TODO Doomsayer_VAN_NEW1_021 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Doomsayer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Doomsayer");
		}

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
		[Fact(Skip = "ignore")]
		public void LootHoarder_VAN_EX1_096()
		{
			// TODO LootHoarder_VAN_EX1_096 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Loot Hoarder", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Loot Hoarder");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_007] Acolyte of Pain - COST:3 [ATK:1/HP:3] 
		// - Set: vanilla, Rarity: common
		// --------------------------------------------------------
		// Text: Whenever this minion takes damage, draw a_card.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1659
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void AcolyteOfPain_VAN_EX1_007()
		{
			// TODO AcolyteOfPain_VAN_EX1_007 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Acolyte of Pain", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Acolyte of Pain");
		}

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
		[Fact(Skip = "ignore")]
		public void Spellbreaker_VAN_EX1_048()
		{
			// TODO Spellbreaker_VAN_EX1_048 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Spellbreaker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Spellbreaker");
		}

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
		[Fact(Skip = "ignore")]
		public void ShatteredSunCleric_VAN_EX1_019()
		{
			// TODO ShatteredSunCleric_VAN_EX1_019 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Shattered Sun Cleric", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Shattered Sun Cleric");
		}

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
		[Fact(Skip = "ignore")]
		public void PintSizedSummoner_VAN_EX1_076()
		{
			// TODO PintSizedSummoner_VAN_EX1_076 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Pint-Sized Summoner", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Pint-Sized Summoner");
		}

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
		[Fact(Skip = "ignore")]
		public void CrazedAlchemist_VAN_EX1_059()
		{
			// TODO CrazedAlchemist_VAN_EX1_059 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Crazed Alchemist", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Crazed Alchemist");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_004] Young Priestess - COST:1 [ATK:2/HP:1] 
		// - Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: At the end of your turn, give another random friendly minion +1 Health.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1634
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void YoungPriestess_VAN_EX1_004()
		{
			// TODO YoungPriestess_VAN_EX1_004 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Young Priestess", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Young Priestess");
		}

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
		[Fact(Skip = "ignore")]
		public void PriestessOfElune_VAN_EX1_583()
		{
			// TODO PriestessOfElune_VAN_EX1_583 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Priestess of Elune", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Priestess of Elune");
		}

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
		[Fact(Skip = "ignore")]
		public void Deathwing_VAN_NEW1_030()
		{
			// TODO Deathwing_VAN_NEW1_030 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Deathwing", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Deathwing");
		}

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
		[Fact(Skip = "ignore")]
		public void RagnarosTheFirelord_VAN_EX1_298()
		{
			// TODO RagnarosTheFirelord_VAN_EX1_298 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ragnaros the Firelord", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ragnaros the Firelord");
		}

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
		[Fact(Skip = "ignore")]
		public void BluegillWarrior_VAN_CS2_173()
		{
			// TODO BluegillWarrior_VAN_CS2_173 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Bluegill Warrior", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Bluegill Warrior");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_NEW1_037] Master Swordsmith - COST:2 [ATK:1/HP:3] 
		// - Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: At the end of your turn, give another random friendly minion +1 Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 351
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void MasterSwordsmith_VAN_NEW1_037()
		{
			// TODO MasterSwordsmith_VAN_NEW1_037 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Master Swordsmith", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Master Swordsmith");
		}

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
		[Fact(Skip = "ignore")]
		public void MurlocTidehunter_VAN_EX1_506()
		{
			// TODO MurlocTidehunter_VAN_EX1_506 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Murloc Tidehunter", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Murloc Tidehunter");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_PRO_001] Elite Tauren Chieftain - COST:5 [ATK:5/HP:5] 
		// - Set: vanilla, Rarity: legendary
		// --------------------------------------------------------
		// Text: <b>Battlecry:</b> Give both players the power to ROCK! (with a Power Chord card)
		// --------------------------------------------------------
		// Entourage: PRO_001a, PRO_001b, PRO_001c
		// --------------------------------------------------------
		// GameTag:
		// - ELITE = 1
		// - BATTLECRY = 1
		// - 858 = 1754
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void EliteTaurenChieftain_VAN_PRO_001()
		{
			// TODO EliteTaurenChieftain_VAN_PRO_001 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Elite Tauren Chieftain", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Elite Tauren Chieftain");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_001] Lightwarden - COST:1 [ATK:1/HP:2] 
		// - Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: Whenever a character is healed, gain +2 Attack.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1655
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Lightwarden_VAN_EX1_001()
		{
			// TODO Lightwarden_VAN_EX1_001 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lightwarden", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Lightwarden");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_586] Sea Giant - COST:10 [ATK:8/HP:8] 
		// - Fac: neutral, Set: vanilla, Rarity: epic
		// --------------------------------------------------------
		// Text: Costs (1) less for each other minion on the battlefield.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 211
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void SeaGiant_VAN_EX1_586()
		{
			// TODO SeaGiant_VAN_EX1_586 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sea Giant", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Sea Giant");
		}

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
		[Fact(Skip = "ignore")]
		public void LeeroyJenkins_VAN_EX1_116()
		{
			// TODO LeeroyJenkins_VAN_EX1_116 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Leeroy Jenkins", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Leeroy Jenkins");
		}

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
		[Fact(Skip = "ignore")]
		public void Hogger_VAN_NEW1_040()
		{
			// TODO Hogger_VAN_NEW1_040 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Hogger", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Hogger");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_201] Core Hound - COST:7 [ATK:9/HP:5] 
		// - Race: beast, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1687
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void CoreHound_VAN_CS2_201()
		{
			// TODO CoreHound_VAN_CS2_201 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Core Hound", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Core Hound");
		}

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
		[Fact(Skip = "ignore")]
		public void TwilightDrake_VAN_EX1_043()
		{
			// TODO TwilightDrake_VAN_EX1_043 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Twilight Drake", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Twilight Drake");
		}

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
		[Fact(Skip = "ignore")]
		public void MogushanWarden_VAN_EX1_396()
		{
			// TODO MogushanWarden_VAN_EX1_396 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Mogu'shan Warden", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Mogu'shan Warden");
		}

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
		[Fact(Skip = "ignore")]
		public void TinkmasterOverspark_VAN_EX1_083()
		{
			// TODO TinkmasterOverspark_VAN_EX1_083 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Tinkmaster Overspark", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Tinkmaster Overspark");
		}

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
		[Fact(Skip = "ignore")]
		public void Malygos_VAN_EX1_563()
		{
			// TODO Malygos_VAN_EX1_563 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Malygos", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Malygos");
		}

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
		[Fact(Skip = "ignore")]
		public void SilverbackPatriarch_VAN_CS2_127()
		{
			// TODO SilverbackPatriarch_VAN_CS2_127 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Silverback Patriarch", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Silverback Patriarch");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_102] Demolisher - COST:3 [ATK:1/HP:4] 
		// - Race: mechanical, Fac: neutral, Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: At the start of your turn, deal 2 damage to a random enemy.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 979
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Demolisher_VAN_EX1_102()
		{
			// TODO Demolisher_VAN_EX1_102 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Demolisher", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Demolisher");
		}

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
		[Fact(Skip = "ignore")]
		public void StormwindChampion_VAN_CS2_222()
		{
			// TODO StormwindChampion_VAN_CS2_222 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Stormwind Champion", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Stormwind Champion");
		}

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
		[Fact(Skip = "ignore")]
		public void VoodooDoctor_VAN_EX1_011()
		{
			// TODO VoodooDoctor_VAN_EX1_011 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Voodoo Doctor", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Voodoo Doctor");
		}

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
		[Fact(Skip = "ignore")]
		public void SenjinShieldmasta_VAN_CS2_179()
		{
			// TODO SenjinShieldmasta_VAN_CS2_179 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Sen'jin Shieldmasta", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Sen'jin Shieldmasta");
		}

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
		[Fact(Skip = "ignore")]
		public void Secretkeeper_VAN_EX1_080()
		{
			// TODO Secretkeeper_VAN_EX1_080 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Secretkeeper", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Secretkeeper");
		}

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
		[Fact(Skip = "ignore")]
		public void AcidicSwampOoze_VAN_EX1_066()
		{
			// TODO AcidicSwampOoze_VAN_EX1_066 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Acidic Swamp Ooze", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Acidic Swamp Ooze");
		}

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
		[Fact]
		public void GrimscaleOracle_VAN_EX1_508()
		{
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Grimscale Oracle", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;

			MinionInPlay m1 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			MinionInPlay m2 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			game.EndTurn();

			MinionInPlay m3 = game.ProcessCard<MinionInPlay>("Murloc Raider");
			MinionInPlay testCard = game.ProcessCard<MinionInPlay>("Grimscale Oracle");

			Assert.Equal(m1.Card.ATK + 1, m1.AttackDamage);
			Assert.Equal(m2.Card.ATK + 1, m2.AttackDamage);
			Assert.Equal(m3.Card.ATK + 1, m3.AttackDamage);

			testCard.Silence();
			game.AuraUpdate();

			Assert.Equal(m1.Card.ATK, m1.AttackDamage);
			Assert.Equal(m2.Card.ATK, m2.AttackDamage);
			Assert.Equal(m3.Card.ATK, m3.AttackDamage);
		}

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
		[Fact(Skip = "ignore")]
		public void Wolfrider_VAN_CS2_124()
		{
			// TODO Wolfrider_VAN_CS2_124 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Wolfrider", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Wolfrider");
		}

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
		[Fact(Skip = "ignore")]
		public void AncientWatcher_VAN_EX1_045()
		{
			// TODO AncientWatcher_VAN_EX1_045 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ancient Watcher", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ancient Watcher");
		}

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
		[Fact(Skip = "ignore")]
		public void KingMukla_VAN_EX1_014()
		{
			// TODO KingMukla_VAN_EX1_014 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("King Mukla", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("King Mukla");
		}

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
		[Fact(Skip = "ignore")]
		public void LordOfTheArena_VAN_CS2_162()
		{
			// TODO LordOfTheArena_VAN_CS2_162 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Lord of the Arena", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Lord of the Arena");
		}

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
		[Fact(Skip = "ignore")]
		public void RagingWorgen_VAN_EX1_412()
		{
			// TODO RagingWorgen_VAN_EX1_412 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Raging Worgen", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Raging Worgen");
		}

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
		[Fact(Skip = "ignore")]
		public void AngryChicken_VAN_EX1_009()
		{
			// TODO AngryChicken_VAN_EX1_009 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Angry Chicken", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Angry Chicken");
		}

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
		[Fact(Skip = "ignore")]
		public void JunglePanther_VAN_EX1_017()
		{
			// TODO JunglePanther_VAN_EX1_017 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Jungle Panther", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Jungle Panther");
		}

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
		[Fact(Skip = "ignore")]
		public void IronforgeRifleman_VAN_CS2_141()
		{
			// TODO IronforgeRifleman_VAN_CS2_141 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ironforge Rifleman", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ironforge Rifleman");
		}

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
		[Fact(Skip = "ignore")]
		public void Abomination_VAN_EX1_097()
		{
			// TODO Abomination_VAN_EX1_097 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Abomination", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Abomination");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_EX1_572] Ysera - COST:9 [ATK:4/HP:12] 
		// - Race: dragon, Fac: neutral, Set: vanilla, Rarity: legendary
		// --------------------------------------------------------
		// Text: At the end of your turn, add_a Dream Card to_your hand.
		// --------------------------------------------------------
		// Entourage: DREAM_01, DREAM_02, DREAM_03, DREAM_04, DREAM_05
		// --------------------------------------------------------
		// GameTag:
		// - ELITE = 1
		// - 858 = 1186
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void Ysera_VAN_EX1_572()
		{
			// TODO Ysera_VAN_EX1_572 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Ysera", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Ysera");
		}

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
		[Fact(Skip = "ignore")]
		public void InjuredBlademaster_VAN_CS2_181()
		{
			// TODO InjuredBlademaster_VAN_CS2_181 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Injured Blademaster", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Injured Blademaster");
		}

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
		[Fact(Skip = "ignore")]
		public void StormwindKnight_VAN_CS2_131()
		{
			// TODO StormwindKnight_VAN_CS2_131 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Stormwind Knight", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Stormwind Knight");
		}

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
		[Fact(Skip = "ignore")]
		public void LeperGnome_VAN_EX1_029()
		{
			// TODO LeperGnome_VAN_EX1_029 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Leper Gnome", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Leper Gnome");
		}

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
		[Fact(Skip = "ignore")]
		public void AmaniBerserker_VAN_EX1_393()
		{
			// TODO AmaniBerserker_VAN_EX1_393 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Amani Berserker", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Amani Berserker");
		}

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
		[Fact(Skip = "ignore")]
		public void StonetuskBoar_VAN_CS2_171()
		{
			// TODO StonetuskBoar_VAN_CS2_171 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Stonetusk Boar", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Stonetusk Boar");
		}

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
		[Fact(Skip = "ignore")]
		public void HungryCrab_VAN_NEW1_017()
		{
			// TODO HungryCrab_VAN_NEW1_017 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Hungry Crab", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Hungry Crab");
		}

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
		[Fact(Skip = "ignore")]
		public void KoboldGeomancer_VAN_CS2_142()
		{
			// TODO KoboldGeomancer_VAN_CS2_142 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Kobold Geomancer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Kobold Geomancer");
		}

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
		[Fact(Skip = "ignore")]
		public void TheBeast_VAN_EX1_577()
		{
			// TODO TheBeast_VAN_EX1_577 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("The Beast", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("The Beast");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_CS2_182] Chillwind Yeti - COST:4 [ATK:4/HP:5] 
		// - Fac: neutral, Set: vanilla, Rarity: free
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 90
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void ChillwindYeti_VAN_CS2_182()
		{
			// TODO ChillwindYeti_VAN_CS2_182 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Chillwind Yeti", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Chillwind Yeti");
		}

		// --------------------------------------- MINION - NEUTRAL
		// [VAN_NEW1_020] Wild Pyromancer - COST:2 [ATK:3/HP:2] 
		// - Set: vanilla, Rarity: rare
		// --------------------------------------------------------
		// Text: After you cast a spell, deal 1 damage to ALL minions.
		// --------------------------------------------------------
		// GameTag:
		// - 858 = 1014
		// --------------------------------------------------------
		[Fact(Skip = "ignore")]
		public void WildPyromancer_VAN_NEW1_020()
		{
			// TODO WildPyromancer_VAN_NEW1_020 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Wild Pyromancer", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Wild Pyromancer");
		}

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
		[Fact(Skip = "ignore")]
		public void TaurenWarrior_VAN_EX1_390()
		{
			// TODO TaurenWarrior_VAN_EX1_390 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Tauren Warrior", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Tauren Warrior");
		}

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
		[Fact(Skip = "ignore")]
		public void Alexstrasza_VAN_EX1_561()
		{
			// TODO Alexstrasza_VAN_EX1_561 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Alexstrasza", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Alexstrasza");
		}

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
		[Fact(Skip = "ignore")]
		public void BootyBayBodyguard_VAN_CS2_187()
		{
			// TODO BootyBayBodyguard_VAN_CS2_187 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Booty Bay Bodyguard", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Booty Bay Bodyguard");
		}

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
		[Fact(Skip = "ignore")]
		public void RazorfenHunter_VAN_CS2_196()
		{
			// TODO RazorfenHunter_VAN_CS2_196 test
			var game = new Game(new GameConfig
			{
				StartPlayer = 1,
				Player1HeroClass = CardClass.MAGE,
				Player1Deck = new List<Card>()
				{
					Cards.FromName("Razorfen Hunter", FormatType.FT_CLASSIC)
				},
				Player2HeroClass = CardClass.MAGE,
				Shuffle = false,
				FillDecks = true,
				FillDecksPredictably = true,
				FormatType=FormatType.FT_CLASSIC
			});
			game.StartGame();
			game.Player1.BaseMana = 10;
			game.Player2.BaseMana = 10;
			//Minion testCard = game.ProcessCard<Minion>("Razorfen Hunter");
		}

	}

}
