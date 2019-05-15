using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// There is an N by M matrix of zeroes. Given N and M
	///  write a function to count the number of ways of starting at the top-left corner
	/// and getting to the bottom-right corner. You can only move right or down.
	/// For example, given a 2 by 2 matrix, you should return 2, since there are two ways to get to the bottom-right:
	/// Right, then down
	/// Down, then right
	/// Given a 5 by 5 matrix, there are 70 ways to get to the bottom-right.
	/// </summary>
	[TestFixture]
	public class RightDownMatrixWalker
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(2, GetWayCount(2, 2));
			Assert.AreEqual(6, GetWayCount(3, 3));
			Assert.AreEqual(28, GetWayCount(3, 7));
			Assert.AreEqual(20, GetWayCount(4, 4));
			Assert.AreEqual(70, GetWayCount(5, 5));
		}

		private int GetWayCount(int n, int m)
		{
			if (n == 1 || m == 1)
			{
				return 1;
			}

			return GetWayCount(n - 1, m) + GetWayCount(n, m - 1);
		}
	}
}