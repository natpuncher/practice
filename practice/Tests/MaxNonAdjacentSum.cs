using System.Collections.Generic;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given a list of integers
	/// Write a function that returns the largest sum of non-adjacent numbers
	/// Numbers can be 0 or negative.
	/// For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5.
	/// [5, 1, 1, 5] should return 10, since we pick 5 and 5.
	/// </summary>
	[TestFixture]
	public class MaxNonAdjacentSum
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(13, GetMaxNonAdjacentSum(new []{2, 4, 6, 2, 5}));
			Assert.AreEqual(10, GetMaxNonAdjacentSum(new []{5, 1, 1, 5}));
		}

		private int GetMaxNonAdjacentSum(int[] array)
		{
			var data = new List<SumData>();
			return 0;
		}

		public class SumData
		{
			public int Sum { get; }
			
			private int _lastIndex;

			public void Add(int index, int val)
			{
			}
		}
	}
}