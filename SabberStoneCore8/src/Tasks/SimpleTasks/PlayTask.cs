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
using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public enum PlayType
	{
		SPELL
	}

	/// <summary>
	///     Allows to have a playable played out in a task
	/// </summary>
	public class PlayTask : SimpleTask
	{
		private readonly PlayType _playType;
		private readonly bool _randTarget;
		private readonly EntityType _targetType;

		/// <summary>
		///     Create a PlayTask to play a card as a task.
		/// </summary>
		/// <param name="playType">The type of playable.</param>
		/// <param name="randTarget">true if the target of the playable is chosen randomly</param>
		public PlayTask(PlayType playType, bool randTarget = false)
		{
			_playType = playType;
			_randTarget = randTarget;
		}

		public PlayTask(PlayType playType, EntityType targetType)
		{
			_playType = playType;
			_targetType = targetType;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			switch (_playType)
			{
				case PlayType.SPELL:
					for (int i = 0; i < (stack?.Playables).Count; i++)
					{
						Playable p = (stack?.Playables)[i];
						Character cardTarget = null;
						if (_randTarget && p.Card.MustHaveTargetToPlay)
						{
							var targets = (List<Character>) p.ValidPlayTargets;

							cardTarget = targets.Count > 0
								? Util.RandomElement(targets)
								: throw new InvalidOperationException();

							p.CardTarget = cardTarget?.Id ?? -1;

							game.Log(LogLevel.INFO, BlockType.POWER, "PlayTask",
								!game.Logging ? "" : $"{p}'s target is randomly selected to {cardTarget}");
						}
						else if
							(_targetType != EntityType.INVALID)
						{
							cardTarget = (Character) IncludeTask.GetEntities(_targetType, in controller, source,
								target, stack?.Playables)[0];
						}

						if (spell.Zone == null || Generic.RemoveFromZone(c, p))
						{
							Generic.CastSpell.Invoke(c, game, spell, cardTarget, 0);
						}

						while (c.Choice != null)
							Generic.ChoicePick(c, game, c.Choice.Choices.Choose(game.Random));
					}

					return TaskState.COMPLETE;

				default:
					throw new NotImplementedException();
			}
		}
	}
}
