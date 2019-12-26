#region copyright
// SabberStone, Hearthstone Simulator in C# .NET Core
// Copyright (C) 2017-2019 SabberStone Team, darkfriend77 & rnilva
//
// SabberStone is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License.
// SabberStone is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
#endregion
using System;
using System.Text;
using SabberStoneCore.Conditions;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;

// ReSharper disable InconsistentNaming

namespace SabberStoneCore.Auras
{
	/// <summary>
	/// Implementation of the specific effects of varying cost. e.g. Giants
	/// </summary>
	public class AdaptiveCostEffect : IAura
	{
		// Consider make these subclasses
		private readonly Type _type;

		private readonly Playable _owner;
		private readonly int _value;
		private readonly EffectOperator _operator;
		private readonly Func<Playable, int> _costFunction;

		private readonly TriggerType _triggerType;
		private readonly TriggerSource _triggerSource;
		private readonly SelfCondition _condition;
		private readonly TriggerManager.TriggerHandler _updateHandler;
		private readonly TriggerManager.TriggerHandler _removedHandler;

		private readonly Func<Playable, int> _initialisationFunction;
		private int _cachedValue = -1;

		private bool _isTriggered;
		private bool _isAppliedThisTurn;

		/// <summary>
		/// Creates an Adaptive Cost Effect that varies the owner's cost.
		/// (e.g. Giants needs subtraction. They costs less for the calculated value from the given cost function.)
		/// The argument of the cost function is the owner entity.
		/// </summary>
		/// <param name="costFunc">The cost function to calculate the amount the owner costs varies.</param>
		/// <param name="operator">This determines how cost varies.</param>
		/// <param name="condition">The necessary condition for this effect.</param>
		public AdaptiveCostEffect(Func<Playable, int> costFunc, EffectOperator @operator = EffectOperator.SUB,
			SelfCondition condition = null)
		{
			_type = Type.Variable;
			_costFunction = costFunc;
			_operator = @operator;
			_condition = condition;
			IsSetEffect = @operator == EffectOperator.SET;
		}

		/// <summary>
		/// Creates an Adaptive Cost Effect that sets cost of the owner to a specific value
		/// until the end of the turn when the given criterion is satisfied. (e.g. Happy Ghoul, Arcane Tyrant)
		/// </summary>
		/// <param name="value">The value to set.</param>
		/// <param name="trigger">The type of trigger this effect should check.</param>
		/// <param name="triggerSource">The specific type of source entities that can invoke the trigger.</param>
		/// <param name="triggerCondition">Condition to be applied to the source of the trigger.</param>
		public AdaptiveCostEffect(int value, TriggerType trigger,
			TriggerSource triggerSource = TriggerSource.ALL, SelfCondition triggerCondition = null)
		{
			_type = Type.Triggered;
			_value = value;
			_triggerType = trigger;
			_triggerSource = triggerSource;
			_condition = triggerCondition;
			IsSetEffect = true;
		}

		/// <summary>
		/// Creates an Adaptive Cost Effect that reduces cost by
		/// a criterion estimated during the entire game.
		/// </summary>
		/// <param name="initialisationFunction">A function to estimate the accumulated value before activation in hand.</param>
		/// <param name="triggerValueFunction">A function to calculate the value increment when triggered. Argument is the source of the trigger.</param>
		/// <param name="trigger">A type of trigger that affects this effect.</param>
		/// <param name="triggerSource">The source constraint for the trigger.</param>
		/// <param name="triggerCondition">An additional condition for the trigger.</param>
		public AdaptiveCostEffect(Func<Playable, int> initialisationFunction, Func<Playable, int> triggerValueFunction, TriggerType trigger,
			TriggerSource triggerSource = TriggerSource.ALL, SelfCondition triggerCondition = null)
		{
			_type = Type.TriggeredWithInitialisation;
			_initialisationFunction = initialisationFunction;
			_costFunction = triggerValueFunction;
			_triggerType = trigger;
			_triggerSource = triggerSource;
			_condition = triggerCondition;
		}

		private AdaptiveCostEffect(AdaptiveCostEffect prototype, Playable owner)
		{
			_owner = owner;
			_type = prototype._type;
			switch (_type)
			{
				case Type.Variable:
					_costFunction = prototype._costFunction;
					_operator = prototype._operator;
					_condition = prototype._condition;
					IsSetEffect = prototype.IsSetEffect;
					return;
				case Type.Triggered:
					_value = prototype._value;
					_triggerType = prototype._triggerType;
					_triggerSource = prototype._triggerSource;
					_condition = prototype._condition;
					IsSetEffect = true;
					break;
				case Type.TriggeredWithInitialisation:
					_initialisationFunction = prototype._initialisationFunction;
					_cachedValue = _initialisationFunction(owner);
					_costFunction = prototype._costFunction;
					_triggerType = prototype._triggerType;
					_triggerSource = prototype._triggerSource;
					_condition = prototype._condition;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_updateHandler = Trigger;
			_removedHandler = RemoveAtEnd;
			_isTriggered = prototype._isTriggered;
			_isAppliedThisTurn = prototype._isAppliedThisTurn;
		}

		public Playable Owner => _owner;

		public bool IsSetEffect { get; }

		public void Activate(Playable owner, bool cloning = false)
		{
			if (!cloning && !(owner.Zone is HandZone)) return;

			var instance = new AdaptiveCostEffect(this, owner);

			owner.GetCostManager().ActivateAdaptiveEffect(instance);
			owner.OngoingEffect = instance;

			switch (_triggerType)
			{
				case TriggerType.NONE:
					break;
				case TriggerType.HEAL:
					owner.Game.TriggerManager.HealTrigger += instance._updateHandler;
					break;
				case TriggerType.DEATH:
					owner.Game.TriggerManager.DeathTrigger += instance._updateHandler;
					break;
				case TriggerType.CAST_SPELL:
					owner.Game.TriggerManager.CastSpellTrigger += instance._updateHandler;
					break;
				case TriggerType.AFTER_CAST:
					owner.Game.TriggerManager.AfterCastTrigger += instance._updateHandler;
					break;
				case TriggerType.TURN_START:
					owner.Game.TriggerManager.TurnStartTrigger += instance._updateHandler;
					break;
				case TriggerType.ZONE:
					owner.Game.TriggerManager.ZoneTrigger += instance._updateHandler;
					break;
				case TriggerType.OVERLOAD:
					owner.Game.TriggerManager.OverloadTrigger += instance._updateHandler;
					break;
				default:
					throw new NotImplementedException();
			}

			owner.Game.Auras.Add(instance);
		}

		public bool Apply(ref int value)
		{
			if (_initialisationFunction != null)
			{
				value += _cachedValue;
				return true;
			}

			if (_costFunction != null && (_condition == null || _condition.Eval(_owner)))
			{
				if (_operator == EffectOperator.SUB)
					value -= _costFunction.Invoke(_owner);
				else if (_operator == EffectOperator.SET)
					value = _costFunction.Invoke(_owner);
				else if (_operator == EffectOperator.ADD)
					value += _costFunction.Invoke(_owner);
				else
					value *= _costFunction.Invoke(_owner);
				return true;
			}

			if (_isAppliedThisTurn)
			{
				value = _value;
				return true;
			}

			return false;
		}

		public void Remove()
		{
			_owner.OngoingEffect = null;
			_owner.Game.Auras.Remove(this);
			_owner.GetCostManager()?.DeactivateAdaptiveEffect();

			switch (_triggerType)
			{
				case TriggerType.NONE:
					break;
				case TriggerType.HEAL:
					_owner.Game.TriggerManager.HealTrigger -= _updateHandler;
					break;
				case TriggerType.DEATH:
					_owner.Game.TriggerManager.DeathTrigger -= _updateHandler;
					break;
				case TriggerType.CAST_SPELL:
					_owner.Game.TriggerManager.CastSpellTrigger -= _updateHandler;
					break;
				case TriggerType.AFTER_CAST:
					_owner.Game.TriggerManager.AfterCastTrigger -= _updateHandler;
					break;
				case TriggerType.TURN_START:
					_owner.Game.TriggerManager.TurnStartTrigger -= _updateHandler;
					break;
				case TriggerType.ZONE:
					_owner.Game.TriggerManager.ZoneTrigger -= _updateHandler;
					break;
				case TriggerType.OVERLOAD:
					_owner.Game.TriggerManager.OverloadTrigger -= _updateHandler;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		void IAura.Activate(Playable owner)
		{
			Activate(owner, false);
		}

		public bool Update()
		{
			if (_triggerType != TriggerType.NONE)
			{
				if (_initialisationFunction != null)
				{
					_owner.GetCostManager().UpdateAdaptiveEffect(_cachedValue);
					return true;
				}

				if (!_isTriggered) return true;

				if (_isAppliedThisTurn) return true;

				_owner.GetCostManager().UpdateAdaptiveEffect();

				_isAppliedThisTurn = true;
			}
			else
				_owner.GetCostManager().UpdateAdaptiveEffect();

			return true;
		}

		public void Clone(Playable clone)
		{
			Activate(clone, true);
		}

		public override string ToString()
		{
			var sb = new StringBuilder("[ACE:");
			sb.Append(Owner.Card.Name);
			sb.Append("]");
			return sb.ToString();
		}

		public static readonly AdaptiveCostEffect NumEachMinionDiedThisTurn
			= new AdaptiveCostEffect(p => p.Controller.NumFriendlyMinionsThatDiedThisTurn
			                              + p.Controller.Opponent.NumFriendlyMinionsThatDiedThisTurn);

		private void Trigger(Entity sender)
		{
			if (_isTriggered)
				return;

			switch (_triggerSource)
			{
				case TriggerSource.FRIENDLY when sender.Controller != Owner.Controller:
					return;
				case TriggerSource.ALL:
				case TriggerSource.FRIENDLY:
					break;
				default:
					throw new NotImplementedException();
			}

			if (_condition != null)
			{
				if (!(sender is Playable p)) p = _owner;

				if (!_condition.Eval(p)) return;
			}

			if (_initialisationFunction != null)
				_cachedValue += _costFunction.Invoke((Playable)sender);
			else
			{
				_isTriggered = true;

				_owner.Game.TriggerManager.EndTurnTrigger += _removedHandler;
			}
		}

		private void RemoveAtEnd(Entity sender)
		{
			_owner.GetCostManager()?.UpdateAdaptiveEffect();
			_isTriggered = false;
			_isAppliedThisTurn = false;
			_owner.Game.TriggerManager.EndTurnTrigger -= _removedHandler;
		}

		private enum Type
		{
			Variable,
			Triggered,
			TriggeredWithInitialisation
		}
	}
}
