using System.Linq;
using System.Text;
using SabberStoneCore.Actions;
using SabberStoneCore.Enchants;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Auras
{
	/// <summary>
	/// Implementation of the Enrage effect.
	/// </summary>
	public class EnrageEffect : Aura
	{
		private bool _enraged;
		private Character _target;
		private Enchantment _currentInstance;

		public EnrageEffect(AuraType type, params AbstractEffect[] effects) : base(type, effects)
		{
		}

		public EnrageEffect(AuraType type, string enchantmentId) : base(type, enchantmentId)
		{

		}

		private EnrageEffect(EnrageEffect prototype, Character owner) : base(prototype, owner)
		{
			_enraged = prototype._enraged;
			Restless = true;            //	can cause performance issue; should replace with heal trigger ?
			switch (Type)
			{
				case AuraType.SELF:
					_target = owner;
					break;
				case AuraType.WEAPON:
					_target = owner.Controller.Hero.Weapon;
					break;
			}
		}

		public override void Activate(Playable owner, bool cloning = false)
		{
			//if (owner is Enchantment e)
			//	owner = (Playable)e.Target;

			var instance = new EnrageEffect(this, (Character) owner);

			owner.Game.Auras.Add(instance);
			owner.OngoingEffect = instance;
		}

		public override bool Update()
		{
			var m = (MinionInPlay) Owner;

			// Remove this EnrageEffect from the target
			if (!On)
			{
				//Game.Auras.Remove(this);

				if (!_enraged) return false;

				// Spiteful Smith
				if (Type == AuraType.WEAPON)
				{
					Weapon weapon = m.Controller.Hero.Weapon;
					if (weapon == null)
						return false;

					if (_target != weapon)
						return false;
				}

				foreach (AbstractEffect eff in EnchantmentCard.Power.Enchant.Effects)
				{
					//eff.RemoveFrom(_target);
					_target.RemoveEffect(eff);
				}
				_currentInstance?.Remove();
				//if (_target != null)
				//	for (int i = 0; i < Effects.Length; i++)
				//		Effects[i].RemoveFrom(_target.AuraEffects);

				return false;
			}

			if (Type == AuraType.WEAPON)
			{
				Weapon weapon = m.Controller.Hero.Weapon;
				if (weapon == null)
					return true;

				if (_target != weapon)
				{
					_currentInstance?.Remove();
					_currentInstance = null;

					_target = weapon;
				}
			}

			if (!_enraged)
			{
				if (m.Damage == 0) return true;
				//if (_target != null)
				//	for (int i = 0; i < Effects.Length; i++)
				//		Effects[i].ApplyTo(_target.AuraEffects);
				Generic.AddEnchantmentBlock(Game, EnchantmentCard, m, _target, 0, 0, 0);
				if (Game.History)
					_currentInstance = _target.AppliedEnchantments.Last();
				_enraged = true;
			}
			else
			{
				if (m.Damage != 0) return true;

				foreach (AbstractEffect eff in EnchantmentCard.Power.Enchant.Effects)
					m.RemoveEffect(eff);

				_currentInstance?.Remove();
				_enraged = false;
			}

			return true;
		}

		public override void Clone(Playable clone)
		{
			Activate(clone, true);
		}

		public override string ToString()
		{
			var sb = new StringBuilder("[EE:");
			sb.Append(Owner.Card.Name);
			sb.Append("]");
			return sb.ToString();
		}
	}
}
