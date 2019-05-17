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

		/// <summary>
		/// [2, 4, 6, 2, 5]
		/// [4, 8, 6, 11, 2] - negate
		///
		/// [5, 1, 1, 5]
		/// [1, 5, 6, 1] - negate
		///
		/// [5, 1, 1, 5, 5, 1, 1, 5]
		/// [1, 6, 6, 6, 6, 6, 6, 1] - negate
		///
		/// if array.all(i < 0) -> return array.max
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		private int GetMaxNonAdjacentSum(int[] array)
		{
			var result = 0;

			var arrayLength = array.Length;
			var index = 0;
			while (index < arrayLength)
			{
				var first = array[index];
				
				var isLastElement = index == arrayLength - 1;
				if (isLastElement)
				{
					result += first;
					index += 2;
					continue;
				}
				
				var second = array[index + 1];

				var negate1 = GetNegate(index, array);
				var negate2 = GetNegate(index + 1, array);

				if (negate1 > negate2)
				{
					result += second;
					index += 1;
				}
				else if (negate1 < negate2)
				{
					result += first;
				}
				else
				{
					if (second > first)
					{
						result += second;
						index += 1;
					}
					else
					{
						result += first;
					}
				}
				
				index += 2;
			}
			
			return result;
		}

		/// <summary>
		/// get sum of adjacent elements
		/// </summary>
		/// <param name="index"></param>
		/// <param name="array"></param>
		/// <returns></returns>
		private int GetNegate(int index, int[] array)
		{
			var isFirst = index == 0;
			if (isFirst)
			{
				return array[1];
			}

			var isLast = index == array.Length - 1;
			if (isLast)
			{
				return array[index - 1];
			}
			
			return array[index + 1] + array[index - 1];
		}
	}
}