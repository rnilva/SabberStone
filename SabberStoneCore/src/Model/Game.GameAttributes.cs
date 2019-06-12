using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SabberStoneCore.Model
{
	public partial class Game
	{
		private unsafe struct GameAttributes
		{
			private const int COUNT = 8;
			private fixed int _data[COUNT];

			public GameAttributes(GameAttributes other)
			{
				fixed (void* ptr = _data)
					Buffer.MemoryCopy(other._data, ptr,
						COUNT * sizeof(int), COUNT * sizeof(int));
			}

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
