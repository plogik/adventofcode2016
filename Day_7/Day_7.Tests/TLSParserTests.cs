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

			var result = TLSParser.IsValidTLS(input);

			Assert.IsTrue(result);
		}

		[Test]
		public void TLSParser_Scenario_2()
		{
			var input = "abcd[bddb]xyyx";

			var result = TLSParser.IsValidTLS(input);

			Assert.IsFalse(result);
		}

		[Test]
		public void TLSParser_Scenario_3()
		{
			var input = "aaaa[qwer]tyui";

			var result = TLSParser.IsValidTLS(input);

			Assert.IsFalse(result);
		}

		[Test]
		public void TLSParser_Scenario_4()
		{
			var input = "";

			var result = TLSParser.IsValidTLS(input);

			Assert.IsTrue(result);
		}
	}
}
