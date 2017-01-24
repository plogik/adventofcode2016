using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6.Tests
{
	[TestFixture]
    public class RepeaterDescramblerTests
    {
		[Test]
		public void Descrambler_Scenario_1_Pt_1()
		{
			var messages = new string[]
			{
				"eedadn",
				"drvtee",
				"eandsr",
				"raavrd",
				"atevrs",
				"tsrnev",
				"sdttsa",
				"rasrtv",
				"nssdts",
				"ntnada",
				"svetve",
				"tesnvt",
				"vntsnd",
				"vrdear",
				"dvrsen",
				"enarar"
			};

			var descrambler = new RepeaterDescrambler(messages);

			descrambler.DescramblePt1();

			Assert.AreEqual("easter", descrambler.Descrambled);
		}

		[Test]
		public void Descrambler_Scenario_1_Pt_2()
		{
			var messages = new string[]
			{
				"eedadn",
				"drvtee",
				"eandsr",
				"raavrd",
				"atevrs",
				"tsrnev",
				"sdttsa",
				"rasrtv",
				"nssdts",
				"ntnada",
				"svetve",
				"tesnvt",
				"vntsnd",
				"vrdear",
				"dvrsen",
				"enarar"
			};

			var descrambler = new RepeaterDescrambler(messages);

			descrambler.DescramblePt2();

			Assert.AreEqual("advent", descrambler.Descrambled);
		}
	}
}
