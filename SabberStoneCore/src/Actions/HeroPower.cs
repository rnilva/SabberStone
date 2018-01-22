﻿using System;
using SabberStoneCore.Model;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;

namespace SabberStoneCore.Actions
{
	public partial class Generic
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public static bool HeroPower(Controller c, ICharacter target = null)
		{
			return HeroPowerBlock.Invoke(c, target);
		}

		public static Func<Controller, ICharacter, bool> HeroPowerBlock
			=> delegate (Controller c, ICharacter target)
			{
				if (!c.Hero.HeroPower.IsPlayable || !c.Hero.HeroPower.IsValidPlayTarget(target))
				{
					return false;
				}

				PayPhase.Invoke(c, c.Hero.HeroPower);

				// play block
				if (c.Game.History)
					c.Game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.PLAY, c.Hero.HeroPower.Id, "", 0, target?.Id ?? 0));

				c.Game.Log(LogLevel.INFO, BlockType.ACTION, "HeroPowerBlock", !c.Game.Logging? "":$"Play HeroPower {c.Hero.HeroPower}[{c.Hero.HeroPower.Card.Id}]{(target != null ? $" targeting {target}" : "")}.");

				c.Hero.HeroPower.ActivateTask(PowerActivation.POWER, target);

				c.Hero.HeroPower.IsExhausted = true;
				c.HeroPowerActivationsThisTurn++;
				c.NumTimesHeroPowerUsedThisGame++;

				if (c.Game.History)
					c.Game.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());

				return true;
			};
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
