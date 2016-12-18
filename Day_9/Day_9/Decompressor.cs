using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_9
{
	public class Decompressor
	{
		public static string Decompress(string input)
		{
			var buf = new StringBuilder();
			var regex = new Regex(@"\(\d+x\d+\)");

			Match match;
			var pos = 0;
			while ((match = regex.Match(input, pos)) != Match.Empty)
			{
				buf.Append(input.Substring(pos, match.Index - pos));

				// Advance past marker
				pos = match.Index + match.Length;

				// Extract marker info
				var strMatch = match.Value;
				// Remove parantheses
				strMatch = strMatch.Substring(1, strMatch.Length - 2);
				var parts = strMatch.Split('x');

				int numChars = int.Parse(parts[0]);
				int numRuns = int.Parse(parts[1]);
				for (int i = 0; i < numRuns; i++)
				{
					buf.Append(input.Substring(pos, numChars));
				}
				// Advance past expanded part of input
				pos += numChars;
			}
			//if(pos < input.Length - 1)
			{
				buf.Append(input.Substring(pos));
			}
			return buf.ToString();
		}
	}
}
