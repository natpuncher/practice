using System.Linq;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time.
	/// Given N, write a function that returns the number of unique ways you can climb the staircase.
	/// The order of the steps matters.
	/// For example, if N is 4, then there are 5 unique ways:
	/// 1, 1, 1, 1
	/// 2, 1, 1
	/// 1, 2, 1
	/// 1, 1, 2
	/// 2, 2
	/// What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X?
	/// For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
	/// </summary>
	[TestFixture]
	public class StaircaseClimb
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(5, GetUniqueWaysCount(4, new[] {1, 2}));
			Assert.AreEqual(3, GetUniqueWaysCount(4, new[] {1, 3, 5}));
			Assert.AreEqual(12, GetUniqueWaysCount(7, new[] {1, 3, 5}));
		}

		private int GetUniqueWaysCount(int staircaseSteps, int[] possibleMoves)
		{
			return InternalCount(staircaseSteps, possibleMoves, possibleMoves.Length, possibleMoves.Min());
		}

		private int InternalCount(int staircaseSteps, int[] possibleMoves, int length, int min)
		{
			var isTerminal = staircaseSteps < min;
			if (isTerminal)
			{
				return 1;
			}

			var sum = 0;
			for (var i = 0; i < length; i++)
			{
				var step = possibleMoves[i];
				if (staircaseSteps < step)
				{
					continue;
				}
				sum += InternalCount(staircaseSteps - step, possibleMoves, length, min);
			}

			return sum;
		}
	}
}