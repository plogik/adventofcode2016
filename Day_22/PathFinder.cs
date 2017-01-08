using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
	public class PathFinder
	{
		private List<NodePt2> nodes;

		public PathFinder(List<Node> nodesPt1)
		{
			// Convert to pt2-nodes
			nodes = new List<NodePt2>(nodesPt1.Count);
			foreach(var n in nodesPt1)
			{
				nodes.Add(NodePt2.From(n));
			}

			// Mark "walls", i.e. nodes that are too large to move
			int minSize = nodes.Min(n => n.Size);
			foreach(var n in nodes.Where(n => n.Used > minSize).ToList())
			{
				n.IsLarge = true;
			}

			// Mark node with the data we want to access
			nodes.Find(n => n.Y == 0 && n.X == nodes.Max(n2 => n2.X)).IsGoalNode = true;
		}

		public int Steps;
		public enum Direction { Left, Right, Up, Down };
		public bool MoveEmpty(Direction dir)
		{
			var n1 = nodes.Find(n => n.Used == 0);
			int cols = nodes.Max(n => n.X);
			int rows = nodes.Max(n => n.Y);

			var insideBounds = dir == Direction.Left && n1.X > 0 ||
				dir == Direction.Right && n1.X < cols ||
				dir == Direction.Up && n1.Y > 0 ||
				dir == Direction.Down && n1.Y < rows;

			if(insideBounds)
			{
				var n2X = dir == Direction.Left ? n1.X - 1 :
					dir == Direction.Right ? n1.X + 1 : n1.X;
				var n2Y = dir == Direction.Up ? n1.Y - 1 :
					dir == Direction.Down ? n1.Y + 1 : n1.Y;

				var n2 = nodes.Find(n => n.X == n2X && n.Y == n2Y);
				if(!n2.IsLarge)
				{
					n1.Used = n2.Used;
					n1.IsGoalNode = n2.IsGoalNode;
					n2.Used = 0;
					n2.IsGoalNode = false;
					Steps++;
					return true;
				}
			}
			return false;
		}

		// This does what i did manually in interactive mode. Only works for
		// grid where wall is above, hole is to the far left, there is no wall
		// in the top two rows
		public void RunOptimized()
		{
			while (MoveEmpty(Direction.Up)) // Up to wall
				;
			while (MoveEmpty(Direction.Left)) // Left to get through hole
				;
			while (MoveEmpty(Direction.Up)) // To top of grid
				;
			while (MoveEmpty(Direction.Right)) // To top right, moving the goal data one step to the left
				;

			// From here on, moving the goal one step to the left takes 5 steps
			var goalNode = nodes.First(n => n.IsGoalNode);
			Steps += goalNode.X * 5;
		}


		public override string ToString()
		{
			int cols = nodes.Max(n => n.X);
			int rows = nodes.Max(n => n.Y);

			var buf = new StringBuilder();
			buf.Append("Grid:").Append(cols).Append('X').Append(rows).Append(Environment.NewLine);

			for (int row = 0; row <= rows; row++)
			{
				foreach(var n in nodes.Where(n => n.Y == row))
				{
					buf.Append(n.IsLarge ? '#' : 
						n.Used == 0 ? '_' : 
						n.IsGoalNode ? 'G' : '.');
				}
				buf.Append(row);
				buf.Append(Environment.NewLine);
			}
			return buf.ToString();
		}
	}
}
