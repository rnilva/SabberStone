using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Enchants
{
	interface IEffect<T> where T : Playable
	{
		void ApplyTo(T playable, bool isOneTurnEffect = false);
		void ApplyAuraTo(T playable);
		void RemoveFrom(T entity);
		void RemoveAuraFrom(T entity);
		IEffect<T> ChangeValue(int newValue);
	}

	internal readonly struct GenericEffect<T> : IEffect where T : IPlayable
	{
		//private readonly TAttr _attr;
		public readonly Attr<T> _attr;
		public readonly EffectOperator _operator;
		public readonly int _value;

		internal GenericEffect(Attr<T> attr, EffectOperator @operator, int value)
		{
			_attr = attr;
			_operator = @operator;
			_value = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ApplyTo(T entity)
		{
			_attr.Apply(entity, _operator, _value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ApplyTo(T entity, bool isOneTurnEffect)
		{
			if (isOneTurnEffect)
				entity.Game.OneTurnEffects.Add((entity.Id, this));

			_attr.Apply(entity, _operator, _value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ApplyAuraTo(T playable)
		{
			_attr.ApplyAura(playable, _operator, _value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RemoveFrom(T entity)
		{
			_attr.Remove(entity, _operator, _value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RemoveAuraFrom(T playable)
		{
			_attr.RemoveAura(playable, _operator, _value);
		}

		void IEffect.ApplyTo(IEntity entity, bool oneTurnEffect)
		{
			if (!(entity is T playable))
				throw new Exception($"Cannot apply {this} to an entity of type {entity.GetType()}");

			ApplyTo(playable, oneTurnEffect);
		}

		void IEffect.ApplyAuraTo(IPlayable playable)
		{
			if (!(playable is T p))
				throw new Exception($"Cannot apply AuraEffect {this} to an entity of type {playable.GetType()}");

			ApplyAuraTo(p);
		}

		void IEffect.RemoveFrom(IEntity entity)
		{
			if (!(entity is T playable))
				throw new Exception($"Cannot remove {this} from an entity of type {entity.GetType()}");

			RemoveFrom(playable);
		}

		void IEffect.RemoveAuraFrom(IPlayable playable)
		{
			if (!(playable is T p))
				throw new Exception($"Cannot remove AuraEffect {this} from an entity of type {playable.GetType()}");

			RemoveAuraFrom(p);
		}

		public IEffect ChangeValue(int newValue)
		{
			return new GenericEffect<T>(_attr, _operator, newValue);
		}

		public override string ToString()
		{
			return $"{_operator} {_attr} {_value}";
		}
	}

	internal abstract class Attr<T> where T : IPlayable
	{
		public abstract void Apply(T entity, EffectOperator @operator, int value);
		public abstract void ApplyAura(T entity, EffectOperator @operator, int value);
		public abstract void Remove(T entity, EffectOperator @operator, int value);
		public abstract void RemoveAura(T entity, EffectOperator @operator, int value);

		protected abstract ref int GetAuraRef(AuraEffects auraEffects);
	}

	//[StructLayout(LayoutKind.Explicit)]
	//internal readonly ref struct ValueWrapper
	//{
	//	[FieldOffset(0)]
	//	private readonly bool _value;
	//	[FieldOffset(0)]
	//	private readonly int _IntValue;

	//	public ValueWrapper(int intValue)
	//	{

	//	}

	//	public unsafe void GetValue(byte[] buffer)
	//	{
	//		IntPtr ptr = Marshal.AllocHGlobal(sizeof(int));
	//		Marshal.StructureToPtr(this, ptr, true);
	//		Marshal.Copy(ptr, buffer, 0, sizeof(int));
	//		Marshal.FreeHGlobal(ptr);
	//	}

	//	public static bool operator true(ValueWrapper value)
	//	{
	//		return value._value;
	//	}

	//	public static bool operator false(ValueWrapper value)
	//	{
	//		return !value._value;
	//	}

	//	public static implicit operator bool(ValueWrapper value)
	//	{
	//		return value._value;
	//	}
	//}

	//internal abstract class ValueAttr<T, TPlayable> : Attr<TPlayable> where TPlayable : Playable where T : unmanaged
	//{
	//	public static ValueAttr<ValueWrapper, Character> Test;

	//	public void ApplyValue(TPlayable playable, T value)
	//	{
	//		bool test = (bool)value;
	//	}

	//	public void Tests()
	//	{
			
	//	}
	//}

	internal abstract class IntAttr<TSelf, TPlayable> : Attr<TPlayable>
		where TPlayable : IPlayable
		where TSelf : IntAttr<TSelf, TPlayable>, new()
	{
		private static readonly TSelf _singleton = new TSelf();

		public static GenericEffect<TPlayable> Effect(EffectOperator @operator, int value)
		{
			return new GenericEffect<TPlayable>(_singleton, @operator, value);
		}

		protected abstract ref int? GetRef(TPlayable entity);

		protected abstract int GetCardValue(TPlayable entity);


		public override void Apply(TPlayable entity, EffectOperator @operator, int value)
		{
			ref int? target = ref GetRef(entity);

			if (@operator == EffectOperator.SET)
			{
				target = value;
				return;
			}

			int baseValue = target ?? GetCardValue(entity);

			switch (@operator)
			{
				case EffectOperator.ADD:
					target = baseValue + value;
					break;
				case EffectOperator.SUB:
					target = baseValue - value;
					break;
				case EffectOperator.MUL:
					target = baseValue * value;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
			}
		}

		public override void Remove(TPlayable entity, EffectOperator @operator, int value)
		{
			ref int? target = ref GetRef(entity);

			if (!target.HasValue)
				return;

			switch (@operator)
			{
				case EffectOperator.ADD:
					target -= value;
					break;
				case EffectOperator.SUB:
					target += value;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
			}
		}

		public override void ApplyAura(TPlayable entity, EffectOperator @operator, int value)
		{
			AuraEffects auraEffects = entity.AuraEffects;
			if (auraEffects == null)
			{
				auraEffects = new AuraEffects(entity.Card.Type);
				entity.AuraEffects = auraEffects;
			}

			ref int target = ref GetAuraRef(auraEffects);

			switch (@operator)
			{
				case EffectOperator.ADD:
					target += value;
					break;
				case EffectOperator.SUB:
					target -= value;
					break;
				case EffectOperator.MUL:
					target *= value;
					break;
				case EffectOperator.SET:
					GetRef(entity) = 0;
					target = value;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
			}
		}

		public override void RemoveAura(TPlayable entity, EffectOperator @operator, int value)
		{
			ref int target = ref GetAuraRef(entity.AuraEffects);

			switch (@operator)
			{
				case EffectOperator.ADD:
					target -= value;
					return;
				case EffectOperator.SUB:
					target += value;
					return;
				case EffectOperator.SET:
					target -= value;
					return;
				default:
					throw new NotImplementedException();
			}
		}
	}

	internal abstract class BoolAttr<TSelf, TPlayable> : Attr<TPlayable>
		where TPlayable : Playable
		where TSelf : BoolAttr<TSelf, TPlayable>, new()
	{
		private static readonly TSelf _singleton = new TSelf();

		public static GenericEffect<TPlayable> Effect(bool value = true)
		{
			return new GenericEffect<TPlayable>(_singleton, EffectOperator.SET, value ? 1 : 0);
		}

		protected abstract ref bool? GetRef(TPlayable entity);

		public override void Apply(TPlayable entity, EffectOperator @operator, int value)
		{
			ref bool? target = ref GetRef(entity);

			if (@operator != EffectOperator.SET)
				throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);

			target = value > 0;
		}

		public override void Remove(TPlayable entity, EffectOperator @operator, int value)
		{
			ref bool? target = ref GetRef(entity);

			target = false;
		}

		public override void ApplyAura(TPlayable entity, EffectOperator @operator, int value)
		{
			AuraEffects auraEffects = entity.AuraEffects;
			if (auraEffects == null)
			{
				auraEffects = new AuraEffects(entity.Card.Type);
				entity.AuraEffects = auraEffects;
			}

			GetAuraRef(auraEffects)++;
		}

		public override void RemoveAura(TPlayable entity, EffectOperator @operator, int value)
		{
			GetAuraRef(entity.AuraEffects)--;
		}
	}

	//internal abstract class SelfContainedIntAttr<TSelf, TTarget> : IntAttr<TTarget>
	//	where TSelf : SelfContainedIntAttr<TSelf, TTarget>, new() where TTarget : Playable
	//{
	//	private static readonly TSelf _singleton = new TSelf();

	//	public static GenericEffect<TSelf, TTarget> Effect(EffectOperator @operator, int value)
	//	{
	//		return new GenericEffect<TSelf, TTarget>(_singleton, @operator, value);
	//	}
	//}

	//internal abstract class SelfContainedBoolAttr<TSelf, TTarget> : BoolAttr<TTarget>
	//	where TSelf : SelfContainedBoolAttr<TSelf, TTarget>, new() where TTarget : Playable
	//{
	//	private static readonly TSelf _singleton = new TSelf();

	//	public static GenericEffect<TSelf, TTarget> Effect(bool value = true)
	//	{
	//		return new GenericEffect<TSelf, TTarget>(_singleton, EffectOperator.SET, value ? 1 : 0);
	//	}
	//}

	internal class Cost : IntAttr<Cost, Playable>
	{
		protected override ref int? GetRef(Playable entity)
		{
			return ref entity._modifiedCost;
		}

		protected override int GetCardValue(Playable entity)
		{
			return entity.Card.Cost;
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			throw new NotImplementedException();
		}

		public override void Apply(Playable entity, EffectOperator @operator, int value)
		{
			base.Apply(entity, @operator, value);

			entity._costManager?.AddCostEnchantment(@operator, value);
		}

		public override void ApplyAura(Playable entity, EffectOperator @operator, int value)
		{
			Playable.CostManager costManager = entity._costManager;
			if (costManager == null)
			{
				costManager = new Playable.CostManager();
				entity._costManager = costManager;
			}

			costManager.AddCostAura(@operator, value);
		}

		public override void RemoveAura(Playable entity, EffectOperator @operator, int value)
		{
			entity._costManager?.RemoveCostAura(@operator, value);
		}
	}

	internal class ATK : IntAttr<ATK, Character>
	{
		protected override ref int? GetRef(Character entity)
		{
			return ref entity._modifiedATK;
		}

		protected override int GetCardValue(Character entity)
		{
			return entity.Card.ATK;
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			return ref auraEffects._data[3];
		}

		public override void Apply(Character entity, EffectOperator @operator, int value)
		{
			if (@operator == EffectOperator.SET)
			{
				// TODO Fix OneTurnEffects & GenericEffect
				for (int i = entity.Game.OneTurnEffects.Count - 1; i >= 0; i--)
				{
					(int id, IEffect eff) = entity.Game.OneTurnEffects[i];
					if (id != entity.Id || !(eff is GenericEffect<Character>)) continue;
					entity.Game.OneTurnEffects.RemoveAt(i);
				}
			}


			base.Apply(entity, @operator, value);
		}

		//public override void ApplyAura(Playable entity, EffectOperator @operator, int value)
		//{
		//	if (entity is Weapon)
		//		entity = entity.Controller.Hero;

		//	base.ApplyAura(entity, @operator, value);
		//}

		//public override void RemoveAura(Playable entity, EffectOperator @operator, int value)
		//{
		//	if (entity is Weapon)
		//		entity = entity.Controller.Hero;

		//	base.RemoveAura(entity, @operator, value);
		//}
	}

	internal class WeaponATK : IntAttr<WeaponATK, Weapon>
	{
		#region Overrides of Attr<Weapon>

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Overrides of IntAttr<WeaponATK,Weapon>

		protected override ref int? GetRef(Weapon entity)
		{
			return ref entity._atk;
		}

		protected override int GetCardValue(Weapon entity)
		{
			return entity.Card.ATK;
		}

		#endregion
	}

	internal class Health : IntAttr<Health, Character>
	{
		protected override ref int? GetRef(Character entity)
		{
			return ref entity._modifiedHealth;
		}

		protected override int GetCardValue(Character entity)
		{
			return entity.Card.Health;
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			return ref auraEffects._data[4];
		}

		public override void Apply(Character entity, EffectOperator @operator, int value)
		{
			if (@operator == EffectOperator.SET)
			{
				if (entity is Hero h)
				{
					int hbh = h.BaseHealth;
					if (hbh > value)
						h.Damage = hbh - value;
					else
						h.Health = value;
					return;
				}

				if (entity is Minion m)
				{
					m.Health = value;
					return;
				}
			}

			base.Apply(entity, @operator, value);
		}

		public override void RemoveAura(Character entity, EffectOperator @operator, int value)
		{
			base.RemoveAura(entity, @operator, value);

			if (@operator == EffectOperator.ADD)
				entity.Damage -= value;
		}
	}

	internal class Stealth : BoolAttr<Stealth, Character>
	{
		protected override ref bool? GetRef(Character entity)
		{
			return ref entity._modifiedStealth;
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			throw new NotImplementedException();
		}
	}

	internal class Taunt : BoolAttr<Taunt, Minion>
	{
		protected override ref bool? GetRef(Minion entity)
		{
			return ref entity._modifiedTaunt;
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			return ref auraEffects._data[6];
		}
	}

	internal class CantBeTargetedBySpells : BoolAttr<CantBeTargetedBySpells, Character>
	{
		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			return ref auraEffects._data[2];
		}

		protected override ref bool? GetRef(Character entity)
		{
			return ref entity._modifiedCantBeTargetedBySpells;
		}
	}


	internal abstract class SurrogateAttr<TSelf> : Attr<PlayableSurrogate> where TSelf : SurrogateAttr<TSelf>, new()
	{
		private static readonly TSelf _singleton = new TSelf();

		public static GenericEffect<PlayableSurrogate> Effect(EffectOperator @operator, int value)
		{
			return new GenericEffect<PlayableSurrogate>(_singleton, @operator, value);
		}
	}

	internal class SurrogateATK : SurrogateAttr<SurrogateATK>
	{
		#region Overrides of Attr<PlayableSurrogate>

		public override void Apply(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			ref int val = ref entity._atk;

			switch (@operator)
			{
				case EffectOperator.ADD:
					val += value;
					break;
				case EffectOperator.SUB:
					val -= value;
					break;
				case EffectOperator.MUL:
					val *= value;
					break;
				case EffectOperator.SET:
					val = value;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
			}
		}

		public override void ApplyAura(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		public override void Remove(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		public override void RemoveAura(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			throw new NotImplementedException();
		}

		#endregion
	}

	internal class SurrogateHealth : SurrogateAttr<SurrogateHealth>
	{
		#region Overrides of Attr<PlayableSurrogate>

		public override void Apply(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			ref int val = ref entity._health;

			switch (@operator)
			{
				case EffectOperator.ADD:
					val += value;
					break;
				case EffectOperator.SUB:
					val -= value;
					break;
				case EffectOperator.MUL:
					val *= value;
					break;
				case EffectOperator.SET:
					val = value;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
			}
		}

		public override void ApplyAura(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		public override void Remove(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		public override void RemoveAura(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			throw new NotImplementedException();
		}

		#endregion
	}

	internal class SurrogateCost : SurrogateAttr<SurrogateCost>
	{
		#region Overrides of Attr<PlayableSurrogate>

		public override void Apply(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			ref int val = ref entity._cost;

			switch (@operator)
			{
				case EffectOperator.ADD:
					val += value;
					break;
				case EffectOperator.SUB:
					val -= value;
					break;
				case EffectOperator.MUL:
					val *= value;
					break;
				case EffectOperator.SET:
					val = value;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
			}
		}

		public override void ApplyAura(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		public override void Remove(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		public override void RemoveAura(PlayableSurrogate entity, EffectOperator @operator, int value)
		{
			throw new NotImplementedException();
		}

		protected override ref int GetAuraRef(AuraEffects auraEffects)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
