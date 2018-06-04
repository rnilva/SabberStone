using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Conditions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class FilterStackTask : SabberTask
    {
	    private readonly EntityType _type;
	    private readonly SelfCondition[] _selfConditions;
	    private readonly RelaCondition[] _relaConditions;

	    public FilterStackTask(params SelfCondition[] selfConditions)
	    {
		    _selfConditions = selfConditions;
	    }

	    public FilterStackTask(EntityType type, params RelaCondition[] relaConditions)
	    {
		    _type = type;
		    _relaConditions = relaConditions;
	    }

	    private FilterStackTask(EntityType type, SelfCondition[] selfConditions, RelaCondition[] relaConditions)
	    {
		    _type = type;
		    _selfConditions = selfConditions;
		    _relaConditions = relaConditions;
	    }

		public override TaskState Process(TaskStack stack)
	    {
		    if (_relaConditions != null)
		    {
			    IList<IPlayable> entities = GetEntities(_type, stack);

			    if (entities.Count != 1)
				    return TaskState.STOP;

			    var filtered = new List<IPlayable>(entities.Count);
			    foreach (IPlayable p in stack.Playables)
			    {
				    bool flag = true;
				    for (int i = 0; i < _relaConditions.Length; i++)
					    flag = flag && _relaConditions[i].Eval(entities[0], p);
				    if (flag)
					    filtered.Add(p);
			    }
			    stack.Playables = filtered;
		    }

		    if (_selfConditions != null)
		    {
			    var filtered = new List<IPlayable>(stack.Playables.Count);
			    foreach (IPlayable p in stack.Playables)
			    {
				    bool flag = true;
				    for (int i = 0; i < _selfConditions.Length; i++)
				    {
					    if (_selfConditions[i] != null)
						    flag = flag && _selfConditions[i].Eval(p);
				    }

				    if (flag)
					    filtered.Add(p);
			    }

			    stack.Playables = filtered;
		    }

		    return TaskState.COMPLETE;
	    }

	    public override SabberTask Clone(TaskStack stack)
	    {
		    var clone = new FilterStackTask(_type, _selfConditions, _relaConditions){ PrivateStack = stack };
		    return clone;
	    }
	}
}
