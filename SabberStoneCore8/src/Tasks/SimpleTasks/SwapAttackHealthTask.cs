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
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class SwapAttackHealthTask : SimpleTask
	{
		private readonly Card _enchantmentCard;

		/// <summary>
		///     Changes the attack attribute of the given entity.
		/// </summary>
		public SwapAttackHealthTask(EntityType entityType, string enchantmentId)
		{
			Type = entityType;
			_enchantmentCard = Cards.FromId(enchantmentId);
		}

		public EntityType Type { get; set; }

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IEnumerable<Playable> entities =
				IncludeTask.GetEntities(Type, in controller, source, target, stack?.Playables);
			foreach (Playable p in entities)
			{
				if (!(p is Minion m))
					return TaskState.STOP;

				int atk = m.AttackDamage;
				int health = m.Health;

				if (game.History)
				{
					Enchantment instance =
						Enchantment.GetInstance(in game, controller, (Playable) source, p, in _enchantmentCard);
					instance.ScriptTag1 = atk;
					instance.ScriptTag2 = health;
				}

				m.ApplyEffect(Effects.SetAttack(health));
				m.ApplyEffect(Effects.SetMaxHealth(atk));

				foreach (Aura aura in controller.BoardZone.Auras)
				{
					if (aura.Deregister(p))
						aura.EntityAdded(p);
				}
			}

			return TaskState.COMPLETE;
		}
	}
}
