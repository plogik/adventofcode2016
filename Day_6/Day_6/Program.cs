using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
	class Program
	{
		static void Main(string[] args)
		{
			var descrambler = new RepeaterDescrambler(File.ReadAllLines("input.txt"));
			//descrambler.DescramblePt1();
			descrambler.DescramblePt2();
			Console.WriteLine(descrambler.Descrambled);
			Console.ReadLine();
		}
	}
}
