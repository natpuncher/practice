using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given the root to a binary tree
	/// implement serialize(root), which serializes the tree into a string,
	/// and deserialize(s), which deserializes the string back into the tree
	/// recursion banned
	/// </summary>
	[TestFixture]
	public class TreeSerializer
	{
		public const char Escape = '\\';
		public const char OpenBracketSymbol = '(';
		public const char CloseBracketSymbol = ')';
		public const char NextElementSymbol = ',';

		public class Node
		{
			public string Value;
			public Node Left;
			public Node Right;

			public Node(string value = "", Node left = null, Node right = null)
			{
				Value = value;
				Left = left;
				Right = right;
			}
		}

		[Test]
		public void SerializeTest()
		{
			Assert.AreEqual("root(left)",
				SerializeTree(
					new Node
					(
						"root",
						new Node("left")
					)));

			Assert.AreEqual("root(left,right)",
				SerializeTree(
					new Node
					(
						"root",
						new Node("left"),
						new Node("right")
					)));

			Assert.AreEqual("a(b(d(f),e),c(j))", SerializeTree(CreateTree()));
		}

//		[Test]
		public void DeserializeTest()
		{
			var tree = CreateTree();
			var data = SerializeTree(tree);

			var newTree = DeserializeTree(data);

			Assert.AreEqual(data, SerializeTree(newTree));
		}

		/// <summary>
		/// a(b(d(f),e),c(j))
		/// </summary>
		/// <returns></returns>
		private Node CreateTree()
		{
			return new Node
			(
				"a",
				new Node
				(
					"b",
					new Node("d", new Node("f")),
					new Node("e")
				),
				new Node("c", new Node("j"))
			);
		}

		/// <summary>
		/// Traverse tree depth first
		/// </summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		private string SerializeTree(Node tree)
		{
			var sb = new StringBuilder();

			var level = 0;
			var unprocessedChildCount = new int[100];
			var stack = new Stack<Node>();
			stack.Push(tree);
			while (stack.Count > 0)
			{
				var node = stack.Pop();

				sb.Append(node.Value);

				if (node.Right != null)
				{
					unprocessedChildCount[level]++;
					stack.Push(node.Right);
				}

				if (node.Left != null)
				{
					unprocessedChildCount[level]++;
					stack.Push(node.Left);
				}

				var hasChildren = node.Right != null || node.Left != null;
				if (hasChildren)
				{
					sb.Append(OpenBracketSymbol);
					level++;
					continue;
				}

				unprocessedChildCount[level - 1]--;

				do
				{
					var isLastChildOnTheLevel = unprocessedChildCount[level - 1] == 0;
					if (isLastChildOnTheLevel)
					{
						level--;
						sb.Append(CloseBracketSymbol);
					}
					else
					{
						sb.Append(NextElementSymbol);
					}
				} while (level >= 1 && unprocessedChildCount[level - 1] == 0);
			}

			return sb.ToString();
		}

		private Node DeserializeTree(string data)
		{
			var sb = new StringBuilder();

			var result = new Node();

			var currentNode = result;

			var length = data.Length;
			for (var i = 0; i < length; i++)
			{
				var symbol = data[i];

				var isNext = symbol == NextElementSymbol;
				var isOpen = symbol == OpenBracketSymbol;
				var isClose = symbol == CloseBracketSymbol;

				var isDataSymbol = !isNext && !isOpen && !isClose;

				if (isDataSymbol)
				{
					sb.Append(symbol);
					continue;
				}

				currentNode.Value = sb.ToString();
				sb.Length = 0;

				if (isOpen)
				{
					currentNode.Left = new Node();
					currentNode = currentNode.Left;
					continue;
				}

				if (isNext)
				{
					currentNode.Right = new Node();
					currentNode = currentNode.Right;
					continue;
				}

				if (isClose)
				{
				}
			}

			return result;
		}
	}
}