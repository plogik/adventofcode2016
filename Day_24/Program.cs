using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_24
{
	class Program
	{
		static IEnumerable<IEnumerable<T>>
	GetPermutations<T>(IEnumerable<T> list, int length)
		{
			if (length == 1) return list.Select(t => new T[] { t });

			return GetPermutations(list, length - 1)
				.SelectMany(t => list.Where(e => !t.Contains(e)),
					(t1, t2) => t1.Concat(new T[] { t2 }));
		}

		static void Main(string[] args)
		{
			//var maze = new Maze(File.ReadAllLines("input.txt"));

			// 0, 1, 2, 3

			int i = 0;
			foreach(var p in GetPermutations(Enumerable.Range(1, 7), 7))
			{
				//
				foreach(var pp in p)
				{
					i++;
					Console.Write(pp + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine(i);
			Console.ReadLine();
		}
	}
}
