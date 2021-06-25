using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given three 32-bit integers x, y, and b,
	/// return x if b is 1 and y if b is 0, using only mathematical or bit operations.
	/// You can assume b can only be 1 or 0.
	/// </summary>
	public class ChoseValue
	{
		[Test]
		public void Test()
		{
			var x = 10;
			var y = 29;
			Assert.IsTrue(Chose(x, y, 1) == x);
			Assert.IsTrue(Chose(x, y, 0) == y);
		}

		private int Chose(int x, int y, int b)
		{
			return x * b + y * (1 - b);
		}
	}
}