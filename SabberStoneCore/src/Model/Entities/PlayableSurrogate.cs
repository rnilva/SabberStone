using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Model.Entities
{
	public class PlayableSurrogate : IPlayable
	{
		private int _cost;
		private int _atk;
		private int _health;
		private Card _card;
		private int _id;
		private bool _toBeDestroyed;

		internal PlayableSurrogate(in Game game, in Card card, int id = -1)
		{
			if (id < 0)
				id = game.NextId;
			game.IdEntityDic[id] = this;
			_id = id;
			_card = card;
			_cost = card.Cost;

			if (card.Type == CardType.MINION)
			{

				_atk = card.ATK;
				_health = card.Health;
				IsMinion = true;
			}
			else if (card.Type == CardType.WEAPON)
			{
				_atk = card.ATK;
				_health = card[GameTag.DURABILITY];
			}
		}

		private PlayableSurrogate(in PlayableSurrogate other)
		{
			_cost = other._cost;
			_atk = other._atk;
			_health = other._health;
			_card = other._card;
			_id = other._id;
			_toBeDestroyed = other._toBeDestroyed;
			IsMinion = other.IsMinion;
		}

		public int Id
		{
			get => _id;
			set => _id = value;
		}

		public Card Card
		{
			get => _card;
			set => _card = value;
		}

		public int Cost
		{
			get => _cost;
			set => _cost = value;
		}

		public int AttackDamage
		{
			get => _atk;
			set => _atk = value;
		}

		public int Health
		{
			get => _health;
			set => _health = value;
		}

		public bool ToBeDestroyed
		{
			get => _toBeDestroyed;
			set => _toBeDestroyed = value;
		}

		public Power Power => Card.Power;

		public bool IsMinion { get; private set; }

		public bool HasTaunt => Card.Taunt;
		public bool HasDivineShield => Card.DivineShield;
		public bool HasLifeSteal => Card.LifeSteal;
		public bool HasWindfury => Card.Windfury;

		public IPlayable CastToPlayable(in Controller controller)
		{
			IPlayable entity = Entity.FromCard(in controller, in _card, id: in _id);
			entity.Cost = _cost;
			if (entity is Minion m)
			{
				m._modifiedATK = _atk;
				m._modifiedHealth = _health;
			}
			else if (entity is Weapon w)
			{
				w.AttackDamage = _atk;
				w.Durability = _health;
			}

			return entity;
		}

		internal void ApplyEffect(IEffect iEffect)
		{
			switch (iEffect)
			{
				case GenericEffect<ATK, Playable> atkEffect:
					switch (atkEffect._operator)
					{
						case EffectOperator.ADD:
							_atk += atkEffect._value;
							break;
						case EffectOperator.SUB:
							_atk -= atkEffect._value;
							break;
						case EffectOperator.MUL:
							_atk *= atkEffect._value;
							break;
						case EffectOperator.SET:
							_atk = atkEffect._value;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
					break;
				case GenericEffect<Health, Character> healthEffect:
					switch (healthEffect._operator)
					{
						case EffectOperator.ADD:
							_health += healthEffect._value;
							break;
						case EffectOperator.SUB:
							_health -= healthEffect._value;
							break;
						case EffectOperator.MUL:
							_health *= healthEffect._value;
							break;
						case EffectOperator.SET:
							_health = healthEffect._value;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
					break;
				case GenericEffect<Cost, Playable> costEffect:
					switch (costEffect._operator)
					{
						case EffectOperator.ADD:
							_cost += costEffect._value;
							break;
						case EffectOperator.SUB:
							_cost -= costEffect._value;
							break;
						case EffectOperator.MUL:
							_cost *= costEffect._value;
							break;
						case EffectOperator.SET:
							_cost = costEffect._value;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
					break;
				default:
					throw new ArgumentOutOfRangeException($"Can't apply effect {iEffect.GetType()} {iEffect} to PlayableSurrogate entity.");
			}
		}

		public void ChangeEntity(Card newCard)
		{
			_card = newCard;
			_cost = newCard.Cost;
			_atk = newCard.ATK;
			_health = newCard.Health;
			ActivatedTrigger?.Remove();
		}

		public static implicit operator PlayableSurrogate(Playable p)
		{
			return new PlayableSurrogate(p.Game, p.Card, p.Id);
		}

		internal static PlayableSurrogate CastFromPlayable(IPlayable ip)
		{
			if (ip is Playable p)
				return p;
			else if
				(ip is PlayableSurrogate ps)
				return ps;

			throw new InvalidCastException();
		}

		#region Implementation of IEnumerable

		IEnumerator<KeyValuePair<GameTag, int>> IEnumerable<KeyValuePair<GameTag, int>>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IEntity
		Game IEntity.Game
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public Controller Controller
		{
			get => Zone?.Controller;
			set => throw new NotImplementedException();
		}

		public IZone Zone { get; set; }

		public int this[GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.COST:
						return _cost;
					case GameTag.ATK:
						return _atk;
					case GameTag.HEALTH:
						return _health;
					default:
						return Card[t];
				}
			}
			set { return; }
		}

		void IEntity.Reset()
		{
			throw new NotImplementedException();
		}

		string IEntity.Hash(params GameTag[] ignore)
		{
			var sb = new StringBuilder();
			sb.Append("[");
			sb.Append(Card.Name);
			sb.Append("{");
			sb.Append(_cost);
			sb.Append(_atk);
			sb.Append(_health);
			sb.Append("}");
			sb.Append("]");
			return sb.ToString();
		}

		AuraEffects IEntity.AuraEffects
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		IDictionary<GameTag, int> IEntity.NativeTags => throw new NotImplementedException();

		List<Enchantment> IEntity.AppliedEnchantments
		{
			get => null;
			set
			{
				return;
			}
		}

		#endregion

		#region Implementation of IPlayable

		bool IPlayable.IsPlayableByPlayer => throw new NotImplementedException();

		bool IPlayable.IsPlayableByCardReq => throw new NotImplementedException();

		bool IPlayable.Combo => throw new NotImplementedException();

		void IPlayable.Destroy()
		{
			throw new NotImplementedException();
		}

		void IPlayable.ActivateTask(in PowerActivation activation, in ICharacter target, in int chooseOne,
			in IPlayable source)
		{
			throw new NotImplementedException();
		}

		int IPlayable.CardTarget
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		int IPlayable.ZonePosition
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		bool IPlayable.IsExhausted
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		int IPlayable.Overload => _card.Overload;

		bool IPlayable.HasDeathrattle
		{
			get => _card.Deathrattle;
			set => throw new NotImplementedException();
		}

		bool IPlayable.HasLifeSteal
		{
			get => _card.LifeSteal;
			set => throw new NotImplementedException();
		}

		bool IPlayable.IsEcho => _card.Echo;

		bool IPlayable.ChooseOne => _card.ChooseOne;

		IPlayable[] IPlayable.ChooseOnePlayables
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}


		int IPlayable.OrderOfPlay
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		IPlayable IPlayable.Clone(in Controller controller)
		{
			var clone = new PlayableSurrogate(this);
			controller.Game.IdEntityDic[clone.Id] = clone;
			return clone;
		}

		IAura IPlayable.OngoingEffect
		{
			get => null;
			set => throw new NotImplementedException();
		}

		public Trigger ActivatedTrigger { get; set; }

		IEnumerable<ICharacter> IPlayable.ValidPlayTargets => throw new NotImplementedException();

		bool IPlayable.IsValidPlayTarget(ICharacter target)
		{
			throw new NotImplementedException();
		}

		bool IPlayable.HasAnyValidPlayTargets
		{
			get
			{
				bool friendlyMinions = false;
				bool enemyMinions = false;
				bool hero = false;
				bool opHero = false;
				switch (Card.TargetingType)
				{
					case TargetingType.None:
						return false;
					case TargetingType.FriendlyCharacters:
						hero = true;
						friendlyMinions = true;
						break;
					case TargetingType.Heroes:
						hero = true;
						opHero = true;
						break;
					case TargetingType.All:
						hero = true;
						opHero = true;
						friendlyMinions = true;
						enemyMinions = true;
						break;
					case TargetingType.FriendlyMinions:
						friendlyMinions = true;
						break;
					case TargetingType.EnemyCharacters:
						opHero = true;
						enemyMinions = true;
						break;
					case TargetingType.EnemyMinions:
						enemyMinions = true;
						break;
					case TargetingType.AllMinions:
						friendlyMinions = true;
						enemyMinions = true;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				if (hero && TargetingRequirements(Controller.Hero)) return true;

				if (opHero && TargetingRequirements(Controller.Opponent.Hero)) return true;

				if (friendlyMinions)
				{
					ReadOnlySpan<Minion> span = Controller.BoardZone.GetSpan();
					for (int i = 0; i < span.Length; i++)
						if (TargetingRequirements(span[i]))
							return true;
				}

				if (enemyMinions)
				{
					ReadOnlySpan<Minion> span = Controller.Opponent.BoardZone.GetSpan();
					for (int i = 0; i < span.Length; i++)
						if (TargetingRequirements(span[i]))
							return true;
				}

				return false;
			}
		}

		private bool TargetingRequirements(ICharacter target)
		{
			if (target.Card.Untouchable)
				return false;

			if ((target.HasStealth || target.IsImmune) && target.Controller != Controller)
				return false;

			if (!Card.TargetingPredicate?.Invoke(target) ?? false)
				return false;

			return true;
		}

		#endregion

		public override string ToString()
		{
			return $"'{Card.Name}[{Id}]'";
		}
	}
}
