using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_24
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw = new Stopwatch();
			var maze = new MazeWalker(File.ReadAllLines("input.txt"));
			sw.Start();
			var distance = maze.FindShortestDistance(); // Pass in true for part 2
			sw.Stop();
			Console.WriteLine("Shortest path:" + distance);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
