using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_19
{
	class Program
	{
		static int FindLuckyElfPt1(int elfCount)
		{
			var elves = new int[elfCount];

			// Give each elf a present
			for (int i = 0; i < elves.Length; i++)
				elves[i] = 1;

			for (int i = 0; true;)
			{
				while (elves[i] == 0)
					i = (i + 1) % elves.Length;

				int thisElf = i;
				do
				{
					i = (i + 1) % elves.Length;
				} while (elves[i] == 0);
				if (thisElf == i)
				{
					return i + 1;
				}
				else
				{
					elves[thisElf] += elves[i];
					elves[i] = 0;
				}
			}
		}

		static int _FindLuckyElfPt2(int elfCount)
		{
			var elves = new List<int>(elfCount);

			for (int i = 0; i < elfCount; i++)
				elves.Add(i);

			for(int i = 0; elves.Count > 1; i = (i + 1) % elves.Count)
			{
				int half = elves.Count / 2;
				elves.RemoveAt((i + half) % elves.Count);
			}
			return elves[0];
		}


		/*
			Elf #1410967
			Elapsed:16:27:36.2790683

			That's the right answer!
		 */
		static int FindLuckyElfPt2(int elfCount)
		{
			var elves = new int[elfCount];

			// Give each elf a present
			for (int i = 0; i < elves.Length; i++)
				elves[i] = 1;

			for (int i = 0, elvesLeft = elfCount; true; elvesLeft--, i++)
			{
				while (elves[i] == 0)
					i = (i + 1) % elves.Length;

				if (elvesLeft == 1)
					return (i + 1);

				var halfWayAway = elvesLeft / 2;
				var giverElf = i;
				while(halfWayAway > 0)
				{
					giverElf = (giverElf + 1) % elves.Length;
					if (elves[giverElf] > 0)
						halfWayAway--;
				}
				elves[giverElf] = 0;
				Console.WriteLine(elvesLeft);
			}
		}


		static void Main(string[] args)
		{
			var sw = new Stopwatch();
			sw.Start();
			//var luckyElf = FindLuckyElfPt1(3005290);
			var luckyElf = FindLuckyElfPt2(3005290);
			sw.Stop();
			Console.WriteLine("Elf #" + luckyElf);
			Console.WriteLine("Elapsed:" + sw.Elapsed);
			Console.ReadLine();
		}
	}
}
