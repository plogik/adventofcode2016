using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20.Tests
{
	[TestFixture]
    public class RangeTests
    {
		[Test]
		public void Range_TestOverlaps_1()
		{
			var r1 = new Range(4, 6);
			var r2 = new Range(5, 7);

			Assert.IsTrue(r1.Overlaps(r2));
		}

		[Test]
		public void Range_TestOverlaps_2()
		{
			var r1 = new Range(4, 6);
			var r2 = new Range(5, 7);

			Assert.IsTrue(r2.Overlaps(r1));
		}

		[Test]
		public void Range_TestOverlaps_3()
		{
			var r1 = new Range(4, 6);
			var r2 = new Range(7, 8);

			Assert.IsFalse(r2.Overlaps(r1));
		}

		[Test]
		public void Range_Test_Expand()
		{
			var r1 = new Range(4, 6);
			var r2 = new Range(6, 8);

			r1.Merge(r2);

			Assert.AreEqual(new Range(4, 8), r1);
		}

		[Test]
		public void Range_TestExpand_1()
		{
			var r1 = new Range(399974274, 423562472);
			var r2 = new Range(412226938, 422230809);

			r2.Merge(r1);

			Assert.AreEqual(new Range(399974274, 423562472), r2);
		}
	}
}
