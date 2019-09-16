using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class HealNumberTask : SimpleTask
	{
		public HealNumberTask(EntityType entityType)
		{
			Type = entityType;
		}

		public EntityType Type { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			var playable = source as Playable;

			foreach (Playable p in IncludeTask.GetEntities(Type, in controller, playable, target, stack?.Playables))
			{
				var character = p as Character;
				character?.TakeHeal(playable, stack.Number);
			}

			return TaskState.COMPLETE;
		}
	}
}
