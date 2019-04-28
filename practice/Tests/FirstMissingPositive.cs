using System.Collections.Generic;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given an array of integers, find the first missing positive integer in linear time and constant space.
	/// In other words, find the lowest positive integer that does not exist in the array.
	/// The array can contain duplicates and negative numbers as well.
	/// For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
	/// </summary>
	[TestFixture]
	public class FirstMissingPositive
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(2, FindMinMissingPositive(new []{3, 4, -1, 1}));
			Assert.AreEqual(3, FindMinMissingPositive(new []{1, 2, 0}));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		private int FindMinMissingPositive(int[] array)
		{
			var result = 1;

			var cache = new HashSet<int>();
			var arrayLength = array.Length;
			for (var i = 0; i < arrayLength; i++)
			{
				var element = array[i];
				if (cache.Contains(element))
				{
					continue;
				}

				cache.Add(element);

				if (result < element)
				{
					continue;
				}
				
				result = GetMinNotInCache(cache, element, result);
			}

			return result;
		}

		private int GetMinNotInCache(HashSet<int> cache, int border, int result)
		{
			while (result <= border || cache.Contains(result))
			{
				result++;
			}
			return result;
		}
	}
}