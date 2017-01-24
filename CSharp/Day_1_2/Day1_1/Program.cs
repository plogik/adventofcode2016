using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_2
{
    class Program
    {
		static void Main(string[] args)
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
			Console.WriteLine("First crossing num steps away:{0}", navigator.DistanceToFirstCrossing());
			Console.ReadLine();
		}
	}
}
