using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SabberStoneCore.Model.Entities
{
	/// <summary>
	/// A collection of <see cref="Playable"/>/<see cref="int"/> id pairs of a <see cref="Game"/> instance.
	/// Implements <see cref="IDictionary"/>.
	/// </summary>
	[DebuggerDisplay("Count = {_count}")]
	public class EntityList : IDictionary<int, Playable>
	{
		private Playable[] _list;
		private int _count;

		public Playable this[int id]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (id >= _list.Length)
					throw new ArgumentOutOfRangeException();
				Playable value = _list[id];
				if (value == null)
					throw new KeyNotFoundException();

				return value;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				Playable[] list = _list;
				if (id >= list.Length)
				{
					var newlist = new Playable[(int)(list.Length * 1.5)];
					Array.Copy(list, newlist, list.Length);
					list = newlist;
					_list = newlist;
				}

				if (list[id] == null)
					_count++;

				list[id] = value;
			}
		}

		internal EntityList(int length)
		{
			_list = new Playable[length];
		}

		public int Capacity => _list.Length;

		public void Add(int key, Playable value)
		{
			Playable[] list = _list;
			if (list.Length <= key)
			{
				var newlist = new Playable[list.Length * 2];
				Array.Copy(list, newlist, list.Length);
				list = newlist;
				_list = newlist;
			}

			if (list[key] != null)
				throw new ArgumentException();
			list[key] = value;
			_count++;
		}

		public ReadOnlySpan<Playable> GetSpan()
		{
			return new ReadOnlySpan<Playable>(_list, 0, Count + 4);
		}

		#region IDictionary
		public bool ContainsKey(int key)
		{
			return _list[key] != null;
		}

		public bool Remove(int key)
		{
			if (_list[key] == null) return false;
			_list[key] = null;
			return true;
		}

		public bool TryGetValue(int key, out Playable value)
		{
			value = _list[key];
			return value != null;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ICollection<int> Keys { get; }

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public ICollection<Playable> Values
		{
			get
			{
				var values = new Playable[_count];
				int i = 0;
				foreach (Playable item in _list)
				{
					if (item == null) continue;

					values[i++] = item;
				}
				return values;
			}
		}

		public IEnumerator<KeyValuePair<int, Playable>> GetEnumerator()
		{
			var list = _list;
			for (int i = 0; i < list.Length; i++)
				if (list[i] != null)
					yield return new KeyValuePair<int, Playable>(i, list[i]);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(KeyValuePair<int, Playable> item)
		{
			Add(item.Key, item.Value);
		}

		public void Clear()
		{
			var list = _list;
			for (int i = 0; i < list.Length; i++)
				list[i] = null;
		}

		public bool Contains(KeyValuePair<int, Playable> item)
		{
			return _list[item.Key] != null;
		}

		public void CopyTo(KeyValuePair<int, Playable>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(KeyValuePair<int, Playable> item)
		{
			if (_list[item.Key] == null)
				return false;
			_list[item.Key] = null;
			return true;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Count => _count;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsReadOnly => false;
		#endregion
	}
}
