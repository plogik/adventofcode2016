using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
	public interface Command
	{

	}

	public struct FromInputToBotCommand : Command
	{
		public int Value;
		public int ReceiverId;
	}

	public struct FromBotToReceiversCommand : Command
	{
		public int GiverId;
		public int LowReceiverId;
		public int HighReceiverId;
		public bool LowReceiverIsOutput;
		public bool HighReceiverIsOutput;
	}
}
