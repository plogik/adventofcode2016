using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
	public class Maze
	{
		private int seed;

		private class Node
		{
			public int X, Y;
			public int Distance = -1;
			public Node Parent;

			public override bool Equals(object obj)
			{
				return obj is Node &&
					((Node)obj).X == X &&
					((Node)obj).Y == Y;
			}

			public override int GetHashCode()
			{
				int result = 17;
				result = 31 * result + X;
				result = 31 * result + Y;
				return result;
			}

			public override string ToString()
			{
				return string.Format("{{{0},{1}}} Distance:{2}", X, Y, Distance);
			}
		}

		public Maze(int seed)
		{
			this.seed = seed;
		}

		public int FindDistanceTo(int x, int y)
		{
			var result = Find(
				new Node() { X = 1, Y = 1 }, 
				new Node() { X = x, Y = y });
			if (result != null)
			{
				//PrintPath(result);
				return result.Distance;
			}
			return -1; // Not found
		}

		private void PrintPath(Node n)
		{
			do
			{
				Console.WriteLine(n);
			} while ((n = n.Parent) != null);
		}

		// Breadth-First-Search
		private Node Find(Node start, Node needle)
		{
			var q = new Queue<Node>();
			var visited = new List<Node>();
			var maxVisited = 0; // Part 2

			start.Distance = 0;
			q.Enqueue(start);

			while (q.Count != 0)
			{
				var curr = q.Dequeue();

				foreach (var n in AdjacentTo(curr))
				{
					if (visited.Contains(n))
						continue;

					visited.Add(n);
					n.Parent = curr;

					if (n.Distance == -1)
					{
						n.Distance = curr.Distance + 1;
						q.Enqueue(n);

						// Part 2
						if (curr.Distance == 49)
							maxVisited = maxVisited > visited.Count ? maxVisited : visited.Count;

						if (n.Equals(needle))
						{
							// Ok, ugly to print here but it works for this no-frills solution
							Console.WriteLine("Max visited in a distance of 50 is (part 2) " + maxVisited);
							return n; // Found
						}
					}
				}
			}
			return null; // Not found
		}

		private List<Node> AdjacentTo(Node currNode)
		{
			var nodes = new List<Node>();

			for (int offset = -1; offset < 2; offset += 2)
			{
				if (currNode.X + offset >= 0 && IsOpenSpace(currNode.X + offset, currNode.Y))
					nodes.Add(new Node() { X = currNode.X + offset, Y = currNode.Y });
				if (currNode.Y + offset >= 0 && IsOpenSpace(currNode.X, currNode.Y + offset))
					nodes.Add(new Node() { X = currNode.X, Y = currNode.Y + offset });
			}
			return nodes;
		}

		private bool IsOpenSpace(int x, int y)
		{
			int n = x * x + 3 * x + 2 * x * y + y + y * y;
			n += seed;
			// If the number of bits that are 1 is even, it's an open space.
			var ones = 0;
			for(int i = 0; i < 31; i++)
			{
				ones += n >> i & 1;
			}
			return ones % 2 == 0;
		}

	}
}
