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
using System.Collections.Generic;
using SabberStoneCore.Actions;
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class TransformCopyTask : SimpleTask
	{
		private readonly bool _addToStack;

		public TransformCopyTask(bool addToStack = false)
		{
			_addToStack = addToStack;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source,
			in Entity target,
			in TaskStack stack = null)
		{
			var minionTarget = (MinionInPlay) target;
			if (minionTarget == null)
				return TaskState.STOP;

			var minionSource = (MinionInPlay) source;
			if (minionSource.Zone?.Type != Zone.PLAY)
				return TaskState.STOP;

			{	// Copy Tags from target to source.
				if (minionTarget._data != null)
				{
					EntityData sourceTags = minionSource._data ?? new EntityData();
					sourceTags.CopyFrom(in minionTarget._data);
					if (game.History)
					{
						sourceTags[GameTag.ENTITY_ID] = minionSource.Id;
						sourceTags[GameTag.CONTROLLER] = minionSource.Controller.PlayerId;
						sourceTags[GameTag.ZONE_POSITION] = minionSource.ZonePosition + 1;
					}
				}
			}


			minionSource = (MinionInPlay) Generic.ChangeEntityBlock(controller, minionSource, minionTarget.Card, true);

			minionSource.CopyAttributesFrom(minionTarget);

			{
				int id = minionTarget.Id;
				foreach (AdjacentAura adjAura in controller.BoardZone.AdjacentAuras)
				foreach (MinionInPlay minion in adjAura.AppliedEntities)
					if (minion.Id == id)
					{
						// De-apply effects from adjacent auras affecting the target
						adjAura.DeApply(minionSource, true);
						break;
					}
			}

			IAura aura = minionTarget.OngoingEffect;

			// Copy Enchantments
			if (minionTarget.AppliedEnchantments != null)
				foreach (Enchantment e in minionTarget.AppliedEnchantments)
				{
					Enchantment instance = Enchantment.GetInstance(in game, in controller, minionSource, minionSource, e.Card);
					if (e.ScriptTag1 > 0)
					{
						instance.ScriptTag1 = e.ScriptTag1;
						if (e.ScriptTag2 > 0)
							instance.ScriptTag2 = e.ScriptTag2;
					}
					if (e.IsOneTurnActive)
						game.OneTurnEffectEnchantments.Add(instance);
				}

			// Register the copied entity to auras; this will prevent duplication.
			foreach (Aura boardAura in controller.BoardZone.Auras)
				boardAura.Register(minionSource);

			if (aura != null && minionSource.OngoingEffect == null)
				aura.Clone(minionSource);

			if (minionTarget.HasCharge)
				minionSource.IsExhausted = false;
			else if (minionTarget.IsRush)
			{
				minionSource.AttackableByRush = true;
				game.RushMinions.Add(minionSource.Id);
			}

			if (_addToStack)
				stack.Playables = new Playable[]{minionSource};

			return TaskState.COMPLETE;
		}
	}
}
