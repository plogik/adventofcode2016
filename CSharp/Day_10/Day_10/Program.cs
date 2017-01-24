using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
	class Program
	{
		static void Pt1(List<Command> cmds)
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();
			var found = false;
			for (int i = 1; !found; i++)
			{
				Console.WriteLine("Pass #" + i);
				foreach (var cmd in cmds)
				{
					CommandProcessor.Execute(botRepos, outputRepos, cmd);
					foreach (var bot in botRepos)
					{
						if (bot.ValueCount == 2 &&
							bot.LowValue == 17 &&
							bot.HighValue == 61)
						{
							Console.WriteLine("The bot responsible for comparing 17 and 61 has id:" + bot.Id);
							found = true;
							break;
						}

					}

					if (found)
						break;
				}
			}
		}

		static void Pt2(List<Command> cmds)
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();
			var filled = false;
			for (int i = 1; !filled; i++)
			{
				Console.WriteLine("Pass #" + i);
				foreach (var cmd in cmds)
				{
					CommandProcessor.Execute(botRepos, outputRepos, cmd);
					if(outputRepos[0].Count > 0 &&
						outputRepos[0].Peek() != -1 &&
						outputRepos[1].Count > 0 &&
						outputRepos[1].Peek() != -1 &&
						outputRepos[2].Count > 0 &&
						outputRepos[2].Peek() != -1)
					{
						filled = true;
					}

					if (filled)
						break;
				}
			}
			var binIds = new int[] { 0, 1, 2 };
			var binValues = new int[3];
			foreach (var id in binIds)
			{
				var bin = outputRepos[id];
				Console.WriteLine("Bin #" + id + " has value " + bin.Peek());
				binValues[id] = bin.Peek();
			}
			Console.WriteLine("Product is:" + binValues[0] * binValues[1] * binValues[2]);
		}

		static void Main()
		{

			var cmds = new List<Command>();
			foreach(var line in File.ReadLines("input.txt"))
			{
				cmds.Add(CommandParser.Parse(line));
			}
			Pt1(cmds);
			Pt2(cmds);

			Console.ReadLine();
		}
	}
}
