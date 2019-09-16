using System;
using System.Collections.Generic;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class FuncPlayablesTask : SimpleTask
	{
		public FuncPlayablesTask(Func<IList<Playable>, IList<Playable>> function)
		{
			Function = function;
		}

		public Func<IList<Playable>, IList<Playable>> Function { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IList<Playable> results = Function(stack?.Playables);

			if (stack != null)
				stack.Playables = results;

			return TaskState.COMPLETE;
		}
	}
}
