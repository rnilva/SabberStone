using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Model.Zones
{
	public class SetasideZone : UnlimitedZone
	{
		public SetasideZone(Controller controller) : base(controller)
		{
		}

		private SetasideZone(Controller c, SetasideZone zone) : base(c, zone)
		{
		}

		public override Zone Type => Zone.SETASIDE;

		public override void Add(IPlayable entity, int zonePosition = -1)
		{
			if (entity is Playable p)
			{
				p.Zone = this;
				entity = (PlayableSurrogate)p;
			}

			base.Add(entity, zonePosition);
		}

		public SetasideZone Clone(Controller c)
		{
			return new SetasideZone(c, this);
		}
	}
}
