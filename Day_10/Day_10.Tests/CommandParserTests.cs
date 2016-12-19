using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10.Tests
{
	[TestFixture]
	class CommandParserTests
	{
		[Test]
		public void CommandParser_Parse_FromInputToBotCommand()
		{
			var input = "value 5 goes to bot 2";

			var cmd = CommandParser.Parse(input);

			Assert.IsInstanceOf(typeof(FromInputToBotCommand), cmd);
		}

		[Test]
		public void CommandParser_Parse_FromInputToBotCommand_Value()
		{
			var input = "value 5 goes to bot 2";

			var cmd = (FromInputToBotCommand) CommandParser.Parse(input);

			Assert.AreEqual(5, cmd.Value);
		}

		[Test]
		public void CommandParser_Parse_FromInputToBotCommand_Receiver()
		{
			var input = "value 5 goes to bot 2";

			var cmd = (FromInputToBotCommand)CommandParser.Parse(input);

			Assert.AreEqual(2, cmd.ReceiverId);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand()
		{
			var input = "bot 2 gives low to bot 1 and high to bot 0";

			var cmd = CommandParser.Parse(input);

			Assert.IsInstanceOf(typeof(FromBotToReceiversCommand), cmd);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand_Giver_Id()
		{
			var input = "bot 2 gives low to bot 1 and high to bot 0";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.AreEqual(2, cmd.GiverId);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand_Low_Id()
		{
			var input = "bot 2 gives low to bot 1 and high to bot 0";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.AreEqual(1, cmd.LowReceiverId);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand_High_Id()
		{
			var input = "bot 2 gives low to bot 1 and high to bot 0";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.AreEqual(0, cmd.HighReceiverId);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand_Low_Is_Bot()
		{
			var input = "bot 2 gives low to bot 1 and high to bot 0";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.IsFalse(cmd.LowReceiverIsOutput);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand_High_Is_Bot()
		{
			var input = "bot 2 gives low to bot 1 and high to bot 0";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.IsFalse(cmd.HighReceiverIsOutput);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand_Low_Is_Output()
		{
			var input = "bot 1 gives low to output 1 and high to bot 0";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.IsTrue(cmd.LowReceiverIsOutput);
		}

		[Test]
		public void CommandParser_Parse_FromBotToReceiversCommand_High_Is_Output()
		{
			var input = "bot 2 gives low to bot 1 and high to output 0";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.IsTrue(cmd.HighReceiverIsOutput);
		}

		[Test]
		public void CommandParser_Parse_TestSomeError()
		{
			var input = "bot 28 gives low to output 0 and high to bot 61";

			var cmd = (FromBotToReceiversCommand)CommandParser.Parse(input);

			Assert.IsTrue(cmd.LowReceiverIsOutput);
			Assert.AreEqual(0, cmd.LowReceiverId);
		}

	}
}
