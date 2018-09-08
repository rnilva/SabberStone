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
		public Weapon(Controller controller, Card card, IDictionary<GameTag, int> tags, int id = -1)
			: base(controller, card, tags, id)
		{
			Game.Log(LogLevel.INFO, BlockType.PLAY, "Weapon", !Game.Logging? "":$"{this} ({Card.Class}) was created.");
		}

		/// <summary>
		/// A copy constructor.
		/// </summary>
		/// <param name="controller">A target <see cref="Controller"/> instance.</param>
		/// <param name="weapon">A source <see cref="Weapon"/>.</param>
		private Weapon(Controller controller, Weapon weapon) : base(controller, weapon) { }

		public override IPlayable Clone(Controller controller)
		{
			return new Weapon(controller, this);
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

		public bool HasWindfury
		{
			get { return this[GameTag.WINDFURY] == 1; }
			set { this[GameTag.WINDFURY] = value ? 1 : 0; }
		}

		public bool IsImmune
		{
			get { return this[GameTag.IMMUNE] == 1; }
			set { this[GameTag.IMMUNE] = value ? 1 : 0; }
		}

		public bool Poisonous
		{
			get { return this[GameTag.POISONOUS] == 1; }
			set { this[GameTag.POISONOUS] = value ? 1 : 0; }
		}
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
