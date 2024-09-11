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
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using SabberStoneCore.Enums;
using SabberStoneCore.Loader;
using SabberStoneCore.Model.Zones;
using SabberStoneCore.Tasks.PlayerTasks;
using SabberStoneCore.Tasks.PlayerTasks.Lite;

namespace SabberStoneCore.Model.Entities
{
	public partial class Controller
	{
		public unsafe void Options(List<PlayerTask> buffer, bool skipPrePhase = true)
		{
			buffer.Clear();

			if (this != Game.CurrentPlayer || Game.Step != Step.MAIN_ACTION) return;

			// ChooseTasks

			// EndTurnTask
			buffer.Add(EndTurnTask.Any(this));

			#region PlayCardTask
			// Flags
			// 0 : All Characters generated
			// 1 : Friendly Minions generated
			// 2 : Enemy Minions generated
			// 3 : All Minions generated
			// 4 : All Friendly Characters generated
			// 5 : All Enemy Characters generated
			// 6 : Attackable Targets generated
			bool* flags = stackalloc bool[7];
			var cache = new OptionHelper.Targets();
			ReadOnlySpan<Playable> hand = HandZone.GetSpan();
			int mana = RemainingMana;
			for (int i = 0; i < hand.Length; ++i)
			{
				Playable playable = hand[i];
				Card card = playable.Card;
				CardType type = card.Type;
				if (!playable.ChooseOne || ChooseBoth)
				{
					if (OptionHelper.IsPlayable(this, in playable, in card, type, mana))
						//OptionHelper.GetPlayCardTasks(this, in hand[i], in buffer, flags, ref cache, skipPrePhase);
					{
						bool targetable = !card.TargetingAvailabilityPredicate?.Invoke(this, card) ?? false;

						// Card doesn't require any targets
						if (targetable || card.TargetingType == TargetingType.None)
						{
							if (playable is Minion)
								for (int j = 0; j <= BoardZone.Count; j++)
									buffer.Add(PlayCardTask.Any(this, playable, null, j, -1, skipPrePhase));
							else
								buffer.Add(PlayCardTask.Any(this, playable, null, -1, -1, skipPrePhase));

							continue;
						}


						var targets = OptionHelper.Targets.Get(this, in card, ref cache, flags);

						if (targets.Empty)
						{
							if (card.MustHaveTargetToPlay)
								continue;

							if (playable is Minion)
								for (int j = 0; j <= BoardZone.Count; j++)
									buffer.Add(PlayCardTask.Any(this, playable, null, j, -1, skipPrePhase));
							else
								buffer.Add(PlayCardTask.Any(this, playable, null, -1, -1, skipPrePhase));
						}
						else
						{
							foreach (Character target in targets)
							{
								if (playable is Minion)
									for (int j = 0; j <= BoardZone.Count; j++)
										buffer.Add(PlayCardTask.Any(this, playable, target, j, -1,
											true));
								else
									buffer.Add(PlayCardTask.Any(this, playable, target, -1, -1, skipPrePhase));

							}
						}
					}
				}
				else
				{
					//Playable[] playables = hand[i].ChooseOnePlayables;
					//for (int j = 0; j < playables.Length; j++)
					//	OptionHelper.GetPlayCardTasks(in hand[i], playables[j], j + 1);
				}
			}
			#endregion

			#region HeroPowerTask
			HeroPower power = Hero.HeroPower;
			Card heroPowerCard = power.Card;
			if (!power.IsExhausted && mana >= power.Cost &&
			    !HeroPowerDisabled && !heroPowerCard.HideStat)
			{
				if (heroPowerCard.ChooseOne)
				{
					if (ChooseBoth)
						buffer.Add(HeroPowerTask.Any(this, skipPrePhase: true));
					else
					{
						buffer.Add(HeroPowerTask.Any(this, null, 1, true));
						buffer.Add(HeroPowerTask.Any(this, null, 2, true));
					}
				}
				else
				{
					if (heroPowerCard.IsPlayableByCardReq(this))
					{
						if (heroPowerCard.TargetingType == TargetingType.None ||
						    (!heroPowerCard.TargetingAvailabilityPredicate?.Invoke(this, heroPowerCard) ?? false))
							buffer.Add(HeroPowerTask.Any(this, skipPrePhase: true));
						else
						{
							var targets = OptionHelper.Targets.Get(this, in heroPowerCard, ref cache, flags);
							foreach (Character target in targets)
								buffer.Add(HeroPowerTask.Any(this, target, skipPrePhase: true));
						}
					}
				}
			}
			#endregion

			#region MinionAttackTasks
			ReadOnlySpan<MinionInPlay> attackTargets = default;
			bool isOpHeroValidAttackTarget = true;
			ReadOnlySpan<MinionInPlay> boardSpan = BoardZone.GetSpan();
			if (!boardSpan.IsEmpty)
			{
				ReadOnlySpan<MinionInPlay> enemyMinions;
				if (!flags[2])
				{
					enemyMinions = OptionHelper.GetTargetableEnemyMinions(Opponent);
					flags[2] = true;
				}
				else
				{
					enemyMinions = cache.EnemyMinions;
				}

				attackTargets = OptionHelper.GetAttackableMinions(in enemyMinions, ref isOpHeroValidAttackTarget);

				if (isOpHeroValidAttackTarget)
				{
					if (flags[5])
						isOpHeroValidAttackTarget = cache.EnemyHero != null;
					else
						isOpHeroValidAttackTarget = !Opponent.Hero.IsImmune && !Opponent.Hero.HasStealth;
				}

				for (int j = 0; j < boardSpan.Length; j++)
				{
					MinionInPlay minion = boardSpan[j];

					//if (minion.IsExhausted && (!minion.HasCharge || minion.NumAttacksThisTurn != 0))
					//	continue;
					//if (minion.IsFrozen || minion.AttackDamage == 0 || minion.CantAttack || minion.Untouchable)
					//	continue;

					if (!minion.CanAttack(false)) continue;

					for (int i = 0; i < attackTargets.Length; i++)
						buffer.Add(MinionAttackTask.Any(this, minion, attackTargets[i], skipPrePhase));

					if (isOpHeroValidAttackTarget && !(minion.CantAttackHeroes || minion.AttackableByRush))
						buffer.Add(MinionAttackTask.Any(this, minion, Opponent.Hero, skipPrePhase));
				}
			}
			#endregion

			#region HeroAttackTasks
			HeroInPlay hero = Hero;

			if ((!hero.IsExhausted || (hero.ExtraAttacksThisTurn > 0 && hero.ExtraAttacksThisTurn >= hero.NumAttacksThisTurn))
			    && hero.AttackDamage > 0 && !hero.IsFrozen)
			{
				if (attackTargets.IsEmpty)
				{
					ReadOnlySpan<MinionInPlay> enemyMinions = !flags[2]
						? OptionHelper.GetTargetableEnemyMinions(Opponent)
						: cache.EnemyMinions;

					attackTargets = OptionHelper.GetAttackableMinions(in enemyMinions, ref isOpHeroValidAttackTarget);
				}

				for (int i = 0; i < attackTargets.Length; i++)
					buffer.Add(HeroAttackTask.Any(this, attackTargets[i], skipPrePhase));

				if (isOpHeroValidAttackTarget && !hero.CantAttackHeroes)
					buffer.Add(HeroAttackTask.Any(this, Opponent.Hero, skipPrePhase));
			}
			#endregion

			OptionHelper.ReturnArrays();
		}

		public unsafe void Options(PlayerTaskLiteContainer buffer, bool skipPrePhase = true)
		{
			buffer.Reset();

			if (this != Game.CurrentPlayer || Game.Step != Step.MAIN_ACTION) return;

			if (Choice != null)
			{
				if (Choice.ChoiceType != ChoiceType.GENERAL) return;

				for (int i = 0; i < Choice.Choices.Count; ++i)
					buffer.Add(PlayerTaskLite.Choose(i));
				return;
			}

			// EndTurnTask
			ref readonly PlayerTaskLite endTurnTask = ref PlayerTaskLite.EndTurnTask();
			buffer.Add(in endTurnTask);

			#region PlayCardTask
			// Flags
			// 0 : All Characters generated
			// 1 : Friendly Minions generated
			// 2 : Enemy Minions generated
			// 3 : All Minions generated
			// 4 : All Friendly Characters generated
			// 5 : All Enemy Characters generated
			// 6 : Defensible Targets generated
			bool* flags = stackalloc bool[7];
			Controller op = Opponent;
			Span<int> friendlyMinionIndices = stackalloc int[BoardZone.Count];
			Span<int> enemyMinionIndices = stackalloc int[op.BoardZone.Count];
			var cache = OptionHelper.TargetIndices.Initialise(in friendlyMinionIndices, in enemyMinionIndices);
			List<int[]> arraysToBeReturned = null;


			ReadOnlySpan<Playable> hand = HandZone.GetSpan();
			int mana = RemainingMana;
			for (int i = 0; i < hand.Length; ++i)
			{
				Playable playable = hand[i];
				Card card = playable.Card;
				CardType type = card.Type;
				if (!playable.ChooseOne || ChooseBoth)
				{
					if (OptionHelper.IsPlayable(this, in playable, in card, type, mana))
					{
						bool targetable = !card.TargetingAvailabilityPredicate?.Invoke(this, card) ?? false;

						// Card doesn't require any targets
						if (targetable || card.TargetingType == TargetingType.None)
						{
							if (type == CardType.MINION)
								for (int j = 0; j <= BoardZone.Count; j++)
									buffer.Add(PlayerTaskLite.PlayCard(i, -1, j, skipPrePhase: skipPrePhase));
							else
								buffer.Add(PlayerTaskLite.PlayCard(i, -1, skipPrePhase: skipPrePhase));

							continue;
						}


						var targets = OptionHelper.TargetIndices.Get(this, in card, ref cache, flags);

						targets.Filter(this, type, card.TargetingPredicate, arraysToBeReturned);

						if (targets.IsEmpty())
						{
							if (card.MustHaveTargetToPlay)
								continue;

							if (type == CardType.MINION)
								for (int j = 0; j <= BoardZone.Count; j++)
									buffer.Add(PlayerTaskLite.PlayCard(i, -1, j, -1, skipPrePhase));
							else
								buffer.Add(PlayerTaskLite.PlayCard(i, skipPrePhase: skipPrePhase));
						}
						else
						{
							foreach (int index in targets)
							{
								if (type == CardType.MINION)
									for (int j = 0; j <= BoardZone.Count; j++)
										buffer.Add(PlayerTaskLite.PlayCard(i, index, j, -1, skipPrePhase));
								else
									buffer.Add(PlayerTaskLite.PlayCard(i, index, -1, -1, skipPrePhase));
							}
						}
					}
				}
				else
				{
					//Playable[] playables = hand[i].ChooseOnePlayables;
					//for (int j = 0; j < playables.Length; j++)
					//	OptionHelper.GetPlayCardTasks(in hand[i], playables[j], j + 1);
				}
			}
			#endregion

			#region HeroPowerTask
			HeroPower power = Hero.HeroPower;
			Card heroPowerCard = power.Card;
			if (!power.IsExhausted && mana >= power.Cost &&
			    !HeroPowerDisabled && !heroPowerCard.HideStat)
			{
				if (heroPowerCard.ChooseOne)
				{
					if (ChooseBoth)
						buffer.Add(PlayerTaskLite.HeroPower(skipPrePhase: skipPrePhase));
					else
					{
						buffer.Add(PlayerTaskLite.HeroPower(chooseOne: 1, skipPrePhase: skipPrePhase));
						buffer.Add(PlayerTaskLite.HeroPower(chooseOne: 2, skipPrePhase: skipPrePhase));
					}
				}
				else
				{
					if (heroPowerCard.IsPlayableByCardReq(this))
					{
						if (heroPowerCard.TargetingType == TargetingType.None ||
							(!heroPowerCard.TargetingAvailabilityPredicate?.Invoke(this, heroPowerCard) ?? false))
							buffer.Add(PlayerTaskLite.HeroPower(skipPrePhase: skipPrePhase));
						else
						{
							var targets = OptionHelper.TargetIndices.Get(this, in heroPowerCard, ref cache, flags);
							foreach (int index in targets)
								buffer.Add(PlayerTaskLite.HeroPower(index, skipPrePhase: skipPrePhase));
						}
					}
				}
			}
			#endregion

			#region MinionAttackTasks
			bool isOpHeroValidAttackTarget = true;
			ReadOnlySpan<MinionInPlay> boardSpan = BoardZone.GetSpan();
			if (!boardSpan.IsEmpty)
			{
				if (!flags[2])
					enemyMinionIndices = OptionHelper.GetTargetableEnemyMinionIndices(Opponent, enemyMinionIndices);
				else
					enemyMinionIndices = cache.EnemyMinions;

				enemyMinionIndices =
					OptionHelper.GetDefensibleMinionIndices(op.BoardZone.GetSpan(),
						enemyMinionIndices, ref isOpHeroValidAttackTarget);

				flags[6] = true;

				if (isOpHeroValidAttackTarget)
				{
					if (flags[5])
						isOpHeroValidAttackTarget = cache.EnemyHero;
					else
						isOpHeroValidAttackTarget = !op.Hero.IsImmune && !op.Hero.HasStealth;
				}

				for (int j = 0; j < boardSpan.Length; j++)
				{
					if (!boardSpan[j].CanAttack(false)) continue;

					for (int i = 0; i < enemyMinionIndices.Length; i++)
						buffer.Add(PlayerTaskLite.MinionAttackTask(j, enemyMinionIndices[i], skipPrePhase));

					if (isOpHeroValidAttackTarget && !(boardSpan[j].CantAttackHeroes || boardSpan[j].AttackableByRush))
						buffer.Add(PlayerTaskLite.MinionAttackTask(j, 7, skipPrePhase));
				}
			}
			#endregion

			#region HeroAttackTasks
			HeroInPlay hero = Hero;

			if ((!hero.IsExhausted || (hero.ExtraAttacksThisTurn > 0 && hero.ExtraAttacksThisTurn >= hero.NumAttacksThisTurn))
				&& hero.AttackDamage > 0 && !hero.IsFrozen)
			{
				if (!flags[6])
				{
					if (!flags[2])
						enemyMinionIndices = OptionHelper.GetTargetableEnemyMinionIndices(Opponent, enemyMinionIndices);
					else
						enemyMinionIndices = cache.EnemyMinions;

					enemyMinionIndices =
						OptionHelper.GetDefensibleMinionIndices(op.BoardZone.GetSpan(),
							enemyMinionIndices, ref isOpHeroValidAttackTarget);

					if (isOpHeroValidAttackTarget)
					{
						if (flags[5])
							isOpHeroValidAttackTarget = cache.EnemyHero;
						else
							isOpHeroValidAttackTarget = !op.Hero.IsImmune && !op.Hero.HasStealth;
					}
				}

				for (int i = 0; i < enemyMinionIndices.Length; i++)
					buffer.Add(PlayerTaskLite.HeroAttackTask(enemyMinionIndices[i], true));

				if (isOpHeroValidAttackTarget && !hero.CantAttackHeroes)
					buffer.Add(PlayerTaskLite.HeroAttackTask(7, true));
			}
			#endregion

			//ArrayPool<int>.Shared.Return(friendlyArray);
			//ArrayPool<int>.Shared.Return(enemyArray);
		}

		//public unsafe void Options_with_methods(PlayerTaskLiteContainer buffer, bool skipPrePhase = true)
		//{
		//	buffer.Reset();

		//	if (this != Game.CurrentPlayer || Game.Step != Step.MAIN_ACTION) return;

		//	// EndTurnTask
		//	ref readonly PlayerTaskLite endTurnTask = ref PlayerTaskLite.EndTurnTask();
		//	buffer.Add(in endTurnTask);

		//	OptionHelper.GetPlayTasks(this, HandZone.GetSpan(), buffer, skipPrePhase);
		//}
	}

	public static class OptionHelper
	{
		//public static unsafe void GetPlayTasks(Controller c, ReadOnlySpan<Playable> hand, PlayerTaskLiteContainer buffer,
		//	bool skipPrePhase)
		//{
		//	int mana = c.RemainingMana;
		//	bool chooseBoth = c.ChooseBoth;
		//	int boardCount = c.BoardZone.Count;

		//	int* withTargets = stackalloc int[hand.Length];
		//	int n = 0;
		//	bool heroPowerNeedsTargets = false;

		//	Playable playable;
		//	Card card;
		//	for (int i = 0; i < hand.Length; ++i)
		//	{
		//		playable = hand[i];
		//		card = playable.Card;
		//		CardType type = card.Type;
		//		if (!playable.ChooseOne || chooseBoth)
		//		{
		//			if (IsPlayable(c, in playable, in card, type, mana))
		//			{
		//				bool targetable = !card.TargetingAvailabilityPredicate?.Invoke(c, card) ?? false;

		//				// Card doesn't require any targets
		//				if (targetable || card.TargetingType == TargetingType.None)
		//				{
		//					if (type == CardType.MINION)
		//						for (int j = 0; j <= boardCount; j++)
		//							buffer.Add(PlayerTaskLite.PlayCard(i, -1, j, skipPrePhase: skipPrePhase));
		//					else
		//						buffer.Add(PlayerTaskLite.PlayCard(i, -1, skipPrePhase: skipPrePhase));

		//					continue;
		//				}

		//				withTargets[n++] = i;
		//			}
		//		}
		//		else
		//		{
		//			//Playable[] playables = hand[i].ChooseOnePlayables;
		//			//for (int j = 0; j < playables.Length; j++)
		//			//	OptionHelper.GetPlayCardTasks(in hand[i], playables[j], j + 1);
		//		}
		//	}

		//	playable = c.Hero.HeroPower;
		//	card = playable.Card;
		//	if (!playable.IsExhausted && mana >= playable.Cost &&
		//	    !c.HeroPowerDisabled && !card.HideStat)
		//	{
		//		if (card.ChooseOne)
		//		{
		//			if (chooseBoth)
		//				buffer.Add(PlayerTaskLite.HeroPower(skipPrePhase: skipPrePhase));
		//			else
		//			{
		//				buffer.Add(PlayerTaskLite.HeroPower(chooseOne: 1, skipPrePhase: skipPrePhase));
		//				buffer.Add(PlayerTaskLite.HeroPower(chooseOne: 2, skipPrePhase: skipPrePhase));
		//			}
		//		}
		//		else
		//		{
		//			if (card.IsPlayableByCardReq(c))
		//			{
		//				if (card.TargetingType == TargetingType.None ||
		//				    (!card.TargetingAvailabilityPredicate?.Invoke(c, card) ?? false))
		//					buffer.Add(PlayerTaskLite.HeroPower(skipPrePhase: skipPrePhase));
		//				else
		//					heroPowerNeedsTargets = true;
		//			}
		//		}
		//	}

		//	for (int i = 0; i < n; ++i)
		//	{

		//	}
		//	if (heroPowerNeedsTargets)
		//	{
		//		var targets = OptionHelper.TargetIndices.Get(c, in card, ref cache, flags);
		//		foreach (int index in targets)
		//			buffer.Add(PlayerTaskLite.HeroPower(index, skipPrePhase: skipPrePhase));
		//	}

		//}

		//public static unsafe void GetPlayTaskWithTargets(Controller c, ReadOnlySpan<Playable> hand,
		//	int* indices, int n, bool heropower, PlayerTaskLiteContainer buffer, bool skipPrePhase = true)
		//{
		//	List<int[]> arraysToBeReturned = null;
		//	int boardCount = c.BoardZone.Count;
		//	// Flags
		//	// 0 : All Characters generated
		//	// 1 : Friendly Minions generated
		//	// 2 : Enemy Minions generated
		//	// 3 : All Minions generated
		//	// 4 : All Friendly Characters generated
		//	// 5 : All Enemy Characters generated
		//	// 6 : Defensible Targets generated
		//	bool* flags = stackalloc bool[7];
		//	Span<int> friendlyMinionIndices = stackalloc int[boardCount];
		//	Span<int> enemyMinionIndices = stackalloc int[c.Opponent.BoardZone.Count];
		//	TargetIndices cache = TargetIndices.Initialise(in friendlyMinionIndices, in enemyMinionIndices);

		//	for (int i = 0; i < n; ++i)
		//	{
		//		Card card = hand[indices[i]].Card;
		//		CardType type = card.Type;

		//		targets = TargetIndices.Get(c, in card, ref cache, flags);

		//		targets.Filter(c, type, card.TargetingPredicate, arraysToBeReturned);

		//		if (targets.IsEmpty())
		//		{
		//			if (card.MustHaveTargetToPlay)
		//				continue;

		//			if (type == CardType.MINION)
		//				for (int j = 0; j <= boardCount; j++)
		//					buffer.Add(PlayerTaskLite.PlayCard(i, -1, j, -1, skipPrePhase));
		//			else
		//				buffer.Add(PlayerTaskLite.PlayCard(i, skipPrePhase: skipPrePhase));
		//		}
		//		else
		//		{
		//			foreach (int index in targets)
		//			{
		//				if (type == CardType.MINION)
		//					for (int j = 0; j <= boardCount; j++)
		//						buffer.Add(PlayerTaskLite.PlayCard(i, index, j, -1, skipPrePhase));
		//				else
		//					buffer.Add(PlayerTaskLite.PlayCard(i, index, -1, -1, skipPrePhase));
		//			}
		//		}
		//	}

		//	if (s)
		//}

		public static unsafe void GetHeroPowerTasks(Controller c, HeroPower power, int mana, PlayerTaskLiteContainer buffer,
			ref TargetIndices cache, bool* flags)
		{
			Card heroPowerCard = power.Card;
			if (!power.IsExhausted && mana >= power.Cost &&
			    !c.HeroPowerDisabled && !heroPowerCard.HideStat)
			{
				if (heroPowerCard.ChooseOne)
				{
					if (c.ChooseBoth)
						buffer.Add(PlayerTaskLite.HeroPower());
					else
					{
						buffer.Add(PlayerTaskLite.HeroPower(chooseOne: 1));
						buffer.Add(PlayerTaskLite.HeroPower(chooseOne: 2));
					}
				}
				else
				{
					if (heroPowerCard.IsPlayableByCardReq(c))
					{
						if (heroPowerCard.TargetingType == TargetingType.None ||
						    (!heroPowerCard.TargetingAvailabilityPredicate?.Invoke(c, heroPowerCard) ?? false))
							buffer.Add(PlayerTaskLite.HeroPower());
						else
						{
							var targets = TargetIndices.Get(c, in heroPowerCard, ref cache, flags);
							foreach (int index in targets)
								buffer.Add(PlayerTaskLite.HeroPower(index));
						}
					}
				}
			}
		}


		public static bool IsPlayable(in Controller controller, in Playable playable, in Card card, CardType type, int mana)
		{
			if (card.HideStat) return false;

			if (playable.Cost > mana)
			{
				bool healthCost = (playable.CardCostsHealth) ||
				                  (controller.SpellsCostHealth && type == CardType.SPELL);

				if (!healthCost)
					return false;
			}

			// check PlayableByPlayer
			switch (type)
			{
				//	REQ_MINION_CAP
				case CardType.MINION when controller.BoardZone.IsFull:
					return false;
				case CardType.SPELL:
				{
					if (card.IsSecret)
					{
						if (controller.SecretZone.IsFull) // REQ_SECRET_CAP
							return false;

						{
							ReadOnlySpan<Spell> span = controller.SecretZone.GetSpan();
							for (int i = 0; i < span.Length; ++i)
								if (span[i].Card.AssetId == card.AssetId)  // REQ_UNIQUE_SECRET
									return false;
						}
					}

					if (card.IsQuest && controller.SecretZone.Quest != null)
						return false;
					break;
				}
			}

			return card.IsPlayableByCardReq(controller);
		}

		public static ReadOnlySpan<MinionInPlay> GetTargetableFriendlyMinions(in Controller controller)
		{
			ReadOnlySpan<MinionInPlay> board = controller.BoardZone.GetSpan();
			Span<int> indices = stackalloc int[7];
			int n = 0;
			for (int i = 0; i < board.Length; ++i)
			{
				if (board[i].Untouchable)
					continue;
				indices[n++] = i;
			}

			if (n == board.Length)
				return board;

			MinionInPlay[] array = Rent();
			for (int i = 0; i < n; ++i)
				array[i] = board[indices[i]];

			return array.AsSpan().Slice(0, n);
		}

		public static Span<int> GetTargetableFriendlyMinionIndices(in Controller controller, Span<int> indices)
		{
			ReadOnlySpan<MinionInPlay> board = controller.BoardZone.GetSpan();
			int n = 0;
			for (int i = 0; i < board.Length; ++i)
			{
				if (board[i].Untouchable) continue;
				indices[n++] = i;
			}

			return indices.Slice(0, n);
		}

		public static ReadOnlySpan<MinionInPlay> GetTargetableEnemyMinions(Controller opponent)
		{
			ReadOnlySpan<MinionInPlay> board = opponent.BoardZone.GetSpan();

			Span<int> indices = stackalloc int[7];
			int n = 0;
			for (int i = 0; i < board.Length; ++i)
			{
				if (board[i].HasStealth || board[i].IsImmune || board[i].Untouchable)
					continue;
				indices[n++] = i;
			}

			if (n == board.Length)
				return board;

			MinionInPlay[] array = Rent();
			for (int i = 0; i < n; ++i)
				array[i] = board[indices[i]];

			return array.AsSpan().Slice(0, n);
		}

		public static Span<int> GetTargetableEnemyMinionIndices(Controller opponent, Span<int> indices)
		{
			ReadOnlySpan<MinionInPlay> board = opponent.BoardZone.GetSpan();
			int n = 0;
			for (int i = 0; i < board.Length; ++i)
			{
				if (board[i].HasStealth || board[i].IsImmune || board[i].Untouchable) continue;
				indices[n++] = i;
			}
			return indices.Slice(0, n);
		}

		public static ReadOnlySpan<MinionInPlay> GetAttackableMinions(in ReadOnlySpan<MinionInPlay> eMinions,
			ref bool isOpHeroValidAttackTarget)
		{
			if (eMinions.IsEmpty)
				return eMinions;

			Span<int> tauntIndices = stackalloc int[eMinions.Length];
			int tauntCount = 0;
			for (int i = 0; i < eMinions.Length; ++i)
				if (eMinions[i].HasTaunt)
					tauntIndices[tauntCount++] = i;

			if (tauntCount > 0)
			{
				MinionInPlay[] arr = Rent();
				for (int i = 0; i < tauntCount; ++i)
					arr[i] = eMinions[tauntIndices[i]];

				isOpHeroValidAttackTarget = false;
				return arr.AsSpan(0, tauntCount);
			}

			return eMinions;
		}

		public static Span<int> GetDefensibleMinionIndices(ReadOnlySpan<MinionInPlay> opBoard,
			Span<int> indices, ref bool isOpHeroValidAttackTarget)
		{
			if (indices.IsEmpty) return indices;

			Span<int> tauntIndices = stackalloc int[indices.Length];
			int n = 0;
			for (int i = 0; i < indices.Length; ++i)
				if (opBoard[indices[i]].HasTaunt)
					tauntIndices[n++] = i;
			if (n > 0)
			{
				isOpHeroValidAttackTarget = false;
				tauntIndices.CopyTo(indices);
				return indices.Slice(0, n);
			}

			return indices;
		}

		public ref struct Targets
		{
			public bool Empty;
			public HeroInPlay FriendlyHero;
			public HeroInPlay EnemyHero;
			public ReadOnlySpan<MinionInPlay> FriendlyMinions;
			public ReadOnlySpan<MinionInPlay> EnemyMinions;

			public void Create(TargetingType type, ref Targets targets)
			{
				//Targets targets = new Targets();

				switch (type)
				{
					case TargetingType.FriendlyCharacters:
						targets.FriendlyHero = FriendlyHero;
						targets.FriendlyMinions = FriendlyMinions;
						break;
					case TargetingType.EnemyCharacters:
						if (EnemyHero == null && EnemyMinions.IsEmpty)
						{
							targets.Empty = true;
							break;
						}
						targets.EnemyHero = EnemyHero;
						targets.EnemyMinions = EnemyMinions;
						break;
					case TargetingType.AllMinions:
						if (FriendlyMinions.IsEmpty && EnemyMinions.IsEmpty)
						{
							targets.Empty = true;
							break;
						}
						targets.FriendlyMinions = FriendlyMinions;
						targets.EnemyMinions = EnemyMinions;
						break;
					case TargetingType.FriendlyMinions:
						if (FriendlyMinions.IsEmpty)
						{
							targets.Empty = true;
							break;
						}
						targets.FriendlyMinions = FriendlyMinions;
						break;
					case TargetingType.EnemyMinions:
						if (EnemyMinions.IsEmpty)
						{
							targets.Empty = true;
							break;
						}
						targets.EnemyMinions = EnemyMinions;
						break;
					case TargetingType.Heroes:
						targets.FriendlyHero = FriendlyHero;
						targets.EnemyHero = EnemyHero;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(type), type, null);
				}
			}

			public static unsafe Targets Get(in Controller controller, in Card card, ref Targets cache, bool* flags)
			{
				Targets targets = new Targets();
				switch (card.TargetingType)
				{
					case TargetingType.All:
						if (flags[0])
						{
							targets = cache;
							break;
						}
						if (!flags[5])
						{
							HeroInPlay opHero = controller.Opponent.Hero;
							if (!opHero.HasStealth && !opHero.IsImmune)
								cache.EnemyHero = opHero;
							if (!flags[2])
							{
								cache.EnemyMinions = GetTargetableEnemyMinions(controller.Opponent);
								flags[2] = true;
							}
							flags[5] = true;
						}
						if (!flags[4])
						{
							cache.FriendlyHero = controller.Hero;
							if (!flags[1])
							{
								cache.FriendlyMinions = GetTargetableFriendlyMinions(in controller);
								flags[1] = true;
							}
							flags[4] = true;
						}
						if (targets.EnemyMinions.IsEmpty && targets.FriendlyMinions.IsEmpty && targets.EnemyHero == null)
							targets.Empty = true;
						flags[0] = true;
						targets = cache;
						break;
					case TargetingType.FriendlyCharacters:
						if (!flags[4])
						{
							cache.FriendlyHero = controller.Hero;
							if (!flags[1])
							{
								cache.FriendlyMinions = GetTargetableFriendlyMinions(in controller);
								flags[1] = true;
							}

							flags[4] = true;
							cache.Create(TargetingType.FriendlyCharacters, ref targets);
						}
						else
							cache.Create(TargetingType.FriendlyCharacters, ref targets);
						break;
					case TargetingType.EnemyCharacters:
						if (!flags[5])
						{
							HeroInPlay opHero = controller.Opponent.Hero;
							if (!opHero.HasStealth && !opHero.IsImmune)
								cache.EnemyHero = opHero;
							if (!flags[2])
							{
								cache.EnemyMinions = GetTargetableEnemyMinions(controller.Opponent);
								flags[2] = true;
							}
							flags[5] = true;
							cache.Create(TargetingType.EnemyCharacters, ref targets);
						}
						else
							cache.Create(TargetingType.EnemyCharacters, ref targets);
						break;
					case TargetingType.AllMinions:
						if (flags[3])
							 cache.Create(TargetingType.AllMinions, ref targets);
						if (!flags[2])
						{
							cache.EnemyMinions = GetTargetableEnemyMinions(controller.Opponent);
							flags[2] = true;
						}
						if (!flags[1])
						{
							cache.FriendlyMinions = GetTargetableFriendlyMinions(in controller);
							flags[1] = true;
						}
						flags[3] = true;
						cache.Create(TargetingType.AllMinions, ref targets);
						break;
					case TargetingType.FriendlyMinions:
						if (!flags[1])
						{
							cache.FriendlyMinions = GetTargetableFriendlyMinions(in controller);
							flags[1] = true;
						}
						cache.Create(TargetingType.FriendlyMinions, ref targets);
						break;
					case TargetingType.EnemyMinions:
						if (!flags[2])
						{
							cache.EnemyMinions = GetTargetableEnemyMinions(controller.Opponent);
							flags[2] = true;
						}
						cache.Create(TargetingType.EnemyMinions, ref targets);
						break;
					case TargetingType.Heroes:
						if (!flags[5])
						{
							HeroInPlay opHero = controller.Opponent.Hero;
							if (!opHero.HasStealth && !opHero.IsImmune)
								cache.EnemyHero = opHero;
						}
						cache.FriendlyHero = controller.Hero;
						cache.Create(TargetingType.Heroes, ref targets);
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(card.TargetingType), card.TargetingType, null);
				}

				targets.Filter(in card);

				return targets;
			}

			public unsafe void Filter(in Card card)
			{
				TargetingPredicate p = card.TargetingPredicate;
				bool isSpellOrHeropower = card.Type == CardType.SPELL || card.Type == CardType.HERO_POWER;

				if (p == null && !isSpellOrHeropower) return;
				FilterHero(ref FriendlyHero);
				FilterHero(ref EnemyHero);
				int* indices = stackalloc int[FriendlyMinions.Length > EnemyMinions.Length ? FriendlyMinions.Length : EnemyMinions.Length];
				if (p != null)
				{
					if (!FriendlyMinions.IsEmpty)
						FriendlyMinions = FilterSpanWithP(FriendlyMinions, indices, isSpellOrHeropower, p);
					if (!EnemyMinions.IsEmpty)
						EnemyMinions = FilterSpanWithP(EnemyMinions, indices, isSpellOrHeropower, p);
				}
				else
				{
					if (!FriendlyMinions.IsEmpty)
						FriendlyMinions = FilterSpan(FriendlyMinions, indices, isSpellOrHeropower);
					if (!EnemyMinions.IsEmpty)
						EnemyMinions = FilterSpan(EnemyMinions, indices, isSpellOrHeropower);
				}

				void FilterHero(ref HeroInPlay hero)
				{
					if (hero == null)
						return;
					bool flag = p?.Invoke(hero) ?? true;
					if (flag)
					{
						if (isSpellOrHeropower && hero.CantBeTargetedBySpells)
							hero = null;
					}
					else
					{
						hero = null;
					}
				}

				ReadOnlySpan<MinionInPlay> FilterSpan(ReadOnlySpan<MinionInPlay> span, int* indices, bool spell)
				{
					int n = 0;

					for (int i = 0; i < span.Length; ++i)
					{
						if (spell && span[i].CantBeTargetedBySpells)
							continue;
						indices[n++] = i;
					}
					if (n == span.Length) return span;

					MinionInPlay[] newArr = Rent();
					for (int i = 0; i < n; ++i)
						newArr[i] = span[indices[i]];
					return newArr.AsSpan();
				}

				ReadOnlySpan<MinionInPlay> FilterSpanWithP(ReadOnlySpan<MinionInPlay> span, int* indices, bool spell, TargetingPredicate predicate)
				{
					int n = 0;

					for (int i = 0; i < span.Length; ++i)
					{
						bool flag = predicate.Invoke(span[i]);
						if (!flag)
							continue;
						if (spell && span[i].CantBeTargetedBySpells)
							continue;
						indices[n++] = i;
					}
					if (n == span.Length) return span;

					var newArr = Rent();
					for (int i = 0; i < n; ++i)
						newArr[i] = span[indices[i]];
					return newArr.AsSpan();
				}
			}

			public ref struct Enumerator
			{
				private Targets _targets;
				private int _outerIndex;
				private int _innerIndex;

				public Character Current
				{
					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					get
					{
						switch (_outerIndex)
						{
							case 0:
								if (_targets.FriendlyHero == null)
								{
									++_outerIndex;
									goto case 1;
								}
								return _targets.FriendlyHero;
							case 1:
								++_outerIndex;
								if (_targets.EnemyHero == null)
								{
									goto case 2;
								}
								return _targets.EnemyHero;
							case 2:
								if (_targets.EnemyMinions.IsEmpty)
								{
									_outerIndex = 3;
									goto default;
								}
								return _targets.EnemyMinions[_innerIndex++];
							default:
								return _targets.FriendlyMinions[_innerIndex++];
						}
					}
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public Enumerator(Targets targets)
				{
					_targets = targets;
					_outerIndex = -1;
					_innerIndex = 0;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public bool MoveNext()
				{
					if (_outerIndex < 1)
					{
						++_outerIndex;
						return true;
					}

					if (_outerIndex == 1)
					{
						if (_targets.EnemyMinions.IsEmpty)
						{
							if (_targets.FriendlyMinions.IsEmpty)
								return false;
							else
							{
								_outerIndex = 3;
								return true;
							}
						}
						else
						{
							_outerIndex = 2;
							return true;
						}
					}

					if (_outerIndex == 2)
					{
						if (_innerIndex == _targets.EnemyMinions.Length)
						{
							if (_targets.FriendlyMinions.IsEmpty)
								return false;
							_innerIndex = 0;
							_outerIndex = 3;
							return true;
						}
						{
							return true;
						}
					}

					return _innerIndex != _targets.FriendlyMinions.Length;
				}
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(this);
			}
		}

		public unsafe ref struct TargetIndices
		{
			//public int FriendlyMinionsCount;
			//public int EnemyMinionsCount;
			public bool FriendlyHero;
			public bool EnemyHero;
			public Span<int> FriendlyMinions;
			public Span<int> EnemyMinions;
			//public Span<int> NonElusiveIndices;

			private TargetIndices(in Span<int> friendly, in Span<int> enemy)
			{
				FriendlyHero = true;
				EnemyHero = false;
				FriendlyMinions = friendly;
				EnemyMinions = enemy;
				//NonElusiveIndices = null;
			}

			private TargetIndices(in Span<int> minions, bool friendly)
			{
				if (friendly)
				{
					FriendlyHero = false;
					EnemyHero = false;
					FriendlyMinions = minions;
					EnemyMinions = null;
				}
				else
				{
					FriendlyHero = false;
					EnemyHero = false;
					FriendlyMinions = null;
					EnemyMinions = minions;
				}
				//NonElusiveIndices = null;
			}

			public static TargetIndices Initialise(in Span<int> friendly, in Span<int> enemy)
			{
				return new TargetIndices(in friendly, in enemy);
			}

			public static TargetIndices FriendlyCharacters(in Span<int> minions)
			{
				return new TargetIndices
				{
					FriendlyHero = true,
					FriendlyMinions = minions
				};
			}

			public static TargetIndices EnemyCharacters(bool hero, in Span<int> minions)
			{
				return new TargetIndices
				{
					EnemyHero = hero,
					EnemyMinions = minions
				};
			}

			public static TargetIndices FriendlyMinionTargets(in Span<int> minions)
			{
				return new TargetIndices(minions, true);
			}

			public static TargetIndices EnemyMinionTargets(in Span<int> minions)
			{
				return new TargetIndices(minions, false);
			}

			public static TargetIndices AllMinions(in Span<int> friendly, in Span<int> enemy)
			{
				return new TargetIndices
				{
					FriendlyMinions = friendly,
					EnemyMinions = enemy
				};
			}

			public static TargetIndices Get(in Controller controller, in Card card, ref TargetIndices cache, bool* flags)
			{
				TargetIndices targets;


				switch (card.TargetingType)
				{
					case TargetingType.All:
						if (flags[0])
						{
							targets = cache;
							break;
						}
						if (!flags[5])
						{
							HeroInPlay opHero = controller.Opponent.Hero;
							if (!opHero.HasStealth && !opHero.IsImmune)
								cache.EnemyHero = true;
							if (!flags[2])
							{
								cache.EnemyMinions =
									GetTargetableEnemyMinionIndices(controller.Opponent, cache.EnemyMinions);
								flags[2] = true;
							}
							flags[5] = true;
						}
						if (!flags[4])
						{
							if (!flags[1])
							{
								cache.FriendlyMinions =
									GetTargetableFriendlyMinionIndices(in controller, cache.FriendlyMinions);
								flags[1] = true;
							}
							flags[4] = true;
						}
						flags[0] = true;
						targets = cache;
						break;
					case TargetingType.FriendlyCharacters:
						if (!flags[4])
						{
							if (!flags[1])
							{
								cache.FriendlyMinions =
									GetTargetableFriendlyMinionIndices(in controller, cache.FriendlyMinions);
								flags[1] = true;
							}

							flags[4] = true;
						}
						targets = FriendlyCharacters(cache.FriendlyMinions);
						break;
					case TargetingType.EnemyCharacters:
						if (!flags[5])
						{
							HeroInPlay opHero = controller.Opponent.Hero;
							if (!opHero.HasStealth && !opHero.IsImmune)
								cache.EnemyHero = true;
							if (!flags[2])
							{
								cache.EnemyMinions =
									GetTargetableEnemyMinionIndices(controller.Opponent, cache.EnemyMinions);
								flags[2] = true;
							}
							flags[5] = true;
						}
						targets = EnemyCharacters(cache.EnemyHero, cache.EnemyMinions);
						break;
					case TargetingType.AllMinions:
						if (flags[3])
						{
							targets = AllMinions(cache.FriendlyMinions, cache.EnemyMinions);
							break;
						}
						if (!flags[2])
						{
							cache.EnemyMinions =
								GetTargetableEnemyMinionIndices(controller.Opponent, cache.EnemyMinions);
							flags[2] = true;
						}
						if (!flags[1])
						{
							cache.FriendlyMinions =
								GetTargetableFriendlyMinionIndices(in controller, cache.FriendlyMinions);
							flags[1] = true;
						}
						flags[3] = true;
						targets = AllMinions(cache.FriendlyMinions, cache.EnemyMinions);
						break;
					case TargetingType.FriendlyMinions:
						if (!flags[1])
						{
							cache.FriendlyMinions =
								GetTargetableFriendlyMinionIndices(in controller, cache.FriendlyMinions);
							flags[1] = true;
						}

						targets = FriendlyMinionTargets(cache.FriendlyMinions);
						break;
					case TargetingType.EnemyMinions:
						if (!flags[2])
						{
							cache.EnemyMinions =
								GetTargetableEnemyMinionIndices(controller.Opponent, cache.EnemyMinions);
							flags[2] = true;
						}

						targets = EnemyMinionTargets(cache.EnemyMinions);
						break;
					case TargetingType.Heroes:
						{
							HeroInPlay opHero = controller.Opponent.Hero;
							if (!opHero.HasStealth && !opHero.IsImmune)
								cache.EnemyHero = true;
							targets = new TargetIndices
							{
								FriendlyHero = true,
								EnemyHero = cache.EnemyHero
							};
						}
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				return targets;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool IsEmpty()
			{
				return !FriendlyHero && !EnemyHero && FriendlyMinions.IsEmpty && EnemyMinions.IsEmpty;
			}

			public void Filter(Controller controller, CardType type, in TargetingPredicate predicate,
				List<int[]> arraysToBeReturned)
			{
				bool spellOrHeropower = type == CardType.SPELL || type == CardType.HERO_POWER;
				if (FriendlyHero)
					FriendlyHero = FilterHero(controller.Hero, spellOrHeropower, in predicate);
				if (EnemyHero)
					EnemyHero = FilterHero(controller.Opponent.Hero, spellOrHeropower, in predicate);
				if (!FriendlyMinions.IsEmpty)
					FriendlyMinions = FilterIndices(FriendlyMinions, controller.BoardZone.GetSpan(),
						spellOrHeropower, in predicate, arraysToBeReturned);
				if (!EnemyMinions.IsEmpty)
					EnemyMinions = FilterIndices(EnemyMinions, controller.Opponent.BoardZone.GetSpan(),
						spellOrHeropower, in predicate, arraysToBeReturned);

				bool FilterHero(HeroInPlay hero, bool spell, in TargetingPredicate p)
				{
					bool flag = p?.Invoke(hero) ?? true;
					return !flag || !spell || !hero.CantBeTargetedBySpells;
				}

				Span<int> FilterIndices(Span<int> indices, ReadOnlySpan<MinionInPlay> span,
					bool spell, in TargetingPredicate p, List<int[]> arrays)
				{
					Span<int> filtered = stackalloc int[indices.Length];
					int n = 0;
					for (int i = 0; i < indices.Length; ++i)
					{
						MinionInPlay minion = span[indices[i]];
						bool flag = p?.Invoke(minion) ?? true;
						if (!flag) continue;
						if (spell && minion.CantBeTargetedBySpells) continue;
						filtered[n++] = indices[i];
					}

					if (n == indices.Length) return indices;

					if (arrays == null)
						arrays = new List<int[]>(2);
					int[] newArray = ArrayPool<int>.Shared.Rent(16);
					arrays.Add(newArray);
					var newSpan = new Span<int>(newArray, 0, n);
					filtered[..n].CopyTo(newSpan);
					return newSpan;
				}
			}

			public ref struct Enumerator
			{
				private TargetIndices _targets;
				private int _outerIndex;
				private int _innerIndex;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public Enumerator(in TargetIndices targets)
				{
					_targets = targets;
					_outerIndex = -1;
					_innerIndex = 0;
				}

				public int Current
				{
					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					get => _outerIndex switch
					{
						0 => 0,
						1 => 8,
						2 => _targets.EnemyMinions[_innerIndex++] + 9,
						3 => _targets.FriendlyMinions[_innerIndex++] + 1,
						_ => throw new ArgumentOutOfRangeException("Enumerator Error"),
					};
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public bool MoveNext()
				{
					switch (_outerIndex)
					{
						case -1:
							++_outerIndex;
							if (_targets.FriendlyHero)
								return true;
							goto case 0;
						case 0:
							++_outerIndex;
							if (_targets.EnemyHero)
								return true;
							goto case 1;
						case 1:
							++_outerIndex;
							if (_innerIndex != _targets.EnemyMinions.Length)
								return true;
							goto case 2;
						case 2:
							if (_innerIndex != _targets.EnemyMinions.Length)
								return true;
							++_outerIndex;
							_innerIndex = 0;
							goto case 3;
						case 3:
							return _innerIndex != _targets.FriendlyMinions.Length;
						default:
							throw new ArgumentOutOfRangeException("Enumerator Error");

					}
				}
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(in this);
			}
		}

		public static class SpanPool<T>
		{
			public static Span<T> Rent(int length = 7)
			{
				T[] array = ArrayPool<T>.Shared.Rent(length);
				ArraysToBeReturned.Add(array);
				return new Span<T>(array, 0, length);
			}

			public static void ReturnAll()
			{
				if (ArraysToBeReturned.Count == 0) return;
			}

			private static readonly List<T[]> ArraysToBeReturned
				= new List<T[]>();
		}

		public static MinionInPlay[] Rent()
		{
			MinionInPlay[] array = ArrayPool<MinionInPlay>.Shared.Rent(7);
			ArraysToBeReturned.Add(array);
			return array;
		}

		public static void ReturnArrays()
		{
			if (ArraysToBeReturned.Count == 0) return;

			ArrayPool<MinionInPlay> pool = ArrayPool<MinionInPlay>.Shared;
			for (int i = 0; i < ArraysToBeReturned.Count; ++i)
				pool.Return(ArraysToBeReturned[i], true);
			ArraysToBeReturned.Clear();
		}

		private static readonly List<MinionInPlay[]> ArraysToBeReturned = new List<MinionInPlay[]>();
	}
}
