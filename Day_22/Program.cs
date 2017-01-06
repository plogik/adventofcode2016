using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
	class Program
	{
		static int NumPairs(List<Node> nodes)
		{
			var numPairs = 0;
			for(int a = 0; a < nodes.Count - 1; a++)
			{
				for(int b = a + 1; b < nodes.Count; b++)
				{
					if (nodes[a].Used > 0 && nodes[a].Used <= nodes[b].Avail)
						numPairs++;
					if (nodes[b].Used > 0 && nodes[b].Used <= nodes[a].Avail)
						numPairs++;

				}
			}
			return numPairs;
		}

		static void Main(string[] args)
		{
			var nodes = new List<Node>();
			foreach(var line in File.ReadLines("input.txt"))
			{
				nodes.Add(Node.From(line));
			}
			Console.WriteLine("# pairs:" + NumPairs(nodes));
			Console.ReadLine();
		}
	}
}
