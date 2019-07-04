using System;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Model
{
    public class TriggerManager
    {
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

		public delegate void TriggerHandler(IEntity sender);

	    public event TriggerHandler DealDamageTrigger;
	    public event TriggerHandler DamageTrigger;
	    public event TriggerHandler HealTrigger;
	    public event TriggerHandler LoseDivineShield;

	    public event TriggerHandler EndTurnTrigger;
	    public event TriggerHandler TurnStartTrigger;

	    public event TriggerHandler SummonTrigger;
	    public event TriggerHandler AfterSummonTrigger;

	    public event TriggerHandler AttackTrigger;

	    public event TriggerHandler DeathTrigger;

	    public event TriggerHandler PlayCardTrigger;
	    public event TriggerHandler AfterPlayCardTrigger;

		public event TriggerHandler PlayMinionTrigger;
	    public event TriggerHandler AfterPlayMinionTrigger;

	    public event TriggerHandler CastSpellTrigger;
	    public event TriggerHandler AfterCastTrigger;

	    public event TriggerHandler SecretRevealedTrigger;

	    public event TriggerHandler ZoneTrigger;

	    public event TriggerHandler DiscardTrigger;

	    public event TriggerHandler GameStartTrigger;

	    public event TriggerHandler DrawTrigger;

	    public event TriggerHandler TargetTrigger;

	    public event TriggerHandler InspireTrigger;

	    public event TriggerHandler FreezeTrigger;

	    public event TriggerHandler ArmorTrigger;

	    public event TriggerHandler EquipWeaponTrigger;

	    public event TriggerHandler ShuffleIntoDeckTrigger;

		public bool HasTargetTrigger => TargetTrigger != null;
		public bool HasOnSummonTrigger => SummonTrigger != null;
		public bool HasShuffleIntoDeckTrigger => ShuffleIntoDeckTrigger != null;

		internal bool OnDealDamageTrigger(IEntity sender)
	    {
	        if (DealDamageTrigger == null) return false;
	        StartEvent();
	        DealDamageTrigger.Invoke(sender);
	        return true;
	    }
	    internal bool OnDamageTrigger(IEntity sender)
	    {
	        if (DamageTrigger == null) return false;
	        StartEvent();
	        DamageTrigger.Invoke(sender);
	        return true;
	    }
	    internal void OnHealTrigger(IEntity sender)
	    {
	        if (HealTrigger == null) return;
	        StartEvent();
	        HealTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	        return;
	    }
	    internal void OnLoseDivineShield(IEntity sender)
	    {
		    LoseDivineShield?.Invoke(sender);
	    }
	    internal void OnEndTurnTrigger(IEntity sender)
	    {
	        if (EndTurnTrigger == null) return;
	        StartEvent();
	        EndTurnTrigger.Invoke(sender);
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	    }
	    internal bool OnTurnStartTrigger(IEntity sender)
	    {
	        if (TurnStartTrigger == null) return false;
	        TurnStartTrigger.Invoke(sender);
	        ProcessTasks();
	        return true;
	    }
	    internal void OnSummonTrigger(IEntity sender, bool srs = false)
	    {
	        if (SummonTrigger == null) return;
	        if (!srs) StartEvent();
	        SummonTrigger.Invoke(sender);
	        ProcessTasks();
	        if (!srs) EndEvent();
	    }
	    internal void OnAfterSummonTrigger(IEntity sender)
	    {
		    if (AfterSummonTrigger == null)
			    return;
		    StartEvent();
		    AfterSummonTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
	    }
	    internal void OnAttackTrigger(IEntity sender)
	    {
	        if (AttackTrigger == null) return;
	        StartEvent();
	        AttackTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	    }
	    internal void OnDeathTrigger(IEntity sender)
	    {
		    DeathTrigger?.Invoke(sender);
	    }

	    internal void OnPlayCardTrigger(IEntity sender)
	    {
			if (PlayCardTrigger == null) return;
			StartEvent();
			PlayCardTrigger.Invoke(sender);
			return;
	    }
	    internal void OnAfterPlayCardTrigger(IEntity sender)
	    {
	        if (AfterPlayCardTrigger == null) return;
	        StartEvent();
	        AfterPlayCardTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	        return;
	    }
	    internal void OnPlayMinionTrigger(IEntity sender)
	    {
		    if (PlayMinionTrigger == null)
		    {
			    if (PlayCardTrigger == null)
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
	    internal void OnAfterPlayMinionTrigger(IEntity sender)
	    {
		    if (AfterPlayMinionTrigger == null)
		    {
			    if (AfterPlayCardTrigger == null)
			    {
					if (AfterSummonTrigger == null)
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
	    internal void OnCastSpellTrigger(IEntity sender)
	    {
		    if (CastSpellTrigger == null)
		    {
			    if (PlayCardTrigger == null)
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
	    internal void OnAfterCastTrigger(IEntity sender)
	    {
		    if (AfterCastTrigger == null)
		    {
				if (AfterPlayCardTrigger == null)
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
	    internal void OnSecretRevealedTrigger(IEntity sender)
	    {
		    SecretRevealedTrigger?.Invoke(sender);
	    }
	    internal void OnZoneTrigger(IEntity sender)
	    {
		    if (ZoneTrigger == null) return;
		    StartEvent();
		    ZoneTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
	    }
	    internal bool OnDiscardTrigger(IEntity sender)
	    {
	        if (DiscardTrigger == null) return false;
	        StartEvent();
	        DiscardTrigger.Invoke(sender);
	        return true;
	    }
	    internal void OnGameStartTrigger()
	    {
		    GameStartTrigger?.Invoke(null);
	    }
	    internal void OnDrawTrigger(IEntity sender)
	    {
	        if (DrawTrigger == null) return;
	        StartEvent();
	        DrawTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	    }
	    internal bool OnTargetTrigger(IEntity sender)
	    {
		    if (TargetTrigger == null) return false;
		    StartEvent();
		    TargetTrigger.Invoke(sender);
		    ProcessTasks();
		    EndEvent();
			return true;
	    }
	    internal void OnInspireTrigger(IEntity sender)
	    {
	        if (InspireTrigger == null) return;
	        StartEvent();
	        InspireTrigger.Invoke(sender);
	        ProcessTasks();
	        EndEvent();
	        DeathProcessingAndAuraUpdate();
	    }
	    internal void OnFreezeTrigger(IEntity sender)
	    {
		    FreezeTrigger?.Invoke(sender);
	    }
	    internal void OnArmorTrigger(IEntity sender)
	    {
		    ArmorTrigger?.Invoke(sender);
	    }
	    internal void OnEquipWeaponTrigger(IEntity sender)
	    {
		    EquipWeaponTrigger?.Invoke(sender);
	    }

	    internal void OnShuffleIntoDeckTrigger(IEntity sender)
	    {
		    ShuffleIntoDeckTrigger?.Invoke(sender);
	    }

	    public void AddTrigger(TriggerType type, TriggerHandler method)
	    {
			switch (type)
			{
				case TriggerType.TURN_END:
					EndTurnTrigger += method;
					return;
				case TriggerType.TURN_START:
					TurnStartTrigger += method;
					return;
				case TriggerType.DEATH:
					DeathTrigger += method;
					return;
				case TriggerType.INSPIRE:
					InspireTrigger += method;
					return;
				case TriggerType.DEAL_DAMAGE:
					DealDamageTrigger += method;
					return;
				case TriggerType.TAKE_DAMAGE:
					DamageTrigger += method;
					return;
				case TriggerType.HEAL:
					HealTrigger += method;
					return;
				case TriggerType.LOSE_DIVINE_SHIELD:
					LoseDivineShield += method;
					return;
				case TriggerType.ATTACK:
					AttackTrigger += method;
					return;
				case TriggerType.SUMMON:
					SummonTrigger += method;
					return;
				case TriggerType.AFTER_SUMMON:
					AfterSummonTrigger += method;
					return;
				case TriggerType.PLAY_CARD:
					PlayCardTrigger += method;
					return;
				case TriggerType.AFTER_PLAY_CARD:
					AfterPlayMinionTrigger += method;
					return;
				case TriggerType.PLAY_MINION:
					PlayMinionTrigger += method;
					return;
				case TriggerType.AFTER_PLAY_MINION:
					AfterPlayMinionTrigger += method;
					return;
				case TriggerType.CAST_SPELL:
					CastSpellTrigger += method;
					return;
				case TriggerType.AFTER_CAST:
					AfterCastTrigger += method;
					return;
				case TriggerType.SECRET_REVEALED:
					SecretRevealedTrigger += method;
					return;
				case TriggerType.ZONE:
					ZoneTrigger += method;
					return;
				case TriggerType.DISCARD:
					DiscardTrigger += method;
					return;
				case TriggerType.GAME_START:
					GameStartTrigger += method;
					return;
				case TriggerType.DRAW:
					DrawTrigger += method;
					return;
				case TriggerType.TARGET:
					TargetTrigger += method;
					return;
				case TriggerType.FROZEN:
					FreezeTrigger += method;
					return;
				case TriggerType.ARMOR:
					ArmorTrigger += method;
					return;
				case TriggerType.EQUIP_WEAPON:
					EquipWeaponTrigger += method;
					return;
				default:
					throw new System.NotImplementedException();
			}
		}

	    public void RemoveTrigger(TriggerType type, TriggerHandler method)
	    {
		    switch (type)
		    {
			    case TriggerType.TURN_END:
				    EndTurnTrigger -= method;
				    return;
			    case TriggerType.TURN_START:
				    TurnStartTrigger -= method;
				    return;
			    case TriggerType.DEATH:
				    DeathTrigger -= method;
				    return;
			    case TriggerType.INSPIRE:
				    InspireTrigger -= method;
				    return;
			    case TriggerType.DEAL_DAMAGE:
				    DealDamageTrigger -= method;
				    return;
			    case TriggerType.TAKE_DAMAGE:
				    DamageTrigger -= method;
				    return;
			    case TriggerType.HEAL:
				    HealTrigger -= method;
				    return;
				case TriggerType.LOSE_DIVINE_SHIELD:
				    LoseDivineShield -= method;
				    return;
			    case TriggerType.ATTACK:
				    AttackTrigger -= method;
				    return;
			    case TriggerType.SUMMON:
				    SummonTrigger -= method;
				    return;
			    case TriggerType.AFTER_SUMMON:
				    AfterSummonTrigger -= method;
				    return;
			    case TriggerType.PLAY_CARD:
				    PlayCardTrigger -= method;
				    return;
			    case TriggerType.AFTER_PLAY_CARD:
				    AfterPlayMinionTrigger -= method;
				    return;
			    case TriggerType.PLAY_MINION:
				    PlayMinionTrigger -= method;
				    return;
			    case TriggerType.AFTER_PLAY_MINION:
				    AfterPlayMinionTrigger -= method;
				    return;
			    case TriggerType.CAST_SPELL:
				    CastSpellTrigger -= method;
				    return;
			    case TriggerType.AFTER_CAST:
				    AfterCastTrigger -= method;
				    return;
			    case TriggerType.SECRET_REVEALED:
				    SecretRevealedTrigger -= method;
				    return;
			    case TriggerType.ZONE:
				    ZoneTrigger -= method;
				    return;
			    case TriggerType.DISCARD:
				    DiscardTrigger -= method;
				    return;
			    case TriggerType.GAME_START:
				    GameStartTrigger -= method;
				    return;
			    case TriggerType.DRAW:
				    DrawTrigger -= method;
				    return;
			    case TriggerType.TARGET:
				    TargetTrigger -= method;
				    return;
			    case TriggerType.FROZEN:
				    FreezeTrigger -= method;
				    return;
			    case TriggerType.ARMOR:
				    ArmorTrigger -= method;
				    return;
			    case TriggerType.EQUIP_WEAPON:
				    EquipWeaponTrigger -= method;
				    return;
			    default:
				    throw new System.NotImplementedException();
		    }
	    }
    }
}
