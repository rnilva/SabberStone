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

using System.Collections.Generic;
using SabberStoneCore.Actions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class EnqueueTask : SimpleTask
	{
		private readonly int _amount;
		private readonly bool _spellDmg;
		private readonly SimpleTask _task;

		public EnqueueTask(int amount, SimpleTask task, bool spellDmg = false)
		{
			_amount = amount;
			_task = task;
			_spellDmg = spellDmg;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			int times = _spellDmg ? _amount + controller.CurrentSpellPower : _amount;

			for (int i = 0; i < times; i++)
				game.TaskQueue.Enqueue(in _task, in controller, source, target);
			//Controller.game.TaskQueue.Enqueue(
			//	new ClearStackTask
			//	{
			//		Game = controller.Game,
			//		Controller = in controller,
			//		source = source as Playable,
			//		target = target as Playable
			//	});

			return TaskState.COMPLETE;
		}
	}

	public class EnqueuePendingTask : SimpleTask
	{
		private readonly SimpleTask? _task;
		private readonly EntityType _targetType;

		public EnqueuePendingTask(SimpleTask task, EntityType targetType)
		{
			_task = task;
			_targetType = targetType;
		}

		public EnqueuePendingTask(EntityType targetType)
		{
			_targetType = targetType;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IList<Playable> targets = IncludeTask.GetEntities(in _targetType, in controller, source, target, stack?.Playables);

			if (_task == null)
			{
				SimpleTask? task;
				if (target.Card.ChooseOne)
				{
					int chooseOne = game.EventNumber();

					string id = target.Card.Id;
					if (controller.ChooseBoth
					    && !id.Equals("EX1_165")	// OG_044a, using choose one 0 option
					    && !id.Equals("BRM_010")	// OG_044b, using choose one 0 option
					    && !id.Equals("AT_042")		// OG_044c, using choose one 0 option
					    && !id.Equals("UNG_101")	// UNG_101t3
					    && !id.Equals("ICC_051")	// ICC_051t3
					    && !id.Equals("ICC_047"))	// using choose one 0 option
					{
						SimpleTask? task1 = ((Playable)target).ChooseOnePlayables[0].Card.Power?.PowerTask;
						SimpleTask? task2 = ((Playable)target).ChooseOnePlayables[1].Card.Power?.PowerTask;

						if (task1 == null || task2 == null)
						{
							game.Log(LogLevel.WARNING, BlockType.POWER, "EnqueuePendingTask", $"{target} does not have a PowerTask.");
							return TaskState.STOP;
						}

						foreach (Playable p in targets)
						{
							game.TaskQueue.EnqueuePendingTask(task1, in controller, target, p);
							game.TaskQueue.EnqueuePendingTask(task2,in controller, target, p);
						}

						return TaskState.COMPLETE;
					}

					if (!controller.ChooseBoth && chooseOne > 0)
						task = ((Playable)target).ChooseOnePlayables[chooseOne - 1].Card.Power?.PowerTask;
					else
						return TaskState.STOP;
				}
				else
					task = target.Card.Power?.PowerTask;

				if (task == null)
				{
					game.Log(LogLevel.WARNING, BlockType.POWER, "EnqueuePendingTask", $"{target} does not have a PowerTask.");
					return TaskState.STOP;
				}

				if (target.Card.HasOverload)
					task = ComplexTask.Create(task, OverloadTask.Task);
				foreach (Playable p in targets)
					game.TaskQueue.EnqueuePendingTask(in task, in controller, target, p);
			}
			else
				foreach (Playable p in targets)
					game.TaskQueue.EnqueuePendingTask(in _task, in controller, target, p);

			return TaskState.COMPLETE;
		}
	}

	public class OverloadTask : SimpleTask
	{
		private OverloadTask() { }

		public static readonly OverloadTask Task = new OverloadTask();

		public override TaskState Process(in Game game, in Controller controller, in Entity source,
			in Entity target,
			in TaskStack stack = null)
		{
			Generic.OverloadBlock(controller, (Playable) source, game.History);
			return TaskState.COMPLETE;
		}
	}
}
