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
using SabberStoneCore.Model;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;

namespace SabberStoneCore.Actions
{
	public static partial class Generic
	{
		/// <summary>
		/// Create and add a new entity with a specified card.
		/// </summary>
		/// <param name="c"></param>
		/// <param name="card"></param>
		/// <returns></returns>
		public static Playable DrawCard(Controller c, Card card)
		{
			Playable playable = card.Type == CardType.MINION
				? MinionInPlay.FromCard(in c, in card)
				: Entity.FromCard(in c, in card);

			//c.NumCardsDrawnThisTurn++;
			AddHandPhase.Invoke(c, playable);
			return playable;
		}

		/// <summary>
		/// Get an entity from a controller's deck.
		/// </summary>
		/// <param name="c">The controller.</param>
		/// <param name="deckIndex">Index of the entity to draw in the deck.</param>
		/// <returns>The drawn entity.</returns>
		public static Playable Draw(Controller c, int deckIndex = -1)
		{
			// Don't consider fatigue when trying to draw a specific card
			if (deckIndex < 0 && !PreDrawPhase(c))
				return null;

			Playable playable = DrawPhase(c, deckIndex);

			if (AddHandPhase.Invoke(c, playable))
			{
				// DrawTrigger vs TOPDECK ?? not sure which one is first

				Game game = c.Game;

				if (deckIndex < 0)
				{
					game.TriggerManager.OnDrawTrigger(playable);
				}

				SimpleTask task = playable.Power?.TopdeckTask;
				if (task != null)
				{
					if (game.History)
					{
						// TODO: triggerkeyword: TOPDECK
						game.PowerHistory.Add(
							PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, playable.Id, "", 0, 0));
					}

					c.SetasideZone.Add(c.HandZone.Remove(playable));

					game.Log(LogLevel.INFO, BlockType.TRIGGER, "TOPDECK",
						!game.Logging ? "" : $"{playable}'s TOPDECK effect is activated.");

					task.Process(game, c, playable, null);

					if (game.History)
						game.PowerHistory.Add(
							PowerHistoryBuilder.BlockEnd());
				}
			}

			return playable;
		}

		/// <summary>
		/// Get an entity from a controller's deck.
		/// </summary>
		/// <param name="c">The controller.</param>
		/// <param name="playable">The entity to draw.</param>
		/// <returns>The drawn entity.</returns>
		public static Playable Draw(Controller c, Playable playable)
		{
			ReadOnlySpan<Playable> deck = c.DeckZone.GetSpan();
			for (int i = 0; i < deck.Length; i++)
				if (deck[i] == playable)
					return Draw(c, i);

			throw new ArgumentOutOfRangeException($"Can't Find {playable} in {c}'s deckzone.");
		}

		private static bool PreDrawPhase(Controller c)
		{
			if (c.DeckZone.IsEmpty)
			{
				int fatigueDamage = c.Hero.Fatigue + 1;
				c.Hero.Fatigue = fatigueDamage;
				DamageCharFunc(c.Hero, c.Hero, fatigueDamage, false);
				return false;
			}

			return true;
		}

		private static Playable DrawPhase(Controller c, int deckIndex)
		{
			Playable playable = c.DeckZone.Draw(deckIndex);

			c.Game.Log(LogLevel.INFO, BlockType.ACTION, "DrawPhase",
				!c.Game.Logging ? "" : $"{c.Name} draws {playable}");

			c.NumCardsDrawnThisTurn++;
			c.LastCardDrawn = playable.Id;

			return playable;
		}


#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}
}
