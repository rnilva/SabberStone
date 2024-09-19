using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SabberStoneCore.Config;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.PlayerTasks.Lite;

namespace SabberStoneBasicAI
{
	public static class Match
	{
		public readonly record struct Config(
			bool SkipMulligan = true,
			int? Seed = null,
			FormatType FormatType = FormatType.FT_CLASSIC,
			string LogDir = null,
			string ErrorDir = null,
			string OutDir = null
		);

		public static int[] RunGames(IAgent agent1, IAgent agent2, Deck deck1, Deck deck2,
			int count, in Config config)
		{
			return RunGames(agent1, agent2, deck1.ToClassAndCards(), deck2.ToClassAndCards(), count, in config);
		}

		public static int[] RunGames(IAgent agent1, IAgent agent2, in (CardClass, List<Card>) deck1,
			in (CardClass, List<Card>) deck2, int count, in Config config)
		{
			Random seedGenerator = new(config.Seed ?? Guid.NewGuid().GetHashCode());

			// Set up the game configuration.
			GameConfig gameConfig = new();
			(gameConfig.Player1HeroClass, gameConfig.Player1Deck) = deck1;
			(gameConfig.Player2HeroClass, gameConfig.Player2Deck) = deck2;
			gameConfig.SkipMulligan = config.SkipMulligan;
			gameConfig.FormatType = config.FormatType;

			if (!String.IsNullOrEmpty(config.LogDir))
			{
				gameConfig.Logging = true;
				if (!Directory.Exists(config.LogDir))
					Directory.CreateDirectory(config.LogDir);
			}

			if (!String.IsNullOrEmpty(config.ErrorDir))
			{
				if (!Directory.Exists(config.ErrorDir))
					Directory.CreateDirectory(config.ErrorDir);
			}

			string outDir = null;
			if (!String.IsNullOrEmpty(config.OutDir))
			{
				outDir = Path.Join(config.OutDir, $"{DateTime.Now.ToString("yyMMdd-HHmmss-ffffff")}");

				if (!Directory.Exists(outDir))
					Directory.CreateDirectory(outDir);	
				else
					Directory.CreateDirectory(outDir + "(2)");			
			}

			
			// using StreamWriter outWriter = File.CreateText(outFile);

			// Initialise agents.
			IAgent[] agents = [agent1, agent2];
			foreach (IAgent agent in agents)
				agent.OnMatchStarted();

			int[] numWins = [0, 0];
			for (int i = 0; i < count; i++)
			{
				gameConfig.RandomSeed = seedGenerator.Next();

				foreach (IAgent agent in agents)
					agent.OnGameStarted();

				Game game;
				try
				{
					game = new(gameConfig);
					game.StartGame();

					if (!config.SkipMulligan)
					{
						for (int pid = 1; pid <= 2; pid++)
							game.Process(agents[pid - 1].Mulligan(game, game.ControllerByPlayerId(pid)));

						game.MainBegin(proceed: true);
					}

					// TODO: Timer

					// TODO: Turn

					while (game.State != State.COMPLETE)
					{
						Controller controller = game.CurrentPlayer;
						IAgent agent = agents[controller.PlayerId - 1];
						PlayerTaskLite action = agent.GetAction(game, controller);
						game.Process(in action);
					}
				}
				catch (Exception e)
				{
					string errorDir = config.ErrorDir;
					if (String.IsNullOrEmpty(errorDir))
					{
						const string defaultErrorDir = "./_sabberstone_match_errors";
						errorDir = defaultErrorDir;
					}

					if (!Path.Exists(errorDir))
						Directory.CreateDirectory(errorDir);


					string now = DateTime.Now.ToString("yyMMdd-HHmmss");
					string fileName = $"error_{now}_{config.Seed}.txt";
					using StreamWriter writer = File.CreateText(Path.Combine(errorDir, fileName));

					string deckstring1 = DeckSerializer.Serialize(
						Deck.FromClassAndCards(deck1.Item1, deck1.Item2, config.FormatType), false);
					string deckstring2 = DeckSerializer.Serialize(
						Deck.FromClassAndCards(deck2.Item1, deck2.Item2, config.FormatType), false);

					writer.WriteLine("Exception has raised during the run.");
					writer.WriteLine("Deck1: " + deckstring2);
					writer.WriteLine("Deck2: " + deckstring2);
					writer.WriteLine(new string('-', 50));
					writer.WriteLine(e.ToString());

					continue;
				}

				foreach (IAgent agent in agents)
					agent.OnGameFinished();

				int winner = game.Player1.PlayState == PlayState.WON ? 0 :
					game.Player2.PlayState == PlayState.WON ? 1 : -1;
				if (winner >= 0)
					++numWins[winner];

				if (!String.IsNullOrEmpty(config.LogDir))
				{
					string filePath = Path.Join(config.LogDir, $"{i + 1}.txt");
					using StreamWriter writer = File.CreateText(filePath);
					foreach (LogEntry item in game.Logs.Where(l => l.Level <= LogLevel.INFO))
						writer.WriteLine(item.ToString());
				}

				if (outDir is not null)
				{
					string outFile = Path.Combine(outDir, $"{i + 1}.txt");
					using StreamWriter writer = File.CreateText(outFile);
					writer.WriteLine($"Deck1:");
					writer.WriteLine(DeckSerializer.Serialize(Deck.FromClassAndCards(deck1.Item1, deck1.Item2, config.FormatType), true));
					writer.WriteLine($"Deck2:");
					writer.WriteLine(DeckSerializer.Serialize(Deck.FromClassAndCards(deck2.Item1, deck2.Item2, config.FormatType), true));
					writer.WriteLine($"Winner: {winner}");
				}
			}

			if (outDir is not null)
			{
				string outFile = Path.Combine(outDir, $"summary.txt");
				using StreamWriter writer = File.CreateText(outFile);
				writer.WriteLine($"Deck1:");
				writer.WriteLine(DeckSerializer.Serialize(Deck.FromClassAndCards(deck1.Item1, deck1.Item2, config.FormatType), true));
				writer.WriteLine($"Deck2:");
				writer.WriteLine(DeckSerializer.Serialize(Deck.FromClassAndCards(deck2.Item1, deck2.Item2, config.FormatType), true));
				writer.WriteLine($"Wins: {numWins[0]}:{numWins[1]}");
			}

			return numWins;
		}

		public static int[] RunParallelGames<TA1, TA2>(
			Func<TA1> agentFactory1, Func<TA2> agentFactory2,
			Deck deck1, Deck deck2,
			int count, Config config)
			where TA1 : IAgent
			where TA2 : IAgent
		{
			int[][] results = new int[count][];

			Random seedGenerator = new(config.Seed.GetValueOrDefault(Guid.NewGuid().GetHashCode()));
			int[] seeds = Enumerable.Range(0, count).Select(_ => seedGenerator.Next()).ToArray();

			Parallel.For(0, count, (i) =>
			{
				int[] r = RunGames(agentFactory1(), agentFactory2(), deck1, deck2,
					1, config with { Seed = seeds[i] });
				results[i] = r;
			});

			int[] total = [0, 0];

			foreach (int[] r in results)
			{
				total[0] += r[0];
				total[1] += r[1];
			}

			return total;
		}

		public static int[] RunParallelGames(
			Func<IAgent> agentFactory1, Func<IAgent> agentFactory2,
			IEnumerable<Deck> decks1, IEnumerable<Deck> decks2,
			int countPerPair, Config config, int maxParallelism = -1)
		{
			var pairs = decks1.SelectMany(d => decks2.Select(d2 => (d, d2))).ToArray();
			int[][] results = new int[pairs.Length][];

			Random seedGenerator = new(config.Seed.GetValueOrDefault(Guid.NewGuid().GetHashCode()));
			int[] seeds = Enumerable.Range(0, pairs.Length).Select(_ => seedGenerator.Next()).ToArray();


			ParallelOptions pOptions = new()
			{
				MaxDegreeOfParallelism = maxParallelism
			};
			Parallel.For(0, pairs.Length, pOptions, (i) =>
			{
				(Deck deck1, Deck deck2) = pairs[i];
				int[] r = RunGames(agentFactory1(), agentFactory2(), deck1, deck2,
					countPerPair, config with {
						Seed = seeds[i],
						LogDir = $""
					});
				results[i] = r;
			});

			int[] total = [0, 0];

			foreach (int[] r in results)
			{
				total[0] += r[0];
				total[1] += r[1];
			}

			return total;
		}
	}
}
