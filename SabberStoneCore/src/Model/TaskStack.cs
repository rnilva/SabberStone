using System;
using SabberStoneCore.Model.Entities;
using System.Collections.Generic;

namespace SabberStoneCore.Model
{
	public class TaskStack
	{
		public Game Game { get; set; }

		public Controller Controller { get; set; }
		public IEntity Source { get; set; }
		public IEntity Target { get; set; }

		public List<IPlayable> Playables { get; set; } = new List<IPlayable>();
		//public List<string> CardIds { get; set; }
		public bool Flag { get; set; }
		public int[] Numbers { get; set; } = new[] { 0, 0, 0, 0, 0 };

		public TaskStack(Game game)
		{
			Game = game;
		}

		public TaskStack(Game game, Controller controller, IEntity source, IEntity target, int number = 0)
		{
			Game = game;
			Controller = controller;
			Source = source;
			Target = target;
			Numbers[0] = number;
		}

		public int Number
		{
			get => Numbers[0];
			set => Numbers[0] = value;
		}

		public int Number1
		{
			get => Numbers[1];
			set => Numbers[1] = value;
		}

		//public void SetDamageMetaData(IPlayable source, IPlayable target)
		//{
		//	_damageSource = source;
		//	_damageTarget = target;
		//}

		//public void ResetDamageMetaData()
		//{
		//	_damageSource = null;
		//	_damageTarget = null;
		//}

		public void Renew(Controller controller, IEntity src, IEntity tgt)
		{
			Controller = controller;
			Source = src;
			Target = tgt;
		}

		public void Reset()
		{
			Playables = new List<IPlayable>();
			Flag = false;
			Numbers = new[] { 0, 0, 0, 0, 0 };
		}

		public void Stamp(TaskStack taskStack)
		{
			//Playables = taskStack.Playables?.Select(p => Game.IdEntityDic[p.Id]).ToList();
			Playables = new List<IPlayable>();
			//CardIds = new List<string>();
			Flag = taskStack.Flag;
			Numbers = new int[5];
			Array.Copy(taskStack.Numbers, Numbers, 5);

			if (taskStack.Controller != null)
				Controller = Game.ControllerById(taskStack.Controller.Id);
			if (taskStack.Source != null)
				Source = Game.IdEntityDic[taskStack.Source.Id];
			if (taskStack.Target != null)
				Target = Game.IdEntityDic[taskStack.Target.Id];
		}
	}
}
