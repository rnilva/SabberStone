using System;
using SabberStoneCore.Model;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;

namespace SabberStoneCore.Actions
{
	public static partial class Generic
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public static IPlayable DrawCard(Controller c, Card card)
		{
			return DrawCardBlock.Invoke(c, card);
		}

		public static IPlayable Draw(Controller c, int cardIdToDraw = -1)
		{
			return DrawBlock.Invoke(c, cardIdToDraw);
		}

		public static Func<Controller, Card, IPlayable> DrawCardBlock
			=> delegate (Controller c, Card card)
			{
				IPlayable playable = Entity.FromCard(c, card);
				//c.NumCardsDrawnThisTurn++;
				AddHandPhase.Invoke(c, playable);
				return playable;
			};

		public static Func<Controller, int, IPlayable> DrawBlock
			=> delegate (Controller c, int cardIdToDraw)
			{
				if (!PreDrawPhase.Invoke(c))
					return null;

				IPlayable playable = DrawPhase.Invoke(c, cardIdToDraw);
				//c.NumCardsToDraw--; 

				if (AddHandPhase.Invoke(c, playable))
				{
					// DrawTrigger vs TOPDECK ?? not sure which one is first

					if (playable != null)
					{
						c.Game.TriggerManager.OnDrawTrigger(playable);
					}

					ISimpleTask task = playable.Power?.TopdeckTask;
					if (task != null)
					{
						if (c.Game.History)
						{
							// TODO: triggerkeyword: TOPDECK
							c.Game.PowerHistory.Add(
								PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, playable.Id, "", 0, 0));
						}

						c.SetasideZone.Add(c.HandZone.Remove(playable));

						c.Game.Log(LogLevel.INFO, BlockType.TRIGGER, "TOPDECK",
							!c.Game.Logging ? "" : $"{playable}'s TOPDECK effect is activated.");

						task.Process(c.Game, c, playable, null);

						if (c.Game.History)
							c.Game.PowerHistory.Add(
								PowerHistoryBuilder.BlockEnd());
					}
				}

				return playable;
			};

		private static Func<Controller, bool> PreDrawPhase
			=> delegate (Controller c)
			{
				if (c.DeckZone.IsEmpty)
				{
					int fatigueDamage = c.Hero.Fatigue == 0 ? 1 : c.Hero.Fatigue + 1;
					DamageCharFunc(c.Hero, c.Hero, fatigueDamage, false);
					return false;
				}
				return true;
			};

		private static Func<Controller, int, IPlayable> DrawPhase
			=> delegate (Controller c, int cardIdToDraw)
			{
				//IPlayable playable = c.DeckZone.Remove(cardToDraw ?? c.DeckZone.TopCard);
				IPlayable playable = c.DeckZone.Draw(cardIdToDraw);

				c.Game.Log(LogLevel.INFO, BlockType.ACTION, "DrawPhase", !c.Game.Logging ? "" : $"{c.Name} draws {playable}");

				c.NumCardsDrawnThisTurn++;
				c.LastCardDrawn = playable.Id;

				return playable;
			};
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
