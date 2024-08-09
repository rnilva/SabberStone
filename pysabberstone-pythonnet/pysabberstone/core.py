from pathlib import Path

import pythonnet

pythonnet.load("coreclr")
import clr

lib_path = Path(__file__).parent / "lib" / "SabberStoneCore"

clr.AddReference(str(lib_path.resolve()))
