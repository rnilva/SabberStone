#region copyright
// SabberStone, Hearthstone Simulator in C# .NET Core
// Copyright (C) 2017-2019 SabberStone Team, darkfriend77 & rnilva
//
// SabberStone is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License.
// SabberStone is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
#endregion
﻿using System;
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

			var filtered = new Playable[k];
			for (int i = 0; i < k; ++i)
				filtered[i] = entities[indices[i]];

			stack.Playables = filtered;

			return TaskState.COMPLETE;
		}
	}
}
