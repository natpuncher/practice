using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Using a function rand5() that returns an integer from 1 to 5 (inclusive) with uniform probability,
	/// implement a function rand7() that returns an integer from 1 to 7 (inclusive).
	/// </summary>
	[TestFixture]
	public class Rnd5ToRnd7
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(7, GetRand7(5));
			Assert.AreEqual(1, GetRand7(1));
			Assert.AreEqual(4, GetRand7(3));
		}

		private int GetRand7(int rand5) // 1 .. 5
		{
			var normalizeValue = (rand5 - 1) * 1.0f / 4; // (0 .. 4) / 4 => 0 .. 1
			return (int)(normalizeValue * 6) + 1;
		}
	}
}