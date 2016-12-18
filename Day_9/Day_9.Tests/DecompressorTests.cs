using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9.Tests
{
	[TestFixture]
	public class DecompressorTests
	{
		[Test]
		public void Decompressor_Scenario_1()
		{
			var input = "ADVENT";

			var result = Decompressor.Decompress(input);

			Assert.AreEqual(input, result);
		}

		[Test]
		public void Decompressor_Scenario_2()
		{
			var input = "A(1x5)BC";

			var result = Decompressor.Decompress(input);

			Assert.AreEqual("ABBBBBC", result);
		}

		[Test]
		public void Decompressor_Scenario_3()
		{
			var input = "(3x3)XYZ";

			var result = Decompressor.Decompress(input);

			Assert.AreEqual("XYZXYZXYZ", result);
		}

		[Test]
		public void Decompressor_Scenario_4()
		{
			var input = "A(2x2)BCD(2x2)EFG";

			var result = Decompressor.Decompress(input);

			Assert.AreEqual("ABCBCDEFEFG", result);
		}

		[Test]
		public void Decompressor_Scenario_5()
		{
			var input = "(6x1)(1x3)A";

			var result = Decompressor.Decompress(input);

			Assert.AreEqual("(1x3)A", result);
		}

		[Test]
		public void Decompressor_Scenario_6()
		{
			var input = "X(8x2)(3x3)ABCY";

			var result = Decompressor.Decompress(input);

			Assert.AreEqual("X(3x3)ABC(3x3)ABCY", result);
		}
	}
}
