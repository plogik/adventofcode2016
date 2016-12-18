using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_9
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllText("input.txt");
			var result = Decompressor.Decompress(input);
			Console.WriteLine(result.Trim());
			Console.WriteLine(result.Trim().Length);
			Console.ReadLine();
		}
	}
}
