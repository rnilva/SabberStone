using System;
using System.Collections.Generic;
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
			//Entities = new List<Playable>(zone.Entities);
		}

		public override Zone Type => Zone.GRAVEYARD;

		public override void Add(Playable entity, int zonePosition = -1)
		{
			entity.Zone = this;

			if (entity.AppliedEnchantments != null)
				for (int i = entity.AppliedEnchantments.Count - 1; i >= 0; i--)
					entity.AppliedEnchantments[i].Remove();

			base.Add(entity, zonePosition);

			//entity.Reset();
		}

		public GraveyardZone Clone(Controller c)
		{
			return new GraveyardZone(c, this);
		}
	}

	//public class GraveyardZone_new : IZone
	//{
	//	private Controller _controller;
	//	private Zone _type;
	//	private int _count;
	//	private bool _full;
	//	private List<Playable> _getAll;

	//	private class GraveyardEntityNode
	//	{
	//		private GraveyardEntityNode _prev;
	//		private GraveyardEntityNode _next;
	//		private Entity _entity;

	//		public GraveyardEntityNode(Entity entity)
	//		{
	//			_entity = entity;
	//		}

	//		public GraveyardEntityNode Next
	//		{
	//			get => _next;
	//			set => _next = value;
	//		}

	//		public GraveyardEntityNode Prev
	//		{
	//			get => _prev;
	//			set => _prev = value;
	//		}

	//		public Entity Entity
	//		{
	//			get => _entity;
	//		}

	//		public GraveyardEntityNode Clone()
	//		{
	//			var cloneHead = new GraveyardEntityNode(_entity);
	//			_prev
	//		}
	//	}

	//	private class Container
	//	{
	//		private struct Enumerator
	//		{
	//			private Container _container;
	//			private Entity _current;
	//			private int _index;

	//			public Enumerator(Container container)
	//			{
	//				_container = container;
	//				_current = null;
	//				_index = 0;
	//			}

	//			public bool MoveNext()
	//			{
					
	//			}
	//		}

	//		private readonly Container _prev;
	//		private readonly int _prevCount;

	//		private int _currentCount;
	//		private Entity[] _entities;

	//		public int Count { get; set; }
			

	//		public bool Any(Predicate<Entity> predicate)
	//		{
	//			int c = _prevCount;
				
	//		}
	//	}

	//	private GraveyardEntityNode _head;

	//	internal GraveyardZone_new()
	//	{

	//	}

	//	private GraveyardZone_new(GraveyardEntityNode newHead)
	//	{
	//		_head = newHead;
	//	}

	//	public void Add(Playable entity)
	//	{
	//		entity.Zone = this;

	//		if (entity.AppliedEnchantments != null)
	//			for (int i = entity.AppliedEnchantments.Count - 1; i >= 0; i--)
	//				entity.AppliedEnchantments[i].Remove();

	//		Entity ps = Entity.CastFromPlayable(entity);
	//		if (entity.ToBeDestroyed)
	//			ps.ToBeDestroyed = true;

	//		if (_head == null)
	//			_head = new GraveyardEntityNode(ps);
	//		else
	//			_head.Next = new GraveyardEntityNode(ps);
	//	}

	//	public bool Any(Predicate<Entity> predicate)
	//	{
	//		GraveyardEntityNode ptr = _head;
	//		while (ptr != null)
	//		{
	//			if (predicate(ptr.Entity))
	//				return true;
	//			ptr = ptr.Next;
	//		}

	//		return false;
	//	}

	//	public GraveyardZone_new Clone()
	//	{
	//		return new GraveyardZone_new(_head?.Clone())
	//	}

	//	#region Implementation of IZone

	//	Controller IZone.Controller => _controller;

	//	Zone IZone.Type => _type;

	//	int IZone.Count => _count;

	//	bool IZone.IsFull => _full;

	//	List<Playable> IZone.GetAll => _getAll;

	//	void IZone.Add(Playable entity, int zonePosition)
	//	{
	//		throw new System.NotImplementedException();
	//	}

	//	Playable IZone.Remove(Playable entity)
	//	{
	//		throw new System.NotImplementedException();
	//	}

	//	string IZone.Hash(params GameTag[] ignore)
	//	{
	//		throw new System.NotImplementedException();
	//	}

	//	#endregion
	//}
}
