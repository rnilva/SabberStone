using System;
using System.Reflection;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.SimpleTasks
{
	public class GetPropertyTask : SimpleTask
	{
		private readonly EntityType _type;
		private readonly MethodInfo _property;

		public GetPropertyTask(EntityType entityType, string propertyName)
		{
			Type type;
			switch (entityType)
			{
				case EntityType.CONTROLLER:
					type = typeof(Controller);
					break;
				case EntityType.HERO:
					type = typeof(HeroInPlay);
					break;
				default:
					throw new NotImplementedException();
			}

			MethodInfo property = type.GetProperty(propertyName)?.GetGetMethod();
			if (property == null)
				throw new ArgumentOutOfRangeException($"{type} does not have a getter named {propertyName}");

			_type = entityType;
			_property = property;
		}


		#region Overrides of SimpleTask

		public override TaskState Process(in Game game, in Controller controller, in Entity source, in Entity target,
			in TaskStack stack = null)
		{
			object obj;
			switch (_type)
			{
				case EntityType.CONTROLLER:
					obj = controller;
					break;
				case EntityType.HERO:
					obj = controller.Hero;
					break;
				default:
					throw new NotImplementedException();
			}

			object value = _property.Invoke(obj, null);

			if (_property.ReturnType == typeof(int))
				stack.Number = (int)value;
			else if (_property.ReturnType == typeof(bool))
				stack.Flag = (bool)value;
			else
				throw new NotImplementedException();

			return TaskState.COMPLETE;
		}

		#endregion
	}
}
