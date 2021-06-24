using System;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
	/// </summary>
	public class MonteCarloPiEstimation
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(Math.PI, EstimatePi(), 0.001d);
		}

		private double EstimatePi()
		{
			var random = new Random(123123);
			var iterations = 100000;
			var inCircleCount = 0d;
			var r = 1d;
			for (var i = 0; i < iterations; i++)
			{
				var x = random.NextDouble();
				var y = random.NextDouble();
				var isInCircle = x * x + y * y <= r;
				if (!isInCircle)
				{
					continue;
				}
				inCircleCount++;
			}
			return (inCircleCount / iterations) * 4;
		}
	}
}