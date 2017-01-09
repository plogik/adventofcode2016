using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
	public class PathFinder
	{
		private string seed;

		public struct SearchResults
		{
			public string Pt1Result;
			public int Pt2Result;
		}

		private class Node
		{
			public int X, Y;
			public int Distance = -1;
			public string Path = "";

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
		public PathFinder(string seed)
		{
			this.seed = seed;
		}

		public SearchResults Find()
		{
			using (MD5 md5 = MD5.Create())
			{
				var result = Find(
					new Node() { X = 0, Y = 0 },
					new Node() { X = 3, Y = 3 },
					md5);
				return new SearchResults()
				{
					Pt1Result = result.OrderBy(n => n.Distance).First().Path,
					Pt2Result = result.OrderByDescending(n => n.Distance).First().Distance
				};
			}
		}

		// Breadth-First-Search
		private List<Node> Find(Node start, Node needle, MD5 md5)
		{
			var q = new Queue<Node>();
			var found = new List<Node>();

			start.Distance = 0;
			q.Enqueue(start);

			while (q.Count != 0)
			{
				var curr = q.Dequeue();

				foreach (var n in AdjacentTo(curr, md5))
				{
					if (n.Distance == -1)
					{
						n.Distance = curr.Distance + 1;

						if (n.Equals(needle))
						{
							found.Add(n);
						}
						else
							q.Enqueue(n);
					}
				}
			}
			return found;
		}

		private List<Node> AdjacentTo(Node currNode, MD5 md5)
		{
			var nodes = new List<Node>();

			var hash = GetHash(md5, seed + currNode.Path);

			// Up
			if (hash[0] >= 'b' && hash[0] <= 'f' && currNode.Y > 0)
				nodes.Add(new Node() { X = currNode.X, Y = currNode.Y - 1, Path = currNode.Path + "U" });
			// Down
			if (hash[1] >= 'b' && hash[1] <= 'f' && currNode.Y < 3)
				nodes.Add(new Node() { X = currNode.X, Y = currNode.Y + 1, Path = currNode.Path + "D" });
			// Left
			if (hash[2] >= 'b' && hash[2] <= 'f' && currNode.X > 0)
				nodes.Add(new Node() { X = currNode.X - 1, Y = currNode.Y, Path = currNode.Path + "L" });
			// Right
			if (hash[3] >= 'b' && hash[3] <= 'f' && currNode.X < 3)
				nodes.Add(new Node() { X = currNode.X + 1, Y = currNode.Y, Path = currNode.Path + "R" });

			return nodes;
		}

		static string GetHash(MD5 md5, string input)
		{
			byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			return sBuilder.ToString().Substring(0, 4);
		}
	}
}
