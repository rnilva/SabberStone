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
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;

namespace SabberStoneCore.Triggers
{
	public partial class Trigger
	{
		private static readonly Dictionary<TriggerType, Action<Game, TriggerStub>> ActivatorDict;
		private static readonly Dictionary<TriggerType, Action<Game, TriggerStub>> DeactivatorDict;

		internal static Action<Game, TriggerStub> GetActivator(TriggerType type)
		{
			return ActivatorDict.TryGetValue(type, out Action<Game, TriggerStub> value)
				? value
				: throw new NotImplementedException();
		}

		internal static Action<Game, TriggerStub> GetDeactivator(TriggerType type)
		{
			return DeactivatorDict.TryGetValue(type, out Action<Game, TriggerStub> value)
				? value
				: throw new NotImplementedException();
		}
		static Trigger()
		{
			ActivatorDict = new Dictionary<TriggerType, Action<Game, TriggerStub>>
			{
				{TriggerType.NONE, null},
				{TriggerType.MULTITRIGGER, null},
				{TriggerType.TURN_END, (g, t) => g.TriggerManager.AddEndTurnTrigger(t)},
				{TriggerType.TURN_START, (g, t) => g.TriggerManager.AddTurnStartTrigger(t)},
				{TriggerType.DEATH, (g, t) => g.TriggerManager.AddDeathTrigger(t)},
				{TriggerType.INSPIRE, (g, t) => g.TriggerManager.AddInspireTrigger(t)},
				{TriggerType.DEAL_DAMAGE, (g, t) => g.TriggerManager.AddDealDamageTrigger(t)},
				{TriggerType.TAKE_DAMAGE, (g, t) => g.TriggerManager.AddTakeDamageTrigger(t)},
				{TriggerType.PREDAMAGE, (g, t) => g.TriggerManager.AddPredamageTrigger(t)},
				{TriggerType.HEAL, (g, t) => g.TriggerManager.AddHealTrigger(t)},
				{TriggerType.LOSE_DIVINE_SHIELD, (g, t) => g.TriggerManager.AddLoseDivineShieldTrigger(t)},
				{TriggerType.ATTACK, (g, t) => g.TriggerManager.AddAttackTrigger(t)},
				{TriggerType.AFTER_ATTACK, (g, t) => g.TriggerManager.AddAfterAttackTrigger(t)},
				{TriggerType.SUMMON, (g, t) => g.TriggerManager.AddSummonTrigger(t)},
				{TriggerType.AFTER_SUMMON, (g, t) => g.TriggerManager.AddAfterSummonTrigger(t)},
				{TriggerType.PLAY_CARD, (g, t) => g.TriggerManager.AddPlayCardTrigger(t)},
				{TriggerType.AFTER_PLAY_CARD, (g, t) => g.TriggerManager.AddAfterPlayCardTrigger(t)},
				{TriggerType.PLAY_MINION, (g, t) => g.TriggerManager.AddPlayMinionTrigger(t)},
				{TriggerType.AFTER_PLAY_MINION, (g, t) => g.TriggerManager.AddAfterPlayMinionTrigger(t)},
				{TriggerType.CAST_SPELL, (g, t) => g.TriggerManager.AddCastSpellTrigger(t)},
				{TriggerType.AFTER_CAST, (g, t) => g.TriggerManager.AddAfterCastTrigger(t)},
				{TriggerType.SECRET_REVEALED, (g, t) => g.TriggerManager.AddSecretRevealedTrigger(t)},
				{TriggerType.ZONE, (g, t) => g.TriggerManager.AddZoneTrigger(t)},
				{TriggerType.DISCARD, (g, t) => g.TriggerManager.AddDiscardTrigger(t)},
				{TriggerType.GAME_START, (g, t) => g.TriggerManager.AddGameStartTrigger(t)},
				{TriggerType.DRAW, (g, t) => g.TriggerManager.AddDrawTrigger(t)},
				{TriggerType.TARGET, (g, t) => g.TriggerManager.AddTargetTrigger(t)},
				{TriggerType.FROZEN, (g, t) => g.TriggerManager.AddFrozenTrigger(t)},
				{TriggerType.ARMOR, (g, t) => g.TriggerManager.AddArmorTrigger(t)},
				{TriggerType.EQUIP_WEAPON, (g, t) => g.TriggerManager.AddEquipWeaponTrigger(t)},
				{TriggerType.SHUFFLE_INTO_DECK, (g, t) => g.TriggerManager.AddShuffleIntoDeckTrigger(t)},
				{TriggerType.OVERLOAD, (g, t) => g.TriggerManager.AddOverloadTrigger(t)},
			};
			ActivatorDict.Add(TriggerType.WORGEN_TRANSFORM, ActivatorDict[TriggerType.TURN_END]);

			DeactivatorDict = new Dictionary<TriggerType, Action<Game, TriggerStub>>
			{
				{TriggerType.NONE, null},
				{TriggerType.MULTITRIGGER, null},
				{TriggerType.TURN_END, (g, t) => g.TriggerManager.EndTurnTrigger.Remove(t)},
				{TriggerType.TURN_START, (g, t) => g.TriggerManager.TurnStartTrigger.Remove(t)},
				{TriggerType.DEATH, (g, t) => g.TriggerManager.DeathTrigger.Remove(t)},
				{TriggerType.INSPIRE, (g, t) => g.TriggerManager.InspireTrigger.Remove(t)},
				{TriggerType.DEAL_DAMAGE, (g, t) => g.TriggerManager.DealDamageTrigger.Remove(t)},
				{TriggerType.TAKE_DAMAGE, (g, t) => g.TriggerManager.TakeDamageTrigger.Remove(t)},
				{TriggerType.PREDAMAGE, (g, t) => g.TriggerManager.PredamageTrigger.Remove(t)},
				{TriggerType.HEAL, (g, t) => g.TriggerManager.HealTrigger.Remove(t)},
				{TriggerType.LOSE_DIVINE_SHIELD, (g, t) => g.TriggerManager.LoseDivineShieldTrigger.Remove(t)},
				{TriggerType.ATTACK, (g, t) => g.TriggerManager.AttackTrigger.Remove(t)},
				{TriggerType.AFTER_ATTACK, (g, t) => g.TriggerManager.AfterAttackTrigger.Remove(t)},
				{TriggerType.SUMMON, (g, t) => g.TriggerManager.SummonTrigger.Remove(t)},
				{TriggerType.AFTER_SUMMON, (g, t) => g.TriggerManager.AfterSummonTrigger.Remove(t)},
				{TriggerType.PLAY_CARD, (g, t) => g.TriggerManager.PlayCardTrigger.Remove(t)},
				{TriggerType.AFTER_PLAY_CARD, (g, t) => g.TriggerManager.AfterPlayCardTrigger.Remove(t)},
				{TriggerType.PLAY_MINION, (g, t) => g.TriggerManager.PlayMinionTrigger.Remove(t)},
				{TriggerType.AFTER_PLAY_MINION, (g, t) => g.TriggerManager.AfterPlayMinionTrigger.Remove(t)},
				{TriggerType.CAST_SPELL, (g, t) => g.TriggerManager.CastSpellTrigger.Remove(t)},
				{TriggerType.AFTER_CAST, (g, t) => g.TriggerManager.AfterCastTrigger.Remove(t)},
				{TriggerType.SECRET_REVEALED, (g, t) => g.TriggerManager.SecretRevealedTrigger.Remove(t)},
				{TriggerType.ZONE, (g, t) => g.TriggerManager.ZoneTrigger.Remove(t)},
				{TriggerType.DISCARD, (g, t) => g.TriggerManager.DiscardTrigger.Remove(t)},
				{TriggerType.GAME_START, (g, t) => g.TriggerManager.GameStartTrigger.Remove(t)},
				{TriggerType.DRAW, (g, t) => g.TriggerManager.DrawTrigger.Remove(t)},
				{TriggerType.TARGET, (g, t) => g.TriggerManager.TargetTrigger.Remove(t)},
				{TriggerType.FROZEN, (g, t) => g.TriggerManager.FrozenTrigger.Remove(t)},
				{TriggerType.ARMOR, (g, t) => g.TriggerManager.ArmorTrigger.Remove(t)},
				{TriggerType.EQUIP_WEAPON, (g, t) => g.TriggerManager.EquipWeaponTrigger.Remove(t)},
				{TriggerType.SHUFFLE_INTO_DECK, (g, t) => g.TriggerManager.ShuffleIntoDeckTrigger.Remove(t)},
				{TriggerType.OVERLOAD, (g, t) => g.TriggerManager.OverloadTrigger.Remove(t)},
			};

			DeactivatorDict.Add(TriggerType.WORGEN_TRANSFORM, DeactivatorDict[TriggerType.TURN_END]);
		}
	}
}
