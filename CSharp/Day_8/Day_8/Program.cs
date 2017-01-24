using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
	class Program
	{


		static void Main(string[] args)
		{
			var display = new Display(6, 50);

			foreach(var line in File.ReadLines("input.txt"))
			{
				CommandParser.PerformOp(display, line);
			}
			Console.WriteLine("# pixels on:" + display.PixelOnCount);
			Console.WriteLine(display);
			Console.ReadLine();
		}
	}
}
