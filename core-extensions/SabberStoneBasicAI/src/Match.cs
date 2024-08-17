using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using HearthDb.Deckstrings;

using SabberStoneCore.Config;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.PlayerTasks.Lite;

namespace SabberStoneBasicAI
{
	public static class Match
	{
		private static (CardClass, List<Card>) ToCards(this Deck deck)
		{
			CardClass heroClass = deck.GetHero().Class;
			List<Card> cards = deck.GetCards()
				.SelectMany(pair => Enumerable.Repeat(Cards.FromId(pair.Key.Id), pair.Value))
				.ToList();
			return (heroClass, cards);
		}


		public static int[] RunGames(IAgent agent1, IAgent agent2, Deck deck1, Deck deck2,
			int count, bool skipMulligan = true, long? seed = null)
		{
			int[] numWins = [0, 0];

			(CardClass, List<Card>) config1 = deck1.ToCards();
			(CardClass, List<Card>) config2 = deck2.ToCards();

			IAgent[] agents = [agent1, agent2];
			foreach (IAgent agent in agents)
				agent.OnMatchStarted();

			for (int i = 0; i < count; i++)
			{
				foreach (IAgent agent in agents)
					agent.OnGameStarted();

				GameConfig config = new()
				{
					StartPlayer = -1,
					Player1HeroClass = config1.Item1,
					Player1Deck = config1.Item2,
					Player2HeroClass = config2.Item1,
					Player2Deck = config2.Item2,

					Logging = false,
					History = false,
					FillDecks = false,
					Shuffle = true,
					SkipMulligan = skipMulligan,
					RandomSeed = seed ?? Guid.NewGuid().GetHashCode()
				};

				Game game = new(config);
				game.StartGame();


				// TODO: Mullligan

				// TODO: Timer

				// TODO: Turn

				while (game.State != State.COMPLETE)
				{
					Controller controller = game.CurrentPlayer;
					IAgent agent = agents[controller.PlayerId - 1];
					PlayerTaskLite action = agent.GetAction(game, controller);
					game.Process(in action);
				}

				foreach (IAgent agent in agents)
					agent.OnGameFinished();

				int winner = game.Player1.PlayState == PlayState.WON ? 0 :
					game.Player2.PlayState == PlayState.WON ? 1 : -1;
				if (winner >= 0)
					++numWins[winner];
			}

			return numWins;
		}
	}
}
