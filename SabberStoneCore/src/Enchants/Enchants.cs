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
using System.Text.RegularExpressions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Enchants
{
    internal static class Enchants
    {
	    private static Regex AttackHealth = new Regex(@"[+](\d)[/][+](\d)");
	    private static Regex SetAttackHealth = new Regex(@"(\d)[/](\d)");
	    private static Regex Attack = new Regex(@"[+](\d) Attack");
	    private static Regex Health = new Regex(@"[+](\d) Health");
	    private static Regex SpellPower = new Regex(@"Spell Damage [+](\d)");

	    public static readonly Enchant AddAttackScriptTag =
		    new Enchant(Effects.Attack_N(0))
		    {
			    UseScriptTag = true
		    };
	    public static readonly Enchant AddHealthScriptTag =
		    new Enchant(Effects.Health_N(0))
		    {
			    UseScriptTag = true
		    };
	    public static readonly Enchant SetAttackScriptTag =
		    new Enchant(Effects.SetAttack(0))
		    {
			    UseScriptTag = true
		    };
	    public static readonly Enchant SetHealthScriptTag =
		    new Enchant(Effects.SetMaxHealth(0))
		    {
			    UseScriptTag = true
		    };
		public static readonly Enchant AddAttackHealthScriptTag =
		    new Enchant(Effects.AttackHealth_N(0))
		    {
			    UseScriptTag = true
		    };
	    public static readonly Enchant SetAttackHealthScriptTag =
		    new Enchant(Effects.SetAttackHealth(0))
		    {
			    UseScriptTag = true
		    };

		/// <summary>
		/// Generate proper <see cref="Enchant"/> from the text of the given card.
		/// </summary>
		/// <param name="cardId"></param>
		/// <returns></returns>
		public static Enchant GetAutoEnchantFromText(string cardId)
		{
			Card card = Cards.FromId(cardId);
			string text = card.Text;
		    var effects = new List<AbstractEffect>();
			bool oneTurn = false;
			bool mod = false;

			if (card.Modular)
			{	// generate magnetic enchants
				effects.AddRange(Effects.AttackHealth_N(0));
				mod = true;
			}
			else
			{
				Match attackHealth = AttackHealth.Match(text);
				Match attack = Attack.Match(text);
				Match health = Health.Match(text);
				Match set = SetAttackHealth.Match(text);

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
				else if
					(set.Success)
				{
					effects.Add(Effects.SetAttack(Int32.Parse(set.Groups[1].Value)));
					effects.Add(Effects.SetMaxHealth(Int32.Parse(set.Groups[2].Value)));
				}
			}


			if (text.Contains(@"<b>Taunt</b>"))
		    {
			    effects.Add(Effects.TauntEff);
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

		    if (text.Contains(@"<b>Divine Shield</b>"))
		    {
			    //effects.Add(new Effect(GameTag.DIVINE_SHIELD, EffectOperator.SET, 1));
			    effects.Add(Effects.DivineShield);
		    }

		    if (text.Contains(@"<b>Poisonous</b>"))
		    {
			    //effects.Add(new Effect(GameTag.POISONOUS, EffectOperator.SET, 1));
			    effects.Add(Effects.Poisonous);
		    }

		    if (text.Contains(@"<b>Lifesteal</b>"))
		    {
			    effects.Add(Effects.Lifesteal);
		    }

		    if (text.Contains(@"<b>Rush</b>"))
		    {
			    effects.Add(Effects.Rush);
		    }

			if (text.Contains("this turn"))
		    {
				oneTurn = true;
		    }

			Match spellPower = SpellPower.Match(text);
			if (spellPower.Success)
			{
				effects.Add(new AddSpellPower(Int32.Parse(spellPower.Groups[1].Value)));
			}

			var output = new Enchant(effects.ToArray())
			{
				IsOneTurnEffect = oneTurn
			};
			if (mod)
				output.UseScriptTag = true;

			return output;
	    }


    }

	internal static class Effects
	{
		private static readonly Dictionary<int, VaryAttackEffect> VaryAttackEffects = new Dictionary<int, VaryAttackEffect>();
		private static readonly Dictionary<int, SetAttackEffect> SetAttackEffects = new Dictionary<int, SetAttackEffect>();
		private static readonly Dictionary<int, VaryHealthEffect> VaryHealthEffects = new Dictionary<int, VaryHealthEffect>();
		private static readonly Dictionary<int, SetHealthEffect> SetHealthEffects = new Dictionary<int, SetHealthEffect>();

		internal static AbstractEffect Attack_N(int n)
		{
			return VaryAttackEffects.TryGetValue(n, out VaryAttackEffect value)
				? value
				: (VaryAttackEffects[n] = new VaryAttackEffect(n));
		}

		internal static AbstractEffect Health_N(int n)
		{
			return VaryHealthEffects.TryGetValue(n, out VaryHealthEffect value)
				? value
				: (VaryHealthEffects[n] = new VaryHealthEffect(n));
		}

		internal static AbstractEffect Durability_N(int n)
		{
			return Health_N(n);
		}

		internal static AbstractEffect[] AttackHealth_N(int n)
		{
			return new[] {Attack_N(n), Health_N(n)};
		}

		internal static AbstractEffect SetAttack(int n)
		{
			return SetAttackEffects.TryGetValue(n, out SetAttackEffect value)
				? value
				: SetAttackEffects[n] = new SetAttackEffect(n);
		}

		internal static AbstractEffect SetMaxHealth(int n)
		{
			return SetHealthEffects.TryGetValue(n, out SetHealthEffect value)
				? value
				: SetHealthEffects[n] = new SetHealthEffect(n);
		}

		internal static AbstractEffect[] SetAttackHealth(int n)
		{
			return new[] {SetAttack(n), SetMaxHealth(n)};
		}

		internal static AbstractEffect MultiplyAttack(int n)
		{
			return new MultiplyAttackEffect(n);
		}

		internal static AbstractEffect MultiplyHealth(int n)
		{
			return new MultiplyHealthEffect(n);
		}

		internal static AbstractEffect ReduceCost(int n)
		{
			//return Cost.Effect(EffectOperator.SUB, n);
			return new VaryCost(-n);
		}

		internal static AbstractEffect SetCost(int n)
		{
			//return Cost.Effect(EffectOperator.SET, n);
			return new SetCost(n);
		}

		internal static AbstractEffect AddCost(int n)
		{
			//return Cost.Effect(EffectOperator.ADD, n);
			return new VaryCost(n);
		}

		internal static readonly AbstractEffect TauntEff = new SetBoolAttrEffect(BoolAttributes.Taunt, true);

		internal static readonly AbstractEffect StealthEff = new SetBoolAttrEffect(BoolAttributes.Stealth, true);

		internal static readonly AbstractEffect Elusive = new SetBoolAttrEffect(BoolAttributes.Elusive, true);

		internal static readonly AbstractEffect DivineShield = new SetBoolAttrEffect(BoolAttributes.DivineShield, true);

		internal static readonly AbstractEffect Poisonous = new SetBoolAttrEffect(BoolAttributes.Poisonous, true);

		internal static readonly AbstractEffect Windfury = new SetWindfuryEffect();

		internal static readonly AbstractEffect Charge = new SetChargeEffect();

		internal static readonly AbstractEffect Immune = new SetBoolAttrEffect(BoolAttributes.Immune, true);

		internal static readonly AbstractEffect Lifesteal = new SetLifestealEffect();

		internal static readonly AbstractEffect Rush = new SetRushEffect();

		internal static readonly AbstractEffect Echo = new SetEchoEffect();

		internal static AbstractEffect AttributeAddEffect(IntAttributes intAttr, int value) =>
			new AddIntAttrEffect(intAttr, value);

		internal static AbstractEffect SetAttributeEffect(IntAttributes intAttr, int value) =>
			new SetIntAttrEffect(intAttr, value);

		internal static AbstractEffect SetAttributeEffect(BoolAttributes boolAttr, bool value = true) =>
			new SetBoolAttrEffect(boolAttr, value);

		internal static AbstractEffect ControllerAttributeEffect(ControllerBoolAttributes boolAttr) =>
			new SetControllerBoolAttr(boolAttr);

		internal static AbstractEffect ControllerAttributeEffect(ControllerIntAttributes intAttr, int value = 1) =>
			new AddControllerIntAttr(intAttr, value);
	}
}
