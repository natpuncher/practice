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
				var isLastElement = index == arrayLength - 1;
				if (isLastElement)
				{
					// get first
				}
				
				var first = array[index];
				var second = array[index + 1];

				var negate1 = GetNegate(index, array);
				var negate2 = GetNegate(index + 1, array);

				if (negate1 > negate2)
				{
					// get second
				}
				else if (negate1 < negate2)
				{
					// get first
				}
				else
				{
					if (second > first)
					{
						//get second
					}
					else
					{
						// get first
					}
				}

				index++;
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
			return 0;
		}
	}
}