using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_2
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = File.ReadAllText("input.txt");
			var triangles = new List<Triangle>();
			foreach(string line in new ColumnLineReader(input))
			{
				var parsed = TriangleParser.Parse(line);
				foreach(var triangle in parsed)
				{
					if(TriangleValidator.IsValid(triangle))
					{
						triangles.Add(triangle);
					}
				}
			}
			Console.WriteLine("Found {0} valid triangles", triangles.Count);
			Console.ReadLine();
		}
	}
}
