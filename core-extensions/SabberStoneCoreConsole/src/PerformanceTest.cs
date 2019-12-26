using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SabberStoneCore.Config;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Tasks.PlayerTasks;

namespace SabberStoneCoreConsole
{
	public static class PerformanceTest
	{
		public static void MageExpertTest(int count = 20000, int round = 5)
		{
			var watch = new Stopwatch();
			var deck = new[]
			{
				"Arcane Missiles",
				"Arcane Missiles",
				"Arcane Explosion",
				"Arcane Explosion",
				"Mana Wyrm",
				"Mana Wyrm",
				"Sorcerer's Apprentice",
				"Sorcerer's Apprentice",
				"Counterspell",
				"Counterspell",
				"Kirin Tor Mage",
				"Kirin Tor Mage",
				"Mirror Entity",
				"Mirror Entity",
				"Vaporize",
				"Vaporize",
				"Fireball",
				"Fireball",
				"Polymorph",
				"Polymorph",
				"Water Elemental",
				"Water Elemental",
				"Kobold Geomancer",
				"Kobold Geomancer",
				"Mana Addict",
				"Mana Addict",
				"Azure Drake",
				"Azure Drake",
				"Frost Elemental",
				"Frost Elemental",
			};
			var game = new Game(new GameConfig
			{
				Player1HeroClass = CardClass.MAGE,
				Player2HeroClass = CardClass.MAGE,
				Player1Deck = deck.Select(Cards.FromName).ToList(),
				Player2Deck = deck.Select(Cards.FromName).ToList(),
				Shuffle = true,
				Logging = false,
				History = false
			});

			var rnd = new Random();

			Console.WriteLine("Warming up......");
			for (int i = 0; i < count; ++i)
			{
				Game g = game.Clone();
				g.StartGame();
				do
				{
					List<PlayerTask> options = g.CurrentPlayer.Options();
					g.Process(options[rnd.Next(options.Count)]);

				} while (g.State != State.COMPLETE);
			}

			var roundRecords = new double[round];

			for (int r = 0; r < round; ++r)
			{
				var record = new long[count];

				for (int i = 0; i < count; ++i)
				{
					watch.Start();
					Game g = game.Clone();
					g.StartGame();
					do
					{
						List<PlayerTask> options = g.CurrentPlayer.Options();
						g.Process(options[rnd.Next(options.Count)]);

					} while (g.State != State.COMPLETE);
					watch.Stop();

					record[i] = watch.ElapsedMilliseconds;
				}

				double sum = record.Sum();
				double average = record.Average();
				Console.WriteLine($"Round {r}");
				Console.WriteLine($"Total duration for {count} games: {sum} ms");
				Console.WriteLine($"Average duration for {count} games: {average} ms");
				Console.WriteLine();
				roundRecords[r] = average;
				watch.Reset();
			}

			Console.WriteLine($"Average duration per round: {roundRecords.Average()} ms");
		}
	}
}
