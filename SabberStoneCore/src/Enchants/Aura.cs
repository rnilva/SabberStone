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
		SELF,
		ADJACENT,
		BOARD,
		BOARD_EXCEPT_SOURCE,
		HAND,
		OP_HAND,
		HANDS,
		CONTROLLER,
		CONTROLLERS,
		ADAPTIVE,
		TARGET,
		WEAPON
	}

	public interface IAura
	{
		void Update();
		void Remove();
		void Clone(IPlayable clone);
	}

	public class Aura : IAura
	{
		private readonly int _ownerId;
		private IPlayable _owner;
		//private readonly List<int> _appliedEntityIds;
		private readonly HashSet<int> _appliedEntityIds;
		private List<IPlayable> _appliedEntities;
		private List<IPlayable> _tempList;
		protected bool On = true;
		private bool _toBeUpdated = true;
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

		protected Aura(Aura prototype, IPlayable owner)
		{
			Type = prototype.Type;
			Effects = prototype.Effects;
			Condition = prototype.Condition;
			Predicate = prototype.Predicate;
			RemoveTrigger = prototype.RemoveTrigger;
			EnchantmentCard = prototype.EnchantmentCard;
			Restless = prototype.Restless;
			On = prototype.On;
			//_appliedEntityIds = prototype._appliedEntityIds != null ? new List<int>(prototype._appliedEntityIds) : new List<int>();
			_appliedEntityIds = prototype._appliedEntityIds != null
				? new HashSet<int>(prototype._appliedEntityIds)
				: new HashSet<int>();

			Game = owner.Game;
			_owner = owner;
			_ownerId = owner.Id;
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
				//for (int i = 0; i < _appliedEntityIds.Count; i++)
				//	_appliedEntities.Add(Game.IdEntityDic[_appliedEntityIds[i]]);
				foreach (int id in _appliedEntityIds)
					_appliedEntities.Add(Game.IdEntityDic[id]);
				return _appliedEntities;
			}
		}


		public virtual void Activate(IPlayable owner, bool cloning = false)
		{
			if (Effects == null)
				Effects = EnchantmentCard.Power.Enchant.Effects;

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
				case AuraType.HANDS:
					owner.Controller.HandZone.Auras.Add(instance);
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
					case TriggerType.TURN_END:
						owner.Game.TriggerManager.EndTurnTrigger += instance.TriggeredRemove;
						break;
				}
			}

			if (cloning || !owner.Game.History) return;

			if (EnchantmentCard == null) return;

			switch (Type)
			{
				case AuraType.BOARD_EXCEPT_SOURCE:
					_tempList = new List<IPlayable>();
					foreach (Minion minion in (BoardZone)owner.Zone)
					{
						if (minion == owner) continue;
						if (Condition == null || Condition.Eval(minion))
							Enchantment.GetInstance(owner.Controller, owner, minion, EnchantmentCard);

						_tempList.Add(minion);
					}
					break;
				case AuraType.BOARD:
					_tempList = new List<IPlayable>();
					foreach (Minion minion in (BoardZone)owner.Zone)
					{
						if (Condition == null || Condition.Eval(minion))
							Enchantment.GetInstance(owner.Controller, owner, minion, EnchantmentCard);

						_tempList.Add(minion);
					}
					break;

			}
		}

		public virtual void Update()
		{
			if (!_toBeUpdated) return;

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
					case AuraType.HANDS:
						foreach (IPlayable p in Owner.Controller.HandZone)
							Apply(p);
						foreach (IPlayable p in Owner.Controller.Opponent.HandZone)
							Apply(p);
						break;
					case AuraType.WEAPON:
						if (Owner.Controller.Hero.Weapon == null) break;
						Apply(Owner.Controller.Hero.Weapon);
						break;
					case AuraType.CONTROLLER:
						for (int i = 0; i < Effects.Length; i++)
							Effects[i].Apply(Owner.Controller.ControllerAuraEffects);
						break;
					case AuraType.CONTROLLERS:
						for (int i = 0; i < Effects.Length; i++)
						{
							Effects[i].Apply(Owner.Controller.ControllerAuraEffects);
							Effects[i].Apply(Owner.Controller.Opponent.ControllerAuraEffects);
						}
						break;
				}

				if (!Restless)
					_toBeUpdated = false;
			}
			else
			{
				// Remove effects from applied entities
				switch (Type)
				{
					case AuraType.CONTROLLER:
						for (int i = 0; i < Effects.Length; i++)
							Effects[i].Remove(Owner.Controller.ControllerAuraEffects);
						break;
					case AuraType.CONTROLLERS:
						for (int i = 0; i < Effects.Length; i++)
						{
							Effects[i].Remove(Owner.Controller.ControllerAuraEffects);
							Effects[i].Remove(Owner.Controller.Opponent.ControllerAuraEffects);
						}
						break;
					default:
						foreach (IPlayable entity in AppliedEntities)
						{
							if (Predicate != null)
							{
								var effect = new Effect(Effects[0].Tag, Effects[0].Operator, Predicate(entity));
								effect.Remove(entity.AuraEffects);
								continue;
							}

							for (int i = 0; i < Effects.Length; i++)
								Effects[i].Remove(entity.AuraEffects);
						}

						break;
				}

				Game.Auras.Remove(this);

				// Remove enchantments from applied entities
				if (EnchantmentCard != null && (Game.History || EnchantmentCard.Power.Trigger != null))
					foreach (IPlayable entity in AppliedEntities)
						for (int i = entity.AppliedEnchantments.Count - 1; i >= 0; i--)
							if (entity.AppliedEnchantments[i].Creator.Id == _ownerId)
								entity.AppliedEnchantments[i].Remove();
			}
		}

		public virtual void Remove()
		{
			On = false;
			_toBeUpdated = true;
			Owner.OngoingEffect = null;

			switch (RemoveTrigger.Type)
			{
				case TriggerType.CAST_SPELL:
					Game.TriggerManager.CastSpellTrigger -= TriggeredRemove;
					return;
				case TriggerType.TURN_END:
					Game.TriggerManager.EndTurnTrigger -= TriggeredRemove;
					break;
			}

			if (Owner is Enchantment e)
				e.Remove();
		}

		private void TriggeredRemove(IEntity source)
		{
			if (RemoveTrigger.Condition != null)
			{
				if (source is Controller)
					source = Owner;
				if (!RemoveTrigger.Condition.Eval((IPlayable)source))
					return;
			}

			Remove();
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

			if (EnchantmentCard != null)
			{
				if (Game.History || EnchantmentCard.Power.Trigger != null)
				{
					Enchantment instance = Enchantment.GetInstance(entity.Controller, Owner, entity, EnchantmentCard);
					EnchantmentCard.Power.Trigger?.Activate(instance);
					if (entity.AppliedEnchantments == null)
						entity.AppliedEnchantments = new List<Enchantment> {instance};
					else
						entity.AppliedEnchantments.Add(instance);
				}
			}

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
		//private readonly Func<IPlayable, int> _predicate;
		private readonly GameTag _tag;
		private readonly EffectOperator _operator;
		private int _lastValue;

		public AdaptiveEffect(GameTag tag, EffectOperator @operator, Func<IPlayable, int> predicate) : base(AuraType.ADAPTIVE)
		{
			Predicate = predicate;
			_tag = tag;
			_operator = @operator;
		}

		private AdaptiveEffect(AdaptiveEffect prototype, IPlayable owner) : base(prototype, owner)
		{
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
					int val = Predicate(Owner);
					Owner.AuraEffects[_tag] += val;
					_lastValue = val;
					return;
				}
				case EffectOperator.SUB:
				{
					Owner.AuraEffects[_tag] += _lastValue;
					int val = Predicate(Owner);
					Owner.AuraEffects[_tag] -= val;
					_lastValue = val;
					return;
				}
				case EffectOperator.SET:
					_lastValue += Owner.AuraEffects[_tag];
					Owner.AuraEffects[_tag] = 0;
					Owner[_tag] = Predicate(Owner);
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

	public class AdaptiveCostEffect : Aura
	{
		private EffectOperator _operator;

		public AdaptiveCostEffect(EffectOperator @operator, Func<IPlayable, int> predicate) : base(AuraType.ADAPTIVE)
		{
			Predicate = predicate;
			_operator = @operator;
		}

		private AdaptiveCostEffect(AdaptiveCostEffect prototype, IPlayable owner) : base(prototype, owner)
		{
			_operator = prototype._operator;
		}

		public override void Activate(IPlayable owner, bool cloning = false)
		{
			var instance = new AdaptiveCostEffect(this, owner);

			owner.AuraEffects.AdaptiveCostEffect = instance;
			owner.OngoingEffect = instance;
			owner.Game.Auras.Add(instance);
		}

		public int Apply(int value)
		{
			switch (_operator)
			{
				case EffectOperator.ADD:
					return value + Predicate(Owner);
				case EffectOperator.SUB:
					return value - Predicate(Owner);
				case EffectOperator.SET:
					return value;
				case EffectOperator.MUL:
					return value * Predicate(Owner);
			}

			return 0;
		}

		public override void Remove()
		{
			Owner.AuraEffects.AdaptiveCostEffect = null;
			Owner.OngoingEffect = null;
		}

		public override void Update()
		{
			Owner.AuraEffects.Checker = true;
		}

		public override void Clone(IPlayable clone)
		{
			Activate(clone);
		}

	}

	public class EnrageEffect : Aura
	{
		private bool _enraged;
		private IPlayable _target;

		public EnrageEffect(AuraType type, params Effect[] effects) : base(type, effects)
		{
		}

		//public EnrageEffect(AuraType type, string enchantmentId) : base(type, enchantmentId)
		//{
		//}

		private EnrageEffect(EnrageEffect prototype, IPlayable owner) : base(prototype, owner)
		{
			_enraged = prototype._enraged;
			Restless = true;            //	can cause performance issue; should replace with heal trigger ?
			switch (Type)
			{
				case AuraType.SELF:
					_target = owner;
					break;
				case AuraType.WEAPON:
					_target = owner.Controller.Hero.Weapon;
					break;
			}
		}

		public override void Activate(IPlayable owner, bool cloning = false)
		{
			if (owner is Enchantment e)
				owner = (IPlayable)e.Target;

			var instance = new EnrageEffect(this, owner);

			owner.Game.Auras.Add(instance);
			owner.OngoingEffect = instance;
		}

		public override void Update()
		{
			var m = Owner as Minion;

			if (Type == AuraType.WEAPON)
				_target = m.Controller.Hero.Weapon;

			if (!On)
			{
				Game.Auras.Remove(this);
				if (!_enraged) return;
				if (_target != null)
					for (int i = 0; i < Effects.Length; i++)
						Effects[i].Remove(_target.AuraEffects);
			}

			if (!_enraged)
			{
				if (m.Damage == 0) return;
				if (_target != null)
					for (int i = 0; i < Effects.Length; i++)
						Effects[i].Apply(_target.AuraEffects);
				_enraged = true;
			}
			else
			{
				if (m.Damage != 0) return;
				if (_target != null)
					for (int i = 0; i < Effects.Length; i++)
						Effects[i].Remove(_target.AuraEffects);
				_enraged = false;
			}
		}

		public override void Clone(IPlayable clone)
		{
			Activate(clone, true);
		}
	}
}
