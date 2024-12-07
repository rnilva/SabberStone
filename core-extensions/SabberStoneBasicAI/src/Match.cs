using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using SabberStoneCore.Config;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.PlayerTasks.Lite;

using ClassDeckPair = System.ValueTuple<SabberStoneCore.Enums.CardClass, System.Collections.Generic.List<SabberStoneCore.Model.Card>>;

namespace SabberStoneBasicAI
{
	public static class Match
	{
		public record Config(
			bool SkipMulligan = true,
			int? Seed = null,
			FormatType FormatType = FormatType.FT_CLASSIC,
			string LogDir = null,
			string ErrorDir = null,
			string OutDir = null,
			bool ThrowException = false
		);


		public record GameResult(
			int Winner,
			TimeSpan Duration,
			string Agent1,
			string Agent2,
			string Deck1,
			string Deck2,
			long Seed,
			Exception Error = null	
		);


		public record MatchResult(
			int TotalGames,
			int Agent1Wins,
			int Agent2Wins,
			int Errors,
			TimeSpan AverageDuration
		);


		public static GameResult RunSingleGame(
			IAgent agent1,
			IAgent agent2,
			in ClassDeckPair deck1,
			in ClassDeckPair deck2,
			in Config config,
			bool testRun = false)
		{
			IAgent[] agents = [agent1, agent2];

			long seed = config.Seed.GetValueOrDefault(Guid.NewGuid().GetHashCode());

			// Set up the game configuration.
			GameConfig gameConfig = new();
			(gameConfig.Player1HeroClass, gameConfig.Player1Deck) = deck1;
			(gameConfig.Player2HeroClass, gameConfig.Player2Deck) = deck2;
			gameConfig.SkipMulligan = config.SkipMulligan;
			gameConfig.FormatType = config.FormatType;
			gameConfig.History = false;
			gameConfig.RandomSeed = seed;

			if (!String.IsNullOrEmpty(config.LogDir))
			{
				gameConfig.Logging = true;
				if (!Directory.Exists(config.LogDir))
					Directory.CreateDirectory(config.LogDir);
			}

			long startTime = Stopwatch.GetTimestamp();
			Game game;
			try
			{
				// Initialise the game
				game = new(gameConfig);
				game.StartGame();
				
				foreach (IAgent agent in agents)
					agent.OnGameStarted();

				if (testRun)
				{
					Random rnd = new((int)seed);
					Thread.Sleep(TimeSpan.FromSeconds(rnd.NextDouble() * 5));
					game.ControllerByPlayerId(rnd.Next(1, 3)).PlayState = PlayState.WON;
				}
				else
				{
					// Mulligan
					if (!config.SkipMulligan)
					{
						for (int pid = 1; pid <= 2; pid++)
							game.Process(agents[pid - 1].Mulligan(game, game.ControllerByPlayerId(pid)));

						game.MainBegin(proceed: true);
					}

					// Main loop
					while (game.State != State.COMPLETE)
					{
						Controller controller = game.CurrentPlayer;
						IAgent agent = agents[controller.PlayerId - 1];
						PlayerTaskLite action = agent.GetAction(game, controller);
						game.Process(in action);
					}
				}

				foreach (IAgent agent in agents)
					agent.OnGameFinished();
			}
			catch (Exception exception)
			{
				if (config.ThrowException)
					throw;

				foreach (IAgent agent in agents)
					agent.OnGameFinished();

				return new(
					0,
					Stopwatch.GetElapsedTime(startTime),
					agent1.Name,
					agent2.Name,
					deck1.ToDeck(config.FormatType).DeckString(),
					deck2.ToDeck(config.FormatType).DeckString(),
					seed,
					exception
				);
			}

			TimeSpan duration = Stopwatch.GetElapsedTime(startTime);
			int winner = game.Player1.PlayState == PlayState.WON ? 1 : game.Player2.PlayState == PlayState.WON ? 2 : 0;

			GameResult result = new(
				winner,
				duration,
				agent1.Name,
				agent2.Name,
				deck1.ToDeck(game.FormatType).DeckString(),
				deck2.ToDeck(game.FormatType).DeckString(),
				seed
			);

			if (!String.IsNullOrEmpty(config.LogDir))
			{
				string filePath = Path.Join(config.LogDir, $"{seed}.txt");
				using StreamWriter writer = File.CreateText(filePath);
				foreach (LogEntry item in game.Logs.Where(l => l.Level <= LogLevel.INFO))
					writer.WriteLine(item.ToString());
			}

			return result;
		}


		public static GameResult RunSingleGame(
			IAgent agent1,
			IAgent agent2,
			Deck deck1,
			Deck deck2,
			in Config config,
			bool testRun = false) => RunSingleGame(agent1, agent2, deck1.ToClassAndCards(), deck2.ToClassAndCards(), in config, testRun);


		public static GameResult[] RunMatch(IAgent agent1, IAgent agent2, Deck deck1, Deck deck2,
			int count, in Config config)
		{
			ClassDeckPair pairDeck1 = deck1.ToClassAndCards();
			ClassDeckPair pairDeck2 = deck2.ToClassAndCards();

			agent1.OnMatchStarted();
			agent2.OnMatchStarted();

			var results = new GameResult[count];
			for (int i = 0; i < count; ++i)
				results[i] = RunSingleGame(agent1, agent2, pairDeck1, pairDeck2, in config);

			agent1.OnMatchFinished();
			agent2.OnMatchFinished();

			return results;
		}


		public static (Dictionary<(string, string), MatchResult>, MatchResult) RunParallelGames(
			Func<IAgent> agentFactory1, Func<IAgent> agentFactory2,
			IEnumerable<Deck> decks1, IEnumerable<Deck> decks2,
			int countPerPair, Config config, int maxParallelism = -1, bool testRun = false)
		{
			(Deck d1, Deck d2)[] pairs = decks1
				.SelectMany(d1 => decks2
					.SelectMany(d2 =>
						Enumerable.Repeat((d1, d2), countPerPair)))
				.ToArray();

			ConcurrentBag<GameResult> results = [];

			Random seedGenerator = new(config.Seed.GetValueOrDefault(Guid.NewGuid().GetHashCode()));
			int[] seeds = Enumerable.Range(0, pairs.Length).Select(_ => seedGenerator.Next()).ToArray();

			ParallelOptions pOptions = new()
			{
				MaxDegreeOfParallelism = maxParallelism
			};
			Parallel.For(0, pairs.Length, pOptions, (i) =>
			{
				(Deck deck1, Deck deck2) = pairs[i];
				GameResult r = RunSingleGame(agentFactory1(), agentFactory2(), deck1, deck2,
						config with {
							Seed = seeds[i],
							//LogDir = $""
						}, testRun);
				results.Add(r);
			});

			var deckStats = results
				.GroupBy(r => (r.Deck1, r.Deck2))
				.ToDictionary(
					g => g.Key,
					g => new MatchResult(
						TotalGames: g.Count(),
						Agent1Wins: g.Count(r => r.Winner == 1),
						Agent2Wins: g.Count(r => r.Winner == 2),
						Errors: g.Count(r => r.Error != null),
						AverageDuration: TimeSpan.FromTicks((long)g.Average(r => r.Duration.Ticks))
					)
				);

			var totalStats = new MatchResult(
				TotalGames: results.Count(),
				Agent1Wins: results.Count(r => r.Winner == 1),
				Agent2Wins: results.Count(r => r.Winner == 2),
				Errors: results.Count(r => r.Error != null),
				AverageDuration: TimeSpan.FromTicks((long)results.Average(r => r.Duration.Ticks))
			);

			return (deckStats, totalStats);
		}


		public static Deck ToDeck(this (CardClass, List<Card>) pair, FormatType formatType)
			=> Deck.FromClassAndCards(pair.Item1, pair.Item2, formatType);


		public static string DeckString(this Deck deck, bool includeComments = false)
			=> DeckSerializer.Serialize(deck, includeComments);
	}
}
