using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_18.Tests
{
	[TestFixture]
    public class MapMakerTests
    {
		[Test]
		public void MapMaker_Row_Test_1()
		{
			var input = "..^^.".ToCharArray();

			var result = new string(MapMaker.NextRow(input));

			Assert.AreEqual(".^^^^", result);
		}

		[Test]
		public void MapMaker_Row_Test_2()
		{
			var input = ".^^^^".ToCharArray();

			var result = new string(MapMaker.NextRow(input));

			Assert.AreEqual("^^..^", result);
		}

		[Test]
		public void MapMaker_Row_Test_3()
		{
			var input = ".^^.^.^^^^".ToCharArray();

			var result = new string(MapMaker.NextRow(input));

			Assert.AreEqual("^^^...^..^", result);
		}

	}
}
