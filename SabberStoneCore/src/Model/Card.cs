﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using System;
using SabberStoneCore.Loader;

namespace SabberStoneCore.Model
{
	/// <summary>
	/// Object representing a known entity.
	///
	/// All properties exposed by these instances are defined by `resources/Data/CardDefs.xml`.
	/// <see cref="CardLoader"/> for extraction procedures.
	/// </summary>
	public class Card
	{
		/// <summary>
		/// 
		/// </summary>
		public int ATK { get; }
		public int Health { get; }
		public bool Taunt { get; }
		public bool Charge { get; }
		public bool Stealth { get; }
		public bool CantBeTargetedBySpells { get; }
		public bool CantBeTargetedByHeroPowers => CantBeTargetedBySpells;
		public bool CantAttack { get; }
		public bool ChooseOne { get; }
		public bool IsSecret { get; }
		public bool IsQuest { get; }
		public bool Untouchable { get; }
		public bool HideStat { get; }
		public bool ReceivesDoubleSpelldamageBonus { get; }

		private Card()
		{

		}

		internal Card(string id, int assetId, Tag[] tags,
			Dictionary<PlayReq, int> playRequirements, string[] entourage, Tag[] refTags)
		{
			Id = id;
			AssetId = assetId;
			Entourage = entourage;
			PlayRequirements = playRequirements;
			var tagDict = new Dictionary<GameTag, int>();
			var refTagDict = new Dictionary<GameTag, int>();

			// Preprocessing tags.
			foreach (Tag tag in tags)
			{
				if (tag.TagValue.HasIntValue)
				{
					tagDict.Add(tag.GameTag, tag.TagValue);
					switch (tag.GameTag)
					{
						case GameTag.COST:
							Cost = tag.TagValue;
							break;
						case GameTag.ATK:
							ATK = tag.TagValue;
							break;
						case GameTag.HEALTH:
							Health = tag.TagValue;
							break;
						case GameTag.OVERLOAD:
							HasOverload = true;
							Overload = tag.TagValue;
							break;
						case GameTag.CHOOSE_ONE:
							ChooseOne = true;
							break;
						case GameTag.TAUNT:
							Taunt = true;
							break;
						case GameTag.CHARGE:
							Charge = true;
							break;
						case GameTag.STEALTH:
							Stealth = true;
							break;
						case GameTag.CANT_BE_TARGETED_BY_SPELLS:
							CantBeTargetedBySpells = true;
							break;
						case GameTag.CANT_ATTACK:
							CantAttack = true;
							break;
						case GameTag.SECRET:
							IsSecret = true;
							break;
						case GameTag.QUEST:
							IsQuest = true;
							break;
						case GameTag.UNTOUCHABLE:
							Untouchable = true;
							break;
						case GameTag.HIDE_STATS:
							HideStat = true;
							break;
						case GameTag.RECEIVES_DOUBLE_SPELLDAMAGE_BONUS:
							ReceivesDoubleSpelldamageBonus = true;
							break;
						case GameTag.CARDRACE:
							Race = (Race)(int)tag.TagValue;
							break;
						case GameTag.CLASS:
							Class = (CardClass)(int)tag.TagValue;
							break;
					}
				}
				else if
					(tag.TagValue.HasBoolValue)
				{
					tagDict.Add(tag.GameTag, tag.TagValue ? 1 : 0);
				}
				else if
					(tag.TagValue.HasStringValue)
				{
					switch (tag.GameTag)
					{
						case GameTag.CARDNAME:
							Name = tag.TagValue;
							break;
						case GameTag.CARDTEXT:
							Text = tag.TagValue;
							break;
					}
				}
			}
			foreach (Tag tag in refTags)
			{
				if (refTagDict.ContainsKey(tag.GameTag))
					continue;

				if (tag.TagValue.HasIntValue)
				{
					refTagDict.Add(tag.GameTag, tag.TagValue);
				}
				else if (tag.TagValue.HasBoolValue)
				{
					refTagDict.Add(tag.GameTag, tag.TagValue ? 1 : 0);
				}
			}

			#region Preprocessing requirements
			//var results = new bool[6];
			//Predicate<ICharacter> targetPredicate;
			//Predicate<Controller> checkTargeting;
			//Predicate<Controller> checkPlayablility;
			//foreach (KeyValuePair<PlayReq, int> requirement in playRequirements)
			//{
			//	switch (requirement.Key)
			//	{
			//		case PlayReq.REQ_TARGET_TO_PLAY:
			//			results[0] = true;
			//			break;
			//		case PlayReq.REQ_DRAG_TO_PLAY:  // TODO
			//		case PlayReq.REQ_NONSELF_TARGET:
			//		case PlayReq.REQ_TARGET_IF_AVAILABLE:
			//			results[1] = true;
			//			break;
			//		case PlayReq.REQ_MINION_TARGET:
			//			results[2] = true;
			//			break;
			//		case PlayReq.REQ_FRIENDLY_TARGET:
			//			results[3] = true;
			//			break;
			//		case PlayReq.REQ_ENEMY_TARGET:
			//			results[4] = true;
			//			break;
			//		case PlayReq.REQ_HERO_TARGET:
			//			results[5] = true;
			//			break;
			//		case PlayReq.REQ_TARGET_WITH_RACE:
			//			targetPredicate = p => (int)p.Race == requirement.Value;
			//			break;
			//		case PlayReq.REQ_FROZEN_TARGET:
			//			targetPredicate = p => p.IsFrozen;
			//			break;
			//		case PlayReq.REQ_DAMAGED_TARGET:
			//			targetPredicate = p => p.Damage > 0;
			//			break;
			//		case PlayReq.REQ_UNDAMAGED_TARGET:
			//			targetPredicate = p => p.Damage == 0;
			//			break;
			//		case PlayReq.REQ_TARGET_MAX_ATTACK:
			//			targetPredicate = p => p.AttackDamage <= requirement.Value;
			//			break;
			//		case PlayReq.REQ_TARGET_MIN_ATTACK:
			//			targetPredicate = p => p.AttackDamage >= requirement.Value;
			//			break;
			//		case PlayReq.REQ_MUST_TARGET_TAUNTER:
			//			targetPredicate = p => p.HasTaunt;
			//			break;
			//		case PlayReq.REQ_STEALTHED_TARGET:
			//			targetPredicate = p => p[GameTag.STEALTH] == 1;
			//			break;
			//		case PlayReq.REQ_TARGET_WITH_DEATHRATTLE:
			//			targetPredicate = p => p.HasDeathrattle;
			//			break;
			//		case PlayReq.REQ_TARGET_FOR_COMBO:
			//			checkTargeting = p => p.IsComboActive;
			//			break;
			//		case PlayReq.REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN:
			//			checkTargeting = p => p.NumElementalsPlayedLastTurn > 0;
			//			break;
			//		case PlayReq.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND:
			//			checkTargeting = p => p.DragonInHand;
			//			break;
			//		case PlayReq.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS:
			//			checkTargeting = p => p.BoardZone.Count >= requirement.Value;
			//			break;
			//		case PlayReq.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS:
			//			checkTargeting = p => p.SecretZone.Count >= requirement.Value;
			//			break;
			//		case PlayReq.REQ_TARGET_IF_AVAILABLE_AND_NO_3_COST_CARD_IN_DECK:
			//			results[1] = true;  //  TODO
			//			break;
			//		case PlayReq.REQ_NUM_MINION_SLOTS:
			//			checkPlayablility = p => (p.BoardZone.FreeSpace >= requirement.Value);
			//			break;
			//		case PlayReq.REQ_MINIMUM_ENEMY_MINIONS:
			//			checkPlayablility = p => p.Opponent.BoardZone.Count >= requirement.Value;
			//			break;
			//		case PlayReq.REQ_MINIMUM_TOTAL_MINIONS:
			//			checkPlayablility = p => p.BoardZone.Count + p.Opponent.BoardZone.Count >= requirement.Value;
			//			break;
			//		case PlayReq.REQ_HAND_NOT_FULL:
			//			checkPlayablility = p => !p.HandZone.IsFull;
			//			break;
			//		case PlayReq.REQ_WEAPON_EQUIPPED:
			//			checkPlayablility = p => p.Hero.Weapon != null;
			//			break;
			//		case PlayReq.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY:
			//			checkPlayablility = p =>
			//			{
			//				var ent = Entourage;
			//				int count = ent.Length;
			//				if (p.BoardZone.Count >= count)
			//				{
			//					int[] indices = new int[count];
			//					ReadOnlySpan<Minion> span = p.BoardZone.GetSpan();
			//					for (int i = 0, j = span.Length, k = 0; i < span.Length; i++)
			//					{
			//						int index = Array.IndexOf(entourage, span[i].Card.Id);
			//						if (index < 0)
			//						{
			//							if (--j < count)
			//								break;
			//							continue;
			//						}

			//						bool flag = false;
			//						for (int l = 0; l < k; l++)
			//						{
			//							if (indices[l] != index) continue;
			//							flag = true;
			//							break;
			//						}

			//						if (flag)
			//						{
			//							if (--j < count)
			//								break;
			//						}
			//						else
			//						{
			//							indices[k++] = index;
			//							if (k == count)
			//								return false;
			//						}
			//					}
			//				}
			//				return true;
			//			};
			//			break;
			//		case PlayReq.REQ_FRIENDLY_MINION_DIED_THIS_GAME:
			//			checkPlayablility = p => p.GraveyardZone.Any(q => q.ToBeDestroyed);
			//			break;
			//		case PlayReq.REQ_MUST_PLAY_OTHER_CARD_FIRST:
			//			checkPlayablility = p => false;
			//			break;
			//		//	REQ_STEADY_SHOT
			//		//	REQ_MINION_OR_ENEMY_HERO	//	Steady Shot
			//		//	REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT	//	Jade Blossom
			//		case PlayReq.REQ_SECRET_ZONE_CAP_FOR_NON_SECRET:
			//			checkPlayablility = p => !p.SecretZone.IsFull;
			//			break;
			//	}
			//}
			#endregion


			Tags = tagDict;
			RefTags = refTagDict;
			// spell damage information add ... 
			if (Text != null && (Text.Contains("$") || tagDict.ContainsKey(GameTag.AFFECTED_BY_SPELL_POWER)))
			{
				Text += " @spelldmg";
				IsAffectedBySpellDamage = true;
			}
		}

		/// <summary>
		/// Unique asset id of that card nummeric representation.
		/// </summary>
		public int AssetId { get; }

		/// <summary>
		/// Unique card ID, as defined in
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// Name of the card, localized in the extracted language.
		/// </summary>
		public string Name { get; internal set; }

		/// <summary>
		/// Flavour text of the card, localized in the extracted language.
		/// </summary>
		public string Text { get; internal set; }

		/// <summary>
		/// Contains all card ID's which are generated by this specific card.
		///
		/// For example Ysera, the dragon which produces on DREAM card after your turn,
		/// has entourage: DREAM_01, DREAM_02, DREAM_03, DREAM_04, DREAM_05
		/// </summary>
		public string[] Entourage { get; }

		/// <summary>
		/// Properties set on this instance.
		/// These properties represent health, attack, # turns in play etc.
		/// <see cref="GameTag"/> for all possibilities.
		/// </summary>
		public Dictionary<GameTag, int> Tags { get; private set; }

		/// <summary>
		/// Declares all effects that are triggered by this instance.
		/// Possibilities are SpellPower, DeathRattle, Charge etc.
		/// </summary>
		public Dictionary<GameTag, int> RefTags { get; private set; }

		/// <summary>
		/// Requirements that must have been met before this card can be moved into
		/// play zone.
		/// <see cref="PlayReq"/> for all possibilities.
		/// </summary>
		public Dictionary<PlayReq, int> PlayRequirements { get; private set; }

		/// <summary>
		/// Provides easy access to the value of a specific Tag set on this instance.
		/// <seealso cref="Tags"/>
		/// </summary>
		/// <param name="t">The <see cref="GameTag"/> which value is queried</param>
		/// <returns></returns>
		public int this[GameTag t]
			=> Tags.TryGetValue(t, out int value) ? value : 0;

		/// <summary>
		/// Indicates if this card occurs in the player's collection. Only collectible
		/// cards can be put together in a deck.
		///
		/// Non-collectible cards are generated during the game, like Ysera's Dream cards.
		/// </summary>
		public bool Collectible => this[GameTag.COLLECTIBLE] == 1;

		/// <summary>
		/// A card can have NO class or AT MOST one.
		/// The cardclass is coupled with the chosen hero to represent the player.
		///
		/// Cards with a specific class can NOT be put into a deck with other classcards.
		/// <seealso cref="CardClass"/>
		/// </summary>
		public CardClass Class { get; }

		/// <summary>
		/// <see cref="Race"/>
		/// </summary>
		public Race Race { get; }

		/// <summary>
		/// <see cref="Faction"/>
		/// </summary>
		public Faction Faction => (Faction)this[GameTag.FACTION];

		/// <summary>
		/// Indicates if this card has a combo effect or not.
		/// </summary>
		public bool HasCombo => this[GameTag.COMBO] == 1;

		/// <summary>
		/// <see cref="Rarity"/>
		/// </summary>
		public Rarity Rarity => (Rarity)this[GameTag.RARITY];

		/// <summary>
		/// The actual type of a card has limitations on it's usage.
		/// A hero card cannot be put into a deck for example.. imagine that!
		/// Knights of the Frozen Throne , is beyond imagination? With
		/// Deathknigth heros in the deck!
		/// <see cref="CardType"/>
		/// </summary>
		public CardType Type => (CardType)this[GameTag.CARDTYPE];

		/// <summary>
		/// <see cref="CardSet"/>
		/// </summary>
		public CardSet Set => (CardSet)this[GameTag.CARD_SET];

		/// <summary>
		/// Original mana-cost of this card.
		/// </summary>
		public int Cost { get; }

		/// <summary>
		/// True if this card will incur Overload when played.
		/// Overload is an effect that locks mana crystals.
		/// Locked mana crystals can't be spent during one turn.
		/// </summary>
		public bool HasOverload { get; internal set; }

		/// <summary>
		/// The amount of overload incurred by this card when played.
		/// </summary>
		public int Overload { get; internal set; }

		/// <summary>
		/// Returns to which multi class group this card belongs.
		/// <see cref="MultiClassGroup"/>
		/// </summary>
		public bool RequiresTarget => PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_TO_PLAY);

		/// <summary>
		/// Requires a target for combo
		/// </summary>
		public bool RequiresTargetForCombo => PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_FOR_COMBO);

		/// <summary>
		/// Requires a target if available
		/// </summary>
		public bool RequiresTargetIfAvailable => PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_IF_AVAILABLE) ||
		                                         PlayRequirements.ContainsKey(PlayReq.REQ_DRAG_TO_PLAY);

		/// <summary>
		/// Requires a target if available and dragon in hand
		/// </summary>
		public bool RequiresTargetIfAvailableAndDragonInHand
			=> PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND);

		/// <summary>
		/// Requires a target if available and element played last turn
		/// </summary>
		public bool RequiresTargetIfAvailableAndElementalPlayedLastTurn
			=> PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN);

		/// <summary>
		/// Requires a target if available and minimum friendly minions
		/// </summary>
		public bool RequiresTargetIfAvailableAndMinimumFriendlyMinions
			=> PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS);

		/// <summary>
		/// Requires a target if available and minimum friendly secrets
		/// </summary>
		public bool RequiresTargetIfAvailableAndMinimumFriendlySecrets
			=> PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS);

		public bool RequiresTargetIfAvailableAndNo3CostCardInDeck
			=> PlayRequirements.ContainsKey(PlayReq.REQ_TARGET_IF_AVAILABLE_AND_NO_3_COST_CARD_IN_DECK);

		/// <summary>
		/// Maximum amount of copies that are allowed in one deck.
		/// </summary>
		public int MaxAllowedInDeck => Rarity == Rarity.LEGENDARY ? 1 : 2;

		/// <summary>
		/// True if the effects of this card are implemented.
		/// </summary>
		public bool Implemented { get; set; }

		/// <summary>
		/// Holds a list of Buffs/Debuffs on this card instance.
		/// <seealso cref="Power"/>
		/// </summary>
		//public List<Power> Powers { get; set; } = new List<Power>();
		public Power Power { get; set; }

		/// <summary>
		/// True if this card increases it's owners spell damage.
		/// </summary>
		public bool IsAffectedBySpellDamage { get; set; }

		/// <summary>
		/// Multi class group.
		/// </summary>
		public int MultiClassGroup => this[GameTag.MULTI_CLASS_GROUP];

		/// <summary>
		/// Returns a string representation.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"[{Name}]";
		}
		/// <summary>
		/// Returns a substring of the name of this instance.
		/// </summary>
		/// <param name="size">The maximum length of the substring in # characters.</param>
		/// <returns></returns>
		public string AbbreviatedName(int size)
		{
			if (Name.Length <= size)
			{
				return Name;
			}
			else if (!Name.Contains(" "))
			{
				return Name.Substring(0, size);
			}
			else
			{
				string[] strArray = Name.Split(' ');
				return String.Join("", strArray.Select(p => p.Length > 4 ? p.Substring(0, 4) : p).ToList()).Substring(0, 7);
			}

		}

		/// <summary>
		/// Returns a string containing all information about this instance.
		/// </summary>
		/// <param name="gameTag"></param>
		/// <param name="playReq"></param>
		/// <returns></returns>
		public string FullPrint(bool gameTag = false, bool playReq = false)
		{
			var builder = new StringBuilder();
			builder.Append($"[CARD: {Name} - {Id} (Col={Collectible},Set={Set})]");
			if (gameTag)
			{
				builder.Append("\n   GameTags:");
				Tags.ToList().ForEach(pair => builder.Append($"\n   - {pair.Key} -> {pair.Value}"));
			}
			if (playReq)
			{
				builder.Append("\n   PlayReq:");
				PlayRequirements.ToList().ForEach(pair => builder.Append($"\n   - {pair.Key} -> {pair.Value}"));
			}
			return builder.ToString();
		}

		internal static readonly Card CardGame = new Card()
		{
			Id = "Game",
			Name = "Game",
			Tags = new Dictionary<GameTag, int> { [GameTag.CARDTYPE] = (int)CardType.GAME },
			//PlayRequirements = new Dictionary<PlayReq, int>(),
		};

		internal static readonly Card CardPlayer = new Card()
		{
			Id = "Player",
			Name = "Player",
			Tags = new Dictionary<GameTag, int> { [GameTag.CARDTYPE] = (int)CardType.PLAYER },
			//PlayRequirements = new Dictionary<PlayReq, int>(),
		};

		public Card Clone()
		{
			var clone = (Card)MemberwiseClone();
			clone.Tags = new Dictionary<GameTag, int>(Tags);
			clone.RefTags = new Dictionary<GameTag, int>(RefTags);
			return clone;
		}

		//public readonly bool[] _requirements;
		//public readonly Predicate<ICharacter> _targetPredicate;
		//public readonly Predicate<Controller> _checkTargeting;
		//public readonly Predicate<Controller> _checkPlayablility;
	}
}
