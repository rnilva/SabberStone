using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Auras
{
	public class SummoningPortalAura : Aura
	{
		public SummoningPortalAura() : base(AuraType.HAND) { }
		
		private SummoningPortalAura(SummoningPortalAura prototype, Playable owner) : base(prototype, owner)
		{
			
		}

		public override void Activate(Playable owner, bool cloning = false)
		{
			var instance = new SummoningPortalAura(this, owner);
			owner.OngoingEffect = instance;
			owner.Controller.HandZone.Auras.Add(instance);
			owner.Game.Auras.Add(instance);
			if (!cloning)
				instance._queue.Enqueue(new AuraUpdateInstruction(Instruction.AddAll), 1);
		}

		public override bool Update()
		{
			bool addAllProcessed = false;
			while (_queue.Count > 0)
			{
				AuraUpdateInstruction inst = _queue.Dequeue();
				switch (inst.Instruction)
				{
					case Instruction.RemoveAll:
						RemoveAll();
						return false;
					case Instruction.AddAll:
						addAllProcessed = true;
						AddAll();
						break;
					case Instruction.Add:
						if (addAllProcessed) break;
						Apply(inst.Src);
						_ids.Add(inst.Src.Id);
						break;
					case Instruction.Remove:
						if (!_ids.Remove(inst.Src.Id))
							break;
						DeApply(inst.Src);
						break;
				}
			}
			return true;
		}

		private void AddAll()
		{
			Owner.Controller.HandZone.ForEach(p =>
			{
				Apply(p);
				_ids.Add(p.Id);
			});
		}

		private void RemoveAll()
		{
			_ids.ForEach(Game.IdEntityDic,
				(i, dict) => DeApply(dict[i]));
			//Game.Auras.Remove(this);
		}

		private static void Apply(Playable playable)
		{
			// The effect of Summoning Portal is always applied before any other effects.
			Playable p = playable;

			int cardValue = p.Card.Cost;
			int cost = cardValue > 2 ? cardValue - 2 : 1;

			int? eValue = p._modifiedCost;

			p.Cost = eValue.HasValue ? cost - cardValue + eValue.Value : cost;

			p.GetCostManager()?.QueueUpdate();
		}

		private new static void DeApply(Playable playable)
		{
			if (playable._modifiedCost == null) return;

			int cardValue = playable.Card.Cost;
			int delta = cardValue > 2 ? 2 : cardValue > 1 ? 1 : 0;

			playable.Cost = playable._modifiedCost.Value + delta;

			playable.GetCostManager()?.QueueUpdate();

			//playable[GameTag.COST] += delta;
			//playable.AuraEffects.ToBeUpdated = true;
		}
		
		public override void Clone(Playable clone)
		{
			Activate(clone, true);
		}
	}
}
