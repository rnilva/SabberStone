using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class MoveToSetaside : SimpleTask
	{
		public MoveToSetaside(EntityType type)
		{
			Type = type;
		}

		public EntityType Type { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			//List<Playable> entities = IncludeTask.GetEntities(Type, in controller, source, target, stack?.Playables);
			//entities.ForEach(p =>
			foreach (Playable p in IncludeTask.GetEntities(Type, in controller, source, target, stack?.Playables))
			{
				Playable removedEntity = p.Zone.Remove(p);
				game.Log(LogLevel.INFO, BlockType.PLAY, "MoveToSetaside",
					!game.Logging ? "" : $"{controller.Name}'s {p} is moved to the setaside zone.");
				controller.SetasideZone.Add(removedEntity);
			}
			return TaskState.COMPLETE;
		}
	}
}
