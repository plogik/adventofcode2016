using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_24
{
	public class MazeWalker
	{
		private string[] rows;
		private List<Pair> pairs = new List<Pair>();

		public MazeWalker(string[] rows)
		{
			this.rows = rows;
		}

		public int FindShortestDistance(bool runPart2 = false)
		{
			// Find all numbers in maze
			var locations = new List<Location>();
			for (int rowIdx = 0; rowIdx < rows.Length; rowIdx++)
			{
				var row = rows[rowIdx];
				for (int colIdx = 0; colIdx < row.Length; colIdx++)
				{
					if (char.IsDigit(row[colIdx]))
					{
						locations.Add(new Location() { X = colIdx, Y = rowIdx, Number = row[colIdx] - '0' });
					}
				}
			}

			// Find distance between all numbers in the maze
			foreach (var loc in locations)
			{
				FindPairs(loc, locations.Count - 1);
			}

			// Traverse all possible combinations of numbers in maze to find shortest path
			// around all of them
			return FindShortestPath(runPart2);
		}

		private int FindShortestPath(bool runPart2 = false)
		{
			int minSteps = -1;
			foreach (var p in GetPermutations(Enumerable.Range(1, 7), 7))
			{
				var steps = 0;
				var prevNumber = 0;
				foreach (var pp in p)
				{
					var pair = pairs.Where(n => n.From.Number == prevNumber && n.To.Number == pp).First();
					prevNumber = pair.To.Number;
					steps += pair.To.Distance;
				}
				// Pt 2
				if(runPart2) // And back again
					steps += pairs.Where(n => n.From.Number == prevNumber && n.To.Number == 0).First().To.Distance;

				minSteps = minSteps == -1 ? steps :
					steps < minSteps ? steps : minSteps;
			}
			return minSteps;
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
		private void FindPairs(Location start, int pairsToFind)
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

		// http://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
		static IEnumerable<IEnumerable<T>>
			GetPermutations<T>(IEnumerable<T> list, int length)
		{
			if (length == 1) return list.Select(t => new T[] { t });

			return GetPermutations(list, length - 1)
				.SelectMany(t => list.Where(e => !t.Contains(e)),
					(t1, t2) => t1.Concat(new T[] { t2 }));
		}

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

	}
}
