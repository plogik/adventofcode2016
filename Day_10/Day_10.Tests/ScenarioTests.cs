using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10.Tests
{
	[TestFixture]
	class ScenarioTests
	{
		/*[SetUp]
		public void Setup()
		{

			CommandExecutor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandExecutor.Execute(botRepos, outputRepos, CommandParser.Parse("value 3 goes to bot 1"));
			CommandExecutor.Execute(botRepos, outputRepos, CommandParser.Parse("value 2 goes to bot 2"));
			CommandExecutor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 2 gives low to bot 1 and high to bot 0"));
			CommandExecutor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 1 gives low to output 1 and high to bot 0"));
			CommandExecutor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 0 gives low to output 2 and high to output 0"));
		}*/

		[Test]
		public void Scenario_1()
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();

			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 7 goes to bot 2"));

			var bot = botRepos[2];

			Assert.AreEqual(5, bot.LowValue);
		}

		[Test]
		public void Scenario_2()
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();

			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 7 goes to bot 2"));

			var bot = botRepos[2];

			Assert.AreEqual(7, bot.HighValue);
		}

		[Test]
		public void Scenario_3()
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();

			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 7 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 2 gives low to bot 1 and high to bot 1"));

			var bot = botRepos[1];

			Assert.AreEqual(5, bot.LowValue);
		}

		[Test]
		public void Scenario_4()
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();

			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 7 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 2 gives low to bot 1 and high to bot 1"));

			var bot = botRepos[1];

			Assert.AreEqual(7, bot.HighValue);
		}

		// These test the example scenario in the task, ordered so we won't have to do multiple passes

		[Test]
		public void Scenario_Example_Test1()
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();

			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 3 goes to bot 1"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 2 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 2 gives low to bot 1 and high to bot 0"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 1 gives low to output 1 and high to bot 0"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 0 gives low to output 2 and high to output 0"));

			var bin = outputRepos[0];
			Assert.IsTrue(bin.Contains(5));
		}

		[Test]
		public void Scenario_Example_Test2()
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();

			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 3 goes to bot 1"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 2 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 2 gives low to bot 1 and high to bot 0"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 1 gives low to output 1 and high to bot 0"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 0 gives low to output 2 and high to output 0"));

			var bin = outputRepos[1];
			Assert.IsTrue(bin.Contains(2));
		}

		[Test]
		public void Scenario_Example_Test3()
		{
			var botRepos = new BotRepository();
			var outputRepos = new OutputRepository();

			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 5 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 3 goes to bot 1"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("value 2 goes to bot 2"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 2 gives low to bot 1 and high to bot 0"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 1 gives low to output 1 and high to bot 0"));
			CommandProcessor.Execute(botRepos, outputRepos, CommandParser.Parse("bot 0 gives low to output 2 and high to output 0"));

			var bin = outputRepos[2];
			Assert.IsTrue(bin.Contains(3));
		}
	}
}
