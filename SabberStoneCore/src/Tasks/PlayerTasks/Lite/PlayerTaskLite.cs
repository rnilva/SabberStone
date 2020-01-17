using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Model.Entities;

namespace SabberStoneCore.Tasks.PlayerTasks.Lite
{
	/**
	 * - SourcePositions
	 *	- PlayCardTask
	 *	 0 - 9 : Zone position in hand.
	 *	- MinionAttackTask
	 *	 0 - 6 : Zone position in board.
	 * - TargetPositions
	 * -1 : None
	 *	0 : Friendly hero
	 *	1 - 7 : Friendly minion's zone position
	 *	8 : Enemy hero
	 *	9 - 15 : Enemy minion's zone position
	 *  - AttackTasks
	 *	 0 - 6 : Zone position in enemy's board.
	 *   7 : Enemy hero
	 */
	public readonly struct PlayerTaskLite
	{
		public const int FriendlyHero = 0;
		public const int EnemyHero = 8;

		public readonly PlayerTaskType Type;
		public readonly int SourcePosition;
		public readonly int TargetPosition;
		public readonly int ZonePosition;
		public readonly int ChooseOne;
		public readonly bool SkipPrePhase;

		public PlayerTaskLite(PlayerTaskType type, int sourcePosition, int targetPosition, int zonePosition, int chooseOne, bool skipPrePhase)
		{
			Type = type;
			SourcePosition = sourcePosition;
			TargetPosition = targetPosition;
			ZonePosition = zonePosition;
			ChooseOne = chooseOne;
			SkipPrePhase = skipPrePhase;
		}

		public Playable GetPlaySource(Controller controller)
		{
			return controller.HandZone[SourcePosition];
		}

		public MinionInPlay GetAttackSource(Controller controller)
		{
			return controller.BoardZone[SourcePosition];
		}

		public Character GetTarget(Controller controller)
		{
			if (TargetPosition < 0) return null;

			if (Type == PlayerTaskType.PLAY_CARD || Type == PlayerTaskType.HERO_POWER)
			{
				if (TargetPosition < 8)
				{
					if (TargetPosition == 0) return controller.Hero;
					return controller.BoardZone[TargetPosition - 1];
				}

				if (TargetPosition == 8)
					return controller.Opponent.Hero;

				return controller.Opponent.BoardZone[TargetPosition - 9];
			}

			if (TargetPosition > 6)
				return controller.Opponent.Hero;

			return controller.Opponent.BoardZone[TargetPosition];
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append($"[{Type}] ");
			switch (Type)
			{
				case PlayerTaskType.CHOOSE:
					break;
				case PlayerTaskType.HERO_POWER:
					if (TargetPosition >= 0)
						sb.Append($"=> {TargetPosition}");
					break;
				case PlayerTaskType.HERO_ATTACK:
					sb.Append($"=> {TargetPosition}");
					break;
				case PlayerTaskType.MINION_ATTACK:
					sb.Append($"{SourcePosition} => {TargetPosition}");
					break;
				case PlayerTaskType.PLAY_CARD:
					sb.Append($"{SourcePosition}");
					if (TargetPosition >= 0)
						sb.Append($" => {TargetPosition}");
					if (ZonePosition > 0)
						sb.Append($" (Pos: {ZonePosition})");
					if (ChooseOne > 0)
						sb.Append($" (Opt: {ChooseOne})");
					break;
			}

			return sb.ToString();

		}

		public static ref readonly PlayerTaskLite EndTurnTask() => ref _endTurnTask;
		public static PlayerTaskLite PlayCard(int sourcePos, int targetPos = -1, int zonePos = -1,
											  int chooseOne = -1, bool skipPrePhase = false)
			=> new PlayerTaskLite(PlayerTaskType.PLAY_CARD, sourcePos, targetPos,
								  zonePos, chooseOne, skipPrePhase);

		public static PlayerTaskLite HeroPower(int targetPos = -1, int chooseOne = -1, bool skipPrePhase = false)
			=> new PlayerTaskLite(PlayerTaskType.HERO_POWER, 0, targetPos, -1, chooseOne, skipPrePhase);

		public static PlayerTaskLite MinionAttackTask(int sourcePos, int targetPos, bool skipPrePhase = false)
			=> new PlayerTaskLite(PlayerTaskType.MINION_ATTACK, sourcePos, targetPos, -1, -1, skipPrePhase);

		public static PlayerTaskLite HeroAttackTask(int targerPos, bool skipPrePhase = false)
			=> new PlayerTaskLite(PlayerTaskType.HERO_ATTACK, 0, targerPos, -1, -1, skipPrePhase);

		public int Choice => SourcePosition;

		private static readonly PlayerTaskLite _endTurnTask
			= new PlayerTaskLite(PlayerTaskType.END_TURN, 0, 0, 0, 0, false);
	}
}

