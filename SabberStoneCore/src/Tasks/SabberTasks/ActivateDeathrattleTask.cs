using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class ActivateDeathrattleTask : SabberTask
    {
	    private readonly EntityType _type;

	    public ActivateDeathrattleTask(EntityType type)
	    {
		    _type = type;
	    }

	    public override TaskState Process(TaskStack stack)
	    {
		    foreach (IPlayable p in IncludeTask.GetEntities(_type, stack.Controller, stack.Source, stack.Target, stack.Playables))
		    {
			    p.ActivateTask(Enums.PowerActivation.DEATHRATTLE);
			    p.AppliedEnchantments?.ForEach(e =>
			    {
				    if (e.Power.DeathrattleTask == null) return;
				    //stack.Game.SabberTaskQueue.Enqueue(e.Power.DeathrattleTask.Clone(new TaskStack(stack.Game, e.Target.Controller, e.Target, e)));
			    });
			    if (p.Controller.ControllerAuraEffects[Enums.GameTag.EXTRA_DEATHRATTLES] == 1)
			    {
				    p.ActivateTask(Enums.PowerActivation.DEATHRATTLE);
				    p.AppliedEnchantments?.ForEach(e =>
				    {
					    if (e.Power.DeathrattleTask == null) return;

						//stack.Game.SabberTaskQueue.Enqueue(e.Power.DeathrattleTask.Clone(new TaskStack(stack.Game, e.Target.Controller, e.Target, e)));
					});
			    }
		    }

		    new PlayableContainer(_type, stack.Controller, stack.Source, stack.Target).Apply(p =>
		    {
			    p.ActivateTask(Enums.PowerActivation.DEATHRATTLE);
			    p.AppliedEnchantments?.ForEach(e =>
			    {
				    if (e.Power.DeathrattleTask == null) return;
				    //stack.Game.SabberTaskQueue.Enqueue(e.Power.DeathrattleTask.Clone(new TaskStack(stack.Game, e.Target.Controller, e.Target, e)));
			    });
			    if (p.Controller.ControllerAuraEffects[Enums.GameTag.EXTRA_DEATHRATTLES] == 1)
			    {
				    p.ActivateTask(Enums.PowerActivation.DEATHRATTLE);
				    p.AppliedEnchantments?.ForEach(e =>
				    {
					    if (e.Power.DeathrattleTask == null) return;

					    //stack.Game.SabberTaskQueue.Enqueue(e.Power.DeathrattleTask.Clone(new TaskStack(stack.Game, e.Target.Controller, e.Target, e)));
				    });
			    }
		    });

		    return TaskState.STOP;
	    }

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new ActivateDeathrattleTask(_type)
			{
				PrivateStack = stack
			};
			return clone;
		}
	}
}
