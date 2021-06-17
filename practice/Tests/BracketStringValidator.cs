using System.Collections.Generic;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).
	/// For example, given the string "([])[]({})", you should return true.
	/// Given the string "([)]" or "((()", you should return false.
	/// </summary>
	public class BracketStringValidator
	{
		private static readonly Dictionary<char, char> IdentityMap = new Dictionary<char, char>
		{
			{')', '('},
			{'}', '{'},
			{']', '['},
		};

		private static readonly Stack<char> Buffer = new Stack<char>();

		[Test]
		public void Test()
		{
			Assert.IsTrue(IsBracketsValid("([])[]({})"));
			Assert.IsTrue(IsBracketsValid("([{}{()([{}])}])[]({})"));
			Assert.IsFalse(IsBracketsValid("([{}{()([{}])}])[]({)}"));
			Assert.IsFalse(IsBracketsValid("([)]"));
			Assert.IsFalse(IsBracketsValid("((()"));
			Assert.IsFalse(IsBracketsValid("((("));
			Assert.IsFalse(IsBracketsValid(")))"));
			Assert.IsFalse(IsBracketsValid("00"));
		}

		private bool IsBracketsValid(string source)
		{
			var isEven = source.Length % 2 == 0;
			if (!isEven)
			{
				return false;
			}

			Buffer.Clear();
			foreach (var symbol in source)
			{
				if (!ProcessSymbol(symbol, Buffer))
				{
					return false;
				}
			}

			var allBracketsClosed = Buffer.Count == 0;
			return allBracketsClosed;
		}

		private static bool ProcessSymbol(char symbol, Stack<char> buffer)
		{
			var isCloseSymbol = IdentityMap.TryGetValue(symbol, out var openSymbol);
			if (!isCloseSymbol)
			{
				buffer.Push(symbol);
				return true;
			}

			var hasOpenBrackets = buffer.Count != 0;
			var hasMatchingBrackets = hasOpenBrackets && buffer.Pop() == openSymbol;
			return hasMatchingBrackets;
		}
	}
}