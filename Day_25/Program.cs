using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_25
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw = new Stopwatch();
			sw.Start();
			var computer = new Computer(File.ReadAllLines("input.txt"));
			int seed = 0;
			var found = false;
			while(!found)
			{
				seed++;
				computer["a"] = seed;
				computer["b"] = 0;
				computer["c"] = 0;
				computer["d"] = 0;
				var result = computer.Run(80);
				if (IsCorrectSequence(result))
					found = true;
			}
			sw.Stop();
			Console.WriteLine("Correct seed:" + seed);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}

		static bool IsCorrectSequence(int[] input)
		{
			int prev = 1;
			foreach(var i in input)
			{
				if (i == prev)
					return false;
				prev = i;
			}
			return true;
		}
	}
}
