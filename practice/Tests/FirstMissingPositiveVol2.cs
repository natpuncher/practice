using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given an array of integers, find the first missing positive integer in linear time and constant space.
	/// In other words, find the lowest positive integer that does not exist in the array.
	/// The array can contain duplicates and negative numbers as well.
	/// For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
	/// You can modify the input array in-place.
	/// </summary>
	public class FirstMissingPositiveVol2
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(2, FindMinMissingPositive(new[] {3, 4, -1, 1}));
			Assert.AreEqual(3, FindMinMissingPositive(new[] {1, 2, 0}));
			Assert.AreEqual(5, FindMinMissingPositive(new[] {3, 7, 6, -1, 1, 0, 4, 2}));
		}

		private int FindMinMissingPositive(int[] array)
		{
			var indexes = new List<bool>();
			foreach (var val in array)
			{
				if (val < 1)
				{
					continue;
				}
				
				if (val > indexes.Count)
				{
					indexes.AddRange(Enumerable.Repeat(false, val - indexes.Count));
				}

				indexes[val - 1] = true;
			}

			var result = indexes.Count + 1;
			for (var index = 0; index < indexes.Count; index++)
			{
				if (indexes[index])
				{
					continue;
				}
				
				result = index + 1;
				break;
			}

			return result;
		}
	}
}