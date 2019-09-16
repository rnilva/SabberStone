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
		public static bool SummonBlock(Game g, ref Minion minion, int zonePosition)
		{
			SummonPhase(g, ref minion, zonePosition);

			g.TriggerManager.OnAfterSummonTrigger(minion);

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
