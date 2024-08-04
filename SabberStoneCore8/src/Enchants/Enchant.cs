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
using System.Text;
using SabberStoneCore.Auras;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks.SimpleTasks;
using SabberStoneCore.Triggers;

namespace SabberStoneCore.Enchants
{
	/// <summary>
	/// Class to store attributes of the <see cref="Power"/> of an Enchantment Card.
	/// </summary>
	public class Enchant
	{
		public static readonly Trigger RemoveWhenPlayedTrigger =
			new Trigger(TriggerType.PLAY_CARD, TriggerSource.ENCHANTMENT_TARGET)
			{
				SingleTask = RemoveEnchantmentTask.Task,
				RemoveAfterTriggered = true,
				IsAncillaryTrigger = true,
			};

		public readonly AbstractEffect[] Effects;
		public bool UseScriptTag;
		public bool IsOneTurnEffect;
		public bool RemoveWhenPlayed;

		public Enchant(GameTag tag, EffectOperator @operator, int value)
	    {
			AbstractEffect eff;
			BoolAttributes attr = AttributeHelpers.GameTagToBoolAttribute(tag);
			if (attr != BoolAttributes.Invalid)
				eff = SabberStoneCore.Enchants.Effects.SetAttributeEffect(attr);
			else
				eff = new GameTagEffect(tag, @operator, value);

			Effects = new[] {eff};
	    }

	    public Enchant(params AbstractEffect[] effects)
	    {
			Effects = effects;
	    }

		public static implicit operator Enchant(AbstractEffect effect) => new Enchant(effect);

		public static implicit operator Enchant(AbstractEffect[] effects) => new Enchant(effects);

		///// <summary>
		///// Create an Enchant that uses the Number value in the stack.
		///// </summary>
		//public Enchant(GameTag tag, EffectOperator @operator)
		//{
		//	Effects = new AbstractEffect[] {new Effect(tag, @operator, 0)};
		//	UseScriptTag = true;
		//}

		/// <summary>
		/// Apply this Enchant's <see cref="Effect"/>s to the given entity.
		/// </summary>
		/// <param name="entity">The target entity.</param>
		/// <param name="num1">Integer value for GameTag.TAG_SCRIPT_DATA_NUM_1.</param>
		/// <param name="num2">Integer value for GameTag.TAG_SCRIPT_DATA_NUM_2.</param>
		public virtual void ActivateTo(Entity entity, int? num1, int? num2)
		{
			AbstractEffect[] effects = Effects;
			if (!UseScriptTag)
				for (int i = 0; i < effects.Length; i++)
					//effects[i].ApplyTo(entity);
					entity.ApplyEffect(effects[i]);
			else
			{
				//effects[0].ChangeValue(num1).ApplyTo(entity);
				entity.ApplyEffect(effects[0].ChangeValue(num1.Value));

				if (effects.Length >= 2)
				{
					if (num2 >= 0)
						//effects[1].ChangeValue(num2).ApplyTo(entity);
						entity.ApplyEffect(effects[1].ChangeValue(num2.Value));
					else
						//effects[1].ChangeValue(num1).ApplyTo(entity);
						entity.ApplyEffect(effects[1].ChangeValue(num1.Value));

					for (int i = 2; i < effects.Length; i++)
						//effects[i].ApplyTo(entity);
						entity.ApplyEffect(effects[i]);
				}
			}

			if (IsOneTurnEffect)
			{
				for (int i = 0; i < effects.Length; i++)
				{
					entity.Game.OneTurnEffects.Add((entity.Id, effects[i]));
				}
			}

			if (entity.Game.History)
				for (int i = 0; i < effects.Length; i++)
					entity.Game.PowerHistory.Add(
						PowerHistoryBuilder.TagChange(entity.Id, effects[i].Tag, entity[effects[i].Tag]));
			
		}

		public void RemoveEffect(in Entity target)
		{
			for (int i = 0; i < Effects.Length; i++)
				target.RemoveEffect(Effects[i]);

            if (target.Game.History)
                for (int i = 0; i < Effects.Length; i++)
                    target.Game.PowerHistory.Add(
                        PowerHistoryBuilder.TagChange(
                            target.Id, Effects[i].Tag, target[Effects[i].Tag]));
		}

		public void RemoveEffect(in Entity target, int num1, int num2)
		{
			//Effects[0].ChangeValue(num1).RemoveFrom(target);
			target.RemoveEffect(Effects[0].ChangeValue(num1));
			if (Effects.Length == 1) return;
			if (num2 > 0)
				//Effects[1].ChangeValue(num2).RemoveFrom(target);
				target.RemoveEffect(Effects[1].ChangeValue(num2));
			else
				//Effects[1].ChangeValue(num1).RemoveFrom(target);
				target.RemoveEffect(Effects[1].ChangeValue(num1));

			for (int i = 2; i < Effects.Length; i++)
				target.RemoveEffect(Effects[i]);
			

			if (target.Game.History)
				for (int i = 0; i < Effects.Length; i++)
					target.Game.PowerHistory.Add(
						PowerHistoryBuilder.TagChange(
							target.Id, Effects[i].Tag, target[Effects[i].Tag]));
				
		}
    }

	/// <summary>
	/// Implementation of a kind of enchantment that its effect gradually grows due to a trigger.
	/// OngoingEnchant is narrowly used when the source of the trigger and 
	/// the target of the Enchantment is identical. (e.g. Mana Wyrm)
	/// </summary>
	public class OngoingEnchant : Enchant, IAura
	{
		public Game Game;
		private int _count = 1;
		private int _lastCount = 1;
		//private int _targetId;
		private bool _toBeUpdated;
		//private Entity _target;

		Playable IAura.Owner => Target;

		public OngoingEnchant(params AbstractEffect[] effects) : base(effects) { }

		public int Count
		{
			get => _count;
			set
			{
				_count = value;
				_toBeUpdated = true;
			}
		}
		//public Entity Target
		//{
		//	get => _target ?? (_target = Game.IdEntityDic[_targetId]);
		//	set
		//	{
		//		_targetId = value.Id;
		//		_target = value;
		//	}
		//}
		public Playable Target { get; set; }

		public override void ActivateTo(Entity entity, int? num1, int? num2)
		{
			Clone((Playable) entity);

			base.ActivateTo(entity, num1, num2);
		}

		public bool Update()
		{
			if (!_toBeUpdated) return true;

			int delta = _count - _lastCount;

			for (int i = 0 ; i < delta; i++)
				base.ActivateTo(Target, null, null);

			_lastCount = _count;

			_toBeUpdated = false;

			return true;
		}

		public void Remove()
		{
			Target.OngoingEffect = null;
			Target.Game.Auras.Remove(this);
		}

		public void Clone(Playable clone)
		{
			var copy = new OngoingEnchant(Effects)
			{
				Game = clone.Game,
				Target = clone,
				IsOneTurnEffect = IsOneTurnEffect,
			};
			clone.OngoingEffect = copy;
			copy.Game.Auras.Add(copy);
		}

		void IAura.Activate(Playable owner)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			var sb = new StringBuilder("[OE:");
			sb.Append(Target.Card.Name);
			sb.Append("]");
			sb.Append(_toBeUpdated ? "[U]" : "[NU]");
			return sb.ToString();
		}
	}
}
