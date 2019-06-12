//using System;
//using System.Buffers;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Text;
//using SabberStoneCore.Auras;
//using SabberStoneCore.Enums;
//using SabberStoneCore.Exceptions;
//using SabberStoneCore.Model.Entities;

//namespace SabberStoneCore.Model.Zones
//{
//	public class BoardZone_rework : IZone
//	{
//		public const int MaxSize = 7;

//		private int _count;
//		private int _untouchableCount;
//		private bool _hasUntouchables;
//		private readonly Memory<Character> _memory;

//		public readonly List<Aura> Auras = new List<Aura>();
//		public readonly List<AdjacentAura> AdjacentAuras = new List<AdjacentAura>();

//		public Game Game { get; }
//		public int CountExceptUntouchables { get; }
//		public bool HasUntouchables { get; }

//		public BoardZone_rework(Controller controller)
//		{
//			Game = controller.Game;
//			Controller = controller;
//			if (controller.PlayerId == 1)
//				_memory = new Memory<Character>(controller.Game._characters, 1, 7);
//		}

//		public void Add(Minion entity, int zonePosition = -1)
//		{
//			#region Zone.Add

//			int c = _count;

//			Span<Character> entities = _memory.Span;
//			if (zonePosition < 0 || zonePosition == c)
//			{
//				entities[c] = entity;
//				entity.ZonePosition = c;
//			}
//			else
//			{
//				entities.Slice(zonePosition).CopyTo(entities.Slice(zonePosition + 1));
//				entities[zonePosition] = entity;
//				for (int i = c; i >= zonePosition; --i)
//					entities[i].ZonePosition = i;
//			}

//			_count = c + 1;

//			entity.Zone = this;

//			for (int i = Auras.Count - 1; i >= 0; i--)
//				Auras[i].EntityAdded(entity);

//			#endregion

//			if (entity.Controller == Game.CurrentPlayer)
//			{
//				if (!entity.HasCharge)
//				{
//					if (entity.IsRush)
//					{
//						entity.AttackableByRush = true;
//						Game.RushMinions.Add(entity.Id);
//					}
//					else
//						entity.IsExhausted = true;
//				}
//			}

//			entity.OrderOfPlay = Game.NextOop;

//			ActivateAura(entity);

//			for (int i = AdjacentAuras.Count - 1; i >= 0; i--)
//				AdjacentAuras[i].BoardChanged = true;

//			Game.TriggerManager.OnZoneTrigger(entity);

//			if (entity.Card.Untouchable)
//			{
//				++_untouchableCount;
//				_hasUntouchables = true;
//			}
//		}

//		public Minion Remove(Minion entity)
//		{
//			RemoveAura(entity);
//			for (int i = 0; i < AdjacentAuras.Count; i++)
//				AdjacentAuras[i].BoardChanged = true;
//			if (entity.Card.Untouchable && --_untouchableCount == 0)
//				_hasUntouchables = false;


//			int pos = entity.ZonePosition;
//			int c = _count;
//			Span<Character> span = _memory.Span;

//			if (pos < --c)
//			{
//				span.Slice(pos + 1).CopyTo(span.Slice(pos));
//				for (int i = c - 1; i >= pos; --i)
//					span[i].ZonePosition = i;
//			}

//			return entity;
//		}

//		public void Replace(Minion oldEntity, Minion newEntity)
//		{
//			int pos = oldEntity.ZonePosition;
//			_memory.Span[pos] = newEntity;
//			newEntity.ZonePosition = pos;
//			newEntity[GameTag.ZONE] = (int)Type;
//			newEntity.Zone = this;

//			// Remove old Entity
//			RemoveAura(oldEntity);
//			for (int i = 0; i < Auras.Count; i++)
//				Auras[i].EntityRemoved(oldEntity);
//			if (oldEntity.AppliedEnchantments != null)
//				for (int i = oldEntity.AppliedEnchantments.Count - 1; i >= 0; i--)
//				{
//					//if (oldEntity.AppliedEnchantments[i].Creator.Power?.Aura != null)
//					//	continue;
//					oldEntity.AppliedEnchantments[i].Remove();
//				}

//			oldEntity.ActivatedTrigger?.Remove();
//			if (oldEntity.Card.Untouchable && --_untouchableCount == 0)
//				_hasUntouchables = false;

//			Controller.SetasideZone.Add(oldEntity);

//			// Add new Entity
//			newEntity.OrderOfPlay = Game.NextOop;
//			ActivateAura(newEntity);
//			if (newEntity.Card.Untouchable)
//			{
//				++_untouchableCount;
//				_hasUntouchables = true;
//			}

//			Auras.ForEach(a => a.EntityAdded(newEntity));
//			AdjacentAuras.ForEach(a => a.BoardChanged = true);
//		}

//		public static void ActivateAura(Minion entity)
//		{
//			entity.Power?.Trigger?.Activate(entity.Game, entity);
//			entity.Power?.Aura?.Activate(entity);

//			if (entity.Card.SpellPower > 0)
//				entity.Controller.CurrentSpellPower += entity.Card.SpellPower;
//		}

//		private static void RemoveAura(Minion entity)
//		{
//			entity.OngoingEffect?.Remove();
//			int csp = entity.Controller.CurrentSpellPower;
//			if (csp > 0)
//			{
//				int sp = entity.SpellPower;
//				if (sp > 0)
//					entity.Controller.CurrentSpellPower = csp - sp;
//			}
//		}

//		#region Implementation of IZone

//		public Controller Controller { get; }

//		public Zone Type => Zone.PLAY;

//		public int Count => _count;

//		public bool IsFull => _count == 7;

//		List<IPlayable> IZone.GetAll => throw new NotImplementedException();

//		public void Add(IPlayable entity, int zonePosition = -1)
//		{
//			throw new NotImplementedException();
//		}

//		public IPlayable Remove(IPlayable entity)
//		{
//			throw new NotImplementedException();
//		}

//		public string Hash(params GameTag[] ignore)
//		{
//			throw new NotImplementedException();
//		}

//		#endregion

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		public ReadOnlySpan<Character> GetSpan()
//		{
//			return _memory.Span;
//		}

//		public Character[] GetAll(Predicate<Character> predicate)
//		{
//			Span<Character> span = _memory.Span;

//			Span<int> buffer = stackalloc int[span.Length];
//			int k = 0;

//			if (_hasUntouchables)
//			{
//				for (int i = 0; i < span.Length; i++)
//				{
//					if (span[i].Card.Untouchable)
//						continue;

//					if (predicate(span[i]))
//						buffer[k++] = i;
//				}
//			}
//			else
//				for (int i = 0; i < span.Length; i++)
//					if (predicate(span[i]))
//						buffer[k++] = i;

//			var result = new Character[k];
//			for (int i = 0; i < k; i++)
//				result[i] = span[buffer[i]];

//			return result;
//		}

//		internal void CopyTo(Array destination, int index)
//		{
//			if (_hasUntouchables)
//			{

//			}


//		}

//		internal void DecrementUntouchablesCount()
//		{
//			if (!_hasUntouchables) return;
//			if (--_untouchableCount == 0)
//				_hasUntouchables = false;
//		}

//		public void Stamp(BoardZone_rework zone)
//		{
//			zone._hasUntouchables = _hasUntouchables;
//			zone._untouchableCount = _untouchableCount;
//			zone._count = _count;

//			var span = _memory.Span;
//			var target = zone._memory.Span;
//			var c = zone.Controller;
//			for (int i = 0; i < span.Length; i++)
//			{
//				var copy = (Character)span[i].Clone(c);
//				copy.Zone = zone;
//				target[i] = copy;
//			}
//		}
//	}
//}

