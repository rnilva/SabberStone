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
using System.Collections;
using System.Collections.Generic;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Triggers
{
	public class MultiTrigger : Trigger, IReadOnlyList<Trigger>
	{
		private readonly IReadOnlyList<Trigger> _triggers;

		public MultiTrigger(params Trigger[] triggers) : base(TriggerType.MULTITRIGGER)
		{
			//for (int i = 0; i < triggers.Length; i++)
			//	triggers[i].IsAncillaryTrigger = true;
			_triggers = triggers;
		}

		//private MultiTrigger(Trigger[] triggers, MultiTrigger protoType, Game game, Playable owner) : base(protoType, game, owner)
		//{
		//	_triggers = triggers;
		//}

		public override TriggerStub Activate(Game game, Playable source, TriggerActivation activation = TriggerActivation.PLAY, bool cloning = false, bool asAncillary = false)
		{
			if (source.ActivatedTrigger != null && !IsAncillaryTrigger)
				throw new Exceptions.EntityException($"{source} already has an activated trigger.");

			//var triggers = new Trigger[_triggers.Count];
			var triggers = new TriggerStub[_triggers.Count];

			bool flag = false;
			for (int i = 0; i < triggers.Length; i++)
			{
				triggers[i] = _triggers[i]?.Activate(game, source, activation, cloning, true);
				if (triggers[i] != null)
					flag = true;
			}

			if (!flag) return null;

			//var instance = new MultiTrigger(triggers, this, game, source);
			var instance = new MultiTriggerStub(triggers, source);

			if (!IsAncillaryTrigger)
				source.ActivatedTrigger = instance;

			return instance;
		}

		public int Count => _triggers.Count;

		public Trigger this[int index] => _triggers[index];

		public override void Deactivate(Game game, TriggerStub stub)
		{
			for (int i = 0; i < _triggers.Count; ++i)
			{
				_triggers[i].Deactivate(game, stub);
			}
		}

		public IEnumerator<Trigger> GetEnumerator()
		{
			return _triggers.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public class MultiTriggerStub : TriggerStub
	{
		private TriggerStub[] _stubs;
		//private readonly MultiTrigger _trigger;
		private readonly Playable _owner;

		public MultiTriggerStub(TriggerStub[] stubs, /*MultiTrigger trigger, */Playable owner)
		{
			_stubs = stubs;
			//_trigger = trigger;
			_owner = owner;
		}


		public override bool Process(Entity source)
		{
			throw new System.NotImplementedException();
		}

		public override void Remove(Game game)
		{
			for (int i = 0; i < _stubs.Length; ++i)
				_stubs[i].Remove(game);

			_owner.ActivatedTrigger = null;
		}

		public override void Validate(Entity source)
		{

		}

		public override void Invalidate()
		{

		}

		public override TriggerStub Clone(Playable owner)
		{
			//return _trigger.Activate(owner.Game, owner, cloning: true);
			var stubs = new TriggerStub[_stubs.Length];
			for (int i = 0; i < _stubs.Length; ++i)
				stubs[i] = _stubs[i].Clone(owner);
			return new MultiTriggerStub(stubs, owner);
		}

		public override TriggerStub Combine(Trigger trigger)
		{
			TriggerStub stub = trigger.Activate(_owner.Game, _owner, asAncillary: true);
			var stubs = new TriggerStub[_stubs.Length + 1];
			Array.Copy(_stubs, stubs, _stubs.Length);
			stubs[_stubs.Length] = stub;
			_stubs = stubs;
			return this;
		}
	}
}
