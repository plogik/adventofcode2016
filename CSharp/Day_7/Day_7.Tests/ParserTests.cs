using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Tests
{
	[TestFixture]
    public class ParserTests
    {
		[Test]
		public void TLSParser_Scenario_1()
		{
			var input = " abba[mnop]qrst";

			var result = new Parser(input).IsValidTLS();

			Assert.IsTrue(result);
		}

		[Test]
		public void TLSParser_Scenario_2()
		{
			var input = "abcd[bddb]xyyx";

			var result = new Parser(input).IsValidTLS();

			Assert.IsFalse(result);
		}

		[Test]
		public void TLSParser_Scenario_3()
		{
			var input = "aaaa[qwer]tyui";

			var result = new Parser(input).IsValidTLS();

			Assert.IsFalse(result);
		}

		[Test]
		public void TLSParser_Scenario_4()
		{
			var input = "ioxxoj[asdfgh]zxcvbn";

			var result = new Parser(input).IsValidTLS();

			Assert.IsTrue(result);
		}

		[Test]
		public void SSLParser_Scenario_1()
		{
			var input = "aba[bab]xyz";

			var result = new Parser(input).IsValidSSL();

			Assert.IsTrue(result);
		}

		[Test]
		public void SSLParser_Scenario_2()
		{
			var input = "xyx[xyx]xyx";

			var result = new Parser(input).IsValidSSL();

			Assert.IsFalse(result);
		}

		[Test]
		public void SSLParser_Scenario_3()
		{
			var input = "aaa[kek]eke";

			var result = new Parser(input).IsValidSSL();

			Assert.IsTrue(result);
		}

		[Test]
		public void SSLParser_Scenario_4()
		{
			var input = "zazbz[bzb]cdb";

			var result = new Parser(input).IsValidSSL();

			Assert.IsTrue(result);
		}
	}
}
