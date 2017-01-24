using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw = new Stopwatch();
			var computer = new Computer(File.ReadAllLines("input.txt"));
			sw.Start();
			computer.Run();
			sw.Stop();
			Console.WriteLine("Value of reg a: " + computer["a"]);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
