using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_16.Tests
{
	[TestFixture]
    public class CalculatorTests
    {
		[Test]
		public void Calculator_Get_Data_1()
		{
			var c = new Calculator(new byte[] { 1 });

			c.GenerateData(3);
			var result = c.Data;

			Assert.IsTrue(result.SequenceEqual(new byte[] { 1, 0, 0 }));
		}

		[Test]
		public void Calculator_Get_Data_2()
		{
			var c = new Calculator(new byte[] { 0 });

			c.GenerateData(3);
			var result = c.Data;

			Assert.IsTrue(result.SequenceEqual(new byte[] { 0, 0, 1 }));
		}

		[Test]
		public void Calculator_Get_Data_3()
		{
			var c = new Calculator(new byte[] { 1, 1, 1, 1, 1 });

			c.GenerateData(11);
			var result = c.Data;

			Assert.IsTrue(result.SequenceEqual(
				new byte[] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 }));
		}

		[Test]
		public void Calculator_Get_Data_4()
		{
			var c = new Calculator(new byte[] { 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0 });

			// 111100001010
			c.GenerateData(20);
			var result = c.Data;

			// 111100001010 01010111
			Assert.IsTrue(result.SequenceEqual(
				new byte[] { 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1 }));
		}

		[Test]
		public void Calculator_Checksum_Test()
		{
			var c = new Calculator(new byte[] { });

			c.Data = new byte[] { 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0 };

			var result = c.CalculateChecksum();

			Assert.IsTrue(result.SequenceEqual(new byte[] { 1, 0, 0 }));
		}

		[Test]
		public void Calculator_Scenario_1()
		{
			var c = new Calculator(new byte[] { 1, 0, 0, 0, 0 });

			c.GenerateData(20);

			var result = c.CalculateChecksum();

			Assert.IsTrue(result.SequenceEqual(new byte[] { 0, 1, 1, 0, 0 } ));
		}
	}
}
