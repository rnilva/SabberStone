using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SabberStoneCore.Conditions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
	public class ConditionTask : SabberTask
	{
		public SelfCondition[] SelfConditions { get; set; }
		public RelaCondition[] RelaConditions { get; set; }
		public EntityType Type { get; set; }

		private ConditionTask(EntityType entityType,
			SelfCondition[] selfConditions,
			RelaCondition[] relaConditions)
		{
			SelfConditions = selfConditions;
			RelaConditions = relaConditions;
			Type = entityType;
		}

		public ConditionTask(EntityType entityType, params SelfCondition[] selfConditions)
		{
			SelfConditions = selfConditions;
			RelaConditions = new RelaCondition[] { };
			Type = entityType;
		}

		public ConditionTask(EntityType entityType, params RelaCondition[] relaConditions)
		{
			SelfConditions = new SelfCondition[] { };
			RelaConditions = relaConditions;
			Type = entityType;
		}

		public override TaskState Process(TaskStack stack)
		{
			IEnumerable<IPlayable> entities = GetEntities(Type, stack);
			if (!entities.Any())
				return TaskState.STOP;

			var source = (IPlayable)stack.Source;

			int i;
			bool flag = true;
			foreach (IPlayable p in entities)
			{
				for (i = 0; i < SelfConditions.Length; i++)
					flag = flag && SelfConditions[i].Eval(p);

				for (i = 0; i < RelaConditions.Length; i++)
					flag = flag && RelaConditions[i].Eval(source, p);
			}

			stack.Flag = flag;


			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new ConditionTask(Type, SelfConditions, RelaConditions){PrivateStack = stack};
			return clone;
		}
	}

	public class NumberConditionTask : SabberTask
	{
		private readonly RelaSign _sign;
		private readonly int _reference;

		/// <summary>
		/// Create Task that compares the stored Number and the given reference value.
		/// </summary>
		public NumberConditionTask(int referenceValue, RelaSign sign)
		{
			_sign = sign;
			_reference = referenceValue;
		}

		/// <summary>
		/// Create Task that compares Number and Number1 in the stack.
		/// </summary>
		/// <param name="sign"></param>
		public NumberConditionTask(RelaSign sign) : this(Int32.MinValue, sign)
		{

		}

		public override TaskState Process(TaskStack stack)
		{
			int number = stack.Number;
			int number1 = stack.Number1;

			if (_reference == Int32.MinValue)
			{
				stack.Flag =
					_sign == RelaSign.GEQ ? number >= number1 :
					_sign == RelaSign.LEQ ? number <= number1 :
					number == number1;

				return TaskState.COMPLETE;
			}

			stack.Flag =
				_sign == RelaSign.GEQ ? number >= _reference :
				_sign == RelaSign.LEQ ? number <= _reference :
				number == _reference;

			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			return new NumberConditionTask(_reference, _sign) {PrivateStack = stack};
		}
	}
}
