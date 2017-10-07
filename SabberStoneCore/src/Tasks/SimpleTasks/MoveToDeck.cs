﻿using SabberStoneCore.Actions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class MoveToDeck : SimpleTask
	{
		public MoveToDeck(EntityType type)
		{
			Type = type;
		}

		public EntityType Type { get; set; }

		public override TaskState Process()
		{
			System.Collections.Generic.List<IPlayable> entities = IncludeTask.GetEntites(Type, Controller, Source, Target, Playables);
			entities.ForEach(p =>
			{
				IPlayable removedEntity = p.Zone.Remove(p);
				removedEntity.Controller = Controller;
				if (Game.Logging)
					Game.Log(LogLevel.INFO, BlockType.PLAY, "MoveToDeck", $"{Controller.Name} is taking control of {p} and shuffled into his deck.");
				Generic.ShuffleIntoDeck.Invoke(Controller, p);
			});
			return TaskState.COMPLETE;
		}

		public override ISimpleTask Clone()
		{
			var clone = new MoveToDeck(Type);
			clone.Copy(this);
			return clone;
		}
	}
}
