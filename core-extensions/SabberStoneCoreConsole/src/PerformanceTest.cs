using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SabberStoneCore.Config;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Tasks.PlayerTasks;
using SabberStoneCore.Tasks.PlayerTasks.Lite;

namespace SabberStoneCoreConsole
{
	public static class PerformanceTest
	{
		public static void MageExpertTest(int count = 20000, int round = 5)
		{
			const bool LineByLineMode = false;

			if (LineByLineMode)
			{
				count = 5000;
				round = 1;
			}

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
			//var deck = new[]
			//{
			//	"Elven Archer",
			//	"Elven Archer",
			//	"Whirlwind",
			//	"Whirlwind",
			//	"Amani Berserker",
			//	"Amani Berserker",
			//	"Battle Rage",
			//	"Battle Rage",
			//	"Bloodsail Raider",
			//	"Bloodsail Raider",
			//	"Cruel Taskmaster",
			//	"Cruel Taskmaster",
			//	"Execute",
			//	"Execute",
			//	"Acolyte of Pain",
			//	"Acolyte of Pain",
			//	"Fiery War Axe",
			//	"Fiery War Axe",
			//	"Frothing Berserker",
			//	"Frothing Berserker",
			//	"Raging Worgen",
			//	"Raging Worgen",
			//	"Tauren Warrior",
			//	"Tauren Warrior",
			//	"Arathi Weaponsmith",
			//	"Arathi Weaponsmith",
			//	"Kor'kron Elite",
			//	"Brawl",
			//	"Spiteful Smith",
			//	"Spiteful Smith",
			//};
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

			List<PlayerTask> optionBuffer = new List<PlayerTask>(64);
			var buffer = new PlayerTaskLiteContainer();

			if (!LineByLineMode)
			{
				Console.WriteLine("Warming up......");
				for (int i = 0; i < count * 2; ++i)
				{
					Game g = game.Clone();
					g.StartGame();
					do
					{
						//List<PlayerTask> options = g.CurrentPlayer.Options();
						//g.CurrentPlayer.Options(optionBuffer);
						g.CurrentPlayer.Options(buffer);
						//if (options.Count != buffer.Count)
						//	;
						//g.Process(options[rnd.Next(options.Count)]);
						ref readonly PlayerTaskLite option = ref buffer.GetRandom(rnd);
						g.Process(in option);

					} while (g.State != State.COMPLETE);
				}
			}



			Console.WriteLine("Press any key to start.");
			Console.ReadKey();

			var watch = new Stopwatch();
			var optionsWatch = new Stopwatch();
			long totalSum = 0;
			long optionsSum = 0;

			for (int r = 0; r < round; ++r)
			{
				//var options = new List<PlayerTask>(64);
				long sum = 0;

				watch.Start();
				for (int i = 0; i < count; ++i)
				{
					Game g = game.Clone();
					g.StartGame();
					do
					{
						//optionsWatch.Start();
						//List<PlayerTask> options = g.CurrentPlayer.Options();
						//PlayerTask option = options[rnd.Next(options.Count)];
						//optionsWatch.Stop();
						//g.Process(option);

						optionsWatch.Start();
						g.CurrentPlayer.Options(buffer);
						ref readonly PlayerTaskLite option = ref buffer.GetRandom(rnd);
						optionsWatch.Stop();
						g.Process(in option);

						//watch.Start();
						//g = g.Clone();
						//watch.Stop();

					} while (g.State != State.COMPLETE);

					//record[i] = watch.ElapsedMilliseconds;
				}
				watch.Stop();

				sum = watch.ElapsedMilliseconds;

				Console.WriteLine($"Round {r}");
				Console.WriteLine($"Total duration for {count} games: {sum} ms");
				Console.WriteLine($"Total duration for generating options: {optionsWatch.ElapsedMilliseconds} ms");
				Console.WriteLine();
				totalSum += sum;
				optionsSum += optionsWatch.ElapsedMilliseconds;
				watch.Reset();
				optionsWatch.Reset();
			}

			Console.WriteLine($"Average duration per round: {(double) totalSum / round} ms");
			Console.WriteLine($"Average duration for generating options per round: {(double) optionsSum / round} ms");
		}
	}
}
