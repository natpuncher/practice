using System.Collections.Generic;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// You are given a histogram consisting of rectangles of different heights.
	/// These heights are represented in an input list, such that [1, 3, 2, 5] corresponds to the following diagram:
	///       x
	///       x
	///   x   x
	///	  x x x
	/// x x x x
	/// Determine the area of the largest rectangle that can be formed only from the bars of the histogram.
	/// For the diagram above, for example, this would be six, representing the 2 x 3 area at the bottom right.
	/// </summary>
	public class MaximumRectangleArea
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(6, GetMaximumRectangleArea(new[] {1, 3, 2, 5, 1}));
			Assert.AreEqual(6, GetMaximumRectangleArea(new[] {1, 3, 2, 5}));
			Assert.AreEqual(5, GetMaximumRectangleArea(new[] {1, 2, 3, 1, 2}));
			Assert.AreEqual(31, GetMaximumRectangleArea(new[] {1, 2, 31, 1, 2}));
			Assert.AreEqual(6, GetMaximumRectangleArea(new[] {1, 3, 2, 5}));
			Assert.AreEqual(10, GetMaximumRectangleArea(new[] {1, 3, 2, 5, 5}));
			Assert.AreEqual(8, GetMaximumRectangleArea(new[] {1, 3, 2, 5, 3}));
			Assert.AreEqual(4, GetMaximumRectangleArea(new[] {1, 1, 2, 1}));
			Assert.AreEqual(7, GetMaximumRectangleArea(new[] {1, 7, 1, 1}));
			Assert.AreEqual(6, GetMaximumRectangleArea(new[] {1, 1, 1, 1, 1, 1, 0, 1, 1, 1}));
		}

		private int GetMaximumRectangleArea(int[] heights)
		{
			var areaIndexes = new Stack<int>();

			var maximumArea = 0;

			var heightsLength = heights.Length;
			for (var index = 0; index < heightsLength; index++)
			{
				if (!IsAscending(index, areaIndexes, heights))
				{
					var area = GetMaximumBufferArea(ref areaIndexes, index, heights);
					if (area > maximumArea)
					{
						maximumArea = area;
					}
				}

				areaIndexes.Push(index);
			}

			while (areaIndexes.Count > 0)
			{
				var area = GetArea(ref areaIndexes, heightsLength, heights);
				if (area > maximumArea)
				{
					maximumArea = area;
				}
			}

			return maximumArea;
		}

		private bool IsAscending(int index, Stack<int> indexesBuffer, int[] heights)
		{
			return indexesBuffer.Count == 0 || heights[index] >= heights[indexesBuffer.Peek()];
		}

		private int GetMaximumBufferArea(ref Stack<int> indexesBuffer, int lastIndex, int[] heights)
		{
			var maximumArea = 0;
			while (!IsAscending(lastIndex, indexesBuffer, heights))
			{
				var area = GetArea(ref indexesBuffer, lastIndex, heights);
				if (area > maximumArea)
				{
					maximumArea = area;
				}
			}

			return maximumArea;
		}

		private int GetArea(ref Stack<int> indexesBuffer, int lastIndex, int[] heights)
		{
			if (indexesBuffer.Count == 0)
			{
				return 0;
			}

			var index = indexesBuffer.Pop();
			var height = heights[index];
			var areaStartIndex = indexesBuffer.Count > 0 ? indexesBuffer.Peek() + 1 : 0;
			var length = lastIndex - areaStartIndex;
			var area = height * length;
			return area;
		}
	}
}