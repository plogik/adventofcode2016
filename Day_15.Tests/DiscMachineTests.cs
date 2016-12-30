using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15.Tests
{
	[TestFixture]
    public class DiscMachineTests
    {
		[Test]
		public void DiscMachine_Scenario_1()
		{
			var m = new DiscMachine();

			var discs = new Disc[] 
			{
				new Disc() { posCount = 5, currPos = 4},
				new Disc() { posCount = 2, currPos = 1 }
			};

			var result = m.GetSecondToDrop(discs);

			Assert.AreEqual(5, result);
		}
	}
}
