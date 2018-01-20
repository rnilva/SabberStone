﻿using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Enchants;

namespace SabberStoneCore.Model
{
    public class TriggerManager
    {
	    public delegate void TriggerHandler(IEntity sender);

	    public event TriggerHandler DamageTrigger;
	    public event TriggerHandler HealTrigger;

	    public event TriggerHandler EndTurnTrigger;
	    public event TriggerHandler TurnStartTrigger;

	    public event TriggerHandler SummonTrigger;

	    public event TriggerHandler AttackTrigger;

	    public event TriggerHandler DeathTrigger;

	    public event TriggerHandler PlayCardTrigger;

		public event TriggerHandler PlayMinionTrigger;
	    public event TriggerHandler AfterPlayMinionTrigger;

	    public event TriggerHandler CastSpellTrigger;
	    public event TriggerHandler AfterCastTrigger;

	    public event TriggerHandler SecretRevealedTrigger;

	    //public List<Trigger> DamageDealtTriggers = new LinkedList<Trigger>
	    //public List<Trigger> PlayCardTriggers = new List<Trigger>();
	    //public List<Trigger> SummonTriggers = new List<Trigger>();

		internal void OnDamageTrigger(IEntity sender)
	    {
		    DamageTrigger?.Invoke(sender);
	    }

	    internal void OnHealTrigger(IEntity sender)
	    {
		    Trigger.ValidateTriggers(sender.Game, sender, TriggerType.HEAL);
			HealTrigger?.Invoke(sender);
	    }

	    internal void OnEndTurnTrigger(IEntity sender)
	    {
		    Trigger.ValidateTriggers(sender.Game, sender, TriggerType.TURN_END);
			EndTurnTrigger?.Invoke(sender);
	    }

	    internal void OnTurnStartTrigger(IEntity sender)
	    {
		    Trigger.ValidateTriggers(sender.Game, sender, TriggerType.TURN_START);
			TurnStartTrigger?.Invoke(sender);
	    }

	    internal void OnSummonTrigger(IEntity sender)
	    {
		    Trigger.ValidateTriggers(sender.Game, sender, TriggerType.SUMMON);
			SummonTrigger?.Invoke(sender);
	    }

	    internal void OnAttackTrigger(IEntity sender)
	    {
		    AttackTrigger?.Invoke(sender);
	    }

	    internal void OnDeathTrigger(IEntity sender)
	    {
		    Trigger.ValidateTriggers(sender.Game, sender, TriggerType.DEATH);
			DeathTrigger?.Invoke(sender);
	    }

	    internal void OnPlayCardTrigger(IEntity sender)
	    {
		    Trigger.ValidateTriggers(sender.Game, sender, TriggerType.PLAY_CARD);
			PlayCardTrigger?.Invoke(sender);
	    }

	    internal void OnPlayMinionTrigger(IEntity sender)
	    {
		    PlayMinionTrigger?.Invoke(sender);
	    }

	    internal void OnAfterPlayMinionTrigger(IEntity sender)
	    {
		    AfterPlayMinionTrigger?.Invoke(sender);
	    }

	    internal void OnCastSpellTrigger(IEntity sender)
	    {
		    CastSpellTrigger?.Invoke(sender);
	    }

	    internal void OnAfterCastTrigger(IEntity sender)
	    {
		    AfterCastTrigger?.Invoke(sender);
	    }

	    internal void OnSecretRevealedTrigger(IEntity sender)
	    {
		    Trigger.ValidateTriggers(sender.Game, sender, TriggerType.SECRET_REVEALED);
			SecretRevealedTrigger?.Invoke(sender);
	    }
    }
}