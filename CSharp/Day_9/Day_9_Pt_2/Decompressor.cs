using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_9_Pt_2
{
	public class Decompressor
	{
		private static Regex regex = new Regex(@"\(\d+x\d+\)");

		public static long Expand(string input)
		{
			return Expand(input, 0, input.Length);
		}

		private static long Expand(string input, int startPos, int length)
		{
			long expLen = 0L;
			Match match;

			while((match = regex.Match(input, startPos, length)) != Match.Empty)
			{
				expLen += match.Index - startPos;

				var marker = ParseMarker(match.Value);

				expLen += 
					marker.Multiplier *
						Expand(input, match.Index + match.Length, marker.Length);

				length -= match.Index + match.Length + marker.Length - startPos;
				startPos = match.Index + match.Length + marker.Length;
			}
			expLen += length;

			return expLen;
		}

		private static Marker ParseMarker(string marker)
		{
			marker = marker.Substring(1, marker.Length - 2);
			var parts = marker.Split('x');

			return new Marker()
			{
				Length = int.Parse(parts[0]),
				Multiplier = int.Parse(parts[1])
			};
		}

		struct Marker
		{
			internal int Multiplier;
			internal int Length;
		}
	}
}
