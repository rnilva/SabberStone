#region copyright
// SabberStone, Hearthstone Simulator in C# .NET Core
// Copyright (C) 2017-2019 SabberStone Team, darkfriend77 & rnilva
//
// SabberStone is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License.
// SabberStone is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
#endregion
using System;
using System.Linq;
using SabberStoneCore.Conditions;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Triggers;

namespace SabberStoneCore.Auras
{
	public class SwitchingAura : Aura
	{
		private readonly SelfCondition _initialisationCondtion;
		private readonly TriggerType _offTrigger;
		//private readonly TriggerManager.TriggerHandler _offHandler;
		//private readonly TriggerManager.TriggerHandler _onHandler;

		private readonly SwitchingAuraTriggerStub _offHandler;
		private readonly SwitchingAuraTriggerStub _onHandler;

		private bool _removed;

		public SwitchingAura(AuraType type, SelfCondition initCondition, TriggerType offTrigger, params AbstractEffect[] effects) : base(type, effects)
		{
			_initialisationCondtion = initCondition;
			_offTrigger = offTrigger;
		}

		public SwitchingAura(AuraType type, SelfCondition initCondition, TriggerType offTrigger, string enchantmentId) : base(type, enchantmentId)
		{
			_initialisationCondtion = initCondition;
			_offTrigger = offTrigger;
		}

		protected SwitchingAura(SwitchingAura prototype, Playable owner) : base(prototype, owner)
		{
			_initialisationCondtion = prototype._initialisationCondtion;
			_offTrigger = prototype._offTrigger;
			_offHandler = new SwitchingAuraTriggerStub(this, false);
			_onHandler = new SwitchingAuraTriggerStub(this, true);
		}

		public override void Activate(Playable owner, bool cloning = false)
		{
			if (Effects == null)
				Effects = EnchantmentCard.Power.Enchant.Effects;

			var instance = new SwitchingAura(this, owner);

			AddToGame(owner, instance);

			owner.Game.TriggerManager.TurnStartTrigger.Add(instance._onHandler);
			owner.Game.TriggerManager.EndTurnTrigger.Add(instance._offHandler);

			switch (_offTrigger)
			{
				case TriggerType.PLAY_MINION:
					owner.Game.TriggerManager.PlayMinionTrigger.Add(instance._offHandler);
					break;
				case TriggerType.CAST_SPELL:
					owner.Game.TriggerManager.CastSpellTrigger.Add(instance._offHandler);
					break;
				default:
					throw new NotImplementedException();
			}

			if (!cloning)
			{
				if (!instance._initialisationCondtion.Eval(owner))
					instance.On = false;
				else
					instance.AuraUpdateInstructionsQueue.Enqueue(new AuraUpdateInstruction(Instruction.AddAll), 1);
			}
		}

		public override void Remove()
		{
			base.Remove();

			_removed = true;

			//Game.TriggerManager.TurnStartTrigger.Remove(_onHandler);
			//Game.TriggerManager.EndTurnTrigger.Remove(_offHandler);

			//switch (_offTrigger)
			//{
			//	case TriggerType.PLAY_MINION:
			//		Game.TriggerManager.PlayMinionTrigger.Remove(_offHandler);
			//		break;
			//	case TriggerType.CAST_SPELL:
			//		Game.TriggerManager.CastSpellTrigger.Remove(_offHandler);
			//		break;
			//	default:
			//		throw new NotImplementedException();
			//}
		}

		//protected override void UpdateInternal()
		//{
		//	if (!On) return;

		//	base.UpdateInternal();
		//}

		protected override bool RemoveInternal()
		{
			AppliedEntityIdCollection.ForEach(Game.IdEntityDic, Effects,
				(id, idDict, effs) =>
				{
					Playable entity = idDict[id];
					for (int i = 0; i < effs.Length; i++)
						//effs[i].RemoveFrom(entity);
						entity.RemoveEffect(effs[i]);
				});

			AppliedEntityIdCollection.Clear();

			// TODO: EnchantmentCard, if there is a case

			if (Game.Logging)
				Game.Log(LogLevel.DEBUG, BlockType.TRIGGER, "Aura.RemoveInternal",
					$"{Owner}'s aura is removed from " +
					$"{string.Join(",", AppliedEntityIdCollection.Select(i => Game.IdEntityDic[i]))})");

			return !_removed;
		}

		private void TurnOff(Entity source)
		{
			if (!On) return;
			On = false;
			if (source.Game.Logging)
				source.Game.Log(LogLevel.DEBUG, BlockType.TRIGGER, "SwitchingAura.TurnOff",
				$"{source} triggers {_offTrigger}. {Owner}'s aura is now turned off for this turn.");

			AuraUpdateInstructionsQueue.Enqueue(new AuraUpdateInstruction(Instruction.RemoveAll), 0);
		}

		private void TurnOn(Entity source)
		{
			if (On) return;

			On = true;
			AuraUpdateInstructionsQueue.Enqueue(new AuraUpdateInstruction(Instruction.AddAll), 1);
		}

		private class SwitchingAuraTriggerStub : TriggerStub
		{
			private readonly SwitchingAura _aura;
			private readonly bool _type;

			public SwitchingAuraTriggerStub(SwitchingAura aura, bool type)
			{
				_aura = aura;
				_type = type;
			}

			#region Overrides of TriggerStub

			public override bool Process(Entity source)
			{
				if (_aura._removed)
					return false;

				if (_type)
					_aura.TurnOn(source);
				else
					_aura.TurnOff(source);
				return true;
			}

			public override void Remove(Game game)
			{
				throw new NotImplementedException();
			}

			public override void Validate(Entity source)
			{
				
			}

			public override void Invalidate()
			{
				
			}

			public override TriggerStub Clone(Playable owner)
			{
				throw new NotImplementedException();
			}

			public override TriggerStub Combine(Trigger trigger)
			{
				throw new NotImplementedException();
			}

			#endregion
		}
	}
}
