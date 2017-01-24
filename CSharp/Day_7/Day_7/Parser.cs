using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_7
{
	public class Parser
	{
		private string insideBrackets;
		private string outsideBrackets;

		public Parser(string input)
		{
			Parse(input);
		}

		public bool IsValidTLS()
		{
			return HasValidFourCharSequence(outsideBrackets) &&
				!HasValidFourCharSequence(insideBrackets);
		}

		private void Parse(string input)
		{
			bool inside = false;
			var insideBuf = new StringBuilder();
			var outsideBuf = new StringBuilder();
			foreach (var c in input)
			{
				if (c == '[')
				{
					inside = true;
					continue;
				}
				if (c == ']')
				{
					inside = false;
					continue;
				}
				insideBuf.Append(inside ? c : ' ');
				outsideBuf.Append(inside ? ' ' : c);
			}
			insideBrackets = insideBuf.ToString();
			outsideBrackets = outsideBuf.ToString();
		}

		private static bool HasValidFourCharSequence(string seq)
		{
			for(int i = 0; i < seq.Length - 3; i++)
			{
				if (seq[i] == seq[i + 3] &&
					seq[i + 1] == seq[i + 2] &&
					seq[i] != seq[i + 1])
					return true;
			}
			return false;
		}

		public bool IsValidSSL()
		{
			bool valid = false;
			for(int i = 0; i < outsideBrackets.Length - 2; i++)
			{
				if(outsideBrackets[i] == outsideBrackets[i + 2] &&
					outsideBrackets[i] != outsideBrackets[i + 1])
				{
					var revChars = new string(new char[]
					{
						outsideBrackets[i + 1],
						outsideBrackets[i],
						outsideBrackets[i + 1]
					});
					if(insideBrackets.IndexOf(revChars) != -1)
					{
						return true;
					}

				}
			}
			return valid;
		}

		
	}
}
