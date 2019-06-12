using System;
using SabberStoneCore.Enchants;
using SabberStoneCore.Model;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Actions
{
	public static partial class Generic
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	{
		public static bool PlayCard(Game g, Controller c, IPlayable source, ICharacter target = null, int zonePosition = -1, int chooseOne = 0, bool skipPrePhase = false)
		{
			return PlayCardBlock.Invoke(g, c, source, target, zonePosition, chooseOne, skipPrePhase);
		}

		public static Func<Game, Controller, IPlayable, ICharacter, int, int, bool, bool> PlayCardBlock
			=> delegate (Game g, Controller c, IPlayable source, ICharacter target, int zonePosition, int chooseOne, bool skipPrePhase)
			{
				// Preplay Phase : check the given source is playable
				if (!skipPrePhase)
					if (!PrePlayPhase.Invoke(g, c, source, target, zonePosition, chooseOne))
						return false;

				// Start play block
				if (g.History)
					g.PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.PLAY, source.Id, "", 0, target?.Id ?? 0));

				g.CurrentEventData = new EventMetaData(source, target);

				// Pay Phase
				if (!PayPhase.Invoke(g, c, source))
					return false;

				// remove from hand zone
				if (source is Spell)
					source[GameTag.TAG_LAST_KNOWN_COST_IN_HAND] = source.Cost;

				bool echo = source.IsEcho;

				//if (!RemoveFromZone.Invoke(c, source))
				//	return false;
				c.HandZone.Remove(source);

				c.NumCardsPlayedThisTurn++;
				c.LastCardPlayed = source.Id;

				// Check Overload
				if (source.Card.HasOverload)
				{
					int amount = source.Overload;
					c.OverloadOwed += amount;
					c.OverloadThisGame += amount;
					g.CurrentEventData.EventNumber = amount;
				}

				// record played cards for effect of cards like Obsidian Shard and Lynessa Sunsorrow
				// or use graveyard instead with 'played' tag(or bool)?
				c.CardsPlayedThisTurn.Add(source.Card);
				c.PlayHistory.Add(new PlayHistoryEntry(in source, in target, in chooseOne));

				//// show entity
				//if (g.History)
				//	g.PowerHistory.Add(PowerHistoryBuilder.ShowEntity(source));

				// target is beeing set onto this gametag
				if (target != null)
				{
					source.CardTarget = target.Id;
					Trigger.ValidateTriggers(g, source, SequenceType.Target);
				}


				Trigger.ValidateTriggers(g, source, SequenceType.PlayCard);
				switch (source)
				{
					case Hero hero:
						PlayHero.Invoke(g, c, hero, target, chooseOne);
						break;
					case Minion minion:
						PlayMinion.Invoke(g, c, minion, target, zonePosition, chooseOne);
						break;
					case Weapon weapon:
						PlayWeapon.Invoke(g, c, weapon, target, chooseOne);
						break;
					case Spell spell:
						PlaySpell.Invoke(g, c, spell, target, chooseOne);
						break;
				}

				if (echo && !(source is Spell s && s.IsCountered))
				{
					var echoTags = new EntityData
					{
						{GameTag.GHOSTLY, 1}
					};
					IPlayable echoPlayable = Entity.FromCard(c, source.Card, echoTags, c.HandZone);
					echoPlayable[GameTag.DISPLAYED_CREATOR] = source.Id;

					g.AuraUpdate();

					g.GhostlyCards.Add(echoPlayable.Id);
				}

				c.NumOptionsPlayedThisTurn++;

				if (!c.IsComboActive)
					c.IsComboActive = true;

				if (g.History)
				{
					if (source[GameTag.GHOSTLY] == 1)
						source[GameTag.GHOSTLY] = 0;
					g.PowerHistory.Add(PowerHistoryBuilder.BlockEnd());
				}

				g.CurrentEventData = null;


				return true;
			};

		public static Func<Game, Controller, IPlayable, ICharacter, int, int, bool> PrePlayPhase
			=> delegate (Game g, Controller c, IPlayable source, ICharacter target, int zonePosition, int chooseOne)
			{
				// can't play because we got already board full
				if (source is Minion && c.BoardZone.IsFull)
				{
					g.Log(LogLevel.WARNING, BlockType.ACTION, "PrePlayPhase", !g.Logging? "":$"Board has already {c.BoardZone.MaxSize} minions.");
					return false;
				}

				// set choose one option
				IPlayable subSource = chooseOne > 0 ? source.ChooseOnePlayables[chooseOne - 1] : source;

				// check if we can play this card and the target is valid
				if (!source.IsPlayableByPlayer || !subSource.IsPlayableByCardReq || !subSource.IsValidPlayTarget(target))
				{
					return false;
				}

				return true;
			};

		public static Func<Game, Controller, IPlayable, bool> PayPhase
			=> delegate (Game g, Controller c, IPlayable source)
			{
				int cost = source.Cost;
				if (cost > 0)
				{
					if (source is Spell && c.ControllerAuraEffects[GameTag.SPELLS_COST_HEALTH] == 1)
					{
						c.Hero.TakeDamage(c.Hero, cost);
						return true;
					}

					if (source.AuraEffects?.CardCostHealth ?? false)
					{
						c.Hero.TakeDamage(c.Hero, cost);
						return true;
					}

					int tempUsed = Math.Min(c.TemporaryMana, cost);
					c.TemporaryMana -= tempUsed;
					c.UsedMana += cost - tempUsed;
					c.TotalManaSpentThisGame += cost;
				}
				g.Log(LogLevel.INFO, BlockType.ACTION, "PayPhase", !g.Logging? "":$"Paying {source} for {source.Cost} Mana, remaining mana is {c.RemainingMana}.");
				return true;
			};

		public static Func<Game, Controller, Hero, ICharacter, int, bool> PlayHero
			=> delegate (Game g, Controller c, Hero hero, ICharacter target, int chooseOne)
			{
				g.Log(LogLevel.INFO, BlockType.ACTION, "PlayHero", !g.Logging? "":$"{c.Name} plays Hero {hero} {(target != null ? "with target " + target : "to board")}.");


				Hero oldHero = c.Hero;
				hero[GameTag.ZONE] = (int)Zone.PLAY;
				//hero[GameTag.LINKED_ENTITY] = c.Hero.Id;
				//hero[GameTag.HEALTH] = oldHero[GameTag.HEALTH];
				hero.BaseHealth = oldHero.BaseHealth;
				//hero[GameTag.DAMAGE] = oldHero[GameTag.DAMAGE];
				hero.Damage = oldHero.Damage;
				hero[GameTag.ARMOR] = oldHero[GameTag.ARMOR] + hero.Card[GameTag.ARMOR];
				hero.IsExhausted = oldHero.IsExhausted;

				c.SetasideZone.Add(oldHero);
				//oldHero[GameTag.REVEALED] = 1;
				//c[GameTag.HERO_ENTITY] = hero.Id;
				hero.Weapon = oldHero.Weapon;
				c.SetasideZone.Add(oldHero.HeroPower);
				hero.HeroPower = (HeroPower) Entity.FromCard(c, Cards.GetHeroPower(hero.Card[GameTag.HERO_POWER]));
				hero.HeroPower.Power?.Trigger?.Activate(g, hero.HeroPower);

				c.Hero = hero;
				hero.Power?.Trigger?.Activate(g, hero);

				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				OnPlayTrigger.Invoke(g, c, hero);

				// - BattleCry Phase --> Battle Cry Resolves
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				hero.ActivateTask(PowerActivation.POWER, target, chooseOne);
				// check if [LOE_077] Brann Bronzebeard aura is active
				if (c.ExtraBattlecry)
				{
					hero.ActivateTask(PowerActivation.POWER, target);
				}
				if (hero.HeroPower.IsPassiveHeroPower)  // Valeera, ad hoc for now; Maybe revisit here for Bosses
					hero.HeroPower.ActivateTask();
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();

				// - After Play Phase --> After play Trigger / Secrets (Mirror Entity)
				//   (death processing, aura updates)
				//hero.JustPlayed = false;
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnAfterPlayCardTrigger(hero);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();

				return true;
			};

		public static Func<Game, Controller, Minion, ICharacter, int, int, bool> PlayMinion
			=> delegate (Game g, Controller c, Minion minion, ICharacter target, int zonePosition, int chooseOne)
			{
				Trigger.ValidateTriggers(g, minion, SequenceType.PlayMinion);

				g.Log(LogLevel.INFO, BlockType.ACTION, "PlayMinion", !g.Logging? "":$"{c.Name} plays Minion {minion} {(target != null ? "with target " + target : "to board")} " +
						 $"{(zonePosition > -1 ? "position " + zonePosition : "")}.");

				c.NumMinionsPlayedThisTurn++;
				c.BoardZone.Add(minion, zonePosition);

				// - PreSummon Phase --> PreSummon Phase Trigger (Tidecaller)
				//   (death processing, aura updates)
				// not Implemented

				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnPlayMinionTrigger(minion);
				OnPlayTrigger.Invoke(g, c, minion);

				// - Summon Resolution Step (Work in Process)
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnSummonTrigger(minion);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				// Noggenfogger here
				if (target != null)
				{
					g.TaskQueue.StartEvent();
					g.TriggerManager.OnTargetTrigger(minion);
					g.ProcessTasks();
					g.TaskQueue.EndEvent();
					if (minion.CardTarget != target.Id)
						target = (ICharacter)g.IdEntityDic[minion.CardTarget];
				}

				// - BattleCry Phase --> Battle Cry Resolves
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				if (minion.Combo && c.IsComboActive)
					minion.ActivateTask(PowerActivation.COMBO, target);
				else
					minion.ActivateTask(PowerActivation.POWER, target, chooseOne);
				// check if [LOE_077] Brann Bronzebeard aura is active
				if (c.ExtraBattlecry && minion.HasBattleCry)
				//if (minion[GameTag.BATTLECRY] == 2)
				{
					minion.ActivateTask(PowerActivation.POWER, target, chooseOne);
				}
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();

				minion = (Minion)g.CurrentEventData.EventSource;

				// - After Play Phase --> After play Trigger / Secrets (Mirror Entity)
				//   (death processing, aura updates)
				//minion.JustPlayed = false;
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnAfterPlayMinionTrigger(minion);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				// - After Summon Phase --> After Summon Trigger
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnAfterPlayCardTrigger(minion);
				AfterSummonTrigger.Invoke(g, minion);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();

				switch (minion.Race)
				{
					case Race.ELEMENTAL:
						c.NumElementalsPlayedThisTurn++;
						break;
					case Race.MURLOC:
						c.NumMurlocsPlayedThisGame++;
						break;
				}

				return true;
			};

		public static Func<Game, Controller, Spell, ICharacter, int, bool> PlaySpell
			=> delegate (Game g, Controller c, Spell spell, ICharacter target, int chooseOne)
			{
				Trigger.ValidateTriggers(g, spell, SequenceType.PlaySpell);

				if (g.History)
				{
					if (spell.IsSecret || spell.IsQuest)
						spell[GameTag.ZONE] = (int)Zone.SECRET;
					else
						spell[GameTag.ZONE] = (int)Zone.PLAY;
				}

				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnCastSpellTrigger(spell);
				OnPlayTrigger.Invoke(g, c, spell);

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
					if (target != null)
					{
						g.TaskQueue.StartEvent();
						g.TriggerManager.OnTargetTrigger(spell);
						g.ProcessTasks();
						g.TaskQueue.EndEvent();
						if (target.Id != spell.CardTarget)
						{
							target = (ICharacter)g.IdEntityDic[spell.CardTarget];
							g.Log(LogLevel.DEBUG, BlockType.ACTION, "PlaySpell", !g.Logging ? "" : $"trigger Spellbender Phase. Target of {spell} is changed to {target}.");
						}
					}

					CastSpell.Invoke(c, spell, target, chooseOne, false);
					g.DeathProcessingAndAuraUpdate();
				}
				
				// trigger After Play Phase
				g.Log(LogLevel.DEBUG, BlockType.ACTION, "PlaySpell", !g.Logging? "":"trigger After Play Phase");
				g.TaskQueue.StartEvent();
				g.TriggerManager.OnAfterCastTrigger(spell);
				g.TriggerManager.OnAfterPlayCardTrigger(spell);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();

				c.NumSpellsPlayedThisGame++;
				if (spell.IsSecret)
					c.NumSecretsPlayedThisGame++;
				return true;
			};

		public static Func<Game, Controller, Weapon, ICharacter, int, bool> PlayWeapon
			=> delegate (Game g, Controller c, Weapon weapon, ICharacter target, int chooseOne)
			{
				g.Log(LogLevel.INFO, BlockType.ACTION, "PlayWeapon", !g.Logging ? "" : $"{c.Hero} gets Weapon {c.Hero.Weapon}.");

				//c.Hero.AddWeapon(weapon);

				if (g.History)
					weapon[GameTag.ZONE] = (int) Zone.PLAY;


				// - OnPlay Phase --> OnPlay Trigger (Illidan)
				//   (death processing, aura updates)
				g.TaskQueue.StartEvent();
				OnPlayTrigger.Invoke(g, c, weapon);

				// not sure... need some test
				weapon.Card.Power?.Aura?.Activate(weapon);
				weapon.Card.Power?.Trigger?.Activate(g, weapon);


				if (target != null)
				{
					g.TaskQueue.StartEvent();
					g.TriggerManager.OnTargetTrigger(weapon);
					g.ProcessTasks();
					g.TaskQueue.EndEvent();
					if (target.Id != weapon.CardTarget)
						target = (ICharacter) g.IdEntityDic[weapon.CardTarget];
				}

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

		private static Action<Game, Controller, IPlayable> OnPlayTrigger
			=> delegate (Game g, Controller c, IPlayable playable)
			{
				//playable.JustPlayed = true;
				g.TriggerManager.OnPlayCardTrigger(playable);
				g.ProcessTasks();
				g.TaskQueue.EndEvent();

				g.DeathProcessingAndAuraUpdate();
			};
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
