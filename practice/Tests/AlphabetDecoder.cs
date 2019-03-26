using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// 
	/// </summary>
	[TestFixture]
	public class AlphabetDecoder
	{
		[Test]
		public void Test()
		{
			var alphabet = CreateAlphabet();
			Assert.Pass();
		}

		private int GetDecodeWayCount(int decodedData)
		{
			return 0;
		}
		
		private char[] CreateAlphabet()
		{
			var letterCount = 26;
			
			var result = new char[letterCount];
			for (var i = 0; i < letterCount; i++)
			{
				result[i] = (char)(97 + i);
			}

			return result;
		}
	}
}