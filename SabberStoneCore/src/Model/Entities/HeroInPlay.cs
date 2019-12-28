using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;

namespace SabberStoneCore.Model.Entities
{
	public class HeroInPlay : Hero
	{
		public HeroInPlay(in Controller controller, in Card card, in int id = -1) : base(in controller, in card, in id)
		{
			_v1 = card.ATK;
			Auras = new List<Aura>();
			Zone = controller.BoardZone;
		}

		private HeroInPlay(in Controller controller, HeroInPlay hero) : base(in controller, hero)
		{
			Auras = new List<Aura>(hero.Auras.Count);
			DamageTakenThisTurn = hero.DamageTakenThisTurn;
			Armor = hero.Armor;
			_attrs = hero._attrs;
			Zone = controller.BoardZone;
		}

		public static HeroInPlay FromCard(in Controller c, in Card card)
		{
			var entity = new HeroInPlay(in c, in card);
			c.Game.IdEntityDic[entity.Id] = entity;
			if (card.ChooseOne) CreateChooseOnePlayables(in c, entity, in card, -1);
			return entity;
		}

		public List<Aura> Auras { get; }

		/// <summary>Gets or sets the hero power entity.</summary>
		/// <value><see cref="Entities.HeroPower"/></value>
		public HeroPower HeroPower { get; set; }

		/// <summary>Gets or sets the weapon entity equipped on the Hero.</summary>
		/// <value><see cref="Entities.Weapon"/></value>
		public Weapon Weapon { get; set; }

		internal override bool GetAttribute(Entities.BoolAttributes attr)
		{
			unsafe
			{
				return _attrs.boolAttrs[(int) attr];
			}
		}
		internal override void SetAttribute(Entities.BoolAttributes attr, bool value)
		{
			unsafe
			{
				_attrs.boolAttrs[(int) attr] = value;
			}
		}

		public override int this[GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.SPELLPOWER:
						return SpellPower;
					case GameTag.HEROPOWER_DAMAGE:
						return HeroPowerDamage;
					case GameTag.FATIGUE:
						return Fatigue;
					default:
						return base[t];
				}
			}
			set
			{
				switch (t)
				{
					case GameTag.SPELLPOWER:
						SpellPower = value;
						return;
					case GameTag.HEROPOWER_DAMAGE:
						HeroPowerDamage = value;
						return;
					case GameTag.FATIGUE:
						Fatigue = value;
						return;
					default:
						base[t] = value;
						return;
				}
			}
		}

		public override int AttackDamage
		{
			get
			{
				int value = _v1.Value;
				if (Weapon != null && Game.CurrentPlayer == Controller)
					return Weapon.AttackDamage + value;
				return value;
			}
			set => _v1 = value;
		}

		public override bool CanAttack(bool checkTargets = true)
			=> AttackDamage > 0
			   && (!IsExhausted || (ExtraAttacksThisTurn > 0 && ExtraAttacksThisTurn >= NumAttacksThisTurn))
			   && !IsFrozen
			   && (!checkTargets || HasAnyValidAttackTargets());

		public override bool HasWindfury
		{
			get => Weapon?.HasWindfury ?? false;
			set => throw new NotImplementedException();
		}

		public override bool HasLifeSteal => Weapon?.HasLifeSteal ?? false;

		public override bool HasOverkill => Weapon?.HasOverkill ?? false;

		public override void Destroy()
		{
			_toBeDestroyed = true;
			Game.ResolveDeadHeroes += DisposeHero;
		}

		public static HeroInPlay FromHero(ref Hero hero)
		{
			var inPlay = new HeroInPlay(hero.Controller, hero.Card, hero.Id)
			{
				_data = hero._data,
				ChooseOnePlayables = hero.ChooseOnePlayables
			};
			inPlay.ChooseOnePlayables = hero.ChooseOnePlayables;
			hero.Game.IdEntityDic[hero.Id] = inPlay;
			hero = inPlay;
			return inPlay;
		}

		/// <summary>
		/// Gain the specified amount of armor.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="armor"></param>
		public void GainArmor(Playable source, int armor)
		{
			Game.Log(LogLevel.INFO, BlockType.ACTION, "Character", !Game.Logging? "":$"{this} gaining armor for {armor}.");
			Armor += armor;
			EventMetaData temp = Game.CurrentEventData;
			Game.CurrentEventData = new EventMetaData(source, this, armor);
			Game.TriggerManager.OnArmorTrigger(this);
			//Game.ProcessTasks();
			Game.CurrentEventData = temp;
		}

		public void AddWeapon(Weapon weapon)
		{
			RemoveWeapon();
			//weapon.OrderOfPlay = Game.NextOop;
			Weapon = weapon;
			if (_history)
			{
				Weapon[GameTag.ZONE] = (int)Enums.Zone.PLAY;
				Weapon[GameTag.ZONE_POSITION] = 0;
				//EquippedWeapon = weapon.Id;
			}

			Weapon.Zone = Controller.BoardZone;
			if (weapon.HasWindfury && IsExhausted && NumAttacksThisTurn == 1)
				IsExhausted = false;

			Game.TriggerManager.OnEquipWeaponTrigger(weapon);
		}

		/// <summary>
		/// Removes the equipped weapon to the graveyard. This triggers deathrattle events on the weapon.
		/// </summary>
		public void RemoveWeapon()
		{
			if (Weapon == null)
				return;

			if (Weapon.HasDeathrattle)
				Weapon.ActivateTask(PowerActivation.DEATHRATTLE);

			Game.TriggerManager.OnDeathTrigger(Weapon);

			Game.Log(LogLevel.INFO, BlockType.PLAY, "Hero", !Game.Logging? "":$"Butcher's knife incoming to graveyard, say 'gugus' to {Weapon}");
			Controller.GraveyardZone.Add(Weapon);

			ClearWeapon();
		}

		/// <summary>
		/// Clears weapon information on Hero.
		/// </summary>
		public void ClearWeapon()
		{
			Weapon.ActivatedTrigger?.Remove();
			Weapon.OngoingEffect?.Remove();
			if (Weapon.AppliedEnchantments != null /*&& Weapon[GameTag.KEEP_ENCHANTMENTS] != 1*/)
			{
				for (int i = Weapon.AppliedEnchantments.Count - 1; i >= 0; i--)
					Weapon.AppliedEnchantments[i].Remove();
				Weapon.AppliedEnchantments.Clear();
			}

			Weapon = null;
			//EquippedWeapon = 0;
		}

		public override Playable Clone(in Controller controller)
		{
			return new HeroInPlay(in controller, this);
		}

		internal override void ApplyEffect(AbstractEffect effect)
		{
			effect.ApplyTo(this);
		}
		internal override void RemoveEffect(AbstractEffect effect)
		{
			effect.RemoveFrom(this);
		}

		public string FullPrint()
		{
			var str = new StringBuilder();
			string mStr = Weapon != null ? $"[{Weapon.Card.Name}[{Weapon.AttackDamage}/{Weapon.Durability}]]" : "[NO WEAPON]";
			str.Append($"[HERO][{this}][ATK{AttackDamage}/AR{Armor}/HP{Health}][WP{mStr}][SP{Controller.CurrentSpellPower}]");
			//str.Append($"[ENCH {OldEnchants.Count}]");
			//str.Append($"[TRIG {Triggers.Count}]");
			return str.ToString();
		}

		public void DisposeHero()
		{
			if (Controller.Opponent.PlayState == PlayState.LOSING)
			{
				Controller.PlayState = PlayState.TIED;
				Controller.Opponent.PlayState = PlayState.TIED;
			}
			else
				Controller.PlayState = PlayState.LOSING;
		}

		private static readonly Action<Game> SetDraw = g =>
		{
			g.Player1.PlayState = PlayState.TIED;
			g.Player2.PlayState = PlayState.TIED;
		};
		public int EquippedWeapon => Weapon?.Id ?? 0;

		private Attributes _attrs;

		private unsafe struct Attributes
		{
			// 0 : SpellPower

			// 1 : Damage
			// 2 : NumAttacksThisTurn
			// 3 : Fatigue
			// 4 : DamageTakenThisTurn
			// 5 : HeroPowerDamage
			// 6 : ExtraAttacksThisTurn


			// 0 : Immune
			// 1 : Frozen
			// 2 : Stealth
			// 3 : CantBeTargetedBySpells
			// 4 : CannotAttackHeroes

			private const int NUM_INT_ATTRS = 7;
			private const int NUM_BOOL_ATTRS = 5;
#pragma warning disable 649
			public fixed int intAttrs[NUM_INT_ATTRS];
			public fixed bool boolAttrs[NUM_BOOL_ATTRS];
#pragma warning restore 649
		}

		public unsafe int SpellPower
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[0];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[0] = value;
		}
		public override unsafe int Damage
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[1];
			set
			{
				if (value < 0)
					value = 0;
				else if (BaseHealth <= value)
					Destroy();

				_attrs.intAttrs[1] = value;
			}
		}
		public override unsafe int NumAttacksThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[2];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[2] = value;
		}
		public unsafe int Fatigue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[3];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[3] = value;
		}
		public unsafe int DamageTakenThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[4];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[4] = value;
		}
		public unsafe int HeroPowerDamage
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[5];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[5] = value;
		}
		public unsafe int ExtraAttacksThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[6];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[6] = value;
		}
		public override unsafe bool IsImmune
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[0];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[0] = value;
		}
		public override unsafe bool IsFrozen
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[1];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[1] = value;
		}
		public override unsafe bool HasStealth
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[2];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[2] = value;
		}
		public override unsafe bool CantBeTargetedBySpells
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[3];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[3] = value;
		}
		public override unsafe bool CantAttackHeroes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[4];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[4] = value;
		}
		internal override unsafe ref bool GetRef(int index)
		{
			return ref _attrs.boolAttrs[index];
		}
		internal override unsafe ref int GetIntRef(int index)
		{
			return ref _attrs.intAttrs[index];
		}
	}
}
