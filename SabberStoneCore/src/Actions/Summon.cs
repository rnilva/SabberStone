#region copyright
// SabberStone, Hearthstone Simulator in C# .NET Core
// Copyright (C) 2017-2019 SabberStone Team, darkfriend77 & rnilva
//
// SabberStone is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License.
// SabberStone is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
#endregion
using System;
using SabberStoneCore.Model;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Actions
{
	public static partial class Generic
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public static bool SummonBlock(Game g, ref Minion minion, int zonePosition, Entity summoner)
		{
			SummonPhase(g, ref minion, zonePosition);

			summoner!!
			g.TriggerManager.OnAfterSummonTrigger(minion);

            if (minion.IsRace(Race.TOTEM))
                minion.Controller.NumTotemSummonedThisGame++;

			return true;
		}

		public static bool SummonBlock(Game g, ref Playable playable, int zonePosition)
		{
			var m = (Minion) playable;
			bool flag = SummonBlock(g, ref m, zonePosition);
			playable = m;
			return flag;
		}

		public static bool SummonBlock(Game g, Minion minion, int zonePosition)
		{
			return SummonBlock(g, ref minion, zonePosition);
		}
		private static void SummonPhase(Game g, ref Minion minion, int zonePosition)
		{
			g.Log(LogLevel.INFO, BlockType.PLAY, "SummonPhase", !g.Logging? "":$"Summon Minion {minion} to Board of {minion.Controller.Name}.");
			minion.Controller.BoardZone.Add(ref minion, zonePosition);

			g.AuraUpdate();

			g.SummonedMinions.Add((MinionInPlay) minion);

			// add summon block show entity 
			if (g.History)
				g.PowerHistory.Add(PowerHistoryBuilder.ShowEntity(minion));
		}
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
