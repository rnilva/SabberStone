using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class ChangeUnidentifiedTask : SimpleTask
	{
		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			Generic.ChangeEntityBlock(controller, (Playable) source, Cards.FromId(Util.Choose(source.Card.Entourage)), false);
			return TaskState.COMPLETE;
		}
	}
}
