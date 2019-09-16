using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class SetGameTagNumberTask : SimpleTask
	{
		public SetGameTagNumberTask(GameTag tag, EntityType entityType, bool ignoreDamage = false)
		{
			Tag = tag;
			Type = entityType;
			IgnoreDamage = ignoreDamage;
		}

		public GameTag Tag { get; set; }

		public EntityType Type { get; set; }

		public bool IgnoreDamage { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			//System.Collections.Generic.List<Model.Entities.Playable> entities = IncludeTask.GetEntities(Type, in controller, source, target, stack?.Playables);
			foreach (Playable p in IncludeTask.GetEntities(Type, in controller, source, target, stack?.Playables))
				if (p is Character c)
					switch (Tag)
					{
						case GameTag.ATK:
							c.AttackDamage = stack.Number;
							break;
						case GameTag.HEALTH:
							c.BaseHealth = stack.Number;
							break;
						case GameTag.DAMAGE:
							c.Damage = stack.Number;
							break;
						default:
							c[Tag] = stack.Number;
							break;
					}
				else
					p[Tag] = stack.Number;


			return TaskState.COMPLETE;
		}
	}
}
