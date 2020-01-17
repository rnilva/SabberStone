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
using SabberStoneCore.Model;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Triggers;

namespace SabberStoneCore.Actions
{
	public static partial class Generic
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public static bool PlayCard(Game g, Controller c, Playable source, Character target = null, int zonePosition = -1, int chooseOne = 0, bool skipPrePhase = false)
		{
			return PlayCardBlock.Invoke(g, c, source, target, zonePosition, chooseOne, skipPrePhase);
		}

		public static Func<Game, Controller, Playable, Character, int, int, bool, bool> PlayCardBlock
			=> delegate (Game g, Controller c, Playable source, Character target, int zonePosition, int chooseOne, bool skipPrePhase)
			{
				// Preplay Phase : check the given source is playable
				if (!skipPrePhase)
					if (!PrePlayPhase.Invoke(g, c, source, target, zonePosition, chooseOne))
						return false;

				Game game = c.Game;
				bool history = game.History;

				// Start play block
				if (history)
					game.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.PLAY, source.Id, "", 0, target?.Id ?? 0));

				game.CurrentEventData = new EventMetaData(source, target);

				// Pay Phase
				if (!PayPhase.Invoke(g, c, source))
					return false;

				// remove from hand zone
				if (!RemoveFromZone.Invoke(c, source))
					return false;

				bool echo = source.IsEcho;

				c.NumCardsPlayedThisTurn++;
				c.LastCardPlayed = source.Id;

				// record played cards for effect of cards like Obsidian Shard and Lynessa Sunsorrow
				// or use graveyard instead with 'played' tag(or bool)?
				c.CardsPlayedThisTurn.Add(source.Card);
				c.PlayHistory.Add(new PlayHistoryEntry(in source, in target, in chooseOne));

				//// show entity
				//if (g.History)
				//	g.PowerHistory.Add(PowerHistoryBuilder.ShowEntity(source));

				if (target != null)
				{	// Don't use CardTarget any more; Use EventMetaData.Target instead.

					//source.CardTarget = target.Id;
					//Trigger.ValidateTriggers(g, source, SequenceType.Target);
					g.TriggerManager.ValidateTriggers(source, SequenceType.Target);
				}


				//Trigger.ValidateTriggers(g, source, SequenceType.PlayCard);
				g.TriggerManager.ValidateTriggers(source, SequenceType.PlayCard);
				switch (source)
				{
					case Hero hero:
						PlayHero.Invoke(c, game, hero, target, chooseOne);
						break;
					case Minion minion:
						PlayMinion.Invoke(c, game, minion, target, zonePosition, chooseOne);
						break;
					case Weapon weapon:
						PlayWeapon.Invoke(c, game, weapon, target, chooseOne);
						break;
					case Spell spell:
						PlaySpell.Invoke(c, game, spell, target, chooseOne);
						break;
				}

				if (echo && !(source is Spell s && s.IsCountered))
				{
					//var echoTags = new EntityData
					//{
					//	{GameTag.GHOSTLY, 1}
					//};
					Playable echoPlayable = Entity.FromCard(c, source.Card, c.HandZone);
					echoPlayable.Ghostly = true;
					echoPlayable.CreatorId = source.Id;

					g.AuraUpdate();

					g.GhostlyCards.Add(echoPlayable.Id);
				}

				if (!c.IsComboActive)
					c.IsComboActive = true;

				c.NumOptionsPlayedThisTurn++;

				if (history)
				{
					if (source.Ghostly)
						source[GameTag.GHOSTLY] = 0;
					g.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());
				}

				game.CurrentEventData = null;

				return true;
			};

		public static Func<Game, Controller, Playable, Character, int, int, bool> PrePlayPhase
			=> delegate (Game g, Controller c, Playable source, Character target, int zonePosition, int chooseOne)
			{
				// can't play because we got already board full
				if (source is Minion && c.BoardZone.IsFull)
				{
					g.Log(LogLevel.WARNING, BlockType.ACTION, "PrePlayPhase", !g.Logging? "":$"Board has already {c.BoardZone.MaxSize} minions.");
					return false;
				}

				// set choose one option
				Playable subSource = chooseOne > 0 ? source.ChooseOnePlayables[chooseOne - 1] : source;

				// check if we can play this card and the target is valid
				if (!source.IsPlayableByPlayer() || !subSource.IsPlayableByCardReq() || !subSource.IsValidPlayTarget(target))
				{
					return false;
				}

				return true;
			};

		public static Func<Game, Controller, Playable, bool> PayPhase
			=> delegate (Game g, Controller c, Playable source)
			{
				int cost = source.Cost;
				if (cost > 0)
				{
					//source[GameTag.TAG_LAST_KNOWN_COST_IN_HAND] = cost;

					if (g.CurrentEventData != null)
						g.CurrentEventData.EventNumber = cost;

					if (source is Spell && c.SpellsCostHealth)
					{
						c.Hero.TakeDamage(c.Hero, cost);
						return true;
					}

					if (source.CardCostsHealth)
					{
						c.Hero.TakeDamage(c.Hero, cost);
						return true;
					}

					int tempUsed = Math.Min(c.TemporaryMana, cost);
					if (tempUsed > 0) c.TemporaryMana -= tempUsed;
					c.UsedMana += cost - tempUsed;
					c.TotalManaSpentThisGame += cost;
					if (source.Card.Type == CardType.SPELL)
						c.TotalManaSpentOnSpells += cost;
				}
				g.Log(LogLevel.INFO, BlockType.ACTION, "PayPhase", !g.Logging? "":$"Paying {source} for {source.Cost} Mana, remaining mana is {c.RemainingMana}.");
				return true;
			};

		public static Func<Game, Controller, Hero, Character, int, bool> PlayHero
			=> delegate (Game g, Controller c, Hero hero, Character target, int chooseOne)
			{
				g.Log(LogLevel.INFO, BlockType.ACTION, "PlayHero", !g.Logging? "":$"{c.Name} plays Hero {hero} {(target != null ? "with target " + target : "to board")}.");


				HeroInPlay oldHero = c.Hero;
				HeroInPlay heroInPlay = HeroInPlay.FromHero(ref hero);
				if (g.History)
					hero[GameTag.ZONE] = (int)Zone.PLAY;
				//hero[GameTag.LINKED_ENTITY] = c.Hero.Id;
				//hero[GameTag.HEALTH] = oldHero[GameTag.HEALTH];
				heroInPlay.BaseHealth = oldHero.BaseHealth;
				//heroInPlay[GameTag.DAMAGE] = oldHero[GameTag.DAMAGE];
				heroInPlay.Damage = oldHero.Damage;
				//heroInPlay[GameTag.ARMOR] = oldHero[GameTag.ARMOR] + heroInPlay.Card[GameTag.ARMOR];
				heroInPlay.Armor = oldHero.Armor + heroInPlay.Card[GameTag.ARMOR];
				heroInPlay.IsExhausted = oldHero.IsExhausted;

				c.SetasideZone.Add(oldHero);
				//oldHero.IsRevealed = true;
				//c[GameTag.HERO_ENTITY] = heroInPlay.Id;
				heroInPlay.Weapon = oldHero.Weapon;
				c.SetasideZone.Add(oldHero.HeroPower);
				heroInPlay.HeroPower = (HeroPower) Entity.FromCard(c, Cards.GetHeroPower(heroInPlay.Card[GameTag.HERO_POWER]));
				heroInPlay.HeroPower.Power?.Trigger?.Activate(g, heroInPlay.HeroPower);

				c.Hero = heroInPlay;
				heroInPlay.Power?.Trigger?.Activate(g, heroInPlay);

				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				g.TriggerManager.OnPlayCardTrigger(heroInPlay);

					// - BattleCry Phase --> Battle Cry Resolves
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				heroInPlay.ActivateTask(PowerActivation.POWER, target, chooseOne);
				// check if [LOE_077] Brann Bronzebeard aura is active
				if (c.ExtraBattlecry)
				{
					heroInPlay.ActivateTask(PowerActivation.POWER, target);
				}
				if (heroInPlay.HeroPower.IsPassiveHeroPower)  // Valeera, ad hoc for now; Maybe revisit here for Bosses
					heroInPlay.HeroPower.ActivateTask();
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();

				// - After Play Phase --> After play Trigger / Secrets (Mirror Entity)
				//   (death processing, aura updates)
				//heroInPlay.JustPlayed = false;

				g.TriggerManager.OnAfterPlayCardTrigger(heroInPlay);

				return true;
			};

		public static Func<Game, Controller, Minion, Character, int, int, bool> PlayMinion
			=> delegate (Game g, Controller c, Minion minion, Character target, int zonePosition, int chooseOne)
			{
				//Trigger.ValidateTriggers(g, minion, SequenceType.PlayMinion);
				g.TriggerManager.ValidateTriggers(minion, SequenceType.PlayMinion);
				TriggerManager triggerManager = g.TriggerManager;

				game.Log(LogLevel.INFO, BlockType.ACTION, "PlayMinion", !game.Logging? "":$"{c.Name} plays Minion {minion} {(target != null ? "with target " + target : "to board")} " +
						 $"{(zonePosition > -1 ? "position " + zonePosition : "")}.");

				c.NumMinionsPlayedThisTurn++;

				c.BoardZone.Add(ref minion, zonePosition);
				g.CurrentEventData.EventSource = minion;

				// - PreSummon Phase --> PreSummon Phase Trigger (Tidecaller)
				//   (death processing, aura updates)
				// not Implemented

				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				game.TaskQueue.StartEvent();
				game.TriggerManager.OnPlayMinionTrigger(minion);
				OnPlayTrigger.Invoke(game, minion);

				// - Summon Resolution Step (Work in Process)
				triggerManager.OnSummonTrigger(minion);

				// Noggenfogger here
				if (target != null && g.TriggerManager.OnTargetTrigger(minion))
					//target = (Character) g.IdEntityDic[minion.CardTarget];
					target = (Character) g.CurrentEventData.EventTarget;

				// - BattleCry Phase --> Battle Cry Resolves
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				if (minion.Combo && c.IsComboActive)
				{
					minion.ActivateTask(PowerActivation.COMBO, target);
					if (c.ExtraBattleCryAndCombo)
						minion.ActivateTask(PowerActivation.COMBO, target);
				}
				else
					minion.ActivateTask(PowerActivation.POWER, target, chooseOne);

				// check if [LOE_077] Brann Bronzebeard aura is active
				if ((c.ExtraBattlecry || c.ExtraBattleCryAndCombo) && minion.HasBattleCry)
				{
					minion.ActivateTask(PowerActivation.POWER, target, chooseOne);
				}
                OverloadBlock(c, minion, g.History);
                
                g.ProcessTasks();
				g.TaskQueue.EndEvent();
				g.DeathProcessingAndAuraUpdate();

				minion = (Minion)g.CurrentEventData.EventSource;

				// - After Play Phase --> After play Trigger / Secrets (Mirror Entity)
				//   (death processing, aura updates)
				// - After Summon Phase --> After Summon Trigger
				//   (death processing, aura updates)
				game.TaskQueue.StartEvent();
				game.TriggerManager.OnAfterPlayCardTrigger(minion);
				AfterSummonTrigger.Invoke(game, minion, null);
				game.ProcessTasks();
				game.TaskQueue.EndEvent();


				if (minion.IsRace(Race.ELEMENTAL))
					c.NumElementalsPlayedThisTurn++;
				else if (minion.IsRace(Race.MURLOC))
					c.NumMurlocsPlayedThisGame++;
				else if (minion.IsRace(Race.TOTEM))
					c.NumTotemSummonedThisGame++;

				return true;
			};

		public static Func<Game, Controller, Spell, Character, int, bool> PlaySpell
			=> delegate (Game g, Controller c, Spell spell, Character target, int chooseOne)
			{
				//Trigger.ValidateTriggers(g, spell, SequenceType.PlaySpell);
				g.TriggerManager.ValidateTriggers(spell, SequenceType.PlaySpell);
				TriggerManager triggerManager = g.TriggerManager;

				if (g.History)
				{
					if (spell.IsSecret || spell.IsQuest)
						spell[GameTag.ZONE] = (int)Zone.SECRET;
					else
						spell[GameTag.ZONE] = (int)Zone.PLAY;
				}

				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				game.TaskQueue.StartEvent();
				game.TriggerManager.OnCastSpellTrigger(spell);
				OnPlayTrigger.Invoke(game, spell);

				g.Log(LogLevel.INFO, BlockType.ACTION, "PlaySpell", !g.Logging? "":$"{c.Name} plays Spell {spell} {(target != null ? "with target " + target.Card : "to board")}.");

				// check the spell is countered
				if (spell.IsCountered)
				{
					g.Log(LogLevel.INFO, BlockType.ACTION, "PlaySpell", !g.Logging ? "" : $"Spell {spell} has been countred.");
					c.GraveyardZone.Add(spell);
				}
				else
				{
					// check Spellbender and Mayor Noggenfogger
					if (target != null && triggerManager.OnTargetTrigger(spell))
					{
						//target = (Character)g.IdEntityDic[spell.CardTarget];
						target = (Character) g.CurrentEventData.EventTarget;
						g.Log(LogLevel.DEBUG, BlockType.ACTION, "PlaySpell", !g.Logging ? "" : $"trigger Spellbender Phase. Target of {spell} is changed to {target}.");
					}

					CastSpell.Invoke(c, game, spell, target, chooseOne);
					game.DeathProcessingAndAuraUpdate();
				}
				
				// trigger After Play Phase
				g.Log(LogLevel.DEBUG, BlockType.ACTION, "PlaySpell", !g.Logging? "":"trigger After Play Phase");
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnAfterCastTrigger(spell);
				g.TriggerManager.OnAfterPlayCardTrigger(spell);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				c.NumSpellsPlayedThisGame++;
				if (spell.IsSecret)
					c.NumSecretsPlayedThisGame++;

				game.DeathProcessingAndAuraUpdate();

				return true;
			};

		public static Func<Game, Controller, Weapon, Character, int, bool> PlayWeapon
			=> delegate (Game g, Controller c, Weapon weapon, Character target, int chooseOne)
			{
				game.Log(LogLevel.INFO, BlockType.ACTION, "PlayWeapon", !game.Logging ? "" : $"{c.Hero} gets Weapon {c.Hero.Weapon}.");

				//c.Hero.AddWeapon(weapon);

				if (g.History)
					weapon[GameTag.ZONE] = (int) Zone.PLAY;

				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				game.TaskQueue.StartEvent();
				OnPlayTrigger.Invoke(game, weapon);

				// not sure... need some test
				weapon.Card.Power?.Aura?.Activate(weapon);
				weapon.Card.Power?.Trigger?.Activate(g, weapon);


				if (target != null && g.TriggerManager.OnTargetTrigger(weapon))
				{
					//if (target.Id != weapon.CardTarget)
					//	target = (Character) g.IdEntityDic[weapon.CardTarget];
					target = (Character) g.CurrentEventData.EventTarget;
				}

				OverloadBlock(c, weapon, g.History);

				// - Equipping Phase --> Resolve Battlecry, OnDeathTrigger
				// activate battlecry
				if (g.History)
					g.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.POWER, weapon.Id, "", -1, 0));

				g.TaskQueue.StartEvent();
				weapon.ActivateTask(PowerActivation.POWER, target);
				if (c.ExtraBattlecry && weapon.Card[GameTag.BATTLECRY] == 1)
					weapon.ActivateTask(PowerActivation.POWER, target);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				if (g.History)
					g.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());

				// equip new weapon here
				g.TaskQueue.StartEvent();
				// destroy old weapon
				// equip new weapon
				// weapon's deathrattle task queues up here
				c.Hero.AddWeapon(weapon);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				// deathprocessing;
				g.DeathProcessingAndAuraUpdate();

				// trigger After Play Phase
				g.Log(LogLevel.DEBUG, BlockType.ACTION, "PlayWeapon", !g.Logging? "":"trigger After Play Phase");
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnAfterPlayCardTrigger(weapon);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();

				c.NumWeaponsPlayedThisGame++;

				return true;
			};

		private static Action<Game, IPlayable> OnPlayTrigger
			=> delegate (Game game, IPlayable playable)
			{
				//playable.JustPlayed = true;
				game.TriggerManager.OnPlayCardTrigger(playable);
				game.ProcessTasks();
				game.TaskQueue.EndEvent();

				game.DeathProcessingAndAuraUpdate();
			};
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
