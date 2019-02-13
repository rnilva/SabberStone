﻿using System;
using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Actions
{
    public static partial class Generic
    {
	    public static Action<Controller, Spell, ICharacter, int, bool> CastSpell
		    => delegate(Controller c, Spell spell, ICharacter target, int chooseOne, bool checkOverload)
		    {
			    if (checkOverload && spell.Card.HasOverload)
			    {
				    int amount = spell.Overload;
				    c.OverloadOwed += amount;
				    c.OverloadThisGame += amount;
				}

			    c.Game.TaskQueue.StartEvent();
			    if (spell.IsSecret || spell.IsQuest)
			    {
				    spell.Power.Trigger?.Activate(c.Game, spell);
				    c.SecretZone.Add(spell);
				    spell.IsExhausted = true;
			    }
			    else
			    {
				    spell.Power?.Trigger?.Activate(c.Game, spell);
				    spell.Power?.Aura?.Activate(spell);

				    if (spell.Combo && c.IsComboActive)
					    spell.ActivateTask(PowerActivation.COMBO, target);
				    else
					    spell.ActivateTask(PowerActivation.POWER, target, chooseOne);

				    c.GraveyardZone.Add(spell);
			    }

			    // process power tasks
			    c.Game.ProcessTasks();
			    c.Game.TaskQueue.EndEvent();
		    };
    }
}
