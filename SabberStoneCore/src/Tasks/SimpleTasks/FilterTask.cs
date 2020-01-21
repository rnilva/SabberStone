using System;
using System.Collections.Generic;
using System.Linq;
using SabberStoneCore.Conditions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class FilterStackTask : SimpleTask
	{
		private readonly SelfCondition[] _selfConditions;

		public FilterStackTask(params SelfCondition[] selfConditions)
		{
			if (selfConditions.Length == 0)
				throw new ArgumentException("Cannot construct FilterStackTask with 0 conditions.", nameof(selfConditions));

			_selfConditions = selfConditions.Where(s => s != null).ToArray();
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IList<Playable> entities = stack.Playables;
			Span<int> indices = stackalloc int[entities.Count];
			int k = 0;
			for (int i = 0; i < entities.Count; ++i)
			{
				bool flag = true;
				for (int j = 0; j < _selfConditions.Length; ++j)
				{
					if (!_selfConditions[j].Eval(entities[i]))
					{
						flag = false;
						break;
					}
				}


				if (!flag) continue;

				indices[k++] = i;
			}

			if (k == entities.Count)
				return TaskState.COMPLETE;

			var filtered = new Playable[k];
			for (int i = 0; i < k; ++i)
				filtered[i] = entities[indices[i]];

			stack.Playables = filtered;

			return TaskState.COMPLETE;
		}
	}
}
