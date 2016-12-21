using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_12
{
	public class Computer
	{
		private Dictionary<string, int> registers = new Dictionary<string, int>()
		{
			{ "a", 0 },
			{ "b", 0 },
			{ "c", 1 }, // { "c", 0 } for part 1
			{ "d", 0 }
		};
		private string[] strOps;

		public Computer(string[] strOps)
		{
			this.strOps = strOps;
		}

		public void Run()
		{
			int sp = 0;
			while(sp < strOps.Length)
			{
				var parts = strOps[sp].Split(' ');

				switch (parts[0])
				{
					case "cpy":
						registers[parts[2]] = char.IsDigit(parts[1][0]) ?
							int.Parse(parts[1]) : registers[parts[1]];
						break;
					case "inc":
						registers[parts[1]]++;
						break;
					case "dec":
						registers[parts[1]]--;
						break;
					case "jnz":
						if((char.IsDigit(parts[1][0]) ?
							int.Parse(parts[1]) : registers[parts[1]]) != 0)
						{
							sp += int.Parse(parts[2]);
							sp--;
						}
						break;
				}
				sp++;
			}
		}

		public int this [string reg]
		{
			get
			{
				return registers[reg];
			}
		}
	}
}
