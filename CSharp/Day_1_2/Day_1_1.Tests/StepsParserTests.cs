using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_2.Tests
{
	[TestFixture]
	public class StepsParserTests
	{
		[Test]
		public void StepsParser_NotNull()
		{
			string input = "";

			List<DirectionAndSteps> steps = StepsParser.Parse(input);

			Assert.NotNull(steps);
		}

		[Test]
		public void StepsParser_OneElement()
		{
			string input = "L3";

			List<DirectionAndSteps> steps = StepsParser.Parse(input);

			Assert.AreEqual(
				new DirectionAndSteps() { Direction = Directions.L, Steps = 3 }, 
				steps[0]);
		}

		[Test]
		public void StepsParser_TwoElements()
		{
			string input = "L3, R4 ";

			List<DirectionAndSteps> steps = StepsParser.Parse(input);

			Assert.AreEqual(
				new DirectionAndSteps() { Direction = Directions.L, Steps = 3 },
				steps[0]);
			Assert.AreEqual(
				new DirectionAndSteps() { Direction = Directions.R, Steps = 4 },
				steps[1]);
		}

	}
}
