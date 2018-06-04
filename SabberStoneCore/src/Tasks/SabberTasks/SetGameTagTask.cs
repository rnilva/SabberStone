using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class SetGameTagTask : SabberTask
    {
	    private readonly GameTag _tag;
	    private readonly EntityType _type;
	    private readonly int _amount;

		public SetGameTagTask(GameTag tag, int amount, EntityType entityType)
	    {
		    _tag = tag;
		    _amount = amount;
		    _type = entityType;
	    }

	    public override TaskState Process(TaskStack stack)
	    {
		    foreach (IPlayable p in GetEntities(_type, stack))
		    {
			    p[_tag] = _amount;

			    if (_tag == GameTag.DIVINE_SHIELD && _amount == 0 && p[GameTag.DIVINE_SHIELD] != 0)
				    stack.Game.TriggerManager.OnLoseDivineShield(p);
			    else if
				    (_tag == GameTag.FROZEN && _amount == 1)
				    stack.Game.TriggerManager.OnFreezeTrigger(p);

		    };

		    return TaskState.COMPLETE;
	    }

	    public override SabberTask Clone(TaskStack stack)
	    {
		    var clone = new SetGameTagTask(_tag, _amount, _type){ PrivateStack = stack };
		    return clone;
	    }
	}
}
