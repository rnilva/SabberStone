using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
			bool SkipMulligan,
			int? Seed,
			string LogDir,
			FormatType FormatType
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

				Game game = new(gameConfig);
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

			Parallel.For(0, count, (i) =>
			{
				int[] r = RunGames(agentFactory1(), agentFactory2(), deck1, deck2, 1, config);
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
