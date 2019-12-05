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
using SabberStoneCore.Actions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class AddStackTo : SimpleTask
	{
		public AddStackTo(EntityType type)
		{
			Type = type;
		}

		public EntityType Type { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			foreach (Playable p in stack.Playables)
				p[GameTag.DISPLAYED_CREATOR] = source.Id;

			switch (Type)
			{
				case EntityType.DECK:
					foreach (Playable p in stack.Playables) Generic.ShuffleIntoDeck.Invoke(controller, source, p);
					var result = new Playable[stack.Playables.Count];
					for (int i = 0; i < stack.Playables.Count; i++)
						result[i] = game.IdEntityDic[stack.Playables[i].Id];
					stack.Playables = result;
					return TaskState.COMPLETE;

				case EntityType.HAND:
					foreach (Playable p in stack.Playables) Generic.AddHandPhase.Invoke(controller, p);
					return TaskState.COMPLETE;

				case EntityType.OP_HAND:
					foreach (Playable p in stack.Playables) Generic.AddHandPhase.Invoke(controller.Opponent, p);
					return TaskState.COMPLETE;

				case EntityType.OP_DECK:
					foreach (Playable p in stack.Playables) Generic.ShuffleIntoDeck.Invoke(controller.Opponent, source, p);
					return TaskState.COMPLETE;

				default:
					throw new NotImplementedException();
			}
		}
	}
}
