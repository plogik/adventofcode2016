using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9_Pt_2.Tests
{
	[TestFixture]
    public class DecompressorTests
    {
		[Test]
		public void Decompressor_Scenario_1()
		{
			var input = "(3x3)XYZ";

			var len = Decompressor.Expand(input);

			Assert.AreEqual(9, len);
		}

		[Test]
		public void Decompressor_Scenario_2()
		{
			var input = "X(8x2)(3x3)ABCY";

			var len = Decompressor.Expand(input);

			Assert.AreEqual(20, len);
		}

		[Test]
		public void Decompressor_Scenario_3()
		{
			var input = "(27x12)(20x12)(13x14)(7x10)(1x12)A";

			var len = Decompressor.Expand(input);

			Assert.AreEqual(241920, len);
		}

		[Test]
		public void Decompressor_Scenario_4()
		{
			var input = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";

			var len = Decompressor.Expand(input);

			Assert.AreEqual(445, len);
		}
	}
}
