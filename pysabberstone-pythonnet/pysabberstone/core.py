from pathlib import Path

import pythonnet

pythonnet.load("coreclr")
import clr

lib_path = Path(__file__).parent / "lib" / "SabberStoneCore"
ai_lib_path = Path(__file__).parent / "lib" / "SabberStoneBasicAI"

clr.AddReference(str(lib_path.resolve()))
clr.AddReference(str(ai_lib_path.resolve()))
