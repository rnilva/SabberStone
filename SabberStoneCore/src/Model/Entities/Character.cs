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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Tasks;

namespace SabberStoneCore.Model.Entities
{
	/// <summary>
	/// Base implementation of Character.
	/// <seealso cref="Character"/>
	/// <seealso cref="Playable"/>
	/// </summary>
	public abstract class Character : Playable
	{
		public event TriggerManager.TriggerHandler PreDamageTrigger;
		public event TriggerManager.TriggerHandler TakeDamageTrigger;
		public event TriggerManager.TriggerHandler AfterAttackTrigger;

		protected bool _toBeDestroyed;

		/// <summary>
		/// Build a new character from the provided data.
		/// </summary>
		/// <param name="controller">Owner of the character; not specifically limited to players.</param>
		/// <param name="card">The card which this character embodies.</param>
		/// <param name="tags">Properties of this entity.</param>
		/// <param name="id">Integral id of this entity. </param>
		protected Character(in Controller controller, in Card card, in int id)
			: base(in controller, in card, in id)
		{

		}

		/// <summary>
		/// A copy constructor. This constructor is only used to the inherited copy constructors.
		/// </summary>
		/// <param name="controller">The target <see cref="T:SabberStoneCore.Model.Entities.Controller" /> instance.</param>
		/// <param name="character">The source <see cref="T:SabberStoneCore.Model.Entities.Character`1" />.</param>
		protected Character(in Controller controller, in Character character) : base(in controller, character)
		{
			_toBeDestroyed = character._toBeDestroyed;
		}

		/// <summary>
		/// Character is dead or destroyed.
		/// </summary>
		public bool IsDead => Health <= 0 || ToBeDestroyed;

		public override int this[GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.ATK:
						return AttackDamage;
					case GameTag.HEALTH:
						return BaseHealth;
					case GameTag.DAMAGE:
						return Damage;
					case GameTag.STEALTH:
						return HasStealth ? 1 : 0;
					case GameTag.IMMUNE:
						return IsImmune ? 1 : 0;
					case GameTag.TAUNT:
						return HasTaunt ? 1 : 0;
					case GameTag.CANT_BE_TARGETED_BY_SPELLS:
					case GameTag.CANT_BE_TARGETED_BY_HERO_POWERS:
						return CantBeTargetedBySpells ? 1 : 0;
					case GameTag.NUM_ATTACKS_THIS_TURN:
						return NumAttacksThisTurn;
					case GameTag.WINDFURY:
						return HasWindfury ? 1 : 0;
					case GameTag.POISONOUS:
						return Poisonous ? 1 : 0;
					default:
						return base[t];
				}
			}
			set
			{
				switch (t)
				{
					case GameTag.ATK:
						AttackDamage = value;
						return;
					case GameTag.HEALTH:
						BaseHealth = value;
						return;
					case GameTag.DAMAGE:
						Damage = value;
						return;
					case GameTag.STEALTH:
						HasStealth = value > 0;
						return;
					case GameTag.IMMUNE:
						IsImmune = value > 0;
						return;
					case GameTag.TAUNT:
						HasTaunt = value > 0;
						return;
					case GameTag.CANT_BE_TARGETED_BY_SPELLS:
					case GameTag.CANT_BE_TARGETED_BY_HERO_POWERS:
						CantBeTargetedBySpells = value > 0;
						return;
					case GameTag.NUM_ATTACKS_THIS_TURN:
						NumAttacksThisTurn = value;
						return;
					default:
						base[t] = value;
						return;
				}
			}
		}

		/// <summary>
		/// Character can attack.
		/// </summary>
		public virtual bool CanAttack(bool checkTargets = true)
			=> !IsExhausted &&
			   !IsFrozen &&
			   !CantAttack &&
			   (!checkTargets || HasAnyValidAttackTargets());

		/// <summary>
		/// Indicates if the provided character can be attacked by this character.
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public virtual bool IsValidAttackTarget(Character target)
		{
			// got target but isn't contained in valid targets
			if (!GetValidAttackTargets().Contains(target))
			{
				Game.Log(LogLevel.WARNING, BlockType.ACTION, "Character", !Game.Logging? "":$"{this} has an invalid target {target}.");
				return false;
			}

			if (target is HeroInPlay)
			{
				if (CantAttackHeroes || (this is MinionInPlay m && m.AttackableByRush))
				{
					Game.Log(LogLevel.WARNING, BlockType.ACTION, "Character", !Game.Logging ? "" : $"Can't attack Heroes!");
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Returns a sequence of characters which are attackable.
		/// </summary>
		public IEnumerable<Character> GetValidAttackTargets()
		{
			bool tauntFlag = false;
			var allTargets = new List<Character>(4);
			var allTargetsTaunt = new List<Character>(2);
			foreach (Minion minion in Controller.Opponent.BoardZone.GetAll())
			{
				if (!minion.HasStealth)
				{
					if (minion.HasTaunt)
					{
						allTargetsTaunt.Add(minion);
						tauntFlag = true;
						continue;
					}
					if (!tauntFlag)
						allTargets.Add(minion);
				}
			}
			if (tauntFlag)
				return allTargetsTaunt;

			Hero opHero = Controller.Opponent.Hero;

			if (!(this is MinionInPlay m && m.AttackableByRush) && !CantAttackHeroes && !opHero.IsImmune && !opHero.HasStealth)
				allTargets.Add(opHero);

			return allTargets;
		}

		public bool HasAnyValidAttackTargets()
		{
			ReadOnlySpan<MinionInPlay> span = Controller.Opponent.BoardZone.GetSpan();
			for (int i = 0; i < span.Length; i++)
			{
				if (!(span[i].HasStealth || span[i].IsImmune))
					return true;
			}

			bool isOpHeroValidPlayTarget =
				!Controller.Opponent.Hero.HasStealth && !Controller.Opponent.Hero.IsImmune;

			if (isOpHeroValidPlayTarget && (!CantAttackHeroes || this is MinionInPlay m && m.AttackableByRush))
				return true; // Op Hero is a valid attack target

			return false;
		}

		/// <summary>
		/// Inflict damage onto this character.
		/// The actual amount still needs to be determined by the current
		/// state of the game. eg: The presence of immunity effects can cause
		/// the damage to be ignored.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="damage"></param>
		/// <returns></returns>
		public int TakeDamage(Playable source, int damage)
		{
			Game game = Game;
			var hero = this as HeroInPlay;
			var minion = this as MinionInPlay;

			if (minion != null && minion.Zone.Type != Enums.Zone.PLAY)
				return 0;

			bool fatigue = hero != null && this == source;

			if (fatigue)
				hero.Fatigue = damage;

			if (minion != null && minion.HasDivineShield)
			{
				game.Log(LogLevel.INFO, BlockType.ACTION, "Character", !game.Logging? "":$"{this} divine shield absorbed incoming damage.");
				minion.HasDivineShield = false;
				return 0;
			}

			int armor = hero?.Armor ?? 0;

			int amount = hero == null ? damage : armor < damage ? damage - armor : 0;

			// Damage event is created
			// Collect all the tasks and sort them by order of play
			// Death phase and aura update are not emerge here

			// place event related data
			//game.TaskQueue.StartEvent();
			EventMetaData temp = game.CurrentEventData;
			game.CurrentEventData = new EventMetaData(source, this, amount);

			//// added pre damage
			//if (_history)
			//	PreDamage = amount;

			// Predamage triggers (e.g. Ice Block)
			if (PreDamageTrigger != null)
			{
				game.TaskQueue.StartEvent();
				PreDamageTrigger.Invoke(this);
				game.ProcessTasks();
				game.TaskQueue.EndEvent();
				amount = game.CurrentEventData.EventNumber;
				if (amount == 0 && armor == 0)
				{
					//if (_history)
					//	PreDamage = 0;
					game.CurrentEventData = temp;
					return 0;
				}
			}
			if (IsImmune)
			{
				//game.TaskQueue.EndEvent();
				game.CurrentEventData = temp;

				game.Log(LogLevel.INFO, BlockType.ACTION, "Character", !game.Logging ? "" : $"{this} is immune.");
                //if (_history)
                //    PreDamage = 0;
                return 0;
			}

			//// reset predamage
			//if (_history)
			//	PreDamage = 0;

			// remove armor first from hero ....
			if (armor > 0)
				hero.Armor = armor < damage ? 0 : armor - damage;

			// final damage is beeing accumulated
			Damage += amount;

			game.Log(LogLevel.INFO, BlockType.ACTION, "Character", !game.Logging? "":$"{this} took damage for {amount}({damage}). {(fatigue ? "(fatigue)" : "")}");

			//LastAffectedBy = source.Id;	TODO

			// on-damage triggers
			game.TaskQueue.StartEvent();
			TakeDamageTrigger?.Invoke(this);
			game.TriggerManager.OnDamageTrigger(this);
			game.TriggerManager.OnDealDamageTrigger(source);

            // Check if the source is Overkill
            if (source.HasOverkill && source.Controller == game.CurrentPlayer && Health < 0)
            {
                game.Log(LogLevel.VERBOSE, BlockType.TRIGGER, "TakeDamage", !_logging ? "" : $"{source}' Overkill is triggered.");

                SimpleTask task = source is HeroInPlay h ? h.Weapon.Card.Power.OverkillTask : source.Card.Power.OverkillTask;
                game.TaskQueue.Enqueue(task, source.Controller, source, null);
            }

			game.ProcessTasks();
			game.TaskQueue.EndEvent();
			game.CurrentEventData = temp;

			// Check if the source is lifesteal
			if (source.HasLifeSteal && !_lifestealChecker)
			{
				if (game.History)
					game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, source.Id, source.Card.Id, -1, 0)); // TriggerKeyword=LIFESTEAL
				if (game.Logging)
					game.Log(LogLevel.VERBOSE, BlockType.ATTACK, "TakeDamage", !_logging ? "" : $"lifesteal source {source} has damaged target for {amount}.");

				source.Controller.Hero.TakeHeal(source, amount);

				if (game.History)
					game.PowerHistory.Add(new PowerHistoryBlockEnd());

				if (source.Controller.Hero.ToBeDestroyed && source.Controller.Hero.Health > 0)
				{
					source.Controller.Hero._toBeDestroyed = false;
					Game.ResolveDeadHeroes -= source.Controller.Hero.DisposeHero;
				}
			}

			if (hero != null)
				hero.DamageTakenThisTurn += amount;

			if (source.Card.Type == CardType.HERO_POWER)
				source.Controller.NumHeroPowerDamageThisGame += amount;

			return amount;
		}

		/// <summary>
		/// Heal up all taken damage.
		/// </summary>
		/// <param name="source"></param>
		public void TakeFullHeal(Playable source)
		{
			TakeHeal(source, Damage);
		}

		/// <summary>
		/// Heal a specified amount of health.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="heal"></param>
		public void TakeHeal(Playable source, int heal)
		{
			if ((source is Spell || source is HeroPower) && source.Controller.SpellHealingDouble > 0)
			{
				heal *= (int) Math.Pow(2, source.Controller.SpellHealingDouble);
			}

			if (source.Controller.AllHealingDouble > 0)
				heal *= (int) Math.Pow(2, source.Controller.AllHealingDouble);

			if (source.Controller.RestoreToDamage)
			{
				if (_lifestealChecker)
					return;

				_lifestealChecker = true;
				TakeDamage(source, heal);
				_lifestealChecker = false;
				return;
			}
			// we don't heal undamaged entities
			if (Damage == 0)
			{
				return;
			}

			int amount = Damage > heal ? heal : Damage;
			if (Game.Logging)
				Game.Log(LogLevel.INFO, BlockType.ACTION, "Character", $"{this} took healing for {amount}.");
			Damage -= amount;

			// Heal event created
			// Process gathered tasks
			EventMetaData temp = Game.CurrentEventData;
			Game.CurrentEventData = new EventMetaData(source, this, amount);
			Game.TriggerManager.OnHealTrigger(this);
			Game.CurrentEventData = temp;

			if (this is Hero)
				Controller.AmountHeroHealedThisTurn += amount;
		}

		/// <summary>
		/// Character is member of Race.
		/// Characters of Race.ALL.  IE Amalgam.IsRace(Race.MULROC/Race.DRAGON/...) => true
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsRace(Race race) => Card.IsRace(race);

		public void OnAfterAttackTrigger()
		{
			AfterAttackTrigger?.Invoke(this);
		}

		public override string Hash(params GameTag[] ignore)
		{
			var sb = new StringBuilder(base.Hash(ignore));
			//sb.Append($"[A:{_modifiedATK}, ");
			//sb.Append($"H:{_modifiedHealth}, ");
			//sb.Append($"D:{_damage}]");
			return sb.ToString();
		}

		private bool _lifestealChecker;

		public virtual int AttackDamage
		{
			get => _v1 ?? (_v1 = Card.ATK).Value;
			set => _v1 = value;
		}
		public virtual int BaseHealth
		{
			get => _v2 ?? (_v2 = Card.Health).Value;
			set => _v2 = value;
		}
		public virtual int Damage
		{
			get => default;
			// ReSharper disable once ValueParameterNotUsed
			set{ }
		}

		public int Health
		{
			get => BaseHealth - Damage;
			set
			{
				if (value == 0) Destroy();
				BaseHealth = value;
				Damage = 0;
			}
		}

		public virtual bool CantAttack
		{
			get => Card.CantAttack;
			set => throw new NotImplementedException();
		}
		public virtual bool CantAttackHeroes
		{
			get => Card[GameTag.CANNOT_ATTACK_HEROES] == 1;
			set => throw new NotImplementedException();
		}
		public virtual bool CantBeTargetedBySpells
		{
			get => Card.CantBeTargetedBySpells;
			set => throw new NotImplementedException();
		}
		public bool CantBeTargetedByHeroPowers => CantBeTargetedBySpells;
		public bool HasBattleCry => Card.Battlecry;

		public virtual bool IsImmune
		{
			get => default;
			set => throw new NotImplementedException();
		}
		public virtual bool IsFrozen
		{
			get => default;
			set => throw new NotImplementedException();
		}
		public virtual bool HasTaunt
		{
			get => Card.Taunt;
			set => throw new NotImplementedException();
		}
		public virtual bool HasWindfury
		{
			get => Card.Windfury;
			set => throw new NotImplementedException();
		}
		public virtual bool Poisonous
		{
			get => Card.Poisonous;
			set => throw new NotImplementedException();
		}
		public virtual bool HasStealth
		{
			get => Card.Stealth;
			set => throw new NotImplementedException();
		}
		public virtual int NumAttacksThisTurn
		{
			get => default;
			set => throw new NotImplementedException();
		}
		public virtual bool AutoAttack
		{
			get => Card[GameTag.AUTOATTACK] == 1;
			set => throw new NotImplementedException();
		}
		public bool ToBeDestroyed => _toBeDestroyed;

		public bool IsAttacking
		{
			get { return this[GameTag.ATTACKING] == 1; }
			set { this[GameTag.ATTACKING] = value ? 1 : 0; }
		}

		public bool IsDefending
		{
			get { return this[GameTag.DEFENDING] == 1; }
			set { this[GameTag.DEFENDING] = value ? 1 : 0; }
		}

//		public abstract ref bool this[BoolAttributes attr] { get; }

		internal override void ApplyEffect(AbstractEffect effect)
		{
			effect.ApplyTo(this);
		}
		internal void ApplyEffect(CharacterEffect effect)
		{
			effect.ApplyTo(this);
		}
		internal override void RemoveEffect(AbstractEffect effect)
		{
			effect.RemoveFrom(this);
		}
		internal void RemoveFrom(CharacterEffect effect)
		{
			effect.RemoveFrom(this);
		}

		internal abstract ref bool GetRef(int index);
		internal abstract ref int GetIntRef(int index);
		internal abstract bool GetAttribute(BoolAttributes attr);
		internal abstract void SetAttribute(BoolAttributes attr, bool value);
#pragma warning restore CS1591 // Fehledes XML-Kommentar für öffentlich sichtbaren Typ oder Element
	}
}
