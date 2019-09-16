using System.Linq;
using SabberStoneCore.Model.Entities;
using System.Collections.Generic;

namespace SabberStoneCore.Model
{
	public class TaskStack
	{
		public IList<Playable> Playables { get; set; }
		public bool Flag { get; set; }
		public int Number { get; set; }
		public int Number1 { get; set; }
		public int Number2 { get; set; }
		public int Number3 { get; set; }
		public int Number4 { get; set; }

		public void AddPlayables(IEnumerable<Playable> playables)
		{
			if (Playables is List<Playable> list)
				list.AddRange(playables);
			else
			{
				var toList = Playables.ToList();
				toList.AddRange(playables);
				Playables = toList;
			}
		}
		
		public void AddPlayable(Playable playable)
		{
			if (Playables is List<Playable> list)
				list.Add(playable);
			else
			{
				if (Playables == null)
					Playables = new List<Playable> {playable};
				else
				{
					List<Playable> toList = Playables.ToList();
					toList.Add(playable);
					Playables = toList;
				}
			}
		}
		
		public TaskStack Clone(Game game)
		{

			var clone = new TaskStack()
			{
				Playables = new List<Playable>(),
				Flag = Flag,
				Number = Number,
				Number1 = Number1,
				Number2 = Number2,
				Number3 = Number3,
				Number4 = Number4
			};

			if (Playables.Count > 0)
				clone.AddPlayables(Playables.Select(p => game.IdEntityDic[p.Id]));

			return clone;
		}
	}
}
