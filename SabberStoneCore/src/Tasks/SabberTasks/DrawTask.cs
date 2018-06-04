using System.Linq;
using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public class DrawTask : SabberTask
    {
	    private readonly bool _toStack;
	    private readonly int _count;

	    public DrawTask(bool toStack = false, int count = 1)
	    {
		    _toStack = toStack;
		    _count = count;
	    }

	    public DrawTask(int count) : this(false, count)
	    {
	    }


	    public override TaskState Process(TaskStack stack)
	    {
		    //Model.Entities.IPlayable drawedCard = Generic.Draw(Controller);
		    bool nullFlag = false;
		    var cards = new IPlayable[_count];
		    for (int i = 0; i < _count; i++)
		    {
			    IPlayable draw = Generic.Draw(stack.Controller);
			    if (draw == null)
				    nullFlag = true;
			    cards[i] = draw;
		    }

		    if (cards[0] == null)
		    {
			    return TaskState.COMPLETE;
		    }

		    if (_toStack)
			    stack.Playables.AddRange(nullFlag ? cards.Where(p => p != null) : cards);

		    return TaskState.COMPLETE;
	    }

	    public override SabberTask Clone(TaskStack stack)
	    {
		    var clone = new DrawTask(_toStack, _count) {PrivateStack = stack};
		    return clone;
	    }
	}
}
