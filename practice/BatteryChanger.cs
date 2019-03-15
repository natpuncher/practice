using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Have an array [4, 0, 2, 0, 2, 0]
	/// that means batteries with charge equals to array value
	/// Each move to the next index will cost you 1 charge
	/// You can change your battery at any point you stay
	/// Should say can you go outside the array from 0 index
	/// </summary>
	[TestFixture]
	public class BatteryChanger
	{
		[Test]
		public void Test()
		{
			Assert.True(CanGoOutside(new[] {4, 2, 0, 0, 2, 0}));
			Assert.True(CanGoOutside(new[] {4, 0, 1, 0, 1, 10, 0, 2}));

			Assert.False(CanGoOutside(new[] {1, 0}));
			Assert.False(CanGoOutside(new[] {0, 2}));
			Assert.False(CanGoOutside(new[] {1, 0, 1, 0, 1, 0, 10, 0}));
			Assert.False(CanGoOutside(new[] {1, 0, 1, 0, 1, 1, 0, 2}));
			Assert.False(CanGoOutside(new[] {0, 1, 1, 0, 1, 10, 0, 2}));
		}

		/// <summary>
		/// The idea is going from the end and calculating move points to achieve this position
		/// If you find a battery, check is it carrying your move points and if so, reset the required move points
		/// </summary>
		/// <param name="batteries"></param>
		/// <returns></returns>
		public bool CanGoOutside(int[] batteries)
		{
			var movePoints = 0;
			for (var i = batteries.Length - 1; i >= 0; i--)
			{
				movePoints++;
				var currentMovePoints = batteries[i];
				if (movePoints <= currentMovePoints)
				{
					movePoints = 0;
				}
			}
			return movePoints == 0;
		}
	}
}