using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20
{
	class Program
	{
		static RangeRepos PrepareRepo()
		{
			var repo = new RangeRepos();
			foreach (var line in File.ReadLines("input.txt"))
			{
				var parts = line.Split('-');
				repo.Add(new Range(long.Parse(parts[0]), long.Parse(parts[1])));
			}
			repo.Sort();
			repo.Compact();
			return repo;
		}

		static void Main(string[] args)
		{
			var repo = PrepareRepo();

			// Part 1
			Console.WriteLine("First free no:" + repo.FirstFreeNo());

			// Part 2
			Console.WriteLine("# free ips:" + repo.FreeIps());

			Console.ReadLine();
		}
	}
}
