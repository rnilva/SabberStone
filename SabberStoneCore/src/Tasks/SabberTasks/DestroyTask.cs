using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
	public class DestroyTask : SabberTask
	{
		private readonly EntityType _type;
		private readonly bool _forcedDeathPhase;

		public DestroyTask(EntityType entityType, bool forcedDeathPhase = false)
		{
			_type = entityType;
			_forcedDeathPhase = forcedDeathPhase;
		}

		public override TaskState Process(TaskStack stack)
		{
			foreach (IPlayable p in GetEntities(_type, stack))
				p.Destroy();

			if (_forcedDeathPhase)
			{
				stack.Game.DeathProcessingAndAuraUpdate();
			}

			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new DestroyTask(_type, _forcedDeathPhase){ PrivateStack = stack };
			return clone;
		}
	}
}
