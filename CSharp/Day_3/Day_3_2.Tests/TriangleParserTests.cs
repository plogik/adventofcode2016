using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_2.Tests
{
	[TestFixture]
    public class TriangleParserTests
    {
		[Test]
		public void TriangleParser_ShouldFindTwoValid()
		{
			var input = "345 456 345 511 522 533 555 611 622 633 543";

			var triangles = TriangleParser.Parse(input);

			Assert.AreEqual(2, triangles.Count);
			Assert.AreEqual(511, triangles[0].A);
			Assert.AreEqual(522, triangles[0].B);
			Assert.AreEqual(533, triangles[0].C);

			Assert.AreEqual(611, triangles[1].A);
			Assert.AreEqual(622, triangles[1].B);
			Assert.AreEqual(633, triangles[1].C);
		}
	}
}
