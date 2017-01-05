using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
	// Pardon the ugliness, this whole solution is a mess. I cut some corners getting to pt 2
	class Program
	{
		static void Pt1()
		{
			var input = "abcdefgh";

			var s = new Scrambler(input);
			s.Scramble(File.ReadAllLines("input.txt"));
			var result = s.Password;

			// bdfhgeca
			Console.WriteLine(result);
		}

		static void Pt2()
		{
			var input = "fbgdceah";
			var allLines = File.ReadAllLines("input.txt");
			for(int i = allLines.Length - 1; i >= 0; i--)
			{
				Console.WriteLine("#" + i + ":" + allLines[i]);
				input = OperationParser.Parse(allLines[i], true).Execute(input);
			}
			Console.WriteLine(input);
		}

		static void Main(string[] args)
		{
			//Pt1();

			Pt2();
			Console.ReadLine();
		}
	}
}
