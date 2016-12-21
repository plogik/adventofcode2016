using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12.Tests
{
	[TestFixture]
	class ComputerTests
	{
		[Test]
		public void Computer_Do_Assignment_Example_Scenario()
		{
			var ops = new string[]
			{
				"cpy 41 a",
				"inc a",
				"inc a",
				"dec a",
				"jnz a 2",
				"dec a"
			};

			var comp = new Computer(ops);
			comp.Run();

			Assert.AreEqual(42, comp['a']);
		}
	}
}
