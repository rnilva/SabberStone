using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
		public abstract GameTag Tag { get; }

		public abstract void ApplyTo(Entity entity);
		public abstract void RemoveFrom(Entity entity);
		public abstract void ApplyTo(Playable playable);
		public abstract void RemoveFrom(Playable playable);
		public abstract void ApplyTo(Character character);
		public abstract void RemoveFrom(Character character);
		public abstract void ApplyTo(HeroInPlay hero);
		public abstract void RemoveFrom(HeroInPlay hero);
		public abstract void ApplyTo(MinionInPlay minion);
		public abstract void RemoveFrom(MinionInPlay minion);
		public abstract void ApplyTo(Controller controller);
		public abstract void RemoveFrom(Controller controller);

		public virtual AbstractEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}
	}

	public abstract class EntityEffect : AbstractEffect
	{
		#region Overrides of AbstractEffect

		public override void ApplyTo(Playable playable)
		{
			ApplyTo((Entity) playable);
		}

		public override void RemoveFrom(Playable playable)
		{
			RemoveFrom((Entity) playable);
		}

		public override void ApplyTo(Character character)
		{
			ApplyTo((Entity) character);
		}

		public override void RemoveFrom(Character character)
		{
			RemoveFrom((Entity) character);
		}

		public override void ApplyTo(HeroInPlay hero)
		{
			ApplyTo((Entity) hero);
		}

		public override void RemoveFrom(HeroInPlay hero)
		{
			RemoveFrom((Entity) hero);
		}

		public override void ApplyTo(MinionInPlay minion)
		{
			ApplyTo((Entity) minion);
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			RemoveFrom((Entity) minion);
		}

		public override void ApplyTo(Controller controller)
		{
			ApplyTo((Entity) controller);
		}

		public override void RemoveFrom(Controller controller)
		{
			RemoveFrom((Entity) controller);
		}
		#endregion
	}
	public abstract class PlayableEffect : AbstractEffect
	{
		#region Overrides of AbstractEffect
		public override void ApplyTo(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Character character)
		{
			ApplyTo((Playable) character);
		}

		public override void RemoveFrom(Character character)
		{
			RemoveFrom((Playable) character);
		}

		public override void ApplyTo(HeroInPlay hero)
		{
			ApplyTo((Playable) hero);
		}

		public override void RemoveFrom(HeroInPlay hero)
		{
			RemoveFrom((Playable) hero);
		}

		public override void ApplyTo(MinionInPlay minion)
		{
			ApplyTo((Playable) minion);
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			RemoveFrom((Playable) minion);
		}

		public override void ApplyTo(Controller controller)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Controller controller)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
	public abstract class CharacterEffect : AbstractEffect
	{
		#region Overrides of AbstractEffect
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void ApplyTo(Entity entity)
		{
			throw new NotImplementedException();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void RemoveFrom(Entity entity)
		{
			throw new NotImplementedException();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void ApplyTo(Playable playable)
		{
			throw new NotImplementedException();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void RemoveFrom(Playable playable)
		{
			throw new NotImplementedException();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void ApplyTo(HeroInPlay hero)
		{
			ApplyTo((Character) hero);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void RemoveFrom(HeroInPlay hero)
		{
			RemoveFrom((Character) hero);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void ApplyTo(MinionInPlay minion)
		{
			ApplyTo((Character) minion);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void RemoveFrom(MinionInPlay minion)
		{
			RemoveFrom((Character) minion);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void ApplyTo(Controller controller)
		{
			throw new NotImplementedException();
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void RemoveFrom(Controller controller)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
	public abstract class HeroInPlayEffect : AbstractEffect
	{
		#region Overrides of AbstractEffect
		public override void ApplyTo(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Playable playable)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Playable playable)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Character character)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Character character)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(MinionInPlay minion)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Controller controller)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Controller controller)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
	public abstract class MinionInPlayEffect : AbstractEffect
	{
		#region Overrides of AbstractEffect
		public override void ApplyTo(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Playable playable)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Playable playable)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Character character)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Character character)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(HeroInPlay hero)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(HeroInPlay hero)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Controller controller)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Controller controller)
		{
			throw new NotImplementedException();
		}
		#endregion
	}

	public abstract class ControllerEffect : AbstractEffect
	{
		#region Overrides of AbstractEffect
		public override void ApplyTo(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Entity entity)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Playable playable)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Playable playable)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(Character character)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(Character character)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(HeroInPlay hero)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(HeroInPlay hero)
		{
			throw new NotImplementedException();
		}

		public override void ApplyTo(MinionInPlay minion)
		{
			throw new NotImplementedException();
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			throw new NotImplementedException();
		}

		#endregion
	}

	public class SetChargeEffect : MinionInPlayEffect
	{
		public override GameTag Tag => GameTag.CHARGE;
		public EffectOperator Operator => EffectOperator.SET;
		public int Value => 1;

		public override void ApplyTo(MinionInPlay minion)
		{
			minion.HasCharge = true;
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			minion.HasCharge = false;
		}
	}

	public class SetWindfuryEffect : MinionInPlayEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public override GameTag Tag => GameTag.WINDFURY;

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
	}

	public class SetRushEffect : MinionInPlayEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		public override GameTag Tag => GameTag.RUSH;

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
	}

	public class SetLifestealEffect : PlayableEffect
	{
		public override GameTag Tag => GameTag.LIFESTEAL;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => 1;

		public override void ApplyTo(Playable playable)
		{
			playable.HasLifesteal = true;
		}

		public override void RemoveFrom(Playable playable)
		{
			playable.HasLifesteal = false;
		}
	}

	public class OneTurnControlEffect : MinionInPlayEffect
	{
		public override GameTag Tag => GameTag.CONTROLLER_CHANGED_THIS_TURN;

		private readonly ControlTask _task = new ControlTask(EntityType.SOURCE);

		public override void ApplyTo(MinionInPlay minion)
		{
			_task.Process(minion.Game, minion.Controller.Opponent, minion, null);
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			_task.Process(minion.Game, minion.Controller.Opponent, minion, null);
		}
		public EffectOperator Operator => EffectOperator.SET;
		public int Value => 1;
	}

	public class VaryAttackEffect : CharacterEffect
	{
		private EffectOperator _operator;
		private readonly int _value;

		public VaryAttackEffect(int value)
		{
			_value = value;
		}

		public override GameTag Tag => GameTag.ATK;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => _value;

		public override AbstractEffect ChangeValue(int newValue)
		{
			return Effects.Attack_N(newValue);
		}

		public override void ApplyTo(Character character)
		{
			ref int? target = ref character._v1;
			if (target == null)
				target = character.Card.ATK;
			target += _value;
		}
		public override void RemoveFrom(Character character)
		{
			character._v1 -= _value;
		}
	}

	public class ReduceAttackScriptTagEffect : MinionInPlayEffect
	{
		private readonly int _value;

		public ReduceAttackScriptTagEffect(int value)
		{
			_value = value;
		}

		#region Overrides of AbstractEffect

		public override GameTag Tag => GameTag.ATK;
		public override void ApplyTo(MinionInPlay minion)
		{
			minion._v1 -= _value;
		}

		public override void RemoveFrom(MinionInPlay minion)
		{
			minion._v1 += _value;
		}

		public override AbstractEffect ChangeValue(int newValue)
		{
			return new ReduceAttackScriptTagEffect(newValue);
		}

		#endregion
	}

	public class SetAttackEffect : CharacterEffect
	{
		private readonly int _value;
		private EffectOperator _operator;

		public SetAttackEffect(int value)
		{
			_value = value;
		}

		public override GameTag Tag => GameTag.ATK;

		public EffectOperator Operator => _operator;

		public int Value => _value;

		public override AbstractEffect ChangeValue(int newValue)
		{
			return Effects.SetAttack(newValue);
		}

		public override void ApplyTo(Character character)
		{
			character.AttackDamage = _value;

			// Remove atk one turn effects
			List<(int entityId, AbstractEffect effect)> oneTurnEffects = character.Game.OneTurnEffects;
			for (int i = oneTurnEffects.Count - 1; i >= 0; --i)
			{
				(int id, AbstractEffect eff) = oneTurnEffects[i];
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

	public class MultiplyAttackEffect : CharacterEffect
	{
		private readonly int _value;

		public override GameTag Tag => GameTag.ATK;

		public MultiplyAttackEffect(int value)
		{
			_value = value;
		}

		public override void ApplyTo(Character character)
		{
			character.AttackDamage *= _value;
		}

		public override void RemoveFrom(Character character)
		{
			
		}
	}

	public class VaryHealthEffect : CharacterEffect
	{
		private readonly int _value;

		public override GameTag Tag => GameTag.HEALTH;

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

		public override AbstractEffect ChangeValue(int newValue)
		{
			return Effects.Health_N(newValue);
		}
	}

	public class SetHealthEffect : CharacterEffect
	{
		private readonly int _value;

		public override GameTag Tag => GameTag.HEALTH;

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

		public override void RemoveFrom(Character character)
		{
			
		}

		public override AbstractEffect ChangeValue(int newValue)
		{
			return Effects.SetMaxHealth(newValue);
		}
	}

	public class MultiplyHealthEffect : CharacterEffect
	{
		private readonly int _value;

		public override GameTag Tag => GameTag.HEALTH;

		public MultiplyHealthEffect(int value)
		{
			_value = value;
		}

		public override void ApplyTo(Character character)
		{
			character.BaseHealth *= _value;
		}

		public override void RemoveFrom(Character character)
		{
			
		}
	}

	public class FreezeEffect : CharacterEffect
	{
		public override GameTag Tag => GameTag.FREEZE;

		public override void ApplyTo(Character character)
		{
			character.IsFrozen = true;
		}

		public override void RemoveFrom(Character character)
		{
			character.IsFrozen = false;
		}
	}

	public class SetUnexhaustedEffect : PlayableEffect
	{
		public override GameTag Tag => GameTag.EXHAUSTED;

		public override void ApplyTo(Playable playable)
		{
			playable.IsExhausted = false;
		}

		public override void RemoveFrom(Playable playable)
		{
			
		}
	}

	public class CardCostsHealth : PlayableEffect
	{
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

		public override GameTag Tag => GameTag.CARD_COSTS_HEALTH;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => 1;
	}

	public class SetEchoEffect : PlayableEffect
	{
		public override GameTag Tag => GameTag.ECHO;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => 1;

		public override void ApplyTo(Playable playable)
		{
			playable.IsEcho = true;
		}

		public override void RemoveFrom(Playable playable)
		{
			playable.IsEcho = false;
		}
	}

	public class VaryCost : PlayableEffect
	{ 
		private EffectOperator _operator;
		private int _value;

		public override GameTag Tag => GameTag.COST;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => _value;

		public VaryCost(int value) { _value = value;}

		public override void ApplyTo(Playable playable)
		{
			playable.VaryCost(_value);
		}

		public override void RemoveFrom(Playable playable)
		{
			playable.RemoveCostEffect(_value);
		}
	}

	public class SetCost : PlayableEffect
	{
		private EffectOperator _operator;
		private int _value;

		public override GameTag Tag => GameTag.COST;

		public EffectOperator Operator => EffectOperator.SET;

		public int Value => _value;

		public SetCost(int value) { _value = value;}

		public override void ApplyTo(Playable playable)
		{
			playable.SetCost(_value);
		}

		public override void RemoveFrom(Playable playable)
		{
			playable.RemoveSetCostEffect(_value);
		}
	}

	public class AddIntAttrEffect : CharacterEffect
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

		public override GameTag Tag => _tag;

		public EffectOperator Operator => _operator;

		public int Value => _value;
		public override AbstractEffect ChangeValue(int newValue)
		{
			return new AddIntAttrEffect((IntAttributes) _attr, newValue);
		}
	}

	public class SetIntAttrEffect : CharacterEffect
	{
		private readonly int _attr;

		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public override GameTag Tag => _tag;

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

		public override AbstractEffect ChangeValue(int newValue)
		{
			return new SetIntAttrEffect((IntAttributes) _attr, newValue);
		}
	}

	public class SetBoolAttrEffect : CharacterEffect
	{
		private readonly int _attr;

		private GameTag _tag;
		private EffectOperator _operator;
		private bool _value;

		public override GameTag Tag => _tag;

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

		public override AbstractEffect ChangeValue(int newValue)
		{
			return new SetBoolAttrEffect((BoolAttributes) _attr, newValue > 0);
		}
	}

	public class AddSpellPower : CharacterEffect
	{
		private int _value;

		public override GameTag Tag => GameTag.SPELLPOWER;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => _value;

		public AddSpellPower(int value)
		{
			_value = value;
		}

		public override void ApplyTo(Character character)
		{
			character.GetIntRef((int) IntAttributes.SpellPower) += _value;
		}

		public override void RemoveFrom(Character character)
		{
			character.GetIntRef((int) IntAttributes.SpellPower) -= _value;
		}
	}

	public class AddControllerIntAttr : ControllerEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public override GameTag Tag => _tag;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => 1;

		private readonly ControllerIntAttributes _attr;

		public AddControllerIntAttr(ControllerIntAttributes attr, int value)
		{
			_attr = attr;
			_value = value;
		}

		public override void ApplyTo(Controller controller)
		{
			controller[_attr] += _value;
		}

		public override void RemoveFrom(Controller controller)
		{
			controller[_attr] -= _value;
		}
	}

	public class SetControllerBoolAttr : ControllerEffect
	{
		private GameTag _tag;
		private EffectOperator _operator;
		private int _value;

		public override GameTag Tag => _tag;

		public EffectOperator Operator => EffectOperator.ADD;

		public int Value => 1;

		private readonly ControllerBoolAttributes _attr;

		public SetControllerBoolAttr(ControllerBoolAttributes attr)
		{
			_attr = attr;
		}

		public override void ApplyTo(Controller controller)
		{
			controller[_attr] = true;
		}

		public override void RemoveFrom(Controller controller)
		{
			controller[_attr] = false;
		}
	}

	public class GameTagEffect : EntityEffect
	{
		private readonly GameTag _tag;
		private readonly EffectOperator _operator;
		private readonly int _value;

		public override GameTag Tag => _tag;

		public GameTagEffect(GameTag tag, EffectOperator @operator, int value)
		{
			_tag = tag;
			_operator = @operator;
			_value = value;
		}

		public override void ApplyTo(Entity entity)
		{
			if (entity._data == null)
				entity._data = new EntityData();

			int oldValue = 0;
			if (_operator != EffectOperator.SET)
				entity._data.TryGetValue(_tag, out oldValue);

			switch (_operator)
			{
				case EffectOperator.ADD:
					entity._data[_tag] = oldValue + _value;
					break;
				case EffectOperator.SUB:
					entity._data[_tag] = oldValue - _value;
					break;
				case EffectOperator.MUL:
					entity._data[_tag] = oldValue * _value;
					break;
				case EffectOperator.SET:
					entity._data[_tag] = _value;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public override void RemoveFrom(Entity entity)
		{
			if (entity._data == null)
				return;

			int oldValue = 0;
			if (_operator != EffectOperator.SET)
				entity._data.TryGetValue(_tag, out oldValue);

			switch (_operator)
			{
				case EffectOperator.ADD:
					entity._data[_tag] = oldValue - _value;
					break;
				case EffectOperator.SUB:
					entity._data[_tag] = oldValue + _value;
					break;
				case EffectOperator.MUL:
					break;
				case EffectOperator.SET:
					entity._data[_tag] = 0;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
