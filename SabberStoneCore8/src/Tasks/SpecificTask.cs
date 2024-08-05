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
using System.Collections.ObjectModel;
using System.Linq;
using SabberStoneCore.Enums;
using SabberStoneCore.Conditions;
using SabberStoneCore.Model;
using SabberStoneCore.Tasks.SimpleTasks;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Actions;
using SabberStoneCore.Enchants;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Tasks
{
	internal static class SpecificTask
	{
		public static SimpleTask LivingMana
			=> ComplexTask.Create(
				new IncludeTask(EntityType.SOURCE),
				new FuncPlayablesTask(p =>
				{
					var result = new List<Playable>();
					Controller controller = p[0].Controller;
					int manaCrystal = (new[] { controller.BoardZone.MaxSize - controller.BoardZone.Count, controller.BaseMana }).Min();
					for (int i = 0; i < manaCrystal; i++)
					{
						result.Add(Entity.FromCard(controller, Cards.FromId("UNG_111t1")));
					}
					return result;
				}),
				new CountTask(EntityType.STACK),
				new SummonCopyTask(EntityType.STACK),
				new MathMultiplyTask(-1),
				new ManaCrystalEmptyTask(0, false, true)
			);

		public static SimpleTask PatchesThePirate
			=> ComplexTask.Create(
				new ConditionTask(EntityType.HERO, SelfCondition.IsNotBoardFull),
				new FlagTask(true, new RemoveFromDeck(EntityType.SOURCE)),
				new FlagTask(true, new SummonTask())
			);

		public static SimpleTask TotemicCall
			=> ComplexTask.Create(
				new FuncNumberTask(p =>
				{
					ReadOnlySpan<MinionInPlay> minions = p.Controller.BoardZone.GetSpan();
					Span<int> notContained = stackalloc int[4];
					int k = 0;
					string[] entourage = p.Card.Entourage;
					for (int i = 0; i < entourage.Length; i++)
					{
						string id = entourage[i];
						bool flag = false;
						for (int j = 0; j < minions.Length; j++)
						{
							Minion m = minions[j];
							if (id == m.Card.Id)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
							notContained[k++] = i;
					}
					Entity.FromCard(p.Controller, Cards.FromId(entourage[notContained[
							p.Game.Random.Next(k)]]), p.Controller.BoardZone);
					p.Game.OnRandomHappened(true);
					return 0;
				}));

		public static SimpleTask Betrayal
			=> ComplexTask.Create(
				new GetGameTagTask(GameTag.ATK, EntityType.TARGET),
				new IncludeAdjacentTask(EntityType.TARGET),
				new DamageNumberTask(EntityType.STACK));

		public static SimpleTask JusticarTrueheart
			=> ComplexTask.Create(
				new IncludeTask(EntityType.HERO_POWER),
				new FuncPlayablesTask(p =>
				{
					Controller controller = p[0].Controller;
					switch (p[0].Card.Id)
					{
						case "CS1h_001":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_PRIEST")) };
						case "CS2_017":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_DRUID")) };
						case "CS2_034":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_MAGE")) };
						case "CS2_049":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_SHAMAN")) };
						case "CS2_056":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_WARLOCK")) };
						case "CS2_083b":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_ROGUE")) };
						case "CS2_101":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_PALADIN")) };
						case "CS2_102":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_WARRIOR")) };
						case "DS1h_292":
							return new List<Playable> { Entity.FromCard(controller, Cards.FromId("AT_132_HUNTER")) };
					}
					return new List<Playable>();
				}),
				new ReplaceHeroPower()
			);

		public static SimpleTask Doppelgangster
			=> ComplexTask.Create(
				new IncludeTask(EntityType.SOURCE),
				new FuncPlayablesTask(p =>
				{
					var s = (Minion) p[0];
					Controller c = s.Controller;
					Minion left = null;
					Minion right = null;
					int space = c.BoardZone.MaxSize - c.BoardZone.Count;
					switch (s.Card.Id)
					{
						case "CFM_668":
							if (space > 0)
								left = (Minion) Entity.FromCard(c, Cards.FromId("CFM_668t"));
							if (space > 1)
								right = (Minion) Entity.FromCard(c, Cards.FromId("CFM_668t2"));
							break;
						case "CFM_668t":
							if (space > 0)
								left = (Minion)Entity.FromCard(c, Cards.FromId("CFM_668t2"));
							if (space > 1)
								right = (Minion)Entity.FromCard(c, Cards.FromId("CFM_668"));
							break;
						case "CFM_668t2":
							if (space > 0)
								left = (Minion)Entity.FromCard(c, Cards.FromId("CFM_668t"));
							if (space > 1)
								right = (Minion)Entity.FromCard(c, Cards.FromId("CFM_668"));
							break;
						default:
							throw new NotImplementedException();
					}
					if (left != null)
					{
						Generic.SummonBlock(c.Game, ref left, s.ZonePosition, s);
						s.AppliedEnchantments?.ForEach(e => Enchantment.GetInstance(c.Game, in c, left, left, e.Card));
						//left[GameTag.ATK] = s[GameTag.ATK];
						//left[GameTag.HEALTH] = s[GameTag.HEALTH];
						left.AttackDamage = s.AttackDamage;
						left.BaseHealth = s.BaseHealth;

						if (right != null)
						{
							Generic.SummonBlock(c.Game, ref right, s.ZonePosition + 1, s);
							s.AppliedEnchantments?.ForEach(e => Enchantment.GetInstance(c.Game, in c, right, right, e.Card));
							//right[GameTag.ATK] = s[GameTag.ATK];
							//right[GameTag.HEALTH] = s[GameTag.HEALTH];
							right.AttackDamage = s.AttackDamage;
							right.BaseHealth = s.BaseHealth;
						}
					}
					return null;
				})
			);

		public static SimpleTask MayorNoggenfogger =>
			new CustomTask((g, c, s, t, stack) =>
			{
				int opBoardCount = t.Controller.Opponent.BoardZone.CountExceptUntouchables;

				if (t is Character ch && ch.IsAttacking)
				{
					int index = g.Random.Next(opBoardCount + 1);
					g.CurrentEventData.EventTarget =
						index == opBoardCount
							? (Playable)ch.Controller.Opponent.Hero
							: ch.Controller.Opponent.BoardZone.HasUntouchables
								? ch.Controller.Opponent.BoardZone.GetAll(null)[index]
								: ch.Controller.Opponent.BoardZone[index];

					g.ProposedDefender = g.CurrentEventData.EventTarget.Id;
					g.OnRandomHappened(true);
					return;
				}

				//t.CardTarget = ((Playable)t).GetValidPlayTargets().RandomElement(g.Random).Id;
				g.CurrentEventData.EventTarget = ((Playable)t).GetValidPlayTargets().RandomElement(g.Random);
				g.OnRandomHappened(true);
			});

		// TODO The cache should be managed separately when using different decks 
		public static SimpleTask CuriousGlimmerroot
			=> new CustomTask((g,c,s,t,stack) =>
			{
				Controller op = c.Opponent;
				if (_glimmerrootMemory1 == null)
				{
					lock (locker)
					{
						var opClassCards = new List<Card>();
						_glimmerrootMemory2 = new HashSet<int>();
						_glimmerrootMemory3 = Cards.FormatTypeClassCards(c.Game.FormatType)[op.BaseClass]
							.Where(card => card.Class == op.BaseClass)
							.ToList()
							.AsReadOnly();
						foreach (Card card in op.DeckCards)
						{
							if (card.Class != op.BaseClass)
								continue;
							if (_glimmerrootMemory2.Contains(card.AssetId))
								continue;
							opClassCards.Add(card);
							_glimmerrootMemory2.Add(card.AssetId);
						}
						_glimmerrootMemory1 = opClassCards.AsReadOnly();
					}
				}

				if (_glimmerrootMemory1.Count == 0)
					return;

				//var result = new List<Card> { Util.Choose(_glimmerrootMemory1) };
				//while (result.Count < 3)
				//{
				//	Card pick = Util.Choose(_glimmerrootMemory3);
				//	if (_glimmerrootMemory2.Contains(pick.AssetId) || result.Contains(pick))
				//		continue;
				//	result.Add(pick);
				//}

				Util.DeepCloneableRandom rnd = g.Random;

				var result = new Card[3];
				result[0] = _glimmerrootMemory1.Choose(rnd);
				int count = 1;
				do
				{
					Card pick = _glimmerrootMemory3.Choose(rnd);
					if (_glimmerrootMemory2.Contains(pick.AssetId) || result.Contains(pick)) continue;
					result[count] = pick;
					count++;
				} while (count < 3);

				for (int i = 0; i < 3; i++)
				{
					int j = rnd.Next(i, 3);
					Card temp = result[i];
					result[i] = result[j];
					result[j] = temp;
				}
				Generic.CreateChoiceCards.Invoke(c, s, null, ChoiceType.GENERAL, ChoiceAction.GLIMMERROOT,
					result, null);
				g.OnRandomHappened(true);
			});
		private static IReadOnlyList<Card> _glimmerrootMemory1;
		private static HashSet<int> _glimmerrootMemory2;
		private static IReadOnlyList<Card> _glimmerrootMemory3;
		private static readonly object locker = new object();

		public static SimpleTask UngoroPack
			=> new CustomTask((g,c,s,t,stack) =>
			{
				int space = Controller.MaxHandSize - c.HandZone.Count;
				if (space >= 5)
					space = 5;
				else if (space == 0)
					return;
				//var pack = new List<Playable>(space);

				if (_ungoroPackMemory == null)
				{
					lock (locker)
					{
						var dic = new Dictionary<Rarity, Card[]>(4);
						Card[] ungCards = Cards.All.Where(card => card.Set == CardSet.UNGORO && card.Collectible && !card.IsQuest).ToArray();
						dic.Add(Rarity.COMMON, ungCards.Where(card => card.Rarity == Rarity.COMMON).ToArray());
						dic.Add(Rarity.RARE, ungCards.Where(card => card.Rarity == Rarity.RARE).ToArray());
						dic.Add(Rarity.EPIC, ungCards.Where(card => card.Rarity == Rarity.EPIC).ToArray());
						dic.Add(Rarity.LEGENDARY, ungCards.Where(card => card.Rarity == Rarity.LEGENDARY).ToArray());
						_ungoroPackMemory = new ReadOnlyDictionary<Rarity, Card[]>(dic);
					}
				}

				for (int i = 0; i < space; ++i)
				{
					Rarity rarity;
					double rnd = g.Random.NextDouble();

					// empirical result
					if (rnd < 0.19)
						rarity = Rarity.LEGENDARY;
					else if (rnd < 0.43)
						rarity = Rarity.EPIC;
					else if (rnd < 0.71)
						rarity = Rarity.RARE;
					else
						rarity = Rarity.COMMON;

					Card[] cards = _ungoroPackMemory[rarity];
					Card pick = cards[g.Random.Next(cards.Length)];
					Playable entity = Entity.FromCard(c, pick, zone: c.HandZone);
					entity.CreatorId = s.Id;
					//pack.Add(entity);
				}

				g.OnRandomHappened(true);
			});
		private static ReadOnlyDictionary<Rarity, Card[]> _ungoroPackMemory;

		// public static SimpleTask RandomHunterSecretPlay
		// 	=> ComplexTask.Create(
		// 		new IncludeTask(EntityType.TARGET),
		// 		new FuncPlayablesTask(p =>
		// 		{
		// 			Controller controller = p[0].Controller;
		// 			var activeSecrets = controller.SecretZone.Select(secret => secret.Card.Id).ToList();
		// 			//activeSecrets.Add(p[0].Card.Id);
		// 			IEnumerable<Card> cards = controller.Game.FormatType == FormatType.FT_STANDARD ? Cards.Standard[CardClass.HUNTER] : Cards.Wild[CardClass.HUNTER];
		// 			IEnumerable<Card> cardsList = cards.Where(card => card.Type == CardType.SPELL && card.Tags.ContainsKey(GameTag.SECRET) && !activeSecrets.Contains(card.Id));
		// 			var spell = (Spell)Entity.FromCard(controller, Util.Choose(cardsList.ToList()));
		// 			Generic.CastSpell(controller, spell, null, 0, true);
		// 			controller.Game.OnRandomHappened(true);
		// 			return new List<Playable>();
		// 		})
		// 	);

		public static SimpleTask Simulacrum
			=> ComplexTask.Create(
				new IncludeTask(EntityType.HAND),
				new FilterStackTask(SelfCondition.IsMinion),
				new FuncPlayablesTask(list =>
				{
					if (!list.Any())
						return new List<Playable>();
					int minCost = list.Min(p => p.Cost);
					return list.Where(p => p.Cost == minCost).ToArray();
				}),
				new RandomTask(1, EntityType.STACK),
				new CopyTask(EntityType.STACK, Zone.HAND));

		public static SimpleTask DeathsShadow
			=> ComplexTask.Create(
				new IncludeTask(EntityType.SOURCE),
				new FuncPlayablesTask(list =>
				{
					Playable p = list[0];
					if (p.Controller.HandZone.IsFull)
						return new List<Playable>(0);
					Playable entity = Entity.FromCard(p.Controller, Cards.FromId("ICC_827t"), p.Controller.HandZone, creator: p);
					return new List<Playable> {entity};
				}),
				new AddEnchantmentTask("ICC_827e", EntityType.STACK));

		public static SimpleTask ShadowReflection
			=> ComplexTask.Create(
				new IncludeTask(EntityType.SOURCE),
				new IncludeTask(EntityType.TARGET, null, true),
				new FuncPlayablesTask(pList =>
				{
					Enchantment e = (Enchantment) pList[0];
					Playable previous = (Playable) e.Target;
					e.Remove(true);

					Playable newEntity = Generic.ChangeEntityBlock.Invoke(e.Controller, previous, pList[1].Card, false);

					if (newEntity.CreatorId == 0)
						newEntity.CreatorId = e.Creator.Id;

					Generic.AddEnchantmentBlock(e.Game, e.Card, e, newEntity, 0, 0, 0);

					// TODO choose ones

					return null;
				}));

		public static SimpleTask ExplosiveRunes
			=> ComplexTask.Create(
				new ConditionTask(EntityType.EVENT_SOURCE, SelfCondition.IsNotDead, SelfCondition.IsNotUntouchable),
				new FlagTask(true, ComplexTask.Secret(
					new IncludeTask(EntityType.SOURCE),
					new IncludeTask(EntityType.EVENT_SOURCE, null, true),
					new FuncPlayablesTask(list =>
					{
						var target = (Minion) list[1];
						int health = target.Health;
						int amount = 6 + target.Controller.CurrentSpellPower;
						amount *= (int) Math.Pow(2, target.Controller.SpellPowerDouble);
						if (health >= amount)
						{
							Generic.DamageCharFunc(list[0], target, 6, true);
							return null;
						}
						target.TakeDamage(list[0], health);
						target.Controller.Hero.TakeDamage(list[0], amount - health);
						return null;
					}))));

		public static SimpleTask DiamondSpellstone(int i)
		{
			return ComplexTask.Create(
				new IncludeTask(EntityType.GRAVEYARD),
				new FuncPlayablesTask(list =>
				{
					list[0].Game.OnRandomHappened(true);
					Util.DeepCloneableRandom rnd = list[0].Game.Random;
					return list
						.Where(p => p is Minion m && m.IsDead)
						.Select(p => p.Card.Id)
						.Distinct()
						.OrderBy(p => rnd.Next())
						.Take(i)
						.Select(p => Entity.FromCard(list[0].Controller, Cards.FromId(p)))
						.ToList();
				}),
				new SummonStackTask());
		}

		public static SimpleTask Kingsbane
			=> ComplexTask.Create(
				new FuncNumberTask((Playable p) =>
				{
					Weapon deadWeapon = (Weapon) p;

					//var tags = new EntityData
					//{
					//	{GameTag.ATK, deadWeapon[GameTag.ATK]},
					//	{GameTag.POISONOUS, deadWeapon[GameTag.POISONOUS]},
					//	{GameTag.LIFESTEAL, deadWeapon[GameTag.LIFESTEAL]}
					//};
					Weapon newWeapon = (Weapon) Entity.FromCard(deadWeapon.Controller, deadWeapon.Card);
					deadWeapon.AppliedEnchantments?.ForEach(e =>
					{
						Enchantment instance = Enchantment.GetInstance(deadWeapon.Game, deadWeapon.Controller, newWeapon, newWeapon, e.Card);
						if (e.ScriptTag1 > 0)
						{
							instance.ScriptTag1 = e.ScriptTag1;
							if (e.ScriptTag2 > 0)
								instance.ScriptTag2 = e.ScriptTag2;
						}
					});

					newWeapon._v1 = deadWeapon._v1;
					newWeapon._v2 = deadWeapon._v2;
					newWeapon.Poisonous = deadWeapon.Poisonous;
					newWeapon.HasLifesteal = deadWeapon.HasLifesteal;

					Generic.ShuffleIntoDeck(deadWeapon.Controller, newWeapon, newWeapon);
					return 0;
				}));

		public static SimpleTask DarknessCandle
			=> ComplexTask.Create(
				new FuncNumberTask(p =>
				{
					Minion[] targets = p.Controller.Opponent.BoardZone.Where(m => m.Card.Id == "LOOT_526d").ToArray();
					if (targets.Length == 0) return 0;
					for (int i = 0; i < targets.Length; i++)
					{
						SimpleTask task = DarknessCandleInternal;
						p.Game.TaskQueue.Execute(task, p.Controller, targets[i], null);
					}
					return 0;
				}),
				new DrawTask());
		private static SimpleTask DarknessCandleInternal
			=> ComplexTask.Create(
				new GetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_1, EntityType.SOURCE),
				new MathAddTask(1),
				new SetGameTagNumberTask(GameTag.TAG_SCRIPT_DATA_NUM_1, EntityType.SOURCE),
				new SetGameTagNumberTask(GameTag.SCORE_VALUE_2, EntityType.SOURCE),
				new GetGameTagTask(GameTag.TAG_SCRIPT_DATA_NUM_2, EntityType.SOURCE, 0, 1),
				new NumberConditionTask(RelaSign.EQ),
				new FlagTask(true, new FuncNumberTask(q =>
				{
					// TODO ChangeEntityBlock
					q.Card = Cards.FromId("LOOT_526");
					q.Controller.BoardZone.DecrementUntouchablesCount();
					return 0;
				})));

		public static SimpleTask LynessaSunsorrow
			=> new FuncNumberTask(p =>
			{
				int original = p.Card.AssetId;
				Controller c = p.Controller;
				Game g = c.Game;
				List<PlayHistoryEntry> history = c.PlayHistory;

				List<PlayHistoryEntry> spellCards = history
					.Where(current => current.SourceController == current.TargetController &&
					                  current.SourceCard.Type == CardType.SPELL)
					.ToList();

				spellCards.Shuffle(g.Random);
				for (int i = 0; i < spellCards.Count; i++)
				{
					Playable spell = Entity.FromCard(c, spellCards[i].SourceCard);
					Generic.CastSpell(c, g, (Spell)spell, (Character)p, spellCards[i].SubOption);
					while (c.Choice != null)
						Generic.ChoicePick(c, g, c.Choice.Choices.Choose(g.Random));
					if (p.Zone?.Type != Zone.PLAY || p.Card.AssetId != original)
						break;
				}

				c.Game.OnRandomHappened(true);

				return 0;
			});

		public static SimpleTask SwapDecks
			=> new FuncNumberTask(p =>
			{
				Controller c = p.Controller;
				Controller op = c.Opponent;

				DeckZone temp = c.DeckZone;
				temp.ForEach(x =>
				{
					x.Controller = op;
					x[GameTag.CONTROLLER] = op.PlayerId;
				});
				op.DeckZone.ForEach(x =>
				{
					x.Controller = c;
					x[GameTag.CONTROLLER] = c.PlayerId;
				});
				c.DeckZone = op.DeckZone;
				c.DeckZone.Controller = c;
				op.DeckZone = temp;
				temp.Controller = op;

				return 0;
			});

		public static SimpleTask TessGreymane
			=> new FuncNumberTask(p =>
			{
				Controller c = p.Controller;
				Game g = c.Game;

				IList<Card> playedCards = c.PlayHistory
					.Select(e => e.SourceCard)
					.Where(card => card.Class != CardClass.NEUTRAL && card.Class != c.Hero.Card.Class)
					.ToArray()
					.Shuffle(g.Random);

				foreach (Card card in playedCards)
				{
					Playable entity = Entity.FromCard(c, card);

					Character randTarget = entity.GetRandomValidTarget();

					if (card.MustHaveTargetToPlay && randTarget == null)
						continue;

					int randChooseOne = g.Random.Next(1, 3);

					c.Game.TaskQueue.StartEvent();
					switch (card.Type)
					{
						case CardType.MINION:
							if (c.BoardZone.IsFull) break;
							Generic.SummonBlock(c.Game, entity as Minion, -1, p);
							c.Game.DeathProcessingAndAuraUpdate();
							break;
						case CardType.WEAPON:
							var weapon = entity as Weapon;
							weapon.Card.Power?.Aura?.Activate(weapon);
							weapon.Card.Power?.Trigger?.Activate(c.Game, weapon);
							c.Hero.AddWeapon(weapon);
							break;
						case CardType.HERO:
							Generic.PlayHero(g, c, entity as Hero, randTarget, randChooseOne);
							break;
						case CardType.SPELL:
							Generic.CastSpell.Invoke(c, g, entity as Spell, randTarget, randChooseOne);
							c.Game.DeathProcessingAndAuraUpdate();
							break;
						default:
							throw new NotImplementedException();
					}

					g.TaskQueue.EndEvent();

					while (c.Choice != null)
					{
						g.TaskQueue.StartEvent();
						Generic.ChoicePick.Invoke(c, g, c.Choice.Choices.Choose(g.Random));
						g.ProcessTasks();
						g.TaskQueue.EndEvent();
						g.DeathProcessingAndAuraUpdate();
					}
				}
				return 0;
			});

		public static SimpleTask Shudderwock
			=> new FuncNumberTask(p =>
			{
				int original = p.Card.AssetId;
				Game game = p.Game;
				Controller c = p.Controller;

				IList<Card> playedCards = c.PlayHistory
					.Select(e => e.SourceCard)
					.Where(card => card[GameTag.BATTLECRY] == 1 && card.AssetId != 48111)
					.ToArray()
					.Shuffle(game.Random);

				int count = 0;
				foreach (Card card in playedCards)
				{
					var entity = Entity.FromCard(c, card); // TODO
					Character randTarget = entity.GetRandomValidTarget();

					if (card.MustHaveTargetToPlay && randTarget == null)
						continue;

					game.TaskQueue.StartEvent();
					entity.ActivateTask(PowerActivation.POWER, randTarget, 0, p);
					game.ProcessTasks();
					game.TaskQueue.EndEvent();
					game.DeathProcessingAndAuraUpdate();

					while (c.Choice != null)
					{
						game.TaskQueue.StartEvent();
						Generic.ChoicePick.Invoke(c, game, c.Choice.Choices.Choose(game.Random));
						game.ProcessTasks();
						game.TaskQueue.EndEvent();
						game.DeathProcessingAndAuraUpdate();
					}

					if (++count == 30) break;

					if (p is MinionInPlay m && m.ToBeDestroyed || p.Zone.Type != Zone.PLAY || p.Card.AssetId != original)
						break;
				}

				return 0;
			});

		public static SimpleTask ArcaneKeysmith =>
			new FuncNumberTask(source =>
			{
				if (source.Controller.SecretZone.IsFull) return 0;

				CardClass[] secretClasses = {CardClass.HUNTER, CardClass.PALADIN, CardClass.ROGUE};
				int[] existing = source.Controller.SecretZone.Select(p => p.Card.AssetId).ToArray();

				CardClass cls = source.Controller.Hero.Card.Class;

				if (!secretClasses.Contains(cls))
					cls = CardClass.MAGE;

				Card[] candidates = GetFormatTypeClassSecrets(source.Game.FormatType, cls)
					.Where(c => !existing.Contains(c.AssetId)).ToArray();

				Card[] choices = candidates.ChooseNElements(3, source.Game.Random);

				if (candidates.Length == 0) return 0;

				Generic.CreateChoiceCards(source.Controller, source, null, ChoiceType.GENERAL, ChoiceAction.CAST,
					choices, null);
				return 0;
			});

		public static SimpleTask CastRandomSecret(CardClass cardClass) =>
			new CustomTask((g,c,s,t,stack) =>
			{
				//if (c.SecretZone.IsFull) return;
				int[] activeSecrets = c.SecretZone.Select(secret => secret.Card.AssetId).ToArray();
				Card[] cardsList = GetFormatTypeClassSecrets(g.FormatType, cardClass)
					.Where(card => !activeSecrets.Contains(card.AssetId)).ToArray();
				Spell spell = (Spell)Entity.FromCard(c, cardsList.Choose(g.Random));
				Generic.CastSpell(c, g, spell, null, 0);
				g.OnRandomHappened(true);
			});

		private static Card[] GetFormatTypeClassSecrets(FormatType format, CardClass cardClass)
		{
			lock (locker)
			{
				if (_cachedSecrets == null || !_cachedSecrets.ContainsKey((format, cardClass)))
				{
					if (_cachedSecrets == null)
						_cachedSecrets = new Dictionary<(FormatType, CardClass), Card[]>();

					// This would not work when you would use both format types at the same time in a runtime
					_cachedSecrets.Add((format, cardClass), Cards.FormatTypeClassCards(format)[cardClass]
						.Where(card => card.IsSecret)
						.ToArray());
				}
			}

			return _cachedSecrets[(format, cardClass)];
		}

		private static Dictionary<(FormatType, CardClass), Card[]> _cachedSecrets;

		public static SimpleTask AzalinaSoulthief =>
			new FuncNumberTask(source =>
			{
				Controller c = source.Controller;
				SetasideZone setaside = c.SetasideZone;
				HandZone hand = c.HandZone, opHand = c.Opponent.HandZone;

				// Move hand cards to setaside.
				for (int i = hand.Count - 1; i >= 0; i--)
					setaside.Add(hand.Remove(hand[i]));

				// Create copies of opponent cards and add them to the hand
				// and move them to the opponent's setaside zone.
				for (int i = opHand.Count - 1; i >= 0; i--)
					Generic.Copy(in c, source, opHand[i], Zone.HAND);

				return 0;
			});

		public static SimpleTask GetRandomDrBoomHeroPower =>
			new FuncNumberTask(source =>
			{
				string nextId;
				Controller c = source.Controller;
				Util.DeepCloneableRandom rnd = source.Game.Random;

				if (source is HeroPower currentPower)
				{
					do
					{
						nextId = DrBoomHeroPowerIds.Choose(rnd);
					} while (nextId == currentPower.Card.Id);
				}
				else
				{
					nextId = DrBoomHeroPowerIds.Choose(rnd);
					currentPower = c.Hero.HeroPower;
				}
				c.SetasideZone.Add(currentPower);
				HeroPower nextPower = (HeroPower)Entity.FromCard(in c, Cards.FromId(nextId));
				c.Hero.HeroPower = nextPower;
				nextPower.Power?.Trigger?.Activate(c.Game, nextPower);

				return 0;
			});
		private static readonly IReadOnlyList<string> DrBoomHeroPowerIds = Cards.FromId("BOT_238p").Entourage;

		public static readonly SimpleTask Zuljin = new FuncNumberTask(ZuljinInternal);
		private static int ZuljinInternal(Playable source)
		{
			Controller c = source.Controller;
			Game g = c.Game;
			Util.DeepCloneableRandom rnd = g.Random;
			// Iterate through the play history of the controller.
			foreach (PlayHistoryEntry history in c.PlayHistory)
			{
				if (history.SourceCard.Type != CardType.SPELL)
					continue;

				Spell entity = (Spell) Entity.FromCard(in c, in history.SourceCard);
				Character randTarget = entity.GetRandomValidTarget();

				if (history.SourceCard.MustHaveTargetToPlay && randTarget == null)
					continue;

				Generic.CastSpell(c, g, entity, randTarget, history.SourceCard.ChooseOne ? rnd.Next(1, 3) : -1);
			}
			return 0;
		}

		public static readonly SimpleTask PrismaticLens =
			new FuncNumberTask(p =>
			{
				Controller c = p.Controller;
				ReadOnlySpan<Playable> deck = c.DeckZone.GetSpan();
				List<int> minions = new List<int>();
				List<int> spells = new List<int>();
				for (int i = 0; i < deck.Length; i++)
				{
					if (deck[i] is Minion)
						minions.Add(i);
					else if
						(deck[i] is Spell)
						spells.Add(i);

				}

				Util.DeepCloneableRandom rnd = c.Game.Random;
				int? minionToDraw = minions.Count == 0 ? null : (int?) minions[rnd.Next(minions.Count)];
				int? spellToDraw = spells.Count == 0 ? null : (int?) spells[rnd.Next(spells.Count)];

				if (minionToDraw == null)
				{
					Generic.Draw(c, spellToDraw.Value);
					return 0;
				}
				if (spellToDraw == null)
				{
					Generic.Draw(c, minionToDraw.Value);
					return 0;
				}

				Playable minion = Generic.Draw(c, minionToDraw.Value);
				Playable spell = Generic.Draw(c, spellToDraw.Value);

				int temp = minion.Cost;
				minion.Cost = spell.Cost;
				spell.Cost = temp;

				// TODO Enchantment BOT_436e

				return 0;
			});

		public static readonly SimpleTask MastersCall =
			new FuncNumberTask(p =>
			{
				Controller c = p.Controller;
				ReadOnlySpan<Playable> deck = c.DeckZone.GetSpan();
				List<Playable> minions = new List<Playable>();
				List<int> indices = new List<int>();
				for (int i = 0; i < deck.Length; i++)
				{
					if (deck[i].Card.Type == CardType.MINION)
					{
						bool contained = false;
						int id = deck[i].Card.AssetId;
						for (int j = 0; j < minions.Count; j++)
						{
							if (minions[j].Card.AssetId != id) continue;
							contained = true;
							break;
						}

						if (contained)
							continue;
						minions.Add(deck[i]);
						indices.Add(i);
					}
				}

				int count = minions.Count;

				if (count == 0) return 0;

				if (count <= 3)
				{
					minions.InsertionSort(indices);

					if (count == 3 && minions.TrueForAll(e => e.Card.IsRace(Race.BEAST)))
					{
						for (int i = count - 1; i >= 0; i--)
						{
							Playable playable = c.DeckZone.Remove(indices[i]);
							Generic.AddHandPhase(c, playable);
						}
					}
					else
					{
						for (int i = count - 1; i >= 0; i--)
							c.SetasideZone.Add(c.DeckZone.Remove(indices[i]));
						Generic.CreateChoice(c, p, ChoiceType.GENERAL, ChoiceAction.HAND,
							minions.Select(q => q.Id).ToList());
					}

					return 0;
				}

				Playable[] choices = new Playable[3];
				int[] choiceIndices = new int[3];
				int[] range = new int[count];
				for (int i = 0; i < range.Length; i++)
					range[i] = i;
				Util.DeepCloneableRandom rnd = p.Game.Random;
				for (int i = 0; i < 3; i++)
				{
					int j = rnd.Next(i, count);
					int temp = range[i];
					range[i] = range[j];
					range[j] = temp;
					choices[i] = minions[range[i]];
					choiceIndices[i] = indices[range[i]];
				}

				Array.Sort(choiceIndices, choices);
				if (Array.TrueForAll(choices, e => e.Card.IsRace(Race.BEAST)))
				{
					for (int i = choiceIndices.Length - 1; i >= 0; i--)
					{
						Playable playable = c.DeckZone.Remove(choiceIndices[i]);
						Generic.AddHandPhase(c, playable);
					}
				}
				else
				{
					for (int i = choiceIndices.Length - 1; i >= 0; i--)
						c.SetasideZone.Add(c.DeckZone.Remove(choiceIndices[i]));
					Generic.CreateChoice(c, p, ChoiceType.GENERAL, ChoiceAction.HAND,
						minions.Select(q => q.Id).ToList());
				}

				return 0;
			});

		public static readonly SimpleTask ArchmageVargoth =
			new CustomTask((g, c, s, t, stack) =>
			{
				List<Card> spellsPlayedThisTurn = new List<Card>();
				foreach (Card card in c.CardsPlayedThisTurn)
					if (card.Type == CardType.SPELL)
						spellsPlayedThisTurn.Add(card);
				if (spellsPlayedThisTurn.Count == 0) return;
				Util.DeepCloneableRandom rnd = g.Random;
				g.OnRandomHappened(true);

				Card randSpellCard = spellsPlayedThisTurn.Count == 1
					? spellsPlayedThisTurn[0]
					: spellsPlayedThisTurn[rnd.Next(spellsPlayedThisTurn.Count)];

				// TODO: Reveal card for history
				if (!randSpellCard.IsPlayableByCardReq(in c) ||
				    randSpellCard.IsSecret && c.SecretZone.IsFull ||
				    randSpellCard.IsQuest && c.SecretZone.Quest != null)
				{
					return;
				}

				Character randTarget;
				{
					List<Character> validTargets = randSpellCard.GetValidPlayTargets(in c);
					randTarget = validTargets.Count == 0 ? null : validTargets[rnd.Next(validTargets.Count)];
				}
				if (randSpellCard.MustHaveTargetToPlay && randTarget == null)
				{
					return;
				}

				Spell spellToCast = (Spell)Entity.FromCard(in c, in randSpellCard);

				int randChooseOne = rnd.Next(1, 3);

				Generic.CastSpell(c, g, spellToCast, randTarget, randChooseOne);

				while (c.Choice != null)
					Generic.ChoicePick(c, g, c.Choice.Choices[rnd.Next(c.Choice.Choices.Count)]);
			});

		public static readonly SimpleTask ImmortalPrelate =
			new CustomTask((g, c, s, t, stack) =>
			{
				//Minion source = (Minion)s;

				//Minion newEntity = (Minion) Entity.FromCard(in c, source.Card,
				//	zone: c.DeckZone, zonePos: g.Random.Next(c.DeckZone.Count));

				MinionInPlay source = (MinionInPlay) s;
				MinionInPlay newEntity = MinionInPlay.FromCard(in c, source.Card);
				Generic.ShuffleIntoDeck(c, source, newEntity);
				newEntity.CopyAttributesFrom(source);
				newEntity.Damage = 0;
				newEntity.IsFrozen = false;
				newEntity.IsImmune = false;
				newEntity.IsSilenced = false;

				if (source.AppliedEnchantments != null)
				{
					foreach (Enchantment e in source.AppliedEnchantments)
					{
						Enchantment instance = Enchantment.GetInstance(in g, in c, e.Creator, newEntity, e.Card);
						if (e.ScriptTag1 > 0)
						{
							instance.ScriptTag1 = e.ScriptTag1;
							if (e.ScriptTag2 > 0)
								instance.ScriptTag2 = e.ScriptTag2;
						}
						instance.CapturedCard = e.CapturedCard;

						if (e.IsOneTurnActive)
							instance.Game.OneTurnEffectEnchantments.Add(instance);
					}
				}



				List<(int entityId, AbstractEffect effect)> oneTurnEffects = g.OneTurnEffects;
				for (int i = oneTurnEffects.Count - 1; i >= 0; i--)
				{
					(int id, AbstractEffect effect) = oneTurnEffects[i];
					if (id == source.Id)
						oneTurnEffects.Add((newEntity.Id, effect));
				}
			});

		public class RenonunceDarkness : SimpleTask
		{
			private static readonly Card EnchantmentCard = Cards.FromId("OG_118e");

			public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
				in TaskStack stack = null)
			{
				Util.DeepCloneableRandom rnd = game.Random;

				// get a new class
				CardClass randClass;
				do
				{
					randClass = (CardClass) rnd.Next(2, 11);
				} while (randClass == CardClass.WARLOCK);
					
				// replace Hero Power
				Card heroPowerCard = null;
				switch (randClass)
				{
					case CardClass.DRUID:
						heroPowerCard = Cards.FromId("CS2_017");
						break;
					case CardClass.HUNTER:
						heroPowerCard = Cards.FromId("DS1h_292");
						break;
					case CardClass.MAGE:
						heroPowerCard = Cards.FromId("CS2_034");
						break;
					case CardClass.PALADIN:
						heroPowerCard = Cards.FromId("CS2_101");
						break;
					case CardClass.PRIEST:
						heroPowerCard = Cards.FromId("CS1h_001");
						break;
					case CardClass.ROGUE:
						heroPowerCard = Cards.FromId("CS2_083b");
						break;
					case CardClass.SHAMAN:
						heroPowerCard = Cards.FromId("CS2_049");
						break;
					case CardClass.WARRIOR:
						heroPowerCard = Cards.FromId("CS2_102");
						break;
				}
				HeroPower heroPower =
					(HeroPower) Entity.FromCard(in controller, heroPowerCard, creator: source);
				controller.SetasideZone.Add(controller.Hero.HeroPower);
				controller.Hero.HeroPower = heroPower;

				Card[] cards = Cards.FormatTypeClassCards(game.FormatType)[randClass].Where(p => p.Class == randClass && !p.IsQuest).ToArray();

				// replace cards in hand
				for (int i = 0; i < controller.HandZone.Count; i++)
				{
					Playable entity = controller.HandZone[i];
					if (entity.Card.Class != CardClass.WARLOCK) continue;
					controller.HandZone.Remove(entity);
					controller.SetasideZone.Add(entity);
					var tags = new EntityData();
					//if (game.History)
					//{
					//	tags.Add(GameTag.ZONE_POSITION, i + 1);
					//	tags.Add(GameTag.CREATOR, source.Id);
					//}

					Playable newEntity = Entity.FromCard(in controller, cards.Choose(rnd), controller.HandZone, -1, i, source);
					//newEntity.CreatorId = source.Id;
					newEntity.Cost = newEntity.Card.Cost - 1;
				}

				ReadOnlySpan<Playable> deck = controller.DeckZone.GetSpan();
				// replace cards in deck
				for (int i = deck.Length - 1; i >= 0; i--)
				{
					Playable entity = deck[i];
					if (entity.Card.Class != CardClass.WARLOCK) continue;

					Card randCard = cards.Choose(rnd);
					Playable newEntity = Entity.FromCard(in controller, in randCard, controller.DeckZone);
					newEntity.CreatorId = source.Id;

					//Enchantment.GetInstance(Controller, (Playable) Source, newEntity, EnchantmentCard);

					controller.DeckZone.Remove(entity);
					controller.SetasideZone.Add(entity);

					newEntity.Cost = newEntity.Card.Cost - 1;
				}

				game.OnRandomHappened(true);

				return TaskState.COMPLETE;
			}
		}

		public class GetRandomPastLegendary : SimpleTask
		{
			private static readonly CardSet[] WildSets = Cards.WildSets.Except(Cards.StandardSets).ToArray();

			private static readonly Card[] PastLegendaryMinions
				= Cards.All.Where(p => p.Rarity == Rarity.LEGENDARY &&
				                       p.Collectible &&
				                       WildSets.Contains(p.Set) &&
				                       p.Type == CardType.MINION
				                       ).ToArray();

			public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
				in TaskStack stack = null)
			{
				Card pick = PastLegendaryMinions.Choose(game.Random);
				Entity.FromCard(in controller, in pick, controller.HandZone);
				return TaskState.COMPLETE;
			}
		}

		public class BuildABeast : SimpleTask
		{
			public static IReadOnlyList<Card> FirstBeastsMemory;
			public static IReadOnlyList<Card> SecondBeastsMemory;

			public override TaskState Process(in Game game, in Controller controller, in Entity source,
				in Entity target, in TaskStack stack = null)
			{
				if (FirstBeastsMemory == null)
				{
					lock (locker)
					{
						// In Hearthstone, cards from K & C is not included in the card pool for Build-A-Beast
						// I am not sure whether Sabber should follow the rule or not ...
						IEnumerable<Card> all = controller.Game.FormatType == FormatType.FT_STANDARD ?
							Cards.Standard[CardClass.HUNTER].Where(c => c.IsRace(Race.BEAST) && c.Cost <= 5) :
							Cards.Wild[CardClass.HUNTER].Where(c => c.IsRace(Race.BEAST) && c.Cost <= 5);
						var firstBeasts = new List<Card>();
						var secondBeasts = new List<Card>();
						foreach (Card card in all)
						{
							if (card.Power != null)
							{
								if (card.Taunt) continue;
								firstBeasts.Add(card);
							}
							else
								secondBeasts.Add(card);
						}

						FirstBeastsMemory = firstBeasts.AsReadOnly();
						SecondBeastsMemory = secondBeasts.AsReadOnly();
					}
				}

				Card[] first = FirstBeastsMemory.ChooseNElements(3, game.Random);

				Generic.CreateChoiceCards.Invoke(controller, source, null, ChoiceType.GENERAL,
					ChoiceAction.BUILDABEAST, first, null);

				return TaskState.COMPLETE;
			}
		}
	}
}


