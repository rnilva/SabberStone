﻿using System;
using System.Collections.Generic;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Zones;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Model.Entities
{
	/// <summary>
	/// Entity which is a character that can reside in the <see cref="Controller.BoardZone"/> and perform
	/// certain actions (provided through <see cref="Character{Minion}"/>.
	/// </summary>
	/// <seealso cref="Character{Minion}" />
	public partial class Minion : Character
	{
		/// <summary>Initializes a new instance of the <see cref="Minion"/> class.</summary>
		/// <param name="controller">Owner of the character; not specifically limited to players.</param>
		/// <param name="card">The card which this character embodies.</param>
		/// <param name="tags">Properties of this entity.</param>
		/// <autogeneratedoc />
		public Minion(in Controller controller, in Card card, in IDictionary<GameTag, int> tags, in int id = -1)
			: base(in controller, in card, in tags, in id)
		{
			Game.Log(LogLevel.VERBOSE, BlockType.PLAY, "Minion", !Game.Logging? "":$"{this} ({Card.Class}) was created.");
		}

		/// <summary>
		/// A copy constructor.
		/// </summary>
		/// <param name="controller">The target <see cref="Controller"/> instance.</param>
		/// <param name="minion">The source <see cref="Minion"/>.</param>
		protected Minion(in Controller controller, in Character minion) : base(in controller, in minion) { }

		/// <summary>Character can attack.</summary>
		/// <autogeneratedoc />
		public override bool CanAttack => /*ChargeBuffed() &&*/ base.CanAttack && AttackDamage > 0;

		//private bool ChargeBuffed()
		//{
		//	if (NumAttacksThisTurn == 0 && HasCharge && IsExhausted)
		//	{
		//		IsExhausted = false;
		//	}
		//	return true;
		//}

		/// <summary>Disables all special effects on this minion.
		/// It's not possible to undo a silence!
		/// </summary>
		public void Silence()
		{
			// remove keywords
			HasTaunt = false;
			IsFrozen = false;
			IsEnraged = false;
			HasCharge = false;
			IsWindfury = false;
			HasDivineShield = false;
			HasStealth = false;
			IsDeathrattle = false;
			HasBattleCry = false;
			HasInspire = false;
			IsLifeSteal = false;
			CantBeTargetedByHeroPowers = false;
			CantBeTargetedBySpells = false;
			IsImmune = false;
			AttackableByRush = false;

			int sp = this[GameTag.SPELLPOWER];
			if (sp > 0)
			{
				Controller.CurrentSpellPower -= sp;
				this[GameTag.SPELLPOWER] = 0;
			}

			// remove enchantments, aura and trigger
			OngoingEffect?.Remove();
			Game.OneTurnEffects.RemoveAll(p => p.entityId == Id);
			ActivatedTrigger?.Remove();
			//Controller.BoardZone.Auras.ForEach(aura => aura.EntityRemoved(this));

			if (AppliedEnchantments != null)
				for (int i = AppliedEnchantments.Count - 1; i >= 0; i--)
				{
					if (AppliedEnchantments[i].Creator.Power?.Aura != null)
						continue;
					AppliedEnchantments[i].Remove();
				}

			// reset ATK and Health
			AttackDamage = Card.ATK;

			int cardBaseHealth = Card.Health;
			if (Health > cardBaseHealth)
				Health = cardBaseHealth;
			else
			{
				int delta = BaseHealth - cardBaseHealth;
				if (delta > 0)
					Damage -= delta;
				BaseHealth = cardBaseHealth;
			}

			if (_data.TryGetValue(GameTag.CONTROLLER_CHANGED_THIS_TURN, out int v) && v > 0)
			{
				Game.TaskQueue.Execute(new ControlTask(EntityType.SOURCE, true), Controller, this, null);
				this[GameTag.CONTROLLER_CHANGED_THIS_TURN] = 0;
			}

			if (_history && Card[GameTag.TRIGGER_VISUAL] == 1) this[GameTag.TRIGGER_VISUAL] = 0;

			IsSilenced = true;

			Game.Log(LogLevel.INFO, BlockType.PLAY, "Minion", !Game.Logging? "":$"{this} got silenced!");
		}

		public override void Reset()
		{
			base.Reset();
			_atkModifier = Card.ATK;
			_healthModifier = Card.Health;
			_dmgModifier = 0;
			_exhausted = false;
			_numAttackThisturn = 0;

			OngoingEffect?.Remove();
			Game.OneTurnEffects.RemoveAll(p => p.entityId == Id);
			if (ToBeDestroyed)
			{
				//Game.DeadMinions.Remove(OrderOfPlay);
				Game.DeadMinions.Remove(this);
				ToBeDestroyed = false;
			}
		}

		/// <summary>
		/// Gets the Minions adjacent to this Minion in order from left to right.
		/// </summary>
		/// <param name="includeUntouchables">true if the result should contain Untouchable entities.</param>
		public Minion[] GetAdjacentMinions(bool includeUntouchables = false)
		{
			int pos = ZonePosition;
			if (!(Zone is BoardZone zone))
				throw new MethodAccessException();

			if (includeUntouchables)
			{
				if (pos > 0)
				{
					if (pos < zone.Count - 1)
					{
						var arr = new Minion[2];
						arr[0] = zone[pos - 1];
						arr[1] = zone[pos + 1];
						return arr;
					}
					return new[] { zone[pos - 1] };
				}
				return pos < zone.Count - 1 ?
					new[] { zone[pos + 1] } :
					new Minion[0];
			}


			if (pos > 0)
			{
				Minion left;
				if (pos < zone.Count - 1)
				{
					left = zone[pos - 1];
					Minion right = zone[pos + 1];
					return left.Untouchable
						? (right.Untouchable ? new Minion[0] : new[] {right})
						: (right.Untouchable ? new[] {left} : new[] {left, right});
				}

				left = zone[pos - 1];
				return left.Untouchable ? new Minion[0] : new [] {left};
			}

			if (pos < zone.Count - 1)
			{
				Minion r = zone[pos + 1];
				return r.Untouchable ? new Minion[0] : new[] {r};
			}

			return new Minion[0];
		}

		/// <summary>
		/// Gets a value indicating whether this entity is playable by the player. Some entities require specific
		/// requirements before they can be played. This method will process the requirements and produce
		/// a result for the current state of the game.
		/// </summary>
		/// <value><c>true</c> if this entity is playable; otherwise, <c>false</c>.</value>
		public override bool IsPlayableByPlayer
		{
			get
			{
				// check if we got a slot on board for minions
				if (Controller.BoardZone.IsFull)
				{
					Game.Log(LogLevel.VERBOSE, BlockType.PLAY, "Playable",
						!Game.Logging? "":$"{this} isn't playable, because not enough place on board.");
					return false;
				}

				return base.IsPlayableByPlayer;
			}
		}

		public override IPlayable Clone(in Controller controller)
		{
			return new Minion(in controller, this);
		}
	}

	public partial class Minion
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public int SpellPower
		{
			get
			{
				if (!_data.TryGetValue(GameTag.SPELLPOWER, out int value))
					return Card.SpellPower;
				return value;
			}
			set
			{
				Controller.CurrentSpellPower += (value - SpellPower);
				this[GameTag.SPELLPOWER] = value;
			}
		}

		public bool HasCharge
		{
			//get => this[GameTag.CHARGE] >= 1;
			get
			{
				if (AuraEffects.Charge > 0)
					return true;
				if (!_data.TryGetValue(GameTag.CHARGE, out int value))
					return Card.Charge;
				return value > 0;
			}
			set
			{
				if (value)
				{
					if (IsExhausted && NumAttacksThisTurn == 0)
						IsExhausted = false;
					this[GameTag.CHARGE] = 1;
					return;
				}

				this[GameTag.CHARGE] = 0;
			}
		}

		public bool HasDivineShield
		{
			//get { return this[GameTag.DIVINE_SHIELD] == 1; }
			get
			{
				if (!_data.TryGetValue(GameTag.DIVINE_SHIELD, out int value))
					return Card.DivineShield;
				return value > 0;
			}
			set
			{
				if (!value)
				{
					if (this[GameTag.DIVINE_SHIELD] == 1)
						Game.TriggerManager.OnLoseDivineShield(this);
					this[GameTag.DIVINE_SHIELD] = 0;
					return;
				}

				this[GameTag.DIVINE_SHIELD] = 1;
			}
		}

		public override bool IsWindfury
		{
			//get { return this[GameTag.WINDFURY] >= 1; }
			get
			{
				if (!_data.TryGetValue(GameTag.WINDFURY, out int value))
					return Card.Windfury;
				return value > 0;
			}
			set { this[GameTag.WINDFURY] = value ? 1 : 0; }
		}

		public bool HasBattleCry
		{
			get { return Card[GameTag.BATTLECRY] != 0; }
			set { this[GameTag.BATTLECRY] = value ? 1 : 0; }
		}

		public override bool IsDeathrattle
		{
			//get { return this[GameTag.DEATHRATTLE] == 1; }
			get
			{
				if (!_data.TryGetValue(GameTag.DEATHRATTLE, out int value))
					return Card.Deathrattle;
				return value > 0;
			}
			set => this[GameTag.DEATHRATTLE] = value ? 1 : 0;
		}

		public bool HasInspire
		{
			get { return this[GameTag.INSPIRE] == 1; }
			set { this[GameTag.INSPIRE] = value ? 1 : 0; }
		}

		public bool IsEnraged
		{
			get { return this[GameTag.ENRAGED] == 1; }
			set { this[GameTag.ENRAGED] = value ? 1 : 0; }
		}

		public bool Freeze => Card.Freeze;

		public bool Poisonous
		{
			//get { return this[GameTag.POISONOUS] == 1; }
			get
			{
				if (!_data.TryGetValue(GameTag.POISONOUS, out int value))
					return Card.Poisonous;
				return value > 0;
			}
			set { this[GameTag.POISONOUS] = value ? 1 : 0; }
		}

		public override bool IsLifeSteal
		{
			get
			{
				if (AuraEffects.Lifesteal > 0)
					return true;
				if (!_data.TryGetValue(GameTag.LIFESTEAL, out int value))
					return Card.LifeSteal;
				return value > 0;
			}
			set => base.IsLifeSteal = value; }

		public bool Untouchable => Card.Untouchable;

		public bool IsRush
		{
			get
			{
				if (AuraEffects.Rush > 0)
					return true;

				if (!_data.TryGetValue(GameTag.RUSH, out int value))
					return Card.Rush;

				return value > 0;
			}
		}

		public bool AttackableByRush
		{
			get => _data.Contains(new KeyValuePair<GameTag, int>(GameTag.ATTACKABLE_BY_RUSH, 1));
			set => this[GameTag.ATTACKABLE_BY_RUSH] = value ? 1 : 0;
		} 

		public int LastBoardPosition
		{
			get
			{
				_data.TryGetValue(GameTag.TAG_LAST_KNOWN_POSITION_ON_BOARD, out int value);
				return value;
			}
			set { this[GameTag.TAG_LAST_KNOWN_POSITION_ON_BOARD] = value; }
		}

		public override bool ToBeDestroyed
		{
			get => base.ToBeDestroyed;

			set
			{
				if (value == base.ToBeDestroyed)
					return;
				base.ToBeDestroyed = value;
				if (value)
					Game.DeadMinions.Add(this);
			} 
		}
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
