using System;
using System.Collections.Generic;
using System.Text;
using System.Buffers;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SabberStoneCore.Tasks.PlayerTasks.Lite
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	[DebuggerTypeProxy(typeof(DebuggerView))]
	public class PlayerTaskLiteContainer : IEnumerable<PlayerTaskLite>
	{
		public int Count { get; private set; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(in PlayerTaskLite task)
		{
			if (Count == _array.Length)
				Resize();
			_array[Count++] = task;
		}

		//public void Emplace(PlayerTaskType type, int source, int target,
		//	int zonePosition, int chooseOne, bool skipPrePhase)
		//{
		//	ref PlayerTaskLite ptr = ref _array[Count];
		//	ptr = new PlayerTaskLite()
		//}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			//ArrayPool<PlayerTaskLite> pool = ArrayPool<PlayerTaskLite>.Shared;
			//pool.Return(_array, true);
			//_array = pool.Rent(MIN_SIZE);
			Count = 0;
		}

		public ref readonly PlayerTaskLite GetRandom(Random rnd)
		{
			return ref _array[rnd.Next(Count)];
		}

		private const int MIN_SIZE = 64;

		private void Resize()
		{
			//ArrayPool<PlayerTaskLite> pool = ArrayPool<PlayerTaskLite>.Shared;
			//PlayerTaskLite[] newArr = pool.Rent(_array.Length << 1);
			var newArr = new PlayerTaskLite[_array.Length << 1];
			//Buffer.BlockCopy(_array, 0, newArr, 0, _array.Length * sizeof(PlayerTaskLite));
			Array.Copy(_array, 0, newArr, 0, _array.Length);
			//pool.Return(_array, true);
			_array = newArr;
		}

		private void Allocate()
		{
			var pool = ArrayPool<PlayerTaskLite>.Shared;
			_array = pool.Rent(MIN_SIZE);
		}

		private PlayerTaskLite[] _array = new PlayerTaskLite[MIN_SIZE];

		private class DebuggerView
		{
			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public Span<PlayerTaskLite> View => _c._array.AsSpan(0, _c.Count);

			public DebuggerView(PlayerTaskLiteContainer container)
			{
				_c = container;
			}

			private PlayerTaskLiteContainer _c;
		}

		private string DebuggerDisplay => $"Count = {Count}";

		private struct Enumerator : IEnumerator<PlayerTaskLite>
		{
			private readonly PlayerTaskLite[] _data;
			private readonly int _count;
			private int _pos = -1;

			public Enumerator(PlayerTaskLite[] data, int count)
			{
				_data = data;
				_count = count;
			}

			public bool MoveNext()
			{
				++_pos;
				return _pos < _count;
			}

			public void Reset()
			{
				_pos = -1;
			}

			public PlayerTaskLite Current => _data[_pos];

			object IEnumerator.Current => Current;

			public void Dispose()
			{
			}
		}


		public IEnumerator<PlayerTaskLite> GetEnumerator()
		{
			return new Enumerator(_array, Count);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
