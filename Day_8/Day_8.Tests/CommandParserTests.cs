using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8.Tests
{
	[TestFixture]
	public class CommandParserTests
	{
		Display display;

		[SetUp]
		public void Init()
		{
			display = new Display(3, 7);
			CommandParser.PerformOp(display, "rect 3x2");
		}

		[Test]
		public void CommandParser_Scenario_1()
		{
			Assert.AreEqual(
				"###...." + Environment.NewLine +
				"###...." + Environment.NewLine +
				"......." + Environment.NewLine,
				display.ToString());
		}

		[Test]
		public void CommandParser_Scenario_2()
		{
			CommandParser.PerformOp(display, "rotate column x=1 by 1");
			Assert.AreEqual(
				"#.#...." + Environment.NewLine +
				"###...." + Environment.NewLine +
				".#....." + Environment.NewLine,
				display.ToString());

		}

		[Test]
		public void CommandParser_Scenario_3()
		{
			CommandParser.PerformOp(display, "rotate row y=0 by 4");
			Assert.AreEqual(
				"....###" + Environment.NewLine +
				"###...." + Environment.NewLine +
				"......." + Environment.NewLine,
				display.ToString());
		}
	}
}
