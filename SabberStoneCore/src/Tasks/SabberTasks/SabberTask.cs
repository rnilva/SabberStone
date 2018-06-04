using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
    public abstract class SabberTask
    {
	    internal class PlayableContainer
	    {
		    public readonly bool IsSingular;
			public readonly EntityType Type;
			public readonly IPlayable[] Playables;
			public readonly IPlayable Playable;

		    public PlayableContainer(EntityType type, Controller c, IEntity source, IEntity target)
		    {
				Type = type;
			    
		    }

		    public void Apply(Action<IPlayable> procedure)
		    {
			    if (IsSingular)
			    {
				    procedure(Playable);
					return;
			    }

			    IPlayable[] playables = Playables;
			    for (int i = 0; i < playables.Length; i++)
				    procedure(playables[i]);
		    }

		    public void Apply(Action<Controller> procedure)
		    {
			    if (Type != EntityType.CONTROLLER)
				    throw new InvalidOperationException();

		    }

		 //   private IPlayable GetSingular(EntityType type)
		 //   {
			//	switch (type)
			//	{
			//		case EntityType.TARGET:
			//			IsSingular = true;
			//			Playable = (IPlayable)target;
			//			break;
			//		case EntityType.SOURCE:
			//			IsSingular = true;
			//			Playable = (IPlayable)source;
			//			break;
			//		case EntityType.HERO:
			//			IsSingular = true;
			//			Playable = c.Hero;
			//			break;
			//		case EntityType.HERO_POWER:
			//			IsSingular = true;
			//			Playable = c.Hero.HeroPower;
			//			break;
			//		case EntityType.OP_HERO_POWER:
			//			IsSingular = true;
			//			Playable = c.Opponent.Hero.HeroPower;
			//			break;
					
			//		case EntityType.OP_HERO:
			//			IsSingular = true;
			//			Playable = c.Opponent.Hero;
			//			break;
			//		case EntityType.WEAPON:
			//			IsSingular = true;
			//			Playable = c.Hero.Weapon;
			//			break;
			//		case EntityType.OP_WEAPON:
			//			IsSingular = true;
			//			Playable = c.Opponent.Hero.Weapon;
			//			break;
			//		case EntityType.GRAVEYARD:
			//			Playables = c.GraveyardZone.ToArray();
			//			break;
			//		case EntityType.HEROES:
			//			Playables = new IPlayable[] { c.Hero, c.Opponent.Hero };
			//			break;
			//		case EntityType.TOPCARDFROMDECK:
			//			IsSingular = true;
			//			Playable = c.DeckZone.Count > 0 ? c.DeckZone.TopCard : null;
			//			break;
			//		case EntityType.OP_TOPDECK:
			//			IsSingular = true;
			//			Playable = c.Opponent.DeckZone.Count > 0 ? c.Opponent.DeckZone.TopCard : null;
			//			break;
			//		case EntityType.EVENT_TARGET:
			//			IsSingular = true;
			//			Playable = c.Game.CurrentEventData?.EventSource;
			//			break;
			//		case EntityType.EVENT_SOURCE:
			//			IsSingular = true;
			//			Playable = c.Game.CurrentEventData?.EventTarget;
			//			break;
			//		default:
			//			throw new ArgumentOutOfRangeException(nameof(type), type, null);
			//	}
			//}

		 //   private IPlayable[] GetPlayables(EntityType type)
		 //   {
			//    switch (type)
			//    {
			//	    case EntityType.HAND:
			//		    Playables = c.HandZone.GetAll();
			//		    break;
			//	    case EntityType.DECK:
			//		    Playables = c.DeckZone.GetAll();
			//		    break;
			//	    case EntityType.SECRETS:
			//		    Playables = c.SecretZone.GetAll();
			//		    break;
			//	    case EntityType.MINIONS:
			//		    Playables = c.BoardZone.GetAll();
			//		    break;
			//	    case EntityType.MINIONS_NOSOURCE:
			//		    Playables = c.BoardZone.GetAll(p => p != source);
			//		    break;
			//	    case EntityType.FRIENDS:
			//	    {
			//		    var arr = new ICharacter[c.BoardZone.CountExceptUntouchables + 1];
			//		    arr[0] = c.Hero;
			//		    c.BoardZone.CopyTo(arr, 1);
			//		    Playables = arr;
			//		    break;
			//	    }
			//	    case EntityType.ALLMINIONS:
			//	    {
			//		    var arr = new Minion[c.BoardZone.CountExceptUntouchables + c.Opponent.BoardZone.CountExceptUntouchables];
			//		    c.BoardZone.CopyTo(arr, 0);
			//		    c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
			//		    Playables = arr;
			//	    }
			//		    break;
			//	    case EntityType.ALLMINIONS_NOSOURCE:
			//	    {
			//		    if (source.Controller == c)
			//		    {
			//			    Minion[] board = c.BoardZone.GetAll(p => p != source);
			//			    Minion[] array = new Minion[board.Length + c.Opponent.BoardZone.CountExceptUntouchables];
			//			    board.CopyTo(array, 0);
			//			    c.Opponent.BoardZone.CopyTo(array, board.Length);
			//			    Playables = array;
			//		    }
			//		    else
			//		    {
			//			    Minion[] board = c.Opponent.BoardZone.GetAll(p => p != source);
			//			    Minion[] array = new Minion[board.Length + c.BoardZone.CountExceptUntouchables];
			//			    board.CopyTo(array, 0);
			//			    c.BoardZone.CopyTo(array, board.Length);
			//			    Playables = array;
			//		    }
			//		    break;
			//	    }
			//		case EntityType.OP_HAND:
			//			Playables = c.Opponent.HandZone.GetAll();
			//			break;
			//		case EntityType.OP_DECK:
			//			Playables = c.Opponent.DeckZone.GetAll();
			//			break;
			//		case EntityType.OP_SECRETS:
			//			Playables = c.Opponent.SecretZone.GetAll();
			//			break;
			//		case EntityType.OP_MINIONS:
			//			Playables = c.Opponent.BoardZone.GetAll();
			//			break;
			//		case EntityType.ENEMIES:
			//			{
			//				var arr = new ICharacter[c.Opponent.BoardZone.CountExceptUntouchables + 1];
			//				arr[0] = c.Opponent.Hero;
			//				c.Opponent.BoardZone.CopyTo(arr, 1);
			//				Playables = arr;
			//				break;
			//			}
			//		case EntityType.ENEMIES_NOTARGET:
			//			if (target is Hero)
			//				Playables = c.Opponent.BoardZone.GetAll();
			//			else
			//			{
			//				if (c.Opponent.BoardZone.CountExceptUntouchables > 1)
			//				{
			//					var arr = new ICharacter[c.Opponent.BoardZone.CountExceptUntouchables];
			//					arr[0] = c.Opponent.Hero;
			//					Minion[] temp = c.Opponent.BoardZone.GetAll(p => p != target);
			//					Array.Copy(temp, 0, arr, 1, temp.Length);
			//					Playables = arr;
			//					break;
			//				}

			//				IsSingular = true;
			//				Playable = c.Opponent.Hero;
			//			}
			//			break;
			//		case EntityType.ALL:
			//			{
			//				var arr = new IPlayable[c.BoardZone.CountExceptUntouchables + c.Opponent.BoardZone.CountExceptUntouchables + 2];
			//				c.BoardZone.CopyTo(arr, 0);
			//				c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
			//				arr[arr.Length - 2] = c.Hero;
			//				arr[arr.Length - 1] = c.Opponent.Hero;
			//				Playables = arr;
			//				break;
			//			}
			//		case EntityType.ALL_NOSOURCE:
			//			{
			//				if (source.Zone == null) throw new NotImplementedException();

			//				var arr = new IPlayable[c.BoardZone.CountExceptUntouchables + c.Opponent.BoardZone.CountExceptUntouchables + 1];
			//				if (source.Zone == c.BoardZone)
			//				{
			//					c.BoardZone.GetAll(p => p != source).CopyTo(arr, 0);
			//					c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables - 1);
			//					arr[arr.Length - 2] = c.Hero;
			//					arr[arr.Length - 1] = c.Opponent.Hero;
			//				}
			//				else if (source.Zone == c.Opponent.BoardZone)
			//				{
			//					c.BoardZone.CopyTo(arr, 0);
			//					c.Opponent.BoardZone.GetAll(p => p != source).CopyTo(arr, c.BoardZone.CountExceptUntouchables);
			//					arr[arr.Length - 2] = c.Hero;
			//					arr[arr.Length - 1] = c.Opponent.Hero;
			//				}
			//				else
			//				{
			//					c.BoardZone.CopyTo(arr, 0);
			//					c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
			//					arr[arr.Length - 2] = c.Hero;
			//					arr[arr.Length - 1] = c.Opponent.Hero;
			//				}
			//				Playables = arr;
			//				break;
			//			}
			//	}
		 //   }
	    }

		protected static Random Random => Util.Random;

		public TaskStack PrivateStack;

		public bool IsInstance => PrivateStack != null;

	    public abstract TaskState Process(TaskStack stack);

	    public abstract SabberTask Clone(TaskStack stack);

	    internal static TaskList Create(params SabberTask[] tasks)
	    {
		    return new TaskList(tasks);
	    }

	    public static IList<IPlayable> GetEntities(EntityType type, TaskStack stack)
	    {
			Controller c = stack.Controller;

			switch (type)
			{
				case EntityType.STACK:
					return stack.Playables;
				case EntityType.HAND:
					return c.HandZone.GetAll();
				case EntityType.DECK:
					return c.DeckZone.GetAll();
				case EntityType.MINIONS:
					return c.BoardZone.GetAll();
				case EntityType.SECRETS:
					return c.SecretZone.GetAll();
				case EntityType.GRAVEYARD:
					return c.GraveyardZone.ToArray();
				case EntityType.OP_HAND:
					return c.Opponent.HandZone.GetAll();
				case EntityType.OP_DECK:
					return c.Opponent.DeckZone.GetAll();
				case EntityType.OP_MINIONS:
					return c.Opponent.BoardZone.GetAll();
				case EntityType.OP_SECRETS:
					return c.Opponent.SecretZone.GetAll();

				case EntityType.MINIONS_NOSOURCE:
					return c.BoardZone.GetAll(p => p != stack.Source);
				case EntityType.ALLMINIONS_NOSOURCE:
					{
						if (stack.Source.Controller == c)
						{
							Minion[] board = c.BoardZone.GetAll(p => p != stack.Source);
							Minion[] array = new Minion[board.Length + c.Opponent.BoardZone.CountExceptUntouchables];
							board.CopyTo(array, 0);
							c.Opponent.BoardZone.CopyTo(array, board.Length);
							return array;
						}
						else
						{
							Minion[] board = c.Opponent.BoardZone.GetAll(p => p != stack.Source);
							Minion[] array = new Minion[board.Length + c.BoardZone.CountExceptUntouchables];
							board.CopyTo(array, 0);
							c.BoardZone.CopyTo(array, board.Length);
							return array;
						}
					}
				case EntityType.ENEMIES:
					{
						var arr = new ICharacter[c.Opponent.BoardZone.CountExceptUntouchables + 1];
						arr[0] = c.Opponent.Hero;
						c.Opponent.BoardZone.CopyTo(arr, 1);
						return arr;
					}
				case EntityType.TARGET:
					return stack.Target == null ? new IPlayable[0] : new[] { (IPlayable)stack.Target };
				case EntityType.SOURCE:
					return new[] { (IPlayable)stack.Source };
				case EntityType.HERO:
					return new[] { c.Hero };
				case EntityType.HERO_POWER:
					return new[] { c.Hero.HeroPower };
				case EntityType.OP_HERO_POWER:
					return new[] { c.Opponent.Hero.HeroPower };
				case EntityType.FRIENDS:
					{
						var arr = new ICharacter[c.BoardZone.CountExceptUntouchables + 1];
						arr[0] = c.Hero;
						c.BoardZone.CopyTo(arr, 1);
						return arr;
					}
				case EntityType.OP_HERO:
					return new[] { c.Opponent.Hero };
				case EntityType.ENEMIES_NOTARGET:
					if (stack.Target is Hero)
						return c.Opponent.BoardZone.GetAll();
					else
					{
						if (c.Opponent.BoardZone.CountExceptUntouchables > 1)
						{
							var arr = new ICharacter[c.Opponent.BoardZone.CountExceptUntouchables];
							arr[0] = c.Opponent.Hero;
							Minion[] temp = c.Opponent.BoardZone.GetAll(p => p != stack.Target);
							Array.Copy(temp, 0, arr, 1, temp.Length);
							return arr;
						}

						return new[] { c.Opponent.Hero };
					}
				case EntityType.ALL:
					{
						var arr = new IPlayable[c.BoardZone.CountExceptUntouchables + c.Opponent.BoardZone.CountExceptUntouchables + 2];
						c.BoardZone.CopyTo(arr, 0);
						c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
						arr[arr.Length - 2] = c.Hero;
						arr[arr.Length - 1] = c.Opponent.Hero;
						return arr;
					}
				case EntityType.ALL_NOSOURCE:
					{
						if (stack.Source.Zone == null) throw new NotImplementedException();

						var arr = new IPlayable[c.BoardZone.CountExceptUntouchables + c.Opponent.BoardZone.CountExceptUntouchables + 1];
						if (stack.Source.Zone == c.BoardZone)
						{
							c.BoardZone.GetAll(p => p != stack.Source).CopyTo(arr, 0);
							c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables - 1);
							arr[arr.Length - 2] = c.Hero;
							arr[arr.Length - 1] = c.Opponent.Hero;
						}
						else if (stack.Source.Zone == c.Opponent.BoardZone)
						{
							c.BoardZone.CopyTo(arr, 0);
							c.Opponent.BoardZone.GetAll(p => p != stack.Source).CopyTo(arr, c.BoardZone.CountExceptUntouchables);
							arr[arr.Length - 2] = c.Hero;
							arr[arr.Length - 1] = c.Opponent.Hero;
						}
						else
						{
							c.BoardZone.CopyTo(arr, 0);
							c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
							arr[arr.Length - 2] = c.Hero;
							arr[arr.Length - 1] = c.Opponent.Hero;
						}
						return arr;
					}
				case EntityType.WEAPON:
					return c.Hero.Weapon == null ? new IPlayable[0] : new[] { c.Hero.Weapon };
				case EntityType.OP_WEAPON:
					return c.Opponent.Hero.Weapon == null ? new IPlayable[0] : new[] { c.Opponent.Hero.Weapon };
				case EntityType.ALLMINIONS:
					{
						var arr = new Minion[c.BoardZone.CountExceptUntouchables + c.Opponent.BoardZone.CountExceptUntouchables];
						c.BoardZone.CopyTo(arr, 0);
						c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
						return arr;
					}
				case EntityType.HEROES:
					return new[] { c.Hero, c.Opponent.Hero };
				case EntityType.TOPCARDFROMDECK:
					return c.DeckZone.Count > 0 ? new[] { c.DeckZone.TopCard } : new IPlayable[0];
				case EntityType.OP_TOPDECK:
					return c.Opponent.DeckZone.Count > 0 ? new[] { c.Opponent.DeckZone.TopCard } : new IPlayable[0];
				case EntityType.EVENT_SOURCE:
					return c.Game.CurrentEventData != null ? new[] { c.Game.CurrentEventData.EventSource } : new IPlayable[0];
				case EntityType.EVENT_TARGET:
					return c.Game.CurrentEventData != null ? new[] { c.Game.CurrentEventData.EventTarget } : new IPlayable[0];
				default:
					throw new NotImplementedException();
			}
		}

		//public static T[] GetEntitiesGeneric<T>(EntityType type, Controller c)
    }

	internal class TaskList : SabberTask
	{
		private readonly IReadOnlyList<SabberTask> _tasks;
		//internal TaskStack Stack { private get; set; }

		public TaskList(SabberTask[] tasks)
		{
			_tasks = tasks;
		}

		public override TaskState Process(TaskStack stack)
		{
			for (int i = 0; i < _tasks.Count; i++)
				if (_tasks[i].Process(stack) != TaskState.COMPLETE)
					break;
			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			return new TaskList((SabberTask[]) _tasks) {PrivateStack = stack};
		}
	}
}
