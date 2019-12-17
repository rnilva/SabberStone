using System;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;

namespace SabberStoneCore.Model.Entities
{
	/// <summary>
	/// Internal mappings to indices.
	/// </summary>
	public enum BoolAttributes
	{
		Invalid = - 1,

		// # Boolean attributes
		// ## Character attributes
		// ### Effect-only attributes
		Immune = 0,
		Frozen,
		// ### Card attributes
		Stealth,
		Elusive,
		CannotAttackHeroes,
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
		// ## Hero-only attributes
	}

	public enum IntAttributes
	{
		Invalid = -1,

		// # Character attributes
		SpellPower = 0,
		Damage = 1,
		NumAttacksThisTurn = 2,
		// ## Hero attributes
		HeroPowerDamage = 5
	}

	public static class AttributeHelpers
	{
		public static BoolAttributes GameTagToBoolAttribute(GameTag tag)
		{
			switch (tag)
			{
				case GameTag.IMMUNE:
					return BoolAttributes.Immune;
				case GameTag.FROZEN:
					return BoolAttributes.Frozen;
				case GameTag.DIVINE_SHIELD:
					return BoolAttributes.DivineShield;
				case GameTag.WINDFURY:
					return BoolAttributes.Windfury;
				case GameTag.CHARGE:
					return BoolAttributes.Charge;
				case GameTag.POISONOUS:
					return BoolAttributes.Poisonous;
				case GameTag.LIFESTEAL:
					return BoolAttributes.Lifesteal;
				case GameTag.RUSH:
					return BoolAttributes.Rush;
				case GameTag.CANT_ATTACK:
					return BoolAttributes.CantAttack;
				case GameTag.CANNOT_ATTACK_HEROES:
					return BoolAttributes.CannotAttackHeroes;
				case GameTag.DEATHRATTLE:
					return BoolAttributes.Deathrattle;
				default:
					return BoolAttributes.Invalid;
			}
		}

		public static IntAttributes GameTagToIntAttribute(GameTag tag)
		{
			switch (tag)
			{
				case GameTag.SPELLPOWER:
					return IntAttributes.SpellPower;
				case GameTag.DAMAGE:
					return IntAttributes.Damage;
				case GameTag.NUM_ATTACKS_THIS_TURN:
					return IntAttributes.NumAttacksThisTurn;
				case GameTag.HEROPOWER_DAMAGE:
					return IntAttributes.HeroPowerDamage;
				default:
					return IntAttributes.Invalid;
			}
		}

		public static ControllerIntAttributes GameTagToControllerIntAttribute(GameTag tag)
		{
			switch (tag)
			{
				case GameTag.SPELLPOWER_DOUBLE:
				case GameTag.SPELL_HEALING_DOUBLE:
					return ControllerIntAttributes.SpellPowerDouble;
				case GameTag.HERO_POWER_DOUBLE:
					return ControllerIntAttributes.HeroPowerDouble;
				case GameTag.ALL_HEALING_DOUBLE:
					return ControllerIntAttributes.AllHealingDouble;
				case GameTag.TIMEOUT:
					return ControllerIntAttributes.TimeOut;
				default:
					return ControllerIntAttributes.Invalid;
			}
		}

		public static ControllerBoolAttributes GameTagToControllerBoolAttribute(GameTag tag)
		{
			switch (tag)
			{
				case GameTag.HEALING_DOES_DAMAGE:
					return ControllerBoolAttributes.RestoreToDamage;
				case GameTag.EXTRA_BATTLECRIES_BASE:
					return ControllerBoolAttributes.ExtraBattlecry;
				case GameTag.EXTRA_DEATHRATTLES_BASE:
					return ControllerBoolAttributes.ExtraDeathrattle;
				case GameTag.CHOOSE_BOTH:
					return ControllerBoolAttributes.ChooseBoth;
				case GameTag.SPELLS_COST_HEALTH:
					return ControllerBoolAttributes.SpellsCostHealth;
				case GameTag.EXTRA_END_TURN_EFFECT:
					return ControllerBoolAttributes.ExtraEndTurnEffect;
				case GameTag.HERO_POWER_DISABLED:
					return ControllerBoolAttributes.HeroPowerDisabled;
				case GameTag.EXTRA_MINION_BATTLECRIES_BASE:
					return ControllerBoolAttributes.ExtraBattleCryAndCombo;
				default:
					return ControllerBoolAttributes.Invalid;
			}
		}
	}

	public readonly struct AttributeEffect : IEffect
	{
		private readonly BoolAttributes _attr;
		private readonly bool _value;
		private readonly Action<Character> _afterApplyTask;

		public AttributeEffect(BoolAttributes attr, bool value)
		{
			_attr = attr;
			_value = value;
			switch (attr)
			{
				case BoolAttributes.DivineShield:
					Tag = GameTag.DIVINE_SHIELD;
					_afterApplyTask = null;
					break;
				case BoolAttributes.Frozen:
					Tag = GameTag.FROZEN;
					_afterApplyTask = null;
					break;
				case BoolAttributes.Charge:
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
				case BoolAttributes.Windfury:
					Tag = default;
					_afterApplyTask = c =>
					{
						if (c.NumAttacksThisTurn == 1 && c.IsExhausted)
							c.IsExhausted = false;
					};
					break;
				case BoolAttributes.Rush:
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

		//public void ApplyAuraTo(Playable playable)
		//{
		//	AuraEffects auraEffects;
		//	if (playable.AuraEffects != null)
		//		auraEffects = playable.AuraEffects;
		//	else
		//	{
		//		auraEffects = new AuraEffects(playable.Card.Type);
		//		playable.AuraEffects = auraEffects;
		//	}

		//	switch (_attr)
		//	{
		//		case Attributes.Rush:
		//			auraEffects.Rush = true;
		//			break;
		//		case Attributes.Lifesteal:
		//			auraEffects.Lifesteal = true;
		//			break;
		//		default:
		//			throw new NotImplementedException();
		//	}
		//}

		public void RemoveFrom(Entity entity)
		{
			var c = (Character) entity;
			c.SetAttribute(_attr, !_value);
		}

		public IEffect ChangeValue(int newValue)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
