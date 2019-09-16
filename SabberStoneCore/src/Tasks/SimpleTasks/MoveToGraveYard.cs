using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class MoveToGraveYard : SimpleTask
	{
		public MoveToGraveYard(EntityType type)
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
				p.Controller.GraveyardZone.Add(p.Zone?.Remove(p) ?? p);
				if (p.Card.IsSecret && p[GameTag.REVEALED] == 1)
					game.TriggerManager.OnSecretRevealedTrigger(p);
			}
			return TaskState.COMPLETE;
		}
	}
}
