using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8.Tests
{
	[TestFixture]
    public class DisplayTests
    {
		private Display display;

		[SetUp]
		public void Init()
		{
			display = new Display(3, 7);
			display.OpRect(3, 2);
		}

		[Test]
		public void Display_Scenario_1()
		{
			Assert.AreEqual(
				"###...." + Environment.NewLine +
				"###...." + Environment.NewLine +
				"......." + Environment.NewLine, 
				display.ToString());
		}

		[Test]
		public void Display_Scenario_2()
		{
			display.OpRotateColumn(1, 1);
			Assert.AreEqual(
				"#.#...." + Environment.NewLine +
				"###...." + Environment.NewLine +
				".#....." + Environment.NewLine,
				display.ToString());

		}

		[Test]
		public void Display_Scenario_Col_Overflow()
		{
			display.OpRotateColumn(1, 2);
			Assert.AreEqual(
				"###...." + Environment.NewLine +
				"#.#...." + Environment.NewLine +
				".#....." + Environment.NewLine,
				display.ToString());

		}

		[Test]
		public void Display_Rotate_Row_By_1()
		{
			display.OpRotateRow(0, 1);
			Assert.AreEqual(
				".###..." + Environment.NewLine +
				"###...." + Environment.NewLine +
				"......." + Environment.NewLine,
				display.ToString());
		}

		[Test]
		public void Display_Scenario_3()
		{
			display.OpRotateRow(0, 4);
			Assert.AreEqual(
				"....###" + Environment.NewLine +
				"###...." + Environment.NewLine +
				"......." + Environment.NewLine,
				display.ToString());
		}

		[Test]
		public void Display_Scenario_Row_Overflow()
		{
			display.OpRotateRow(0, 5);
			Assert.AreEqual(
				"#....##" + Environment.NewLine +
				"###...." + Environment.NewLine +
				"......." + Environment.NewLine,
				display.ToString());
		}

		[Test]
		public void Display_Scenario_Add_Pixels()
		{
			display.OpRotateRow(0, 5);
			display.OpRect(3, 3);
			Assert.AreEqual(
				"###..##" + Environment.NewLine +
				"###...." + Environment.NewLine +
				"###...." + Environment.NewLine,
				display.ToString());
		}

		[Test]
		public void Display_On_Count()
		{
			Assert.AreEqual(6, display.PixelOnCount);
		}
	}
}
