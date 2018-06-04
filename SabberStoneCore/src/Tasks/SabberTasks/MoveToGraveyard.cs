using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class MoveToGraveyard : SabberTask
    {
	    private readonly EntityType _type;

		public MoveToGraveyard(EntityType type)
	    {
		    _type = type;
	    }

	    public override TaskState Process(TaskStack stack)
	    {
		    foreach (IPlayable p in GetEntities(_type, stack))
		    {
			    p.Controller.GraveyardZone.Add(p.Zone.Remove(p));
			    if (p.Card.IsSecret && p[GameTag.REVEALED] == 1)
				    stack.Game.TriggerManager.OnSecretRevealedTrigger(p);
		    };
		    return TaskState.COMPLETE;
	    }

	    public override SabberTask Clone(TaskStack stack)
	    {
		    var clone = new MoveToGraveyard(_type) {PrivateStack = stack};
		    return clone;
	    }
	}
}
