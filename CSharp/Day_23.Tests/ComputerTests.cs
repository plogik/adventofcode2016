using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23.Tests
{
	[TestFixture]
    public class ComputerTests
    {
		[Test]
		public void Computer_Test_Scenario_1()
		{
			var input = new string[]
			{
				"cpy 2 a",
				"tgl a",
				"tgl a",
				"tgl a",
				"cpy 1 a",
				"dec a",
				"dec a"
			};

			var computer = new Computer(input);
			computer.Run();

			Assert.AreEqual(3, computer["a"]);
		}
    }
}
