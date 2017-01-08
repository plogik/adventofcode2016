using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
	public class NodePt2 : Node, ICloneable
	{
		public int X, Y;
		public bool IsLarge;
		public bool IsGoalNode;

		public static NodePt2 From(Node n)
		{
			var n2 = new NodePt2()
			{
				Filesystem = n.Filesystem,
				Size = n.Size,
				Used = n.Used,
				Avail = n.Avail,
				UsedPercent = n.UsedPercent
			};

			// Parse grid position (x/y)
			var xStart = n.Filesystem.IndexOf("-x") + 2;
			var lastDash = n.Filesystem.LastIndexOf('-');
			n2.X = int.Parse(n.Filesystem.Substring(xStart, lastDash - xStart));
			n2.Y = int.Parse(n.Filesystem.Substring(lastDash + 2));

			return n2;
		}

		public override bool Equals(object obj)
		{
			return obj is NodePt2 &&
				((NodePt2)obj).X == X &&
				((NodePt2)obj).Y == Y;
		}

		public override int GetHashCode()
		{
			int result = 17;
			result = 31 * result + X;
			result = 31 * result + Y;
			return result;
		}

		public object Clone()
		{
			return new NodePt2()
			{
				Filesystem = string.Copy(Filesystem),
				Size = Size,
				Used = Used,
				Avail = Avail,
				UsedPercent = UsedPercent,
				X = X,
				Y = Y,
				IsLarge = IsLarge,
				IsGoalNode = IsGoalNode
			};
		}
	}
}
