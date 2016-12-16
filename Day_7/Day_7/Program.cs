using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_7
{
	class Program
	{
		static void Main(string[] args)
		{
			int validCount = 0;
			foreach(var line in File.ReadAllLines("input.txt"))
			{
				if(new TLSParser(line).IsValidTLS())
				{
					validCount++;
				}
			}
			Console.WriteLine("Valid count:" + validCount);
			
			/*var d7 = new Day7();
			d7.Solve();*/

			Console.ReadLine();
			
		}
	}
}
