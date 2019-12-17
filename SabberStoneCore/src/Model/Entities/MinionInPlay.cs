using System;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Model.Entities
{
	public class MinionInPlay : Minion
	{
		public MinionInPlay(in Controller controller, in Card card, in EntityData tags, in int id = -1) : base(in controller, in card, in tags, in id)
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

		public static MinionInPlay FromCard(in Controller c, in Card card, in EntityData tags = null)
		{
			var entity = new MinionInPlay(in c, in card, tags ?? new EntityData());
			c.Game.IdEntityDic[entity.Id] = entity;
			// TODO: History
			if (card.ChooseOne) CreateChooseOnePlayables(in c, entity, in card, -1);
			return entity;
		}

		public static MinionInPlay FromMinion(ref Minion minion)
		{
			if (minion is MinionInPlay mp) return mp;

			var inPlay = new MinionInPlay(minion.Controller, minion.Card, minion._data, minion.Id)
			{
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

		#region Attribute Properties
		public override int AttackDamage
		{
			get
			{
				int value = _v1.Value;/* + (AuraEffects?.ATK ?? 0);*/
				return value < 0 ? 0 : value;
			}
			set => _v1 = value;
		}
		public override int BaseHealth
		{
			get => _v2.Value/* + (AuraEffects?.Health ?? 0)*/;
			set => _v2 = value;
		}
		public unsafe int SpellPower
		{
			get => _attrs.intAttrs[0];
			set => _attrs.intAttrs[0] = value;
		}
		public override unsafe int Damage
		{
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
			get => _attrs.intAttrs[2];
			set => _attrs.intAttrs[2] = value;
		}
		public unsafe int OrderOfPlay
		{
			get => _attrs.intAttrs[3];
			set => _attrs.intAttrs[3] = value;
		}
		public override unsafe bool IsImmune
		{
			get => _attrs.boolAttrs[0];
			set => _attrs.boolAttrs[0] = value;
		}
		public override unsafe bool IsFrozen
		{
			get => _attrs.boolAttrs[1];
			set
			{
				if (value)
					Game.TriggerManager.OnFreezeTrigger(this);
				_attrs.boolAttrs[1] = value;
			}
		}

		public override unsafe bool HasStealth
		{
			get => _attrs.boolAttrs[2];
			set => _attrs.boolAttrs[2] = value;
		}
		public override unsafe bool CantBeTargetedBySpells
		{
			get => /*(AuraEffects?.CantBeTargetedBySpells ?? false) ||*/
			       _attrs.boolAttrs[3];
			set => _attrs.boolAttrs[3] = value;
		}
		public override unsafe bool CantAttackHeroes
		{
			get => _attrs.boolAttrs[4];
			set => _attrs.boolAttrs[4] = value;
		}
		public override unsafe bool HasTaunt
		{
			get => /*(AuraEffects?.Taunt ?? false) ||*/
			       _attrs.boolAttrs[5];
			set => _attrs.boolAttrs[5] = value;
		}
		public override unsafe bool HasDivineShield
		{
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
			get => _attrs.boolAttrs[7];
			set => _attrs.boolAttrs[7] = value;
		}
		public override unsafe bool HasCharge
		{
			get => /*(AuraEffects?.Charge ?? 0) > 0 ||*/
			       _attrs.boolAttrs[8];
			set
			{
				if (value && IsExhausted && NumAttacksThisTurn == 0)
					IsExhausted = false;
				_attrs.boolAttrs[8] = value;
			}
		}
		public override unsafe bool Poisonous
		{
			get => _attrs.boolAttrs[9];
			set => _attrs.boolAttrs[9] = value;
		}
		public override unsafe bool HasLifeSteal
		{
			get => /*(AuraEffects?.Lifesteal ?? false) ||*/
			       _attrs.boolAttrs[10];
			set => _attrs.boolAttrs[10] = value;
		}
		public override unsafe bool IsRush
		{
			get => /*(AuraEffects?.Rush ?? false) ||*/
			       _attrs.boolAttrs[11];
			set => _attrs.boolAttrs[11] = value;
		}
		public override unsafe bool CantAttack
		{
			get => _attrs.boolAttrs[12];
			set => _attrs.boolAttrs[12] = value;
		}
		public override unsafe bool HasDeathrattle
		{
			get => _attrs.boolAttrs[13];
			set => _attrs.boolAttrs[13] = value;
		}
		public unsafe bool IsSilenced
		{
			get => _attrs.boolAttrs[14];
			set => _attrs.boolAttrs[14] = value;
		}
		public unsafe bool AttackableByRush
		{
			get => _attrs.boolAttrs[15];
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
			IsEnraged = false;
			HasCharge = false;
			HasWindfury = false;
			Poisonous = false;
			HasDivineShield = false;
			HasStealth = false;
			HasDeathrattle = false;
			HasBattleCry = false;
			HasInspire = false;
			HasLifeSteal = false;
			//CantBeTargetedByHeroPowers = false;
			CantBeTargetedBySpells = false;
			IsImmune = false;
			AttackableByRush = false;
			Poisonous = false;

			SpellPower = 0;

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
			return new MinionInPlay(in controller, this);
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
				return p => ((MinionInPlay) p)._attrs.intAttrs[2] += effect.Value;

			return p => ((MinionInPlay) p)._attrs.boolAttrs[TagToIndex(effect.Tag)] = true;
		}
		#endregion

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
				byte* ptr = (byte*) src;
				for (int i = 0; i < Attributes.NUM_BOOL_ATTRS; i++)
					slice[i] = ptr[i];
			}
		}

		public unsafe ref int this[IntAttributes attr] => ref _attrs.intAttrs[(int) attr];
		public unsafe ref bool this[BoolAttributes attr] => ref _attrs.boolAttrs[(int) attr];
	}
}
