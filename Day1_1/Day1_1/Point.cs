using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_1
{
	public struct Point : IEquatable<Point>
	{
		public int X; public int Y;

		public bool Equals(Point other)
		{
			return other.X == X && other.Y == Y;
		}
		public override bool Equals(object obj)
		{
			bool result = (obj is Point) && Equals((Point)obj);
			return result;
		}
		public override int GetHashCode()
		{
			return X + Y;
		}
		public override string ToString()
		{
			return String.Format("Point {{{0}, {1}}}", X, Y);
		}

		public int DistanceFromOrigo()
		{
			return Math.Abs(X) + Math.Abs(Y);
		}
	}
}
