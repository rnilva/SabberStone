using System.Collections.Generic;
using System.Linq;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class ChangeAttackingTargetTask : SimpleTask
	{
		/// <param name="typA">The attacker</param>
		/// <param name="typB">New Defender</param>
		public ChangeAttackingTargetTask(EntityType typA, EntityType typB)
		{
			TypeA = typA;
			TypeB = typB;
		}

		public EntityType TypeA { get; set; }
		public EntityType TypeB { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			//System.Collections.Generic.List<Playable> typeA = IncludeTask.GetEntities(TypeA, in controller, source, target, stack?.Playables);
			//System.Collections.Generic.List<Playable> typeB = IncludeTask.GetEntities(TypeB, in controller, source, target, stack?.Playables);
			List<Playable> typeA = IncludeTask.GetEntities(TypeA, in controller, source, target, stack?.Playables)
				.ToList();
			List<Playable> typeB = IncludeTask.GetEntities(TypeB, in controller, source, target, stack?.Playables)
				.ToList();
			if (typeA.Count != 1 || typeB.Count != 1) return TaskState.STOP;

			var attacker = typeA[0] as Character;
			var newDefender = typeB[0] as Character;
			if (attacker == null || newDefender == null) return TaskState.STOP;

			if (game.Logging)
				game.Log(LogLevel.INFO, BlockType.ATTACK, "ChangeAttackingTargetTask",
					!game.Logging ? "" : $"{attacker} target {game.ProposedDefender} changed to {newDefender.Id}.");

			game.ProposedDefender = newDefender.Id;
			game.CurrentEventData.EventTarget = newDefender;
			return TaskState.COMPLETE;
		}
	}
}
