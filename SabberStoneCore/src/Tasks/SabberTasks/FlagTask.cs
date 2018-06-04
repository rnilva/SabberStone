using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class FlagTask : SabberTask
    {
	    private readonly bool _checkFlag;
	    private readonly SabberTask _taskToDo;

		public FlagTask(bool checkFlag, SabberTask taskToDo)
	    {
		    _checkFlag = checkFlag;
		    _taskToDo = taskToDo;
	    }

	    public override TaskState Process(TaskStack stack)
	    {
		    return stack.Flag != _checkFlag ? TaskState.COMPLETE : _taskToDo.Process(stack);
	    }

	    public override SabberTask Clone(TaskStack stack)
	    {
		    var clone = new FlagTask(_checkFlag, _taskToDo) {PrivateStack = stack};
		    return clone;
	    }

	    public override string ToString()
	    {
		    return $"[FlagTask][{_checkFlag}:{_taskToDo.GetType().Name}]";
	    }
	}
}
