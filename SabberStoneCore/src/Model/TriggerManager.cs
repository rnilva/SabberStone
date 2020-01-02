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
	    public class FastTriggerHandler
	    {
		    private static readonly TriggerStub[] EmptyArray = new TriggerStub[0];
		    private const int InitSize = 4;

		    private TriggerStub[] _triggers;
			private int _position;
			private bool _invoking;

			internal FastTriggerHandler()
			{
				_triggers = EmptyArray;
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
				if (_triggers.Length == 0)
				{
					// Lazy initialisation.
					_triggers = new TriggerStub[InitSize];
					return;
				}

				var newArr = new TriggerStub[_triggers.Length << 1];
				Array.Copy(_triggers, 0, newArr, 0, _triggers.Length);
				_triggers = newArr;
			}

			public static FastTriggerHandler operator +(FastTriggerHandler handler, TriggerStub trigger)
			{
				handler.Add(trigger);
				return handler;
			}

			public static FastTriggerHandler operator -(FastTriggerHandler handler, TriggerStub trigger)
			{
				handler.Remove(trigger);
				return handler;
			}

			private class DebuggerView
			{
				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				private FastTriggerHandler _handler;
				public DebuggerView(FastTriggerHandler handler)
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

		public delegate void TriggerHandler(Entity sender);

		public readonly FastTriggerHandler PredamageTrigger = new FastTriggerHandler();
		public readonly FastTriggerHandler TakeDamageTrigger =  new FastTriggerHandler();
		public readonly FastTriggerHandler AfterAttackTrigger =  new FastTriggerHandler();
		public readonly FastTriggerHandler DealDamageTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler DamageTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler HealTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler LoseDivineShieldTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler EndTurnTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler TurnStartTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler SummonTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler AfterSummonTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler AttackTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler DeathTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler PlayCardTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler AfterPlayCardTrigger =  new FastTriggerHandler();

		public readonly FastTriggerHandler PlayMinionTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler AfterPlayMinionTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler CastSpellTrigger =  new FastTriggerHandler();
	    public readonly FastTriggerHandler AfterCastTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler SecretRevealedTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler ZoneTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler DiscardTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler GameStartTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler DrawTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler TargetTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler InspireTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler FrozenTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler ArmorTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler EquipWeaponTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler ShuffleIntoDeckTrigger =  new FastTriggerHandler();

	    public readonly FastTriggerHandler OverloadTrigger =  new FastTriggerHandler();

		public bool HasTargetTrigger => TargetTrigger != null;
		public bool HasOnSummonTrigger => SummonTrigger != null;
		public bool HasShuffleIntoDeckTrigger => ShuffleIntoDeckTrigger != null;

		public void ValidateTriggers(Entity source, SequenceType type)
		{
			switch (type)
			{
				case SequenceType.PlayCard:
					PlayCardTrigger.ValidateAll(source);
					AfterPlayCardTrigger.ValidateAll(source);
					break;
				case SequenceType.PlayMinion:
					PlayMinionTrigger.ValidateAll(source);
					AfterPlayMinionTrigger.ValidateAll(source);
					break;
				case SequenceType.PlaySpell:
					CastSpellTrigger.ValidateAll(source);
					AfterCastTrigger.ValidateAll(source);
					break;
				case SequenceType.Target:
					TargetTrigger.ValidateAll(source);
					break;
			}
		}

		public void InvalidateTriggers()
		{
			PlayCardTrigger.InvalidateAll();
			AfterPlayCardTrigger.InvalidateAll();
			CastSpellTrigger.InvalidateAll();
			AfterCastTrigger.InvalidateAll();
			TargetTrigger.InvalidateAll();
		}

		internal void OnDamageTriggers(Playable source, Character target)
		{
			
		}

		internal bool OnDealDamageTrigger(Entity sender)
	    {
	        if (DealDamageTrigger.IsEmpty) return false;
	        //StartEvent();
	        DealDamageTrigger.Invoke(sender);
	        return true;
	    }
	    internal bool OnDamageTrigger(Entity sender)
	    {
	        if (DamageTrigger.IsEmpty) return false;
	        //StartEvent();
	        DamageTrigger.Invoke(sender);
	        return true;
	    }
	    internal void OnHealTrigger(Entity sender)
	    {
	        if (HealTrigger.IsEmpty) return;
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
	        if (EndTurnTrigger.IsEmpty) return;
	        StartEvent();
	        EndTurnTrigger.Invoke(sender);
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	    }
	    internal bool OnTurnStartTrigger(Entity sender)
	    {
	        if (TurnStartTrigger.IsEmpty) return false;
	        TurnStartTrigger.Invoke(sender);
	        ProcessTasks();
	        return true;
	    }
	    internal void OnSummonTrigger(Entity sender, bool srs = false)
	    {
	        if (SummonTrigger.IsEmpty) return;
	        if (!srs) StartEvent();
	        SummonTrigger.Invoke(sender);
	        ProcessTasks();
	        if (!srs) EndEvent();
	    }
	    internal void OnAfterSummonTrigger(Entity sender)
	    {
		    if (AfterSummonTrigger.IsEmpty)
			    return;
		    StartEvent();
		    AfterSummonTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
	    }
	    internal void OnAttackTrigger(Entity sender)
	    {
	        if (AttackTrigger.IsEmpty) return;
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
			if (PlayCardTrigger.IsEmpty) return;
			StartEvent();
			PlayCardTrigger.Invoke(sender);
	    }
	    internal void OnAfterPlayCardTrigger(Entity sender)
	    {
	        if (AfterPlayCardTrigger.IsEmpty) return;
	        StartEvent();
	        AfterPlayCardTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	    }
	    internal void OnPlayMinionTrigger(Entity sender)
	    {
		    if (PlayMinionTrigger.IsEmpty)
		    {
			    if (PlayCardTrigger.IsEmpty)
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
		    if (AfterPlayMinionTrigger.IsEmpty)
		    {
			    if (AfterPlayCardTrigger.IsEmpty)
			    {
					if (AfterSummonTrigger.IsEmpty)
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
		    if (CastSpellTrigger.IsEmpty)
		    {
			    if (PlayCardTrigger.IsEmpty)
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
		    if (AfterCastTrigger.IsEmpty)
		    {
				if (AfterPlayCardTrigger.IsEmpty)
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
		    if (ZoneTrigger.IsEmpty) return;
		    StartEvent();
		    ZoneTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
	    }
	    internal bool OnDiscardTrigger(Entity sender)
	    {
	        if (DiscardTrigger.IsEmpty) return false;
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
	        if (DrawTrigger.IsEmpty) return;
	        StartEvent();
	        DrawTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	    }
	    internal bool OnTargetTrigger(Entity sender)
	    {
		    if (TargetTrigger.IsEmpty) return false;
		    StartEvent();
		    TargetTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
			return true;
	    }
	    internal void OnInspireTrigger(Entity sender)
	    {
	        if (InspireTrigger.IsEmpty) return;
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
			if (OverloadTrigger.IsEmpty)
				return;

			EventMetaData temp = sender.Game.CurrentEventData;
			sender.Game.CurrentEventData = new EventMetaData(sender, null, amount);
			OverloadTrigger.Invoke(sender);
			ProcessTasks();
			sender.Game.CurrentEventData = temp;
	    }
    }
}
