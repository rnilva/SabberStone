using System;
using System.Collections.Generic;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using static SabberStoneCore.Tasks.ImplementationHelpers;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class GetIntegerAttributeTask : SimpleTask
	{
		private readonly int _attribute;
		private readonly EntityType _type;
		private readonly int _entityIndex;
		private readonly int _stackIndex;

		public GetIntegerAttributeTask(IntAttributes attribute, EntityType type, int entityIndex = 0, int stackIndex = 0)
		{
			_attribute = (int)attribute;
			_type = type;
			_entityIndex = entityIndex;
			_stackIndex = stackIndex;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IList<Playable> entities = IncludeTask.GetEntities(_type, in controller, source, target, stack?.Playables);
			if (entities == null || entities.Count == 0 || entities.Count <= _entityIndex) return TaskState.STOP;

			if (!(entities[_entityIndex] is Character entity))
				throw new InvalidCastException("Can't get IntAttribute from a non-Character entity");

			int value;
			try
			{
				value = entity.GetIntRef(_attribute);
			}
			catch
			{
				throw new NotImplementedException($"Getting {(IntAttributes) _attribute} is not implemented.");
			}

			switch (_stackIndex)
			{
				case 0:
					stack.Number = value;
					break;
				case 1:
					stack.Number1 = value;
					break;
				case 2:
					stack.Number2 = value;
					break;
				case 3:
					stack.Number3 = value;
					break;
				case 4:
					stack.Number4 = value;
					break;
			}

			return TaskState.COMPLETE;
		}
	}

	public class SetIntAttributeTask : SimpleTask
	{
		private readonly IEffect _effect;
		private readonly EntityType _type;

		public SetIntAttributeTask(IntAttributes attribute, int amount, EntityType type)
		{
			_effect = Effects.AttributeAddEffect(attribute, amount);
			_type = type;
		}
		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IEffect effect = _effect;

			IList<Playable> entities =
				IncludeTask.GetEntities(in _type, in controller, source, target, stack?.Playables);
			if (effect.Tag == GameTag.EXHAUSTED)
			{
				bool value = effect.Value > 0;
				for (int i = 0; i < entities.Count; i++)
					entities[i].IsExhausted = value;
				return TaskState.COMPLETE;
			}

			for (int i = 0; i < entities.Count; i++)
			{
				if (effect.Tag == GameTag.DIVINE_SHIELD && effect.Value == 0 &&
				    entities[i][GameTag.DIVINE_SHIELD] != 0)
					game.TriggerManager.OnLoseDivineShield(entities[i]);
				else if
				(effect.Tag == GameTag.FROZEN && effect.Value == 1 &&
				 entities[i][GameTag.FROZEN] == 0)
					game.TriggerManager.OnFreezeTrigger(entities[i]);

				effect.ApplyTo(entities[i]);
			}

			return TaskState.COMPLETE;
		}
	}

	public class SetIntAttributeNumberTask : SimpleTask
	{
		private readonly IEffect _effect;
		private readonly EntityType _type;

		public SetIntAttributeNumberTask(IntAttributes attribute, EntityType type)
		{
			_effect = Effects.SetAttributeEffect(attribute, 0);
			_type = type;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			IEffect effect = _effect;

			IList<Playable> entities =
				IncludeTask.GetEntities(in _type, in controller, source, target, stack?.Playables);

			for (int i = 0; i < entities.Count; ++i)
			{
				_effect.ChangeValue(stack.Number).ApplyTo(entities[i]);
			}

			return TaskState.COMPLETE;
		}
	}

	public class GetBooleanAttributeTask : SimpleTask
	{
		private readonly int _attribute;
		private readonly EntityType _type;
		private readonly int _entityIndex;

		/// <summary>
		/// Creates a task that gets a boolean attribute from an entity
		/// and save the result to Flag.
		/// </summary>
		/// <param name="attribute"></param>
		/// <param name="type"></param>
		/// <param name="entityIndex"></param>
		public GetBooleanAttributeTask(BoolAttributes attribute, EntityType type, int entityIndex = 0)
		{
			_attribute = (int)attribute;
			_type = type;
			_entityIndex = entityIndex;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			//IList<Playable> entities = IncludeTask.GetEntities(_type, controller, source, target, stack?.Playables);
			//if (entities == null || entities.Count == 0 || entities.Count <= _entityIndex) return TaskState.STOP;
			//stack.Flag = entities[_entityIndex].GetAttribute<bool>(_attribute);
			return TaskState.COMPLETE;
		}
	}

	public class GetControllerAttributeTask : SimpleTask
	{
		private readonly ControllerIntAttributes _attribute;

		public GetControllerAttributeTask(ControllerIntAttributes attribute)
		{
			_attribute = attribute;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			stack.Number = controller[_attribute];
			return TaskState.COMPLETE;
		}
	}

	public class SetControllerAttributeTask : SimpleTask
	{
		private readonly ControllerIntAttributes _attribute;
		private readonly int _value;

		public SetControllerAttributeTask(ControllerIntAttributes attribute, int value)
		{
			_attribute = attribute;
			_value = value;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			controller[_attribute] = _value;
			return TaskState.COMPLETE;
		}
	}
}
