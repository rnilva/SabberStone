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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Tasks.SimpleTasks
{

	/// <summary>
	/// Indicator enum to specify target range of <see cref="SimpleTask"/>s.
	/// </summary>
	public enum EntityType
	{
		INVALID,

		/// <summary>
		/// All cards on the stack
		/// </summary>
		STACK,

		/// <summary>
		/// The target
		/// </summary>
		TARGET,

		/// <summary>
		/// The source
		/// </summary>
		SOURCE,

		/// <summary>
		/// Player's hero
		/// </summary>
		HERO,

		/// <summary>
		/// Player's hero power
		/// </summary>
		HERO_POWER,

		/// <summary>
		/// Opponent's hero power
		/// </summary>
		OP_HERO_POWER,

		/// <summary>
		/// The target of the current event. (e.g. the defender, the target of a spell, or the just damaged or healed
		/// character)
		/// </summary>
		EVENT_TARGET,

		/// <summary>
		/// The source of the current event. (e.g. the attacker, the played card, or the just damaging or healing entity)
		/// </summary>
		EVENT_SOURCE,

		/// <summary>
		/// The top card from the player's deck
		/// </summary>
		TOPCARDFROMDECK,

		/// <summary>
		/// The top card from the opponent's deck
		/// </summary>
		OP_TOPDECK,

		/// <summary>
		/// All cards in the player's hand
		/// </summary>
		HAND,

		/// <summary>
		/// All cards in the player's deck
		/// </summary>
		DECK,

		///// <summary>
		///// Player's secrets
		///// </summary>
		//SECRETS,

		/// <summary>
		/// Player's minions
		/// </summary>
		MINIONS,

		/// <summary>
		/// Player's minions except the source
		/// </summary>
		MINIONS_NOSOURCE,

		/// <summary>
		/// All friends characters
		/// </summary>
		FRIENDS,

		/// <summary>
		/// Opponent's Hero
		/// </summary>
		OP_HERO,

		/// <summary>
		/// All cards in the opponent's hand
		/// </summary>
		OP_HAND,

		/// <summary>
		/// All cards in the opponent's deck
		/// </summary>
		OP_DECK,

		/// <summary>
		/// All opponent secret
		/// </summary>
		OP_SECRETS,

		/// <summary>
		/// All opponent minion
		/// </summary>
		OP_MINIONS,

		/// <summary>
		/// All opponent character
		/// </summary>
		ENEMIES,

		/// <summary>
		/// All opponent character except the source
		/// </summary>
		ENEMIES_NOTARGET,

		/// <summary>
		/// All characters
		/// </summary>
		ALL,

		/// <summary>
		/// All characters except the source
		/// </summary>
		ALL_NOSOURCE,

		/// <summary>
		/// Player's weapon
		/// </summary>
		WEAPON,

		/// <summary>
		/// Opponent's weapon
		/// </summary>
		OP_WEAPON,

		/// <summary>
		/// All minions
		/// </summary>
		ALLMINIONS,

		/// <summary>
		/// All minions except the source
		/// </summary>
		ALLMINIONS_NOSOURCE,

		/// <summary>
		/// All cards in the graveyard
		/// </summary>
		GRAVEYARD,

		/// <summary>
		/// All heroes
		/// </summary>
		HEROES,

		/// <summary>
		/// The Controller entity of the player
		/// </summary>
		CONTROLLER,

		/// <summary>
		/// The Controller entity of the opponent.
		/// </summary>
		OP_CONTROLLER,

		/// <summary>
		/// The cards have been discarded from the player's hand.
		/// </summary>
		DISCARDED
	}

	public delegate IList<Playable> EntityGetter(Controller c, Entity s, Entity t, IList<Playable> stack);

	public class IncludeTask : SimpleTask
	{
		private const int SingleTypesRange = 9;

		private readonly bool _addFlag;
		private readonly EntityType[] _excludeTypeArray;
		private readonly EntityType _includeType;

		public IncludeTask(EntityType includeType, EntityType[] excludeTypeArray = null, bool addFlag = false)
		{
			_includeType = includeType;
			_excludeTypeArray = excludeTypeArray;
			_addFlag = addFlag;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			if (stack == null)
				throw new ArgumentException();

			IList<Playable> boardGetAll = GetEntities(_includeType, in controller, source, target, stack.Playables);
			if (_excludeTypeArray != null)
			{
				var exceptListEntities = new List<Playable>();
				foreach (EntityType excludeType in _excludeTypeArray)
					exceptListEntities.AddRange(
						GetEntities(excludeType, in controller, source, target, stack.Playables));

				IEnumerable<Playable> result = boardGetAll.Except(exceptListEntities);

				if (_addFlag)
					stack.AddPlayables(result);
				else
					stack.Playables = boardGetAll.Except(exceptListEntities).ToList();
			}
			else if
				(_addFlag)
				stack.AddPlayables(boardGetAll);
			else
				stack.Playables = boardGetAll;

			return TaskState.COMPLETE;
		}

		public static IList<Playable> GetEntities(in EntityType type, in Controller c, Entity source,
			Entity target, in IList<Playable> stack)
		{
			switch (type)
			{
				case EntityType.STACK:
					return stack;
				case EntityType.HAND:
					return c.HandZone.GetAll();
				case EntityType.DECK:
					return c.DeckZone.GetAll();
				case EntityType.MINIONS:
					return c.BoardZone.GetAll();
				case EntityType.GRAVEYARD:
					return c.GraveyardZone.GetSpan().ToArray();
				case EntityType.OP_HAND:
					return c.Opponent.HandZone.GetAll();
				case EntityType.OP_DECK:
					return c.Opponent.DeckZone.GetAll();
				case EntityType.OP_MINIONS:
					return c.Opponent.BoardZone.GetAll();
				case EntityType.OP_SECRETS:
					return c.Opponent.SecretZone.GetAll();

				case EntityType.MINIONS_NOSOURCE:
					return c.BoardZone.GetAll(p => p != source);
				case EntityType.ALLMINIONS_NOSOURCE:
					{
						if (source.Controller == c)
						{
							Minion[] board = c.BoardZone.GetAll(p => p != source);
							var array = new Minion[board.Length + c.Opponent.BoardZone.CountExceptUntouchables];
							board.CopyTo(array, 0);
							c.Opponent.BoardZone.CopyTo(array, board.Length);
							return array;
						}
						else
						{
							Minion[] board = c.Opponent.BoardZone.GetAll(p => p != source);
							var array = new Minion[board.Length + c.BoardZone.CountExceptUntouchables];
							board.CopyTo(array, 0);
							c.BoardZone.CopyTo(array, board.Length);
							return array;
						}
					}

				case EntityType.ENEMIES:
					{
						var arr = new Character[c.Opponent.BoardZone.CountExceptUntouchables + 1];
						arr[0] = c.Opponent.Hero;
						c.Opponent.BoardZone.CopyTo(arr, 1);
						return arr;
					}

				case EntityType.TARGET:
					return target == null ? new Playable[0] : new[] { (Playable)target };
				case EntityType.SOURCE:
					return new[] { (Playable)source };
				case EntityType.HERO:
					return new[] { c.Hero };
				case EntityType.HERO_POWER:
					return new[] { c.Hero.HeroPower };
				case EntityType.OP_HERO_POWER:
					return new[] { c.Opponent.Hero.HeroPower };
				case EntityType.FRIENDS:
					{
						var arr = new Character[c.BoardZone.CountExceptUntouchables + 1];
						arr[0] = c.Hero;
						c.BoardZone.CopyTo(arr, 1);
						return arr;
					}

				case EntityType.OP_HERO:
					return new[] { c.Opponent.Hero };
				case EntityType.ENEMIES_NOTARGET:
					if (target is Hero)
					{
						return c.Opponent.BoardZone.GetAll();
					}
					else if (target.Zone?.Type != Enums.Zone.PLAY)
						goto case EntityType.ENEMIES;
					else
					{
						if (c.Opponent.BoardZone.CountExceptUntouchables > 1)
						{
							var arr = new Character[c.Opponent.BoardZone.CountExceptUntouchables];
							arr[0] = c.Opponent.Hero;
							Minion[] temp = c.Opponent.BoardZone.GetAll(p => p != target);
							Array.Copy(temp, 0, arr, 1, temp.Length);
							return arr;
						}

						return new[] { c.Opponent.Hero };
					}

				case EntityType.ALL:
					{
						var arr = new Playable[c.BoardZone.CountExceptUntouchables +
												c.Opponent.BoardZone.CountExceptUntouchables + 2];
						c.BoardZone.CopyTo(arr, 0);
						c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
						arr[arr.Length - 2] = c.Hero;
						arr[arr.Length - 1] = c.Opponent.Hero;
						return arr;
					}

				case EntityType.ALL_NOSOURCE:
					{
						if (source.Zone == null) throw new NotImplementedException();

						var arr = new Playable[c.BoardZone.CountExceptUntouchables +
												c.Opponent.BoardZone.CountExceptUntouchables + 1];

						if (source is Enchantment e)
						{
							source = e.Target;
						}

						if (source.Zone == c.BoardZone)
						{
							c.BoardZone.GetAll(p => p != source).CopyTo(arr, 0);
							c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables - 1);
							arr[arr.Length - 2] = c.Hero;
							arr[arr.Length - 1] = c.Opponent.Hero;
						}
						else if (source.Zone == c.Opponent.BoardZone)
						{
							c.BoardZone.CopyTo(arr, 0);
							c.Opponent.BoardZone.GetAll(p => p != source).CopyTo(arr, c.BoardZone.CountExceptUntouchables);
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
					return c.Hero.Weapon == null ? new Playable[0] : new[] { c.Hero.Weapon };
				case EntityType.OP_WEAPON:
					return c.Opponent.Hero.Weapon == null ? new Playable[0] : new[] { c.Opponent.Hero.Weapon };
				case EntityType.ALLMINIONS:
					{
						var arr = new Minion[c.BoardZone.CountExceptUntouchables +
											 c.Opponent.BoardZone.CountExceptUntouchables];
						c.BoardZone.CopyTo(arr, 0);
						c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
						return arr;
					}

				case EntityType.HEROES:
					return new[] { c.Hero, c.Opponent.Hero };
				case EntityType.TOPCARDFROMDECK:
					return c.DeckZone.Count > 0 ? new[] { c.DeckZone.TopCard } : new Playable[0];
				case EntityType.OP_TOPDECK:
					return c.Opponent.DeckZone.Count > 0 ? new[] { c.Opponent.DeckZone.TopCard } : new Playable[0];
				case EntityType.DISCARDED:
					{
						EntityList dict = c.Game.IdEntityDic;
						return c.DiscardedEntities.Select(id => dict[id]).ToArray();
					}
				case EntityType.EVENT_SOURCE:
					{
						Playable? s = c.Game.TryGetEventSource();
						return s != null ? [s] : [];
					}
				case EntityType.EVENT_TARGET:
					{
						Playable? s = c.Game.TryGetEventTarget();
						return s != null ? [s] : [];
					}
				default:
					throw new NotImplementedException();
			}
		}

		//public static EntityIterator GetEntities(EntityType type, Controller c, Entity s, Entity t)
		//{
		//	switch (type)
		//	{
		//		case EntityType.SOURCE:
		//			return (Playable)s;
		//		case EntityType.TARGET:
		//			return (Playable)t;
		//		case EntityType.MINIONS:
		//			return c.BoardZone.GetSpan<Playable>();
		//		case EntityType.ALLMINIONS:
		//			return new EntityIterator(c.BoardZone.GetSpan<Playable>(), c.Opponent.BoardZone.GetSpan<Playable>());
		//		case EntityType.ALLMINIONS_NOSOURCE:
		//			{
		//				if (s.Controller == c)
		//				{
		//					ReadOnlySpan<Playable> span = c.BoardZone.GetSpan<Playable>();
		//					int exclude = -1;
		//					for (int i = 0; i < span.Length; ++i)
		//					{
		//						if (span[i] == s)
		//						{
		//							exclude = i;
		//							break;
		//						}
		//					}

		//					return new EntityIterator(span, c.Opponent.BoardZone.GetSpan<Playable>(), exclude);
		//				}
		//				else
		//				{
		//					ReadOnlySpan<Playable> span = c.Opponent.BoardZone.GetSpan<Playable>();
		//					int exclude = -1;
		//					for (int i = 0; i < span.Length; ++i)
		//					{
		//						if (span[i] == s)
		//						{
		//							exclude = i;
		//							break;
		//						}
		//					}

		//					return new EntityIterator(c.BoardZone.GetSpan<Playable>(), span, exclude);
		//				}
		//			}
		//		case EntityType.



		//	}
		//}

		static IncludeTask()
		{
			Func<Playable?, Playable[]> notNullOrEmpty = p => p != null ? [p] : [];


			GetterDict = new Dictionary<EntityType, EntityGetter>
			{
				{EntityType.STACK, (c,s,t,stack) => stack },
				{EntityType.HAND, (c,s,t,stack) => c.HandZone.GetAll() },
				{EntityType.DECK, (c,s,t,stack) => c.DeckZone.GetAll() },
				{EntityType.MINIONS, (c,s,t,stack) => c.BoardZone.GetAll() },
				{EntityType.GRAVEYARD, (c,s,t,stack) => c.GraveyardZone.GetAll() },
				{EntityType.OP_HAND, (c,s,t,stack) => c.Opponent.HandZone.GetAll() },
				{EntityType.OP_DECK, (c,s,t,stack) => c.Opponent.DeckZone.GetAll() },
				{EntityType.OP_MINIONS, (c,s,t,stack) => c.Opponent.BoardZone.GetAll() },
				{EntityType.OP_SECRETS, (c,s,t,stack) => c.Opponent.SecretZone.GetAll() },
				{EntityType.SOURCE, (c,s,t,stack) => notNullOrEmpty((Playable) s) },
				{EntityType.TARGET, (c,s,t,stack) => notNullOrEmpty((Playable) t) },
				{EntityType.HERO, (c,s,t,stack) => new[]{c.Hero}},
				{EntityType.OP_HERO, (c,s,t,stack) => new[]{c.Opponent.Hero}},
				{EntityType.HERO_POWER, (c,s,t,stack) => new[]{c.Hero.HeroPower}},
				{EntityType.OP_HERO_POWER, (c,s,t,stack) => new[]{c.Opponent.Hero.HeroPower}},
				{EntityType.WEAPON, (c, s, t, stack) => notNullOrEmpty(c.Hero.Weapon) },
				{EntityType.OP_WEAPON, (c, s, t, stack) => notNullOrEmpty(c.Opponent.Hero.Weapon)},
				{EntityType.MINIONS_NOSOURCE, (c, s, t, stack) => c.BoardZone.GetAll(p => p != s)},
				{EntityType.ALLMINIONS_NOSOURCE, (c, s, t, stack) =>
				{
					if (s.Controller == c)
					{
						Minion[] board = c.BoardZone.GetAll(p => p != s);
						var array = new Minion[board.Length + c.Opponent.BoardZone.CountExceptUntouchables];
						board.CopyTo(array, 0);
						c.Opponent.BoardZone.CopyTo(array, board.Length);
						return array;
					}
					else
					{
						Minion[] board = c.Opponent.BoardZone.GetAll(p => p != s);
						var array = new Minion[board.Length + c.BoardZone.CountExceptUntouchables];
						board.CopyTo(array, 0);
						c.BoardZone.CopyTo(array, board.Length);
						return array;
					}
				}},
				{EntityType.ALL, (c, s, t, stack) =>
				{
					var arr = new Playable[c.BoardZone.CountExceptUntouchables +
					                       c.Opponent.BoardZone.CountExceptUntouchables + 2];
					c.BoardZone.CopyTo(arr, 0);
					c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
					arr[arr.Length - 2] = c.Hero;
					arr[arr.Length - 1] = c.Opponent.Hero;
					return arr;
				}},
				{EntityType.ALL_NOSOURCE, (c, s, t, stack) =>
				{
					if (s.Zone == null) throw new NotImplementedException();

					var arr = new Playable[c.BoardZone.CountExceptUntouchables +
					                       c.Opponent.BoardZone.CountExceptUntouchables + 1];

					if (s is Enchantment e)
					{
						s = e.Target;
					}

					if (s.Zone == c.BoardZone)
					{
						c.BoardZone.GetAll(p => p != s).CopyTo(arr, 0);
						c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables - 1);
						arr[arr.Length - 2] = c.Hero;
						arr[arr.Length - 1] = c.Opponent.Hero;
					}
					else if (s.Zone == c.Opponent.BoardZone)
					{
						c.BoardZone.CopyTo(arr, 0);
						c.Opponent.BoardZone.GetAll(p => p != s).CopyTo(arr, c.BoardZone.CountExceptUntouchables);
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
				}},
				{EntityType.ALLMINIONS, (c, s, t, stack) =>
				{
					var arr = new Minion[c.BoardZone.CountExceptUntouchables +
					                     c.Opponent.BoardZone.CountExceptUntouchables];
					c.BoardZone.CopyTo(arr, 0);
					c.Opponent.BoardZone.CopyTo(arr, c.BoardZone.CountExceptUntouchables);
					return arr;
				}},
				{EntityType.FRIENDS, (c, s, t, stack) =>
				{
					var arr = new Character[c.BoardZone.CountExceptUntouchables + 1];
					arr[0] = c.Hero;
					c.BoardZone.CopyTo(arr, 1);
					return arr;
				}},
				{EntityType.ENEMIES, (c, s, t, stack) =>
				{
					var arr = new Character[c.Opponent.BoardZone.CountExceptUntouchables + 1];
					arr[0] = c.Opponent.Hero;
					c.Opponent.BoardZone.CopyTo(arr, 1);
					return arr;
				}},
				{EntityType.ENEMIES_NOTARGET, (c, s, t, stack) =>
				{
					if (t is Hero)
					{
						return c.Opponent.BoardZone.GetAll();
					}
					else if (t.Zone?.Type != Enums.Zone.PLAY)
					{
						{
							var arr = new Character[c.Opponent.BoardZone.CountExceptUntouchables + 1];
							arr[0] = c.Opponent.Hero;
							c.Opponent.BoardZone.CopyTo(arr, 1);
							return arr;
						}
					}
					else
					{
						if (c.Opponent.BoardZone.CountExceptUntouchables > 1)
						{
							var arr = new Character[c.Opponent.BoardZone.CountExceptUntouchables];
							arr[0] = c.Opponent.Hero;
							Minion[] temp = c.Opponent.BoardZone.GetAll(p => p != t);
							Array.Copy(temp, 0, arr, 1, temp.Length);
							return arr;
						}

						return new[] { c.Opponent.Hero };
					}
				}},
				{EntityType.HEROES, (c,s,t,stack) => new[] { c.Hero, c.Opponent.Hero }},
				{EntityType.TOPCARDFROMDECK, (c, s, t, stack) => c.DeckZone.Count > 0 ? new[] { c.DeckZone.TopCard } : new Playable[0]},
				{EntityType.OP_TOPDECK, (c, s, t, stack) => c.Opponent.DeckZone.Count > 0 ? new[] { c.Opponent.DeckZone.TopCard } : new Playable[0]},
				{EntityType.DISCARDED, (c, s, t, stack) =>
				{
				
					EntityList dict = c.Game.IdEntityDic;
					return c.DiscardedEntities.Select(id => dict[id]).ToArray();
				}},
				{EntityType.EVENT_SOURCE, (c, s, t, stack) => notNullOrEmpty(c.Game.TryGetEventSource())},
				{EntityType.EVENT_TARGET, (c, s, t, stack) => notNullOrEmpty(c.Game.TryGetEventTarget())},
				{EntityType.CONTROLLER, (c, s, t, stack) => null },
				{EntityType.OP_CONTROLLER, (c, s, t, stack) => null }
			};
		}

		public static readonly Dictionary<EntityType, EntityGetter> GetterDict;
	}

	public class IncludeAdjacentTask : SimpleTask
	{
		private readonly EntityType _type;
		private readonly bool _includeCentre;

		/// <summary>
		/// Get minions adjacent to the minion of the given entity type
		/// and add them to the stack. 
		/// </summary>
		/// <param name="includeCentre">True if the centre minion should be included.</param>
		public IncludeAdjacentTask(EntityType entityType, bool includeCentre = false)
		{
			_type = entityType;
			_includeCentre = includeCentre;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source,
			in Entity target,
			in TaskStack stack = null)
		{
			Minion? left = null, right = null, centre;
			Minion[] minions;

			switch (_type)
			{
				case EntityType.SOURCE:
					centre = source as Minion;
					break;
				case EntityType.TARGET:
					centre = target as Minion;
					break;
				case EntityType.EVENT_SOURCE:
					centre = game.TryGetEventSource() as Minion;
					break;
				case EntityType.EVENT_TARGET:
					centre = game.TryGetEventTarget() as Minion;
					break;
				default:
					throw new NotImplementedException();
			}

			if (centre == null)
				throw new Exception($"Can't obtain adjacent minions of non-minion. (Source:{source}, Target:{target}");

			if (!(centre.Zone is BoardZone zone))
				minions = new Minion[0];
			else
			{
				bool l = false, c = _includeCentre, r = false;
				int count = c ? 1 : 0;
				int pos = centre.ZonePosition;

				if (pos > 0)
				{
					left = zone[pos - 1];
					if (!left.Untouchable)
					{
						l = true;
						count++;
					}

					if (pos < zone.Count - 1)
					{
						right = zone[pos + 1];
						if (!right.Untouchable)
						{
							r = true;
							count++;
						}
					}
				}
				else if (zone.Count > 1)
				{
					right = zone[pos + 1];
					if (!right.Untouchable)
					{
						r = true;
						count++;
					}
				}

				minions = new Minion[count];

				if (r)
					minions[--count] = right;
				if (c)
					minions[--count] = centre;
				if (l)
					minions[--count] = left;

			}

			stack.Playables = minions;

			return TaskState.COMPLETE;
		}
	}

	//public readonly ref struct EntityIterator
	//{
	//	private readonly Playable _p;
	//	private readonly int _excludeIndex;
	//	private readonly bool _single;
	//	private readonly ReadOnlySpan<Playable> _span1;
	//	private readonly ReadOnlySpan<Playable> _span2;

	//	public EntityIterator(in ReadOnlySpan<Playable> span1, in ReadOnlySpan<Playable> span2)
	//	{
	//		_p = null;
	//		_excludeIndex = -1;
	//		_single = false;
	//		_span1 = span1;
	//		_span2 = span2;
	//	}

	//	public EntityIterator(in ReadOnlySpan<Playable> span1, in ReadOnlySpan<Playable> span2, int exclude)
	//	{
	//		_p = null;
	//		_excludeIndex = exclude;
	//		_single = false;
	//		_span1 = span1;
	//		_span2 = span2;
	//	}

	//	public EntityIterator(in ReadOnlySpan<Playable> span)
	//	{
	//		_p = null;
	//		_excludeIndex = -1;
	//		_single = false;
	//		_span1 = span;
	//		_span2 = default;
	//	}

	//	public EntityIterator(Playable playable)
	//	{
	//		_p = playable;
	//		_excludeIndex = -1;
	//		_single = true;
	//		_span1 = default;
	//		_span2 = default;
	//	}

	//	public static implicit operator EntityIterator(Playable p) => new EntityIterator(p);
	//	public static implicit operator EntityIterator(in ReadOnlySpan<Playable> span) => new EntityIterator(in span);
	//}
}
