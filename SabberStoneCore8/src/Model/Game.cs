#region copyright
// SabberStone, Hearthstone Simulator in C# .NET Core
// Copyright (C) 2017-2019 SabberStone Team, darkfriend77 & rnilva
//
// SabberStone is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License.
// SabberStone is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
#endregion
using SabberStoneCore.Actions;
using SabberStoneCore.Config;
using SabberStoneCore.Enchants;
using SabberStoneCore.Enums;
using SabberStoneCore.Kettle;
using SabberStoneCore.Model.Entities;
using SabberStoneCore.Model.Zones;
//using SabberStoneCore.Splits;
using SabberStoneCore.Tasks;
using SabberStoneCore.Tasks.PlayerTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SabberStoneCore.Auras;
using SabberStoneCore.Conditions;
using SabberStoneCore.Tasks.PlayerTasks.Lite;
using SabberStoneCore.Triggers;

// TODO check if event should be removed
// TODO ... spellbender phase ??? and spell text ? wtf .. did you forget them???
// TODO [DS1_188] Gladiator's Longbow, check should be on IMMUNE_WHILE_ATTACKING
// TODO cleanup the Enchant class
// TODO refactor and cleanup SelfCondition & RelaCondition class
namespace SabberStoneCore.Model
{
	/// <summary>
	/// The state machine which processes the given input and generates results which can be interpreted 
	/// to create a new set of inputs.
	/// 
	/// This is THE MOST IMPORTANT type, since it provides a simple interface for handling/processing 
	/// game data.
	/// </summary>
	/// <seealso cref="Entity" />
	public partial class Game : Entity
	{
		private readonly GameConfig _gameConfig;

		private GameAttributes _attrs;
		private Controller _currentPlayer;

		/// <summary>
		/// The entityID of the game itself is always 1.
		/// </summary>
		public const int GAME_ENTITYID = 1;

		/// <summary>
		/// The maximum minions that are allowed on the board.
		/// </summary>
		public const int MAX_MINIONS_ON_BOARD = 7;

		/// <summary>
		/// List of activated auras.
		/// </summary>
		public readonly List<IAura> Auras;

		public readonly List<(int entityId, AbstractEffect effect)> OneTurnEffects;

		/// <summary>
		/// Temporal container to store Enchantment entities of One_Turn_effects.
		/// </summary>
		public readonly List<Enchantment> OneTurnEffectEnchantments;

		/// <summary>
		/// List of activated triggers that should be validated in advance.
		/// </summary>
		public readonly List<Trigger> Triggers;

		/// <summary>
		/// List of Minions that ready to be destroyed and to be removed from the BoardZone.
		/// </summary>
		public readonly List<MinionInPlay> DeadMinions = new List<MinionInPlay>(4);

		/// <summary>
		/// List of Minions summoned in current event.
		/// </summary>
		public readonly List<MinionInPlay> SummonedMinions = new List<MinionInPlay>(4);

		/// <summary>
		/// List of entity ids of Minions in the state of 'AttackableByRush'.
		/// </summary>
		public readonly List<int> RushMinions = new List<int>();

		/// <summary>
		/// List of entity ids of 'Ghostly' entities created by Echo ability.
		/// </summary>
		public readonly List<int> GhostlyCards = new List<int>();

		/// <summary>
		/// Gets or sets the index value for identifying the N-th clone of a game. (0-indexed)
		/// </summary>
		/// <value>The index of the clone.</value>
		//public string CloneIndex { get; set; } = "[0]";

		/// <summary>
		/// Gets or sets the index of the next clone.<seealso cref="CloneIndex"/>
		/// </summary>
		/// <value>The index of the next clone.</value>
		//public int NextCloneIndex { get; set; } = 1;
		internal Util.DeepCloneableRandom Random { get; set; }

		public void SetRandomSeed(long seed) => Random.SetSeed(seed);

		///// <summary>
		///// Gets or sets the list of splitted (and fully resolved) games, derived from this game.
		///// The values hold the derived game instances and split meta information.
		///// </summary>
		///// <value><see cref="SplitNode"/></value>
		//public List<SplitNode> FinalSplits { get; set; }

		///// <summary>
		///// Gets or sets the list of splitted, but unresolved, game instances.
		///// These instances are derived from the current game instance but their TaskQueue
		///// still needs to process.
		///// </summary>
		///// <value><see cref="Game"/></value>
		//public List<Game> Splits { get; set; } = new List<Game>();

		/// <summary>
		/// Occurs when a TAG on an entity, which is hooked onto this game, changes.
		/// </summary>
		//public event EntityChangedEventHandler EntityChangedEvent;

		/// <summary>Occurs when a random event was processed by this game.</summary>
		public event EventHandler<bool> RandomHappenedEvent;

		/// <summary>
		/// Gets the game event manager. This object delegates the state machine of
		/// the game.
		/// </summary>
		/// <value>The game event manager.</value>
		//public GameEventManager GamesEventManager { get; }

		/// <summary>
		/// Holds all the controllers (== players) which are attached to this game.
		/// </summary>
		//private readonly Controller[] _players = new Controller[2];

		/// <summary>
		/// Player with the first turn, alias Player 1.
		/// </summary>
		/// <value><see cref="Controller"/></value>
		public Controller Player1 { get; protected set; }

		/// <summary>
		/// Player starting at the second turn, alias Player 2.
		/// </summary>
		/// <value><see cref="Controller"/></value>
		public Controller Player2 { get; protected set; }

		/// <summary>
		/// Gets the format type of this game.
		/// </summary>
		/// <value><see cref="FormatType"/></value>
		public FormatType FormatType => _gameConfig.FormatType;

		///// <summary>Gets a value indicating whether this <see cref="Game"/> is intended to split.
		///// When TRUE, the game WILL SPLIT ITSELF when <see cref="Splits"/> contains games derived
		///// from this one with different random outcomes.
		///// </summary>
		///// <value><c>true</c> if splitting is intended; otherwise, <c>false</c>.</value>
		//public bool Splitting => _gameConfig.Splitting;

		/// <summary>Gets a value indicating whether this <see cref="Game"/> records debug logs.
		/// When TRUE, detailed information each process step will be saved in <see cref="Logs"/>
		/// in a form of <see cref="LogEntry"/>.
		/// </summary>
		public bool Logging
		{
			get => _logging;
			set
			{
				Logs ??= [];
				_logging = value;
			}
		}

		/// <summary>Gets or sets the power history container. 
		/// This object facilitates building POWER blocks to send to the hearthstone client.
		/// </summary>
		/// <value><see cref="Kettle.PowerHistory"/></value>
		public PowerHistory PowerHistory { get; }

		/// <summary>Gets a value indicating whether this <see cref="Game"/> has Power History 
		/// building enabled.
		/// </summary>
		/// <value><c>true</c> if history building is enabled; otherwise, <c>false</c>.</value>
		public bool History { get; }

		/// <summary>
		/// Gets the task queue.
		/// </summary>
		/// <value>The task queue.</value>
		/// <autogeneratedoc />
		public readonly TaskQueue TaskQueue;

		public readonly TriggerManager TriggerManager;

		private int _idIndex = 4;
		/// <summary>Gets the next entity identifier.</summary>
		/// <value>The next entity id.</value>
		public int NextId => _idIndex++;

		private int _oopIndex;
		/// <summary>Gets the next order of play index.</summary>
		/// <value>The next oop index.</value>
		public int NextOop => _oopIndex++;

		/// <summary>Ovewrites the internal index (multiple) values.
		/// This method is relevant when cloning games.
		/// </summary>
		/// <param name="id">The nex entity ID.</param>
		/// <param name="oop">The next OOP index.</param>
		public void SetIndexer(int id, int oop)
		{
			_idIndex = id;
			_oopIndex = oop;
		}

		///// <summary>
		///// Gets the dictionary containing all generated entities for this game.
		///// </summary>
		///// <value><see cref="Playable"/></value>
		public EntityList IdEntityDic { get; private set; }

		/// <summary>
		/// Gets a list containing all generated enchantments.
		/// </summary>
		public List<Enchantment> AllEnchantments { get; private set;}

		/// <summary>
		/// Gets the dictionary containing all generated choice sets for this game.
		/// </summary>
		/// <value><see cref="PowerEntityChoices"/></value>
		public Dictionary<int, PowerEntityChoices> EntityChoicesMap { get; }

		/// <summary>
		/// Gets all the dictionary containing all generated option sets for this game.
		/// </summary>
		/// <value><see cref="PowerAllOptions"/></value>
		public Dictionary<int, PowerAllOptions> AllOptionsMap { get; }

		/// <summary>
		/// Gets or sets the collection of log entries.
		/// </summary>
		/// <value><see cref="LogEntry"/></value>
		public Queue<LogEntry> Logs { get; private set; }

		/// <summary>Initializes a new instance of the <see cref="Game"/> class.</summary>
		/// <param name="gameConfig">The game configuration.</param>
		/// <param name="setupHeroes"></param>
		public Game(GameConfig gameConfig, bool setupHeroes = true)
			: base(null, Card.CardGame)
		{
			Random = gameConfig.RandomSeed is null ?
				new Util.DeepCloneableRandom() :
				new Util.DeepCloneableRandom(gameConfig.RandomSeed.Value);
			IdEntityDic = new EntityList(75);
			AllEnchantments = new List<Enchantment>(8);
			_gameConfig = gameConfig;
            _attrs = new GameAttributes();
			Game = this;

			bool history = gameConfig.History;
			// add power history create game
			if (history)
			{
				_data = new EntityData
				{
					[GameTag.ENTITY_ID] = GAME_ENTITYID,
					[GameTag.ZONE] = (int) Enums.Zone.PLAY,
					[GameTag.CARDTYPE] = (int) CardType.GAME
				};
				History = true;
				EntityChoicesMap = new Dictionary<int, PowerEntityChoices>();
				AllOptionsMap = new Dictionary<int, PowerAllOptions>();
				PowerHistory = new PowerHistory();
			}
			if (gameConfig.Logging)
			{
				Logging = true;
				Logs = new Queue<LogEntry>();
				_eventStack.Logging = true;
			}

			EntityData p1Dict = history
				? new EntityData(64)
				{
					//[GameTag.HERO_ENTITY] = heroId,
					[GameTag.MAXHANDSIZE] = Controller.MaxHandSize,
					[GameTag.STARTHANDSIZE] = 4,
					[GameTag.PLAYER_ID] = 1,
					[GameTag.TEAM_ID] = 1,
					[GameTag.ZONE] = (int) SabberStoneCore.Enums.Zone.PLAY,
					[GameTag.CONTROLLER] = 1,
					[GameTag.MAXRESOURCES] = Controller.MaxResources,
					[GameTag.CARDTYPE] = (int) CardType.PLAYER
				}
				: null;
			EntityData p2Dict = history
				? new EntityData(64)
				{
					//[GameTag.HERO_ENTITY] = heroId,
					[GameTag.MAXHANDSIZE] = 10,
					[GameTag.STARTHANDSIZE] = 4,
					[GameTag.PLAYER_ID] = 2,
					[GameTag.TEAM_ID] = 2,
					[GameTag.ZONE] = (int) SabberStoneCore.Enums.Zone.PLAY,
					[GameTag.CONTROLLER] = 2,
					[GameTag.MAXRESOURCES] = 10,
					[GameTag.CARDTYPE] = (int) CardType.PLAYER
				}
				: null;
			Player1 = new Controller(this, gameConfig.Player1Name, 1, 2);
			Player2 = new Controller(this, gameConfig.Player2Name, 2, 3);
			if (history)
			{
				Player1.SetTags(p1Dict);
				Player2.SetTags(p2Dict);
			}

			Player1.Opponent = Player2;
			Player2.Opponent = Player1;

			// add power history create game
			if (history) PowerHistory.Add(PowerHistoryBuilder.CreateGame(this, [Player1, Player2]));

			if (setupHeroes)
			{
				Player1.AddHeroAndPower(gameConfig.Player1HeroCard ?? Cards.HeroCard(gameConfig.Player1HeroClass));
				Player1.BaseClass = Player1.HeroClass;

				Player2.AddHeroAndPower(gameConfig.Player2HeroCard ?? Cards.HeroCard(gameConfig.Player2HeroClass));
				Player2.BaseClass = Player2.HeroClass;
			}

			Auras = new List<IAura>(8);
			TaskQueue = new TaskQueue(this);
			TriggerManager = new TriggerManager(this);
			Triggers = new List<Trigger>(4);

			OneTurnEffects = new List<(int, AbstractEffect)>(4);
			OneTurnEffectEnchantments = new List<Enchantment>(4);

			if (history)
			{
				PowerHistory.Add(PowerHistoryBuilder.CreateGame(this, [Player1, Player2]));
			}

			if (!gameConfig.Shuffle && !gameConfig.DrawWithRandom)
			{
				gameConfig.Player1Deck?.Reverse();
				gameConfig.Player2Deck?.Reverse();
			}

			// setting up the decks ...
			gameConfig.Player1Deck?.ForEach(p =>
			{
				Player1.DeckCards.Add(p);
				FromCard(Player1, p, Player1.DeckZone);
			});
			gameConfig.Player2Deck?.ForEach(p =>
			{
				Player2.DeckCards.Add(p);
				FromCard(Player2, p, Player2.DeckZone);
			});
			if (gameConfig.FillDecks)
			{
				Player1.DeckZone.Fill(_gameConfig.FillDecksPredictably ? GameConfig.UnPredictableCardIDs : null);
				Player2.DeckZone.Fill(_gameConfig.FillDecksPredictably ? GameConfig.UnPredictableCardIDs : null);
			}

			if (gameConfig.DrawWithRandom)
			{
				gameConfig.Shuffle = false;
				Player1.DeckZone.DrawWithRandom = true;
				Player2.DeckZone.DrawWithRandom = true;
			}
		}

		/// <summary> A copy constructor. </summary>
		private Game(Game game, bool logging, bool resetRandomSeed, bool history) : base(null, game)
		{
			//IdEntityDic = new Dictionary<int, Playable>(game.IdEntityDic.Count);
			IdEntityDic = new EntityList(game.IdEntityDic.Capacity);
			AllEnchantments = new List<Enchantment>(game.AllEnchantments.Capacity);
			Game = this;

			if (logging)
			{
				_logging = true;
				Logs = new Queue<LogEntry>();	// Logs are not cloned.
				_eventStack.Logging = true;
			}

			if (history)
			{
				_history = true;
				PowerHistory = new PowerHistory();
				EntityChoicesMap = new Dictionary<int, PowerEntityChoices>();
				AllOptionsMap = new Dictionary<int, PowerAllOptions>();
			}

			TaskQueue = new TaskQueue(this, game.TaskQueue);
			TriggerManager = new TriggerManager(this);
			Auras = new List<IAura>(game.Auras.Capacity);
			Triggers = new List<Trigger>(game.Triggers.Capacity);
			OneTurnEffects = new List<(int entityId, AbstractEffect effect)>(game.OneTurnEffects);
			OneTurnEffectEnchantments = new List<Enchantment>(game.OneTurnEffectEnchantments.Capacity);
			RushMinions.AddRange(game.RushMinions);
			GhostlyCards.AddRange(game.GhostlyCards);
			
			//GamesEventManager = new GameEventManager(this);

			// game._gameConfig is cloned here
			_gameConfig = game._gameConfig;
			_attrs = game._attrs;

			//CloneIndex = game.CloneIndex + $"[{game.NextCloneIndex++}]";

			Random = resetRandomSeed ? new Util.DeepCloneableRandom() : game.Random.Clone();

			Player1 = game.Player1.Clone(this);
			Player2 = game.Player2.Clone(this);
			Player1.Opponent = Player2;
			Player2.Opponent = Player1;
			if (game._currentPlayer != null)
			{
				CurrentPlayer = game.CurrentPlayer.Id == 2 ? Player1 : Player2;
				FirstPlayer = game.FirstPlayer.PlayerId == 1 ? Player1 : Player2;
			}

			foreach (Enchantment enchantment in game.AllEnchantments)
			{
				if (enchantment.IsRemoved)
					continue;
				enchantment.Clone(this);
			}

			// Clone auras lastly
			foreach (IAura aura in game.Auras)
			{
				aura.Clone(IdEntityDic[aura.Owner.Id]);
			}

			SetIndexer(game._idIndex, game._oopIndex);

			if (game._eventStack.Count != 0)
				throw new Exception("Need to clone the event stack too!");
		}

		///// <summary>Method which is called when an entity wants to notify that one of it's tags changed value.</summary>
		///// <param name="entity">The entity which has changed.</param>
		///// <param name="t">The game tag which value changed.</param>
		///// <param name="oldValue">The old value.</param>
		///// <param name="newValue">The new value.</param>
		//protected internal virtual void OnEntityChanged(Entity entity, GameTag t, int oldValue, int newValue)
		//{
		//	EntityChangedEvent?.Invoke(entity, t, oldValue, newValue);
		//}

		/// <summary>Call this method to invode the <see cref="RandomHappenedEvent"/>.</summary>
		/// <param name="isHappened">TODO</param>
		protected internal virtual void OnRandomHappened(bool isHappened)
		{
			RandomHappenedEvent?.Invoke(this, isHappened);
		}

		/// <summary>
		/// Retrieves the controller associated with a given entity ID.
		/// </summary>
		/// <param name="entityId">
		/// The ID of the entity for which to retrieve the controller. 
		/// Valid entity IDs are 2 for Player1 and 3 for Player2.
		/// </param>
		/// <returns>
		/// The <see cref="Controller"/> associated with the specified entity ID.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown when <paramref name="entityId"/> is not 2 or 3.
		/// </exception>
		public Controller ControllerByEntityId(int entityId) =>
			entityId switch
			{
				2 => Player1,
				3 => Player2,
				_ => throw new ArgumentOutOfRangeException(nameof(entityId),
					"Entity Id of a controller must be 2 or 3.")
			};

		/// <summary>
		/// Retrieves the controller associated with a given player ID.
		/// </summary>
		/// <param name="playerId">
		/// The ID of the player for which to retrieve the controller. 
		/// Valid player IDs are 1 for Player1 and 2 for Player2.
		/// </param>
		/// <returns>
		/// The <see cref="Controller"/> associated with the specified player ID.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown when <paramref name="playerId"/> is not 1 or 2.
		/// </exception>
		public Controller ControllerByPlayerId(int playerId) =>
			playerId switch
			{
				1 => Player1,
				2 => Player2,
				_ => throw new ArgumentOutOfRangeException(nameof(playerId), "Player Id must be 1 or 2.")
			};

		/// <summary>Process the specified task.
		/// The game will execute the desired task and all effects coupled either
		/// directly or indirectly in synchronous manner.
		/// 
		/// Call <see cref="Controller.Options(Boolean)"/> on the <see cref="CurrentPlayer"/> 
		/// instance for tasks which are accepted as arguments.
		/// After this method returns, check <see cref="Controller.Options(Boolean)"/>
		/// again until only <see cref="EndTurnTask"/> remains, which will
		/// start the turn of <see cref="CurrentOpponent"/>. 
		/// </summary>
		/// <param name="gameTask">The game task to execute.</param>
		public bool Process(PlayerTask gameTask)
		{
			//// start with no splits ...
			//Splits = new List<Game>();

			Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : gameTask.FullPrint());

			// clear last power history
			PowerHistory?.Last.Clear();

			// make sure that we only use task for this game ...
			if (gameTask.Game != this)
			{
				gameTask.Game = this;
				gameTask.Controller = ControllerByEntityId(gameTask.Controller.Id);
				if (gameTask.HasSource)
					gameTask.Source = IdEntityDic[gameTask.Source.Id];
				if (gameTask.HasTarget)
					gameTask.Target = (Character) IdEntityDic[gameTask.Target.Id];
			}
			bool result = gameTask.Process();

			// check dead heroes here again (TODO)
			if (State != State.COMPLETE)
			{
				if (Player1.Hero.ToBeDestroyed)
				{
					if (Player2.Hero.ToBeDestroyed)
					{
						Player1.PlayState = PlayState.TIED;
						Player2.PlayState = PlayState.TIED;
					}
					else
						Player1.PlayState = PlayState.LOSING;

					NextStep = Step.FINAL_WRAPUP;
					FinalWrapUp();
				}
				else if (Player2.Hero.ToBeDestroyed)
				{
					Player2.PlayState = PlayState.LOSING;

					NextStep = Step.FINAL_WRAPUP;
					FinalWrapUp();
				}
			}

			return result;
		}

		public bool Process(in PlayerTaskLite playerTaskLite)
		{
			if (Logging)
				Log(LogLevel.INFO, Enums.BlockType.PLAY, "Game", playerTaskLite.ToString());

			PowerHistory?.Last.Clear();

			bool result = true;

			Controller c = CurrentPlayer;
			switch (playerTaskLite.Type)
			{
				case PlayerTaskType.CHOOSE:
					if (c.Choice is not { ChoiceType: ChoiceType.GENERAL })
						return false;
					result = Generic.ChoicePick(c, this, playerTaskLite.Choice);
					if (result)
					{
						ProcessTasks();
						DeathProcessingAndAuraUpdate();
					}
					break;
				case PlayerTaskType.CONCEDE:
					c.PlayState = PlayState.CONCEDED;
					NextStep = Step.FINAL_WRAPUP;
					FinalWrapUp();
					break;
				case PlayerTaskType.END_TURN:
					Step = Step.MAIN_END;
					MainEnd();
					break;
				case PlayerTaskType.HERO_ATTACK:
					result = Generic.AttackBlock(c, c.Hero, playerTaskLite.GetTarget(c), playerTaskLite.SkipPrePhase, false);
					break;
				case PlayerTaskType.HERO_POWER:
					result = Generic.HeroPower(c, playerTaskLite.GetTarget(c), playerTaskLite.ChooseOne,
						playerTaskLite.SkipPrePhase);
					break;
				case PlayerTaskType.MINION_ATTACK:
					result = Generic.AttackBlock(c, playerTaskLite.GetAttackSource(c), playerTaskLite.GetTarget(c),
						playerTaskLite.SkipPrePhase, false);
					break;
				case PlayerTaskType.PLAY_CARD:
					result = Generic.PlayCard(this, c, playerTaskLite.GetPlaySource(c), playerTaskLite.GetTarget(c),
						playerTaskLite.ZonePosition, playerTaskLite.ChooseOne, playerTaskLite.SkipPrePhase);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			// check dead heroes here again (TODO)
			if (State != State.COMPLETE)
			{
				if (Player1.Hero.ToBeDestroyed)
				{
					if (Player2.Hero.ToBeDestroyed)
					{
						Player1.PlayState = PlayState.TIED;
						Player2.PlayState = PlayState.TIED;
					}
					else
						Player1.PlayState = PlayState.LOSING;

					NextStep = Step.FINAL_WRAPUP;
					FinalWrapUp();
				}
				else if (Player2.Hero.ToBeDestroyed)
				{
					Player2.PlayState = PlayState.LOSING;

					NextStep = Step.FINAL_WRAPUP;
					FinalWrapUp();
				}
			}

			return result;
		}

		#region STATE_MACHINE

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING.
		/// First player is determined here.
		/// For true <paramref name="stopBeforeShuffling"/> the order of cards in decks
		/// and the first hands of both players are determined too.
		/// </summary>
		/// <param name="stopBeforeShuffling">true if you want to start shuffling
		/// and drawing cards later.</param>
		public void StartGame(bool stopBeforeShuffling = false)
		{
			Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : "Starting new game now!");

			// set gamestats
			State = State.RUNNING;
			//_players.ToList().ForEach(p => p.PlayState = PlayState.PLAYING);
			Player1.PlayState = PlayState.PLAYING;
			Player2.PlayState = PlayState.PLAYING;


			// starting mulligan draw block
			if (History)
				PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, Id, "", -1, 0));

			// getting first player
			int first = _gameConfig.StartPlayer - 1;
			if (first < 0)
				first = Random.Next(0, 2);

			if (first == 0)
				FirstPlayer = CurrentPlayer = Player1;
			else
				FirstPlayer = CurrentPlayer = Player2;
			

			Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : $"Starting Player is {CurrentPlayer.Name}.");

			// first turn
			Turn = 1;

			// triggers Start of Game triggers (but does not process tasks here)
			TriggerManager.OnGameStartTrigger(this);

			if (stopBeforeShuffling)
				return;

			// set next step
			NextStep = Step.BEGIN_FIRST;

			BeginFirst();
			BeginShuffle();
			BeginDraw();
			if (!_gameConfig.SkipMulligan)
			{
				BeginMulligan();
				return;
			}
			MainBegin();
			MainReady(FirstPlayer);
			MainStartTriggers();
			MainStart();
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = BEGIN_FIRST
		/// </summary>
		public void BeginFirst()
		{
			Log(LogLevel.VERBOSE, BlockType.PLAY, "Game", !Logging ? "" : $"Begin First.");

			// set next step
			NextStep = Step.BEGIN_SHUFFLE;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = BEGIN_SHUFFLE
		/// </summary>
		public void BeginShuffle()
		{
			Log(LogLevel.VERBOSE, BlockType.PLAY, "Game", !Logging ? "" : $"Begin Shuffle.");

			if (_gameConfig.Shuffle)
			{
				Player1.DeckZone.Shuffle();
				Player2.DeckZone.Shuffle();
			}

			// set next step
			NextStep = Step.BEGIN_DRAW;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = BEGIN_DRAW
		/// </summary>
		public void BeginDraw()
		{
			Log(LogLevel.VERBOSE, BlockType.PLAY, "Game", !Logging ? "" : $"Begin Draw.");

			//FirstPlayer.NumCardsToDraw = 3;
			//FirstPlayer.Opponent.NumCardsToDraw = 4;

			Draw(Player1);
			Draw(Player2);

			Player1.TimeOut = 75;
			Player2.TimeOut = 75;

			NextStep = _gameConfig.SkipMulligan ? Step.MAIN_BEGIN : Step.BEGIN_MULLIGAN;
			return;

			void Draw(Controller p)
			{
				// quest draw if there is
				//int quest = p.DeckZone.FirstOrDefault(q => q.Card.IsQuest)?.Id ?? -1;
				List<int> questIndices = p.DeckZone.FindAllIndices(q => q.Card.IsQuest);
				int k = 0;
				for (int i = 0; i < questIndices.Count; i++, k++)
					Generic.Draw(p, questIndices[i]);
				while (k < 3)
				{
					Generic.Draw(p);
					k++;
				}

				if (p != FirstPlayer)
				{
					// 4th card for second player
					Generic.Draw(p);
				}

				p.NumTurnsLeft = 1;
			}
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = BEGIN_MULLIGAN
		/// </summary>
		public void BeginMulligan()
		{
			Log(LogLevel.VERBOSE, BlockType.PLAY, "Game", !Logging ? "" : $"Begin Mulligan.");

			// starting mulligan draw block
			if (History)
				PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, Id, "", -1, 0));

			Player1.MulliganState = Mulligan.INPUT;
			Player2.MulliganState = Mulligan.INPUT;

			Generic.CreateChoice.Invoke(Player1, this, ChoiceType.MULLIGAN, ChoiceAction.HAND, Player1.HandZone.Select(p => p.Id).ToList());
			Generic.CreateChoice.Invoke(Player2, this, ChoiceType.MULLIGAN, ChoiceAction.HAND, Player2.HandZone.Select(p => p.Id).ToList());

			// ending mulligan draw block
			if (History)
				PowerHistory.Add(PowerHistoryBuilder.BlockEnd());
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_BEGIN
		/// </summary>
		public void MainBegin(bool proceed = false)
		{
			Log(LogLevel.VERBOSE, BlockType.PLAY, "Game", !Logging ? "" : $"Main Begin.");

			// and a coin
			Playable coin = FromCard(FirstPlayer.Opponent, Cards.FromId("GAME_005")
				//,new EntityData
				//{
				//	[GameTag.ZONE] = (int)Enums.Zone.HAND,
				//	[GameTag.CARDTYPE] = (int)CardType.SPELL,
				//	[GameTag.CREATOR] = FirstPlayer.Opponent.PlayerId
				//}
			);
			Generic.AddHandPhase(FirstPlayer.Opponent, coin);

			ProcessTasks();

			NextStep = Step.MAIN_READY;

			if (proceed)
			{
				MainReady(FirstPlayer);
				MainStartTriggers();
				MainStart();
			}
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_READY
		/// </summary>
		public void MainReady(Controller currentPlayer)
		{
			if (History)
				PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, CurrentPlayer.Id, "", 1, 0));

			ReadOnlySpan<MinionInPlay> board;

			// Is this necessary?
			Controller currentOpponent = currentPlayer.Opponent;
			board = currentOpponent.BoardZone.GetSpan();
			for (int j = 0; j < board.Length; j++)
				board[j].NumAttacksThisTurn = 0;
			currentOpponent.Hero.NumAttacksThisTurn = 0;
			currentOpponent.CleanTurnStatistics();


			board = currentPlayer.BoardZone.GetSpan();
			for (int j = 0; j < board.Length; j++)
			{
				board[j].NumAttacksThisTurn = 0;
				board[j].IsExhausted = false;
			}

			currentPlayer.Hero.NumAttacksThisTurn = 0;
			currentPlayer.Hero.ExtraAttacksThisTurn = 0;
			currentPlayer.Hero.IsExhausted = false;
			currentPlayer.Hero.HeroPower.IsExhausted = false;
			if (currentPlayer.Hero.Weapon != null)
				currentPlayer.Hero.Weapon.IsExhausted = false;
			ReadOnlySpan<Spell> secrets = currentPlayer.SecretZone.GetSpan();
			for (int i = 0; i < secrets.Length; i++)
				secrets[i].IsExhausted = true;

			currentPlayer.CleanTurnStatistics();
			currentPlayer.IsComboActive = false; // 9
			currentPlayer.NumFriendlyMinionsThatAttackedThisTurn = 0; //26
			currentPlayer.HeroPowerActivationsThisTurn = 0; // 27
			currentPlayer.NumElementalsPlayedLastTurn = currentPlayer.NumElementalsPlayedThisTurn;
			currentPlayer.NumElementalsPlayedThisTurn = 0;


			NumMinionsKilledThisTurn = 0; 

			MainResources();

			if (History)
				PowerHistory.Add(PowerHistoryBuilder.BlockEnd());

			// set next step
			NextStep = Step.MAIN_START_TRIGGERS;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_START_TRIGGERS
		/// </summary>
		public void MainStartTriggers()
		{
			//CurrentPlayer.TurnStart = true;

			//Game.TaskQueue.StartEvent();
			if (TriggerManager.OnTurnStartTrigger(CurrentPlayer))
			{
				if (History)
					PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, CurrentPlayer.Id, "", 8, 0));

				DeathProcessingAndAuraUpdate();
				//Game.TaskQueue.EndEvent();
				if (History)
					PowerHistory.Add(PowerHistoryBuilder.BlockEnd());
			}


			// set next step
			//NextStep = Step.MAIN_RESOURCE;
			NextStep = Step.MAIN_START;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_RESOURCE
		/// </summary>
		public void MainResources()
		{
			Controller c = CurrentPlayer;

			// adding manacrystal to next player
			Generic.ChangeManaCrystal.Invoke(c, 1, false);

			// clear used mana
			c.UsedMana = 0;

			// remove temp mana
			c.TemporaryMana = 0;

			// overload
			c.OverloadLocked = c.OverloadOwed;
			c.OverloadOwed = 0;

			//// set next step
			//NextStep = Step.MAIN_DRAW;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_DRAW
		/// </summary>
		public void MainDraw()
		{
			if (History)
				PowerHistory.Add(PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, CurrentPlayer.Id, "", 0, 0)); // turn start effect

			//CurrentPlayer.NumCardsToDraw = 1;
			Generic.Draw(CurrentPlayer);

			if (History)
				PowerHistory.Add(PowerHistoryBuilder.BlockEnd());

			//// set next step
			//NextStep = Step.MAIN_START;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_START
		/// </summary>
		public void MainStart()
		{
			MainDraw();

			Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : $"[T:{Turn}/R:{Turn / 2}] with CurrentPlayer {CurrentPlayer.Name} " +
					 $"[HP:{CurrentPlayer.Hero.Health}/M:{CurrentPlayer.RemainingMana}]");

			DeathProcessingAndAuraUpdate();

			NextStep = Step.MAIN_ACTION;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_END
		/// </summary>
		public void MainEnd()
		{
			Controller currentPlayer = CurrentPlayer;

			Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : $"End turn proccessed by player {currentPlayer}");

			if (History)
				PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, currentPlayer.Id, "", 4, 0);

			//CurrentPlayer.TurnStart = false;

			TriggerManager.OnEndTurnTrigger(currentPlayer);

			if (History)
				PowerHistoryBuilder.BlockEnd();

			currentPlayer.CardsPlayedThisTurn.Clear();

			currentPlayer.Hero.DamageTakenThisTurn = 0;

			if (RushMinions.Count > 0)
			{
				foreach (int id in RushMinions)
				{
					if (IdEntityDic[id] is MinionInPlay m)
						m.AttackableByRush = false;
				}
				RushMinions.Clear();
			}

			// set next step
			//NextStep = Step.MAIN_NEXT;
			NextStep = Step.MAIN_CLEANUP;
			MainCleanUp(currentPlayer);
			currentPlayer = MainNext(currentPlayer);
			MainReady(currentPlayer);
			MainStartTriggers();
			MainStart();
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_CLEANUP
		/// </summary>
		public void MainCleanUp(Controller currentPlayer)
		{
			if (History)
				PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, CurrentPlayer.Id, "", 5, 0);

			// Removing Ghostly cards
			if (GhostlyCards.Count > 0)
			{
				foreach (int id in GhostlyCards)
				{
					Playable entity = IdEntityDic[id];
					if (entity.Zone.Type != Enums.Zone.HAND) continue;
					entity.Controller.SetasideZone.Add(entity.Zone.Remove(entity));
				}

				GhostlyCards.Clear();
			}


			// Removing one-turn-effects
			if (OneTurnEffectEnchantments.Count > 0)
			{
				List<Enchantment> enchantments = OneTurnEffectEnchantments;
				for (int i = enchantments.Count - 1; i >= 0; --i)
					enchantments[i].Remove(true);
			}
			if (OneTurnEffects.Count > 0)
			{
				foreach ((int id, AbstractEffect eff) in OneTurnEffects)
					//eff.RemoveFrom(IdEntityDic[id]);
					IdEntityDic[id].RemoveEffect(eff);
				
				OneTurnEffects.Clear();
			}

			// After a player ends their turn (just before the next player's Start of
			// Turn Phase), un-Freeze all characters they control that are Frozen, 
			// don't have summoning sickness (or do have Charge) and have not attacked
			// that turn.
			currentPlayer.BoardZone.ForEach(m =>
			{
				if (m.IsFrozen && m.NumAttacksThisTurn == 0 && !m.IsExhausted)
					m.IsFrozen = false;
			});

			if (currentPlayer.Hero.IsFrozen && currentPlayer.Hero.NumAttacksThisTurn == 0)
				currentPlayer.Hero.IsFrozen = false;

			// Exhausts weapon and secrets
			if (currentPlayer.Hero.Weapon != null)
				currentPlayer.Hero.Weapon.IsExhausted = true;
			currentPlayer.SecretZone.ForEach(p => p.IsExhausted = false);

			if (History)
				PowerHistoryBuilder.BlockEnd();

			NextStep = Step.MAIN_NEXT;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = MAIN_NEXT
		/// </summary>
		public Controller MainNext(Controller currentPlayer)
		{
			if (History)
				PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, Id, "", -1, 0);

			Controller opponent = currentPlayer.Opponent;

			// extra turn effect here
			if (currentPlayer.NumTurnsLeft > 1)
			{
				//this[GameTag.EXTRA_TURNS_TAKEN_THIS_GAME]++;
				//CurrentPlayer[GameTag.EXTRA_TURNS_TAKEN_THIS_GAME]++;
				//this[GameTag.IS_CURRENT_TURN_AN_EXTRA_TURN] = 1;
				currentPlayer.NumTurnsLeft--;
			}
			else if
				(opponent.TemporusFlag)
			{
				//this[GameTag.EXTRA_TURNS_TAKEN_THIS_GAME]++;
				//CurrentOpponent[GameTag.EXTRA_TURNS_TAKEN_THIS_GAME]++;
				//this[GameTag.IS_CURRENT_TURN_AN_EXTRA_TURN] = 1;
				CurrentPlayer = opponent;
				opponent.NumTurnsLeft = 2;
				opponent.TemporusFlag = false;
			}
			else
			{
				currentPlayer.NumTurnsLeft = 0;
				opponent.NumTurnsLeft = 1;
				// set player for next turn ...
				CurrentPlayer = opponent;
			}

			// count next turn
			Turn += 1;

			Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : $"CurentPlayer {CurrentPlayer.Name}.");

			if (History)
				PowerHistoryBuilder.BlockEnd();

			// set next step
			NextStep = Step.MAIN_READY;

			return CurrentPlayer;
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = FINAL_WRAPUP
		/// </summary>
		public void FinalWrapUp()
		{
			if (History)
				PowerHistoryBuilder.BlockStart(BlockType.TRIGGER, Id, "", -1, 0);

			bool ChangeState(Controller player)
			{
				if (player.PlayState == PlayState.TIED)
				{
					player.PlayState = PlayState.LOST;
					player.Opponent.PlayState = PlayState.LOST;
					return false;
				}

				if (player.PlayState != PlayState.LOSING && player.PlayState != PlayState.CONCEDED) return true;

				player.PlayState = PlayState.LOST;
				player.Opponent.PlayState = PlayState.WON;

				return true;
			}

			if (ChangeState(Player1))
				ChangeState(Player2);

			if (History)
				PowerHistoryBuilder.BlockEnd();

			// set next step
			NextStep = Step.FINAL_GAMEOVER;
			FinalGameOver();
		}

		/// <summary>
		/// Part of the state machine.
		/// Runs when STATE = RUNNING &amp;&amp; NEXTSTEP = FINAL_GAMEOVER
		/// </summary>
		public void FinalGameOver()
		{
			State = State.COMPLETE;
			if (Logging)
			{
				Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : $"{Player1.Name} has {Player1.PlayState} the Game!");
				Log(LogLevel.INFO, BlockType.PLAY, "Game", !Logging ? "" : $"{Player2.Name} has {Player2.PlayState} the Game!");
			}
		}
		#endregion

		internal Action ClearWeapons;
		internal Action ResolveDeadHeroes;
		private static readonly Func<MinionInPlay, int> GetOrderOfPlay = m => m.OrderOfPlay;

		/// <summary>
		/// Move destroyed entities from <see cref="Zone.PLAY"/> <see cref="Zone{T}"/> into 
		/// <see cref="Zone.GRAVEYARD"/>
		/// <para></para>
		/// Death Creation Step (Death event is created but not resolved here)
		/// </summary>
		public void GraveYard()
		{
			if (ClearWeapons != null)
			{
				ClearWeapons.Invoke();
				ClearWeapons = null;
			}

			if (DeadMinions.Count > 0)
			{
				if (History)
					PowerHistoryBuilder.BlockStart(BlockType.DEATHS, 1, "", 0, 0);

				DeadMinions.InsertionSort(GetOrderOfPlay);
				for (int i = 0; i < DeadMinions.Count; i++)
				{
					MinionInPlay minion = DeadMinions[i];
					Log(LogLevel.INFO, BlockType.PLAY, "Game",
						!Logging ? "" : $"{minion} is Dead! Graveyard say 'Hello'!");

					// Death event created
					TriggerManager.OnDeathTrigger(minion);


					int lastBoardPosition = minion.ZonePosition;
					Controller c = minion.Controller;
					c.BoardZone.Remove(minion);

					if (minion.HasDeathrattle)
						minion.ActivateTask(PowerActivation.DEATHRATTLE);

					c.GraveyardZone.Add(minion, lastBoardPosition);
					c.NumFriendlyMinionsThatDiedThisTurn++;
					CurrentPlayer.NumMinionsPlayerKilledThisTurn++;
					NumMinionsKilledThisTurn++;
				}

				if (History)
					PowerHistoryBuilder.BlockEnd();

				DeadMinions.Clear();
			}

			if (ResolveDeadHeroes != null)
			{
				ResolveDeadHeroes.Invoke();
				ResolveDeadHeroes = null;

				if (State == State.COMPLETE)
					return;
				NextStep = Step.FINAL_WRAPUP;
				FinalWrapUp();
			}
		}

		/// <summary>
		/// Update the auras on each zone (which can be influenced by entities from the 
		/// <see cref="Zone.PLAY"/> zone.
		/// </summary>
		public void AuraUpdate()
		{
			List<IAura> auras = Auras;
			for (int i = 0; i < auras.Count; ++i)
				if (!auras[i].Update())
					auras.RemoveAt(i--);
		}

		/// <summary>
		/// Process enqueued tasks.
		/// </summary>
		internal void ProcessTasks()
		{
			if (TaskQueue.IsEmpty()) return;

			TaskQueue.ProcessCurrentEventTasks();
		}

		/// <summary>
		/// Checks for entities which are pending to be destroyed and updated 
		/// active auras accordingly.
		/// </summary>
		public void DeathProcessingAndAuraUpdate()
		{
			//Inter-Phase steps
			
			AuraUpdate();

			// Summon Resolution Step
			if (TriggerManager.HasOnSummonTrigger)
			{
				TaskQueue.StartEvent();
				for (int i = 0; i < SummonedMinions.Count; i++)
					TriggerManager.OnSummonTrigger(SummonedMinions[i], true);
				ProcessTasks();
				TaskQueue.EndEvent();
			}
			SummonedMinions.Clear();

			TaskQueue.StartEvent();
			do
			{
				GraveYard();	// Death Creation Step

				ProcessTasks(); // Death Resolution Phase
			} while (DeadMinions.Count != 0);
			TaskQueue.EndEvent();

			AuraUpdate();	// Aura Update (Other) step(Not implemented)
		}


		/// <summary>
		/// Performs a deep copy of this game instance and returns the result.
		/// </summary>
		/// <returns></returns>
		public Game Clone(bool logging = false, bool resetRandomSeed = true, bool history = false)
		{
			return new Game(this, logging, resetRandomSeed, history);
		}

		internal override void ApplyEffect(AbstractEffect effect)
		{
			effect.ApplyTo(this);
		}
		internal override void RemoveEffect(AbstractEffect effect)
		{
			effect.RemoveFrom(this);
		}

		/// <summary>Builds and stores a logentry, from the specified log message.</summary>
		/// <param name="level"><see cref="LogLevel"/></param>
		/// <param name="block"><see cref="BlockType"/></param>
		/// <param name="location">Rough string respresentation of where in the code the message came from.</param>
		/// <param name="text">The message itself.</param>
		public void Log(LogLevel level, BlockType block, string location, string text)
		{
			if (!Logging)
				return;

			Logs.Enqueue(new LogEntry()
			{
				TimeStamp = DateTime.Now,
				Level = level,
				Location = location,
				BlockType = block,
				Text = text
			});
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

		public void Dump(string location, string text)
		{
			Logs.Enqueue(new LogEntry()
			{
				TimeStamp = DateTime.Now,
				Level = LogLevel.DUMP,
				Location = location,
				BlockType = BlockType.SCRIPT,
				Text = text
			});
		}

		public override string Hash(params GameTag[] ignore)
		{
			var str = new StringBuilder();
			str.Append(base.Hash(ignore));
			str.Append(Player1.Hash(ignore));
			str.Append(Player2.Hash(ignore));
			return str.ToString();
		}

		public string FullPrint()
		{
			var str = new StringBuilder();
			str.AppendLine(Player1.HandZone.FullPrint());
			str.AppendLine(Player1.Hero.FullPrint());
			str.AppendLine(Player1.BoardZone.FullPrint());
			str.AppendLine(Player2.BoardZone.FullPrint());
			str.AppendLine(Player2.Hero.FullPrint());
			str.AppendLine(Player2.HandZone.FullPrint());
			return str.ToString();
		}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

		private readonly EventStack _eventStack = new();

		internal void StartEvent(Playable source, Playable? target, int number = 0) =>
			_eventStack.Push(source, target, number);

		internal void EndEvent() => _eventStack.Pop();

		internal EventMetaData CurrentEventMetaData() => _eventStack.Peek();
		internal EventMetaData? TryGetEventMetaData() => _eventStack.TryPeek(out EventMetaData eventMeta) ? eventMeta : null;
		internal Playable? TryGetEventSource() => _eventStack.TryPeek(out EventMetaData eventMeta) ? eventMeta.EventSource : null;
		internal Playable EventSource() => CurrentEventMetaData().EventSource;
		internal Playable? TryGetEventTarget() => _eventStack.TryPeek(out EventMetaData eventMeta) ? eventMeta.EventTarget : null;
		internal Playable? EventTarget() => CurrentEventMetaData().EventTarget;
		internal int? TryGetEventNumber() => _eventStack.TryPeek(out EventMetaData eventMeta) ? eventMeta.EventNumber : null;
		internal int EventNumber() => CurrentEventMetaData().EventNumber;

		internal EventBlock EventBlock(Playable source, Playable? target, int number = 0) =>
			new(_eventStack, source, target, number);
	}

	public partial class Game
	{
		/// <summary>
		/// Gets or sets the turn count.
		/// </summary>
		/// <value>The amount of player turns that happened in the game. When the game starts (after Mulligan),
		/// value will equal 1.</value>
		public int Turn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.Turn;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.Turn = value;
		}

		/// <summary>
		/// Gets or sets the game state.
		/// </summary>
		/// <value><see cref="State"/></value>
		public State State
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => (State)_attrs.State;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.State = (int)value;
		}

		/// <summary>
		/// Gets or sets the first card played this turn.
		/// </summary>
		/// <value>The entityID of the card.</value>
		public int FirstCardPlayedThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.FirstCardPlayedThisTurn;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.FirstCardPlayedThisTurn = value;
		}

		/// <summary>
		/// The controller which goes 'first'. This player's turn starts after Mulligan.
		/// </summary>
		/// <value><see cref="Controller"/></value>
		public Controller FirstPlayer { get; set;  }
		//{
		//	get => Player1[GameTag.FIRST_PLAYER] == 1 ? Player1 : Player2[GameTag.FIRST_PLAYER] == 1 ? Player2 : null;
		//	set => value[GameTag.FIRST_PLAYER] = 1;
		//}

		/// <summary>
		/// Gets or sets the controller delegating the current turn.
		/// </summary>
		/// <value><see cref="Controller"/></value>
		public Controller CurrentPlayer
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _currentPlayer;
			set
			{
				_currentPlayer = value;
				if (!History) return;
				value.Opponent[GameTag.CURRENT_PLAYER] = 0;
				value[GameTag.CURRENT_PLAYER] = 1;
			}
		}

		/// <summary>
		/// Gets the opponent controller of <see cref="CurrentPlayer"/>.
		/// </summary>
		/// <value><see cref="Controller"/></value>
		//public Controller CurrentOpponent
		//	=> Player1[GameTag.CURRENT_PLAYER] == 1 ? Player2 : Player2[GameTag.CURRENT_PLAYER] == 1 ? Player1 : null;
		public Controller CurrentOpponent => _currentPlayer == Player1 ? Player2 : Player1;

		/// <summary>
		/// Gets or sets the CURRENT step. These steps occur within <see cref="State.RUNNING"/> and
		/// indicate states which are used to process actions.
		/// </summary>
		/// <value><see cref="Step"/></value>
		public Step Step
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => (Step)_attrs.Step;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.Step = (int)value;
		}

		/// <summary>
		/// Gets or sets the NEXT step. <seealso cref="Step"/>
		/// </summary>
		/// <value><see cref="Step"/></value>
		public Step NextStep
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => (Step)_attrs.NextStep;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_attrs.NextStep = (int)value;
				Step = value;
			}
		}

		/// <summary>
		/// Gets or sets the number of killed minions for this turn.
		/// </summary>
		/// <value>The amount of killed minions.</value>
		public int NumMinionsKilledThisTurn
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.NumMinionsKilledThisTurn;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.NumMinionsKilledThisTurn = value;
		}

		/// <summary>
		/// The entityID of the character which wants to attack, by entering the
		/// next combat phase.
		/// </summary>
		public int ProposedAttacker
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.ProposedAttacker;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.ProposedAttacker = value;
		}

		/// <summary>
		/// The entityID of the character which has to defend during the next
		/// combat phase.
		/// </summary>
		public int ProposedDefender
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _attrs.ProposedDefender;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => _attrs.ProposedDefender = value;
		}

		/// <summary>Gets the heroes.</summary>
		/// <value><see cref="Hero"/></value>
		public List<Hero> Heroes => new List<Hero> { Game.Player1.Hero, Game.Player2.Hero };

		/// <summary>Gets ALL minions (from both sides of the board).</summary>
		/// <value><see cref="Minion"/></value>
		public List<Minion> Minions
		{
			get
			{
				var list = new List<Minion>();
				list.AddRange(Game.Player1.BoardZone);
				list.AddRange(Game.Player2.BoardZone);
				return list;
			}
		}

		/// <summary>Gets ALL characters.</summary>
		/// <value><see cref="Character"/></value>
		public List<Character> Characters
		{
			get
			{
				var list = new List<Character>();
				list.AddRange(Minions);
				list.AddRange(Heroes);
				return list;
			}
		}
	}

	public partial class Game
	{
		//private const int CHARACTERS_LENGTH = 16;
		//// 0 : P1 Hero
		//// 1 - 7 : P1 Minions
		//// 8 - 14 : P2 Minions
		//// 15 : P2 Hero
		//internal readonly Character[] _characters;
	}
}
