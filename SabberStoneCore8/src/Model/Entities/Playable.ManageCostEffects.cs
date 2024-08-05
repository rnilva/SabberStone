using System;
using System.Collections.Generic;
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;

namespace SabberStoneCore.Model.Entities
{
	public abstract partial class Playable
	{
		internal class CostManager
		{
			private readonly List<int> _setEffects = new List<int>(2);
			private int _cachedValue;
			private bool _toBeUpdated;
			private AdaptiveCostEffect _adaptiveCostEffect;

			public bool CardCostsHealth;

			public CostManager(int initValue)
			{
				_cachedValue = initValue;
				_toBeUpdated = true;
			}

			private CostManager(CostManager original)
			{
				_cachedValue = original._cachedValue;
				_toBeUpdated = original._toBeUpdated;
				_setEffects.AddRange(original._setEffects);
			}

			public void VaryCost(int value)
			{
				_cachedValue += value;
			}

			public void SetCost(int value)
			{
				_setEffects.Add(value);
				_cachedValue = value;
				if (_adaptiveCostEffect != null)
					_toBeUpdated = true;
			}

			public void RemoveSetEffect(int value)
			{
				_setEffects.Remove(value);
				_toBeUpdated = true;
			}

			public void ActivateAdaptiveEffect(AdaptiveCostEffect adaptiveCostEffect)
			{
				_adaptiveCostEffect = adaptiveCostEffect;
			}

			/// <summary>
			/// Tie in for <see cref="AdaptiveCostEffectObsolete"/> to calculate and reflect its result.
			/// </summary>
			public void UpdateAdaptiveEffect(int setValue = -1)
			{
				if (setValue >= 0)
					_cachedValue = setValue;
				else
					_toBeUpdated = true;
			}

			public void DeactivateAdaptiveEffect()
			{
				_adaptiveCostEffect = null;
			}

			public int GetCost(int? cost)
			{
				int result = _toBeUpdated ? GetCostInternal(cost.Value) : _cachedValue;

				return result > 0 ? result : 0;
			}

			internal void QueueUpdate()
			{
				_toBeUpdated = true;
			}

			private int GetCostInternal(int c)
			{
				bool flag = _adaptiveCostEffect?.IsSetEffect == true && _adaptiveCostEffect.Apply(ref c);

				if (!flag) 
				{
					if (_setEffects.Count > 0)
						c = _setEffects[_setEffects.Count - 1];

					_adaptiveCostEffect?.Apply(ref c);
				}

				_cachedValue = c;
				_toBeUpdated = false;

				return c;
			}

			public CostManager Clone()
			{
				return new CostManager(this);
			}
		}

		private CostManager _costManager;
		internal int? _modifiedCost;

		internal CostManager GetCostManager()
		{
			if (Zone?.Type != Enums.Zone.HAND) return null;

			return _costManager ?? (_costManager = new CostManager(_modifiedCost ?? (_modifiedCost = Card.Cost).Value));

			// TODO: Cost TagChange History
		}

		internal void VaryCost(int value)
		{
			ref int? cost = ref _modifiedCost;
			if (!cost.HasValue) cost = Card.Cost;

			cost += value;

			_costManager?.VaryCost(value);
		}

		internal void RemoveCostEffect(int value)
		{
			_modifiedCost -= value;
			//_costManager?.RemoveCostAura(EffectOperator.ADD, value);
			_costManager?.QueueUpdate();
		}

		internal void SetCost(int value)
		{
			if (Zone?.Type == Enums.Zone.HAND || Card.Type == CardType.HERO_POWER)
			{
				if (_costManager == null)
				{
					if (_modifiedCost == null)
						_modifiedCost = Card.Cost;
					_costManager = new CostManager(value);
				}

				_costManager.SetCost(value);
			}
			else
			{
				_modifiedCost = value;
			}
		}

		internal void RemoveSetCostEffect(int value)
		{
			_costManager?.RemoveSetEffect(value);
		}

		public int Cost
		{
			get =>
				_costManager?.GetCost(_modifiedCost) ??
					(_modifiedCost.HasValue
						? _modifiedCost < 0
							? 0
							: _modifiedCost.Value
						: (_modifiedCost = Card.Cost).Value);

			set
			{
				_modifiedCost = value;

				if (_history)
					Game.PowerHistory.Add(PowerHistoryBuilder.TagChange(Id, GameTag.COST, Cost));
			}
		}

		internal void ResetCost()
		{
			_costManager = null;
			_modifiedCost = null;
			if (OngoingEffect is AdaptiveCostEffect ace)
				ace.Remove();

			if (_history)
				Game.PowerHistory.Add(PowerHistoryBuilder.TagChange(Id, GameTag.COST, Card.Cost));
		}

		public bool CardCostsHealth => _costManager?.CardCostsHealth ?? false;
	}
}
