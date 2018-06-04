using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class TransformTask : SabberTask
    {
	    private readonly Card _card;
	    private readonly EntityType _type;


		public TransformTask(Card card, EntityType type)
	    {
		    _card = card;
		    _type = type;
	    }
	    public TransformTask(string cardId, EntityType type)
	    {
		    _card = Cards.FromId(cardId);
		    _type = type;
	    }

	    public override TaskState Process(TaskStack stack)
	    {
		    foreach (IPlayable p in GetEntities(_type, stack))
			    Generic.TransformBlock.Invoke(p.Controller, _card, p as Minion);

		    return TaskState.COMPLETE;
	    }

	    public override SabberTask Clone(TaskStack stack)
	    {
		    var clone = new TransformTask(_card, _type)
		    {
			    PrivateStack = stack
		    };
		    return clone;
	    }
	}
}
