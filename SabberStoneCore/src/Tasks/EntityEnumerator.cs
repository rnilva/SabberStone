//using System;
//using System.Collections.Generic;
//using System.Text;
//using SabberStoneCore.Model.Entities;
//using SabberStoneCore.Tasks.SimpleTasks;

//namespace SabberStoneCore.Tasks
//{
//	internal readonly ref struct EntityContainer
//	{
//		private readonly EntityType _type;
//		private readonly IEntity _source;
//		private readonly IPlayable _target;
//		private readonly Controller _controller;

//		public EntityContainer(EntityType type, IEntity source, IPlayable target, Controller controller)
//		{
//			_type = type;
//			_source = source;
//			_target = target;
//			_controller = controller;
//		}

//		public EntityEnumerator GetEnumerator()
//		{
//			switch (_type)
//			{
//				case EntityType.SOURCE:
//					return new EntityEnumerator(_source);

//			}


//			return new EntityEnumerator();
//		}

//		internal ref struct EntityEnumerator
//		{
//			public readonly ReadOnlySpan<IPlayable> PlayableSpan;
//			public readonly ReadOnlySpan<Minion> MinionSpan;
//			public readonly IPlayable SinglePlayable;

//			public int Index;
//			public int Length;

//			public EntityEnumerator(IPlayable singlePlayable)
//			{
//				PlayableSpan = default;
//				MinionSpan = default;
//				SinglePlayable = singlePlayable;
//				_current = singlePlayable;
//				Index = -1;
//				Length = 1;
//			}

//			private IPlayable _current;

//			public IPlayable Current => _current;
//			public bool MoveNext()
//			{
//				if (Index++ < 0)
//					if (SinglePlayable != null)
//						return true;

//				if (Index >= Length) return false;

//				_current = PlayableSpan != default ? PlayableSpan[Index] : MinionSpan[Index];
//				return true;
//			}
//		}

//		public static void Test()
//		{
//			EntityContainer test = new EntityContainer();

//			foreach (IPlayable i in test)
//			{

//			}
//		}
//	}
//}
