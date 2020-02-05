using System;
using System.Runtime.CompilerServices;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Tasks;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Model.Entities
{
	public class MinionInPlay : Minion
	{
		public MinionInPlay(in Controller controller, in Card card, in int id = -1) : base(in controller, in card, in id)
		{
			_v1 = card.ATK;
			_v2 = card.Health;
			_attrs = new Attributes(in card);
		}

		private MinionInPlay(in Controller controller, in MinionInPlay minion) : base(in controller, minion)
		{
			_v1 = minion._v1;
			_v2 = minion._v2;
			_attrs = minion._attrs;
		}

		public static MinionInPlay FromCard(in Controller c, in Card card)
		{
			var entity = new MinionInPlay(in c, in card);
			c.Game.IdEntityDic[entity.Id] = entity;
			// TODO: History
			if (card.ChooseOne) CreateChooseOnePlayables(in c, entity, in card, -1);
			return entity;
		}

		public static MinionInPlay FromMinion(ref Minion minion)
		{
			if (minion is MinionInPlay mp) return mp;

			var inPlay = new MinionInPlay(minion.Controller, minion.Card, minion.Id)
			{
				_data = minion._data,
				_v1 = minion._v1 ?? minion.Card.ATK,
				_v2 = minion._v2 ?? minion.Card.Health,
				ChooseOnePlayables = minion.ChooseOnePlayables,
				AppliedEnchantments = minion.AppliedEnchantments
			};
			inPlay.AppliedEnchantments?.ForEach(e => e.Target = inPlay);
			minion.Game.IdEntityDic[minion.Id] = inPlay;
			minion = inPlay;
			return inPlay;
		}

		public override int TakeDamage(Playable source, int damage)
		{
			Game game = Game;
			bool logging = game.Logging;

			// Check immunity
			if (IsImmune)
			{
				if (logging)
					game.Log(LogLevel.INFO, BlockType.ACTION, "Character", $"{this} is immune.");
				return 0;
			}

			// Check divine shield
			if (HasDivineShield)
			{
				if (logging)
					game.Log(LogLevel.INFO, BlockType.ACTION, "MinionInPlay",
						$"{this} divine shield absorbed incoming damage.");
				HasDivineShield = false;
				return 0;
			}

			// Create Damage event meta data
			EventMetaData temp = game.CurrentEventData;
			game.CurrentEventData = new EventMetaData(source, this, damage);

			// Check predamage triggers
			if (game.TriggerManager.OnPredamageTrigger(this))
			{
				damage = game.CurrentEventData.EventNumber;
				if (damage == 0)
				{
					game.CurrentEventData = temp;
					return 0;
				}
			}

			Damage += damage;
			if (logging)
				game.Log(LogLevel.INFO, BlockType.ACTION, "Character",
					$"{this} took damage for {damage}.");

			// Check damage triggers (DealDamage / TakeDamage / Overkill)
			game.TriggerManager.OnDamageTriggers(source, this);

			// Check lifesteal
			if (source.HasLifesteal && !_lifestealChecker)
			{
				if (game.History)
					game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, source.Id, source.Card.Id, -1, 0)); // TriggerKeyword=LIFESTEAL
				if (game.Logging)
					game.Log(LogLevel.VERBOSE, BlockType.ATTACK, "TakeDamage", !_logging ? "" : $"lifesteal source {source} has damaged target for {damage}.");

				source.Controller.Hero.TakeHeal(source, damage);

				if (game.History)
					game.PowerHistory.Add(new PowerHistoryBlockEnd());

				if (source.Controller.Hero.ToBeDestroyed && source.Controller.Hero.Health > 0)
				{
					source.Controller.Hero.ToBeDestroyed = false;
					game.ResolveDeadHeroes -= source.Controller.Hero.DisposeHero;
				}
			}

			if (source.Card.Type == CardType.HERO_POWER)
				source.Controller.NumHeroPowerDamageThisGame += damage;

			game.CurrentEventData = temp;

			return damage;
		}

		public override int this[GameTag t]
		{
			get
			{
				switch (t)
				{
					case GameTag.SPELLPOWER:
						return SpellPower;
					case GameTag.DIVINE_SHIELD:
						return HasDivineShield ? 1 : 0;
					case GameTag.POISONOUS:
						return Poisonous ? 1 : 0;
					case GameTag.CHARGE:
						return HasCharge ? 1 : 0;
					case GameTag.RUSH:
						return IsRush ? 1 : 0;
					case GameTag.CANT_ATTACK:
						return CantAttack ? 1 : 0;
					case GameTag.FROZEN:
						return IsFrozen ? 1 : 0;
					case GameTag.ATTACKABLE_BY_RUSH:
						return AttackableByRush ? 1 : 0;
					case GameTag.CANNOT_ATTACK_HEROES:
						return CantAttackHeroes ? 1 : 0;
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
					case GameTag.DIVINE_SHIELD:
						HasDivineShield = value > 0;
						return;
					case GameTag.POISONOUS:
						Poisonous = value > 0;
						return;
					case GameTag.CHARGE:
						HasCharge = value > 0;
						return;
					case GameTag.RUSH:
						IsRush = value > 0;
						return;
					case GameTag.CANT_ATTACK:
						CantAttack = value > 0;
						return;
					case GameTag.FROZEN:
						IsFrozen = value > 0;
						return;
					case GameTag.ATTACKABLE_BY_RUSH:
						AttackableByRush = value > 0;
						return;
					case GameTag.CANNOT_ATTACK_HEROES:
						CantAttackHeroes = value > 0;
						return;
					default:
						base[t] = value;
						return;
				}
			}
		}

		public override bool CanAttack(bool checkTargets = true)
		{
			//if (HasCharge || IsRush)
			//{
			//	if (HasWindfury)
			//	{
			//		if (NumAttacksThisTurn == 2)
			//			return false;
			//	}
			//	else if (NumAttacksThisTurn != 0)
			//		return false;
			//}
			//else if (IsExhausted)
			//	return false;

			//return AttackDamage > 0 &&
			//       !IsFrozen &&
			//       !CantAttack &&
			//       !Untouchable &&
			//       (!checkTargets || HasAnyValidAttackTargets());
			unsafe
			{
				fixed (bool* attrs = _attrs.boolAttrs)
				{
					if (attrs[8] || attrs[11])
					{
						if (attrs[7])
						{
							if (NumAttacksThisTurn == 2)
								return false;
						}
						else if (NumAttacksThisTurn != 0)
							return false;
					}
					else if (_exhausted)
						return false;

					return _v1 > 0 &&
						   !attrs[1] &&
						   !attrs[12] &&
						   !Untouchable &&
						   (!checkTargets || HasAnyValidAttackTargets());

				}
			}
		}

		#region Attribute Properties
		public override int AttackDamage
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				int value = _v1.Value;
				return value < 0 ? 0 : value;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _v1 = value;
		}
		public override int BaseHealth
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _v2.Value;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _v2 = value;
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
		public unsafe int OrderOfPlay
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.intAttrs[3];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.intAttrs[3] = value;
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
			set
			{
				if (value)
					Game.TriggerManager.OnFreezeTrigger(this);
				_attrs.boolAttrs[1] = value;
			}
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
		public override unsafe bool HasTaunt
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[5];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[5] = value;
		}
		public override unsafe bool HasDivineShield
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[6];
			set
			{
				bool oldValue = HasDivineShield;
				_attrs.boolAttrs[6] = value;
				if (oldValue && !value)
					Game.TriggerManager.OnLoseDivineShield(this);
			}
		}
		public override unsafe bool HasWindfury
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[7];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[7] = value;
		}
		public override unsafe bool HasCharge
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[8];
			set
			{
				if (value)
				{
					if (IsExhausted && NumAttacksThisTurn == 0)
						IsExhausted = false;
				}
				else
				{
					//					if (HasCharge && !IsExhausted && )
				}
				_attrs.boolAttrs[8] = value;
			}
		}
		public override unsafe bool Poisonous
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[9];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[9] = value;
		}
		public override unsafe bool HasLifesteal
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[10];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[10] = value;
		}
		public override unsafe bool IsRush
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[11];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[11] = value;
		}
		public override unsafe bool CantAttack
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[12];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[12] = value;
		}
		public override unsafe bool HasDeathrattle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[13];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[13] = value;
		}
		public unsafe bool IsSilenced
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[14];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[14] = value;
		}
		public unsafe bool AttackableByRush
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.boolAttrs[15];
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.boolAttrs[15] = value;
		}
		#endregion

		/// <summary>Disables all special effects on this minion.
		/// It's not possible to undo a silence!
		/// </summary>
		public void Silence()
		{
			// remove keywords
			HasTaunt = false;
			IsFrozen = false;
			//IsEnraged = false;
			HasCharge = false;
			HasWindfury = false;
			Poisonous = false;
			HasDivineShield = false;
			HasStealth = false;
			HasDeathrattle = false;
			//HasBattleCry = false;
			//HasInspire = false;
			HasLifesteal = false;
			//CantBeTargetedByHeroPowers = false;
			CantBeTargetedBySpells = false;
			IsImmune = false;
			AttackableByRush = false;
			Poisonous = false;

			SpellPower = 0;

			// remove enchantments, aura and trigger
			OngoingEffect?.Remove();
			Game.OneTurnEffects.RemoveAll(p => p.entityId == Id);
			ActivatedTrigger?.Remove(Game);
			//Controller.BoardZone.Auras.ForEach(aura => aura.EntityRemoved(this));

			if (AppliedEnchantments != null)
				for (int i = AppliedEnchantments.Count - 1; i >= 0; i--)
				{
					if (AppliedEnchantments[i].Creator.Power?.Aura != null)
						continue;
					AppliedEnchantments[i].Remove();
					AppliedEnchantments.RemoveAt(i);
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

			//if (_data.TryGetValue(GameTag.CONTROLLER_CHANGED_THIS_TURN, out int v) && v > 0)
			//{
			//	Game.TaskQueue.Execute(new ControlTask(EntityType.SOURCE, true), Controller, this, null);
			//	this[GameTag.CONTROLLER_CHANGED_THIS_TURN] = 0;
			//}

			if (_history && Card[GameTag.TRIGGER_VISUAL] == 1) this[GameTag.TRIGGER_VISUAL] = 0;

			IsSilenced = true;

			Game.Log(LogLevel.INFO, BlockType.PLAY, "Minion", !Game.Logging ? "" : $"{this} got silenced!");

			// Send aura update instruction
			Controller.BoardZone.Auras.ForEach(a =>
			{
				if (a.Deregister(this))
					a.EntityAdded(this);
			});
		}

		public override void Destroy()
		{
			if (_toBeDestroyed) return;
			_toBeDestroyed = true;
			Game.DeadMinions.Add(this);
		}

		public override void Reset()
		{
			base.Reset();
			if (AppliedEnchantments != null)
			{
				for (int i = AppliedEnchantments.Count - 1; i >= 0; i--)
					AppliedEnchantments[i].Remove();
				AppliedEnchantments.Clear();
			}

			_v1 = Card.ATK;
			_v2 = Card.Health;
			_attrs = new Attributes(Card);
			OngoingEffect?.Remove();
			Game.OneTurnEffects.RemoveAll(p => p.entityId == Id);
			if (ToBeDestroyed)
			{
				//Game.DeadMinions.Remove(OrderOfPlay);
				Game.DeadMinions.Remove(this);
				_toBeDestroyed = false;
			}
		}

		public override Playable Clone(in Controller controller)
		{
			return Zone?.Type != Enums.Zone.PLAY
				? new Minion(in controller, this)
				: new MinionInPlay(in controller, this);
		}

		internal override void ApplyEffect(AbstractEffect effect)
		{
			effect.ApplyTo(this);
		}
		internal void ApplyEffect(MinionInPlayEffect effect)
		{
			effect.ApplyTo(this);
		}
		internal override void RemoveEffect(AbstractEffect effect)
		{
			effect.RemoveFrom(this);
		}
		internal void RemoveEffect(MinionInPlayEffect effect)
		{
			effect.RemoveFrom(this);
		}

		public Minion CloneAsMinion(in Controller controller)
		{
			return new Minion(in controller, this);
		}

		#region Attribute Implementation
		private Attributes _attrs;

		private unsafe struct Attributes
		{
			// 0 : SpellPower
			// 1 : Damage
			// 2 : NumAttacksThisTurn
			// 3 : OrderOfPlay

			// 0 : IsImmune
			// 1 : Frozen

			// 2 : Stealth
			// 3 : CantBeTargetedBySpells
			// 4 : CannotAttackHeroes
			// 5 : Taunt
			// 6 : DivineShield
			// 7 : Windfury
			// 8 : Charge
			// 9 : Poisonous
			// 10 : Lifesteal
			// 11 : Rush
			// 12 : CantAttack
			// 13 : Deathrattle

			// 14 : Silenced
			// 15 : AttackableByRush

			public const int NUM_INT_ATTRS = 4;
			public const int NUM_BOOL_ATTRS = 16;
			private const int CARD_ATTR_OFFSET = 2;
#pragma warning disable 649
			public fixed int intAttrs[NUM_INT_ATTRS];
			public fixed bool boolAttrs[NUM_BOOL_ATTRS];
#pragma warning restore 649

			public Attributes(in Card card)
			{
				fixed (int* ints = intAttrs)
				fixed (bool* bools = boolAttrs)
					card.CopyMinionAttributes(ints, bools + CARD_ATTR_OFFSET);
			}
		}

		// ReSharper disable once UnusedMember.Local
		private unsafe int[] _attrsDebuggerView
		{
			get
			{
				// ReSharper disable once SuggestVarOrType_Elsewhere
				var array = new int[Attributes.NUM_INT_ATTRS + Attributes.NUM_BOOL_ATTRS];
				for (int i = 0; i < Attributes.NUM_INT_ATTRS; i++)
					array[i] = _attrs.intAttrs[i];
				for (int j = Attributes.NUM_INT_ATTRS, i = 0; i < Attributes.NUM_BOOL_ATTRS; i++, j++)
					array[j] = _attrs.boolAttrs[i] ? 1 : 0;

				return array;
			}
		}

		private static int TagToIndex(GameTag tag)
		{
			switch (tag)
			{
				case GameTag.SPELLPOWER:
					return 0;
				case GameTag.IMMUNE:
					return 0;
				case GameTag.STEALTH:
					return 2;
				case GameTag.CANT_BE_TARGETED_BY_SPELLS:
					return 3;
				case GameTag.TAUNT:
					return 4;
				case GameTag.DIVINE_SHIELD:
					return 5;
				case GameTag.WINDFURY:
					return 6;
				case GameTag.CHARGE:
					return 7;
				case GameTag.POISONOUS:
					return 8;
				case GameTag.LIFESTEAL:
					return 9;
				case GameTag.RUSH:
					return 10;
				case GameTag.CANT_ATTACK:
					return 11;
				case GameTag.CANNOT_ATTACK_HEROES:
					return 15;
				default:
					throw new NotImplementedException($"There is no matching attribute for GameTag {tag}");
			}
		}

		internal override unsafe ref bool GetRef(int index)
		{
			return ref _attrs.boolAttrs[index];
		}

		internal override unsafe ref int GetIntRef(int index)
		{
			return ref _attrs.intAttrs[index];
		}

		internal static unsafe ApplyingEffect GetFunction(Effect effect)
		{
			if (effect.Tag == GameTag.SPELLPOWER)
				return p => ((MinionInPlay)p)._attrs.intAttrs[2] += effect.Value;

			return p => ((MinionInPlay)p)._attrs.boolAttrs[TagToIndex(effect.Tag)] = true;
		}
		#endregion

		internal override bool GetAttribute(BoolAttributes attr)
		{
			unsafe
			{
				return _attrs.boolAttrs[(int)attr];
			}
		}
		internal override void SetAttribute(BoolAttributes attr, bool value)
		{
			unsafe
			{
				_attrs.boolAttrs[(int)attr] = value;
			}
		}

		internal void CopyAttributesFrom(MinionInPlay other)
		{
			_v1 = other._v1;
			_v2 = other._v2;
			_attrs = other._attrs;
		}

		public const int NUM_TOTAL_ATTRIBUTES = Attributes.NUM_INT_ATTRS + Attributes.NUM_BOOL_ATTRS;
		public const int NUM_BOOL_ATTRIBUTES = Attributes.NUM_BOOL_ATTRS;

		public unsafe void ExportAttributes(Span<float> destination)
		{
			if (destination.Length < NUM_TOTAL_ATTRIBUTES)
				throw new Exception();

			for (int i = 0; i < Attributes.NUM_INT_ATTRS; i++)
				destination[i] = _attrs.intAttrs[i];

			Span<float> slice = destination.Slice(Attributes.NUM_INT_ATTRS);
			fixed (bool* src = _attrs.boolAttrs)
			{
				byte* ptr = (byte*)src;
				for (int i = 0; i < Attributes.NUM_BOOL_ATTRS; i++)
					slice[i] = ptr[i];
			}
		}

		public unsafe ref int this[IntAttributes attr] => ref _attrs.intAttrs[(int)attr];
		public unsafe ref bool this[BoolAttributes attr] => ref _attrs.boolAttrs[(int)attr];
	}
}
