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
using System.Linq;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Model.Entities
{
	public class Enchantment : Playable
	{
		//private int _creatorId;
		//private int _controllerId;
		private bool _isOneTurnActive;
		private int _orderOfPlay;
		private Playable _creator;
		private Card _capturedCard;
		private bool _removed;
		//private IAura _ongoingEffect;

		private Enchantment(in Controller controller, in Card card, in int id)
			: base(in controller, in card, in id)
		{
			//_controllerId = controller.Id;
		}

		private Enchantment(in Controller c, in Enchantment e) : base(in c, e.Card, e.Id)
		{
			_v1 = e._v1;
			_v2 = e._v2;
			//Target = e.Target is Playable ? (Entity) Game.IdEntityDic[e.Target.Id] : c;
			Target = e.Target is Playable
				? (Entity) Game.IdEntityDic[e.Target.Id]
				: Game.ControllerById(e.Target.Id);
			Target.AppliedEnchantments?.Add(this);
			//_controllerId = e._controllerId;
			_isOneTurnActive = e._isOneTurnActive;
			_orderOfPlay = e._orderOfPlay;
			_creatorId = e._creatorId;
			_capturedCard = e._capturedCard;

			if (e.IsOneTurnActive)
				Game.OneTurnEffectEnchantments.Add(this);

			Game.IdEntityDic[Id] = this;
			Game.AllEnchantments.Add(this);
			e.ActivatedTrigger?.Activate(Game, this);

			Zone = c.BoardZone;

			if (Power.Enchant?.RemoveWhenPlayed ?? false)
				Enchant.RemoveWhenPlayedTrigger.Activate(Game, this);

			//if (e.Creator is Enchantment eCreator)
			//	eCreator.Clone(Game);
		}

		/// <summary>
		/// The entity that this enchantment is attached to.
		/// </summary>
		public Entity Target { get; set; }

		/// <summary>
		/// <see cref="Card"/> information captured in this instance.
		/// </summary>
		public Card CapturedCard
		{
			get => _capturedCard;
			set
			{
				_capturedCard = value;
				if (value != null && Game.History && (Card.Text?.Contains("{0}") ?? false))
				{
					Card c = Card.Clone();
					c.Text = String.Format(c.Text, value.Name);
					Card = c;
				}
			}
		}

		public Playable Creator
		{
			get => _creator ?? (!Game.IdEntityDic.TryGetValue(_creatorId, out _creator) ? null : _creator);
			private set
			{
				_creatorId = value.Id;
				_creator = value;
			}
		}

		public bool IsOneTurnActive
		{
			get => _isOneTurnActive;
			private set => _isOneTurnActive = value;
		}

		public int OrderOfPlay
		{
			get => _orderOfPlay;
			private set => _orderOfPlay = value;
		}

		public int ScriptTag1
		{
			get => _v1 ?? 0;
			set => _v1 = value;
		}

		public int ScriptTag2
		{
			get => _v2 ?? 0;
			set => _v1 = value;
		}

		/// <summary>
		/// Creates and adds a new Enchantment entity to the given Controller's Game.
		/// </summary>
		/// <param name="controller">The controller of the enchantment.</param>
		/// <param name="creator">The entity who creates the enchantment.</param>
		/// <param name="target">The entity who is subjected to the enchantment.</param>
		/// <param name="card">The card from which the enchantment must be derived.</param>
		/// <param name="num1">The value of script tag 1.</param>
		/// <param name="num2">The value of script tag 2.</param>
		/// <returns>The resulting enchantment entity.</returns>
		public static Enchantment GetInstance(in Game game, in Controller controller, in Playable creator,
											  in Entity target, in Card card,
											  int? num1 = default, int? num2 = default)
		{
			int id = game.NextId;

			//var tags = new EntityData(0);

			var instance = new Enchantment(in controller, in card, in id)
			{
				Creator = creator,
				Target = target,
			};

			if (target.AppliedEnchantments == null)
				target.AppliedEnchantments = new List<Enchantment>(4);
			target.AppliedEnchantments.Add(instance);

			//game.IdEntityDic.Add(instance.Id, instance);
			game.AllEnchantments.Add(instance);
			game.IdEntityDic[instance.Id] = instance;

			if (game.History)
			{
				//tags.Add(GameTag.ENTITY_ID, id);
				//tags.Add(GameTag.ZONE, (int)Enums.Zone.SETASIDE);
				//tags.Add(GameTag.CONTROLLER, controller.PlayerId);

				game.PowerHistory.Add(new PowerHistoryFullEntity
				{
					Entity = new PowerHistoryEntity
					{
						Id = instance.Id,
						//Tags = tags.ToDictionary(k => k.Key, k => k.Value)
						Tags = new Dictionary<GameTag, int>
						{
							{GameTag.ENTITY_ID, id},
							{GameTag.ZONE, (int)Enums.Zone.SETASIDE},
							{GameTag.CONTROLLER, controller.PlayerId}
						}
					}
				});

				if (!(target.Zone is DeckZone))
				{
					var gameTags = new Dictionary<GameTag, int>
					{
						{GameTag.CONTROLLER, controller.PlayerId},
						{GameTag.CARDTYPE, (int) CardType.ENCHANTMENT},
						{GameTag.ATTACHED, target.Id},
						{GameTag.DAMAGE, 0},
						{GameTag.ZONE, (int) Enums.Zone.SETASIDE},
						{GameTag.ENTITY_ID, instance.Id},
						{GameTag.ZONE_POSITION, 0},
						{GameTag.CREATOR, creator.Id},
						{GameTag.TAG_LAST_KNOWN_COST_IN_HAND, 0}
						//	CREATOR_DBID
						//	479
					};
					if (card[GameTag.TAG_ONE_TURN_EFFECT] == 1)
						gameTags.Add(GameTag.TAG_ONE_TURN_EFFECT, 1);
					game.PowerHistory.Add(new PowerHistoryShowEntity
					{
						Entity = new PowerHistoryEntity
						{
							Id = instance.Id,
							Name = instance.Card.Name,
							Tags = gameTags
						}
					});
				}
				
				instance[GameTag.ZONE] = (int)Enums.Zone.PLAY;
			}

			if (card.OneTurnEffect)
			{
				instance.IsOneTurnActive = true;
				game.OneTurnEffectEnchantments.Add(instance);
			}


			instance.Zone = controller.BoardZone;
			instance.OrderOfPlay = game.NextOop;
			//	323 = 1

			if (card.Power.DeathrattleTask != null && target is MinionInPlay m)
				m.HasDeathrattle = true;

			if (game.Logging)
				game.Log(LogLevel.VERBOSE, BlockType.ACTION, "Enchantment",
				!game.Logging ? "" : $"Enchantment {card} created by {creator} is added to {target}.");

			if (num1 >= 0)
			{
				//tags.Add(GameTag.TAG_SCRIPT_DATA_NUM_1, num1.Value);
				instance._v1 = num1;
				if (num2 >= 0)
					//tags.Add(GameTag.TAG_SCRIPT_DATA_NUM_2, num2.Value);
					instance._v2 = num2;
			}

			return instance;
		}

		public override void Destroy()
		{
			throw new NotImplementedException();
		}

		public override Playable Clone(in Controller controller)
		{
			throw new NotImplementedException();
		}

		public Enchantment Clone(Game game)
		{
			return new Enchantment(game.ControllerById(Controller.Id), this);
		}

		public override int this[GameTag t]
		{
			get =>
				t == GameTag.TAG_SCRIPT_DATA_NUM_1 ? ScriptTag1 :
				t == GameTag.TAG_SCRIPT_DATA_NUM_2 ? ScriptTag2 : base[t];
			set
			{
				if (t == GameTag.TAG_SCRIPT_DATA_NUM_1)
					ScriptTag1 = value;
				else if (t == GameTag.TAG_SCRIPT_DATA_NUM_2)
					ScriptTag2 = value;
				else
					base[t] = value;
			}
		}

		public void Remove(bool removeFromList = false)
		{
			if (Game.History)
			{
				if (Zone == null)
					Zone = Controller.BoardZone;
				Game.PowerHistory.Add(PowerHistoryBuilder.HideEntity(this));
				this[GameTag.ZONE] = (int)Enums.Zone.REMOVEDFROMGAME;
			}

			// Activate enchantment deathrattle task.
			if (Power.DeathrattleTask != null && Target.Zone is GraveyardZone)
			{
				Game.TaskQueue.Enqueue(Power.DeathrattleTask, Target.Controller, Target, this);
			}

			OngoingEffect?.Remove();
			ActivatedTrigger?.Remove();

			if (removeFromList)
				Target.AppliedEnchantments.Remove(this);

			if (IsOneTurnActive)
				Game.OneTurnEffectEnchantments.Remove(this);

			Game.Log(LogLevel.VERBOSE, BlockType.ACTION, "Enchantment",
				!Game.Logging ? "" : $"Enchantment {this} is removed from {Target}.");

			//if (!Creator?.Card.Modular ?? true)
			_removed = true;
		}

		public bool IsRemoved => _removed;

		public override string ToString()
		{
			return $"'{Card.Name}[{Id}]'";
		}
	}
}
