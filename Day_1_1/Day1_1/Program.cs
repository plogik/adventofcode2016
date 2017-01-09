using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_1
{
    class Program
    {
		static void Main(string[] args)
        {
			string input = File.ReadAllText("input.txt");
			var steps = StepsParser.Parse(input);
			Navigator navigator = new Navigator();
			foreach (var step in steps)
			{
				navigator.Move(step.Direction, step.Steps);
			}
			Console.WriteLine("# steps away:{0}", navigator.CurrentPosition.DistanceFromOrigo());
			Console.ReadLine();
		}
	}
}
