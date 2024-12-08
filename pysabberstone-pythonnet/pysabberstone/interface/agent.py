import random
from abc import ABC, abstractmethod

from pysabberstone.model.game import Game, GameConfig
from pysabberstone.model.player import Player
from pysabberstone.model.player_task import PlayerTask

import pysabberstone.core
from SabberStoneCore.Tasks.PlayerTasks import ChooseTask as _ChooseTask # type: ignore
from SabberStoneBasicAI import IAgent as _IAgent  # type: ignore
from System.Collections.Generic import List as _List # type: ignore


class Agent(ABC):
    @abstractmethod
    def get_action(self, game: Game, player: Player) -> PlayerTask: ...

    @abstractmethod
    def mulligan(self, game: Game, player: Player) -> list[int]: ...

    @property
    def name(self):
        return self.__class__.__name__

    def on_match_started(self):
        return
    
    def on_match_finished(self):
        return

    def on_game_started(self):
        return

    def on_game_finished(self):
        return


class DotNetAgentWrapper(Agent):
    def __init__(self, _agent) -> None:
        super().__init__()
        self._agent = _agent

    def get_action(self, game: Game, player: Player) -> PlayerTask:
        _task = self._agent.GetAction(game._game, player._controller)
        return PlayerTask.from_core_type(_task)

    def mulligan(self, game: Game, player: Player) -> list[int]:
        _choose_task = self._agent.Mulligan(game._game, player._controller)
        return list(_choose_task.Choices)


class _PythonAgentWrapper(_IAgent):
    __namespace__ = "pysabberstone.agent"

    def __init__(self, agent: Agent) -> None:
        super().__init__()
        self._agent = agent

    def get_Name(self):
        return self._agent.name

    def GetAction(self, _game, _controller):
        game = Game.from_core_type(_game)
        action = self._agent.get_action(game, game.players[_controller.PlayerId - 1])
        return action._to_core_type()

    def Mulligan(self, _game, _controller):
        game = Game.from_core_type(_game)
        choices = self._agent.mulligan(game, game.players[_controller.PlayerId - 1])

        _choices = _List()
        for i in choices:
            _choices.Add(i)
        return _ChooseTask(_controller, _choices)
    
    def OnMatchStarted(self):
        self._agent.on_match_started()

    def OnMatchFinished(self):
        self._agent.on_match_finished()

    def OnGameStarted(self):
        self._agent.on_game_started()

    def OnGameFinished(self):
        self._agent.on_game_finished()


def _to_core_agent(agent: Agent) -> _IAgent:
    if isinstance(agent, DotNetAgentWrapper):
        return agent._agent
    
    return _PythonAgentWrapper(agent)


class RandomAgent(Agent):
    def __init__(self, seed: int) -> None:
        super().__init__()
        self.rng = random.Random(seed)

    def get_action(self, game: Game, player: Player) -> PlayerTask:
        options = game.get_options()
        return self.rng.choice(options)

    def mulligan(self, game: Game, player: Player) -> list[int]:
        return []
