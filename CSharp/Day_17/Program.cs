using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
	class Program
	{
		static void Main(string[] args)
		{
			var finder = new PathFinder("pgflpeqp");
			var sw = new Stopwatch();
			sw.Start();
			var result = finder.Find();
			sw.Stop();
			Console.WriteLine(result.Pt1Result);
			Console.WriteLine("Longest route distance:" + result.Pt2Result);
			Console.WriteLine("Elapsed: " + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
