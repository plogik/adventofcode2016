using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_23
{
	// Modified computer from day 12
	public class Computer
	{
		private Dictionary<string, long> registers = new Dictionary<string, long>()
		{
			{ "a", 12 }, // 7 for pt 1, 12 for pt 2
			{ "b", 0 },
			{ "c", 0 },
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
					case "tgl":
						// The new and shiny toogle
						var idx = sp + registers[parts[1]];
						if(idx < strOps.Length) // inside program bounds?
						{
							var strOp = strOps[idx];
							var toToggle = strOp.Split(' ')[0];
							var toggledOp = 
								toToggle == "cpy" ? "jnz" :
								toToggle == "jnz" ? "cpy" :
								toToggle == "inc" ? "dec" : "inc";
							strOps[idx] = toggledOp + strOps[idx].Substring(3);
						}
						break;
					case "cpy":
						// Skip if the new tgl instruction has messed this into a non-valid instruction 
						// (does not happen on my input though)
						if (!(char.IsDigit(parts[1][0]) && char.IsDigit(parts[2][0])))
						{
							registers[parts[2]] = (char.IsDigit(parts[1][0]) || parts[1][0] == '-') ?
								long.Parse(parts[1]) : registers[parts[1]];
						}
						break;
					case "inc":
						registers[parts[1]]++;
						break;
					case "dec":
						registers[parts[1]]--;
						break;
					case "jnz":
						// Jump only if literal or content of reg is not 0
						if((char.IsDigit(parts[1][0]) ?
							long.Parse(parts[1]) : registers[parts[1]]) != 0)
						{
							// Jump by literal (isDigit or starts with '-') or by content of reg
							sp += (int)((char.IsDigit(parts[2][0]) || parts[2][0] == '-') ?
								long.Parse(parts[2]) : registers[parts[2]]);
							sp--;
						}
						break;
				}
				sp++;
			}
		}

		public long this [string reg]
		{
			get
			{
				return registers[reg];
			}
		}
	}
}
