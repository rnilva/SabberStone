using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;

namespace SabberStoneCore.Model.Entities
{
	public enum Attributes
	{
		Invalid = - 1,
		// # Integer attributes
		// ## Minion-only attributes
		SpellPower = 0,
		// ## Hero-only attributes
		HeroPowerDamage = 3,

		// # Boolean attributes
		// ## Common attributes
		// ### Effect-only attributes
		Immune = 0,
		Frozen,
		ToBeDestroyed,
		// ### Card attributes
		Stealth = 3,
		Elusive,
		// ## Minion-only attributes
		Taunt,
		DivineShield,
		Windfury,
		Charge,
		Poisonous,
		Lifesteal,
		Rush,
		CantAttack,
		Deathrattle,
		CannotAttackHeroes = 16,
		// ## Hero-only attributes
	}

	public static class AttributeHelpers
	{
		public static Attributes GameTagToAttribute(GameTag tag)
		{
			switch (tag)
			{
				case GameTag.IMMUNE:
					return Attributes.Immune;
				case GameTag.FROZEN:
					return Attributes.Frozen;
				case GameTag.TO_BE_DESTROYED:
					return Attributes.ToBeDestroyed;
				case GameTag.DIVINE_SHIELD:
					return Attributes.DivineShield;
				case GameTag.WINDFURY:
					return Attributes.Windfury;
				case GameTag.CHARGE:
					return Attributes.Charge;
				case GameTag.POISONOUS:
					return Attributes.Poisonous;
				case GameTag.LIFESTEAL:
					return Attributes.Lifesteal;
				case GameTag.RUSH:
					return Attributes.Rush;
				case GameTag.CANT_ATTACK:
					return Attributes.CantAttack;
				case GameTag.CANNOT_ATTACK_HEROES:
					return Attributes.CannotAttackHeroes;
				case GameTag.DEATHRATTLE:
					return Attributes.Deathrattle;
				default:
					return Attributes.Invalid;
			}
		}
	}

	public readonly struct AttributeEffect : IEffect
	{
		private readonly Attributes _attr;
		private readonly bool _value;
		private readonly Action<Character> _afterApplyTask;

		public AttributeEffect(Attributes attr, bool value)
		{
			_attr = attr;
			_value = value;
			switch (attr)
			{
				case Attributes.DivineShield:
					Tag = GameTag.DIVINE_SHIELD;
					_afterApplyTask = null;
					break;
				case Attributes.Frozen:
					Tag = GameTag.FROZEN;
					_afterApplyTask = null;
					break;
				case Attributes.Charge:
					Tag = default;
					_afterApplyTask = c =>
					{
						var m = (MinionInPlay) c;
						if (m.IsExhausted && m.NumAttacksThisTurn == 0)
							m.IsExhausted = false;
						if (m.AttackableByRush)
							m.AttackableByRush = false;
					};
					break;
				case Attributes.Windfury:
					Tag = default;
					_afterApplyTask = c =>
					{
						if (c.NumAttacksThisTurn == 1 && c.IsExhausted)
							c.IsExhausted = false;
					};
					break;
				case Attributes.Rush:
					Tag = default;
					_afterApplyTask = c =>
					{
						var m = (MinionInPlay) c;
						if (m.IsExhausted && m.NumAttacksThisTurn == 0)
						{
							m.IsExhausted = false;
							m.AttackableByRush = true;
							m.Game.RushMinions.Add(m.Id);
						}
					};
					break;
				default:
					Tag = default;
					_afterApplyTask = null;
					break;
			}
		}

		#region Implementation of IEffect

		public GameTag Tag { get; }

		public EffectOperator Operator
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public int Value
		{
			get => _value ? 1 : 0;
			set => throw new NotImplementedException();
		}

		public void ApplyTo(Entity entity, bool isOneTurnEffect = false)
		{
			var c = (Character) entity;
			c.SetAttribute(_attr, _value);
			_afterApplyTask?.Invoke(c);
		}

		public void ApplyAuraTo(Playable playable)
		{
			AuraEffects auraEffects;
			if (playable.AuraEffects != null)
				auraEffects = playable.AuraEffects;
			else
			{
				auraEffects = new AuraEffects(playable.Card.Type);
				playable.AuraEffects = auraEffects;
			}

			switch (_attr)
			{
				case Attributes.Rush:
					auraEffects.Rush = true;
					break;
				case Attributes.Lifesteal:
					auraEffects.Lifesteal = true;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public void RemoveFrom(Entity entity)
		{
			var c = (Character) entity;
			c.SetAttribute(_attr, !_value);
		}

		public void RemoveAuraFrom(Playable playable)
		{
			switch (_attr)
			{
				case Attributes.Rush:
					playable.AuraEffects.Rush = false;
					break;
				case Attributes.Lifesteal:
					playable.AuraEffects.Lifesteal = false;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
