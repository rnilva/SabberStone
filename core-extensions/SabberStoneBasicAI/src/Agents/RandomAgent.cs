using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.PlayerTasks;
using SabberStoneCore.Tasks.PlayerTasks.Lite;

namespace SabberStoneBasicAI.Agents
{
	public class RandomAgent(int seed) : IAgent
	{
		private readonly PlayerTaskLiteContainer _optionBuffer = [];

		public Random Rnd { get; set; } = new(seed);

		public string Name => "RandomAgent";
		public PlayerTaskLite GetAction(Game game, Controller controller)
		{
			controller.Options(_optionBuffer);
			return _optionBuffer.GetRandom(Rnd);
		}

		public ChooseTask Mulligan(Game game, Controller controller)
		{
			return Util.GetPowerSet(controller.Choice.Choices)
				.Select(p => ChooseTask.Mulligan(controller, p.ToList()))
				.ToArray()
				.Choose(Rnd);
		}

		public void OnMatchStarted() { }

		public void OnGameStarted() { }

		public void OnGameFinished() { }
	}
}
