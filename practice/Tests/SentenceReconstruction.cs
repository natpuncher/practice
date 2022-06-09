using System.Collections.Generic;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given a dictionary of words and a string made up of those words (no spaces),
	/// return the original sentence in a list. If there is more than one possible reconstruction,
	/// return any of them. If there is no possible reconstruction, then return null.
	/// For example, given the set of words 'quick', 'brown', 'the', 'fox', and the string "thequickbrownfox",
	/// you should return ['the', 'quick', 'brown', 'fox'].
	/// Given the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', and the string "bedbathandbeyond",
	/// return either ['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].
	/// </summary>
	public class SentenceReconstruction
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(
				new List<string> { "the", "quick", "brown", "fox" },
				GetWords("thequickbrownfox", new[] { "quick", "brown", "the", "fox" }));

			Assert.AreEqual(
				new List<string> { "bed", "bath", "and", "beyond" },
				GetWords("bedbathandbeyond", new[] { "bed", "bath", "bedbath", "and", "beyond" }));
			
			Assert.AreEqual(
				new List<string> { "give", "me", "this", "thing", "please", "give", "it", "to", "me", "now" },
				GetWords("givemethisthingpleasegiveittomenow", new[] { "now", "me", "it", "thing", "please", "this", "give", "to" }));
			
			Assert.AreEqual(
				null,
				GetWords("givemethisthingpleasegiveittomenow", new[] { "now", "me", "it", "thing", "please", "this", "give"}));
		}

		private List<string> GetWords(string input, string[] words)
		{
			var result = new List<string>(words.Length);
			var fittingWords = new HashSet<string>();
			ResetFittingWords(words, fittingWords);

			var symbolNumber = 0;
			foreach (var symbol in input)
			{
				var wordFound = FindWord(symbol, symbolNumber, ref fittingWords, out var resultWord);
				if (wordFound)
				{
					result.Add(resultWord);
					symbolNumber = 0;
					ResetFittingWords(words, fittingWords);
					continue;
				}

				var hasFittingWords = fittingWords.Count > 0;
				if (hasFittingWords)
				{
					symbolNumber++;
					continue;
				}

				return null;
			}

			return result;
		}

		private bool FindWord(char symbol, int symbolNumber, ref HashSet<string> fittingWords, out string resultWord)
		{
			var wrongWords = new List<string>(fittingWords.Count);
			foreach (var word in fittingWords)
			{
				var isSymbolOfWord = word[symbolNumber] == symbol;
				if (!isSymbolOfWord)
				{
					wrongWords.Add(word);
					continue;
				}

				var isLastWordSymbol = symbolNumber == word.Length - 1;
				if (isLastWordSymbol)
				{
					resultWord = word;
					return true;
				}
			}

			foreach (var wrongWord in wrongWords)
			{
				fittingWords.Remove(wrongWord);
			}

			resultWord = string.Empty;
			return false;
		}

		private void ResetFittingWords(string[] words, HashSet<string> buffer)
		{
			foreach (var word in words)
			{
				if (buffer.Contains(word))
				{
					continue;
				}

				buffer.Add(word);
			}
		}
	}
}