using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given a 2D matrix of characters and a target word
	/// write a function that returns whether the word can be found in the matrix by going left-to-right, or up-to-down.
	/// For example, given the following matrix:
	/// [['F', 'A', 'C', 'I'],
	/// ['O', 'B', 'Q', 'P'],
	/// ['A', 'N', 'O', 'B'],
	/// ['M', 'A', 'S', 'S']]
	/// and the target word 'FOAM', you should return true, since it's the leftmost column.
	/// Similarly, given the target word 'MASS', you should return true, since it's the last row.
	/// </summary>
	[TestFixture]
	public class WordMatrix
	{
		[Test]
		public void Test()
		{
			var matrix = new[,]
			{
				{'F', 'A', 'C', 'I'},
				{'O', 'B', 'Q', 'P'},
				{'A', 'N', 'O', 'B'},
				{'M', 'A', 'S', 'S'}
			};

			Assert.IsTrue(HasWord(matrix, "FOAM"));
			Assert.IsTrue(HasWord(matrix, "MASS"));
			Assert.IsFalse(HasWord(matrix, "BACQ"));
			Assert.IsTrue(HasWord(matrix, "FABNOS"));
		}

		private bool HasWord(char[,] matrix, string word)
		{
			var wordArray = word.ToCharArray();
			var matrixLength = matrix.GetLength(0);
			for (var i = 0; i < matrixLength; i++)
			{
				for (var j = 0; j < matrixLength; j++)
				{
					var gotFirstLetter = matrix[i, j] == wordArray[0];
					if (gotFirstLetter && CheckWordFromFirstLetter(matrix, wordArray, i, j, matrixLength))
					{
						return true;
					}
				}
			}

			return false;
		}

		private bool CheckWordFromFirstLetter(char[,] matrix, char[] word, int i, int j, int matrixLength)
		{
			var letterIndex = 1;
			var wordLength = word.Length;
			while (letterIndex < wordLength)
			{
				var isRightLetterFromWord = i + 1 < matrixLength && matrix[i + 1, j] == word[letterIndex];
				if (isRightLetterFromWord)
				{
					i += 1;
					letterIndex++;
					continue;
				}

				var isLeftLetterFromWord = j + 1 < matrixLength && matrix[i, j + 1] == word[letterIndex];
				if (isLeftLetterFromWord)
				{
					j += 1;
					letterIndex++;
					continue;
				}

				return false;
			}

			return true;
		}
	}
}