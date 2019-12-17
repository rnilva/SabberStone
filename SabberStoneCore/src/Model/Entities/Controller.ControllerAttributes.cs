

// AUTOMATICALLY GENERATED SOURCE
using System;
using System.Runtime.CompilerServices;
using SabberStoneCore.Enums;

namespace SabberStoneCore.Model.Entities
{
	public enum ControllerIntAttributes
	{
		Invalid = -1,
		UsedMana = 5,
		OverloadOwed = 7,
		OverloadLocked = 8,
		SpellPowerDouble = 10,
		HeroPowerDouble,
		AllHealingDouble,
		TimeOut = 36
	}
	public enum ControllerBoolAttributes
	{
		Invalid = -1,
		RestoreToDamage,
		ExtraDeathrattle,
		ExtraBattlecry,
		ChooseBoth,
		SpellsCostHealth,
		ExtraEndTurnEffect,
		HeroPowerDisabled,
		ExtraBattleCryAndCombo
	}

	public partial class Controller
	{
		internal unsafe ref int GetAttributeRef(int index)
		{
			return ref _attrs.intAttrs[index];
		}

		public unsafe int this[ControllerIntAttributes attr]
		{
			get => _attrs.intAttrs[(int) attr];
			set => _attrs.intAttrs[(int) attr] = value;
		}

		public unsafe bool this[ControllerBoolAttributes attr]
		{
			get => _attrs.sbyteAttrs[(int) attr] > 0;
			set => _attrs.sbyteAttrs[(int) attr] += value ? (sbyte) 1 : (sbyte) -1;
		}

		private unsafe struct Attributes
		{
			// 0 : PlayerId
			// 1 : HeroId
			// 2 : PlayState
			// 3 : MulliganState
			// 4 : BaseMana
			// 5 : UsedMana
			// 6 : TemporaryMana
			// 7 : OverloadOwed
			// 8 : OverloadLocked
			// 9 : OverloadThisGame
			// 10 : SpellPowerDouble
			// 11 : HeroPowerDouble
			// 12 : AllHealingDouble
			// 13 : NumTurnsLeft
			// 14 : LastCardPlayed
			// 15 : LastCardDrawn
			// 16 : LastCardDiscarded
			// 17 : NumCardsDrawnThisTurn
			// 18 : NumCardsPlayedThisTurn
			// 19 : NumMinionsPlayedThisTurn
			// 20 : NumOptionsPlayedThisTurn
			// 21 : NumFriendlyMinionsThatDiedThisTurn
			// 22 : AmountHeroHealedThisTurn
			// 23 : NumMinionsPlayerKilledThisTurn
			// 24 : NumFriendlyMinionsThatAttackedThisTurn
			// 25 : HeroPowerActivationsThisTurn
			// 26 : NumElementalsPlayedThisTurn
			// 27 : NumElementalsPlayedLastTurn
			// 28 : TotalManaSpentThisGame
			// 29 : NumTotemSummonedThisGame
			// 30 : NumTimesHeroPowerUsedThisGame
			// 31 : NumHeroPowerDamageThisGame
			// 32 : NumSecretsPlayedThisGame
			// 33 : NumSpellsPlayedThisGame
			// 34 : NumWeaponsPlayedThisGame
			// 35 : NumMurlocsPlayedThisGame
			// 36 : TimeOut
			// 37 : ProxyCthun

			// 0 : IsComboActive
			// 1 : SeenCthun
			// 2 : TemporusFlag

			// 0 : RestoreToDamage
			// 1 : ExtraDeathrattle
			// 2 : ExtraBattlecry
			// 3 : ChooseBoth
			// 4 : SpellsCostHelath
			// 5 : ExtraEndTurnEffect
			// 6 : HeroPowerDisabled
			// 7 : ExtraBattleCryAndCombo

			private const int NUM_INT_ATTRS = 38;
			private const int NUM_BOOL_ATTRS = 3;
			private const int NUM_SBYTE_ATTRS = 8;
		#pragma warning disable 649
			public fixed int intAttrs[NUM_INT_ATTRS];
			public fixed bool boolAttrs[NUM_BOOL_ATTRS];
			public fixed sbyte sbyteAttrs[NUM_SBYTE_ATTRS];
		#pragma warning restore 649
			#region ClearTurnStatistics
			private const int TURN_STATS_OFFSET = 17;
			private const int TURN_STATS_COUNT = 9;

			private struct _zeroes
			{
#pragma warning disable 649
				public fixed int space[TURN_STATS_COUNT];
				public static _zeroes Get;
#pragma warning restore 649
			}

			public void ClearTurnStatistics()
			{
				fixed (void* src = _zeroes.Get.space)
				fixed (int* dst = intAttrs)
					Buffer.MemoryCopy(src, dst + TURN_STATS_OFFSET, TURN_STATS_COUNT * sizeof(int),
						TURN_STATS_COUNT * sizeof(int));
			}
			#endregion
		}
		private Attributes _attrs;

		#region Attribute Properties
		/// <summary>
		/// ID of the player, which is a monotone ranking order starting from 1
		/// The first player gets PlayerID == 1.
		/// </summary>
		public unsafe int PlayerId
		{
			get => _attrs.intAttrs[0];
			private set => _attrs.intAttrs[0] = value;
		}
		/// <summary>
		/// The EntityID of the selected Hero.
		/// </summary>
		public unsafe int HeroId
		{
			get => _attrs.intAttrs[1];
			set => _attrs.intAttrs[1] = value;
		}
		/// <summary>
		/// Context in which the controller is performing.
		/// </summary>
		public unsafe PlayState PlayState
		{
			get => (PlayState) _attrs.intAttrs[2];
			set => _attrs.intAttrs[2] = (int) value;
		}
		/// <summary>
		/// Progress this player is making during Mulligan Phase.
		/// </summary>
		public unsafe Mulligan MulliganState
		{
			get => (Mulligan) _attrs.intAttrs[3];
			set => _attrs.intAttrs[3] = (int) value;
		}
		/// <summary>
		/// Total amount of mana available to this player
		/// This value DOES NOT contain temporary mana! 
		/// </summary>
		public unsafe int BaseMana
		{
			get => _attrs.intAttrs[4];
			set => _attrs.intAttrs[4] = value;
		}
		/// <summary>
		/// Amount of mana used by this player in this turn.
		/// </summary>
		public unsafe int UsedMana
		{
			get => _attrs.intAttrs[5];
			set => _attrs.intAttrs[5] = value;
		}
		/// <summary>
		/// Additional mana gained during this turn.
		/// </summary>
		public unsafe int TemporaryMana
		{
			get => _attrs.intAttrs[6];
			set => _attrs.intAttrs[6] = value;
		}
		/// <summary>
		/// Amount mana overloaded this turn
		/// This amount will be locked during the next turn.
		/// </summary>
		public unsafe int OverloadOwed
		{
			get => _attrs.intAttrs[7];
			set => _attrs.intAttrs[7] = value;
		}
		/// <summary>
		/// Amount of mana locked this turn
		/// The subtraction of BaseMana and this value gives the available resources during this turn.
		/// </summary>
		public unsafe int OverloadLocked
		{
			get => _attrs.intAttrs[8];
			set => _attrs.intAttrs[8] = value;
		}
		/// <summary>
		/// Total amount of overloaded mana during this game.
		/// </summary>
		public unsafe int OverloadThisGame
		{
			get => _attrs.intAttrs[9];
			set => _attrs.intAttrs[9] = value;
		}
		public unsafe int SpellPowerDouble
		{
			get => _attrs.intAttrs[10];
			set => _attrs.intAttrs[10] = value;
		}
		public unsafe int HeroPowerDouble
		{
			get => _attrs.intAttrs[11];
			set => _attrs.intAttrs[11] = value;
		}
		public unsafe int AllHealingDouble
		{
			get => _attrs.intAttrs[12];
			set => _attrs.intAttrs[12] = value;
		}
		public unsafe int NumTurnsLeft
		{
			get => _attrs.intAttrs[13];
			set => _attrs.intAttrs[13] = value;
		}
		/// <summary>
		/// Id of last entity played by this player.
		/// </summary>
		public unsafe int LastCardPlayed
		{
			get => _attrs.intAttrs[14];
			set => _attrs.intAttrs[14] = value;
		}
		/// <summary>
		/// Id of last entity drawn by this player.
		/// </summary>
		public unsafe int LastCardDrawn
		{
			get => _attrs.intAttrs[15];
			set => _attrs.intAttrs[15] = value;
		}
		/// <summary>
		/// Id of last entity discarded by this player.
		/// </summary>
		public unsafe int LastCardDiscarded
		{
			get => _attrs.intAttrs[16];
			set => _attrs.intAttrs[16] = value;
		}
		public unsafe int NumCardsDrawnThisTurn
		{
			get => _attrs.intAttrs[17];
			set => _attrs.intAttrs[17] = value;
		}
		public unsafe int NumCardsPlayedThisTurn
		{
			get => _attrs.intAttrs[18];
			set => _attrs.intAttrs[18] = value;
		}
		public unsafe int NumMinionsPlayedThisTurn
		{
			get => _attrs.intAttrs[19];
			set => _attrs.intAttrs[19] = value;
		}
		public unsafe int NumOptionsPlayedThisTurn
		{
			get => _attrs.intAttrs[20];
			set => _attrs.intAttrs[20] = value;
		}
		public unsafe int NumFriendlyMinionsThatDiedThisTurn
		{
			get => _attrs.intAttrs[21];
			set => _attrs.intAttrs[21] = value;
		}
		public unsafe int AmountHeroHealedThisTurn
		{
			get => _attrs.intAttrs[22];
			set => _attrs.intAttrs[22] = value;
		}
		public unsafe int NumMinionsPlayerKilledThisTurn
		{
			get => _attrs.intAttrs[23];
			set => _attrs.intAttrs[23] = value;
		}
		public unsafe int NumFriendlyMinionsThatAttackedThisTurn
		{
			get => _attrs.intAttrs[24];
			set => _attrs.intAttrs[24] = value;
		}
		public unsafe int HeroPowerActivationsThisTurn
		{
			get => _attrs.intAttrs[25];
			set => _attrs.intAttrs[25] = value;
		}
		public unsafe int NumElementalsPlayedThisTurn
		{
			get => _attrs.intAttrs[26];
			set => _attrs.intAttrs[26] = value;
		}
		public unsafe int NumElementalsPlayedLastTurn
		{
			get => _attrs.intAttrs[27];
			set => _attrs.intAttrs[27] = value;
		}
		public unsafe int TotalManaSpentThisGame
		{
			get => _attrs.intAttrs[28];
			set => _attrs.intAttrs[28] = value;
		}
		public unsafe int NumTotemSummonedThisGame
		{
			get => _attrs.intAttrs[29];
			set => _attrs.intAttrs[29] = value;
		}
		public unsafe int NumTimesHeroPowerUsedThisGame
		{
			get => _attrs.intAttrs[30];
			set => _attrs.intAttrs[30] = value;
		}
		public unsafe int NumHeroPowerDamageThisGame
		{
			get => _attrs.intAttrs[31];
			set => _attrs.intAttrs[31] = value;
		}
		public unsafe int NumSecretsPlayedThisGame
		{
			get => _attrs.intAttrs[32];
			set => _attrs.intAttrs[32] = value;
		}
		public unsafe int NumSpellsPlayedThisGame
		{
			get => _attrs.intAttrs[33];
			set => _attrs.intAttrs[33] = value;
		}
		public unsafe int NumWeaponsPlayedThisGame
		{
			get => _attrs.intAttrs[34];
			set => _attrs.intAttrs[34] = value;
		}
		public unsafe int NumMurlocsPlayedThisGame
		{
			get => _attrs.intAttrs[35];
			set => _attrs.intAttrs[35] = value;
		}
		/// <summary>
		/// Maximum duration of seconds of this player's turn.
		/// </summary>
		public unsafe int TimeOut
		{
			get => _attrs.intAttrs[36];
			set => _attrs.intAttrs[36] = value;
		}
		/// <summary>
		/// The entity which is a copy of the real C'Thun entity in deck
		/// This proxy is used to display and store all buffs from rituals
		/// The real C'Thun will mirror the proxy C'Thun.
		/// </summary>
		public unsafe int ProxyCthun
		{
			get => _attrs.intAttrs[37];
			set => _attrs.intAttrs[37] = value;
		}
		/// <summary>
		/// Indicates whether combo effects should be executed or not.Combo is active if at least one card has been played this turn.
		/// </summary>
		public unsafe bool IsComboActive
		{
			get => _attrs.boolAttrs[0];
			set => _attrs.boolAttrs[0] = value;
		}
		public unsafe bool SeenCthun
		{
			get => _attrs.boolAttrs[1];
			set => _attrs.boolAttrs[1] = value;
		}
		public unsafe bool TemporusFlag
		{
			get => _attrs.boolAttrs[2];
			set => _attrs.boolAttrs[2] = value;
		}
		/// <summary>
		/// Returns true if for this player all cards and powers that restore Health deal damage instead
		/// (True when Auchenai Soulpriest is in play.)
		/// </summary>
		public unsafe bool RestoreToDamage
		{
			get => _attrs.sbyteAttrs[0] > 0;
			set => _attrs.sbyteAttrs[0] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if deathrattle effects of this player should be executed twice
		/// (True when Baron Rivendare is in play.)
		/// </summary>
		public unsafe bool ExtraDeathrattle
		{
			get => _attrs.sbyteAttrs[1] > 0;
			set => _attrs.sbyteAttrs[1] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if for this player all battlecries should be executed another time
		/// This is applicable when Brann BronzeBeard is in play.
		/// </summary>
		public unsafe bool ExtraBattlecry
		{
			get => _attrs.sbyteAttrs[2] > 0;
			set => _attrs.sbyteAttrs[2] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if this player automatically gets both options instead of having to choose one
		/// This is applicable when Fandral Staghelm is in play.
		/// </summary>
		public unsafe bool ChooseBoth
		{
			get => _attrs.sbyteAttrs[3] > 0;
			set => _attrs.sbyteAttrs[3] += value ? (sbyte) 1 : (sbyte) -1;
		}
		public unsafe bool SpellsCostHelath
		{
			get => _attrs.sbyteAttrs[4] > 0;
			set => _attrs.sbyteAttrs[4] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if for this player all end turn effects should be executed another time
		/// This is applicable when Drakkari Enchanter is in play.
		/// </summary>
		public unsafe bool ExtraEndTurnEffect
		{
			get => _attrs.sbyteAttrs[5] > 0;
			set => _attrs.sbyteAttrs[5] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if for this player hero power is disabled.
		/// </summary>
		public unsafe bool HeroPowerDisabled
		{
			get => _attrs.sbyteAttrs[6] > 0;
			set => _attrs.sbyteAttrs[6] += value ? (sbyte) 1 : (sbyte) -1;
		}
		public unsafe bool ExtraBattleCryAndCombo
		{
			get => _attrs.sbyteAttrs[7] > 0;
			set => _attrs.sbyteAttrs[7] += value ? (sbyte) 1 : (sbyte) -1;
		}
		#endregion

		public int SpellHealingDouble => SpellPowerDouble;
		public int NumDiscardedThisGame => DiscardedEntities.Count;
		public int CurrentSpellPower
		{
			get
			{
				int sum = 0;
				ReadOnlySpan<MinionInPlay> span = BoardZone.GetSpan();
				for (int i = 0; i < span.Length; ++i)
					sum += span[i].SpellPower;
				sum += Hero.SpellPower;
				return sum;
			}
		}
	}
}
