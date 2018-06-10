using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;

namespace SabberStoneCore.Model.Entities
{
    internal class EntityData : IDictionary<GameTag, int>
    {
		private static readonly int[] Primes =
			{
				7,
				11,
				17,
				23,
				29,
				37,
				47,
				59,
				71,
				89,
				107,
				131,
				163,
				197,
				239,
				293,
				353,
				431,
				521,
				631,
				761,
				919,
				1103,
				1327,
				1597,
				1931,
				2333,
				2801,
				3371,
				4049,
				4861,
				5839,
				7013,
				8419,
				10103,
				12143,
				14591,
				17519,
				21023,
				25229,
				30293,
				36353,
				43627,
				52361,
				62851,
				75431,
				90523,
				108631,
				130363,
				156437,
				187751,
				225307,
				270371,
				324449,
				389357,
				467237,
				560689,
				672827,
				807403,
				968897,
				1162687,
				1395263,
				1674319,
				2009191,
				2411033,
				2893249,
				3471899,
				4166287,
				4999559,
				5999471,
				7199369
			};

		//private const int _initSize = 23;
	    private const int _initSize = 16;

		private int[] _buckets;
		private int _size = _initSize;

		public EntityData(Card card)
		{
			Card = card;
			var buckets = new int[_initSize << 1];
			for (int i = 0; i < buckets.Length; i++)
				buckets[i] = -1;
			_buckets = buckets;
		}

		public EntityData(Card card, int capacity)
		{
			Card = card;
			Initialise(capacity);
		}

	    public EntityData(Card card, IDictionary<GameTag, int> tags)
	    {
			Card = card;
		    if (tags is EntityData data)
		    {
			    unsafe
			    {
				    int len = data._buckets.Length;
				    _buckets = new int[len];
				    fixed (int* srcPtr = data._buckets, dstPtr = _buckets)
				    {
					    int* srcEndPtr = srcPtr + len;
					    long* s = (long*)srcPtr;
					    long* d = (long*)dstPtr;

					    do
					    {
						    *d = *s;
						    d++;
						    s++;
						    *d = *s;
						    d++;
						    s++;
					    } while (s + 2 <= srcEndPtr);

					    *d ^= *s;
				    }

				    _size = len >> 1;
				    Count = data.Count;
					return;
				}
			}

		    Initialise(tags.Count);
		    foreach (KeyValuePair<GameTag, int> tag in tags)
			    Insert(tag.Key, tag.Value);
	    }

		public unsafe EntityData(in EntityData data)
		{
			Card = data.Card;
			int len = data._buckets.Length;
			_buckets = new int[len];
			fixed (int* srcPtr = data._buckets, dstPtr = _buckets)
			{
				int* srcEndPtr = srcPtr + len;
				long* s = (long*)srcPtr;
				long* d = (long*)dstPtr;

				do
				{
					*d = *s;
					d++;
					s++;
					*d = *s;
					d++;
					s++;
				} while (s + 2 <= srcEndPtr);

				*d ^= *s;
			}

			_size = len >> 1;
			Count = data.Count;
		}

		public Card Card { get; set; }
		public int Count { get; private set; }
		public bool IsReadOnly { get; } = false;

	    public int GetEntityTag(GameTag key)
	    {
		    return Search((int)key, out int i) ? _buckets[i + 1] : 0;
	    }

		public int this[GameTag key]
		{
			get
			{
				if (Search((int)key, out int i))
					return _buckets[i + 1];

				Card.Tags.TryGetValue(key, out int value);
				return value;
			}
			set => InsertOrOverwrite(key, value);
		}

		public void Add(GameTag key, int value)
		{
			if (Count == _size)
				Resize();
			Insert(key, value);
		}

		public void Add(KeyValuePair<GameTag, int> item)
		{
			if (Count == _size)
				Resize();
			Insert(item.Key, item.Value);
		}

		public bool ContainsKey(GameTag key)
		{
			return SearchIndex(key) >= 0;
		}

		public bool TryGetValue(GameTag key, out int value)
		{
			if (Search((int)key, out int i))
			{
				value = _buckets[i + 1];
				return true;
			}

			value = 0;
			return false;
		}

		public bool Remove(GameTag key)
		{
			int index = SearchIndex(key);
			if (index < 0)
				return false;
			_buckets[index] = 0;
			--Count;
			return true;
		}

	    public bool Contains(GameTag tag, int value)
	    {
		    int index = SearchIndex(tag);
		    return index >= 0 && _buckets[index + 1] == value;
		}

		private void Initialise(int capacity)
		{
			//int prime = GetPrime(capacity);

			int n = 3;
			while (true)
			{
				int pow = 2 << n;
				if (pow > capacity)
				{
					capacity = pow;
					break;
				}

				++n;
			}

			var buckets = new int[capacity << 1];
			for (int i = 0; i < buckets.Length; i++)
				buckets[i] = -1;
			_size = capacity;
			_buckets = buckets;
		}

		// TODO: check duplicate
		private void Insert(GameTag t, int value)
		{
			int k = (int)t;
			//int slotIndex = (k % _size) << 1;
			int slotIndex = (k & (_size - 1)) << 1;

			int[] buckets = _buckets;
			for (int i = slotIndex; i < buckets.Length; i += 2)
			{
				if (buckets[i] > 0) continue;
				buckets[i] = k;
				buckets[i + 1] = value;
				++Count;
				return;
			}

			for (int i = 0; i < slotIndex; i += 2)
			{
				if (buckets[i] > 0) continue;
				buckets[i] = k;
				buckets[i + 1] = value;
				++Count;
				return;
			}

			throw new ArgumentOutOfRangeException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InsertOrOverwrite(GameTag t, int value)
		{
			if (Search((int)t, out int i))
			{
				//_buckets[i] = (int)t;
				_buckets[i + 1] = value;
				return;
			}

			if (i >= 0)
			{
				Count++;
				_buckets[i] = (int)t;
				_buckets[i + 1] = value;
				return;
			}

			Resize();
			Insert(t, value);
		}

		private int SearchIndex(GameTag t)
		{
			int k = (int)t;
			//int slotIndex = (k % _size) << 1;
			int slotIndex = (k & (_size - 1)) << 1;
			int[] buckets = _buckets;
			for (int i = slotIndex; i < buckets.Length; i += 2)
			{
				if (buckets[i] == k)
					return i;
				if (buckets[i] < 0)
					return -1;
			}
			for (int i = 0; i < slotIndex; i += 2)
			{
				if (buckets[i] < 0)
					return -1;
				if (buckets[i] == k)
					return i;
			}

			return -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool Search(int k, out int index)
		{
			int[] buckets = _buckets;

			//int h = (k % _size) << 1;
			int h = (k & (_size - 1)) << 1;

			int i = h;
			if (buckets[i] == k)
			{
				index = i;
				return true;
			}

			if (buckets[i] < 0)
			{
				index = i;
				return false;
			}
			i += 2;
			if (i < buckets.Length)
			{
				if (buckets[i] == k)
				{
					index = i;
					return true;
				}

				if (buckets[i] < 0)
				{
					index = i;
					return false;
				}
				for (i += 2; i < buckets.Length; i += 2)
				{
					if (buckets[i] < 0)
					{
						index = i;
						return false;
					}

					if (buckets[i] == k)
					{
						index = i;
						return true;
					}
				}
			}

			if (buckets[0] < 0)
			{
				index = 0;
				return false;
			}
			if (buckets[0] == k)
			{
				index = 0;
				return true;
			}

			for (i = 2; i < h; i += 2)
			{
				if (buckets[i] < 0)
				{
					index = i;
					return false;
				}

				if (buckets[i] == k)
				{
					index = i;
					return true;
				}
			}
			index = -1;
			return false;
		}

		private void Resize()
		{
			//int newSize = GetPrime(_size << 1);
			int newSize = _size << 1;
			_size = newSize;
			int[] newbuckets = new int[newSize << 1];
			for (int i = 0; i < newbuckets.Length; ++i)
				newbuckets[i] = -1;

			for (int i = 0; i < _buckets.Length; i += 2)
			{
				bool flag = false;

				int newIndex = (_buckets[i] % newSize) << 1;

				for (int j = newIndex; j < newbuckets.Length; j += 2)
				{
					if (newbuckets[j] >= 0) continue;
					newbuckets[j] = _buckets[i];
					newbuckets[j + 1] = _buckets[i + 1];
					flag = true;
					break;
				}

				if (flag)
					continue;

				for (int j = 0; j < newIndex; j += 2)
				{
					if (newbuckets[j] >= 0) continue;
					newbuckets[j] = _buckets[i];
					newbuckets[j + 1] = _buckets[i + 1];
					flag = true;
					break;
				}

				if (!flag)
					throw new ArgumentOutOfRangeException();
			}

			_buckets = newbuckets;
		}

		private static int GetPrime(int min)
		{
			for (int index = 0; index < Primes.Length; ++index)
			{
				int prime = Primes[index];
				if (prime >= min)
					return prime;
			}

			throw new IndexOutOfRangeException();
		}

		#region IDictionary
	    public ICollection<GameTag> Keys
	    {
		    get
		    {
			    var tags = new GameTag[Count];
				int[] buckets = _buckets;
			    for (int i = 0, j = 0; i < buckets.Length; i += 2)
			    {
					if (buckets[i] < 0) continue;
				    tags[j] = (GameTag)buckets[i];
					++j;
			    }

			    return tags;
		    }
	    }

		public ICollection<int> Values
	    {
			get
			{
				var values = new int[Count];
				int[] buckets = _buckets;
				for (int i = 0, j = 0; i < buckets.Length; i += 2)
				{
					if (buckets[i] < 0) continue;
					values[j] = buckets[i + 1];
					++j;
				}

				return values;
			}
		}

	    public void Clear()
	    {
		    if (Count == 0)
			    return;
			int[] buckets = _buckets;
		    for (int i = 0; i < buckets.Length; ++i)
			    buckets[i] = -1;
		    Count = 0;
	    }

		public IEnumerator<KeyValuePair<GameTag, int>> GetEnumerator()
		{
			int[] buckets = _buckets;
			for (int i = 0; i < buckets.Length; i += 2)
			{
				if (buckets[i] > 0)
					yield return new KeyValuePair<GameTag, int>((GameTag)buckets[i], buckets[i + 1]);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool Contains(KeyValuePair<GameTag, int> item)
		{
			return Contains(item.Key, item.Value);
		}

		public void CopyTo(KeyValuePair<GameTag, int>[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException();
			if (arrayIndex < 0 || arrayIndex > array.Length)
				throw new ArgumentOutOfRangeException();
			if (array.Length - arrayIndex < Count)
				throw new ArgumentException();
			int j = arrayIndex;
			int[] buckets = _buckets;
			for (int i = 0; i < buckets.Length; i += 2)
			{
				if (buckets[i] > 0)
				{
					array[j] = new KeyValuePair<GameTag, int>((GameTag)buckets[i], buckets[i + 1]);
					j++;
				}
			}
		}

		public bool Remove(KeyValuePair<GameTag, int> item)
		{
			return Remove(item.Key);
		}
		#endregion

	    public string Hash(params GameTag[] ignore)
	    {
			var hash = new StringBuilder();
			hash.Append("[");
			hash.Append(Card.Id);
			hash.Append("][GT:");
			foreach (KeyValuePair<GameTag, int> kvp in this.OrderBy(p => p.Key))
			{
				if (!ignore.Contains(kvp.Key))
				{
					hash.Append($"{{{kvp.Key},{kvp.Value}}}");
				}
			}
			hash.Append("]");
			return hash.ToString();
		}

		/// <summary>Resets all tags from the container.</summary>
		public void Reset(Dictionary<GameTag, int> tags = null)
		{
			//Tags = tags ?? new Dictionary<GameTag, int>(Enum.GetNames(typeof(GameTag)).Length);
			Remove(GameTag.DAMAGE);
			Remove(GameTag.PREDAMAGE);
			Remove(GameTag.ZONE_POSITION);
			Remove(GameTag.EXHAUSTED);
			Remove(GameTag.JUST_PLAYED);
			Remove(GameTag.SUMMONED);
			Remove(GameTag.ATTACKING);
			Remove(GameTag.DEFENDING);
			Remove(GameTag.ATK);
			Remove(GameTag.HEALTH);
			Remove(GameTag.COST);
			Remove(GameTag.TAUNT);
			Remove(GameTag.FROZEN);
			Remove(GameTag.ENRAGED);
			Remove(GameTag.CHARGE);
			Remove(GameTag.WINDFURY);
			Remove(GameTag.DIVINE_SHIELD);
			Remove(GameTag.STEALTH);
			Remove(GameTag.DEATHRATTLE);
			Remove(GameTag.BATTLECRY);
			Remove(GameTag.SILENCED);
			Remove(GameTag.NUM_ATTACKS_THIS_TURN);
			Remove(GameTag.NUM_TURNS_IN_PLAY);
			Remove(GameTag.ATTACKABLE_BY_RUSH);
			Remove(GameTag.GHOSTLY);
		}
	}
}

