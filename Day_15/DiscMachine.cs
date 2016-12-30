using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
	public struct Disc
	{
		public int posCount;
		public int currPos;

		public override string ToString()
		{
			return
				String.Format(
					"# positions: {0}, current: {1}",
						posCount, currPos);
		}
	}

	public class DiscMachine
	{
		public int GetSecondToDrop(Disc[] discs)
		{
			int secs = 0;
			for (bool found = false; !found; secs++)
			{
				found = true;
				for (int i = 0; i < discs.Length; i++)
				{
					if ((discs[i].currPos + i) % discs[i].posCount != 0)
					{
						found = false;
						break;
					}
				}
				if (!found)
				{
					for (int i = 0; i < discs.Length; i++)
					{
						discs[i].currPos = (discs[i].currPos + 1) % discs[i].posCount;
					}
				}
			}
			return secs - 2;
		}
	}
}
