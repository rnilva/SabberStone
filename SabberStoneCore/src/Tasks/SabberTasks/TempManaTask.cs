using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SabberTasks
{
	public class TempManaTask : SabberTask
	{
		private readonly int _amount;

		public TempManaTask(int amount)
		{
			_amount = amount;
		}

		public override TaskState Process(TaskStack stack)
		{
			Generic.AddTempMana.Invoke(stack.Controller, _amount);

			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new TempManaTask(_amount);
			clone.PrivateStack = stack;
			return clone;
		}
	}
}
