﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using SabberStoneCore.Conditions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Enchants
{
	public enum AuraType
	{
		SELF, ADJACENT, BOARD, BOARD_EXCEPT_SOURCE, HAND, OP_HAND, HANDS, CONTROLLER, ADAPTIVE, TARGET, ENRAGE
	}

	public interface IAura
	{
		string EnchantmentCardId { get; }
		void Update();
		void Remove();
		void Clone(IPlayable clone);
	}

	public class AuraEffects
	{
		private class CostEffect : IEquatable<CostEffect>
		{ 
			private readonly Func<int, int> _func;

			public readonly int Hash;

			public CostEffect(Effect e)
			{ 
				switch (e.Operator)
				{
					case EffectOperator.ADD:
						_func = p => p + e.Value;
						Hash = 0;
						break;
					case EffectOperator.SUB:
						_func = p => p >= e.Value ? p - e.Value : 0;
						Hash = 100;
						break;
					case EffectOperator.SET:
						_func = p => e.Value;
						Hash = 1000000;
						break;
					case EffectOperator.MUL:
						throw new NotImplementedException();
				}

				Hash += e.Value;
			}

			public static int GetHash(Effect e)
			{
				return (int)Math.Pow(10, ((int) e.Operator) * 2) + e.Value;
			}

			public int Apply(int c)
			{
				return _func(c);
			}

			public bool Equals(CostEffect other)
			{
				return Hash == other.Hash;
			}
			public override bool Equals(object obj)
			{
				return Equals(obj as CostEffect);
			}
			public override int GetHashCode()
			{
				return Hash;
			}
		}

		private int ATK;
		private int HEALTH;
		private int COST;
		private int SPELLPOWER;
		private int CHARGE;

		private int SPD;
		private int RESTORE_TO_DAMAGE;

		private List<CostEffect> _costEffects;
		private bool Checker { get; set; }

		public AuraEffects(IEntity owner)
		{
			Owner = owner;
			if (owner is IPlayable)
				COST = owner.Card[GameTag.COST];
		}

		public IEntity Owner { get; private set; }

		public int this[GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.ATK:
						return ATK;
					case GameTag.HEALTH:
						return HEALTH;
					case GameTag.CHARGE:
						return CHARGE;
					case GameTag.CURRENT_SPELLPOWER:
						return SPELLPOWER;
					case GameTag.RESTORE_TO_DAMAGE:
						return RESTORE_TO_DAMAGE;
					case GameTag.HERO_POWER_DOUBLE:
					case GameTag.HEALING_DOUBLE:
					case GameTag.SPELLPOWER_DOUBLE:
						return SPD;
					case GameTag.COST:
						return GetCost() - ((Entity) Owner)._data[GameTag.COST];
					default:
						return 0;
				}
			}
			set
			{
				switch (t)
				{
					case GameTag.ATK:
						ATK = value;
						return;
					case GameTag.HEALTH:
						HEALTH = value;
						return;
					case GameTag.CHARGE:
						CHARGE = value;
						return;
					case GameTag.CURRENT_SPELLPOWER:
						SPELLPOWER = value;
						return;
					case GameTag.RESTORE_TO_DAMAGE:
						RESTORE_TO_DAMAGE = value;
						return;
					case GameTag.HERO_POWER_DOUBLE:
					case GameTag.HEALING_DOUBLE:
					case GameTag.SPELLPOWER_DOUBLE:
						SPD = value;
						return;
					case GameTag.COST:
						throw new NotImplementedException();
					default:
						return;
				}
			}
		}

		public void AddCostAura(Effect e)
		{
			Checker = true;

			if (_costEffects == null)
				_costEffects = new List<CostEffect>(1);

			_costEffects.Add(new CostEffect(e));
		}

		public void RemoveCostAura(Effect e)
		{
			Checker = true;
			int hash = CostEffect.GetHash(e);
			for (int i = 0; i < _costEffects.Count; i++)
			{
				if (_costEffects[i].Hash != hash) continue;

				_costEffects.Remove(_costEffects[i]);
				return;
			}

			throw new Exception();
		}

		public int GetCost()
		{
			if (_costEffects == null)
				return COST;

			if (!Checker) return COST;

			int c = Owner.Card[GameTag.COST];
			for (int i = 0; i < _costEffects.Count; i++)
				c = _costEffects[i].Apply(c);
			Debug.WriteLine(c);
			COST = c;
			Checker = false;

			return COST;
		}

		public AuraEffects Clone(IEntity clone)
		{
			return new AuraEffects(clone)
			{
				ATK = ATK,
				HEALTH = HEALTH,
				COST = COST,
				SPELLPOWER = SPELLPOWER,
				CHARGE = CHARGE,
				SPD = SPD,
				RESTORE_TO_DAMAGE = RESTORE_TO_DAMAGE,
				Owner = clone,
				_costEffects = _costEffects != null ? new List<CostEffect>(_costEffects) : null
			};
		}
	}

	public class Aura : IAura
	{
		private readonly int _ownerId;
		private IPlayable _owner;
		private readonly List<int> _appliedEntityIds;
		private List<IPlayable> _appliedEntities;
		private List<IPlayable> _tempList;
		protected bool On = true;
		private bool _toBeUpdated = true;
		private readonly Func<IPlayable, int> _adaptivePredicate;
		private readonly GameTag _adaptiveTag;
		//private Trigger _removeTrigger;
		protected Effect[] Effects;

		public readonly Game Game;
		public readonly AuraType Type;
		public SelfCondition Condition;
		public Func<IPlayable, int> Predicate;
		public (TriggerType Type, SelfCondition Condition) RemoveTrigger;
		public readonly Card EnchantmentCard;
		public bool Restless;


		public Aura(AuraType type, params Effect[] effects)
		{
			Type = type;
			Effects = effects;
		}

		public Aura(AuraType type, string enchantmentId)
		{
			Type = type;
			EnchantmentCard = Cards.FromId(enchantmentId);
		}

		public Aura(Func<IPlayable, int> adaptivePredicate, GameTag adaptiveTag)
		{
			Type = AuraType.ADAPTIVE;
			_adaptivePredicate = adaptivePredicate;
			_adaptiveTag = adaptiveTag;
		}

		protected Aura(Aura prototype, IPlayable owner)
		{
			Type = prototype.Type;
			Effects = prototype.Effects;
			Condition = prototype.Condition;
			Game = owner.Game;
			Restless = prototype.Restless;
			On = prototype.On;
			_appliedEntityIds = prototype._appliedEntityIds != null ? new List<int>(prototype._appliedEntityIds) : new List<int>();
			_owner = owner;
			_ownerId = owner.Id;
			RemoveTrigger = prototype.RemoveTrigger;
		}


		public bool ToBeUpdated
		{
			set => _toBeUpdated = value;
		}
		public IPlayable Owner => _owner ?? (_owner = Game.IdEntityDic[_ownerId]);
		public List<IPlayable> AppliedEntities
		{
			get
			{
				if (_appliedEntities != null)
					return _appliedEntities;
				_appliedEntities = new List<IPlayable>(_appliedEntityIds.Count);
				for (int i = 0; i < _appliedEntityIds.Count; i++)
					_appliedEntities.Add(Game.IdEntityDic[_appliedEntityIds[i]]);
				return _appliedEntities;
			}
		}
		public string EnchantmentCardId => EnchantmentCard?.Id ?? "";


		public virtual void Activate(IPlayable owner, bool cloning = false)
		{
			if (Effects == null)
				Effects = EnchantmentCard.Powers[0].Enchant.Effects;

			var instance = new Aura(this, owner);

			owner.Game.Auras.Add(instance);
			owner.OngoingEffect = instance;

			switch (Type)
			{
				case AuraType.BOARD:
				case AuraType.BOARD_EXCEPT_SOURCE:
				case AuraType.ADJACENT:
					owner.Controller.BoardZone.Auras.Add(instance);
					break;
				case AuraType.HAND:
					owner.Controller.HandZone.Auras.Add(instance);
					break;
				case AuraType.OP_HAND:
					owner.Controller.Opponent.HandZone.Auras.Add(instance);
					break;
			}

			if (RemoveTrigger.Type != TriggerType.NONE)
			{
				switch (RemoveTrigger.Type)
				{
					case TriggerType.CAST_SPELL:
						owner.Game.TriggerManager.CastSpellTrigger += instance.TriggeredRemove;
						break;
				}
			}

			if (cloning || !owner.Game.History) return;

			switch (Type)
			{
				case AuraType.BOARD_EXCEPT_SOURCE:
					_tempList = new List<IPlayable>();
					foreach (Minion minion in (BoardZone)owner.Zone)
					{
						if (minion == owner) continue;
						if (Condition != null && Condition.Eval(minion))
						{
							Enchantment.GetInstance(owner.Controller, owner, minion, EnchantmentCard);
						}

						_tempList.Add(minion);
					}
					break;

			}
		}

		public virtual void Update()
		{
			if (!_toBeUpdated || Type == AuraType.ADAPTIVE) return;

			if (On)
			{
				if (_tempList != null)
				{
					for (int i = 0; i < _tempList.Count; i++)
					{
						var minion = _tempList[i];

						Apply(minion);
					}
				}
				switch (Type)
				{
					case AuraType.BOARD:
						foreach (Minion minion in Owner.Controller.BoardZone)
							Apply(minion);
						break;

					case AuraType.BOARD_EXCEPT_SOURCE:
						foreach (Minion minion in Owner.Controller.BoardZone)
							if (minion != Owner)
								Apply(minion);
						return;

					case AuraType.ADJACENT:
						int pos = Owner.ZonePosition;
						for (int i = 0; i < AppliedEntities.Count; i++)
						{
							if (Math.Abs(pos - AppliedEntities[i].ZonePosition) == 1) continue;

							for (int j = 0; j < Effects.Length; j++)
								Effects[i].Remove(AppliedEntities[i].AuraEffects);
						}
						if (pos > 0)
							Apply(Owner.Controller.BoardZone[pos - 1]);
						if (pos < Owner.Controller.BoardZone.Count - 1)
							Apply(Owner.Controller.BoardZone[pos + 1]);
						break;

					case AuraType.HAND:
						foreach (IPlayable p in Owner.Controller.HandZone)
							Apply(p);
						break;

					case AuraType.OP_HAND:
						foreach (IPlayable p in Owner.Controller.Opponent.HandZone)
							Apply(p);
						break;						
				}
			}
			else
			{
				foreach (IPlayable entity in AppliedEntities)
					for (int i = 0; i < Effects.Length; i++)
					{
						Effects[i].Remove(entity.AuraEffects);
					}

				Game.Auras.Remove(this);
			}

			if (!Restless)
				_toBeUpdated = false;
		}

		public virtual void Remove()
		{
			On = false;
			_toBeUpdated = true;
			Owner.OngoingEffect = null;
		}

		private void TriggeredRemove(IEntity source)
		{
			if (RemoveTrigger.Condition != null && !RemoveTrigger.Condition.Eval((IPlayable)source))
				return;

			Remove();

			switch (RemoveTrigger.Type)
			{
				case TriggerType.CAST_SPELL:
					Game.TriggerManager.CastSpellTrigger -= TriggeredRemove;
					return;
			}

			if (Owner is Enchantment e)
				e.Remove();
		}

		public void EntityRemoved(Minion m)
		{
			if (AppliedEntities.Remove(m))
			{
				_appliedEntityIds.Remove(m.Id);
			}
			else if (m == Owner)
			{
				Remove();
			}
		}

		protected void Apply(IPlayable entity)
		{
			if (_appliedEntityIds.Contains(entity.Id))
			{
				if (!Restless || Condition.Eval(entity)) return;

				for (int i = 0; i < Effects.Length; i++)
					Effects[i].Remove(entity.AuraEffects);

				_appliedEntityIds.Remove(entity.Id);
				AppliedEntities.Remove(entity);

				return;
			}

			if (Condition != null)
				if (!Condition.Eval(entity))
					return;

			if (Predicate != null)
			{
				var effect = new Effect(Effects[0].Tag, Effects[0].Operator, Predicate(entity));
				effect.Apply(entity.AuraEffects);
			}
			else
				for (int i = 0; i < Effects.Length; i++)
					Effects[i].Apply(entity.AuraEffects);

			// history

			AppliedEntities.Add(entity);
			_appliedEntityIds.Add(entity.Id);
		}

		public virtual void Clone(IPlayable clone)
		{
			Activate(clone, true);
		}
	}

	public class AdaptiveEffect : Aura
	{
		private readonly Func<IPlayable, int> _predicate;
		private readonly GameTag _tag;
		private readonly EffectOperator _operator;
		private int _lastValue;

		public AdaptiveEffect(GameTag tag, EffectOperator @operator, Func<IPlayable, int> predicate) : base(AuraType.SELF)
		{
			_predicate = predicate;
			_tag = tag;
			_operator = @operator;
		}

		private AdaptiveEffect(AdaptiveEffect prototype, IPlayable owner) : base(prototype, owner)
		{
			_predicate = prototype._predicate;
			_tag = prototype._tag;
			_operator = prototype._operator;
		}

		public override void Activate(IPlayable owner, bool cloning = false)
		{
			var instance = new AdaptiveEffect(this, owner);

			owner.Game.Auras.Add(instance);
			owner.OngoingEffect = instance;
		}

		public override void Update()
		{
			switch (_operator)
			{
				case EffectOperator.ADD:
				{
					Owner.AuraEffects[_tag] -= _lastValue;
					int val = _predicate(Owner);
					Owner.AuraEffects[_tag] += val;
					_lastValue = val;
					return;
				}
				case EffectOperator.SUB:
				{
					Owner.AuraEffects[_tag] += _lastValue;
					int val = _predicate(Owner);
					Owner.AuraEffects[_tag] -= val;
					_lastValue = val;
					return;
				}
				case EffectOperator.SET:
					_lastValue += Owner.AuraEffects[_tag];
					Owner.AuraEffects[_tag] = 0;
					Owner[_tag] = _predicate(Owner);
					return;
			}
		}

		public override void Remove()
		{
			Owner.OngoingEffect = null;
			Game.Auras.Remove(this);

			switch (_operator)
			{
				case EffectOperator.ADD:
					Owner.AuraEffects[_tag] -= _lastValue;
					return;
				case EffectOperator.SUB:
					Owner.AuraEffects[_tag] += _lastValue;
					return;
				case EffectOperator.SET:
					Owner.AuraEffects[_tag] = _lastValue;
					return;
			}
		}

		public override void Clone(IPlayable clone)
		{
			Activate(clone);
		}
	}

	public class EnrageEffect : Aura
	{
		private bool _enraged;

		public EnrageEffect(AuraType type, params Effect[] effects) : base(type, effects)
		{
		}

		public EnrageEffect(AuraType type, string enchantmentId) : base(type, enchantmentId)
		{
		}

		protected EnrageEffect(Aura prototype, IPlayable owner) : base(prototype, owner)
		{
		}

		public override void Activate(IPlayable owner, bool cloning = false)
		{
			if (owner is Enchantment e)
				owner = (IPlayable)e.Target;

			base.Activate(owner, cloning);

			Restless = true;
		}

		public override void Update()
		{
			var m = Owner as Minion;
			if (!_enraged)
			{
				if (m.Damage == 0) return;
				Apply(m);
				_enraged = true;
			}
			else
			{
				if (m.Damage != 0) return;
				for (int i = 0; i < Effects.Length; i++)
					Effects[i].Remove(m.AuraEffects);
				_enraged = false;
			}

			if (!On)
			{
				Game.Auras.Remove(this);
				if (!_enraged) return;
				for (int i = 0; i < Effects.Length; i++)
					Effects[i].Remove(m.AuraEffects);
			}
		}

		public override void Clone(IPlayable clone)
		{
			Activate(clone, true);
		}
	}
}
