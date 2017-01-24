using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_2
{
	public class TriangleValidator
	{
		public static bool IsValid(Triangle triangle)
		{
			return
				triangle.A + triangle.B > triangle.C &&
				triangle.A + triangle.C > triangle.B &&
				triangle.B + triangle.C > triangle.A;
		}
	}
}
