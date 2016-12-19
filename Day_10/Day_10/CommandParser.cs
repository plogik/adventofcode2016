using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_10
{
	public static class CommandParser
	{
		public static Command Parse(string input)
		{
			var inToBotRegex = new Regex(@"value \d+ goes to bot \d+");
			var botToBotsOrOutputRegex = new Regex(@"bot \d+ gives low to .*");
			var digitsRegex = new Regex(@"\d+");

			if(inToBotRegex.IsMatch(input))
			{
				var cmd = new FromInputToBotCommand();
				var matches = digitsRegex.Matches(input);
				cmd.Value = int.Parse(matches[0].Value);
				cmd.ReceiverId = int.Parse(matches[1].Value);
				return cmd;
			}
			if(botToBotsOrOutputRegex.IsMatch(input))
			{
				var cmd = new FromBotToReceiversCommand();
				var matches = digitsRegex.Matches(input);
				cmd.GiverId = int.Parse(matches[0].Value);
				cmd.LowReceiverId = int.Parse(matches[1].Value);
				cmd.HighReceiverId = int.Parse(matches[2].Value);
				cmd.LowReceiverIsOutput = input.IndexOf("low to output") != -1;
				cmd.HighReceiverIsOutput = input.IndexOf("and high to output") != -1;

				return cmd;
			}
			throw new FormatException("Can not parse:" + input);
			return null;
		}
	}
}
