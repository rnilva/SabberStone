using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabberStoneCore.Conditions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.PlayerTasks;
using SabberStoneCore.Tasks.PlayerTasks.Lite;

namespace SabberStoneBasicAI
{
	public interface IAgent
	{
		/// <summary>
		/// The name of this agent.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Calculate and return the best move with regard to the given game state.
		/// </summary>
		/// <param name="game">The game context.</param>
		/// <param name="controller">The current player entity.</param>
		/// <returns>The action.</returns>
		PlayerTaskLite GetAction(Game game, Controller controller);

		/// <summary>
		/// The mulligan strategy of this agent.
		/// </summary>
		/// <param name="game"></param>
		/// <param name="controller"></param>
		/// <returns></returns>
		ChooseTask Mulligan(Game game, Controller controller);

		/// <summary>
		/// This method will be called when a match is started.
		/// </summary>
		void OnMatchStarted();

		/// <summary>
		/// This method will be called when each game (round) is started.
		/// </summary>
		void OnGameStarted();

		/// <summary>
		/// This method will be called when each game (round) is finished.
		/// </summary>
		void OnGameFinished();
	}
}
