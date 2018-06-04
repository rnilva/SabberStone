using SabberStoneCore.Tasks;
using SabberStoneCore.Tasks.SabberTasks;

namespace SabberStoneCore.Enchants
{
	public class Power
	{
		public string InfoCardId { get; set; } = null;

		public Aura Aura { get; set; }

		public Enchant Enchant { get; set; }

		public Trigger Trigger { get; set; }

		public ISimpleTask PowerTask { get; set; }

		public ISimpleTask DeathrattleTask { get; set; }

		public ISimpleTask ComboTask { get; set; }

		public ISimpleTask TopdeckTask { get; set; }

		public SabberTask PowerTaskSabber { get; set; }
	}
}
