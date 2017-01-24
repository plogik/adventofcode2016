using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_3_1
{
	class Program
	{
		private static int[] LineToSides(string triangle)
		{
			var strSides = triangle.Split(new char[] { ' ' }, 
				StringSplitOptions.RemoveEmptyEntries);
			var sides = new int[3];
			sides[0] = int.Parse(strSides[0]);
			sides[1] = int.Parse(strSides[1]);
			sides[2] = int.Parse(strSides[2]);
			return sides;
		}

		static void Main(string[] args)
		{
			int validCount = 0;
			foreach(string triangle in File.ReadAllLines("input.txt"))
			{
				var sides = LineToSides(triangle);
				if(TriangleValidator.IsValid(sides[0], sides[1], sides[2]))
				{
					validCount++;
				}
			}
			Console.WriteLine("Valid count:{0}", validCount);
			Console.ReadLine();
		}
	}
}
