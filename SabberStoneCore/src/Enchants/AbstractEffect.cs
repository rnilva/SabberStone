using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Auras;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;
using SabberStoneCore.Tasks.SimpleTasks;

#pragma warning disable 169
#pragma warning disable 649

namespace SabberStoneCore.Enchants
{
	public abstract class AbstractEffect
	{
		public virtual void ApplyTo(Playable playable)
		{
			throw new NotImplementedException();
		}
		public virtual void RemoveFrom(Playable playable)
		{
			throw new NotImplementedException();
		}
		public virtual void ApplyTo(Character character)
		{
			throw new NotImplementedException();
		}
		public virtual void RemoveFrom(Character character)
		{
			throw new NotImplementedException();
		}
		public virtual void ApplyTo(HeroInPlay hero)
		{
			throw new NotImplementedException();
		}
		public virtual void RemoveFrom(HeroInPlay hero)
		{
			throw new NotImplementedException();
		}
		public virtual void ApplyTo(MinionInPlay minion)
		{
			throw new NotImplementedException();
		}
		public virtual void RemoveFrom(MinionInPlay minion)
		{
			throw new NotImplementedException();
		}
		//internal static AbstractEffect IEffectToAbstract<T>(GenericEffect<T> eff) where T: Playable
		//{
		//	switch (eff._attr)
		//	{
		//		case ATK atk:
		//			switch (eff._operator)
		//			{
		//				case EffectOperator.ADD:
		//					return Attribte
		//					break;
		//				case EffectOperator.SUB:
		//					break;
		//				case EffectOperator.MUL:
		//					break;
		//				case EffectOperator.SET:
		//					break;
		//				default:
		//					throw new ArgumentOutOfRangeException();
		//			}
		//			break;
		//	}
		//}

		public static AbstractEffect BooleanAttributeEffect(BoolAttributes attr)
		{
//			switch (attr)
//			{
//				case BoolAttributes.Charge:
//
//			}
			return null;
		}
	}

	public class SetChargeEffect : AbstractEffect, IEffect
	{
		public GameTag Tag => GameTag.CHARGE;
		public EffectOperator Operator => EffectOperator.SET;
		public int Value => 1;

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect) => ApplyTo((MinionInPlay) entity);
		void IEffect.RemoveFrom(Entity entity) => RemoveFrom((MinionInPlay) entity);

		IEffect IEffect.ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(MinionInPlay minion)
		{
			minion.HasCharge = true;
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			minion.HasCharge = false;
		}
	}

	public class SetWindfuryEffect : AbstractEffect, IEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public GameTag Tag => GameTag.WINDFURY;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => 1;

		public override void ApplyTo(MinionInPlay minion)
		{
			minion.HasWindfury = true;
			if (minion.NumAttacksThisTurn == 1)
				minion.IsExhausted = false;
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			minion.HasWindfury = false;
			if (!minion.IsExhausted && minion.NumAttacksThisTurn == 1)
				minion.IsExhausted = true;
		}

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((MinionInPlay) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((MinionInPlay) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class SetRushEffect : AbstractEffect, IEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		public GameTag Tag => GameTag.RUSH;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => 1;

		public override void ApplyTo(MinionInPlay minion)
		{
			minion.IsRush = true;
			if (minion.IsExhausted)
			{
				if (minion.HasWindfury)
				{
					if (minion.NumAttacksThisTurn < 2)
					{
						minion.IsExhausted = false;
						minion.AttackableByRush = true;
					}
				}
				else
				{
					if (minion.NumAttacksThisTurn == 0)
					{
						minion.IsExhausted = false;
						minion.AttackableByRush = true;
					}
				}
			}
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			minion.IsRush = false;
		}

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((MinionInPlay) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((MinionInPlay) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class SetLifestealEffect : AbstractEffect, IEffect
	{
		public GameTag Tag => GameTag.LIFESTEAL;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => 1;

		public override void ApplyTo(Playable playable)
		{
			playable.HasLifeSteal = true;
		}

		public override void RemoveFrom(Playable playable)
		{
			playable.HasLifeSteal = false;
		}


		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Playable) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((Playable) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class OneTurnControlEffect : AbstractEffect, IEffect
	{
		private readonly ControlTask _task = new ControlTask(EntityType.SOURCE);

		public override void ApplyTo(MinionInPlay minion)
		{
			_task.Process(minion.Game, minion.Controller.Opponent, minion, null);
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			_task.Process(minion.Game, minion.Controller.Opponent, minion, null);
		}

		#region Implementation of IEffect

		public GameTag Tag => GameTag.CONTROLLER_CHANGED_THIS_TURN;

		public EffectOperator Operator => EffectOperator.SET;
		public int Value => 1;

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((MinionInPlay) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((MinionInPlay) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
		#endregion
	}

	public class VaryAttackEffect : AbstractEffect, IEffect
	{
		private EffectOperator _operator;
		private readonly int _value;

		public VaryAttackEffect(int value)
		{
			_value = value;
		}

		public GameTag Tag => GameTag.ATK;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => _value;

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Character) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((Character) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			return Effects.Attack_N(newValue);
		}

		public override void ApplyTo(Character character)
		{
			character.AttackDamage += _value; 
		}
		public override void RemoveFrom(Character character)
		{
			character.AttackDamage -= Value;
		}
	}

	public class SetAttackEffect : AbstractEffect, IEffect
	{
		private readonly int _value;
		private EffectOperator _operator;

		public SetAttackEffect(int value)
		{
			_value = value;
		}

		public GameTag Tag => GameTag.ATK;

		public EffectOperator Operator => _operator;

		public int Value => _value;

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Character) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((Character) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			return Effects.SetAttack(newValue);
		}

		public override void ApplyTo(Character character)
		{
			character.AttackDamage = _value;

			// Remove atk one turn effects
			List<(int entityId, IEffect effect)> oneTurnEffects = character.Game.OneTurnEffects;
			for (int i = oneTurnEffects.Count - 1; i >= 0; --i)
			{
				(int id, IEffect eff) = oneTurnEffects[i];
				if (id == character.Id && eff.Tag == GameTag.ATK)
					oneTurnEffects.RemoveAt(i);
			}
			// Reapply auras
			if (character.Zone is BoardZone board)
				foreach (Aura aura in board.Auras)
					if (aura.Deregister(character))
						aura.EntityAdded(character);
		}

		public override void RemoveFrom(Character character)
		{
			// Do nothing
		}
	}

	public class VaryHealthEffect : AbstractEffect, IEffect
	{
		private readonly int _value;

		public GameTag Tag => GameTag.HEALTH;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => _value;

		public VaryHealthEffect(int value)
		{
			_value = value;
		}

		public override void ApplyTo(Character character)
		{
			character.BaseHealth += _value;
		}

		public override void RemoveFrom(Character character)
		{
			character.BaseHealth -= _value;
			character.Damage -= _value;
		}

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Character) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((Character) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			return Effects.Health_N(newValue);
		}
	}

	public class SetHealthEffect : AbstractEffect, IEffect
	{
		private readonly int _value;

		public GameTag Tag => GameTag.HEALTH;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => _value;

		public SetHealthEffect(int value)
		{
			_value = value;
		}

		public override void ApplyTo(Character character)
		{
			if (character is Hero h)
			{
				int hbh = h.BaseHealth;
				if (hbh > _value)
					h.Damage = hbh - _value;
				else
					h.Health = _value;
				return;
			}

			if (character is Minion m)
			{
				m.Health = _value;
				return;
			}

			if (character.Zone is BoardZone board)
			{
				foreach (Aura aura in board.Auras)
				{
					if (aura.Deregister(character))
						aura.EntityAdded(character);
				}
			}
		}

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Character) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((Character) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			return Effects.SetMaxHealth(newValue);
		}
	}

	public class AttributeAddEffect : AbstractEffect, IEffect
	{
		public readonly int Attribute;
		public readonly int _value;
		private GameTag _tag;
		private EffectOperator _operator;

		public AttributeAddEffect(IntAttributes attr, int value)
		{
			Attribute = (int)attr;
			_value = value;
		}

		public override void ApplyTo(Character playable)
		{
			playable.GetIntRef(Attribute) += Value;
		}

		public override void RemoveFrom(Character playable)
		{
			playable.GetIntRef(Attribute) -= Value;
		}

		public GameTag Tag => _tag;

		public EffectOperator Operator => _operator;

		public int Value => _value;

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Character) entity).GetIntRef(Attribute) += Value;
		}

		public void RemoveFrom(Entity entity)
		{
			((Character) entity).GetIntRef(Attribute) -= Value;
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class AttributeAddAuraEffect : AbstractEffect
	{
		private readonly int Attribute;
		private readonly int Value;
		public AttributeAddAuraEffect(BoolAttributes attr, int value)
		{
			Attribute = (int)attr;
			Value = value;
		}
	}

	public class AttributeSetEffect : AbstractEffect
	{
		private readonly int _attribute;
		private readonly bool _value;
		public AttributeSetEffect(BoolAttributes attr, bool value)
		{
			_attribute = (int)attr;
			_value = value;
		}
		public override void ApplyTo(Character character)
		{
			character.GetRef(_attribute) = _value;
		}

		public override void RemoveFrom(Character character)
		{
			character.GetRef(_attribute) = !_value;
		}
	}

	public class BooleanAttributeEffect : AbstractEffect
	{
		private readonly int _attribute;
		private readonly bool _value;
		private readonly Action<Character> _afterApplyTask;
	}

	public class CardCostsHealth : AbstractEffect, IEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public override void ApplyTo(Playable playable)
		{
			playable.GetCostManager().CardCostsHealth = true;
		}

		public override void RemoveFrom(Playable playable)
		{
			Playable.CostManager costManager = playable.GetCostManager();
			if (costManager != null)
				costManager.CardCostsHealth = false;
		}

		public GameTag Tag => _tag;

		public EffectOperator Operator => _operator;

		public int Value => _value;

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Playable)entity).GetCostManager().CardCostsHealth = true;
		}

		public void RemoveFrom(Entity entity)
		{
			Playable.CostManager manager = ((Playable) entity).GetCostManager();
			if (manager != null)
				manager.CardCostsHealth = false;
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class SetEchoEffect : AbstractEffect, IEffect
	{
		public GameTag Tag => GameTag.ECHO;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => 1;

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Playable) entity).IsEcho = true;
		}

		public void RemoveFrom(Entity entity)
		{
			((Playable) entity).IsEcho = false;
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class VaryCost : AbstractEffect, IEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public GameTag Tag => GameTag.COST;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => _value;

		public VaryCost(int value) { _value = value;}

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Playable) entity).VaryCost(_value);
		}

		public void RemoveFrom(Entity entity)
		{
			((Playable) entity).RemoveCostEffect(_value);
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class SetCost : AbstractEffect, IEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public GameTag Tag => GameTag.COST;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => _value;

		public SetCost(int value) { _value = value;}

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Playable) entity).SetCost(_value);
		}

		public void RemoveFrom(Entity entity)
		{
			((Playable) entity).RemoveSetCostEffect(_value);
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class AddIntAttrEffect : AbstractEffect, IEffect
	{
		private readonly int _attr;
		private int _value;
		private readonly GameTag _tag;
		private readonly EffectOperator _operator;

		public AddIntAttrEffect(IntAttributes attr, int value)
		{
			_attr = (int) attr;
			_value = value;
			_tag = AttributeHelpers.AttributeToGameTag(attr);
		}

		public override void ApplyTo(Character character)
		{
			character.GetIntRef(_attr) += _value;
		}

		public override void RemoveFrom(Character character)
		{
			character.GetIntRef(_attr) -= _value;
		}

		public GameTag Tag => _tag;

		public EffectOperator Operator => _operator;

		public int Value => _value;

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Character) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((Character) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			return new AddIntAttrEffect((IntAttributes) _attr, newValue);
		}
	}

	public class SetIntAttrEffect : AbstractEffect, IEffect
	{
		private readonly int _attr;

		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public GameTag Tag => _tag;

		public EffectOperator Operator => _operator;

		public int Value => _value;

		public SetIntAttrEffect(IntAttributes attr, int value)
		{
			_attr = (int) attr;
			_value = value;
			_tag = AttributeHelpers.AttributeToGameTag(attr);
		}

		public override void ApplyTo(Character character)
		{
			character.GetIntRef(_attr) = _value;
		}

		public override void RemoveFrom(Character character)
		{
			
		}

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Character) entity);
		}

		public void RemoveFrom(Entity entity)
		{
			
		}

		public IEffect ChangeValue(int newValue)
		{
			return new SetIntAttrEffect((IntAttributes) _attr, newValue);
		}
	}

	public class SetBoolAttrEffect : AbstractEffect, IEffect
	{
		private readonly int _attr;

		private GameTag _tag;
		private EffectOperator _operator;
		private bool _value;

		public GameTag Tag => _tag;

		public EffectOperator Operator => _operator;

		public int Value => _value ? 1 : 0;

		public SetBoolAttrEffect(BoolAttributes attr, bool value)
		{
			_attr = (int) attr;
			_value = value;
			_tag = AttributeHelpers.AttributeToGameTag(attr);
		}

		public override void ApplyTo(Character character)
		{
			character.GetRef(_attr) = _value;
		}

		public override void RemoveFrom(Character character)
		{
			character.GetRef(_attr) = !_value;
		}

		void IEffect.ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			ApplyTo((Character) entity);
		}

		void IEffect.RemoveFrom(Entity entity)
		{
			RemoveFrom((Character) entity);
		}

		public IEffect ChangeValue(int newValue)
		{
			return new SetBoolAttrEffect((BoolAttributes) _attr, newValue > 0);
		}
	}

	public class AddSpellPower : AbstractEffect, IEffect
	{
		private int _value;

		public GameTag Tag => GameTag.SPELLPOWER;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => _value;

		public AddSpellPower(int value)
		{
			_value = value;
		}

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Character) entity).GetIntRef((int) IntAttributes.SpellPower) += _value;
		}

		public void RemoveFrom(Entity entity)
		{
			((Character) entity).GetIntRef((int) IntAttributes.SpellPower) -= _value;
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class AddControllerIntAttr : AbstractEffect, IEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public GameTag Tag => _tag;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => 1;

		private readonly ControllerIntAttributes _attr;

		public AddControllerIntAttr(ControllerIntAttributes attr, int value)
		{
			_attr = attr;
			_value = value;
		}

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Controller)entity)[_attr] += _value;
		}

		public void RemoveFrom(Entity entity)
		{
			((Controller) entity)[_attr] -= _value;
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public class SetControllerBoolAttr : AbstractEffect, IEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public GameTag Tag => _tag;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => 1;

		private readonly ControllerBoolAttributes _attr;

		public SetControllerBoolAttr(ControllerBoolAttributes attr)
		{
			_attr = attr;
		}

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			((Controller)entity)[_attr] = true;
		}

		public void RemoveFrom(Entity entity)
		{
			((Controller) entity)[_attr] = false;
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}
}
