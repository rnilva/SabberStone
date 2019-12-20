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
using SabberStoneCore.Enums;
using SabberStoneCore.Conditions;
using SabberStoneCore.Model;
using SabberStoneCore.Tasks.SimpleTasks;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Tasks
{
	internal static class ComplexTask
	{
		public static SimpleTask Repeat(SimpleTask task, int times)
		{
			SimpleTask[] list = new SimpleTask[times];
			for (int i = 0; i < times; i++)
				list[i] = task;
			return Create(list);
		}

		public static SimpleTask Create(params SimpleTask[] list)
		{
			return StateTaskList.Chain(list);
		}

		internal static SimpleTask GetRandomEntourageCardToHand(bool opponent = false)
			=> Create(
				new RandomEntourageTask(),
				new AddStackTo(opponent ? EntityType.OP_HAND : EntityType.HAND));

		internal static SimpleTask LifeSteal(EntityType entityType)
			=> new SetGameTagTask(GameTag.LIFESTEAL, 1, entityType);

		public static SimpleTask Freeze(EntityType entityType)
			=> new SetGameTagTask(GameTag.FROZEN, 1, entityType);

		public static SimpleTask WindFury(EntityType entityType)
			=> Create(
				new SetGameTagTask(GameTag.WINDFURY, 1, entityType),
				new IncludeTask(entityType),
				new FuncPlayablesTask(playables =>
				{
					foreach (Playable p in playables)
					{
						var m = (Minion) p;
						if (m.NumAttacksThisTurn == 1 && m.IsExhausted)
							m.IsExhausted = false;
					}

					return playables;
				}));

		public static SimpleTask Taunt(EntityType entityType)
			=> new SetGameTagTask(GameTag.TAUNT, 1, entityType);

		public static SimpleTask DivineShield(EntityType entityType)
			=> new SetGameTagTask(GameTag.DIVINE_SHIELD, 1, entityType);

		public static SimpleTask Poisonous(EntityType entityType)
			=> new SetGameTagTask(GameTag.POISONOUS, 1, entityType);

		public static SimpleTask Charge(EntityType entityType)
			=> Create(
				new SetGameTagTask(GameTag.CHARGE, 1, entityType),
				new IncludeTask(entityType),
				new FuncPlayablesTask(list =>
				{
					foreach (Playable p in list)
					{
						var m = (Minion) p;
						if (m.NumAttacksThisTurn == 0 && m.IsExhausted)
							m.IsExhausted = false;
					}
					return null;
				})
			);

		public static SimpleTask Stealth(EntityType entityType)
			=> new SetGameTagTask(GameTag.STEALTH, 1, entityType);

		public static SimpleTask ExtraAttacksThisTurn(EntityType type) =>
			Create(
				new GetIntAttributeTask(IntAttributes.ExtraAttacksThisTurn, type),
				new MathAddTask(1),
				new SetIntAttributeNumberTask(IntAttributes.ExtraAttacksThisTurn, type));

		public static SimpleTask DiscardRandomCard(int amount)
			=> Create(
				new RandomTask(amount, EntityType.HAND),
				new DiscardTask(EntityType.STACK));

		public static SimpleTask AddRandomShamanSpell
			=> Create(
				new RandomCardTask(CardType.SPELL, CardClass.SHAMAN),
				new AddStackTo(EntityType.HAND));

		public static SimpleTask DrawCardTask()
			=> Create(
				new SplitTask(1, EntityType.DECK),
				new RandomTask(1, EntityType.STACK),
				new DrawCardTask());

		public static SimpleTask DamageRandomTargets(int targets, EntityType type, int amount, bool spellDmg = false)
			=> Create(
				new SplitTask(targets, type),
				new FilterStackTask(SelfCondition.IsNotDead),
				new RandomTask(targets, EntityType.STACK),
				//new RandomTask(targets, type),
				new DamageTask(amount, EntityType.STACK, spellDmg));

		public static SimpleTask DestroyRandomTargets(int targets, EntityType type)
			=> Create(
				new IncludeTask(type),
				new FilterStackTask(SelfCondition.IsNotDead),
				new RandomTask(targets, EntityType.STACK),
				new DestroyTask(EntityType.STACK));

		public static SimpleTask RandomCardCopyToHandFrom(EntityType entityType)
			//=> Create(
			//	new RandomTask(1, entityType),
			//	new CopyTask(EntityType.STACK, 1),
			//	new AddStackTo(EntityType.HAND));
			=> Create(
				new RandomTask(1, entityType),
				new CopyTask(EntityType.STACK, Zone.HAND));

		public static SimpleTask IfComboElse(SimpleTask combo)
			=> Create(
				new ConditionTask(EntityType.SOURCE, SelfCondition.IsComboActive),
				new FlagTask(true, combo));

		public static SimpleTask IfComboElse(SimpleTask combo, SimpleTask noCombo)
			=> Create(
				new ConditionTask(EntityType.SOURCE, SelfCondition.IsComboActive),
				new FlagTask(true, combo),
				new FlagTask(false, noCombo));

		public static SimpleTask True(SimpleTask task)
			=> new FlagTask(true, task);

		public static SimpleTask False(SimpleTask task)
			=> new FlagTask(false, task);

		public static SimpleTask RemoveFromGameTag(GameTag tag, int amount, EntityType type)
			=> Create(
				new GetGameTagTask(tag, type),
				new MathSubstractionTask(amount),
				new SetGameTagNumberTask(tag, type));

		public static SimpleTask ExcessManaCheck
			=> Create(
				new ConditionTask(EntityType.SOURCE, SelfCondition.IsManaCrystalFull),
				new FlagTask(true, new AddCardTo("CS2_013t", EntityType.HAND)),
				new FlagTask(false, Create(
					new ConditionTask(EntityType.SOURCE, SelfCondition.IsRemaningManaFull),
					new FlagTask(true, new AddCardTo("CS2_013t", EntityType.HAND))))
				);

		public static SimpleTask SpendAllManaTask(SimpleTask task)
		{
			return Create(
				new GetControllerManaTask(),
				task,
				new IncludeTask(EntityType.SOURCE),
				new FuncPlayablesTask(p =>
				{
					Controller controller = p[0].Controller;
					if (controller != null)
					{
						controller.UsedMana =
							controller.BaseMana
							+ controller.TemporaryMana
							- controller.OverloadLocked;
					}
					return null;
				}));
		}

		public static SimpleTask BuffRandomMinion(EntityType type, string enchantmentId, params SelfCondition[] list)
		{
			return Create(
				new IncludeTask(type),
				new FilterStackTask(SelfCondition.IsMinion),
				new FilterStackTask(list),
				new RandomTask(1, EntityType.STACK),
				new AddEnchantmentTask(enchantmentId, EntityType.STACK));
		}

		public static SimpleTask SummonRandomMinion(EntityType type, params RelaCondition[] list)
		{
			return Create(
				new IncludeTask(type),
				new FilterStackTask(EntityType.SOURCE, list),
				new RandomTask(1, EntityType.STACK),
				new ConditionTask(EntityType.HERO, SelfCondition.IsNotBoardFull),
				new FlagTask(true, new RemoveFromDeck(EntityType.STACK)),
				new FlagTask(true, new SummonTask()));
		}

		public static SimpleTask SummonOpRandomMinion(EntityType type, params RelaCondition[] list)
		{
			return Create(
				new IncludeTask(type),
				new FilterStackTask(EntityType.SOURCE, list),
				new RandomTask(1, EntityType.STACK),
				new ConditionTask(EntityType.OP_HERO, SelfCondition.IsNotBoardFull),
				new FlagTask(true, new RemoveFromDeck(EntityType.STACK)),
				new FlagTask(true, new SummonOpTask()));
		}

		public static SimpleTask SummonRandomMinionThatDied(SelfCondition selfCondition = null, int amount = 1)
		{
			return Create(
				new IncludeTask(EntityType.GRAVEYARD),
				new FilterStackTask(SelfCondition.IsDead, selfCondition),
				new RandomTask(amount, EntityType.STACK),
				new CopyTask(EntityType.STACK, Zone.PLAY));
		}

		public static SimpleTask SummonRandomMinion(GameTag tag, int value)
		{
			return Create(
				new RandomMinionTask(tag, value),
				new SummonTask());
		}

		public static SimpleTask DrawFromDeck(int amount, params SelfCondition[] list)
		{
			return Create(
				new IncludeTask(EntityType.DECK),
				new FilterStackTask(list),
				new RandomTask(amount, EntityType.STACK),
				new DrawStackTask());
		}

		public static SimpleTask PutSecretFromDeck =>
			Create(
				new ConditionTask(EntityType.SOURCE, SelfCondition.IsZoneCount(Zone.SECRET, 5)),
				new FlagTask(false, Create(
					new IncludeTask(EntityType.DECK),
					new FilterStackTask(SelfCondition.IsSecret),
					new FuncPlayablesTask(stack =>
					{
						if (stack.Count == 0)
							return null;

						Controller c = stack[0].Controller;
						do
						{
							Playable pick = ((List<Playable>)stack).Choose(c.Game.Random);
							if (c.SecretZone.Any(p => p.Card.AssetId == pick.Card.AssetId))
							{
								stack.Remove(pick);
								continue;
							}

							c.DeckZone.Remove(pick);
							var secret = (Spell) pick;
							secret.Power.Trigger?.Activate(c.Game, secret);
							c.SecretZone.Add(secret);
							if (c == c.Game.CurrentPlayer)
								secret.IsExhausted = true;
							break;

						} while (stack.Count > 0);

						return null;
					}))));

		public static SimpleTask AddRandomOpClassCardToHand =>
			Create(
				new RandomCardTask(EntityType.OP_HERO),
				new AddStackTo(EntityType.HAND));

		public static SimpleTask AddRandomMageSpellToHand =>
			Create(
				new RandomCardTask(CardType.SPELL, CardClass.MAGE),
				new AddStackTo(EntityType.HAND));

		public static SimpleTask SummonRandomBasicTotem =>
			Create(
				new IncludeTask(EntityType.SOURCE),
				new FuncPlayablesTask(list =>
				{
					list[0].Game.OnRandomHappened(true);
					return new[]
					{
						Entity.FromCard(list[0].Controller, Cards.BasicTotems[list[0].Game.Random.Next(4)])
					};
				}),
				new SummonTask());

		// TODO maybee better implement it with CFM_712_t + int
		private static readonly IReadOnlyList<string> JadeGolemStr = new []
		{
			"CFM_712_t01",
			"CFM_712_t02",
			"CFM_712_t03",
			"CFM_712_t04",
			"CFM_712_t05",
			"CFM_712_t06",
			"CFM_712_t07",
			"CFM_712_t08",
			"CFM_712_t09",
			"CFM_712_t10",
			"CFM_712_t11",
			"CFM_712_t12",
			"CFM_712_t13",
			"CFM_712_t14",
			"CFM_712_t15",
			"CFM_712_t16",
			"CFM_712_t17",
			"CFM_712_t18",
			"CFM_712_t19",
			"CFM_712_t20",
			"CFM_712_t21",
			"CFM_712_t22",
			"CFM_712_t23",
			"CFM_712_t24",
			"CFM_712_t25",
			"CFM_712_t26",
			"CFM_712_t27",
			"CFM_712_t28",
			"CFM_712_t29",
			"CFM_712_t30",
		};

		public static SimpleTask SummonJadeGolem(SummonSide side)
		{
			return Create(
				new IncludeTask(EntityType.SOURCE),
				new FuncPlayablesTask(p =>
				{
					Controller controller = p[0].Controller;
					//int jadeGolem = controller.JadeGolem;
					//controller.JadeGolem = jadeGolem + 1;
					int jadeGolem = controller[GameTag.JADE_GOLEM];
					controller[GameTag.JADE_GOLEM] = jadeGolem + 1;

					return new List<Playable> { Entity.FromCard(controller, Cards.FromId(jadeGolem < 30 ? JadeGolemStr[jadeGolem] : JadeGolemStr[29])) };
				}),
				new SummonTask(side));
		}

		public static SimpleTask Secret(params SimpleTask[] list)
		{
			List<SimpleTask> secretList = list.ToList();
			secretList.Add(new SetGameTagTask(GameTag.REVEALED, 1, EntityType.SOURCE));
			secretList.Add(new MoveToGraveYard(EntityType.SOURCE));
			return StateTaskList.Chain(secretList.ToArray());
		}

		public static SimpleTask SummonRandomMinionNumberTag(GameTag tag)
		{
			return Create(
				new RandomMinionNumberTask(tag),
				new SummonTask());
		}

		public static SimpleTask ProgressSpellStoneUpdate(string cardId)
		{
			return Create(
				new GetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_1, EntityType.SOURCE),
				new MathAddTask(1),
				new SetGameTagNumberTask(GameTag.TAG_SCRIPT_DATA_NUM_1, EntityType.SOURCE),
				new GetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_2, EntityType.SOURCE, 0, 1),
				new NumberConditionTask(RelaSign.GEQ),
				new FlagTask(true, Create(
					new SetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_1, 0, EntityType.SOURCE),
					new ChangeEntityTask(cardId))));
		}

		public static SimpleTask ProgressSpellStoneUpdateUsingEventNumber(string cardId)
		{
			return Create(
				new GetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_1, EntityType.SOURCE),
				new GetEventNumberTask(1),
				new MathNumberIndexTask(0, 1, MathOperation.ADD),
				new SetGameTagNumberTask(GameTag.TAG_SCRIPT_DATA_NUM_1, EntityType.SOURCE),
				new GetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_2, EntityType.SOURCE, 0, 1),
				new NumberConditionTask(RelaSign.GEQ),
				new FlagTask(true, Create(
					new SetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_1, 0, EntityType.SOURCE),
					new ChangeEntityTask(cardId))));
		}

		public static SimpleTask Scheme(SimpleTask taskWithNumber)
		{
			return Create(
				new GetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_1, EntityType.SOURCE),
				taskWithNumber);
		}

		public static readonly SimpleTask DiscardLowestCostCard
			= Create(
				new IncludeTask(EntityType.HAND),
				new FuncPlayablesTask(list =>
				{
					if (list.Count == 0)
						return list;
					list[0].Game.OnRandomHappened(true);
					list.Shuffle(list[0].Game.Random);
					int min = int.MaxValue;
					int minArg = -1;
					for (int i = 0; i < list.Count; i++)
					{
						int cost = list[i].Cost;
						if (cost < min)
						{
							min = list[i].Cost;
							minArg = i;
						}
					}

					return new[] {list[minArg]};
				}),
				new DiscardTask(EntityType.STACK));

		public static SimpleTask SummonAllFriendlyDiedThisTurn(SelfCondition condition = null)
		{
			return new CustomTask((g, c, s, t, stack) =>
			{
				BoardZone board = c.BoardZone;
				if (board.IsFull) return;

				int num = c.NumFriendlyMinionsThatDiedThisTurn;
				ReadOnlySpan<Playable> graveyard = c.GraveyardZone.GetSpan();
				Span<int> buffer = stackalloc int[num]; int k = 0;

				for (int i = graveyard.Length - 1, j = 0; j < num; --i)
				{
					if (!(graveyard[i] is Minion m && m.ToBeDestroyed)) continue;
					j++;
					if ((!condition?.Eval(graveyard[i]) ?? false)) continue;
					buffer[k++] = i;
				}

				for (--k; k >= 0; --k)
				{
					Entity.FromCard(in c, graveyard[buffer[k]].Card,
						zone: board, creator: in s);
					if (board.IsFull) return;
				}
			});
		}

		public static SimpleTask RecursiveTask(ConditionTask repeatCondition, params SimpleTask[] tasks)
		{
			SimpleTask[] taskList = new SimpleTask[tasks.Length + 2];
			tasks.CopyTo(taskList, 0);
			taskList[tasks.Length] = repeatCondition;
			taskList[tasks.Length + 1] = 
				new FlagTask(true,
				new FuncNumberTask(p =>
				{
					p.ActivateTask(PowerActivation.POWER);
					return 0;
				}
				));
			return StateTaskList.Chain(taskList);
		}

		public static SimpleTask Conditional(SelfCondition condition, SimpleTask trueTask,
			SimpleTask falseTask = null)
		{
			var tasks = new List<SimpleTask>
			{
				new ConditionTask(EntityType.SOURCE, condition),
				new FlagTask(true, trueTask)
			};

			if (falseTask != null)
				tasks.Add(new FlagTask(false, falseTask));

			return Create(tasks.ToArray());
		}

		/// <summary>
		/// Repeat the given task for each entity in the stack.
		/// </summary>
		/// <returns></returns>
		//public static SimpleTask ForEach(SimpleTask task)
		//{
		//	return new FuncPlayablesTask(stack =>
		//	{
		//		if (stack.Count == 0) return stack;

		//		TaskQueue queue = stack[0].Game.TaskQueue;

		//		foreach (Playable p in stack)
		//		{
		//			queue.Enqueue(in task, )
		//		}
		//	})
		//}
	}
}
