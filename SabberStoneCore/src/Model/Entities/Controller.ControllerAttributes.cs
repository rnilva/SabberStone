

// AUTOMATICALLY GENERATED SOURCE
using System;
using System.Runtime.CompilerServices;
using SabberStoneCore.Enums;

namespace SabberStoneCore.Model.Entities
{
	public enum ControllerIntAttributes
	{
		PlayerId = 0,
		HeroId = 1,
		PlayState = 2,
		MulliganState = 3,
		BaseMana = 4,
		UsedMana = 5,
		TemporaryMana = 6,
		OverloadOwed = 7,
		OverloadLocked = 8,
		OverloadThisGame = 9,
		SpellPowerDouble = 10,
		HeroPowerDouble = 11,
		AllHealingDouble = 12,
		NumTurnsLeft = 13,
		LastCardPlayed = 14,
		LastCardDrawn = 15,
		LastCardDiscarded = 16,
		NumCardsDrawnThisTurn = 17,
		NumCardsPlayedThisTurn = 18,
		NumMinionsPlayedThisTurn = 19,
		NumOptionsPlayedThisTurn = 20,
		NumFriendlyMinionsThatDiedThisTurn = 21,
		AmountHeroHealedThisTurn = 22,
		NumMinionsPlayerKilledThisTurn = 23,
		NumFriendlyMinionsThatAttackedThisTurn = 24,
		HeroPowerActivationsThisTurn = 25,
		NumElementalsPlayedThisTurn = 26,
		NumElementalsPlayedLastTurn = 27,
		TotalManaSpentThisGame = 28,
		NumTotemSummonedThisGame = 29,
		NumTimesHeroPowerUsedThisGame = 30,
		NumHeroPowerDamageThisGame = 31,
		AmountHealedThisGame = 32,
		NumSecretsPlayedThisGame = 33,
		NumSpellsPlayedThisGame = 34,
		NumWeaponsPlayedThisGame = 35,
		NumMurlocsPlayedThisGame = 36,
		TimeOut = 38,
		ProxyCthun = 39,
		Invalid = -1,
	}
	public enum ControllerBoolAttributes
	{
		RestoreToDamage = 0,
		ExtraDeathrattle = 1,
		ExtraBattlecry = 2,
		ChooseBoth = 3,
		SpellsCostHealth = 4,
		ExtraEndTurnEffect = 5,
		HeroPowerDisabled = 6,
		ExtraBattleCryAndCombo = 7,
		Invalid = -1,
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
			// 32 : AmountHealedThisGame
			// 33 : NumSecretsPlayedThisGame
			// 34 : NumSpellsPlayedThisGame
			// 35 : NumWeaponsPlayedThisGame
			// 36 : NumMurlocsPlayedThisGame
			// 37 : TotalManaSpentOnSpells
			// 38 : TimeOut
			// 39 : ProxyCthun

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

			private const int NUM_INT_ATTRS = 40;
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[0];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private set => _attrs.intAttrs[0] = value;
		}
		/// <summary>
		/// The EntityID of the selected Hero.
		/// </summary>
		public unsafe int HeroId
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[1];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[1] = value;
		}
		/// <summary>
		/// Context in which the controller is performing.
		/// </summary>
		public unsafe PlayState PlayState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => (PlayState) _attrs.intAttrs[2];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[2] = (int) value;
		}
		/// <summary>
		/// Progress this player is making during Mulligan Phase.
		/// </summary>
		public unsafe Mulligan MulliganState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => (Mulligan) _attrs.intAttrs[3];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[3] = (int) value;
		}
		/// <summary>
		/// Total amount of mana available to this player
		/// This value DOES NOT contain temporary mana! 
		/// </summary>
		public unsafe int BaseMana
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[4];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[4] = value;
		}
		/// <summary>
		/// Amount of mana used by this player in this turn.
		/// </summary>
		public unsafe int UsedMana
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[5];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[5] = value;
		}
		/// <summary>
		/// Additional mana gained during this turn.
		/// </summary>
		public unsafe int TemporaryMana
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[6];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[6] = value;
		}
		/// <summary>
		/// Amount mana overloaded this turn
		/// This amount will be locked during the next turn.
		/// </summary>
		public unsafe int OverloadOwed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[7];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[7] = value;
		}
		/// <summary>
		/// Amount of mana locked this turn
		/// The subtraction of BaseMana and this value gives the available resources during this turn.
		/// </summary>
		public unsafe int OverloadLocked
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[8];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[8] = value;
		}
		/// <summary>
		/// Total amount of overloaded mana during this game.
		/// </summary>
		public unsafe int OverloadThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[9];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[9] = value;
		}
		public unsafe int SpellPowerDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[10];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[10] = value;
		}
		public unsafe int HeroPowerDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[11];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[11] = value;
		}
		public unsafe int AllHealingDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[12];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[12] = value;
		}
		public unsafe int NumTurnsLeft
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[13];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[13] = value;
		}
		/// <summary>
		/// Id of last entity played by this player.
		/// </summary>
		public unsafe int LastCardPlayed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[14];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[14] = value;
		}
		/// <summary>
		/// Id of last entity drawn by this player.
		/// </summary>
		public unsafe int LastCardDrawn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[15];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[15] = value;
		}
		/// <summary>
		/// Id of last entity discarded by this player.
		/// </summary>
		public unsafe int LastCardDiscarded
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[16];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[16] = value;
		}
		public unsafe int NumCardsDrawnThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[17];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[17] = value;
		}
		public unsafe int NumCardsPlayedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[18];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[18] = value;
		}
		public unsafe int NumMinionsPlayedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[19];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[19] = value;
		}
		public unsafe int NumOptionsPlayedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[20];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[20] = value;
		}
		public unsafe int NumFriendlyMinionsThatDiedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[21];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[21] = value;
		}
		public unsafe int AmountHeroHealedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[22];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[22] = value;
		}
		public unsafe int NumMinionsPlayerKilledThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[23];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[23] = value;
		}
		public unsafe int NumFriendlyMinionsThatAttackedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[24];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[24] = value;
		}
		public unsafe int HeroPowerActivationsThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[25];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[25] = value;
		}
		public unsafe int NumElementalsPlayedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[26];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[26] = value;
		}
		public unsafe int NumElementalsPlayedLastTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[27];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[27] = value;
		}
		public unsafe int TotalManaSpentThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[28];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[28] = value;
		}
		public unsafe int NumTotemSummonedThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[29];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[29] = value;
		}
		public unsafe int NumTimesHeroPowerUsedThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[30];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[30] = value;
		}
		public unsafe int NumHeroPowerDamageThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[31];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[31] = value;
		}
		public unsafe int AmountHealedThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[32];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[32] = value;
		}
		public unsafe int NumSecretsPlayedThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[33];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[33] = value;
		}
		public unsafe int NumSpellsPlayedThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[34];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[34] = value;
		}
		public unsafe int NumWeaponsPlayedThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[35];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[35] = value;
		}
		public unsafe int NumMurlocsPlayedThisGame
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[36];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[36] = value;
		}
		public unsafe int TotalManaSpentOnSpells
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[37];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[37] = value;
		}
		/// <summary>
		/// Maximum duration of seconds of this player's turn.
		/// </summary>
		public unsafe int TimeOut
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[38];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[38] = value;
		}
		/// <summary>
		/// The entity which is a copy of the real C'Thun entity in deck
		/// This proxy is used to display and store all buffs from rituals
		/// The real C'Thun will mirror the proxy C'Thun.
		/// </summary>
		public unsafe int ProxyCthun
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[39];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[39] = value;
		}
		/// <summary>
		/// Indicates whether combo effects should be executed or not.Combo is active if at least one card has been played this turn.
		/// </summary>
		public unsafe bool IsComboActive
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[0];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[0] = value;
		}
		public unsafe bool SeenCthun
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[1];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[1] = value;
		}
		public unsafe bool TemporusFlag
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[2];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[2] = value;
		}
		/// <summary>
		/// Returns true if for this player all cards and powers that restore Health deal damage instead
		/// (True when Auchenai Soulpriest is in play.)
		/// </summary>
		public unsafe bool RestoreToDamage
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[0] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.sbyteAttrs[0] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if deathrattle effects of this player should be executed twice
		/// (True when Baron Rivendare is in play.)
		/// </summary>
		public unsafe bool ExtraDeathrattle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[1] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.sbyteAttrs[1] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if for this player all battlecries should be executed another time
		/// This is applicable when Brann BronzeBeard is in play.
		/// </summary>
		public unsafe bool ExtraBattlecry
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[2] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.sbyteAttrs[2] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if this player automatically gets both options instead of having to choose one
		/// This is applicable when Fandral Staghelm is in play.
		/// </summary>
		public unsafe bool ChooseBoth
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[3] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.sbyteAttrs[3] += value ? (sbyte) 1 : (sbyte) -1;
		}
		public unsafe bool SpellsCostHelath
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[4] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.sbyteAttrs[4] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if for this player all end turn effects should be executed another time
		/// This is applicable when Drakkari Enchanter is in play.
		/// </summary>
		public unsafe bool ExtraEndTurnEffect
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[5] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.sbyteAttrs[5] += value ? (sbyte) 1 : (sbyte) -1;
		}
		/// <summary>
		/// Returns true if for this player hero power is disabled.
		/// </summary>
		public unsafe bool HeroPowerDisabled
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[6] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.sbyteAttrs[6] += value ? (sbyte) 1 : (sbyte) -1;
		}
		public unsafe bool ExtraBattleCryAndCombo
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.sbyteAttrs[7] > 0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
