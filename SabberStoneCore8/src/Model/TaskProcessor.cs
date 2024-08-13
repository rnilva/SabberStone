#region copyright
// SabberStone, Hearthstone Simulator in C# .NET Core
// Copyright (C) 2017-2019 SabberStone Team, darkfriend77 & rnilva
//
// SabberStone is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License.
// SabberStone is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
#endregion
//#define LOGEVENT
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SabberStoneCore.Enums;
using SabberStoneCore.Exceptions;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;

//using TaskInstance = System.ValueTuple<SabberStoneCore.Tasks.SimpleTask, SabberStoneCore.Model.Entities.Controller, SabberStoneCore.Model.Entities.Entity, SabberStoneCore.Model.Entities.Entity>;

namespace SabberStoneCore.Model
{
	public class TaskQueue
	{
		private readonly struct TaskInstance
		{
			public readonly SimpleTask Task;
			public readonly Controller Controller;
			public readonly Entity Source;
			public readonly Entity Target;

			public TaskInstance(in SimpleTask task, in Controller controller, in Entity source, in Entity target)
			{
				Task = task;
				Controller = controller;
				Source = source;
				Target = target;
			}

			public static implicit operator (SimpleTask, Controller, Entity, Entity) (TaskInstance t)
			{
				return (t.Task, t.Controller, t.Source, t.Target);
			}

			public void Deconstruct(out SimpleTask simpleTask, out Controller controller, out Entity entity, out Entity target)
			{
				simpleTask = Task;
				controller = Controller;
				entity = Source;
				target = Target;
			}

			public override string ToString()
			{
				return $"({Controller.PlayerId}) [{Task.GetType().Name}] {Source} => {Target}";
			}
		}

		//private readonly struct Event
		//{
		//	public readonly Queue<TaskInstance> Queue;

		//	public Event(Queue<TaskInstance> newQueue)
		//	{
		//		Queue = newQueue;
		//	}
		//}

		private readonly Game _game;

#if LOGEVENT
		private int _stackHeight;
#endif

		public TaskQueue(Game game)
		{
			_game = game;
			_arr = new TaskInstance[INIT_SIZE];
			_headStack = new int[INIT_SIZE];
		}

		public TaskQueue(Game game, TaskQueue taskQueue)
		{
			_game = game;
			_arr = new TaskInstance[taskQueue._arr.Length];
			_headStack = new int[taskQueue._headStack.Length];
		}

		private const int INIT_SIZE = 8;
		private TaskInstance[] _arr;
		private int _current;
		private int _currentHead;
		private int[] _headStack;
		private int _headStackPointer;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty() => _current == _currentHead;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void StartEvent()
		{
			if (_headStack.Length == _headStackPointer)
				ResizeHeadStack();

			_headStack[_headStackPointer++] = _currentHead;
			_currentHead = _current;
#if LOGEVENT
			if (_game.Logging)
			{
				//var sb = new System.Text.StringBuilder("Event Starts");
				//for (int i = 0; i < 10 - _stackHeight; i++)
				//	sb.Append("----");
				_game.Log(LogLevel.DEBUG, BlockType.ACTION, "TaskQueue",
					//sb.ToString()
					$"Event ({_stackHeight}) Starts"
				);
				_stackHeight++;
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void EndEvent()
		{
#if LOGEVENT
			if (_game.Logging)
			{
				//var sb = new System.Text.StringBuilder("Event Ends--");
				//for (int i = 0; i < 10 - _stackHeight; i++)
				//	sb.Append("----");
				//_stackHeight--;
				_stackHeight--;
				_game.Log(LogLevel.DEBUG, BlockType.ACTION, "TaskQueue",
					//sb.ToString()
					$"Event ({_stackHeight}) Ends"
				);
			}
#endif
			_currentHead = _headStack[--_headStackPointer];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Enqueue(in SimpleTask task, in Controller controller, in Entity source, in Entity target)
		{
			if (_arr.Length == _current)
				ResizeTaskArray();

			_arr[_current++] = new TaskInstance(task, controller, source, target);
#if LOGEVENT
			_game.Log(LogLevel.DEBUG, BlockType.TRIGGER, "TaskQueue",
				!_game.Logging ? "" : $"{task.GetType().Name} is Enqueued in {_eventStack.Count}th stack");
#endif
		}

		/// <summary>
		/// Queue a task that will be processed after a task is queued and processed.
		/// </summary>
		/// <param name="task"></param>
		public void EnqueuePendingTask(in SimpleTask task, in Controller controller, in Entity source, in Entity target)
		{
			Enqueue(in task, in controller, in source, in target);
		}

		public void ProcessCurrentEventTasks()
		{
			bool logging = _game.Logging;
			bool history = _game.History;

			for (int i = _currentHead; i < _current; ++i)
			{
				ref readonly TaskInstance task = ref _arr[i];

				if (logging)
					_game.Log(LogLevel.VERBOSE, BlockType.TRIGGER, "TaskQueue", !_game.Logging ? ""
						: $"LazyTask[{task.Source}]: '{task.Task.GetType().Name}' is processed!" + $"'{task.Source.Card.Text?.Replace("\n", " ")}'");
				if (history)
					_game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(task.Task.IsTrigger ? BlockType.TRIGGER : BlockType.POWER, task.Source.Id, "", -1, task.Target?.Id ?? 0));

				TaskState success;
#if !DEBUG
				try
				{
#endif
					success = task.Task.Process(in _game, in task.Controller, in task.Source, in task.Target);
#if !DEBUG
				}
				catch (Exception e)
				{
					throw new TaskException(
						$"Exception occurs during processing a task.\nTask:{task.Task}, Source:{task.Source}, Target:{task.Target}", e);
				}
#endif
				if (history)
					_game.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());
			}

			_current = _currentHead;
		}

		public void Execute(in SimpleTask task, in Controller controller, in Playable source, in Entity target, int number = 0)
		{

			_game.Log(LogLevel.VERBOSE, BlockType.TRIGGER, "TaskQueue", !_game.Logging ? "" : $"PriorityTask[{source}]: '{task.GetType().Name}' is processed!" +
			                                                                                $"'{source.Card.Text?.Replace("\n", " ")}'");

			// power block
			if (controller.Game.History)
				controller.Game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.POWER, source.Id, "", -1, target?.Id ?? 0));

			task.Process(in _game, in controller, source, target);

			if (controller.Game.History)
				controller.Game.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());

			//_game.TaskStack.Reset();
		}

		private void ResizeHeadStack()
		{
			var newArray = new int[_headStack.Length << 1];
			Buffer.BlockCopy(_headStack, 0, newArray, 0, sizeof(int) * _headStack.Length);
			_headStack = newArray;
		}

		private void ResizeTaskArray()
		{
			var newArray = new TaskInstance[_arr.Length << 1];
			Array.Copy(_arr, 0, newArray, 0, _arr.Length);
			_arr = newArray;
		}
	}


	internal class EventMetaData
	{
		public Playable EventSource { get; set; }
		public Playable? EventTarget { get; set; }
		public int EventNumber { get; set; }

		public EventMetaData(Playable source, Playable? target, int number = 0)
		{
			EventSource = source;
			EventTarget = target;
			EventNumber = number;
		}
	}


	internal class EventStack
	{
		private readonly Stack<EventMetaData> _stack = new();

		public void Push(EventMetaData eventMeta) => _stack.Push(eventMeta);

		public void Push(Playable source, Playable? target, int number = 0) => Push(new EventMetaData(source, target, number));

		public void Pop() => _stack.Pop();

		public EventMetaData Peek() => _stack.Peek();

		public bool TryPeek(out EventMetaData eventMeta) => _stack.TryPeek(out eventMeta);
	}


	internal readonly struct EventBlock : IDisposable
	{
		private readonly EventStack _stack;

		public EventBlock(EventStack stack, Playable source, Playable? target, int number = 0)
		{
			_stack = stack;
			_stack.Push(source, target, number);
		}

		public void Dispose()
		{
			_stack.Pop();
		}
	}

}
