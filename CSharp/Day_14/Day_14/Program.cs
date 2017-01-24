using System;
using System.Diagnostics;

namespace Day_14
{
	class Program
	{
		static void Main(string[] args)
		{
			var day14 = new Day14();
			var sw = new Stopwatch();
			sw.Start();
			var index = day14.GetIndex("abc"); // yjdafjpo
			sw.Stop();
			Console.WriteLine("Index:" + index);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
