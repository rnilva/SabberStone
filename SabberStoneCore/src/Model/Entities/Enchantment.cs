using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Zones;

namespace SabberStoneCore.Model.Entities
{
	public partial class Enchantment : Playable
	{
		private int _creatorId;
		private int _controllerId;
		private Playable _creator;
		private Card _capturedCard;
		//private IAura _ongoingEffect;

		private Enchantment(in Controller controller, in Card card, in EntityData tags, in int id)
			: base(in controller, in card, in tags, in id)
		{

		}

		private Enchantment(in Controller c, in Enchantment e)
			: base(in c, e)
		{
			//Game = c.Game;
			//Card = e.Card;
			//Id = e.Id;

			Target = e.Target is Playable ? (Entity) Game.IdEntityDic[e.Target.Id] : c;
			_controllerId = e._controllerId;
			_creatorId = e._creatorId;
			_capturedCard = e._capturedCard;

			if (e.IsOneTurnActive)
				c.Game.OneTurnEffectEnchantments.Add(this);

			Zone = c.BoardZone;

			if (Power.Enchant?.RemoveWhenPlayed ?? false)
				Enchant.RemoveWhenPlayedTrigger.Activate(Game, this);

			if (e.Creator is Enchantment eCreator)
				eCreator.Clone(in c);
		}

		/// <summary>
		/// The entity that this enchantment is attached to.
		/// </summary>
		public Entity Target { get; private set; }

		/// <summary>
		/// <see cref="SabberStoneCore.Model.Card"/> information captured in this instance.
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
			get => _creator ?? (_creator = Game.IdEntityDic[_creatorId]);
			private set
			{
				_creatorId = value.Id;
				_creator = value;
			}
		}

		//public new Controller Controller
		//{
		//	get => _controller ?? (_controller = Game.ControllerById(_controllerId));
		//	set
		//	{
		//		_controllerId = value.Id;
		//		_controller = value;
		//	}
		//}

		//public IAura OngoingEffect
		//{
		//	get => _ongoingEffect;
		//	set => _ongoingEffect = value;
		//}

		public bool IsOneTurnActive => Card[GameTag.TAG_ONE_TURN_EFFECT] == 1;

		public int ScriptTag1 => this[GameTag.TAG_SCRIPT_DATA_NUM_1];

		public int ScriptTag2 => this[GameTag.TAG_SCRIPT_DATA_NUM_2];

		/// <summary>
		/// Creates and adds a new Enchantment entity to the given Controller's Game.
		/// </summary>
		/// <param name="controller">The controller of the enchantment.</param>
		/// <param name="creator">The entity who creates the enchantment.</param>
		/// <param name="target">The entity who is subjected to the enchantment.</param>
		/// <param name="card">The card from which the enchantment must be derived.</param>
		/// <returns>The resulting enchantment entity.</returns>
		public static Enchantment GetInstance(in Controller controller, in Playable creator, in Entity target, in Card card)
		{
			int id = controller.Game.NextId;

			var tags = new EntityData(4);

			var instance = new Enchantment(in controller, in card, in tags, in id)
			{
				Creator = creator,
				Target = target,
			};

			if (target.AppliedEnchantments == null)
				target.AppliedEnchantments = new List<Enchantment> {instance};
			else
				target.AppliedEnchantments.Add(instance);

			//controller.Game.IdEntityDic.Add(instance.Id, instance);
			controller.Game.IdEntityDic[instance.Id] = instance;

			if (controller.Game.History)
			{
				//tags.Add(GameTag.ENTITY_ID, id);
				//tags.Add(GameTag.CONTROLLER, controller.PlayerId);
				tags.Add(GameTag.ZONE, (int)Enums.Zone.SETASIDE);

				controller.Game.PowerHistory.Add(new PowerHistoryFullEntity
				{
					Entity = new PowerHistoryEntity
					{
						Id = instance.Id,
						Tags = tags.ToDictionary(k => k.Key, k => k.Value)
					}
				});

				if (!(target.Zone is DeckZone))
				{
					controller.Game.PowerHistory.Add(new PowerHistoryShowEntity
					{
						Entity = new PowerHistoryEntity
						{
							Id = instance.Id,
							Name = instance.Card.Name,
							Tags = new Dictionary<GameTag, int>
							{
								{GameTag.CONTROLLER, controller.PlayerId},
								{GameTag.CARDTYPE, (int) CardType.ENCHANTMENT},
								{GameTag.PREMIUM, creator[GameTag.PREMIUM]},
								{GameTag.ATTACHED, target.Id},
								{GameTag.DAMAGE, 0},
								{GameTag.ZONE, (int) Enums.Zone.SETASIDE},
								{GameTag.ENTITY_ID, instance.Id},
								{GameTag.SILENCE, 0},
								{GameTag.WINDFURY, 0},
								{GameTag.TAUNT, 0},
								{GameTag.STEALTH, 0},
								{GameTag.DIVINE_SHIELD, 0},
								{GameTag.CHARGE, 0},
								{GameTag.FROZEN, 0},
								{GameTag.ZONE_POSITION, 0},
								{GameTag.NUM_ATTACKS_THIS_TURN, 0},
								{GameTag.CREATOR, creator.Id},
								{GameTag.FORCED_PLAY, 0},
								{GameTag.TO_BE_DESTROYED, 0},
								{GameTag.POISONOUS, 0},
								{GameTag.CUSTOM_KEYWORD_EFFECT, 0},
								{GameTag.EXTRA_ATTACKS_THIS_TURN, 0},
								{GameTag.TAG_LAST_KNOWN_ATK_IN_HAND, 0},
								//	479
								{GameTag.LIFESTEAL, 0}
							}
						}
					});
				}
				
				instance[GameTag.ZONE] = (int)Enums.Zone.PLAY;
			}

			if (card[GameTag.TAG_ONE_TURN_EFFECT] == 1)
				controller.Game.OneTurnEffectEnchantments.Add(instance);


			instance.Zone = controller.BoardZone;
			instance.OrderOfPlay = controller.Game.NextOop;
			//	323 = 1

			if (card.Power.DeathrattleTask != null && target is MinionInPlay m)
				m.HasDeathrattle = true;

			controller.Game.Log(LogLevel.VERBOSE, BlockType.ACTION, "Enchantment",
				!controller.Game.Logging ? "" : $"Enchantment {card} created by {creator} is added to {target}.");

			return instance;
		}

		public override void Destroy()
		{
			throw new NotImplementedException();
		}

		public override Playable Clone(in Controller controller)
		{
			return new Enchantment(in controller, this);
		}

		public void Remove()
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

			Target.AppliedEnchantments.Remove(this);

			if (IsOneTurnActive)
				Game.OneTurnEffectEnchantments.Remove(this);

			Game.Log(LogLevel.VERBOSE, BlockType.ACTION, "Enchantment",
				!Game.Logging ? "" : $"Enchantment {this} is removed from {Target}.");
		}

		public override string ToString()
		{
			return $"'{Card.Name}[{Id}]'";
		}
	}

	public partial class Enchantment
	{
		public int OrderOfPlay { get; set; }
	}
}
