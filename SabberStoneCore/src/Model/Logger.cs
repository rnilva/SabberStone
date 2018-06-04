using System;
using System.Collections.Generic;
using SabberStoneCore.Enums;

namespace SabberStoneCore.Model
{
	public enum LogLevel
	{
		DUMP, ERROR, WARNING, INFO, VERBOSE, DEBUG
	}

	public class LogEntry
	{
		public DateTime TimeStamp { get; set; }
		public LogLevel Level { get; set; }
		public BlockType BlockType { get; set; }
		public string Location { get; set; }
		public string Text { get; set; }

	}


	//public static class Analyser
	//{
	//	public static List<int> Dump = new List<int>(1000000);
	//	public static readonly HashSet<string> Tasks = new HashSet<string>();

	//	private static readonly List<List<int>> Dumps = new List<List<int>>();

	//	public static void Add(int i)
	//	{
	//		Dump.Add(i);
	//		if (Dump.Count != 1000000) return;
	//		Dumps.Add(Dump);
	//		Dump = new List<int>(1000000);

	//	}

	//	public static double GetAverage()
	//	{
	//		long sum = 0;
	//		long count = 0;
	//		foreach (var dump in Dumps)
	//		{
	//			for (int i = 0; i < dump.Count; i++)
	//				sum += dump[i];
	//			count += dump.Count;
	//		}

	//		return sum / (double)count;
	//	}

	//	public static void PrintNames()
	//	{
	//		foreach (var name in Tasks)
	//		{
	//			Console.WriteLine(name);
	//		}
	//	}
	//}
}
