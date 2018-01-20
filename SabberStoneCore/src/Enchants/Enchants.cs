﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;

namespace SabberStoneCore.Enchants
{
    internal static class Enchants
    {
	    private static Regex AttackHealth = new Regex(@"[+](\d)[/][+](\d)");
	    private static Regex Attack = new Regex(@"[+](\d) Attack");
	    private static Regex Health = new Regex(@"[+](\d) Health");

	    public static Enchant GetAutoEnchantFromText(string cardId)
	    {
			string text = Cards.FromId(cardId).Text;
		    var effects = new List<Effect>();
			bool oneTurn = false;

		    Match attackHealth = AttackHealth.Match(text);
		    Match attack = Attack.Match(text);
		    Match health = Health.Match(text);

			if (attackHealth.Success)
			{
				effects.Add(Effects.Attack_N(Int32.Parse(attackHealth.Groups[1].Value)));
				effects.Add(Effects.Health_N(Int32.Parse(attackHealth.Groups[2].Value)));
			}
		    else if (attack.Success)
		    {
			    effects.Add(Effects.Attack_N(Int32.Parse(attack.Groups[1].Value)));
		    }
		    else if (health.Success)
		    {
			    effects.Add(Effects.Health_N(Int32.Parse(health.Groups[1].Value)));
		    }

		    if (text.Contains(@"<b>Taunt</b>"))
		    {
			    effects.Add(Effects.Taunt);
		    }

		    if (text.Contains(@"<b>Windfury</b>"))
		    {
			    effects.Add(Effects.Windfury);
		    }

		    if (text.Contains(@"<b>Charge</b>"))
		    {
			    effects.Add(Effects.Charge);
		    }

		    if (text.Contains(@"<b>Immune</b>"))
		    {
			    effects.Add(Effects.Immune);
		    }

		    if (text.Contains("this turn"))
		    {
				oneTurn = true;
		    }

			return new Enchant (effects.ToArray())
			{
				IsOneTurnEffect = oneTurn
		    };
	    }
    }

	internal static class Effects
	{
		internal static Effect Attack_N(int n)
		{
			return new Effect(GameTag.ATK, EffectOperator.ADD, n);
		}

		internal static Effect Health_N(int n)
		{
			return new Effect(GameTag.HEALTH, EffectOperator.ADD, n);
		}

		internal static Effect[] AttackHealth_N(int n)
		{
			return new[] {Attack_N(n), Health_N(n)};
		}

		internal static Effect SetAttack(int n)
		{
			return new Effect(GameTag.ATK, EffectOperator.SET, n);
		}

		internal static Effect SetMaxHealth(int n)
		{
			return new Effect(GameTag.HEALTH, EffectOperator.SET, n);
		}

		internal static Effect ReduceCost(int n)
		{
			return new Effect(GameTag.COST, EffectOperator.SUB, n);
		}

		internal static Effect Taunt => new Effect(GameTag.TAUNT, EffectOperator.SET, 1);

		internal static Effect Windfury => new Effect(GameTag.WINDFURY, EffectOperator.SET, 1);

		internal static Effect Charge => new Effect(GameTag.CHARGE, EffectOperator.SET, 1);

		internal static Effect Immune => new Effect(GameTag.IMMUNE, EffectOperator.SET, 1);
	}
}