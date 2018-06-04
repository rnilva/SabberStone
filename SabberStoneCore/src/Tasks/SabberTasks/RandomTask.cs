using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
	public class SplitTask : SabberTask
	{
		private readonly int _amount;
		private readonly EntityType _type;

		public SplitTask(int amount, EntityType type)
		{
			_amount = amount;
			_type = type;
		}

		public override TaskState Process(TaskStack stack)
		{

			IEnumerable<IPlayable> entities = GetEntities(_type, stack);

			if (stack.Game.Splitting && stack.Game.Splits.Count == 0)
			{
				throw new NotImplementedException();
			}

			stack.Playables = entities is List<IPlayable> list ? list : entities.ToList();

			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new SplitTask(_amount, _type)
			{
				PrivateStack = stack
			};
			return clone;
		}

	}

	public class RandomTask : SabberTask
	{
		public RandomTask(int amount, EntityType type)
		{
			Amount = amount;
			Type = type;
		}

		public int Amount { get; set; }

		public EntityType Type { get; set; }

		public override TaskState Process(TaskStack stack)
		{
			IEnumerable<IPlayable> temp = GetEntities(Type, stack);
			List<IPlayable> entities = temp is List<IPlayable> list ? list : temp.ToList();

			if (entities.Count == 0)
				return TaskState.STOP;

			stack.Playables = entities.ChooseNElements(entities.Count < Amount ? entities.Count : Amount).ToList();

			stack.Game.OnRandomHappened(true);

			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new RandomTask(Amount, Type) {PrivateStack = stack};
			return clone;
		}
	}
}
