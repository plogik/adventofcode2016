using Day1_2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1_2.Tests
{
    [TestFixture]
    public class NavigatorTest
    {
        [Test]
        public void Navigator_Left1_Should_Position_X0_Y_minus_1()
        {
            // Arrange
            Navigator nav = new Navigator();

            // Act
            nav.Move(Directions.L, 1);

			//Assert
			Assert.AreEqual(new Point() { X = -1, Y = 0 }, nav.CurrentPosition);
        }

		[Test]
		public void Navigator_Scenario_1()
		{
			// R2, L3

			// Arrange
			Navigator nav = new Navigator();

			// Act
			nav.Move(Directions.R, 2);
			nav.Move(Directions.L, 3);

			// Assert
			Assert.AreEqual(new Point() { X = 2, Y = 3 }, nav.CurrentPosition);
		}

		[Test]
		public void Navigator_Scenario_2()
		{
			// R2, R2, R2

			// Arrange
			Navigator nav = new Navigator();

			// Act
			nav.Move(Directions.R, 2);
			nav.Move(Directions.R, 2);
			nav.Move(Directions.R, 2);

			// Assert
			Assert.AreEqual(new Point() { X = 0, Y = -2 }, nav.CurrentPosition);
		}

		[Test]
		public void Navigator_Scenario_3()
		{
			// R5, L5, R5, R3

			// Arrange
			Navigator nav = new Navigator();

			// Act
			nav.Move(Directions.R, 5);
			nav.Move(Directions.L, 5);
			nav.Move(Directions.R, 5);
			nav.Move(Directions.R, 3);

			// Assert
			Assert.AreEqual(12, nav.CurrentPosition.DistanceFromOrigo());
		}

		[Test]
		public void Navigator_Scenario_pt2()
		{
			// R8, R4, R4, R8
			var nav = new Navigator();

			nav.Move(Directions.R, 8);
			nav.Move(Directions.R, 4);
			nav.Move(Directions.R, 4);
			nav.Move(Directions.R, 8);

			Assert.AreEqual(4, nav.DistanceToFirstCrossing());
		}

		[Test]
		public void Navigator_Scenario_pt2_2()
		{
			var nav = new Navigator();

			nav.Move(Directions.L, 4);
			nav.Move(Directions.L, 3);
			nav.Move(Directions.L, 2);
			nav.Move(Directions.L, 4);

			Assert.AreEqual(2, nav.DistanceToFirstCrossing());
		}
	}
}
