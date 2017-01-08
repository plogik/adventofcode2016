using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_25
{
	// Modified computer from day 23 (and 12)
	public class Computer
	{
		private Dictionary<string, long> registers = new Dictionary<string, long>()
		{
			{ "a", 0 }, 
			{ "b", 0 },
			{ "c", 0 },
			{ "d", 0 }
		};
		private string[] strOps;

		public Computer(string[] strOps)
		{
			this.strOps = strOps;
		}

		public int[] Run(int sequenceLen)
		{
			var seqIdx = 0;
			var buf = new int[sequenceLen];
			int sp = 0;
			while(sp < strOps.Length)
			{
				var parts = strOps[sp].Split(' ');

				switch (parts[0])
				{
					case "tgl":
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
					case "out":
						buf[seqIdx] = (int)registers[parts[1]];
						seqIdx++;
						if (seqIdx == sequenceLen)
							return buf;
						break;
				}
				sp++;
			}
			return null;
		}

		public long this [string reg]
		{
			set
			{
				registers[reg] = value;
			}
			get
			{
				return registers[reg];
			}
		}
	}
}
