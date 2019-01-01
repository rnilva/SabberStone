﻿using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.PlayerTasks;

namespace SabberStoneCore.Tasks
{
	public enum PlayerTaskType
	{
		CHOOSE, CONCEDE, END_TURN, HERO_ATTACK, HERO_POWER, MINION_ATTACK, PLAY_CARD
	}

	//[DebuggerTypeProxy(typeof(PlayerTaskDebuggerProxy))]
	public class PlayerTask
	{
		public TaskState State { get; set; } = TaskState.READY;
		public PlayerTaskType PlayerTaskType { get; set; }
		public Game Game { get; set; }

		public Controller Controller { get; set; }
		public IPlayable Source { get; set; }
		public ICharacter Target { get; set; }
		public int ChooseOne { get; set; }
		public bool SkipPrePhase { get; set; }

		//public List<Game> Splits { get; set; } = new List<Game>();
		//public IEnumerable<IEnumerable<IPlayable>> Sets { get; set; }

		public bool HasSource => Source != null;
		public bool HasTarget => Target != null;

		public virtual List<PlayerTask> Build(in Game game, in Controller controller, in IPlayable source, in ICharacter target)
		{
			Game = game;
			Controller = controller;
			Source = source;
			Target = target;
			return new List<PlayerTask> { this };
		}

		public virtual TaskState Process()
		{
			return TaskState.COMPLETE;
		}

		public ISimpleTask Clone()
		{
			throw new NotImplementedException();
		}

		public virtual string FullPrint()
		{
			return "PlayerTask";
		}

		public void ResetState()
		{
			State = TaskState.READY;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			switch (this)
			{
				case ChooseTask choose:
					sb.Append("[CHOOSE]");
					foreach (int choice in choose.Choices)
						sb.Append($" {Game.IdEntityDic[choice].Card.Name}");
					break;
				case ConcedeTask _:
					sb.Append("[CONCEDE]");
					break;
				case EndTurnTask _:
					sb.Append("[END_TURN]");
					break;
				case HeroAttackTask _:
					sb.Append($"[ATTACK] {Controller.Hero} => {Target}");
					break;
				case HeroPowerTask _:
					sb.Append($"[HEROPOWER]{Controller.Hero.HeroPower}");
					if (Target != null)
						sb.Append($" => {Target}");
					break;
				case MinionAttackTask minionAttack:
					sb.Append($"[ATTACK] {minionAttack.Source} => {minionAttack.Target}");
					break;
				case PlayCardTask playCard:
					sb.Append($"[PLAY_CARD] {playCard.Source}");
					if (playCard.Target != null)
						sb.Append($" => {playCard.Target}");
					if (playCard.Source.Card.Type == Enums.CardType.MINION)
						sb.Append($"(Pos {playCard.ZonePosition})");
					if (playCard.ChooseOne > 0)
						sb.Append($"(Opt {playCard.ChooseOne}");
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			sb.Append($"[P{Controller.PlayerId}]");

			return sb.ToString();
		}

		//private class PlayerTaskDebuggerProxy
		//{
		//	private readonly PlayerTask _task;

		//	public PlayerTaskDebuggerProxy(PlayerTask task)
		//	{
		//		_task = task;
		//	}


		//}
	}
}
