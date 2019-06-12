using System;
using System.Runtime.CompilerServices;

namespace SabberStoneCore.Model.Entities
{
	public partial class Controller
	{
		private unsafe struct ControllerAttributes
		{
			private const int COUNT = 37;
			private const int TURN_STATISTICS_OFFSET = 17;
			private const int TURN_STATISTICS_COUNT = 7;

			private fixed int _data[COUNT];

			public ControllerAttributes(ControllerAttributes other)
			{
				fixed (void* ptr = _data)
					Buffer.MemoryCopy(other._data, ptr,
					COUNT * sizeof(int), COUNT * sizeof(int));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void CleanTurnStatistics()
			{
				for (int i = TURN_STATISTICS_OFFSET; i < TURN_STATISTICS_OFFSET + TURN_STATISTICS_COUNT; i++)
					_data[i] = 0;
			}

			#region Properties
			public int PlayerId
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[0];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[0] = value;
			}
			public int HeroId
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[1];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[1] = value;
			}
			public int PlayState
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[2];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[2] = value;
			}
			public int BaseMana
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[3];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[3] = value;
			}
			public int UsedMana
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[4];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[4] = value;
			}
			public int TemporaryMana
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[5];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[5] = value;
			}
			public int OverloadOwed
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[6];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[6] = value;
			}
			public int OverloadLocked
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[7];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[7] = value;
			}
			public int OverloadThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[8];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[8] = value;
			}
			public int IsComboActive
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[9];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[9] = value;
			}
			public int CurrentSpellPower
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[10];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[10] = value;
			}
			public int NumTurnsLeft
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[11];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[11] = value;
			}
			public int TimeOut
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[12];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[12] = value;
			}
			public int TemporusFlag
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[13];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[13] = value;
			}
			public int LastCardPlayed
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[14];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[14] = value;
			}
			public int LastCardDrawn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[15];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[15] = value;
			}
			public int LastCardDiscarded
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[16];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[16] = value;
			}
			public int NumCardsDrawnThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[17];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[17] = value;
			}
			public int NumCardsPlayedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[18];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[18] = value;
			}
			public int NumMinionsPlayedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[19];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[19] = value;
			}
			public int NumOptionsPlayedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[20];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[20] = value;
			}
			public int NumFriendlyMinionThatDiedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[21];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[21] = value;
			}
			public int AmountHeroHealedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[22];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[22] = value;
			}
			public int NumMinionsPlayerKilledThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[23];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[23] = value;
			}
			public int NumElementalPlayedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[24];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[24] = value;
			}
			public int NumElementalPlayedLastTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[25];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[25] = value;
			}
			public int NumFriendlyMinionsThatAttackedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[26];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[26] = value;
			}
			public int HeroPowerActivationsThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[27];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[27] = value;
			}
			public int TotalManaSpentThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[28];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[28] = value;
			}
			public int NumTotemSummonedThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[29];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[29] = value;
			}
			public int NumTimesHeroPowerUsedThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[30];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[30] = value;
			}
			public int NumSecretPlayedThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[31];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[31] = value;
			}
			public int NumSpellsPlayedThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[32];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[32] = value;
			}
			public int NumWeaponsPlayedThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[33];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[33] = value;
			}
			public int NumMurlocsPlayedThisGame
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[34];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[34] = value;
			}
			public int SeenCthun
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[35];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[35] = value;
			}
			public int ProxyCthun
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[36];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[36] = value;
			}
			#endregion
		}
	}
}
