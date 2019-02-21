using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Model.Zones
{
	public class GraveyardZone : UnlimitedZone
	{
		public GraveyardZone(Controller controller) : base(controller)
		{
		}

		private GraveyardZone(Controller c, GraveyardZone zone) : base(c, zone)
		{
			//Entities = new List<IPlayable>(zone.Entities);
		}

		public override Zone Type => Zone.GRAVEYARD;

		public override void Add(IPlayable entity, int zonePosition = -1)
		{
			entity.Zone = this;

			if (entity.AppliedEnchantments != null)
				for (int i = entity.AppliedEnchantments.Count - 1; i >= 0; i--)
					entity.AppliedEnchantments[i].Remove();

			PlayableSurrogate ps = PlayableSurrogate.CastFromPlayable(entity);

			base.Add(ps, zonePosition);

			//entity.Reset();
		}

		public GraveyardZone Clone(Controller c)
		{
			return new GraveyardZone(c, this);
		}
	}
}
