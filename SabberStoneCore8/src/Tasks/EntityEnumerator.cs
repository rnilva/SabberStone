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
//		private readonly Entity _source;
//		private readonly Playable _target;
//		private readonly Controller _controller;

//		public EntityContainer(EntityType type, Entity source, Playable target, Controller controller)
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
//			public readonly ReadOnlySpan<Playable> PlayableSpan;
//			public readonly ReadOnlySpan<MinionInPlay> MinionSpan;
//			public readonly Playable SinglePlayable;

//			public int Index;
//			public int Length;

//			public EntityEnumerator(Playable singlePlayable)
//			{
//				PlayableSpan = default;
//				MinionSpan = default;
//				SinglePlayable = singlePlayable;
//				_current = singlePlayable;
//				Index = -1;
//				Length = 1;
//			}

//			private Playable _current;

//			public Playable Current => _current;
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

//			foreach (Playable i in test)
//			{

//			}
//		}
//	}
//}
