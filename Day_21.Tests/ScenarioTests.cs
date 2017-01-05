using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21.Tests
{
	[TestFixture]
	public class ScenarioTests
	{
		[Test]
		public void Scenario_Test_1()
		{
			var input = "abcde";

			input = OperationParser.Parse("swap position 4 with position 0").Execute(input);
			input = OperationParser.Parse("swap letter d with letter b").Execute(input);
			input = OperationParser.Parse("reverse positions 0 through 4").Execute(input);
			input = OperationParser.Parse("rotate left 1 step").Execute(input);
			input = OperationParser.Parse("move position 1 to position 4").Execute(input);
			input = OperationParser.Parse("move position 3 to position 0").Execute(input);
			input = OperationParser.Parse("rotate based on position of letter b").Execute(input);
			input = OperationParser.Parse("rotate based on position of letter d").Execute(input);

			Assert.AreEqual("decab", input);
		}

		[Test]
		public void Descramble_Scenario_Test_1()
		{
			var input = "decab";

			input = OperationParser.Parse("rotate based on position of letter d", true).Execute(input);
			input = OperationParser.Parse("rotate based on position of letter b", true).Execute(input);
			input = OperationParser.Parse("move position 3 to position 0", true).Execute(input);
			input = OperationParser.Parse("move position 1 to position 4", true).Execute(input);
			input = OperationParser.Parse("rotate left 1 step", true).Execute(input);
			input = OperationParser.Parse("reverse positions 0 through 4", true).Execute(input);
			input = OperationParser.Parse("swap letter d with letter b", true).Execute(input);
			input = OperationParser.Parse("swap position 4 with position 0", true).Execute(input);

			Assert.AreEqual("abcde", input);
		}
	}
}
