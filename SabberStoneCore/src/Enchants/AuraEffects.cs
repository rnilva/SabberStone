﻿using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Auras;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;
// ReSharper disable InconsistentNaming

namespace SabberStoneCore.Enchants
{
	/// <summary>
	/// A simple container for saving tag value perturbations from external Auras. Call indexer to get value for a particular Tag.
	/// </summary>
	public class AuraEffects
	{
		private const int PlayableLength = 2;
		private const int WeaponLength = PlayableLength + 1;
		private const int CharacterLength = PlayableLength + 1;
		private const int HeroLength = CharacterLength + 2;
		private const int MinionLength = CharacterLength + 7;

		internal readonly int[] _data;

		internal AuraEffects(CardType type)
		{
			switch (type)
			{
				case CardType.HERO:
					_data = new int[HeroLength];
					break;
				case CardType.MINION:
					_data = new int[MinionLength];
					break;
				case CardType.WEAPON:
					_data = new int[WeaponLength];
					break;
				case CardType.SPELL:
					_data = new int[PlayableLength];
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}

			Type = type;
		}

		private AuraEffects(AuraEffects original) : this (original.Type)
		{
			Buffer.BlockCopy(original._data, 0, _data, 0, _data.Length);
		}

		public readonly CardType Type;

		public bool CardCostHealth
		{
			get => _data[0] > 0;
			set => _data[0] = value ? 1 : 0;
		}

		public bool Echo
		{
			get => _data[1] > 0;
			set => _data[1] = value ? 1 : 0;
		}

		public bool CantBeTargetedBySpells
		{
			get => _data[2] > 0;
			set => _data[2] = value ? 1 : 0;
		}

		public int ATK
		{
			get => _data[3];
			set => _data[3] = value;
		}

		public int Health
		{
			get => _data[4];
			set => _data[4] = value;
		}

		public int Charge
		{
			get => _data[5];
			set => _data[5] = value;
		}

		public bool Taunt
		{
			get => _data[6] > 0;
			set => _data[6] = value ? 1 : 0;
		}

		public bool Lifesteal
		{
			get => _data[7] > 0;
			set => _data[7] = value ? 1 : 0;
		}

		public bool Rush
		{
			get => _data[8] > 0;
			set => _data[8] = value ? 1 : 0;
		}

		public bool CantAttack
		{
			get => _data[9] > 0;
			set => _data[9] = value ? 1 : 0;
		}

		// Only for Hero entities
		public bool CannotAttackHeroes
		{
			get
			{
				if (Type != CardType.HERO)
					throw new NotImplementedException();
				return _data[4] > 0;
			}
			set
			{
				if (Type != CardType.HERO)
					throw new NotImplementedException();
				_data[4] = value ? 1 : 0;
			}
		}

		public int Immune
		{
			get
			{
				if (Type == CardType.HERO)
					return _data[3];
				if (Type == CardType.WEAPON)
					return _data[2];

				return 0;
			}
			set
			{
				if (Type == CardType.HERO)
					_data[3] = value;
				if (Type == CardType.WEAPON)
					_data[2] = value;

				throw new NotImplementedException();
			}
		}

		public int this[in GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.ATK:
						return ATK;
					case GameTag.HEALTH:
						return Health;
					//case GameTag.COST:
					//	//return GetCost() - ((Entity)Owner)._data[GameTag.COST];
					//	return GetCost() - Owner.GetNativeGameTag(GameTag.COST);
					case GameTag.CHARGE:
						return Charge > 0 ? 1 : 0;
					case GameTag.IMMUNE:
						return Immune;
					case GameTag.LIFESTEAL:
						return Lifesteal ? 1 : 0;
					//case GameTag.CANT_ATTACK:
					//	return CANT_ATTACK;
					case GameTag.CANT_BE_TARGETED_BY_SPELLS:
					case GameTag.CANT_BE_TARGETED_BY_HERO_POWERS:
						return CantBeTargetedBySpells ? 1 : 0;
					case GameTag.CARD_COSTS_HEALTH:
						return CardCostHealth ? 1 : 0;
					case GameTag.RUSH:
						return Rush ? 1 : 0;
					case GameTag.ECHO:
						return Echo ? 1 : 0;
					case GameTag.CANNOT_ATTACK_HEROES:
						return CannotAttackHeroes ? 1 : 0;
					default:
						return 0;
				}
			}
			set
			{
				switch (t)
				{
					case GameTag.ATK:
						ATK = value;
						return;
					case GameTag.HEALTH:
						Health = value;
						return;
					case GameTag.CHARGE:
						Charge += value;
						return;
					case GameTag.HEALTH_MINIMUM:
						//Owner[GameTag.HEALTH_MINIMUM] = value;
						return;
					case GameTag.IMMUNE:
						Immune = value;
						return;
					case GameTag.LIFESTEAL:
						Lifesteal = value > 0;
						return;
					//case GameTag.CANT_ATTACK:
					//	CANT_ATTACK = value;
					//	return;
					case GameTag.CANT_BE_TARGETED_BY_SPELLS:
					case GameTag.CANT_BE_TARGETED_BY_HERO_POWERS:
						CantBeTargetedBySpells = value > 0;
						return;
					case GameTag.CARD_COSTS_HEALTH:
						CardCostHealth = value > 0;
						return;
					case GameTag.RUSH:
						Rush = value > 0;
						return;
					case GameTag.ECHO:
						Echo = value > 0;
						return;
					case GameTag.CANNOT_ATTACK_HEROES:
						CannotAttackHeroes = value > 0;
						return;
					default:
						return;
				}
			}
		}

		public AuraEffects Clone()
		{
			return new AuraEffects(this);
		}

		public string Hash()
		{
			var hash = new StringBuilder();
			hash.Append("[AE:");
			int[] data = _data;
			for (int i = 0; i < data.Length; i++)
				hash.Append(data[i]);
			hash.Append("]");
			return hash.ToString();
		}
	}

	/// <summary>
	/// A collecton of controller Tag increments from Auras. These tags tends to be checked when a player plays any cards.
	/// </summary>
	public class ControllerAuraEffects
	{
		private int _timeOut;
		private int _spellPowerDouble;
		private int _heroPowerDouble;
		private int _restoreToDamage;
		private int _extraBattecry;
		private int _chooseBoth;
		private int _spellsCostHealth;
		private int _extraEndTurnEffect;
		private int _heroPowerDisabled;
		private int _allHealingDouble;

		public int this[GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.TIMEOUT:
						return _timeOut;
					case GameTag.SPELLPOWER_DOUBLE:
					case GameTag.SPELL_HEALING_DOUBLE:
						return _spellPowerDouble;
					case GameTag.HERO_POWER_DOUBLE:
						return _heroPowerDouble;
					case GameTag.RESTORE_TO_DAMAGE:
						return _restoreToDamage >= 1 ? 1 : 0;
					case GameTag.CHOOSE_BOTH:
						return _chooseBoth >= 1 ? 1 : 0;
					case GameTag.SPELLS_COST_HEALTH:
						return _spellsCostHealth >= 1 ? 1 : 0;
					case GameTag.EXTRA_BATTLECRY:
						return _extraBattecry;
					case GameTag.EXTRA_END_TURN_EFFECT:
						return _extraEndTurnEffect;
					case GameTag.HERO_POWER_DISABLED:
						return _heroPowerDisabled >= 1 ? 1 : 0;
					case GameTag.ALL_HEALING_DOUBLE:
						return _allHealingDouble;
					default:
						return 0;
				}
			}
			set
			{
				switch (t)
				{
					case GameTag.TIMEOUT:
						_timeOut = value;
						return;
					case GameTag.SPELLPOWER_DOUBLE:
					case GameTag.SPELL_HEALING_DOUBLE:
						_spellPowerDouble = value;
						return;
					case GameTag.HERO_POWER_DOUBLE:
						_heroPowerDouble = value;
						return;
					case GameTag.RESTORE_TO_DAMAGE:
						_restoreToDamage = value;
						return;
					case GameTag.CHOOSE_BOTH:
						_chooseBoth = value;
						return;
					case GameTag.SPELLS_COST_HEALTH:
						_spellsCostHealth = value;
						return;
					case GameTag.EXTRA_BATTLECRY:
						_extraBattecry = value;
						return;
					case GameTag.EXTRA_END_TURN_EFFECT:
						_extraEndTurnEffect = value;
						return;
					case GameTag.HERO_POWER_DISABLED:
						_heroPowerDisabled = value;
						return;
					case GameTag.ALL_HEALING_DOUBLE:
						_allHealingDouble = value;
						return;
					default:
						return;
				}
			}
		}

		public ControllerAuraEffects Clone()
		{
			return (ControllerAuraEffects)MemberwiseClone();
		}

		public string Hash()
		{
			var sb = new StringBuilder("[CAE:");
			sb.Append(_timeOut);
			sb.Append(_spellPowerDouble);
			sb.Append(_heroPowerDouble);
			sb.Append(_restoreToDamage);
			sb.Append(_extraBattecry);
			sb.Append(_chooseBoth);
			sb.Append(_spellsCostHealth);
			sb.Append(_extraEndTurnEffect);
			sb.Append(_heroPowerDisabled);
			sb.Append(_allHealingDouble);
			sb.Append("]");
			return sb.ToString();
		}
	}
}
