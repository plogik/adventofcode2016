using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
	class Program
	{
		static void Part1()
		{
			Console.WriteLine(PasswordDecryptEngine.GetPwd("wtnhxymk"));
		}

		static void Part2()
		{
			Console.WriteLine(PasswordDecryptEngine.GetPt2Pwd("wtnhxymk"));
		}

		static void Main(string[] args)
		{
			var stopwatch = Stopwatch.StartNew();

			//Part1();
			Part2();

			stopwatch.Stop();
			Console.WriteLine("Ms:" + stopwatch.ElapsedMilliseconds);
			Console.ReadLine();
		}
	}
}
