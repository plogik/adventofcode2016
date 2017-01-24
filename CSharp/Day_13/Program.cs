using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
	class Program
	{
		static void Main(string[] args)
		{
			var m = new Maze(1362);
			var sw = new Stopwatch();
			sw.Start();
			var distance = m.FindDistanceTo(31, 39);
			sw.Stop();
			Console.WriteLine("Distance:" + distance);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
