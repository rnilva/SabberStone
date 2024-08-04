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
using SabberStoneCore.Actions;
using SabberStoneCore.Conditions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class DrawTask : SimpleTask
	{
		private readonly int _count;
		private readonly bool _toStack;
		//private readonly SelfCondition _condition;

		public DrawTask(bool toStack = false, int count = 1)
		{
			_toStack = toStack;
			_count = count;
		}

		public DrawTask(int count) : this(false, count)
		{
		}

		//public DrawTask(SelfCondition condition, bool toStack = false, int count = 1) : this(toStack, count)
		//{
		//	_condition = condition;
		//}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			//if (_condition != null)
			//{
			//	SelfCondition cond = _condition;
			//	ReadOnlySpan<Playable> deck = controller.DeckZone.GetSpan();
			//	List<int> indices = new List<int>();
			//	for (int i = 0; i < deck.Length; i++)
			//		if (cond.Eval(deck[i]))
			//			indices.Add(i);

			//	if (indices.Count == 0)
			//		return TaskState.STOP;

			//	if (indices.Count == 1)
			//	{
					
			//	}
			//}



			List<Playable> cards = _toStack ? new List<Playable>(_count) : null;
			for (int i = 0; i < _count; i++)
			{
				Playable draw = Generic.Draw(controller);
				if (draw == null)
					break;

				cards?.Add(draw);
			}

			if (cards != null)
			{
				//if (nullFlag)
					//stack?.Playables.AddRange(cards.Where(p => p != null));
				//else
					//stack?.Playables.AddRange(cards);

				if (cards.Count == 0)
					return TaskState.STOP;

				stack.Playables = cards;
			}

			return TaskState.COMPLETE;
		}
	}
}
