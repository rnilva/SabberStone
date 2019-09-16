using System.Collections.Generic;
using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class DrawStackTask : SimpleTask
	{
		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			if (stack == null || stack.Playables.Count == 0) return TaskState.STOP;

			var list = new List<Playable>();
			foreach (Playable p in stack.Playables) list.Add(Generic.DrawBlock(controller, p.Id));

			stack.Playables = list;
			return TaskState.COMPLETE;
		}
	}
}
