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

using System;
using System.Collections.Generic;
using System.Text;
using SabberStoneCore.Config;
using SabberStoneCore.Enums;
using SabberStoneCore.Model;
using Xunit;

namespace SabberStoneCoreTest.Basic
{
	public class UtilsTest
	{
		[Fact]
		public void UtilTest()
		{
			var enumarable = new List<string>() { "A", "B", "C" };
			var dict = new Dictionary<string, int>();
			var rnd = new Util.DeepCloneableRandom();
			for (int i = 0; i < 1000; i++)
			{
				string str = enumarable.RandomElement(rnd);
				if (dict.ContainsKey(str))
				{
					dict[str] = dict[str] + 1;
				}
				else
				{
					dict[str] = 1;
				}
			}
			Assert.True(dict["A"] > 300);
			Assert.True(dict["B"] > 300);
			Assert.True(dict["C"] > 300);
		}

		[Fact]
		public void RandomSeedTest()
		{
			var globalRandom = new Random();
			int seed = globalRandom.Next();

			var rnd = new Util.DeepCloneableRandom(seed);
			sbyte[] bytes = new sbyte[10000];
			rnd.NextBytes(bytes);

			Util.ThreadLocalRandom.SetSeed(seed);
			rnd = new Util.DeepCloneableRandom(seed);
			sbyte[] bytes2 = new sbyte[10000];
			rnd.NextBytes(bytes2);

			Assert.Equal(bytes, bytes2);
		}

		[Fact]
		public void DeepClonableRandomTest()
		{
			var rnd1 = new Util.DeepCloneableRandom();
			rnd1.Next();
			Util.DeepCloneableRandom rnd2 = rnd1.Clone();

			for (int i = 0; i < 1000; i++)
				Assert.Equal(rnd1.Next(), rnd2.Next());
		}

		[Fact]
		public void PriorityQueueTest()
		{
			var queue = new Util.PriorityQueue<int>();

			for (int i = 0; i < 10; ++i)
				queue.Enqueue(i, i);
			for (int i = 5; i >= 0; --i)
				queue.Enqueue(i, i);

			var list = new List<int>();
			while (queue.Count != 0)
				list.Add(queue.Dequeue());

			var expected = new List<int>
			{
				0, 0,
				1, 1,
				2, 2,
				3, 3,
				4, 4,
				5, 5,
				6, 7, 8, 9
			};

			Assert.Equal(expected, list);
		}
	}
}
