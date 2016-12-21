using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12
{
	class Program
	{
		static void Main(string[] args)
		{
			var computer = new Computer(File.ReadAllLines("input.txt"));
			computer.Run();
			Console.WriteLine("Value of reg a: " + computer["a"]);
			Console.ReadLine();
		}
	}
}
