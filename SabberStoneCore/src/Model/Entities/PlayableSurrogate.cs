//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using SabberStoneCore.Auras;
//using SabberStoneCore.Enchants;
//using SabberStoneCore.Enums;
//using SabberStoneCore.Model.Zones;

//namespace SabberStoneCore.Model.Entities
//{
//	public class EntityOld
//	{
//		internal int _cost;
//		internal int _atk;
//		internal int _health;
//		private Card _card;
//		private int _id;
//		//private int _creator;

//		internal EntityOld(in Game game, in Card card, int id = -1)
//		{
//			if (id < 0)
//				id = game.NextId;
//			game.IdEntityDic[id] = this;
//			_id = id;
//			_card = card;
//			_cost = card.Cost;

//			if (card.Type == CardType.MINION)
//			{

//				_atk = card.ATK;
//				_health = card.Health;
//				IsMinion = true;
//			}
//			else if (card.Type == CardType.WEAPON)
//			{
//				_atk = card.ATK;
//				_health = card[GameTag.DURABILITY];
//			}
//		}

//		private EntityOld(Entity other)
//		{
//			_cost = other._cost;
//			_atk = other._atk;
//			_health = other._health;
//			_card = other._card;
//			_id = other._id;
//			_toBeDestroyed = other._toBeDestroyed;
//			IsMinion = other.IsMinion;
//		}

//		public int Id
//		{
//			get => _id;
//			set => _id = value;
//		}

//		public Card Card
//		{
//			get => _card;
//			set => _card = value;
//		}

//		public int Cost
//		{
//			get => _cost;
//			set => _cost = value;
//		}

//		public int AttackDamage
//		{
//			get => _atk;
//			set => _atk = value;
//		}

//		public int Health
//		{
//			get => _health;
//			set => _health = value;
//		}

//		public Power Power => Card.Power;

//		public bool IsMinion { get; private set; }

//		public bool HasTaunt => Card.Taunt;
//		public bool HasDivineShield => Card.DivineShield;
//		public bool HasLifeSteal => Card.LifeSteal;
//		public bool HasWindfury => Card.Windfury;

//		public Playable CastToPlayable(in Controller controller)
//		{
//			Playable entity = Entity.FromCard(in controller, in _card, id: in _id);
//			entity.Cost = _cost;
//			if (entity is Minion m)
//			{
//				m._modifiedATK = _atk;
//				m._modifiedHealth = _health;
//			}
//			else if (entity is Weapon w)
//			{
//				w.AttackDamage = _atk;
//				w.Durability = _health;
//			}

//			return entity;
//		}

//		internal void ApplyEffect<T>(GenericEffect<T> effect) where T : Playable
//		{
//			// TODO:
//			switch (effect._attr)
//			{
//				case ATK _:
//					switch (effect._operator)
//					{
//						case EffectOperator.ADD:
//							_atk += effect._value;
//							break;
//						case EffectOperator.SUB:
//							_atk -= effect._value;
//							break;
//						case EffectOperator.MUL:
//							_atk *= effect._value;
//							break;
//						case EffectOperator.SET:
//							_atk = effect._value;
//							break;
//						default:
//							throw new ArgumentOutOfRangeException();
//					}
//					break;
//				case Health _:
//					switch (effect._operator)
//					{
//						case EffectOperator.ADD:
//							_health += effect._value;
//							break;
//						case EffectOperator.SUB:
//							_health -= effect._value;
//							break;
//						case EffectOperator.MUL:
//							_health *= effect._value;
//							break;
//						case EffectOperator.SET:
//							_health = effect._value;
//							break;
//						default:
//							throw new ArgumentOutOfRangeException();
//					}
//					break;
//				case Cost _:
//					switch (effect._operator)
//					{
//						case EffectOperator.ADD:
//							_cost += effect._value;
//							break;
//						case EffectOperator.SUB:
//							_cost -= effect._value;
//							break;
//						case EffectOperator.MUL:
//							_cost *= effect._value;
//							break;
//						case EffectOperator.SET:
//							_cost = effect._value;
//							break;
//						default:
//							throw new ArgumentOutOfRangeException();
//					}
//					break;
//				default:
//					throw new ArgumentOutOfRangeException($"Can't apply effect {effect.GetType()} {effect} to Entity entity.");
//			}
//		}

//		public void ChangeEntity(Card newCard)
//		{
//			_card = newCard;
//			_cost = newCard.Cost;
//			_atk = newCard.ATK;
//			_health = newCard.Health;
//			ActivatedTrigger?.Remove();
//		}

//		public static implicit operator Entity(Playable p)
//		{
//			return new Entity(p.Game, p.Card, p.Id);
//		}

//		internal static Entity CastFromPlayable(Playable ip)
//		{
//			if (ip is Playable p)
//				return p;
//			else if
//				(ip is Entity ps)
//				return ps;

//			throw new InvalidCastException();
//		}

//		#region Implementation of IEnumerable

//		IEnumerator<KeyValuePair<GameTag, int>> IEnumerable<KeyValuePair<GameTag, int>>.GetEnumerator()
//		{
//			throw new NotImplementedException();
//		}

//		IEnumerator IEnumerable.GetEnumerator()
//		{
//			throw new NotImplementedException();
//		}

//		#endregion

//		#region Implementation of Entity
//		Game Entity.Game
//		{
//			get => throw new NotImplementedException();
//			set => throw new NotImplementedException();
//		}

//		public Controller Controller
//		{
//			get => Zone?.Controller;
//			set => throw new NotImplementedException();
//		}

//		public IZone Zone { get; set; }

//		public int this[GameTag t]
//		{
//			get
//			{
//				switch (t)
//				{
//					case GameTag.COST:
//						return _cost;
//					case GameTag.ATK:
//						return _atk;
//					case GameTag.HEALTH:
//						return _health;
//					default:
//						return Card[t];
//				}
//			}
//			set { return; }
//		}

//		void Entity.Reset()
//		{
//			throw new NotImplementedException();
//		}

//		string Entity.Hash(params GameTag[] ignore)
//		{
//			var sb = new StringBuilder();
//			sb.Append("[");
//			sb.Append(Card.Name);
//			sb.Append("{");
//			sb.Append(_cost);
//			sb.Append(_atk);
//			sb.Append(_health);
//			sb.Append("}");
//			sb.Append("]");
//			return sb.ToString();
//		}

//		AuraEffects Entity.AuraEffects
//		{
//			get => throw new NotImplementedException();
//			set => throw new NotImplementedException();
//		}

//		IDictionary<GameTag, int> Entity.NativeTags => throw new NotImplementedException();

//		List<Enchantment> Entity.AppliedEnchantments
//		{
//			get => null;
//			set
//			{
//				return;
//			}
//		}

//		#endregion

//		#region Implementation of Playable

//		bool Playable.IsPlayableByPlayer => throw new NotImplementedException();

//		bool Playable.IsPlayableByCardReq => throw new NotImplementedException();

//		bool Playable.Combo => throw new NotImplementedException();

//		void Playable.Destroy()
//		{
//			throw new NotImplementedException();
//		}

//		void Playable.ActivateTask(in PowerActivation activation, in Character target, in int chooseOne,
//			in Playable source)
//		{
//			throw new NotImplementedException();
//		}

//		int Playable.CardTarget
//		{
//			get => throw new NotImplementedException();
//			set => throw new NotImplementedException();
//		}

//		int Playable.ZonePosition
//		{
//			get => throw new NotImplementedException();
//			set => throw new NotImplementedException();
//		}

//		bool Playable.IsExhausted
//		{
//			get => throw new NotImplementedException();
//			set => throw new NotImplementedException();
//		}

//		int Playable.Overload => _card.Overload;

//		bool Playable.HasDeathrattle
//		{
//			get => _card.Deathrattle;
//			set => throw new NotImplementedException();
//		}

//		bool Playable.HasLifeSteal
//		{
//			get => _card.LifeSteal;
//			set => throw new NotImplementedException();
//		}

//		bool Playable.IsEcho => _card.Echo;

//		bool Playable.ChooseOne => _card.ChooseOne;

//		Playable[] Playable.ChooseOnePlayables
//		{
//			get => throw new NotImplementedException();
//			set => throw new NotImplementedException();
//		}


//		int Playable.OrderOfPlay
//		{
//			get => throw new NotImplementedException();
//			set => throw new NotImplementedException();
//		}

//		Playable Playable.Clone(in Controller controller)
//		{
//			var clone = new Entity(this);
//			controller.Game.IdEntityDic[clone.Id] = clone;
//			ActivatedTrigger?.Activate(controller.Game, clone, cloning: true);
//			return clone;
//		}

//		IAura Playable.OngoingEffect
//		{
//			get => null;
//			set => throw new NotImplementedException();
//		}

//		public Trigger ActivatedTrigger { get; set; }

//		IEnumerable<Character> Playable.ValidPlayTargets => throw new NotImplementedException();

//		bool Playable.IsValidPlayTarget(Character target)
//		{
//			throw new NotImplementedException();
//		}

//		bool Playable.HasAnyValidPlayTargets
//		{
//			get
//			{
//				bool friendlyMinions = false;
//				bool enemyMinions = false;
//				bool hero = false;
//				bool opHero = false;
//				switch (Card.TargetingType)
//				{
//					case TargetingType.None:
//						return false;
//					case TargetingType.FriendlyCharacters:
//						hero = true;
//						friendlyMinions = true;
//						break;
//					case TargetingType.Heroes:
//						hero = true;
//						opHero = true;
//						break;
//					case TargetingType.All:
//						hero = true;
//						opHero = true;
//						friendlyMinions = true;
//						enemyMinions = true;
//						break;
//					case TargetingType.FriendlyMinions:
//						friendlyMinions = true;
//						break;
//					case TargetingType.EnemyCharacters:
//						opHero = true;
//						enemyMinions = true;
//						break;
//					case TargetingType.EnemyMinions:
//						enemyMinions = true;
//						break;
//					case TargetingType.AllMinions:
//						friendlyMinions = true;
//						enemyMinions = true;
//						break;
//					default:
//						throw new ArgumentOutOfRangeException();
//				}

//				if (hero && TargetingRequirements(Controller.Hero)) return true;

//				if (opHero && TargetingRequirements(Controller.Opponent.Hero)) return true;

//				if (friendlyMinions)
//				{
//					var span = Controller.BoardZone.GetSpan();
//					for (int i = 0; i < span.Length; i++)
//						if (TargetingRequirements(span[i]))
//							return true;
//				}

//				if (enemyMinions)
//				{
//					var span = Controller.Opponent.BoardZone.GetSpan();
//					for (int i = 0; i < span.Length; i++)
//						if (TargetingRequirements(span[i]))
//							return true;
//				}

//				return false;
//			}
//		}

//		private bool TargetingRequirements(Character target)
//		{
//			if (target.Card.Untouchable)
//				return false;

//			if ((target.HasStealth || target.IsImmune) && target.Controller != Controller)
//				return false;

//			if (!Card.TargetingPredicate?.Invoke(target) ?? false)
//				return false;

//			return true;
//		}

//		#endregion

//		public override string ToString()
//		{
//			return $"'{Card.Name}[{Id}]'";
//		}
//	}
//}
