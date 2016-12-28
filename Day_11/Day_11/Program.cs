using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using I = Day_11.Node.Item;

namespace Day_11
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new SearchEngine();
			Stopwatch sw = new Stopwatch();
			sw.Start();
			var n = p.Run(new TestWorld());
			sw.Stop();
			Console.WriteLine("Found {0} steps away", n != null ? n.Distance : -1);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			// Unwind and print path
			while (n != null)
			{
				Console.WriteLine(n);
				n = n.Parent;
			}
			Console.ReadLine();
		}
	}
}
