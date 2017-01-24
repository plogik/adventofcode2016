using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_18
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw = new Stopwatch();
			sw.Start();

			var map = MapMaker.MakeMap(
				"^..^^.^^^..^^.^...^^^^^....^.^..^^^.^.^.^^...^.^.^.^.^^.....^.^^.^.^.^.^.^.^^..^^^^^...^.....^....^."
				.ToCharArray(), 400000); // Use 40 for part 1
			var safeTileCount = 0;
			foreach(var row in map)
			{
				// Maybe not the most efficient way to count chars. Good enough though
				var strRow = new string(row);
				safeTileCount +=  strRow.Count(x => x == '.');
				//Console.WriteLine(strRow);
			}

			sw.Stop();

			Console.WriteLine("# safe tiles:" + safeTileCount);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
