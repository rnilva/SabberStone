using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
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
		HeroPowerDamage = 5,
		ExtraAttacksThisTurn = 6
	}

	public static class AttributeHelpers
	{
		private static readonly ReadOnlyDictionary<IntAttributes, GameTag> IntAttrToTagMap;
		private static readonly ReadOnlyDictionary<GameTag, IntAttributes> TagToIntAttrMap;
		private static readonly ReadOnlyDictionary<BoolAttributes, GameTag> BoolAttrToTagMap;
		private static readonly ReadOnlyDictionary<GameTag, BoolAttributes> TagToBoolAttrMap;

		private static readonly ReadOnlyDictionary<GameTag, ControllerIntAttributes> TagToControllerIntAttrMap;
		private static readonly ReadOnlyDictionary<ControllerIntAttributes, GameTag> ControllerIntAttrToTagMap;
		private static readonly ReadOnlyDictionary<GameTag, ControllerBoolAttributes> TagToControllerBoolAttrMap;
		private static readonly ReadOnlyDictionary<ControllerBoolAttributes, GameTag> ControllerBoolAttrToTagMap;

		static AttributeHelpers()
		{
			IntAttrToTagMap = new ReadOnlyDictionary<IntAttributes, GameTag>(new Dictionary<IntAttributes, GameTag>
			{
				{IntAttributes.SpellPower, GameTag.SPELLPOWER},
				{IntAttributes.Damage, GameTag.DAMAGE},
				{IntAttributes.NumAttacksThisTurn, GameTag.NUM_ATTACKS_THIS_TURN},
				{IntAttributes.HeroPowerDamage, GameTag.HEROPOWER_DAMAGE},
				{IntAttributes.ExtraAttacksThisTurn, GameTag.EXTRA_ATTACKS_THIS_TURN }
			});

			TagToIntAttrMap = new ReadOnlyDictionary<GameTag, IntAttributes>(
				IntAttrToTagMap.ToDictionary(p => p.Value, p => p.Key));

			BoolAttrToTagMap = new ReadOnlyDictionary<BoolAttributes, GameTag>(new Dictionary<BoolAttributes, GameTag>
			{
				{BoolAttributes.CannotAttackHeroes, GameTag.CANNOT_ATTACK_HEROES},
				{BoolAttributes.CantAttack, GameTag.CANT_ATTACK},
				{BoolAttributes.Charge, GameTag.CHARGE},
				{BoolAttributes.Deathrattle, GameTag.DEATHRATTLE},
				{BoolAttributes.DivineShield, GameTag.DIVINE_SHIELD},
				{BoolAttributes.Elusive, GameTag.CANT_BE_TARGETED_BY_SPELLS},
				{BoolAttributes.Frozen, GameTag.FROZEN},
				{BoolAttributes.Immune, GameTag.IMMUNE},
				{BoolAttributes.Lifesteal, GameTag.LIFESTEAL},
				{BoolAttributes.Poisonous, GameTag.POISONOUS},
				{BoolAttributes.Rush, GameTag.RUSH},
				{BoolAttributes.Stealth, GameTag.STEALTH},
				{BoolAttributes.Taunt, GameTag.TAUNT},
				{BoolAttributes.Windfury, GameTag.WINDFURY},
			});

			TagToBoolAttrMap = new ReadOnlyDictionary<GameTag, BoolAttributes>(
				BoolAttrToTagMap.ToDictionary(p => p.Value, p => p.Key));


			ControllerIntAttrToTagMap = new ReadOnlyDictionary<ControllerIntAttributes, GameTag>(
				new Dictionary<ControllerIntAttributes, GameTag>
				{
					{ControllerIntAttributes.PlayerId, GameTag.PLAYER_ID},
					{ControllerIntAttributes.HeroId, GameTag.HERO_ENTITY},
					{ControllerIntAttributes.PlayState, GameTag.PLAYSTATE},
					{ControllerIntAttributes.MulliganState, GameTag.MULLIGAN_STATE},
					{ControllerIntAttributes.BaseMana, GameTag.RESOURCES},
					{ControllerIntAttributes.UsedMana, GameTag.RESOURCES_USED},
					{ControllerIntAttributes.TemporaryMana, GameTag.TEMP_RESOURCES},
					{ControllerIntAttributes.OverloadOwed, GameTag.OVERLOAD_OWED},
					{ControllerIntAttributes.OverloadLocked, GameTag.OVERLOAD_LOCKED},
					{ControllerIntAttributes.OverloadThisGame, GameTag.OVERLOAD_THIS_GAME},
					{ControllerIntAttributes.SpellPowerDouble, GameTag.SPELLPOWER_DOUBLE},
					{ControllerIntAttributes.HeroPowerDouble, GameTag.HERO_POWER_DOUBLE},
					{ControllerIntAttributes.AllHealingDouble, GameTag.ALL_HEALING_DOUBLE},
					{ControllerIntAttributes.NumTurnsLeft, GameTag.NUM_TURNS_LEFT},
					{ControllerIntAttributes.LastCardPlayed, GameTag.LAST_CARD_PLAYED},
					{ControllerIntAttributes.LastCardDrawn, GameTag.LAST_CARD_DRAWN},
					{ControllerIntAttributes.LastCardDiscarded, GameTag.LAST_CARD_DISCARDED},
					{ControllerIntAttributes.NumCardsDrawnThisTurn, GameTag.NUM_CARDS_DRAWN_THIS_TURN},
					{ControllerIntAttributes.NumCardsPlayedThisTurn, GameTag.NUM_CARDS_PLAYED_THIS_TURN},
					{ControllerIntAttributes.NumMinionsPlayedThisTurn, GameTag.NUM_MINIONS_PLAYED_THIS_TURN},
					{ControllerIntAttributes.NumOptionsPlayedThisTurn, GameTag.NUM_OPTIONS_PLAYED_THIS_TURN},
					{ControllerIntAttributes.NumFriendlyMinionsThatDiedThisTurn, GameTag.NUM_FRIENDLY_MINIONS_THAT_DIED_THIS_TURN},
					{ControllerIntAttributes.AmountHeroHealedThisTurn, GameTag.AMOUNT_HERO_HEALED_THIS_TURN},
					{ControllerIntAttributes.NumMinionsPlayerKilledThisTurn, GameTag.NUM_MINIONS_PLAYER_KILLED_THIS_TURN},
					{ControllerIntAttributes.NumFriendlyMinionsThatAttackedThisTurn, GameTag.NUM_FRIENDLY_MINIONS_THAT_ATTACKED_THIS_TURN},
					{ControllerIntAttributes.HeroPowerActivationsThisTurn, GameTag.HEROPOWER_ACTIVATIONS_THIS_TURN},
					{ControllerIntAttributes.NumElementalsPlayedThisTurn, GameTag.NUM_ELEMENTAL_PLAYED_THIS_TURN},
					{ControllerIntAttributes.NumElementalsPlayedLastTurn, GameTag.NUM_ELEMENTAL_PLAYED_LAST_TURN},
					{ControllerIntAttributes.TotalManaSpentThisGame, GameTag.NUM_RESOURCES_SPENT_THIS_GAME},
					{ControllerIntAttributes.NumTimesHeroPowerUsedThisGame, GameTag.NUM_TIMES_HERO_POWER_USED_THIS_GAME},
					{ControllerIntAttributes.NumHeroPowerDamageThisGame, GameTag.NUM_HERO_POWER_DAMAGE_THIS_GAME},
					{ControllerIntAttributes.AmountHealedThisGame, GameTag.AMOUNT_HEALED_THIS_GAME},
					{ControllerIntAttributes.NumSecretsPlayedThisGame, GameTag.NUM_SECRETS_PLAYED_THIS_GAME},
					{ControllerIntAttributes.NumSpellsPlayedThisGame, GameTag.NUM_SPELLS_PLAYED_THIS_GAME},
					{ControllerIntAttributes.NumWeaponsPlayedThisGame, GameTag.NUM_WEAPONS_PLAYED_THIS_GAME},
					{ControllerIntAttributes.NumMurlocsPlayedThisGame, GameTag.NUM_MURLOCS_PLAYED_THIS_GAME},
					{ControllerIntAttributes.TimeOut, GameTag.TIMEOUT},
					{ControllerIntAttributes.ProxyCthun, GameTag.PROXY_CTHUN},
				});

			TagToControllerIntAttrMap = new ReadOnlyDictionary<GameTag, ControllerIntAttributes>(
				ControllerIntAttrToTagMap.ToDictionary(p => p.Value, p => p.Key));

			ControllerBoolAttrToTagMap = new ReadOnlyDictionary<ControllerBoolAttributes, GameTag>(
				new Dictionary<ControllerBoolAttributes, GameTag>
				{
					{ControllerBoolAttributes.RestoreToDamage, GameTag.HEALING_DOES_DAMAGE},
					{ControllerBoolAttributes.ExtraDeathrattle, GameTag.EXTRA_DEATHRATTLES_BASE},
					{ControllerBoolAttributes.ExtraBattlecry, GameTag.EXTRA_BATTLECRIES_BASE},
					{ControllerBoolAttributes.ChooseBoth, GameTag.CHOOSE_BOTH},
					{ControllerBoolAttributes.SpellsCostHealth, GameTag.SPELLS_COST_HEALTH},
					{ControllerBoolAttributes.ExtraEndTurnEffect, GameTag.EXTRA_END_TURN_EFFECT},
					{ControllerBoolAttributes.HeroPowerDisabled, GameTag.HERO_POWER_DISABLED},
					{ControllerBoolAttributes.ExtraBattleCryAndCombo, GameTag.EXTRA_MINION_BATTLECRIES_BASE},
				});

			TagToControllerBoolAttrMap = new ReadOnlyDictionary<GameTag, ControllerBoolAttributes>(
				ControllerBoolAttrToTagMap.ToDictionary(p => p.Value, p => p.Key));
		}

		public static GameTag AttributeToGameTag(IntAttributes intAttr)
			=> IntAttrToTagMap.TryGetValue(intAttr, out GameTag value)
				? value
				: throw new NotImplementedException($"Mapping to {intAttr} to GameTag is not implemented.");
		public static GameTag AttributeToGameTag(BoolAttributes boolAttr)
			=> BoolAttrToTagMap.TryGetValue(boolAttr, out GameTag value)
				? value
				: throw new NotImplementedException($"Mapping to {boolAttr} to GameTag is not implemented."); 
		public static IntAttributes GameTagToIntAttribute(GameTag tag)
			=> TagToIntAttrMap.TryGetValue(tag, out IntAttributes value) ? value : IntAttributes.Invalid;

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

		public static ControllerIntAttributes GameTagToControllerIntAttribute(GameTag tag)
			=> TagToControllerIntAttrMap.TryGetValue(tag, out ControllerIntAttributes value)
				? value : ControllerIntAttributes.Invalid;
		public static GameTag ControllerIntAttributeToGameTag(ControllerIntAttributes attr)
			=> ControllerIntAttrToTagMap.TryGetValue(attr, out GameTag value)
				? value
				: throw new NotImplementedException($"Mapping to {attr} to GameTag is not implemented.");

		public static ControllerBoolAttributes GameTagToControllerBoolAttribute(GameTag tag)
			=> TagToControllerBoolAttrMap.TryGetValue(tag, out ControllerBoolAttributes value)
				? value : ControllerBoolAttributes.Invalid;
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
