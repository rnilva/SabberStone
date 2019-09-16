using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class GetControllerManaTask : SimpleTask
	{
		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			stack.Number = controller.RemainingMana;
			return TaskState.COMPLETE;
		}
	}
}
