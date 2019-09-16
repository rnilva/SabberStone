using System;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class ExtraTurnEffectTask : SimpleTask
	{
		//private readonly bool _opposite;

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			if (controller == game.CurrentPlayer)
				controller.NumTurnsLeft++;
			else
				throw new NotImplementedException();

			return TaskState.COMPLETE;
		}
	}
}
