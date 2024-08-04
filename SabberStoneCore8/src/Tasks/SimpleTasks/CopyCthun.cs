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
using System.Collections.Generic;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class CopyCthun : SimpleTask
	{
		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			if (!(source is Playable playableSource))
				return TaskState.STOP;

			if (controller.ProxyCthun == 0)
				return TaskState.STOP;

			var proxyCthun = (Minion) game.IdEntityDic[controller.ProxyCthun];
			var minionTarget = (Minion) target;

			if (game.History)
			{
				if (playableSource.AppliedEnchantments == null)
					playableSource.AppliedEnchantments = new List<Enchantment>(4);

				if (proxyCthun.AppliedEnchantments != null)
					foreach (Enchantment e in proxyCthun.AppliedEnchantments)
					{
						Enchantment instance =
							Enchantment.GetInstance(in game, in controller, minionTarget, minionTarget, e.Card);
						if (e.ScriptTag1 > 0)
						{
							instance.ScriptTag1 = e.ScriptTag1;
							if (e.ScriptTag2 > 0)
								instance.ScriptTag2 = e.ScriptTag2;
						}
					}
			}

			proxyCthun.OngoingEffect?.Clone(playableSource);

			minionTarget.AttackDamage = proxyCthun.AttackDamage;
			minionTarget.BaseHealth = proxyCthun.BaseHealth;
			minionTarget.HasTaunt = proxyCthun.HasTaunt;

			return TaskState.COMPLETE;
		}
	}
}
