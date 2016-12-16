using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Tests
{
	[TestFixture]
    public class TLSParserTests
    {
		[Test]
		public void TLSParser_Scenario_1()
		{
			var input = " abba[mnop]qrst";

			var result = new TLSParser(input).IsValidTLS();

			Assert.IsTrue(result);
		}

		[Test]
		public void TLSParser_Scenario_2()
		{
			var input = "abcd[bddb]xyyx";

			var result = new TLSParser(input).IsValidTLS();

			Assert.IsFalse(result);
		}

		[Test]
		public void TLSParser_Scenario_3()
		{
			var input = "aaaa[qwer]tyui";

			var result = new TLSParser(input).IsValidTLS();

			Assert.IsFalse(result);
		}

		[Test]
		public void TLSParser_Scenario_4()
		{
			var input = "ioxxoj[asdfgh]zxcvbn";

			var result = new TLSParser(input).IsValidTLS();

			Assert.IsTrue(result);
		}
	}
}
