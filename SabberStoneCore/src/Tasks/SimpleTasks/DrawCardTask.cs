﻿using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class DrawCardTask : SimpleTask
	{
		public override TaskState Process(in Game game, in Controller controller, in IEntity source, in IEntity target,
			in TaskStack stack = null)
		{
			if (stack?.Playables.Count != 1) return TaskState.STOP;

			IPlayable drawnCard = Generic.Draw(controller, stack.Playables[0].Id);

			if (drawnCard == null) return TaskState.STOP;

			return TaskState.COMPLETE;
		}
	}
}
