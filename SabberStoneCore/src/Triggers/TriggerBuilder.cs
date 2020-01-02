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
using SabberStoneCore.Conditions;
using SabberStoneCore.Enums;
using SabberStoneCore.Tasks;

namespace SabberStoneCore.Triggers
{
	/// <summary>
	/// Builder class for <see cref="Trigger"/>s.
	/// </summary>
	public static class TriggerBuilder
	{
		/// <summary>
		/// Starts a new Trigger builder for creating a <see cref="Trigger"/>
		/// of a specified <see cref="TriggerType"/>.
		/// </summary>
		/// <param name="type">The type of a trigger. Type determines the timing of a trigger.</param>
		/// <returns></returns>
		public static TriggerTaskBuilder Type(TriggerType type)
		{
			return new TriggerTaskBuilder(type);
		}

		public class TriggerTaskBuilder
		{
			/// <summary>
			/// Set a <see cref="SimpleTask"/> for the trigger.
			/// Consider <see cref="ComplexTask.Create(SimpleTask[])"/> for multiple tasks.
			/// </summary>
			public TriggerPropertyBuilder SetTask(SimpleTask task)
			{
				return new TriggerPropertyBuilder(_type, task);
			}

			/// <summary>
			/// Set a sequence of tasks for the trigger of Secret cards.
			/// This will automatically resolves the disposal of Secrets.
			/// </summary>
			public TriggerPropertyBuilder SetSecretTasks(params SimpleTask[] tasks)
			{
				return new TriggerPropertyBuilder(_type, ComplexTask.Secret(tasks));
			}

			private readonly TriggerType _type;
			internal TriggerTaskBuilder(TriggerType type)
			{
				_type = type;
			}
		}

		public class TriggerPropertyBuilder
		{
			/// <summary>
			/// Sets the location of activation for this trigger.
			/// Triggers start reacting to events after the activation.
			/// Example) Corridor Creeper's Activation should be Hand.
			/// </summary>
			public TriggerPropertyBuilder SetActivation(TriggerActivation activation)
			{
				_activation = activation;
				return this;
			}

			/// <summary>
			/// Sets the type of the source of this trigger.
			/// <see cref="TriggerSource"/> specifies which kind of entities
			/// this trigger should be react.
			/// Example) Acolyte of Pain's Source should be SELF.
			/// </summary>
			public TriggerPropertyBuilder SetSource(TriggerSource source)
			{
				_source = source;
				return this;
			}

			/// <summary>
			/// Sets an additional condition that the owner of this trigger
			/// should satisfy when the corresponding event for this trigger happens.
			/// </summary>
			public TriggerPropertyBuilder SetCondition(SelfCondition condition)
			{
				_condition = condition;
				return this;
			}

			/// <summary> 
			/// This option is only meaningful when this the type of this trigger is
			/// <see cref="TriggerType.TURN_END"/> or <see cref="TriggerType.TURN_START"/>.
			/// True means the effect can be triggered at both player's turn.
			/// </summary>
			public TriggerPropertyBuilder SetEitherTurn()
			{
				_eitherTurn = true;
				return this;
			}

			/// <summary>
			/// Makes this trigger to run the task immediately without queueing.
			/// Use this option only when this trigger should have a priority over
			/// other triggers with the same type.
			/// </summary>
			/// <returns></returns>
			public TriggerPropertyBuilder SetFastExecution()
			{
				_fastExecution = true;
				return this;
			}

			/// <summary>
			/// Makes this trigger to be immediately deactivated and disposed
			/// after the first time it is triggered.
			/// </summary>
			public TriggerPropertyBuilder SetRemoveAfterTriggered()
			{
				_removeAfterTriggered = true;
				return this;
			}

			/// <summary>
			/// Ends this builder and gets the resulting <see cref="Trigger"/>.
			/// </summary>
			public Trigger GetTrigger()
			{
				var trigger = new Trigger(_type, _source, _condition,_eitherTurn)
				{
					TriggerActivation = _activation,
					SingleTask = _task,
					RemoveAfterTriggered = _removeAfterTriggered
				};
				trigger.FastExecution |= _fastExecution;
				return trigger;
			}

			
			public static implicit operator Trigger(TriggerPropertyBuilder builder)
			{
				return builder.GetTrigger();
			}

			private readonly TriggerType _type;
			private readonly SimpleTask _task;
			private TriggerActivation _activation;
			private TriggerSource _source;
			private SelfCondition _condition;
			private bool _eitherTurn;
			private bool _fastExecution;
			private bool _removeAfterTriggered;
			internal TriggerPropertyBuilder(TriggerType type, SimpleTask task)
			{
				_type = type;
				_task = task;
			}
		}
	}
}
