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
using System;
using System.Collections.Generic;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class FuncPlayablesTask : SimpleTask
	{
		public FuncPlayablesTask(Func<IList<Playable>, IList<Playable>> function)
		{
			Function = function;
		}

		public Func<IList<Playable>, IList<Playable>> Function { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IList<Playable> results = Function(stack?.Playables);

			if (stack != null)
				stack.Playables = results;

			return TaskState.COMPLETE;
		}
	}

	public class CustomTask : SimpleTask
	{
		private readonly Action<Game, Controller, Entity, Playable, TaskStack> _func;
		public CustomTask(Action<Game, Controller, Entity, Playable, TaskStack> customFunction)
		{
			_func = customFunction;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Playable target,
			in TaskStack stack = null)
		{
			_func(game, controller, source, target, stack);
			return TaskState.COMPLETE;
		}
	}
}
