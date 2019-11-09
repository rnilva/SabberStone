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
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class SetGameTagTask : SimpleTask
	{
		private readonly IEffect _effect;
		private readonly EntityType _type;

		public SetGameTagTask(GameTag tag, int amount, EntityType entityType)
		{
			switch (tag)
			{
				case GameTag.ATK:
					_effect = ATK.Effect(EffectOperator.SET, amount);
					break;
				case GameTag.HEALTH:
					_effect = Health.Effect(EffectOperator.SET, amount);
					break;
				case GameTag.STEALTH:
					_effect = Stealth.Effect(amount > 0);
					break;
				case GameTag.TAUNT:
					_effect = Taunt.Effect(amount > 0);
					break;
				case GameTag.CANT_BE_TARGETED_BY_SPELLS:
				case GameTag.CANT_BE_TARGETED_BY_HERO_POWERS:
					_effect = CantBeTargetedBySpells.Effect(amount > 0);
					break;
				default:
					Attributes attr = AttributeHelpers.GameTagToAttribute(tag);
					if (attr == Attributes.Invalid)
						_effect = new Effect(tag, EffectOperator.SET, amount);
					else
						_effect = new AttributeEffect(attr, amount == 1);
					break;
			}
			_type = entityType;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source,
			in Entity target, in TaskStack stack = null)
		{
			IEffect effect = _effect;

			IList<Playable> entities =
				IncludeTask.GetEntities(in _type, in controller, source, target, stack?.Playables);
			if (effect.Tag == GameTag.EXHAUSTED)
			{
				bool value = effect.Value > 0;
				for (int i = 0; i < entities.Count; i++)
					entities[i].IsExhausted = value;
				return TaskState.COMPLETE;
			}

			for (int i = 0; i < entities.Count; i++)
			{
				if (effect.Tag == GameTag.DIVINE_SHIELD && effect.Value == 0 &&
				    entities[i][GameTag.DIVINE_SHIELD] != 0)
					game.TriggerManager.OnLoseDivineShield(entities[i]);
				else if
				(effect.Tag == GameTag.FROZEN && effect.Value == 1 &&
				 entities[i][GameTag.FROZEN] == 0)
					game.TriggerManager.OnFreezeTrigger(entities[i]);

				effect.ApplyTo(entities[i]);
			}

		public ApplyEffectTask(EntityType entityType, params IEffect[] effects)
		{
			_type = entityType;
			_effs = effects;
		}
	}

	public class ApplyEffectTask : SimpleTask
	{
		private readonly EntityType _type;
		private readonly IEffect[] _effs;

		public ApplyEffectTask(EntityType entityType, params IEffect[] effects)
		{
			_type = entityType;
			_effs = effects;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source,
			in Entity target, in TaskStack stack = null)
		{
			IEffect[] effects = _effs;
			IList<Playable> entities = IncludeTask.GetEntities(in _type, in controller, source, target, stack?.Playables);

			for (int i = 0; i < entities.Count; i++)
			for (int j = 0; j < effects.Length; j++)
				effects[j].ApplyTo(entities[i]);

			return TaskState.COMPLETE;
		}
	}
}
