using System.Runtime.CompilerServices;
using SabberStoneCore.Enums;

namespace SabberStoneCore.Model
{
	public partial class Game
	{
		public override int this[GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.TURN:
						return Turn;
					case GameTag.STATE:
						return (int) State;
					case GameTag.STEP:
						return (int) Step;
					case GameTag.NEXT_STEP:
						return (int) NextStep;
					case GameTag.PROPOSED_ATTACKER:
						return ProposedAttacker;
					case GameTag.PROPOSED_DEFENDER:
						return ProposedDefender;
					case GameTag.FIRST_CARD_PLAYED_THIS_TURN:
						return FirstCardPlayedThisTurn;
					case GameTag.NUM_MINIONS_KILLED_THIS_TURN:
						return NumMinionsKilledThisTurn;
					default:
						return base[t];
				}
			}
			set => base[t] = value;
		}

		private unsafe struct GameAttributes
		{
			private const int COUNT = 8;
#pragma warning disable 649
			private fixed int _data[COUNT];
#pragma warning restore 649

			//public GameAttributes(GameAttributes other)
			//{
			//	fixed (void* ptr = _data)
			//		Buffer.MemoryCopy(other._data, ptr,
			//			COUNT * sizeof(int), COUNT * sizeof(int));
			//}

			public int Turn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[0];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[0] = value;
			}
			public int State
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[1];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[1] = value;
			}
			public int Step
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[2];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[2] = value;
			}
			public int NextStep
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[3];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[3] = value;
			}
			public int ProposedAttacker
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[4];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[4] = value;
			}
			public int ProposedDefender
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[5];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[5] = value;
			}
			public int FirstCardPlayedThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[6];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[6] = value;
			}
			public int NumMinionsKilledThisTurn
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _data[7];
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _data[7] = value;
			}
		}
	}
}
