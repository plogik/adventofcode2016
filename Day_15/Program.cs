using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
	class Program
	{

		static void Main(string[] args)
		{
			var discs = new Disc[]
			{
				new Disc() { posCount = 5, currPos = 2 },
				new Disc() { posCount = 13, currPos = 7 },
				new Disc() { posCount = 17, currPos = 10 },
				new Disc() { posCount = 3, currPos = 2 },
				new Disc() { posCount = 19, currPos = 9 },
				new Disc() { posCount = 7, currPos = 0 },
				new Disc() { posCount = 11, currPos = 0 } // Comment this out for part 1
			};

			var sw = new Stopwatch();
			sw.Start();
			int secs = new DiscMachine().GetSecondToDrop(discs);
			sw.Stop();
			Console.WriteLine("Drop at second:" + (secs - 2));
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
