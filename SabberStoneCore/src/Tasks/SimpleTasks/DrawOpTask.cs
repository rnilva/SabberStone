using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class DrawOpTask : SimpleTask
	{
		public DrawOpTask(bool toStack = false)
		{
			ToStack = toStack;
		}

		public bool ToStack { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			Playable drawnCard = Generic.Draw(controller.Opponent);
			if (ToStack && drawnCard != null) stack?.Playables.Add(drawnCard);

			return TaskState.COMPLETE;
		}
	}
}
