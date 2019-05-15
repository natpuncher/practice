using System;
using System.Text;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Implement a URL shortener with the following methods:
	/// shorten(url), which shortens the url into a six-character alphanumeric string, such as zLg6wl.
	/// restore(short), which expands the shortened string into the original url.
	/// If no such shortened string exists, return null.
	/// </summary>
	[TestFixture]
	public class URLShortener
	{
		private static readonly char[] SymbolMap = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
		
		[Test]
		public void Test()
		{
			var url = "https://www.youtube.com/watch?v=_5c-6SFYl94";
			var shortUrl = Shorten(url);
			Console.WriteLine(shortUrl);
			Console.WriteLine(shortUrl.Length);
			Assert.LessOrEqual(shortUrl.Length, 6);
//			var restored = Restore(shortUrl);
//			Assert.AreEqual(url, restored);
		}

		private string Shorten(string url)
		{
			var sb = new StringBuilder();

			var mapLength = SymbolMap.Length;
			var urlLength = url.Length;
			while (urlLength > 0)
			{
				sb.Append(SymbolMap[urlLength % mapLength]);
				urlLength /= mapLength;
			}
			
			return sb.ToString();
		}

		private int GetId(string url)
		{
			return 0;
		}

		private string Restore(string shortUrl)
		{
			var sb = new StringBuilder();
			return sb.ToString();
		}
	}
}