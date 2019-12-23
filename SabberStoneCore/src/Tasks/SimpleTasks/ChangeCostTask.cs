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

using System.Collections.Generic;
using SabberStoneCore.Enchants;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class ChangeCostTask : SimpleTask
	{
		private readonly AbstractEffect _effect;
		private readonly EntityType _type;

		public ChangeCostTask(AbstractEffect effect, EntityType entityType)
		{
			_effect = effect;
			_type = entityType;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IList<Playable> entities = IncludeTask.GetEntities(_type, in controller, source, target, stack?.Playables);
			for (int i = 0; i < entities.Count; i++)
				//_effect.ApplyTo(entities[i]);
				entities[i].ApplyEffect(_effect);

			return TaskState.COMPLETE;
		}
	}
}
