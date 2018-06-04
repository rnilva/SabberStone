using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SabberTasks
{
	public class SabberTaskQueue
    {
		private readonly Game _game;
		private readonly Stack<Queue<SabberTask>> _eventStack = new Stack<Queue<SabberTask>>();
		private readonly Queue<SabberTask> _baseQueue = new Queue<SabberTask>();
	    private TaskStack _currentEventTaskStack;

		//private int _stackHeight;
		// Flag == true : current event have not ended yet and no tasks queue in this event;
		private bool _eventFlag;

		public SabberTaskQueue(Game game)
		{
			_game = game;
			_currentEventTaskStack = new TaskStack(game);
		}

		private Queue<SabberTask> CurrentQueue => _eventStack.Count == 0 ? _baseQueue : _eventStack.Peek();

		// nothing left in current event
		public bool IsEmpty => _eventFlag || CurrentQueue.Count == 0;

		public SabberTask CurrentTask { get; private set; }

		public void StartEvent()
		{
			_eventFlag = true;

			//if (_game.Logging)
			//{
			//	_stackHeight++;
			//	var sb = new StringBuilder("Event Starts");
			//	for (int i = 0; i < 10 - _stackHeight; i++)
			//		sb.Append("----");
			//	_game.Log(LogLevel.DEBUG, BlockType.ACTION, "TaskQueue", sb.ToString());
			//}
		}

		public void EndEvent()
		{
			//if (_game.Logging)
			//{
			//	var sb = new StringBuilder("Event Ends--");
			//	for (int i = 0; i < 10 - _stackHeight; i++)
			//		sb.Append("----");
			//	_game.Log(LogLevel.DEBUG, BlockType.ACTION, "TaskQueue", sb.ToString());
			//	_stackHeight--;
			//}

			if (_eventFlag)
			{
				_eventFlag = false;
				return;
			}

			if (_eventStack.Count > 0)
				_eventStack.Pop();
		}

		public void Enqueue(SabberTask task)
		{
			if (_eventFlag) // flag = true means Event starts and no tasks queue yet
			{
				if (CurrentQueue.Count != 0) // Check if an ongoing event exists
					_eventStack.Push(new Queue<SabberTask>());

				_eventFlag = false;
			}

			CurrentQueue.Enqueue(task);

			//_game.Log(LogLevel.DEBUG, BlockType.TRIGGER, "TaskQueue",
			//	!_game.Logging ? "" : $"{task.GetType().Name} is Enqueued in {_eventStack.Count}th stack");
		}

		public void EnqueueBase(SabberTask task)
		{
			_baseQueue.Enqueue(task);

			//_game.Log(LogLevel.DEBUG, BlockType.TRIGGER, "TaskQueue",
			//	!_game.Logging ? "" : $"{task.GetType().Name} is Enqueued in 0th stack");
		}

	    public void ProcessTasks()
	    {
		    while (!_eventFlag && CurrentQueue.Count != 0)
			    if (Process() != TaskState.COMPLETE)
				    _game.Log(LogLevel.INFO, BlockType.PLAY, "Game",
					    !_game.Logging ? "" :
						    "Something really bad happend during proccessing, please analyze!");
	    }

	    public void ProcessTasks(SabberTask initialTask, Controller controller, IEntity source, IEntity target)
	    {
		    _currentEventTaskStack.Renew(controller, source, target);
		    Process(initialTask);
		    while (CurrentQueue.Count != 0)
			    if (Process() != TaskState.COMPLETE)
				    _game.Log(LogLevel.INFO, BlockType.PLAY, "Game",
					    !_game.Logging ? "" :
						    "Something really bad happend during proccessing, please analyze!");
		}

	    private TaskState Process(SabberTask task = null)
		{
			SabberTask currentTask = task ?? CurrentQueue.Dequeue();
			CurrentTask = currentTask;

			TaskState success = currentTask.Process(currentTask.PrivateStack ?? _currentEventTaskStack);

			CurrentTask = null;

			return success;
		}

		public void Execute(SabberTask task, Controller controller, IPlayable source, IPlayable target, int number = 0)
		{
			_game.Log(LogLevel.VERBOSE, BlockType.TRIGGER, "TaskQueue", !_game.Logging ? "" : $"PriorityTask[{source}]: '{task.GetType().Name}' is processed!" +
																							$"'{source.Card.Text?.Replace("\n", " ")}'");

			// power block
			if (controller.Game.History)
				controller.Game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.POWER, source.Id, "", -1, target?.Id ?? 0));

			task.Process(new TaskStack(controller.Game, controller, source, target, number));

			if (controller.Game.History)
				controller.Game.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());

			//_game.TaskStack.Reset();
		}

		public void ClearCurrentEvent()
		{
			CurrentQueue.Clear();
		}

		public void Clone()
		{
			//return new TaskQueue();
		}
	}


	internal struct EventData
	{
		public readonly IPlayable EventSource;
		public readonly IPlayable EventTarget;
		public readonly int EventNumber;

		public EventData(IPlayable source, IPlayable target, int number = 0)
		{
			EventSource = source;
			EventTarget = target;
			EventNumber = number;
		}
	}
}
