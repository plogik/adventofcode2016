using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4_1.Tests
{
	[TestFixture]
    public class RoomTests
    {
		[Test]
		public void Room_Parse_Scenario1_Validate()
		{
			var room = Room.FromString("aaaaa-bbb-z-y-x-123[abxyz]");

			Assert.IsTrue(room.Valid);
		}

		[Test]
		public void Room_Parse_Scenario1_Id()
		{
			var room = Room.FromString("aaaaa-bbb-z-y-x-123[abxyz]");

			Assert.AreEqual(123, room.SectorId);
		}

		[Test]
		public void Room_Parse_Scenario2_Validate()
		{
			var room = Room.FromString("a-b-c-d-e-f-g-h-987[abcde]");

			Assert.IsTrue(room.Valid);
		}

		[Test]
		public void Room_Parse_Scenario2_Id()
		{
			var room = Room.FromString("a-b-c-d-e-f-g-h-987[abcde]");

			Assert.AreEqual(987, room.SectorId);
		}

		[Test]
		public void Room_Parse_Scenario3_Validate()
		{
			var room = Room.FromString("not-a-real-room-404[oarel]");

			Assert.IsTrue(room.Valid);
		}

		[Test]
		public void Room_Parse_Scenario3_Id()
		{
			var room = Room.FromString("not-a-real-room-404[oarel]");

			Assert.AreEqual(404, room.SectorId);
		}

		[Test]
		public void Room_Parse_Scenario4_Validate()
		{
			var room = Room.FromString("totally-real-room-200[decoy]");

			Assert.IsFalse(room.Valid);
		}

		[Test]
		public void Room_Parse_Scenario4_Id()
		{
			var room = Room.FromString("totally-real-room-200[decoy]");

			Assert.AreEqual(200, room.SectorId);
		}
	}
}
