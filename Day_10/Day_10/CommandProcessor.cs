using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
	public static class CommandProcessor
	{
		public static void Execute(BotRepository botRepos, 
				OutputRepository outputRepos, Command cmd)
		{
			if(cmd is FromInputToBotCommand)
			{
				var c = (FromInputToBotCommand)cmd;
				var bot = botRepos[c.ReceiverId];
				bot.AddValue(c.Value);
			}
			else if(cmd is FromBotToReceiversCommand)
			{
				var c = (FromBotToReceiversCommand)cmd;
				var giverBot = botRepos[c.GiverId];
				if(giverBot.ValueCount == 2)
				{
					if(c.LowReceiverIsOutput)
					{
						var bin = outputRepos[c.LowReceiverId];
						bin.Push(giverBot.LowValue);
					}
					else
					{
						var receiver = botRepos[c.LowReceiverId];
						receiver.AddValue(giverBot.LowValue);
					}
					if(c.HighReceiverIsOutput)
					{
						var bin = outputRepos[c.HighReceiverId];
						bin.Push(giverBot.HighValue);
					}
					else
					{
						var receiver = botRepos[c.HighReceiverId];
						receiver.AddValue(giverBot.HighValue);
					}
					giverBot.Clear();
				}
			}
		}
	}
}
