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

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class RandomMinionNumberTask : SimpleTask
	{
		public RandomMinionNumberTask(GameTag tag)
		{
			Tag = tag;
		}

		public GameTag Tag { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			ImmutableArray<Card> cardsList;
			if (Tag == GameTag.COST)
			{
				if (!Cards.CostMinionCards(game.FormatType).TryGetValue(stack.Number, out FrozenSet<Card>? set))
					return TaskState.STOP;

				cardsList = set.Items;
			}
			else
			{
				var cards = Cards.FormatTypeCards(game.FormatType);
				int num = stack.Number;
				cardsList = [..cards.Where(p => p.Type == CardType.MINION && p[Tag] == num)];
				if (!cardsList.Any())
					return TaskState.STOP;
			}

			Playable playable = Entity.FromCard(controller, cardsList.Choose(game.Random));
			stack.Playables = new[] {playable};

			game.OnRandomHappened(true);

			return TaskState.COMPLETE;
		}
	}
}
