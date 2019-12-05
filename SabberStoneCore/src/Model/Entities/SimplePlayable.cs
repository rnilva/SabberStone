using System;

namespace SabberStoneCore.Model.Entities
{
	public class SimplePlayable : Playable
	{
		

		public SimplePlayable(in Controller controller, in Card card, in EntityData tags, in int id) : base(in controller, in card, in tags, in id)
		{
		}

		public SimplePlayable(in Controller controller, in Playable playable) : base(in controller, in playable)
		{
		}

		public override void Destroy()
		{
			throw new NotImplementedException();
		}

		public override Playable Clone(in Controller controller)
		{
			throw new NotImplementedException();
		}
	}
}
