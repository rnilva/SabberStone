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

		public GetIntegerAttributeTask(BoolAttributes attribute, EntityType type, int entityIndex = 0, int stackIndex = 0)
		{
			_attribute = (int)attribute;
			_type = type;
			_entityIndex = entityIndex;
			_stackIndex = stackIndex;
		}

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			//IList<Playable> entities = IncludeTask.GetEntities(_type, in controller, source, target, stack?.Playables);
			//if (entities == null || entities.Count == 0 || entities.Count <= _entityIndex) return TaskState.STOP;

			//int value = entities[_entityIndex].GetAttribute<int>(_attribute);

			//switch (_stackIndex)
			//{
			//	case 0:
			//		stack.Number = value;
			//		break;
			//	case 1:
			//		stack.Number1 = value;
			//		break;
			//	case 2:
			//		stack.Number2 = value;
			//		break;
			//	case 3:
			//		stack.Number3 = value;
			//		break;
			//	case 4:
			//		stack.Number4 = value;
			//		break;
			//}

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
