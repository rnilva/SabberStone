using System.Collections.Generic;
using SabberStoneCore.Actions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class DamageTask : SabberTask
    {
	    private readonly int _amount;
	    private readonly int _randAmount;
	    private readonly EntityType _type;
	    private readonly bool _spellDmg;


		public DamageTask(int amount, int randAmount, EntityType entityType, bool spellDmg = false)
	    {
		    _amount = amount;
		    _randAmount = randAmount;
		    _type = entityType;
		    _spellDmg = spellDmg;
	    }

	    public DamageTask(int amount, EntityType entityType, bool spellDmg = false)
	    {
		    _amount = amount;
		    _randAmount = 0;
		    _type = entityType;
		    _spellDmg = spellDmg;
	    }

	    public override TaskState Process(TaskStack stack)
	    {
		    if (_amount < 1 && _randAmount < 1)
			    return TaskState.STOP;

		    IList<IPlayable> entities = GetEntities(_type, stack);

		    for (int i = 0; i < entities.Count; i++)
		    {
			    int randAmount = 0;
			    if (_randAmount > 0)
			    {
				    randAmount = Random.Next(0, _randAmount + 1);
				    stack.Game.OnRandomHappened(true);
			    }

			    int amount = _amount + randAmount;

			    stack.Game.Log(LogLevel.WARNING, BlockType.ACTION, "DamageTask", !stack.Game.Logging ? "" : $"Amount is {amount} damage of {stack.Source}.");

			    Generic.DamageCharFunc.Invoke(stack.Source as IPlayable, entities[i] as ICharacter, amount, _spellDmg);
		    };
		    return TaskState.COMPLETE;
	    }

	    public override SabberTask Clone(TaskStack stack)
	    {
		    var clone = new DamageTask(_amount, _randAmount, _type, _spellDmg)
		    {
			    PrivateStack = stack
		    };
		    return clone;
	    }
	}
}
