using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Conditions;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;

// ReSharper disable InconsistentNaming

namespace SabberStoneCore.Auras
{
//	/// <summary>
//	/// Effects of this kind of Auras are influenced by other factors in game, in real time. e.g. Lightspawn, Southsea Deckhand.
//	/// </summary>
//	public class AdaptiveEffect : IAura
//	{
//		private readonly bool _isSwitching;
//		private readonly Func<Playable, int> _valueFunction;
//		private readonly SelfCondition _condition;
//		private readonly Playable _owner;
//		//private readonly GameTag _tag;
//		//private readonly EffectOperator _operator;
//
//		private bool _on = true;
//		private int _lastValue;
//
//		/// <summary>
//		/// Defines an effect of a kind in which a tag varies with the value from a specified function.
//		/// (e.g. Spirit Claws)
//		/// </summary>
//		private AdaptiveEffect(EffectOperator @operator, Func<Character, int> valueFunc)
//		{
//			
//		}
//
//		private AdaptiveEffect(AbstractEffect effect)
//		{
//
//		}
//
//		//public static AdaptiveEffect AdaptiveEffect(EffectOperator @operator, )
//
//		public static AdaptiveEffect AdaptiveATKEffect(EffectOperator @operator, Func<Character, int> valueFunc)
//		{
//			return new AdaptiveEffect()
//		}
//
//		/// <summary>
//		/// Defines an effect of a kind in which the value of a tag is boolean and determined by a specified condition.
//		/// (e.g. Southsea Deckhand)
//		/// </summary>
//		public AdaptiveEffect(SelfCondition condition, GameTag tag)
//		{
//			_isSwitching = true;
//			_tag = tag;
//			_condition = condition;
//			_operator = EffectOperator.SET;
//		}
//
//		private AdaptiveEffect(AdaptiveEffect prototype, Playable owner)
//		{
//			_isSwitching = prototype._isSwitching;
//			_valueFunction = prototype._valueFunction;
//			_tag = prototype._tag;
//			_operator = prototype._operator;
//			_condition = prototype._condition;
//			_lastValue = prototype._lastValue;
//			_on = prototype._on;
//
//			_owner = owner;
//		}
//
//		Playable IAura.Owner => _owner;
//
//		public void Activate(Playable owner)
//		{
//			IAura instance = new AdaptiveEffect(this, owner);
//
//			owner.Game.Auras.Add(instance);
//			owner.OngoingEffect = instance;
//		}
//
//		public bool Update()
//		{
//			if (_on)
//			{
//				int value;
//
//				if (_isSwitching)
//				{
//					value = _condition.Eval(_owner) ? 1 : 0;
//
//					if (value == _lastValue)
//						return true;
//
//
//					if (_tag == GameTag.ATK)
//					{
//						ATK.Effect(_operator, _lastValue).RemoveFrom(_owner);
//						ATK.Effect(_operator, value).ApplyTo(_owner);
//					}
//					else
//					{
//						new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
//						new Effect(_tag, _operator, value).ApplyTo(_owner);
//					}
//				}
//				else
//				{
//					value = _valueFunction(_owner);
//
//					if (_tag == GameTag.ATK)
//					{
//						Playable owner = _owner;
//
//						if (_operator == EffectOperator.SET)
//						{
//							owner._v1 = value;
//
//							List<(int entityId, IEffect effect)> oneTurnEffects = owner.Game.OneTurnEffects;
//							for (int i = oneTurnEffects.Count - 1; i >= 0; --i)
//							{
//								(int id, IEffect eff) = oneTurnEffects[i];
//								if (id == owner.Id && eff.Tag == GameTag.ATK)
//									oneTurnEffects.RemoveAt(i);
//							}
//						}
//						else
//						{
//							ATK.Effect(_operator, _lastValue).RemoveFrom(owner);
//							ATK.Effect(_operator, value).ApplyTo(owner);
//						}
//					}
//					else
//					{
//						new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
//						new Effect(_tag, _operator, value).ApplyTo(_owner);
//					}
//				}
//
//				_lastValue = value;
//				return true;
//			}
//			else
//			{
//				if (_isSwitching)
//				{
//					if (_tag == GameTag.ATK)
//						ATK.Effect(_operator, _lastValue).RemoveFrom(_owner);
//					else
//						new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
//				}
//				else
//				{
//					//if (_tag == GameTag.ATK)
//					//	ATK.Effect(_operator, _lastValue).RemoveFrom(_owner);
//					//else
//					//	new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
//				}
//
//				//_owner.Game.Auras.Remove(this);
//				return false;
//			}
//		}
//
//		public void Remove()
//		{
//			_owner.OngoingEffect = null;
//			_on = false;
//		}
//
//		public void Clone(Playable clone)
//		{
//			Activate(clone);
//		}
//
//		public override string ToString()
//		{
//			var sb = new StringBuilder("[AE:");
//			sb.Append(_owner.Card.Name);
//			sb.Append("]");
//			return sb.ToString();
//		}
//	}


	public class AdaptiveATKEffect<T> : IAura where T : Character
	{
		private readonly EffectOperator _operator;
		private readonly Func<T, int> _valueFunction;
		private T _owner;
		private int _lastValue;
		private bool _on;

		public AdaptiveATKEffect(EffectOperator @operator, Func<T, int> valueFunc)
		{
			_operator = @operator;
			_valueFunction = valueFunc;
		}

		private AdaptiveATKEffect(AdaptiveATKEffect<T> prototype, T owner, bool cloning)
		{
			_operator = prototype._operator;
			_valueFunction = prototype._valueFunction;
			_owner = owner;
			if (cloning)
			{
				_lastValue = prototype._lastValue;
				_on = prototype._on;
			}
			else
			{
				_on = true;
			}
		}

		public Playable Owner => _owner;

		public bool Update()
		{
			if (!_on)
			{
				_owner.AttackDamage -= _lastValue;
				return false;
			}

			T owner = _owner;
			int value = _valueFunction(owner);

			if (_operator == EffectOperator.SET)
			{
				owner.AttackDamage = value;

				List<(int entityId, AbstractEffect effect)> oneTurnEffects = owner.Game.OneTurnEffects;
				for (int i = oneTurnEffects.Count - 1; i >= 0; --i)
				{
					(int id, AbstractEffect eff) = oneTurnEffects[i];
					if (id == owner.Id && eff.Tag == GameTag.ATK)
						oneTurnEffects.RemoveAt(i);
				}
				return true;
			}

			if (_lastValue == value) return true;

			if (_operator == EffectOperator.SUB)
				value -= value;

			owner.AttackDamage += (value - _lastValue);
			_lastValue = value;
			return true;
		}

		public void Remove()
		{
			if (_owner.OngoingEffect == this)
				_owner.OngoingEffect = null;
			_on = false;
		}

		void IAura.Activate(Playable owner)
		{
			Activate((T) owner, false);
		}

		public void Activate(T owner, bool cloning)
		{
			IAura instance = new AdaptiveATKEffect<T>(this, owner, cloning);

			owner.Game.Auras.Add(instance);
			owner.OngoingEffect = instance;
		}

		public void Clone(Playable clone)
		{
			Activate((T) clone, true);
		}
	}

	public class AdaptiveBoolAttributeEffect<T> : IAura where T : Character
	{
		private readonly int _attr;
		private readonly SelfCondition _condition;
		private readonly T _owner;
		private bool? _lastValue;
		private bool _on = true;

		public Playable Owner => _owner;

		public AdaptiveBoolAttributeEffect(BoolAttributes attr, SelfCondition condition)
		{
			_attr = (int) attr;
			_condition = condition;
		}

		private AdaptiveBoolAttributeEffect(AdaptiveBoolAttributeEffect<T> prototype, T owner)
		{
			_attr = prototype._attr;
			_condition = prototype._condition;
			_owner = owner;
			_on = prototype._on;
		}

		public bool Update()
		{
			if (!_on)
			{
				if (_lastValue.HasValue)
					_owner.GetRef(_attr) = !_lastValue.Value;
				return false;
			}

			bool value = _condition.Eval(_owner);

			if (value == _lastValue)
				return true;

			_owner.GetRef(_attr) = value;
			_lastValue = value;
			return true;
		}

		public void Remove()
		{
			if (_owner.OngoingEffect == this)
				_owner.OngoingEffect = null;
			_on = false;
		}

		public void Activate(T owner)
		{
			IAura instance = new AdaptiveBoolAttributeEffect<T>(this, owner);
			owner.OngoingEffect = instance;
			owner.Game.Auras.Add(instance);
		}

		void IAura.Activate(Playable owner)
		{
			Activate((T) owner);
		}


		public void Clone(Playable clone)
		{
			Activate((T) clone);
		}
	}
}
