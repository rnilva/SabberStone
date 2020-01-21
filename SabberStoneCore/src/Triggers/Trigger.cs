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
using SabberStoneCore.Conditions;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;

namespace SabberStoneCore.Triggers
{
	public partial class Trigger
    {
	    //private static int _idGen;

		//private readonly TriggerManager.TriggerHandler _processHandler;
		private readonly Action<Game, TriggerStub> _activator;
		private readonly Action<Game, TriggerStub> _deactivator;
		private readonly Func<Entity, Playable, bool> _validator;
		//private readonly int _id;
		//private readonly int _sourceId;
		private readonly TriggerType _triggerType;
		private readonly bool _eitherTurn;
		//private readonly bool _isSecret;
		private readonly SequenceType _sequenceType;
		//private bool _removed;

		//protected readonly Playable _owner;

	    internal bool IsAncillaryTrigger;

		//public readonly Game Game;
		/// <summary>
		/// Indicates the Zone at which the effect is triggered.
		/// </summary>
		public TriggerActivation TriggerActivation;
	    /// <summary>
	    /// Indicates which entities can trigger the effect.
	    /// </summary>
		public TriggerSource TriggerSource { get; private set; }
		/// <summary>
		/// Task to do when this effect is triggered.
		/// </summary>
		public SimpleTask SingleTask;

	    /// <summary> Additional condition for trigger sources </summary>
	    public SelfCondition Condition { get; private set; }

		/// <summary> 
		/// This option is only meaningful when this the type of this trigger is <see cref="TriggerType.TURN_END"/> or <see cref="TriggerType.TURN_START"/>.
		/// </summary>
		/// <value>	true means the effect can be triggered at both player's turn.</value>
		public bool EitherTurn => _eitherTurn;
	    public bool FastExecution;
		/// <value> true means this trigger will be immediately disposed after triggered.</value>
	    public bool RemoveAfterTriggered;

	    public Trigger(TriggerType type, TriggerSource source = TriggerSource.ALL, SelfCondition condition = null, bool eitherTurn = false)
	    {
		    //_id = _idGen++;

			_triggerType = type;
			TriggerSource = source;
			Condition = condition;
			_eitherTurn = eitherTurn;

			switch (type)
		    {
				case TriggerType.PLAY_CARD:
				case TriggerType.AFTER_PLAY_CARD:
					_sequenceType = SequenceType.PlayCard;
					break;
			    case TriggerType.PLAY_MINION:
			    case TriggerType.AFTER_PLAY_MINION:
				    _sequenceType = SequenceType.PlayMinion;
					break;
			    case TriggerType.CAST_SPELL:
			    case TriggerType.AFTER_CAST:
				    _sequenceType = SequenceType.PlaySpell;
					break;
				case TriggerType.TARGET:
					_sequenceType = SequenceType.Target;
					break;
				case TriggerType.TURN_END:
				case TriggerType.WORGEN_TRANSFORM:
					FastExecution = true;
					break;
		    }

			_activator = GetActivator(type);
			_validator = GetValidator();
			_deactivator = GetDeactivator(type);
	    }

	    public Trigger(TriggerType type, SelfCondition condition, bool eitherTurn = false)
		    : this(type, TriggerSource.ALL, condition, eitherTurn) { }

	    public bool Validated { get; set; }

		public SequenceType SequenceType => _sequenceType;
		public TriggerType Type => _triggerType;
		//public bool IsSecret => _isSecret;

		/// <summary>
		/// Create a new instance of <see cref="Trigger"/> object in source's Game. During activation, the instance's <see cref="Process(Entity)"/> subscribes to the events in <see cref="TriggerManager"/>.
		/// </summary>
		public virtual TriggerStub Activate(Game game, Playable source, TriggerActivation activation = TriggerActivation.PLAY, bool cloning = false, bool asAncillary = false)
		{
			if (source.ActivatedTrigger != null && !IsAncillaryTrigger && !asAncillary)
				throw new Exceptions.EntityException($"{source} already has an activated trigger.");

			if (!cloning && activation != TriggerActivation)
			{
				if (TriggerActivation != TriggerActivation.HAND_OR_PLAY)
					return null;

				if (activation == TriggerActivation.DECK)
					return null;
			}

			var instance = new BasicTriggerStub(source, this, asAncillary);

			_activator(game, instance);

			if (!cloning && !asAncillary && !IsAncillaryTrigger)
				source.ActivatedTrigger = instance;

			if (game.Logging)
				game.Log(LogLevel.DEBUG, BlockType.POWER, "Trigger",
					$"{source}'s {_triggerType} trigger is activated.");

			return instance;
		}

		public virtual void  Deactivate(Game game, TriggerStub stub)
		{
			_deactivator(game, stub);
		}

		public bool Validate(Entity source, Playable owner)
	    {
		    if (owner.Card.IsSecret && owner.IsExhausted && _triggerType != TriggerType.TURN_START)
			    return false;

		    return _validator?.Invoke(source, owner) ?? true;
	    }

		public override string ToString()
		{
			return $"[Type:{_triggerType}]";
		}

		private Func<Entity, Playable, bool> GetValidator()
		{
			Func<Entity, Playable, bool> validator;

			Func<Entity, Playable, bool> sourceValidator = null;

			Func<Entity, Playable, bool> typeValidator = null;

			Func<Entity, Playable, bool> conditionValidator = null;




		    switch (TriggerSource)
		    {
				case TriggerSource.ALL:
					break;
				case TriggerSource.FRIENDLY:
					sourceValidator = (s, o) => s.Controller == o.Controller;
				    //if (source.Controller != _owner.Controller) return;
				    break;
			    //case TriggerSource.ENEMY when source.Controller == _owner.Controller: return;
				case TriggerSource.ENEMY:
					sourceValidator = (s, o) => s.Controller != o.Controller;
					break;
			    case TriggerSource.SELF:
				    //if (source.Id != _sourceId) return;
					sourceValidator = (s, o) => s.Id == o.Id;
				    break;
			    case TriggerSource.ALL_MINIONS:
				    //if (!(source is Minion)) return;
					sourceValidator = (s, o) => s.Card.Type == CardType.MINION;
				    break;
			    case TriggerSource.MINIONS:
				    //if (!(source is Minion) || source.Controller != _owner.Controller) return;
					sourceValidator = (s, o) => s.Card.Type == CardType.MINION && s.Controller == o.Controller;
				    break;
			    case TriggerSource.MINIONS_EXCEPT_SELF:
				    //if (!(source is Minion) || source.Controller != _owner.Controller || source.Id == _sourceId ||
				    //    source.Zone.Type != Zone.PLAY) return;
				    sourceValidator = (s, o) =>
					    s.Card.Type == CardType.MINION &&
					    s.Controller == o.Controller &&
					    s.Id != o.Id &&
					    s.Zone?.Type == Zone.PLAY;
					break;
				case TriggerSource.ALL_MINIONS_EXCEPT_SELF:
					//if (!(source is Minion) || source == _owner) return;
					sourceValidator = (s, o) => s.Card.Type == CardType.MINION && s.Id != o.Id;
				    break;
				case TriggerSource.OP_MINIONS:
					//if (!(source is Minion) || source.Controller == _owner.Controller) return;
					sourceValidator = (s, o) => s.Card.Type == CardType.MINION && s.Controller == o.Controller.Opponent;
					break;
			    case TriggerSource.HERO:
				    //if (!(source is Hero) || source.Controller != _owner.Controller) return;
					sourceValidator = (s, o) => s.Card.Type == CardType.HERO && s.Controller == o.Controller;
				    break;
			    case TriggerSource.ENCHANTMENT_TARGET:
				    //if (!(_owner is Enchantment e) || e.Target.Id != source.Id) return;
					sourceValidator = (s, o)  => o is Enchantment e && e.Target.Id == s.Id;
				    break;
				case TriggerSource.WEAPON:
					//if (!(source is Weapon w) || w.Controller != source.Controller) return;
					sourceValidator = (s, o) => s.Card.Type == CardType.WEAPON && s.Controller == o.Controller;
					break;
				case TriggerSource.HERO_POWER:
					//if (!(source is HeroPower hp) || hp.Controller != source.Controller) return;
					sourceValidator = (s, o) => s.Card.Type == CardType.HERO_POWER && s.Controller == o.Controller;
					break;
				case TriggerSource.FRIENDLY_SPELL_CASTED_ON_THE_OWNER:
					//if (!(source is Spell) || source.Controller != _owner.Controller || Game.CurrentEventData?.EventTarget != _owner) return;
					sourceValidator = (s, o) =>
						s.Controller == o.Controller &&
						s.Game.CurrentEventData?.EventTarget == o &&
						s.Card.Type == CardType.SPELL;
					break;
				case TriggerSource.FRIENDLY_SPELL_CASTED_ON_OWN_MINIONS:
					//if (!(source is Spell) || source.Controller != _owner.Controller || Game.CurrentEventData?.EventTarget?.Controller != _owner.Controller) return;
					sourceValidator = (s, o) =>
						s.Controller == o.Controller &&
						s.Game.CurrentEventData?.EventTarget?.Controller == o.Controller &&
						s.Card.Type == CardType.SPELL;
					break;
				case TriggerSource.FRIENDLY_EVENT_SOURCE:
					//if (Game.CurrentEventData?.EventSource.Controller != _owner.Controller) return;
					sourceValidator = (s, o) => s.Game.CurrentEventData?.EventSource.Controller == o.Controller;
					break;
			}

		    //bool extra = false;

		    switch (_triggerType)
		    {
				//case TriggerType.PLAY_CARD when source.Id == _owner.Id:
				//case TriggerType.SUMMON when source == _owner:
				//case TriggerType.AFTER_SUMMON when source.Id == _owner.Id:
				//case TriggerType.TURN_START when !EitherTurn && source != _owner.Controller:
				//case TriggerType.DEATH when _owner is MinionInPlay m && m.ToBeDestroyed:
				//case TriggerType.INSPIRE when !EitherTurn && Game.CurrentPlayer != _owner.Controller:
				//case TriggerType.SHUFFLE_INTO_DECK when Game.CurrentEventData?.EventSource.Card.AssetId == 49269:
				//	return;
				//case TriggerType.TURN_END:
				//case TriggerType.WORGEN_TRANSFORM:
				//	if (!EitherTurn && source != _owner.Controller) return;
				//	if (!(SingleTask is RemoveEnchantmentTask) && Owner.Controller.ExtraEndTurnEffect)
				//		extra = true;
				//	break;
				case TriggerType.SUMMON:
			    case TriggerType.PLAY_CARD:
				case TriggerType.AFTER_SUMMON:
					typeValidator = (s, o) => s.Id != o.Id;
				    break;
				case TriggerType.TURN_START:
					if (!EitherTurn)
						typeValidator = (s, o) => s == o.Controller;
					break;
				case TriggerType.DEATH:
					typeValidator = (s, o) => !(o is MinionInPlay m && m.ToBeDestroyed);
					break;
				case TriggerType.INSPIRE:
					if (!EitherTurn)
						typeValidator = (s, o) => s.Game.CurrentPlayer == o.Controller;
					break;
				case TriggerType.SHUFFLE_INTO_DECK:
					typeValidator = (s, o) => s.Game.CurrentEventData?.EventSource.Card.AssetId != 49269;
					break;
				case TriggerType.TURN_END:
				case TriggerType.WORGEN_TRANSFORM:
					if (!EitherTurn)
						typeValidator = (s, o) => s == o.Controller;
					break;
		    }

		    if (Condition != null)
		    {
			    //Playable s = source as Playable ?? _owner;
			    //if (!Condition.Eval(s))
				   // return;

			    conditionValidator = (s, o) => s is Playable p ? Condition.Eval(p) : Condition.Eval(o);
		    }

			

			//if (sourceValidator != null && typeValidator != null)
			//	validator = (s, o) => { return sourceValidator(s, o) && typeValidator(s, o); }

			validator = sourceValidator != null
				? typeValidator != null ? conditionValidator != null
					? (Func<Entity, Playable, bool>) ((s, o) =>
						sourceValidator(s, o) && typeValidator(s, o) && conditionValidator(s, o))
					: (s, o) => sourceValidator(s, o) && typeValidator(s, o) :
				conditionValidator != null ? (s, o) => sourceValidator(s, o) && conditionValidator(s, o) :
				sourceValidator
				: typeValidator != null
					? conditionValidator != null ? (s, o) => typeValidator(s, o) && conditionValidator(s, o) :
					typeValidator
					: conditionValidator;

			return validator;
		}
	}
}
