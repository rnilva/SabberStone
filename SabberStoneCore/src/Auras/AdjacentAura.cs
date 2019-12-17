using System.Collections.Generic;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;
// ReSharper disable ObjectCreationAsStatement

namespace SabberStoneCore.Auras
{
	public class AdjacentAura : IAura
	{
		private MinionInPlay _left;
		private MinionInPlay _right;
		private bool _toBeRemoved;

		private readonly IEffect[] _effects;
		private readonly MinionInPlay _owner; 
		private readonly BoardZone _board;
		private readonly bool _history;

		public readonly Card EnchantmentCard;

		public Playable Owner => _owner;
		public bool BoardChanged { get; set; }

		public MinionInPlay[] AppliedEntities =>
			_left != null ? _right != null ? new[] {_left, _right} :
			new[] {_left} :
			_right != null ? new[] {_right} : new MinionInPlay[0];

		public AdjacentAura(params IEffect[] effects)
		{
			_effects = effects;
		}

		public AdjacentAura(string enchantmentId)
		{
			EnchantmentCard = Cards.FromId(enchantmentId);
			//_effects = EnchantmentCard.Power.Enchant.Effects;
		}

		private AdjacentAura(AdjacentAura prototype, MinionInPlay owner, bool cloning) : this()
		{
			EnchantmentCard = prototype.EnchantmentCard;
			_effects = prototype._effects ?? EnchantmentCard.Power.Enchant.Effects;
			_owner = owner;
			_history = owner.Game.History;
			owner.OngoingEffect = this;
			owner.Game.Auras.Add(this);
			_board = owner.Controller.BoardZone;
			_board.AdjacentAuras.Add(this);

			if (cloning)
			{
				if (prototype._left != null)
					_left = (MinionInPlay)owner.Game.IdEntityDic[prototype._left.Id];
				if (prototype._right != null)
					_right = (MinionInPlay)owner.Game.IdEntityDic[prototype._right.Id];
			}
		}

		public bool Update()
		{
			if (_toBeRemoved)
			{
				if (_left != null)
					DeApply(_left);
				if (_right != null)
					DeApply(_right);
				_owner.OngoingEffect = null;
				//_owner.Game.Auras.Remove(this);
				_board.AdjacentAuras.Remove(this);
				return false;
			}

			if (!BoardChanged) return true;

			int pos = _owner.ZonePosition;

			// Check left-side
			if (_left != null)
			{
				if (_left.Zone?.Type != Zone.PLAY || _left.ZonePosition != pos - 1)
				{
					DeApply(_left);
					_left = null;
				}
			}
			if (_left == null && pos > 0)
			{
				MinionInPlay left = _board[pos - 1];
				if (!left.Untouchable)
				{
					Apply(left);
					_left = left;
				}
			}

			// Check right-side
			if (_right != null)
			{
				if (_right.Zone?.Type != Zone.PLAY || _right.ZonePosition != pos + 1)
				{
					DeApply(_right);
					_right = null;
				}
			}
			if (_right == null && pos < _board.Count - 1)
			{
				MinionInPlay right = _board[pos + 1];
				if (!right.Untouchable)
				{
					Apply(right);
					_right = right;
				}
			}

			BoardChanged = false;
			return true;
		}

		public void Remove()
		{
			_toBeRemoved = true;
		}

		public void Clone(Playable clone)
		{
			new AdjacentAura(this, (MinionInPlay) clone, true);
		}

		void IAura.Activate(Playable owner)
		{
			new AdjacentAura(this, (MinionInPlay) owner, false);
		}

		private void Apply(MinionInPlay m)
		{
			for (int i = 0; i < _effects.Length; i++)
				_effects[i].ApplyTo(m);

			if (EnchantmentCard != null && _history)
			{
				Enchantment.GetInstance(m.Controller, _owner, m, in EnchantmentCard);
				for (int i = 0; i < _effects.Length; i++)
					_owner.Game.PowerHistory.Add(
						PowerHistoryBuilder.TagChange(_owner.Id, _effects[i].Tag, _owner[_effects[i].Tag]));
			}
		}

		internal void DeApply(MinionInPlay m, bool ignoreEnchantments = false)
		{
			for (int i = 0; i < _effects.Length; i++)
				_effects[i].RemoveFrom(m);

			if (ignoreEnchantments) return;

			if (EnchantmentCard != null && (_history || EnchantmentCard.Power.Trigger != null))
			{
				int cardId = EnchantmentCard.AssetId;
				List<Enchantment> enchantments = m.AppliedEnchantments;
				for (int i = enchantments.Count - 1; i >= 0; i--)
					if (enchantments[i].Creator == _owner && enchantments[i].Card.AssetId == cardId)
					{
						enchantments.RemoveAt(i);
						break;
					}

				if (_history)
					for (int i = 0; i < _effects.Length; i++)
						_owner.Game.PowerHistory.Add(
							PowerHistoryBuilder.TagChange(_owner.Id, _effects[i].Tag, _owner[_effects[i].Tag]));
			}
		}

		public override string ToString()
		{
			return $"[AdjAura:{_owner}]";
		}
	}
}
