using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SabberTasks
{
	public class EnqueueTask : SabberTask
	{
		private readonly int _amount;
		private readonly SabberTask _task;
		private readonly bool _spellDmg;

		public EnqueueTask(int amount, SabberTask task, bool spellDmg = false)
		{
			_amount = amount;
			_task = task;
			_spellDmg = spellDmg;
		}

		public override TaskState Process(TaskStack stack)
		{
			int times = _spellDmg ? _amount + stack.Controller.CurrentSpellPower : _amount;

			for (int i = 0; i < times; i++)
				stack.Game.SabberTaskQueue.Enqueue(_task);

			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new EnqueueTask(_amount, _task, _spellDmg)
			{
				PrivateStack = stack
			};
			return clone;
		}
	}
}
