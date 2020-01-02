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
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;
using SabberStoneCore.Triggers;

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
		//private readonly TriggerManager.TriggerHandler _updateHandler;
		//private readonly TriggerManager.TriggerHandler _removedHandler;
		private readonly AdaptiveCostEffectTriggerStub _updateHandler;
		private readonly AdaptiveCostEffectEndTurnRemoveTriggerStub _removeHandler;
		//private readonly Trigger _updateTrigger;
		private readonly Action<Game, TriggerStub> _triggerActivator;
		private readonly Action<Game, TriggerStub> _triggerDeactivator;

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

			_triggerActivator = Trigger.GetActivator(trigger);
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

			_triggerActivator = Trigger.GetActivator(trigger);
			_triggerDeactivator = Trigger.GetDeactivator(trigger);
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
					_updateHandler = new AdaptiveCostEffectTriggerStub(this, _triggerSource, _condition);
					_removeHandler = new AdaptiveCostEffectEndTurnRemoveTriggerStub(this);
					_triggerActivator = prototype._triggerActivator;
					_triggerDeactivator = prototype._triggerDeactivator;
					break;
				case Type.TriggeredWithInitialisation:
					_initialisationFunction = prototype._initialisationFunction;
					_cachedValue = _initialisationFunction(owner);
					_costFunction = prototype._costFunction;
					_triggerType = prototype._triggerType;
					_triggerSource = prototype._triggerSource;
					_condition = prototype._condition;
					_updateHandler = new AdaptiveCostEffectTriggerStub(this, _triggerSource, _condition);
					_triggerActivator = prototype._triggerActivator;
					_triggerDeactivator = prototype._triggerDeactivator;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			//_updateHandler = Trigger;
			//_removedHandler = RemoveAtEnd;
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

			_triggerActivator?.Invoke(owner.Game, instance._updateHandler);

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
			_owner.Game.Auras.Remove(this);
			_owner.GetCostManager()?.DeactivateAdaptiveEffect();

			_triggerDeactivator?.Invoke(_owner.Game, _updateHandler);
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

		private enum Type
		{
			Variable,
			Triggered,
			TriggeredWithInitialisation
		}

		private class AdaptiveCostEffectTriggerStub : TriggerStub
		{
			private readonly AdaptiveCostEffect _adaptiveCostEffect;
			private readonly Func<Playable, Entity, bool> _validator;

			public AdaptiveCostEffectTriggerStub(AdaptiveCostEffect effect, TriggerSource source, SelfCondition condition)
			{
				_adaptiveCostEffect = effect;
				_validator = GetValidator(source, condition);
			}

			#region Overrides of TriggerStub

			public override bool Process(Entity source)
			{
				if (_adaptiveCostEffect._isTriggered)
					return true;

				if (!(_validator?.Invoke(_adaptiveCostEffect._owner, source) ?? true))
					return true;

				if (_adaptiveCostEffect._initialisationFunction != null)
					_adaptiveCostEffect._cachedValue += _adaptiveCostEffect._costFunction.Invoke((Playable)source);
				else
				{
					_adaptiveCostEffect._isTriggered = true;

					//_owner.Game.TriggerManager.EndTurnTrigger += _removedHandler;
					source.Game.TriggerManager.EndTurnTrigger.Add(_adaptiveCostEffect._removeHandler);
				}

				return true;
			}

			public override void Remove(Game game)
			{
				throw new NotImplementedException();
			}

			public override void Validate(Entity source)
			{
				
			}

			public override void Invalidate()
			{
				
			}

			public override TriggerStub Clone(Playable owner)
			{
				throw new NotImplementedException();
			}

			public override TriggerStub Combine(Trigger trigger)
			{
				throw new NotImplementedException();
			}

			#endregion

			private static Func<Playable, Entity, bool> GetValidator(TriggerSource source, SelfCondition condition)
			{
				return source == TriggerSource.FRIENDLY
					? condition != null
						? (Func<Playable, Entity, bool>) ((o, s) =>
							o.Controller == s.Controller && condition.Eval(s is Playable p ? p : o))
						: (o, s) => o.Controller == s.Controller
					: condition != null
						? (Func<Playable, Entity, bool>) ((o, s) => condition.Eval(s is Playable p ? p : o))
						: null;
			}
		}

		private class AdaptiveCostEffectEndTurnRemoveTriggerStub : TriggerStub
		{
			private readonly AdaptiveCostEffect _adaptiveCostEffect;
			//private readonly Playable _owner;

			public AdaptiveCostEffectEndTurnRemoveTriggerStub(AdaptiveCostEffect adaptiveCostEffect)
			{
				_adaptiveCostEffect = adaptiveCostEffect;
				//_owner = owner;
			}

			#region Overrides of TriggerStub

			public override bool Process(Entity source)
			{
				_adaptiveCostEffect._owner.GetCostManager()?.UpdateAdaptiveEffect();
				_adaptiveCostEffect._isTriggered = false;
				_adaptiveCostEffect._isAppliedThisTurn = false;
				//_owner.Game.TriggerManager.EndTurnTrigger -= _removedHandler;
				//source.Game.TriggerManager.EndTurnTrigger.Remove(this);
				return false;
			}

			public override void Remove(Game game)
			{
				throw new NotImplementedException();
			}

			public override void Validate(Entity source)
			{
				
			}

			public override void Invalidate()
			{
				
			}

			public override TriggerStub Clone(Playable owner)
			{
				throw new NotImplementedException();
			}

			public override TriggerStub Combine(Trigger trigger)
			{
				throw new NotImplementedException();
			}

			#endregion
		}
	}
}
