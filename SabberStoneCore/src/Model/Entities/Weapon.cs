﻿using SabberStoneCore.Enums;
using System.Collections.Generic;

namespace SabberStoneCore.Model.Entities
{
	/// <summary>
	/// Entity which can be attached to a <see cref="Hero"/>.
	/// A weapon is comparable to a buff, because it gives more/stronger abilities to the
	/// controller's hero for a limited use.
	/// </summary>
	/// <seealso cref="Playable{Weapon}" />
	public partial class Weapon : Playable
	{
		/// <summary>Initializes a new instance of the <see cref="Weapon"/> class.</summary>
		/// <param name="controller">The controller.</param>
		/// <param name="card">The card.</param>
		/// <param name="tags">The tags.</param>
		/// <autogeneratedoc />
		public Weapon(in Controller controller, in Card card, in IDictionary<GameTag, int> tags, in int id = -1)
			: base(in controller, in card, in tags, in id)
		{
			Game.Log(LogLevel.INFO, BlockType.PLAY, "Weapon", !Game.Logging? "":$"{this} ({Card.Class}) was created.");
		}

		/// <summary>
		/// A copy constructor.
		/// </summary>
		/// <param name="controller">A target <see cref="Controller"/> instance.</param>
		/// <param name="weapon">A source <see cref="Weapon"/>.</param>
		private Weapon(in Controller controller, in Playable weapon) : base(in controller, in weapon) { }

		public override IPlayable Clone(in Controller controller)
		{
			return new Weapon(in controller, this);
		}
	}

	public partial class Weapon
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public int AttackDamage
		{
			get { return this[GameTag.ATK]; }
			set { this[GameTag.ATK] = value; }
		}

		public int Damage
		{
			get => this[GameTag.DAMAGE];
			set
			{
				//Game.TriggerManager.OnDamageTrigger(this);
				this[GameTag.DAMAGE] = value;
				if (this[GameTag.DURABILITY] <= value)
				{
					ToBeDestroyed = true;
				}
			}
		}

		public int Durability
		{
			get { return this[GameTag.DURABILITY] - this[GameTag.DAMAGE]; }
			set { this[GameTag.DURABILITY] = value; }
		}

		public bool IsWindfury
		{
			get => Card.Windfury;
			set { this[GameTag.WINDFURY] = value ? 1 : 0; }
		}

		public bool IsImmune
		{
			get { return this[GameTag.IMMUNE] == 1; }
			set { this[GameTag.IMMUNE] = value ? 1 : 0; }
		}

		public bool Poisonous
		{
			get
			{
				if (!_data.ContainsKey(GameTag.POISONOUS))
					return Card.Poisonous;
				return true;
			}
			set { this[GameTag.POISONOUS] = value ? 1 : 0; }
		}

		public override bool ToBeDestroyed
		{
			get => base.ToBeDestroyed;
			set
			{
				Game.ClearWeapons += Controller.Hero.RemoveWeapon;
				base.ToBeDestroyed = value;
			}
		}

		public override bool IsLifeSteal
		{
			get
			{
				if (!_data.ContainsKey(GameTag.LIFESTEAL))
					return Card.LifeSteal;
				return true;
			}
			set => base.IsLifeSteal = value;
		}

		public override bool IsDeathrattle
		{
			get => Card.Deathrattle;
			set => this[GameTag.DEATHRATTLE] = value ? 1 : 0;
		}
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
