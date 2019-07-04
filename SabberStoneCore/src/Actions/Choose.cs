using System;
using System.Collections.Generic;
using System.Linq;
using SabberStoneCore.Model;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Tasks.SimpleTasks;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;

namespace SabberStoneCore.Actions
{
	public static partial class Generic
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public static Func<Controller, Game, int, bool> ChoicePick
			=> delegate (Controller c, Game g, int choice)
			{
				if (c.Choice.ChoiceType != ChoiceType.GENERAL)
				{
					g.Log(LogLevel.WARNING, BlockType.ACTION, "ChoicePick", !g.Logging? "":$"Choice failed, trying to pick in a non-pick choice!");
					return false;
				}

				if (!c.Choice.Choices.Contains(choice))
				{
					g.Log(LogLevel.WARNING, BlockType.ACTION, "ChoicePick", !g.Logging? "":$"Choice failed, trying to pick a card that doesn't exist in this choice!");
					return false;
				}

				IPlayable playable = g.IdEntityDic[choice];
				//IPlayable playable = ((PlayableSurrogate) g.IdEntityDic[choice]).CastToPlayable(in c);
				//playable[GameTag.CREATOR] = c.Choice.SourceId;
				//playable[GameTag.DISPLAYED_CREATOR] = c.Choice.SourceId;
				

				g.Log(LogLevel.INFO, BlockType.ACTION, "ChoicePick", !g.Logging? "":$"{c.Name} Picks {playable.Card.Name} as choice!");

				switch (c.Choice.ChoiceAction)
				{
					case ChoiceAction.HAND:
						if (RemoveFromZone(c, playable))
						{
							AddHandPhase.Invoke(c, playable);
						}
						//if (RemoveFromZone(c, playable))
						//{
						//	g.TaskQueue.Enqueue(new AddCardTo(playable, EntityType.HAND)
						//	{
						//		Game = g,
						//		Controller = c,
						//		Source = playable,
						//		Target = playable
						//	});
						//}
						break;

					case ChoiceAction.CAST:
						RemoveFromZone(c, playable);
						CastSpell.Invoke(c, (Spell)((PlayableSurrogate)playable).CastToPlayable(c), null, 0, true);
						break;

					case ChoiceAction.SPELL_RANDOM:
						if (RemoveFromZone(c, playable))
						{
							Spell spell = (Spell) ((PlayableSurrogate) playable).CastToPlayable(c);
							ICharacter randTarget = null;
							if (spell.Card.TargetingType != TargetingType.None)
							{
								List<ICharacter> targets = (List<ICharacter>)spell.ValidPlayTargets;

								randTarget = targets.Count > 0 ? Util.RandomElement(targets) : null;

								spell.CardTarget = randTarget?.Id ?? -1;

								g.Log(LogLevel.INFO, BlockType.POWER, "CastRandomSpell",
									!g.Logging ? "" : $"{spell}'s target is randomly selected to {randTarget}");
							}
							if (spell.Card.HasOverload)
								c.OverloadOwed = spell.Card.Overload;

							g.TaskQueue.StartEvent();
							CastSpell.Invoke(c, spell, randTarget, 0, true);
							g.TaskQueue.EndEvent();
						}
						break;

					case ChoiceAction.SUMMON:
						if (!c.BoardZone.IsFull && RemoveFromZone(c, playable))
						{
							SummonBlock.Invoke(g, (Minion)((PlayableSurrogate)playable).CastToPlayable(in c), -1);
						}
						//if (RemoveFromZone(c, playable))
						//{
						//	g.TaskStack.Playables.Add(playable);
						//	g.TaskQueue.Enqueue(new SummonTask()
						//	{
						//		Game = g,
						//		Controller = c,
						//		Source = playable,
						//		Target = playable
						//	});
						//}
						break;

					case ChoiceAction.ADAPT:
						playable = ((PlayableSurrogate) playable).CastToPlayable(in c);
						g.TaskQueue.StartEvent();
						foreach (IPlayable p in c.Choice.EntityStack.Select(id => g.IdEntityDic[id]))
							playable.ActivateTask(PowerActivation.POWER, (ICharacter)p);
						// Need to move the chosen adaptation to the Graveyard
						g.TaskQueue.Enqueue(new MoveToGraveYard(EntityType.SOURCE), in c, playable, playable);
						g.TaskQueue.EndEvent();
						if (g.History)
						{
							// Send metadata to the client to hide the card
							g.PowerHistory.Add(new PowerHistoryMetaData
							{
								Type = MetaDataType.SHOW_BIG_CARD,
								Data = 2,
								Info = new List<int> { choice }
							});
						}
						break;

					//case ChoiceAction.TRACKING:
					//	if (RemoveFromZone(c, playable))
					//	{
					//		g.TaskQueue.Enqueue(new AddCardTo(playable, EntityType.HAND)
					//		{
					//			Game = g,
					//			Controller = c,
					//			Source = playable,
					//			Target = playable
					//		});
					//	}
					//	break;

					case ChoiceAction.HEROPOWER:
						if (RemoveFromZone(c, playable))
						{
							playable[GameTag.CREATOR] = c.Hero.Id;
							g.Log(LogLevel.INFO, BlockType.PLAY, "ReplaceHeroPower",
								!g.Logging ? "" : $"{c.Hero} power replaced by {playable}");

							c.SetasideZone.Add(c.Hero.HeroPower);
							c.Hero.HeroPower = (HeroPower)((PlayableSurrogate)playable).CastToPlayable(in c);
						}
						break;

					case ChoiceAction.KAZAKUS:
						c.Choice.Choices.Where(p => p != choice).ToList().ForEach(p =>
						{
							g.IdEntityDic[p][GameTag.TAG_SCRIPT_DATA_NUM_1] = 0;
						});
						//c.Setaside.Add(playable);
						var kazakusPotions =
							c.SetasideZone.Where(p => p.Card.Id.StartsWith("CFM_621"))
								.Where(p => p[GameTag.TAG_SCRIPT_DATA_NUM_1] > 0)
								.Select(p => p[GameTag.TAG_SCRIPT_DATA_NUM_1])
								.ToList();
						if (kazakusPotions.Any())
						{
							g.TaskQueue.Enqueue(new PotionGenerating(kazakusPotions), in c, playable, playable);
						}
						break;

					case ChoiceAction.GLIMMERROOT:
						if (c.Opponent.DeckCards.Select(p => p.Id).Contains(playable.Card.Id))
						{
							if (RemoveFromZone(c, playable))
								AddHandPhase.Invoke(c, playable);
						}
						break;

					case ChoiceAction.BUILDABEAST:
						if (c.Choice.NextChoice == null)
						{
							Card firstCard = g.IdEntityDic[c.Choice.LastChoice].Card.Clone();
							Card secondCard = playable.Card;
							Card zombeastCard = Card.CreateZombeastCard(in firstCard, in secondCard, g.History);

							IPlayable zombeast = Entity.FromCard(in c, in zombeastCard);
							zombeast[GameTag.DISPLAYED_CREATOR] = c.Choice.SourceId;

							AddHandPhase.Invoke(c, zombeast);
							break;
						}
						else
							break;


					default:
						throw new NotImplementedException();
				}

				if (g.IdEntityDic[choice] is Playable pp)
					pp._data.Add(GameTag.DISPLAYED_CREATOR, c.Choice.SourceId);

				// aftertask here
				if (c.Choice.AfterChooseTask != null)
				{
					// choice creator as Source
					// selected card as Target
					c.Choice.AfterChooseTask.Process(in g, in c, g.IdEntityDic[c.Choice.SourceId], playable,
						new TaskStack()
						{
							Playables = c.Choice.EntityStack?.Select(id => g.IdEntityDic[id]).ToArray()
						});
				}

				// set displayed creator at least for discover
				//playable[GameTag.DISPLAYED_CREATOR] = c.LastCardPlayed;

				//	Start next Choice if any choice is queueing up
				c.Choice = c.Choice.TryPopNextChoice(choice, out Choice nextChoice) ? nextChoice : null;

				return true;
			};

		public static Func<Controller, List<int>, bool> ChoiceMulligan
			=> delegate (Controller c, List<int> choices)
			{
				if (c.Choice.ChoiceType != ChoiceType.MULLIGAN)
				{
					c.Game.Log(LogLevel.WARNING, BlockType.ACTION, "ChoiceMulligan", !c.Game.Logging? "":$"Choice failed, trying to mulligan in a non-mulligan choice!");
					return false;
				}

				if (!choices.TrueForAll(p => c.Choice.Choices.Contains(p)))
				{
					c.Game.Log(LogLevel.WARNING, BlockType.ACTION, "ChoiceMulligan", !c.Game.Logging? "":$"Choice failed, trying to mulligan a card that doesn't exist in this choice!");
					return false;
				}

				switch (c.Choice.ChoiceAction)
				{
					case ChoiceAction.HAND:
						c.MulliganState = Mulligan.DEALING;

						// starting mulligan draw block
						if (c.Game.History)
							c.Game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, c.Id, "", 6, 0));

						var mulliganList = c.HandZone.Where(p => !choices.Contains(p.Id) && !p.Card.Id.Equals("GAME_005")).ToList();
						mulliganList.ForEach(p =>
						{
							// drawing a new one
							//IPlayable playable = c.DeckZone.Remove(c.DeckZone.TopCard);
							IPlayable playable = c.DeckZone.Draw();

							if (AddHandPhase.Invoke(c, playable))
							{
								c.HandZone.Swap(p, playable);
							}

							// removing old one
							RemoveFromZone(c, p);
							ShuffleIntoDeck.Invoke(c, null, p);
						});

						if (c.Game.History)
							c.Game.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());

						// reset choice it's done
						c.Choice = null;

						break;

					default:
						throw new NotImplementedException();
				}



				return true;
			};

		public static Func<Controller, IEntity, ChoiceType, ChoiceAction, List<int>, bool> CreateChoice
			=> delegate (Controller c, IEntity source, ChoiceType type, ChoiceAction action, List<int> choices)
			{
				if (c.Choice != null)
				{
					c.Game.Log(LogLevel.WARNING, BlockType.ACTION, "CreateChoice", !c.Game.Logging? "":$"there is an unresolved choice, can't add a new one!");
					return false;
				}

				c.Choice = new Choice(c)
				{
					ChoiceType = type,
					ChoiceAction = action,
					Choices = choices,
					SourceId = source.Id
				};
				return true;
			};

		public static Func<Controller, IEntity, IList<IPlayable>, ChoiceType, ChoiceAction, Card[], ISimpleTask, bool> CreateChoiceCards
			=> delegate (Controller c, IEntity source, IList<IPlayable> targets, ChoiceType type, ChoiceAction action, Card[] choices, ISimpleTask taskToDo)
			{
				//if (c.Choice != null)
				//{
				//	c.Game.Log(LogLevel.WARNING, BlockType.ACTION, "CreateChoice", $"there is an unresolved choice, can't add a new one!");
				//	return false;
				//}

				var choicesIds = new List<int>();
				for (int i = 0; i < choices.Length; i++)
				{
					//IPlayable choiceEntity = Entity.FromCard(c, p,
					//	new EntityData
					//	{
					//		{GameTag.CREATOR, source.Id},
					//		{GameTag.DISPLAYED_CREATOR, source.Id }
					//	});
					var choiceEntity = new PlayableSurrogate(c.Game, in choices[i]);
					c.SetasideZone.Add(choiceEntity);
					choicesIds.Add(choiceEntity.Id);
				}

				var choice = new Choice(c)
				{
					ChoiceType = type,
					ChoiceAction = action,
					Choices = choicesIds,
					SourceId = source.Id,
					//TargetIds = targets != null ? targets.Select(p => p.Id).ToList() : new List<int>(),
					//EnchantmentCard = enchantmentCard,
					AfterChooseTask = taskToDo,

					EntityStack = targets?.Select(p => p.Id).ToList()
				};


				if (c.Choice != null)
				{
					//c.Choice.ChoiceQueue.Enqueue(choice);

					Choice next = c.Choice;
					while (next.NextChoice != null)
						next = next.NextChoice;

					next.NextChoice = choice;
				}
				else
					c.Choice = choice;

				return true;
			};
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
