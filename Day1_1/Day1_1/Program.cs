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
		static void Part1()
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

		static void Part2()
		{
			string input = File.ReadAllText("input.txt");
			var steps = StepsParser.Parse(input);
			Navigator navigator = new Navigator();
			var history = new List<Point>() { navigator.CurrentPosition };
			foreach (var step in steps)
			{
				navigator.Move(step.Direction, step.Steps);
				if (history.Contains(navigator.CurrentPosition))
					break;
				history.Add(navigator.CurrentPosition);
			}
			Console.WriteLine("# steps away:{0}", navigator.CurrentPosition.DistanceFromOrigo());
			Console.ReadLine();
		}
		static void Main(string[] args)
        {
			//Part1();
			Part2();
		}
	}
}
