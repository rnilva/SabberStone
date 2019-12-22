using SabberStoneCore.Enums;
using SabberStoneCore.Model.Entities;
using System.Collections.Generic;
using SabberStoneCore.Auras;
using SabberStoneCore.Enchants;
// ReSharper disable ArrangeStaticMemberQualifier

namespace SabberStoneCore.Actions
{
	public partial class Generic
	{
		public static Playable Copy(in Controller controller, in Entity creator, in Playable source, Zone targetZone, int zonePosition = -1)
		{
			// Determine whether enchantments should be also copied.
			// Whenever a card moves forward in that flow (Deck -> Hand, Hand -> Play, Deck -> Play),
			// it retains enchantments. If a card moves backwards in zones
			// (Play -> Hand, Hand -> Deck, Play -> Deck, Play/Hand/Deck -> Graveyard and
			// Graveyard -> Play/Hand/Deck), it loses enchantments.
			// https://playhearthstone.com/en-gb/blog/21965466
			bool copyEnchantments;

			Zone sourceZone = source.Zone?.Type ?? Zone.PLAY;

			if (sourceZone == Zone.GRAVEYARD)
				copyEnchantments = false;
			else if (sourceZone == targetZone)
				copyEnchantments = true;
			else if (targetZone == Zone.SETASIDE)
				copyEnchantments = false;
			else if (targetZone == Zone.PLAY)
				copyEnchantments = true;
			else if (sourceZone == Zone.DECK)
				copyEnchantments = true;
			else if (sourceZone == Zone.HAND && targetZone != Zone.DECK)
				copyEnchantments = true;
			else
				copyEnchantments = false;

			Playable copiedEntity;

			if (copyEnchantments)
			{
				if (targetZone == Zone.PLAY)
                {
	                MinionInPlay mip = MinionInPlay.FromCard(in controller, source.Card);
					mip.CreatorId = creator.Id;
	                if (sourceZone == Zone.PLAY)
	                {
		                mip.CopyAttributesFrom((MinionInPlay) source);
		                {
			                int id = source.Id;
			                foreach (AdjacentAura adjAura in controller.BoardZone.AdjacentAuras)
			                foreach (MinionInPlay minion in adjAura.AppliedEntities)
				                if (minion.Id == id)
				                {
					                // De-apply effects from adjacent auras affecting the target
					                adjAura.DeApply(mip, true);
					                break;
				                }
		                }
		                // Register the copied entity to auras; this will prevent duplication.
		                foreach (Aura boardAura in controller.BoardZone.Auras)
			                boardAura.Register(mip);
	                }
	                else
                    {
						// Copy Modified ATK / Health
						if (source._v1.HasValue) mip._v1 = source._v1;
						if (source._v2.HasValue) mip._v2 = source._v2;
                    }
                    copiedEntity = mip;
                }
                else
                {
                    copiedEntity = Entity.FromCard(in controller, source.Card);
					copiedEntity.CreatorId = creator.Id;

					copiedEntity._v1 = source._v1;
					copiedEntity._v2 = source._v2;
					int? modifiedCost = source._modifiedCost;

                    if (modifiedCost.HasValue)
                        copiedEntity.Cost = modifiedCost.Value;

                    if (sourceZone == Zone.HAND)
                    {
	                    // Remove effects from the auras affecting the target
	                    foreach (Aura handAura in source.Controller.HandZone.Auras)
		                    if (handAura.Registered(source))
			                    handAura.RemoveEffects(copiedEntity);
                    }
                }

				

                if (source.AppliedEnchantments != null)
				{
					foreach (Enchantment e in source.AppliedEnchantments)
					{
						Enchantment instance = Enchantment.GetInstance(in controller, e.Creator, copiedEntity, e.Card);
						if (e[GameTag.TAG_SCRIPT_DATA_NUM_1] > 0)
						{
							instance[GameTag.TAG_SCRIPT_DATA_NUM_1] = e[GameTag.TAG_SCRIPT_DATA_NUM_1];
							if (e[GameTag.TAG_SCRIPT_DATA_NUM_2] > 0)
								instance[GameTag.TAG_SCRIPT_DATA_NUM_2] = e[GameTag.TAG_SCRIPT_DATA_NUM_2];

							instance.CapturedCard = e.CapturedCard;
						}
						instance.CapturedCard = e.CapturedCard;

						if (e.IsOneTurnActive)
							instance.Game.OneTurnEffectEnchantments.Add(instance);
					}
					
				}

                List<(int entityId, IEffect effect)> oneTurnEffects = controller.Game.OneTurnEffects;
				for (int i = oneTurnEffects.Count - 1; i >= 0; i--)
				{
					(int id, IEffect effect) = oneTurnEffects[i];
					if (id == source.Id)
						oneTurnEffects.Add((copiedEntity.Id, effect));
				}

				if (source.OngoingEffect != null && copiedEntity.OngoingEffect == null)
					source.OngoingEffect.Clone(copiedEntity);

				List<(int entityId, IEffect effect)> oneTurnEffects = controller.Game.OneTurnEffects;
				for (int i = oneTurnEffects.Count - 1; i >= 0; i--)
				{
					(int id, IEffect effect) = oneTurnEffects[i];
					if (id == source.Id)
						oneTurnEffects.Add((copiedEntity.Id, effect));
				}
			}
			else if
				(targetZone == Zone.DECK)
			{
				copiedEntity = Entity.FromCard(in controller, source.Card);
				ShuffleIntoDeck(controller, creator, copiedEntity);
				return copiedEntity;
				// TODO: Add tag
			}
			else
			{
				copiedEntity = Entity.FromCard(in controller, source.Card);
				copiedEntity.NativeTags.Add(GameTag.DISPLAYED_CREATOR, creator.Id);
			}

			switch (targetZone)
			{
				case Zone.HAND:
					Generic.AddHandPhase.Invoke(controller, copiedEntity);
					break;
				case Zone.DECK:
					Generic.ShuffleIntoDeck.Invoke(controller, creator, copiedEntity);
					break;
				case Zone.PLAY:
					Generic.SummonBlock(controller.Game, ref copiedEntity, zonePosition);
					break;
				case Zone.SETASIDE:
					controller.SetasideZone.Add(copiedEntity);
					break;
			}
			else
			{
				copiedEntity = Entity.FromCard(in controller, source.Card);
				copiedEntity.CreatorId = creator.Id;
			}

			switch (targetZone)
			{
				case Zone.HAND:
					Generic.AddHandPhase.Invoke(controller, copiedEntity);
					break;
				case Zone.DECK:
					Generic.ShuffleIntoDeck.Invoke(controller, creator, copiedEntity);
					break;
				case Zone.PLAY:
					Generic.SummonBlock(controller.Game, ref copiedEntity, zonePosition, (Playable) creator);
					break;
				case Zone.SETASIDE:
					controller.SetasideZone.Add(copiedEntity);
					break;
			}

			if (copyEnchantments && source.OngoingEffect != null && copiedEntity.OngoingEffect == null)
				source.OngoingEffect.Clone(copiedEntity);

			if (copyEnchantments && source is MinionInPlay m && m.OngoingEffect != null && copiedEntity.OngoingEffect == null)
				source.OngoingEffect.Clone(copiedEntity);

			return copiedEntity;
		}
	}
}
