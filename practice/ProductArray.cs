using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given an array of integers
	/// return a new array such that each element at index i of the new array is the product of all the numbers
	/// in the original array except the one at i.
	/// For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]
	/// If our input was [3, 2, 1], the expected output would be [2, 3, 6].
	/// </summary>
	[TestFixture]
	public class ProductArray
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(new []{120, 60, 40, 30, 24}, GetProductArray(new []{1, 2, 3, 4, 5}));
			Assert.AreEqual(new []{2, 3, 6}, GetProductArray(new []{3, 2, 1}));
		}

		/// <summary>
		/// Calculate the product of all elements in the giving array
		/// Divide it to each element
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		private int[] GetProductArray(int[] array)
		{
			var arrayLength = array.Length;
			
			var result = new int[arrayLength];
			
			var product = GetProduct(array, arrayLength);

			for (var i = 0; i < arrayLength; i++)
			{
				result[i] = product / array[i];
			}

			return result;
		}

		private static int GetProduct(int[] array, int arrayLength)
		{
			var product = 1;
			for (var i = 0; i < arrayLength; i++)
			{
				product *= array[i];
			}

			return product;
		}
	}
}