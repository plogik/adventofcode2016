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

		static void Pt1(List<Node> nodes)
		{
			Console.WriteLine("# pairs:" + NumPairs(nodes));
		}

		static void DoInteractive(PathFinder finder)
		{
			while(true)
			{
				Console.Clear();
				Console.Write(finder);
				Console.Write("Steps:" + finder.Steps);
				var key = Console.ReadKey().Key;
				finder.MoveEmpty(key == ConsoleKey.UpArrow ? PathFinder.Direction.Up :
					key == ConsoleKey.DownArrow ? PathFinder.Direction.Down :
					key == ConsoleKey.LeftArrow ? PathFinder.Direction.Left :
					PathFinder.Direction.Right);
			}
		}

		static void DoOptimized(PathFinder finder)
		{
			finder.RunOptimized();
			Console.Write("Steps:" + finder.Steps);
		}

		static void Pt2(List<Node> nodes)
		{
			var finder = new PathFinder(nodes);

			Console.Write("1 - Interactive, 2 - Optimized, 3 - BFS, 4 - A* [1,2,3,4]? ");
			switch (int.Parse(Console.ReadLine()))
			{
				case 1:
					DoInteractive(finder);
					break;
				case 2:
					DoOptimized(finder);
					break;
				/*case 3:
					break;
				case 4:
					break;*/
				default:
					throw new NotImplementedException();
			}

			//Console.WriteLine(finder);
		}

		static void Main(string[] args)
		{
			var nodes = new List<Node>();
			foreach (var line in File.ReadLines("input.txt"))
			{
				nodes.Add(Node.From(line));
			}

			Console.Write("Pt 1 or 2 [1,2]? ");
			switch(int.Parse(Console.ReadLine()))
			{
				case 1:
					Pt1(nodes);
					break;
				case 2:
					Pt2(nodes);
					break;
			}

			Console.ReadLine();
		}
	}
}
