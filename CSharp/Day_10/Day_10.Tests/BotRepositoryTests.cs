using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10.Tests
{
	[TestFixture]
	class BotRepositoryTests
	{
		[Test]
		public void BotRepos_Test_No_Duplicates()
		{
			var repos = new BotRepository();

			repos.Add(new Bot { Id = 1 });
			repos.Add(new Bot { Id = 2 });
			repos.Add(new Bot { Id = 1 });

			Assert.AreEqual(2, repos.Count);
		}

		[Test]
		public void BotRepos_Add_Test_Low_Value()
		{
			var repos = new BotRepository();

			// value 5 goes to bot 2
			var bot = repos[2];
			bot.AddValue(5);
			bot.AddValue(7);

			bot = repos[2];

			Assert.AreEqual(5, bot.LowValue);
		}

		[Test]
		public void BotRepos_Add_Test_High_Value()
		{
			var repos = new BotRepository();

			// value 5 goes to bot 2
			var bot = repos[2];
			bot.AddValue(5);
			bot.AddValue(7);

			bot = repos[2];

			Assert.AreEqual(7, bot.HighValue);
		}
	}
}
