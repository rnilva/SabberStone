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
		public static Func<Game, Minion, int, bool> SummonBlock
			=> delegate (Game g, Minion minion, int zonePosition)
			{
				SummonPhase.Invoke(g, minion, zonePosition);

				g.TriggerManager.OnAfterSummonTrigger(minion);

				return true;
			};

		private static Action<Game, Minion, int> SummonPhase
			=> delegate (Game g, Minion minion, int zonePosition)
			{
				g.Log(LogLevel.INFO, BlockType.PLAY, "SummonPhase", !g.Logging? "":$"Summon Minion {minion} to Board of {minion.Controller.Name}.");
				minion.Controller.BoardZone.Add(minion, zonePosition);

				g.AuraUpdate();

				g.SummonedMinions.Add(minion);

				// add summon block show entity 
				if (g.History)
					g.PowerHistory.Add(PowerHistoryBuilder.ShowEntity(minion));
			};
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
