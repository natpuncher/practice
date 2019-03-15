using System.Collections.Generic;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Have an array of ints
	/// Need to find is there a pair, that sum is matching the giving number
	/// [1, 3, 2, 4] and sum = 5, should return true
	/// </summary>
	[TestFixture]
	public class PairMatchingSum
	{
		[Test]
		public void Test()
		{
			Assert.True(HasMatchingPair(new []{1, 3, 2, 4}, 5));
			Assert.True(HasMatchingPair(new []{1, 3, 2, 4}, 6));
			Assert.True(HasMatchingPair(new []{1, 3, 2, 4}, 7));
			Assert.True(HasMatchingPair(new []{1, 3, 2, 4}, 4));
			Assert.True(HasMatchingPair(new []{1, 3, 2, 4}, 3));
			
			Assert.False(HasMatchingPair(new []{1, 3, 2, 4}, 8));
			Assert.False(HasMatchingPair(new []{1, 3, 2, 4}, 2));
			Assert.False(HasMatchingPair(new []{1, 3, 2, 4}, 12));
		}

		/// <summary>
		/// The idea is to store deltas into some cache while iterating
		/// </summary>
		/// <param name="array"></param>
		/// <param name="sum"></param>
		/// <returns></returns>
		private bool HasMatchingPair(int[] array, int sum)
		{
			var cache = new HashSet<int>();
			
			var arrayLength = array.Length;
			for (var i = 0; i < arrayLength; i++)
			{
				var delta = sum - array[i];
				if (cache.Contains(delta))
				{
					return true;
				}

				if (!cache.Contains(array[i]))
				{
					cache.Add(array[i]);
				}
			}

			return false;
		}
	}
}