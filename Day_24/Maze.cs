using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_24
{
	public class Maze
	{
		private string[] rows;
		private List<Pair> pairs = new List<Pair>();

		private class Location
		{
			public int X, Y;
			public int Number;
			public int Distance = -1;
			public Location Parent;

			public override string ToString()
			{
				return String.Format("{0} at {{{1},{2}}}", Number, X, Y);
			}

			public override bool Equals(object obj)
			{
				return obj is Location &&
					((Location)obj).X == X &&
					((Location)obj).Y == Y;
			}

			public override int GetHashCode()
			{
				int result = 17;
				result = 31 * result + X;
				result = 31 * result + Y;
				return result;
			}
		}

		private class Pair
		{
			public Location From;
			public Location To;

			public Pair(Location from, Location to)
			{
				From = from;
				To = to;
			}

			public override string ToString()
			{
				return string.Format("From {0} to {1}: {2} steps", From, To, To.Distance);
			}
		}

		public Maze(string[] rows)
		{
			this.rows = rows;

			// Find all numbers in maze
			var locations = new List<Location>();
			for (int rowIdx = 0; rowIdx < rows.Length; rowIdx++)
			{
				var row = rows[rowIdx];
				for(int colIdx = 0; colIdx < row.Length; colIdx++)
				{
					if(char.IsDigit(row[colIdx]))
					{
						locations.Add(new Location() { X = colIdx, Y = rowIdx, Number = row[colIdx] - '0' });
					}
				}
			}

			foreach(var loc in locations)
			{
				Find(loc, locations.Count - 1);
			}

			Console.WriteLine("Pairs found:" + pairs.Count);
			foreach(var pair in pairs.OrderBy(p => p.From.Number).ThenBy(p => p.To.Number))
			{
				Console.WriteLine(pair);
			}
		}

		// returns number if location points to one, otherwise -1
		private int GetNumberAt(Location loc)
		{
			if (char.IsDigit(rows[loc.Y][loc.X]))
				return rows[loc.Y][loc.X] - '0';

			return -1;
		}

		// Breadth-First-Search
		// Looks for numbers not equal to start
		private void Find(Location start, int pairsToFind)
		{
			var pairsFound = 0;
			var visited = new List<Location>();
			var q = new Queue<Location>();

			start.Distance = 0;
			q.Enqueue(start);

			while (q.Count != 0)
			{
				var curr = q.Dequeue();
				foreach (var n in AdjacentTo(curr))
				{
					if(visited.Contains(n))
						continue;

					visited.Add(n);
					n.Parent = curr;

					if (n.Distance == -1)
					{
						n.Distance = curr.Distance + 1;
						q.Enqueue(n);

						int num = GetNumberAt(n);
						if (num != -1 && num != start.Number)
						{
							n.Number = num;
							pairs.Add(new Pair(start, n));
							pairsFound++;
							if (pairsFound == pairsToFind)
								return;
						}
					}
				}
			}
		}

		private List<Location> AdjacentTo(Location curr)
		{
			var locations = new List<Location>();

			for(int offset = -1; offset < 2; offset += 2)
			{
				if (rows[curr.Y][curr.X + offset] != '#')
					locations.Add(new Location() { X = curr.X + offset, Y = curr.Y });
				if (rows[curr.Y + offset][curr.X] != '#')
					locations.Add(new Location() { X = curr.X, Y = curr.Y + offset });
			}
			return locations;
		}

		//public 
	}
}
