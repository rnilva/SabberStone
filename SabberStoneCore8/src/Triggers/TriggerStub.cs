using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Triggers
{
	public abstract class TriggerStub
	{
		public abstract bool Process(Entity source);
		public abstract void Remove(Game game);
		public abstract void Validate(Entity source);
		public abstract void Invalidate();
		public abstract TriggerStub Clone(Playable owner);
		public abstract TriggerStub Combine(Trigger trigger);
	}
	public class BasicTriggerStub : TriggerStub
	{
		private readonly int _sourceId;
		private readonly Playable _owner;
		private readonly Trigger _trigger;
		private readonly bool _ancillary;
		private bool _removed;
		private bool _validated;


		internal BasicTriggerStub(Playable owner, Trigger trigger, bool asAncillary)
		{
			_sourceId = owner.Id;
			_owner = owner;
			_trigger = trigger;
			_ancillary = asAncillary;
		}

		public override bool Process(Entity source)
		{
			// TODO: Report debug log here;

			if (_removed)
				return false;

			if (_trigger.SequenceType == SequenceType.None)
			{
				if (!_trigger.Validate(source, _owner))
					return true;
			}
			else if (!_validated)
				return true;

			ProcessInternal(source);

			if (_trigger.Type == TriggerType.TURN_END && !_removed && _owner.Controller.ExtraEndTurnEffect)
				ProcessInternal(source);

			return !_removed;
		}

		private void ProcessInternal(Entity source)
		{
			_validated = false;

			if (source.Game.Logging)
				source.Game.Log(LogLevel.INFO, BlockType.TRIGGER, "Trigger",
					$"{_owner}'s {_trigger.Type} Trigger is triggered by {source}.");

			if (_trigger.RemoveAfterTriggered)
				Remove(source.Game);

			// Enqueue tasks
			// Source: The owner of this trigger
			// Target: The source of this trigger or
			//			if the owner is Enchantment, the target of the enchantment.
			if (_trigger.FastExecution)
				source.Game.TaskQueue.Execute(_trigger.SingleTask, _owner.Controller, _owner,
					source is Playable playable ? playable
					: _owner is Enchantment ew && ew.Target is Playable p ? p
					: null);
			else
			{
				source.Game.TaskQueue.Enqueue(_trigger.SingleTask, _owner.Controller,
					/*_owner is Enchantment ec ? ec : */_owner,
					source is Playable pSource?
						pSource :
						_owner is Enchantment ew && ew.Target is Playable p ?
							p :
							null);
			}

			if (_owner.Card.IsSecret)
			{
				if (source.Game.History)
					_owner.IsRevealed = true;
				source.Game.TriggerManager.OnSecretRevealedTrigger(_owner);
			}
		}

		public override void Remove(Game game)
		{
			if (_removed) return;

			_trigger.Deactivate(game, this);

			if (!_ancillary)
				_owner.ActivatedTrigger = null;

			_removed = true;

			if (game.Logging)
				game.Log(LogLevel.DEBUG, BlockType.TRIGGER, "Trigger",
			    $"{_owner}'s {_trigger.Type} Trigger is removed.");
		}

		public override void Validate(Entity source)
		{
			_validated = _trigger.Validate(source, _owner);
		}

		public override void Invalidate()
		{
			_validated = false;
		}

		public override TriggerStub Clone(Playable owner)
		{
			return _trigger.Activate(owner.Game, owner, cloning: true);
		}

		public override TriggerStub Combine(Trigger trigger)
		{
			TriggerStub stub = trigger.Activate(_owner.Game, _owner, asAncillary: true);
			if (stub == null)
				return this;

			var multiStub = new MultiTriggerStub(new[] { this, stub }, _owner);
			return multiStub;
		}

		public override string ToString()
		{
			return $"[{_trigger.Type}][{_owner}]{(_removed ? "[Removed]" : "")}";
		}

		public TriggerType TriggerType => _trigger.Type;
	}
}
