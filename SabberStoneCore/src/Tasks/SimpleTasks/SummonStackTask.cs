using System.Collections.Generic;
using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	/// <summary>
	///     Summon minions included in the stack.
	/// </summary>
	/// <seealso cref="SimpleTask" />
	public class SummonStackTask : SimpleTask
	{
		public SummonStackTask(bool removeFromZone = false, bool removeFromStack = false)
		{
			RemoveFromZone = removeFromZone;
			RemoveFromStack = removeFromStack;
		}

		/// <summary>
		///     True if entity must be removed before it is summoned.
		/// </summary>
		public bool RemoveFromZone { get; set; }

		public bool RemoveFromStack { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			if (controller.BoardZone.IsFull || stack?.Playables.Count == 0) return TaskState.STOP;

			List<Playable> playables = new List<Playable>(stack.Playables.Count);
			for (int i = 0; i < stack?.Playables.Count && !controller.BoardZone.IsFull; i++)
			{
				Playable p = stack.Playables[i];

				if (p.Controller.BoardZone.IsFull) continue;

				if (RemoveFromZone)
					p.Zone.Remove(p);

				Generic.SummonBlock(game, ref p, -1);
				playables.Add(p);
			}
			stack.Playables = playables;

			return TaskState.COMPLETE;
		}
	}
}
