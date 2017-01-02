using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20
{
	class RangeRepos
	{
		private List<Range> ranges = new List<Range>();

		public List<Range> Ranges
		{
			get
			{
				return ranges;
			}
		}

		public void Add(Range range)
		{
			ranges.Add(range);
		}

		public void Compact()
		{
			bool removed = false;
			do
			{
				removed = false;
				for (int i = 0; i < ranges.Count - 1; i++)
				{
					for (int n = i + 1; n < ranges.Count; n++)
					{
						if (ranges[n].Overlaps(ranges[i]) || ranges[i].Overlaps(ranges[n]) ||
							ranges[n].Adjacent(ranges[i]) || ranges[i].Adjacent(ranges[n])) 
						{
							ranges[i].Merge(ranges[n]);
							ranges.RemoveAt(n);
							removed = true;
						}
					}
				}
			} while (removed);
		}

		public void Sort()
		{
			ranges.Sort();
		}

		// Make sure to call Sort and Compact before this
		public long FirstFreeNo()
		{
			long lastHighest = 0;
			foreach(var r in ranges)
			{
				if (r.Lower > (lastHighest + 1))
					return lastHighest + 1;
				lastHighest = r.Upper;
			}
			return -1; // Not found
		}

		// Make sure to call Sort and Compact before this
		public int FreeIps()
		{
			var freeIps = 0L;
			for (int i = 0; i < Ranges.Count - 1; i++)
			{
				freeIps += (Ranges[i + 1].Lower - Ranges[i].Upper) - 1;
			}
			return (int)freeIps;
		}
	}
}
