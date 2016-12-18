using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9_Pt_2
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllText("input.txt");
			var result = Decompressor.Expand(input.Trim());
			Console.WriteLine(result);

			Console.ReadLine();
		}
	}
}
