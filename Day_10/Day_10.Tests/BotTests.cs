using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10.Tests
{
	[TestFixture]
    public class BotTests
    {
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Bot_Adding_Too_Many_Values_Throws_Exception()
		{
			var b = new Bot();

			b.AddValue(1);
			b.AddValue(2);
			b.AddValue(3);
		}

		[Test]
		public void Bot_Gives_Correct_High_Value()
		{
			var b = new Bot();

			b.AddValue(3);
			b.AddValue(1);

			Assert.AreEqual(3, b.HighValue);
		}

		[Test]
		public void Bot_Gives_Correct_Low_Value()
		{
			var b = new Bot();

			b.AddValue(3);
			b.AddValue(1);

			Assert.AreEqual(1, b.LowValue);
		}

		[Test]
		public void Bot_Gives_Correct_Count_1()
		{
			var b = new Bot();

			b.AddValue(1);

			Assert.AreEqual(1, b.ValueCount);
		}

		[Test]
		public void Bot_Gives_Correct_Count_2()
		{
			var b = new Bot();

			b.AddValue(1);
			b.AddValue(3);

			Assert.AreEqual(2, b.ValueCount);
		}
	}
}
