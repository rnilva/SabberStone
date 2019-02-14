using System;
using System.Linq;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;
using System.Collections.Generic;
using SabberStoneCore.Exceptions;


namespace SabberStoneCore.Model.Zones
{
	public class DeckZone : LimitedZone<IPlayable>
	{
		public const int StartingCards = 30;
		public const int DeckMaximumCapcity = 60;

		// TODO: Barnabus the Stomper
		public bool NoEvenCostCards { get; private set; } = true;
		public bool NoOddCostCards { get; private set; } = true;

		public DeckZone(Controller controller)
		{
			Game = controller.Game;
			Controller = controller;
		}

		private DeckZone(Controller c, DeckZone zone) : base(c, zone)
		{
			NoEvenCostCards = zone.NoEvenCostCards;
			NoOddCostCards = zone.NoOddCostCards;
		}

		public override bool IsFull => _count == DeckMaximumCapcity;

		public override int MaxSize => DeckMaximumCapcity;

		public override Zone Type => Zone.DECK;

		public override void Add(IPlayable entity, int zonePosition = -1)
		{
			base.Add(entity, zonePosition);

			entity.Power?.Trigger?.Activate(Game, entity, TriggerActivation.DECK);

			if (NoEvenCostCards || NoOddCostCards)
			{
				if (entity.Cost % 2 == 0)
				{
					NoEvenCostCards = false;
				}
				else if (NoOddCostCards)
				{
					NoOddCostCards = false;
				}
			}
		}

		public IPlayable TopCard => _entities[_count - 1];

		public void Fill(IReadOnlyCollection<string> excludeIds = null)
		{
			IReadOnlyList<Card> cards = Game.FormatType == FormatType.FT_STANDARD ? Controller.Standard : Controller.Wild;
			int cardsToAdd = StartingCards - _count;

			Game.Log(LogLevel.INFO, BlockType.PLAY, "Deck", !Game.Logging ? "" : $"Deck[{Game.FormatType}] from {Controller.Name} filling up with {cardsToAdd} random cards.");
			Controller.DeckCards = new List<Card>(30);
			while (cardsToAdd > 0)
			{
				Card card = Util.Choose(cards);

				// don't add cards that have to be excluded here.
				if (excludeIds != null && excludeIds.Contains(card.Id))
					continue;

				// don't add cards that have already reached max occurence in deck.
				if (this.Count(c => c.Card == card) >= card.MaxAllowedInDeck)
					continue;

				Controller.DeckCards.Add(card);

				IPlayable entity = Entity.FromCard(Controller, card);
				Add(entity, 0);

				cardsToAdd--;
			}
		}

		public void Shuffle()
		{
			int n = _count;

			Random rnd = Util.Random;

			Game.Log(LogLevel.INFO, BlockType.PLAY, "Deck", !Game.Logging ? "" : $"{Controller.Name} shuffles its deck.");

			var entities = _entities;
			for (int i = 0; i < n; i++)
			{
				int r = rnd.Next(i, n);
				IPlayable temp = entities[i];
				entities[i] = entities[r];
				entities[r] = temp;
			}
		}

		public DeckZone Clone(Controller c)
		{
			return new DeckZone(c, this);
		}

		internal void SetEntity(int index, IPlayable newEntity)
		{
			_entities[index] = newEntity;
			newEntity.Zone = this;
		}
	}

	public class DeckZone_new : LimitedZone<PlayableSurrogate>
	{
		public const int StartingCards = 30;
		public const int DeckMaximumCapcity = 60;

		public bool NoEvenCostCards { get; private set; } = true;
		public bool NoOddCostCards { get; private set; } = true;
		public IPlayable TopCard => _entities[_count - 1];

		public DeckZone_new(Controller controller)
		{
			Game = controller.Game;
			Controller = controller;
		}

		private DeckZone_new(Controller c, DeckZone_new zone) : base(c, zone)
		{
			NoEvenCostCards = zone.NoEvenCostCards;
			NoOddCostCards = zone.NoOddCostCards;
		}

		public void Add(IPlayable playable, int zonePosition = -1)
		{
			if (playable is Playable p)
				Add(entity: p, zonePosition);
			else if
				(playable is PlayableSurrogate ps)
				Add(entity: ps, zonePosition);
		}

		public IPlayable Remove(IPlayable playable)
		{
			return Remove(entity: (PlayableSurrogate) playable).CastToPlayable(Controller);
		}

		private PlayableSurrogate Remove(int id)
		{
			var entities = _entities;
			var c = _count;
			for (int i = _count - 1; i >= 0; i--)
				if (entities[i].Id == id)
				{
					//IPlayable p = entities[i].CastToPlayable(Controller);
					PlayableSurrogate ps = entities[i];
					ps.ActivatedTrigger?.Remove();
					ps.Zone = null;

					if (i != --_count)
						Array.Copy(entities, i + 1, entities, i, _count - i);

					return ps;
				}

			return null;
		}

		public IPlayable Draw(int cardIdToDraw = -1)
		{
			PlayableSurrogate draw;
			if (cardIdToDraw > 0)
			{
				draw = Remove(cardIdToDraw);
				if (draw == null)
					return null;
			}
			else
				draw = Remove(entity: _entities[_count - 1]);
			return draw.CastToPlayable(Controller);
		}

		public IPlayable Draw(Predicate<Card> predicate)
		{
			var entities = _entities;
			var c = _count;
			for (int i = _count - 1; i >= 0; i--)
				if (predicate(entities[i].Card))
				{
					IPlayable p = entities[i].CastToPlayable(Controller);
					entities[i].ActivatedTrigger?.Remove();

					if (i != _count - 1)
						Array.Copy(entities, i + 1, entities, i, _count - i - 1);

					return p;
				}

			return null;
		}

		public PlayableSurrogate Pop()
		{
			return Remove(entity: _entities[_count - 1]);
		}


		public void Setup(in Game game, in List<Card> cards)
		{
			for (int i = 0; i < cards.Count; i++)
			{
				var ps = new PlayableSurrogate(in game, cards[i]);
				Add(entity: ps);
			}
		}

		public void Shuffle()
		{
			int n = _count;

			Random rnd = Util.Random;

			Game.Log(LogLevel.INFO, BlockType.PLAY, "Deck", !Game.Logging ? "" : $"{Controller.Name} shuffles its deck.");

			var entities = _entities;
			for (int i = 0; i < n; i++)
			{
				int r = rnd.Next(i, n);
				var temp = entities[i];
				entities[i] = entities[r];
				entities[r] = temp;
			}
		}

		public void Fill(IReadOnlyCollection<string> excludeIds = null)
		{
			IReadOnlyList<Card> cards = Game.FormatType == FormatType.FT_STANDARD ? Controller.Standard : Controller.Wild;
			int cardsToAdd = StartingCards - _count;

			Game.Log(LogLevel.INFO, BlockType.PLAY, "Deck", !Game.Logging ? "" : $"Deck[{Game.FormatType}] from {Controller.Name} filling up with {cardsToAdd} random cards.");
			Controller.DeckCards = new List<Card>(30);
			while (cardsToAdd > 0)
			{
				Card card = Util.Choose(cards);

				// don't add cards that have to be excluded here.
				if (excludeIds != null && excludeIds.Contains(card.Id))
					continue;

				// don't add cards that have already reached max occurence in deck.
				if (this.Count(c => c.Card == card) >= card.MaxAllowedInDeck)
					continue;

				Controller.DeckCards.Add(card);

				//IPlayable entity = Entity.FromCard(Controller, card);
				//Add(new PlayableSurrogate(Game, card));
				var ps = new PlayableSurrogate(Game, in card);
				Add(ps, 0);
				cardsToAdd--;
			}
		}

		public DeckZone_new Clone(Controller c)
		{
			return new DeckZone_new(c, this);
		}

		internal void SetEntity(int index, IPlayable newEntity)
		{
			_entities[index] = PlayableSurrogate.CastFromPlayable(newEntity);
			newEntity.Zone = this;
		}

		#region Overrides of Zone<PlayableSurrogate>

		public override bool IsFull => _count == DeckMaximumCapcity;

		public override Zone Type => Zone.DECK;

		public override void Add(PlayableSurrogate entity, int zonePosition = -1)
		{
			if (zonePosition > _count)
				throw new ZoneException($"Zoneposition '{zonePosition}' isn't in a valid range.");

			MoveTo(entity, zonePosition);

			Game.Log(LogLevel.DEBUG, BlockType.PLAY, "Zone", !Game.Logging ? "" : $"Entity '{entity} ({entity.Card.Type})' has been added to zone '{Type}'.");

			entity.Power?.Trigger?.Activate(Game, entity, TriggerActivation.DECK);

			if (NoEvenCostCards || NoOddCostCards)
			{
				if (entity.Cost % 2 == 0)
				{
					NoEvenCostCards = false;
				}
				else if (NoOddCostCards)
				{
					NoOddCostCards = false;
				}
			}
		}

		public override PlayableSurrogate Remove(PlayableSurrogate entity)
		{
			return Remove(entity.Id);
		}
		#endregion

		#region Overrides of LimitedZone<PlayableSurrogate>

		public override int MaxSize => DeckMaximumCapcity;

		#endregion
	}
}
