using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given a array of numbers representing the stock prices of a company in chronological order,
	/// write a function that calculates the maximum profit you could have made from buying and selling that stock once.
	/// You must buy before you can sell it.
	/// For example, given [9, 11, 8, 5, 7, 10], you should return 5,
	/// since you could buy the stock at 5 dollars and sell it at 10 dollars.
	/// </summary>
	public class StockMaximumProfit
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(5, CalculateMaximumProfit(new []{9, 11, 8, 5, 7, 10, 2}));
			Assert.AreEqual(5, CalculateMaximumProfit(new []{7, 11, 8, 5, 7, 10, 2}));
		}

		private int CalculateMaximumProfit(int[] stockPrices)
		{
			var maxProfit = 0;
			var minValue = int.MaxValue;
			foreach (var stockPrice in stockPrices)
			{
				if (stockPrice < minValue)
				{
					minValue = stockPrice;
					continue;
				}

				var profit = stockPrice - minValue;
				if (profit > maxProfit)
				{
					maxProfit = profit;
				}
			}
			return maxProfit;
		}
	}
}