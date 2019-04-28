using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Practice
{
	/// <summary>
	/// Given the root to a binary tree
	/// implement serialize(root), which serializes the tree into a string,
	/// and deserialize(s), which deserializes the string back into the tree
	/// </summary>
	[TestFixture]
	public class TreeSerializer
	{
		//todo : add some escape symbol
		private const char OpenBracketSymbol = '(';
		private const char CloseBracketSymbol = ')';
		private const char NextElementSymbol = ',';

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

		[Test]
		public void DeserializeTest()
		{
			TestDeserializeTree(CreateTree());

			TestDeserializeTree(
				new Node
				(
					"root",
					new Node("left")
				));

			TestDeserializeTree(
				new Node
				(
					"root",
					new Node("left"),
					new Node("right")
				));
		}

		private void TestDeserializeTree(Node tree)
		{
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
		/// Recursion hack
		/// </summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		private string SerializeTree(Node tree)
		{
			var sb = new StringBuilder();

			SerializeRecursive(tree, sb);

			return sb.ToString();
		}

		private void SerializeRecursive(Node tree, StringBuilder sb)
		{
			sb.Append(tree.Value);

			if (tree.Left != null)
			{
				sb.Append(OpenBracketSymbol);

				SerializeRecursive(tree.Left, sb);

				if (tree.Right == null)
				{
					sb.Append(CloseBracketSymbol);
				}
			}

			if (tree.Right != null)
			{
				sb.Append(tree.Left == null ? OpenBracketSymbol : NextElementSymbol);

				SerializeRecursive(tree.Right, sb);

				sb.Append(CloseBracketSymbol);
			}
		}

		/// <summary>
		/// Store node parents to dictionary
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private Node DeserializeTree(string data)
		{
			var sb = new StringBuilder();

			var result = new Node();

			var currentNode = result;

			var parents = new Dictionary<Node, Node>();

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

				WriteNodeValue(currentNode, sb);

				if (isOpen)
				{
					currentNode.Left = new Node();
					parents[currentNode.Left] = currentNode;
					currentNode = currentNode.Left;
					Console.WriteLine(SerializeTree(result));
					continue;
				}

				if (isNext)
				{
					currentNode = parents[currentNode];
					currentNode.Right = new Node();
					parents[currentNode.Right] = currentNode;
					currentNode = currentNode.Right;
					Console.WriteLine(SerializeTree(result));
					continue;
				}

				if (isClose)
				{
					currentNode = parents[currentNode];
					Console.WriteLine(SerializeTree(result));
					continue;
				}
			}

			return result;
		}

		private static void WriteNodeValue(Node currentNode, StringBuilder sb)
		{
			if (sb.Length == 0)
			{
				return;
			}

			currentNode.Value = sb.ToString();
			sb.Length = 0;
		}
	}
}