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
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class RandomMinionTask : SimpleTask
	{
		private static readonly ConcurrentDictionary<int, FrozenSet<Card>> CachedCards = [];

		private readonly bool _opponent;

		public RandomMinionTask(GameTag tag, EntityType type, int amount = 1, bool opponent = false)
		{
			Tag = tag;
			Value = -1;
			Amount = amount;
			Type = type;
			ClassAndMultiOnlyFlag = false;
			MaxInDeckFlag = false;
			RelaSign = RelaSign.EQ;
			_opponent = opponent;
		}

		public RandomMinionTask(GameTag tag, int value, int amount = 1, RelaSign relaSign = RelaSign.EQ,
			bool classAndMultiOnlyFlag = false, bool maxInDeckFlag = false, bool opponent = false)
		{
			Tag = tag;
			Value = value;
			Amount = amount;
			Type = EntityType.INVALID;
			ClassAndMultiOnlyFlag = classAndMultiOnlyFlag;
			MaxInDeckFlag = maxInDeckFlag;
			RelaSign = relaSign;
			_opponent = opponent;
		}

		public GameTag Tag { get; set; }
		public int Value { get; set; }
		public EntityType Type { get; set; }
		public int Amount { get; set; }
		public bool ClassAndMultiOnlyFlag { get; set; }
		public bool MaxInDeckFlag { get; set; }
		public RelaSign RelaSign { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			FrozenSet<Card>? cardsList = null;
			if (Type != EntityType.INVALID)
			{
				if (Type == EntityType.TARGET && Tag == GameTag.COST)
				{
					Value = ((Playable) target).Cost;
					cardsList = Cards.CostMinionCards(game.FormatType)[Value];
				}
				else
				{
					throw new NotImplementedException();
				}
			}

			if (cardsList == null && Tag == GameTag.COST && RelaSign == RelaSign.EQ)
				cardsList = Cards.CostMinionCards(game.FormatType)[Value];

			if (cardsList == null && !CachedCards.TryGetValue(source.Card.AssetId, out cardsList))
			{
				FrozenSet<Card> cards = ClassAndMultiOnlyFlag
					? Cards.FormatTypeClassCards(game.FormatType)[controller.HeroClass]
					: Cards.FormatTypeCards(game.FormatType);


				if (Tag == GameTag.CARDRACE && RelaSign == RelaSign.EQ)
				{
					cardsList = cards.Where(p => p.Type == CardType.MINION
							 && p.IsRace((Race)Value)).ToFrozenSet();
				}
				else
				{
					cardsList = cards.Where(p => p.Type == CardType.MINION
												 && (RelaSign == RelaSign.EQ && p[Tag] == Value
													 || RelaSign == RelaSign.GEQ && p[Tag] >= Value
													 || RelaSign == RelaSign.LEQ && p[Tag] <= Value)).ToFrozenSet();
				}

				CachedCards.TryAdd(source.Card.AssetId, cardsList);
			}

			if (cardsList.Count == 0) return TaskState.STOP;

			var randomMinions = new List<Playable>(Amount);
			if (Amount > 1)
			{
				var list = new List<Card>(cardsList);
				while (randomMinions.Count < Amount && cardsList.Count > 0)
				{
					Card card = list.Choose(game.Random);
					list.Remove(card);

					// check for deck rules
					if (MaxInDeckFlag && controller.DeckCards.Count(p => p.Id == card.Id) >= card.MaxAllowedInDeck)
						continue;

					randomMinions.Add(Entity.FromCard(_opponent ? controller.Opponent : controller, card));
				}
			}
			else
			{
				randomMinions.Add(Entity.FromCard(_opponent ? controller.Opponent : controller,
					cardsList.Choose(game.Random)));
			}


			stack.Playables = randomMinions;

			game.OnRandomHappened(true);

			return TaskState.COMPLETE;
		}
	}
}
