using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Actions;
using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Tasks;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
	public class AddEnchantmentTask : SabberTask
	{
		private readonly Card _enchantmentCard;
		private readonly EntityType _entityType;
		private readonly bool _useScriptTag;

		public AddEnchantmentTask(Card enchantmentCard, EntityType entityType, bool useScriptTag = false)
		{
			_enchantmentCard = enchantmentCard;
			_entityType = entityType;
			_useScriptTag = useScriptTag;
		}

		public AddEnchantmentTask(string enchantmentId, EntityType entityType, bool useScriptTag = false)
			: this(Cards.FromId(enchantmentId), entityType, useScriptTag)
		{
		
		}

		public override TaskState Process(TaskStack stack)
		{
			//	Controller Auras (OTEs)
			if (_entityType == EntityType.CONTROLLER)
			{
				Generic.AddEnchantmentBlock.Invoke(stack.Controller, _enchantmentCard, (IPlayable)stack.Source, stack.Controller, 0, 0);
				return TaskState.COMPLETE;
			}
			if (_entityType == EntityType.OP_CONTROLLER)
			{
				Generic.AddEnchantmentBlock.Invoke(stack.Controller, _enchantmentCard, (IPlayable)stack.Source, stack.Controller.Opponent, 0, 0);
				return TaskState.COMPLETE;
			}

			foreach (IPlayable p in GetEntities(_entityType, stack))
			{
				Generic.AddEnchantmentBlock.Invoke(stack.Controller, _enchantmentCard, (IPlayable)stack.Source, p, stack.Number, stack.Number1);
			}

			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new AddEnchantmentTask(_enchantmentCard, _entityType, _useScriptTag)
			{
				PrivateStack = stack
			};
			return clone;
		}
	}
}
