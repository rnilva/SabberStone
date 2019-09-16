using System;
using System.Collections.Generic;
using SabberStoneCore.Actions;
using SabberStoneCore.Conditions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class RecruitTask : SimpleTask
	{
		private readonly SelfCondition[] _conditions;
		private readonly int _amount;
		private readonly bool _addToStack;

		/// <summary>
		/// Recruits a random minion satisfying the given conditions.
		/// </summary>
		public RecruitTask(int amount, params SelfCondition[] conditions)
		{
			_amount = amount;
			_conditions = conditions;
		}

		public RecruitTask(int amount, bool addToStack = false)
		{
			_amount = amount;
			_addToStack = addToStack;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			int amount = Math.Min(_amount, controller.BoardZone.FreeSpace);

			if (amount == 0) return TaskState.STOP;

			ReadOnlySpan<Playable> deck = controller.DeckZone.GetSpan();
			SelfCondition[] conditions = _conditions;
			var indices = new List<int>();

			for (int i = 0; i < deck.Length; i++)
			{
				if (!(deck[i] is Minion)) continue;

				bool flag = true;
				for (int j = 0; j < conditions?.Length; j++)
					flag &= conditions[j].Eval(deck[i]);
				if (flag)
					indices.Add(i);
			}

			if (indices.Count == 0)
				return TaskState.STOP;

			int[] results = indices.ChooseNElements(amount);

			Playable[] entities = new Playable[results.Length];
			for (int i = 0; i < entities.Length; i++)
				entities[i] = deck[results[i]];

			if (indices.Count > amount)
				game.OnRandomHappened(true);

			List<Playable> playables = null;
			if (_addToStack)
				playables = new List<Playable>(entities.Length);

			for (int i = 0; i < entities.Length; i++)
			{
				Playable p = entities[i];
				Generic.RemoveFromZone.Invoke(controller, p);
				Generic.SummonBlock(game, ref p, -1);

				playables?.Add(p);

				if (controller.BoardZone.IsFull)
					break;
			}

			if (_addToStack)
				stack.Playables = playables;

			return TaskState.COMPLETE;
		}
	}
}
