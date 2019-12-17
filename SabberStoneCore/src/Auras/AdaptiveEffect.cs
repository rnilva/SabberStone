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
	/// <summary>
	/// Effects of this kind of Auras are influenced by other factors in game, in real time. e.g. Lightspawn, Southsea Deckhand.
	/// </summary>
	public class AdaptiveEffect : IAura
	{
		private readonly bool _isSwitching;
		private readonly Func<Playable, int> _valueFunction;
		private readonly SelfCondition _condition;
		private readonly Playable _owner;
		private readonly GameTag _tag;
		private readonly EffectOperator _operator;

		private bool _on = true;
		private int _lastValue;

		/// <summary>
		/// Defines an effect of a kind in which a tag varies with the value from a specified function.
		/// (e.g. Spirit Claws)
		/// </summary>
		public AdaptiveEffect(GameTag tag, EffectOperator @operator, Func<Playable, int> valueFunc)
		{
			_tag = tag;
			_operator = @operator;
			_valueFunction = valueFunc;
		}

		/// <summary>
		/// Defines an effect of a kind in which the value of a tag is boolean and determined by a specified condition.
		/// (e.g. Southsea Deckhand)
		/// </summary>
		public AdaptiveEffect(SelfCondition condition, GameTag tag)
		{
			_isSwitching = true;
			_tag = tag;
			_condition = condition;
			_operator = EffectOperator.SET;
		}

		private AdaptiveEffect(AdaptiveEffect prototype, Playable owner)
		{
			_isSwitching = prototype._isSwitching;
			_valueFunction = prototype._valueFunction;
			_tag = prototype._tag;
			_operator = prototype._operator;
			_condition = prototype._condition;
			_lastValue = prototype._lastValue;
			_on = prototype._on;

			_owner = owner;
		}

		Playable IAura.Owner => _owner;

		public void Activate(Playable owner)
		{
			IAura instance = new AdaptiveEffect(this, owner);

			owner.Game.Auras.Add(instance);
			owner.OngoingEffect = instance;
		}

		public bool Update()
		{
			if (_on)
			{
				int value;

				if (_isSwitching)
				{
					value = _condition.Eval(_owner) ? 1 : 0;

					if (value == _lastValue)
						return true;


					if (_tag == GameTag.ATK)
					{
						ATK.Effect(_operator, _lastValue).RemoveFrom(_owner);
						ATK.Effect(_operator, value).ApplyTo(_owner);
					}
					else
					{
						new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
						new Effect(_tag, _operator, value).ApplyTo(_owner);
					}
				}
				else
				{
					value = _valueFunction(_owner);

					if (_tag == GameTag.ATK)
					{
						Playable owner = _owner;

						if (_operator == EffectOperator.SET)
						{
							owner._v1 = value;

							List<(int entityId, IEffect effect)> oneTurnEffects = owner.Game.OneTurnEffects;
							for (int i = oneTurnEffects.Count - 1; i >= 0; --i)
							{
								(int id, IEffect eff) = oneTurnEffects[i];
								if (id == owner.Id && eff.Tag == GameTag.ATK)
									oneTurnEffects.RemoveAt(i);
							}
						}
						else
						{
							ATK.Effect(_operator, _lastValue).RemoveFrom(owner);
							ATK.Effect(_operator, value).ApplyTo(owner);
						}
					}
					else
					{
						new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
						new Effect(_tag, _operator, value).ApplyTo(_owner);
					}
				}

				_lastValue = value;
				return true;
			}
			else
			{
				if (_isSwitching)
				{
					if (_tag == GameTag.ATK)
						ATK.Effect(_operator, _lastValue).RemoveFrom(_owner);
					else
						new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
				}
				else
				{
					//if (_tag == GameTag.ATK)
					//	ATK.Effect(_operator, _lastValue).RemoveFrom(_owner);
					//else
					//	new Effect(_tag, _operator, _lastValue).RemoveFrom(_owner);
				}

				//_owner.Game.Auras.Remove(this);
				return false;
			}
		}

		public void Remove()
		{
			_owner.OngoingEffect = null;
			_on = false;
		}

		public void Clone(Playable clone)
		{
			Activate(clone);
		}

		public override string ToString()
		{
			var sb = new StringBuilder("[AE:");
			sb.Append(_owner.Card.Name);
			sb.Append("]");
			return sb.ToString();
		}
	}
}
