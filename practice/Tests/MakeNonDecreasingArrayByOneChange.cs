using System.Linq;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given an array of integers, write a function to determine whether the array could become non-decreasing by modifying at most 1 element.
	/// For example, given the array [10, 5, 7], you should return true, since we can modify the 10 into a 1 to make the array non-decreasing.
	/// Given the array [10, 5, 1], you should return false, since we can't modify any one element to get a non-decreasing array.
	/// </summary>
	public class MakeNonDecreasingArrayByOneChange
	{
		[Test]
		public void Test()
		{
			Assert.IsTrue(TryTransformToNonDecreasingArray(new[] {10, 5, 7}, out var result));
			Assert.IsFalse(TryTransformToNonDecreasingArray(new[] {10, 5, 1}, out var result1));
			Assert.IsFalse(TryTransformToNonDecreasingArray(new[] {10, 5, 5}, out var result2));
			Assert.IsTrue(TryTransformToNonDecreasingArray(new[] {1, 5, 5, 6, 7}, out var result3));
			Assert.IsFalse(TryTransformToNonDecreasingArray(new[] {10, 5, 5, 6, 7}, out var result4));
			Assert.IsFalse(TryTransformToNonDecreasingArray(new[] {1, 5, 10, 6, 7}, out var result5));
		}

		private bool TryTransformToNonDecreasingArray(int[] array, out int[] nonDecreasingArray)
		{
			nonDecreasingArray = array.ToArray();
			
			var hasOneError = false;
			for (var index = 0; index < nonDecreasingArray.Length - 1; index++)
			{
				var element = nonDecreasingArray[index];
				var nextElement = nonDecreasingArray[index + 1];
				var isElementAscending = element < nextElement;
				if (isElementAscending)
				{
					continue;
				}

				if (hasOneError)
				{
					return false;
				}

				hasOneError = true;

				var hasPreviousElement = index > 0;
				if (!hasPreviousElement)
				{
					continue;
				}

				var previousElement = nonDecreasingArray[index - 1];
				var canBeModified = nextElement - previousElement > 1;
				if (!canBeModified)
				{
					return false;
				}

				nonDecreasingArray[index] = nextElement - 1;
			}

			return true;
		}
	}
}