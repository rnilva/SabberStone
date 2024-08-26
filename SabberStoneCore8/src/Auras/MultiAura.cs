using System.Collections;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Enchants;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Auras
{
	/// <summary>
	/// A container class for multiple auras. Use this when you want to implement a <see cref="Power"/> with multiple auras.
	/// </summary>
	public class MultiAura : IAura, IReadOnlyList<IAura>
	{
		private readonly IReadOnlyList<IAura> _auras;

		public Playable Owner { get; set; }
		public bool On { get; set; } = true;

		public MultiAura(params IAura[] auras)
		{
			_auras = auras;
		}

		public bool Update()
		{
			if (!On)
			{
				//Owner.Game.Auras.Remove(this);
				return false;
			}
			
			for (int i = 0; i < _auras.Count; i++)
				_auras[i].Update();
			return true;
		}

		public void Remove()
		{
			On = false;
			if (Owner.OngoingEffect == this)
				Owner.OngoingEffect = null;
			for (int i = 0; i < _auras.Count; i++)
				_auras[i].Remove();
		}

		void IAura.Activate(Playable owner)
		{
			ActivateInternal(owner);
		}

		public void Clone(Playable clone)
		{
			ActivateInternal(clone, true);
		}

		public IEnumerator<IAura> GetEnumerator()
		{
			return _auras.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int Count => _auras.Count;

		public IAura this[int index] => _auras[index];

		public override string ToString()
		{
			var sb = new StringBuilder("[MA:");
			foreach (IAura a in _auras)
				sb.Append($"{{{a}}}");
			sb.Append("]");
			return sb.ToString();
		}

		private void ActivateInternal(Playable owner, bool cloning = false)
		{
			IAura[] auras = new IAura[_auras.Count];

			for (int i = 0; i < _auras.Count; i++)
			{
				if (cloning)
					_auras[i].Clone(owner);
				else
					_auras[i].Activate(owner);
				auras[i] = owner.OngoingEffect;
				owner.Game.Auras.RemoveAt(owner.Game.Auras.Count - 1);
			}

			IAura instance = new MultiAura(auras)
			{
				Owner = owner,
			};
			owner.Game.Auras.Add(instance);
			owner.OngoingEffect = instance;
		}


	}
}
