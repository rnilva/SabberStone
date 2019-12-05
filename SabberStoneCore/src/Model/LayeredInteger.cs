namespace SabberStoneCore.Model
{
	public struct LayeredInteger
	{
		private int AuraValue;
		private int Value;

		public void Add(int value)
		{
			Value += value;
		}

		public void AddAura(int value)
		{
			AuraValue += value;
		}

		public static unsafe implicit operator int(LayeredInteger li)
		{
			int temp = li.AuraValue + li.Value;
			return temp > 0 ? temp : 0;

			//while (li.AuraValue != 0)
			//{
			//	int carry = li.AuraValue & li.Value;
			//	li.AuraValue ^= li.Value;
			//	li.Value = carry << 1;
			//}
			//return li.Value;

			//int* vPtr = (int*)&li;

		}

		public static int operator+(LayeredInteger li, int operand)
		{
			li.Value += operand;
			return li;
		}
	}

	public class Test
	{
		public LayeredInteger TestAttr;

		ref LayeredInteger TestMethod()
		{
			return ref TestAttr;
		}

		public static void TestFunction()
		{
			var test = new Test();
			ref LayeredInteger refInt = ref test.TestMethod();
		}
	}
}
