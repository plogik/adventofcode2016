using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_1
{
	public class TriangleValidator
	{
		public static bool IsValid(int a, int b, int c)
		{
			return
				a + b > c &&
				a + c > b &&
				b + c > a;
		}
	}
}
