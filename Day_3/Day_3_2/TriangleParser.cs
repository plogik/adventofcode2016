using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_2
{
	public class TriangleParser
	{
		private static int[] Take3(int startIndex, int[] haystack)
		{
			var sides = new List<int>();
			for(int i = startIndex; i < haystack.Length && i < (startIndex + 3); i++)
			{
				sides.Add(haystack[i]);
			}
			return sides.ToArray();
		}

		public static List<Triangle> Parse(string line)
		{
			var triangles = new List<Triangle>();
			var strSides = line.Split(new char[] { ' ' },
				StringSplitOptions.RemoveEmptyEntries);
			if (strSides.Length < 3)
				return triangles;
			var sides = new int[strSides.Length];
			// Convert to int array
			for(int i = 0; i < strSides.Length; i++)
			{
				sides[i] = int.Parse(strSides[i]);
			}

			for(int i = 0; i < sides.Length; i += 3)
			{
				var triangle = new Triangle() {
					A = sides[i],
					B = sides[i+1],
					C = sides[i+2]
				};
				if (TriangleValidator.IsValid(triangle))
				{
					triangles.Add(triangle);
				}
			}
			return triangles;
		}

	}
}
