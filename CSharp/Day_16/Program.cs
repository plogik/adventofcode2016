using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_16
{
	class Program
	{
		static void Main(string[] args)
		{

			var sw = new Stopwatch();
			sw.Start();

			var c = new Calculator(new byte[] { 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 });
			c.GenerateData(35651584); // Use 272 for part 1
			var checksum = c.CalculateChecksum();

			sw.Stop();

			Console.Write("Checksum:");
			foreach (var b in checksum)
				Console.Write(b);
			Console.WriteLine();
			Console.WriteLine("Length:" + checksum.Length);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
