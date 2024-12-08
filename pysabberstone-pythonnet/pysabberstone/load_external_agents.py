import importlib
from pathlib import Path

from pysabberstone.interface.agent import DotNetAgentWrapper, Agent

import pysabberstone.core
from pysabberstone.core import clr
from SabberStoneBasicAI.Agents import FindAgents # type: ignore


class ExternalAgentMeta(type(DotNetAgentWrapper)):
    def __new__(cls, name: str, bases: tuple, attrs: dict):
        loaded_type = attrs["__loaded_agent__"]

        def __init__(self, *args, **kwargs):
            loaded_agent_instance = loaded_type(*args, **kwargs)
            DotNetAgentWrapper.__init__(self, loaded_agent_instance)

        attrs["__init__"] = __init__

        return super().__new__(cls, name, (DotNetAgentWrapper,) + bases, attrs)


def load():
    dir = Path(__file__).parent / "external_agents"

    for file in dir.iterdir():
        if file.suffix == ".dll":
            try:
                clr.AddReference(str(file.resolve())) # type: ignore
            except Exception as e:
                print(e)
            finally:
                print(f"External module {file.name} is loaded.")

    qualified_names: list[str] = list(FindAgents.Find())

    loaded_agents: dict[str, ExternalAgentMeta] = {}
    for q_name in qualified_names:
        type_spec = q_name.split(",")[0]
        *modules, class_name = type_spec.split(".")
        module = importlib.import_module(".".join(modules))
        cls = getattr(module, class_name)

        agent_type = ExternalAgentMeta(type_spec, (), {"__loaded_agent__": cls})
        loaded_agents[type_spec] = agent_type

    return loaded_agents


if __name__ == "__main__":
	agents = load()
	print(agents)
