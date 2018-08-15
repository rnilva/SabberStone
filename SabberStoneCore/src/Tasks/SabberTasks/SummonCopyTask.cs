using SabberStoneCore.Model;
using SabberStoneCore.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using SabberStoneCore.Enums;
using SabberStoneCore.Tasks.SimpleTasks;

namespace SabberStoneCore.Tasks.SabberTasks
{
	/// <summary>
	/// Summon a copy of one (or more) existing entity.
	/// </summary>
	/// <seealso cref="SabberTask" />
	public class SummonCopyTask : SabberTask
	{
		private readonly EntityType _type;
		private readonly bool _randomFlag;
		private readonly bool _addToStack;
		private readonly SummonSide _side;

		/// <summary>
		/// Summons a copy of the chosen entitytype.
		/// </summary>
		/// <param name="type">Selector of entity to copy.</param>
		/// <param name="randomFlag"><c>true</c> if the copies need to be summoned
		/// in random order, <c>false</c> otherwise.</param>
		public SummonCopyTask(EntityType type, bool randomFlag = false, bool addToStack = false)
		{
			_type = type;
			_randomFlag = randomFlag;
			_addToStack = addToStack;
		}

		public SummonCopyTask(EntityType type, SummonSide side) : this(type)
		{
			_side = side;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

		public override TaskState Process(TaskStack stack)
		{
			Controller c = stack.Controller;

			if (c.BoardZone.IsFull)
				return TaskState.STOP;

			IList<IPlayable> entities = GetEntities(_type, stack);

			if (entities.Count < 1)
			{
				return TaskState.STOP;
			}

			// shuffle list randomly if needed
			entities = _randomFlag ? entities.OrderBy(x => Util.Random.Next()).ToList() : entities;

			if (_randomFlag)
				stack.Game.OnRandomHappened(true);

			int space = c.BoardZone.MaxSize - c.BoardZone.Count;

			space = entities.Count > space ? space : entities.Count;

			if (entities[0].Zone == null || entities[0].Zone.Type != Enums.Zone.PLAY)
				for (int i = 0; i < space; i++)
					stack.Game.TaskQueue.Enqueue(new SummonTask(_side, entities[i].Card));
			else
			{
				for (int i = 0; i < entities.Count; i++)
				{
					if (c.BoardZone.IsFull) break;

					Minion target = (Minion) entities[i];

					//var tags = new EntityData.Data((EntityData.Data) target.NativeTags);
					var copiedData = new EntityData(target._data);

					//if (target.Controller != Controller)
					//	copiedData[GameTag.CONTROLLER] = Controller.PlayerId;

					IPlayable copy = Entity.FromCard(c, copiedData, c.BoardZone);

					target.AppliedEnchantments?.ForEach(e =>
					{
						Enchantment instance = Enchantment.GetInstance(in c, in copy, copy, e.Card);
						if (e[GameTag.TAG_SCRIPT_DATA_NUM_1] > 0)
						{
							instance[GameTag.TAG_SCRIPT_DATA_NUM_1] = e[GameTag.TAG_SCRIPT_DATA_NUM_1];
							if (e[GameTag.TAG_SCRIPT_DATA_NUM_2] > 0)
								instance[GameTag.TAG_SCRIPT_DATA_NUM_2] = e[GameTag.TAG_SCRIPT_DATA_NUM_2];
						}
					});

					if (target.OngoingEffect != null && copy.OngoingEffect == null)
						target.OngoingEffect.Clone(copy);

					if (_addToStack)
						stack.Playables.Add(copy);
				}
			}


			return TaskState.COMPLETE;
		}

		public override SabberTask Clone(TaskStack stack)
		{
			var clone = new SummonCopyTask(_type, _randomFlag, _addToStack) {PrivateStack = stack};
			return clone;
		}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}
}
