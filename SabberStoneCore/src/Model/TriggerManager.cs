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
using System.Diagnostics;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Triggers;

// ReSharper disable PossibleNullReferenceException

namespace SabberStoneCore.Model
{
    public class TriggerManager
    {
		[DebuggerTypeProxy(typeof(DebuggerView))]
		[DebuggerDisplay("Count = {_position}")]
	    public class TriggerHandler
	    {
		    //private static readonly TriggerStub[] EmptyArray = new TriggerStub[0];
		    private const int InitSize = 4;

		    private TriggerStub[] _triggers;
			private int _position;
			private bool _invoking;

			internal TriggerHandler()
			{
				//_triggers = EmptyArray;
				_triggers = new TriggerStub[InitSize];
			}

			public bool IsEmpty => _position == 0;

			public void Add(TriggerStub trigger)
			{
				if (_position == _triggers.Length) Resize();
				_triggers[_position++] = trigger;
			}

			public void Remove(TriggerStub trigger)
			{
				if (_invoking)
					return;

				for (int i = 0; i < _position; ++i)
					if (_triggers[i].Equals(trigger))
					{
						Array.Copy(_triggers, i + 1, _triggers, i, --_position - i);
						break;
					}
			}

			public void Invoke(Entity entity)
			{
				_invoking = true;
				int pos = _position;
				for (int i = 0; i < pos; ++i)
				{
					if (!_triggers[i].Process(entity))
					{
						Array.Copy(_triggers, i + 1,  _triggers, i, --_position - i--);
						--pos;
					}
				}

				_invoking = false;
			}

			public void ValidateAll(Entity entity)
			{
				for (int i = 0; i < _position; ++i)
					_triggers[i].Validate(entity);
			}

			public void InvalidateAll()
			{
				for (int i = 0; i < _position; ++i)
					_triggers[i].Invalidate();
			}

			private void Resize()
			{
				//if (_triggers.Length == 0)
				//{
				//	// Lazy initialisation.
				//	_triggers = new TriggerStub[InitSize];
				//	return;
				//}

				var newArr = new TriggerStub[_triggers.Length << 1];
				Array.Copy(_triggers, 0, newArr, 0, _triggers.Length);
				_triggers = newArr;
			}

			public static TriggerHandler operator +(TriggerHandler handler, TriggerStub trigger)
			{
				handler.Add(trigger);
				return handler;
			}

			public static TriggerHandler operator -(TriggerHandler handler, TriggerStub trigger)
			{
				handler.Remove(trigger);
				return handler;
			}

			private class DebuggerView
			{
				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				private TriggerHandler _handler;
				public DebuggerView(TriggerHandler handler)
				{
					_handler = handler;
				}

				[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
				public Span<TriggerStub> Triggers => _handler._triggers.AsSpan(0, _handler._position);
			}
		}

	    internal TriggerManager(Game g)
	    {
		    StartEvent += g.TaskQueue.StartEvent;
			EndEvent += g.TaskQueue.EndEvent;
			DeathProcessingAndAuraUpdate += g.DeathProcessingAndAuraUpdate;
			ProcessTasks += g.ProcessTasks;
	    }

	    private event Action StartEvent;
	    private event Action EndEvent;
	    private event Action DeathProcessingAndAuraUpdate;
	    private event Action ProcessTasks;

	    #region Handlers

		public TriggerHandler PredamageTrigger;
		public TriggerHandler TakeDamageTrigger;
		public TriggerHandler AfterAttackTrigger;
		public TriggerHandler DealDamageTrigger;
	    public TriggerHandler DamageTrigger;
	    public TriggerHandler HealTrigger;
	    public TriggerHandler LoseDivineShieldTrigger;

	    public TriggerHandler EndTurnTrigger;
	    public TriggerHandler TurnStartTrigger;

	    public TriggerHandler SummonTrigger;
	    public TriggerHandler AfterSummonTrigger;

	    public TriggerHandler AttackTrigger;

	    public TriggerHandler DeathTrigger;

	    public TriggerHandler PlayCardTrigger;
	    public TriggerHandler AfterPlayCardTrigger;

		public TriggerHandler PlayMinionTrigger;
	    public TriggerHandler AfterPlayMinionTrigger;

	    public TriggerHandler CastSpellTrigger;
	    public TriggerHandler AfterCastTrigger;

	    public TriggerHandler SecretRevealedTrigger;

	    public TriggerHandler ZoneTrigger;

	    public TriggerHandler DiscardTrigger;

	    public TriggerHandler GameStartTrigger;

	    public TriggerHandler DrawTrigger;

	    public TriggerHandler TargetTrigger;

	    public TriggerHandler InspireTrigger;

	    public TriggerHandler FrozenTrigger;

	    public TriggerHandler ArmorTrigger;

	    public TriggerHandler EquipWeaponTrigger;

	    public TriggerHandler ShuffleIntoDeckTrigger;

	    public TriggerHandler OverloadTrigger;

		#endregion

		public bool HasTargetTrigger => TargetTrigger != null;
		public bool HasOnSummonTrigger => SummonTrigger != null;
		public bool HasShuffleIntoDeckTrigger => ShuffleIntoDeckTrigger != null;

		public void ValidateTriggers(Entity source, SequenceType type)
		{
			switch (type)
			{
				case SequenceType.PlayCard:
					PlayCardTrigger?.ValidateAll(source);
					AfterPlayCardTrigger?.ValidateAll(source);
					break;
				case SequenceType.PlayMinion:
					PlayMinionTrigger?.ValidateAll(source);
					AfterPlayMinionTrigger?.ValidateAll(source);
					break;
				case SequenceType.PlaySpell:
					CastSpellTrigger?.ValidateAll(source);
					AfterCastTrigger?.ValidateAll(source);
					break;
				case SequenceType.Target:
					TargetTrigger?.ValidateAll(source);
					break;
			}
		}

		public void InvalidateTriggers()
		{
			PlayCardTrigger?.InvalidateAll();
			AfterPlayCardTrigger?.InvalidateAll();
			CastSpellTrigger?.InvalidateAll();
			AfterCastTrigger?.InvalidateAll();
			TargetTrigger?.InvalidateAll();
		}

		#region Event Raisers

		internal void OnDamageTriggers(Playable source, Character target)
		{
			
		}

		internal bool OnDealDamageTrigger(Entity sender)
	    {
	        if (DealDamageTrigger?.IsEmpty ?? true) return false;
	        //StartEvent();
	        DealDamageTrigger.Invoke(sender);
	        return true;
	    }
	    internal bool OnDamageTrigger(Entity sender)
	    {
	        if (DamageTrigger?.IsEmpty ?? true) return false;
	        //StartEvent();
	        DamageTrigger.Invoke(sender);
	        return true;
	    }
	    internal void OnHealTrigger(Entity sender)
	    {
	        if (HealTrigger?.IsEmpty ?? true) return;
	        StartEvent();
	        HealTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	    }
	    internal void OnLoseDivineShield(Entity sender)
	    {
		    LoseDivineShieldTrigger?.Invoke(sender);
	    }
	    internal void OnEndTurnTrigger(Entity sender)
	    {
	        if (EndTurnTrigger?.IsEmpty ?? true) return;
	        StartEvent();
	        EndTurnTrigger.Invoke(sender);
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	    }
	    internal bool OnTurnStartTrigger(Entity sender)
	    {
	        if (TurnStartTrigger?.IsEmpty ?? true) return false;
	        TurnStartTrigger.Invoke(sender);
	        ProcessTasks();
	        return true;
	    }
	    internal void OnSummonTrigger(Entity sender, bool srs = false)
	    {
	        if (SummonTrigger?.IsEmpty ?? true) return;
	        if (!srs) StartEvent();
	        SummonTrigger.Invoke(sender);
	        ProcessTasks();
	        if (!srs) EndEvent();
	    }
	    internal void OnAfterSummonTrigger(Entity sender)
	    {
		    if (AfterSummonTrigger?.IsEmpty ?? true)
			    return;
		    StartEvent();
		    AfterSummonTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
	    }
	    internal void OnAttackTrigger(Entity sender)
	    {
	        if (AttackTrigger?.IsEmpty ?? true) return;
	        StartEvent();
	        AttackTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	    }
	    internal void OnDeathTrigger(Entity sender)
	    {
		    DeathTrigger?.Invoke(sender);
	    }

	    internal void OnPlayCardTrigger(Entity sender)
	    {
			if (PlayCardTrigger?.IsEmpty ?? true) return;
			StartEvent();
			PlayCardTrigger.Invoke(sender);
	    }
	    internal void OnAfterPlayCardTrigger(Entity sender)
	    {
	        if (AfterPlayCardTrigger?.IsEmpty ?? true) return;
	        StartEvent();
	        AfterPlayCardTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	    }
	    internal void OnPlayMinionTrigger(Entity sender)
	    {
		    if (PlayMinionTrigger?.IsEmpty ?? true)
		    {
			    if (PlayCardTrigger?.IsEmpty ?? true)
				    return;

				StartEvent();
				PlayCardTrigger.Invoke(sender);
		    }
		    else
		    {
			    StartEvent();
			    PlayMinionTrigger.Invoke(sender);
			    PlayCardTrigger?.Invoke(sender);
		    }

		    ProcessTasks();
		    DeathProcessingAndAuraUpdate();
		    EndEvent();
	    }
	    internal void OnAfterPlayMinionTrigger(Entity sender)
	    {
		    if (AfterPlayMinionTrigger?.IsEmpty ?? true)
		    {
			    if (AfterPlayCardTrigger?.IsEmpty ?? true)
			    {
					if (AfterSummonTrigger?.IsEmpty ?? true)
						return;

					StartEvent();
					AfterSummonTrigger.Invoke(sender);
			    }
			    else
			    {
				    StartEvent();
				    AfterPlayCardTrigger.Invoke(sender);
				    AfterSummonTrigger?.Invoke(sender);
			    }
		    }
		    else
		    {
			    StartEvent();
			    AfterPlayMinionTrigger.Invoke(sender);
			    AfterPlayCardTrigger?.Invoke(sender);
			    AfterSummonTrigger?.Invoke(sender);
		    }

		    ProcessTasks();
		    EndEvent();
		    DeathProcessingAndAuraUpdate();
	    }
	    internal void OnCastSpellTrigger(Entity sender)
	    {
		    if (CastSpellTrigger?.IsEmpty ?? true)
		    {
			    if (PlayCardTrigger?.IsEmpty ?? true)
				    return;
			    StartEvent();
			    PlayCardTrigger.Invoke(sender);
		    }
		    else
		    {
			    StartEvent();
				CastSpellTrigger.Invoke(sender);
			    PlayCardTrigger?.Invoke(sender);
		    }

		    ProcessTasks();
		    EndEvent();
		    DeathProcessingAndAuraUpdate();
	    }
	    internal void OnAfterCastTrigger(Entity sender)
	    {
		    if (AfterCastTrigger?.IsEmpty ?? true)
		    {
				if (AfterPlayCardTrigger?.IsEmpty ?? true)
					return;
				StartEvent();
				AfterPlayCardTrigger.Invoke(sender);
		    }
		    else
		    {
			    StartEvent();
			    AfterCastTrigger.Invoke(sender);
			    AfterPlayCardTrigger?.Invoke(sender);
		    }

		    ProcessTasks();
		    EndEvent();
		    DeathProcessingAndAuraUpdate();
	    }
	    internal void OnSecretRevealedTrigger(Entity sender)
	    {
		    SecretRevealedTrigger?.Invoke(sender);
	    }
	    internal void OnZoneTrigger(Entity sender)
	    {
		    if (ZoneTrigger?.IsEmpty ?? true) return;
		    StartEvent();
		    ZoneTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
	    }
	    internal bool OnDiscardTrigger(Entity sender)
	    {
	        if (DiscardTrigger?.IsEmpty ?? true) return false;
	        StartEvent();
	        DiscardTrigger.Invoke(sender);
	        return true;
	    }
	    internal void OnGameStartTrigger(Game game)
	    {
		    GameStartTrigger?.Invoke(game);
	    }
	    internal void OnDrawTrigger(Entity sender)
	    {
	        if (DrawTrigger?.IsEmpty ?? true) return;
	        StartEvent();
	        DrawTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	    }
	    internal bool OnTargetTrigger(Entity sender)
	    {
		    if (TargetTrigger?.IsEmpty ?? true) return false;
		    StartEvent();
		    TargetTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
			return true;
	    }
	    internal void OnInspireTrigger(Entity sender)
	    {
	        if (InspireTrigger?.IsEmpty ?? true) return;
	        StartEvent();
	        InspireTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	    }
	    internal void OnFreezeTrigger(Entity sender)
	    {
		    FrozenTrigger?.Invoke(sender);
	    }
	    internal void OnArmorTrigger(Entity sender)
	    {
		    ArmorTrigger?.Invoke(sender);
	    }
	    internal void OnEquipWeaponTrigger(Entity sender)
	    {
		    EquipWeaponTrigger?.Invoke(sender);
	    }

	    internal void OnShuffleIntoDeckTrigger(Entity sender)
	    {
		    ShuffleIntoDeckTrigger?.Invoke(sender);
	    }

	    internal void OnOverloadTrigger(Playable sender, int amount)
	    {
			if (OverloadTrigger?.IsEmpty ?? true)
				return;

			EventMetaData temp = sender.Game.CurrentEventData;
			sender.Game.CurrentEventData = new EventMetaData(sender, null, amount);
			OverloadTrigger.Invoke(sender);
			ProcessTasks();
			sender.Game.CurrentEventData = temp;
	    }

		#endregion

		#region Event subscripting methods

		public void AddEndTurnTrigger(TriggerStub trigger)
		{
			if (EndTurnTrigger == null)
				EndTurnTrigger = new TriggerHandler();
			EndTurnTrigger.Add(trigger);
		}

		public void AddTurnStartTrigger(TriggerStub trigger)
		{
			if (TurnStartTrigger == null)
				TurnStartTrigger = new TriggerHandler();
			TurnStartTrigger.Add(trigger);
		}

		public void AddDeathTrigger(TriggerStub trigger)
		{
			if (DeathTrigger == null)
				DeathTrigger = new TriggerHandler();
			DeathTrigger.Add(trigger);
		}

		public void AddInspireTrigger(TriggerStub trigger)
		{
			if (InspireTrigger == null)
				InspireTrigger = new TriggerHandler();
			InspireTrigger.Add(trigger);
		}

		public void AddDealDamageTrigger(TriggerStub trigger)
		{
			if (DealDamageTrigger == null)
				DealDamageTrigger = new TriggerHandler();
			DealDamageTrigger.Add(trigger);
		}

		public void AddTakeDamageTrigger(TriggerStub trigger)
		{
			if (TakeDamageTrigger == null)
				TakeDamageTrigger = new TriggerHandler();
			TakeDamageTrigger.Add(trigger);
		}

		public void AddPredamageTrigger(TriggerStub trigger)
		{
			if (PredamageTrigger == null)
				PredamageTrigger = new TriggerHandler();
			PredamageTrigger.Add(trigger);
		}

		public void AddHealTrigger(TriggerStub trigger)
		{
			if (HealTrigger == null)
				HealTrigger = new TriggerHandler();
			HealTrigger.Add(trigger);
		}

		public void AddLoseDivineShieldTrigger(TriggerStub trigger)
		{
			if (LoseDivineShieldTrigger == null)
				LoseDivineShieldTrigger = new TriggerHandler();
			LoseDivineShieldTrigger.Add(trigger);
		}

		public void AddAttackTrigger(TriggerStub trigger)
		{
			if (AttackTrigger == null)
				AttackTrigger = new TriggerHandler();
			AttackTrigger.Add(trigger);
		}

		public void AddAfterAttackTrigger(TriggerStub trigger)
		{
			if (AfterAttackTrigger == null)
				AfterAttackTrigger = new TriggerHandler();
			AfterAttackTrigger.Add(trigger);
		}

		public void AddSummonTrigger(TriggerStub trigger)
		{
			if (SummonTrigger == null)
				SummonTrigger = new TriggerHandler();
			SummonTrigger.Add(trigger);
		}

		public void AddAfterSummonTrigger(TriggerStub trigger)
		{
			if (AfterSummonTrigger == null)
				AfterSummonTrigger = new TriggerHandler();
			AfterSummonTrigger.Add(trigger);
		}

		public void AddPlayCardTrigger(TriggerStub trigger)
		{
			if (PlayCardTrigger == null)
				PlayCardTrigger = new TriggerHandler();
			PlayCardTrigger.Add(trigger);
		}

		public void AddAfterPlayCardTrigger(TriggerStub trigger)
		{
			if (AfterPlayCardTrigger == null)
				AfterPlayCardTrigger = new TriggerHandler();
			AfterPlayCardTrigger.Add(trigger);
		}

		public void AddPlayMinionTrigger(TriggerStub trigger)
		{
			if (PlayMinionTrigger == null)
				PlayMinionTrigger = new TriggerHandler();
			PlayMinionTrigger.Add(trigger);
		}

		public void AddAfterPlayMinionTrigger(TriggerStub trigger)
		{
			if (AfterPlayMinionTrigger == null)
				AfterPlayMinionTrigger = new TriggerHandler();
			AfterPlayMinionTrigger.Add(trigger);
		}

		public void AddCastSpellTrigger(TriggerStub trigger)
		{
			if (CastSpellTrigger == null)
				CastSpellTrigger = new TriggerHandler();
			CastSpellTrigger.Add(trigger);
		}

		public void AddAfterCastTrigger(TriggerStub trigger)
		{
			if (AfterCastTrigger == null)
				AfterCastTrigger = new TriggerHandler();
			AfterCastTrigger.Add(trigger);
		}

		public void AddSecretRevealedTrigger(TriggerStub trigger)
		{
			if (SecretRevealedTrigger == null)
				SecretRevealedTrigger = new TriggerHandler();
			SecretRevealedTrigger.Add(trigger);
		}

		public void AddZoneTrigger(TriggerStub trigger)
		{
			if (ZoneTrigger == null)
				ZoneTrigger = new TriggerHandler();
			ZoneTrigger.Add(trigger);
		}

		public void AddDiscardTrigger(TriggerStub trigger)
		{
			if (DiscardTrigger == null)
				DiscardTrigger = new TriggerHandler();
			DiscardTrigger.Add(trigger);
		}

		public void AddGameStartTrigger(TriggerStub trigger)
		{
			if (GameStartTrigger == null)
				GameStartTrigger = new TriggerHandler();
			GameStartTrigger.Add(trigger);
		}

		public void AddDrawTrigger(TriggerStub trigger)
		{
			if (DrawTrigger == null)
				DrawTrigger = new TriggerHandler();
			DrawTrigger.Add(trigger);
		}

		public void AddTargetTrigger(TriggerStub trigger)
		{
			if (TargetTrigger == null)
				TargetTrigger = new TriggerHandler();
			TargetTrigger.Add(trigger);
		}

		public void AddFrozenTrigger(TriggerStub trigger)
		{
			if (FrozenTrigger == null)
				FrozenTrigger = new TriggerHandler();
			FrozenTrigger.Add(trigger);
		}

		public void AddArmorTrigger(TriggerStub trigger)
		{
			if (ArmorTrigger == null)
				ArmorTrigger = new TriggerHandler();
			ArmorTrigger.Add(trigger);
		}

		public void AddEquipWeaponTrigger(TriggerStub trigger)
		{
			if (EquipWeaponTrigger == null)
				EquipWeaponTrigger = new TriggerHandler();
			EquipWeaponTrigger.Add(trigger);
		}

		public void AddShuffleIntoDeckTrigger(TriggerStub trigger)
		{
			if (ShuffleIntoDeckTrigger == null)
				ShuffleIntoDeckTrigger = new TriggerHandler();
			ShuffleIntoDeckTrigger.Add(trigger);
		}

		public void AddOverloadTrigger(TriggerStub trigger)
		{
			if (OverloadTrigger == null)
				OverloadTrigger = new TriggerHandler();
			OverloadTrigger.Add(trigger);
		}

		#endregion
	}
}
