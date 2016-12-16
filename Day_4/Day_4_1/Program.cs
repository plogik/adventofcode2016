using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_4_1
{
	class Program
	{
		static void Main(string[] args)
		{
			var rooms = new List<Room>();
			foreach (var line in File.ReadAllLines("input.txt"))
			{
				rooms.Add(Room.FromString(line));
			}

			// Add valid rooms
			int sum = 0;
			foreach(var room in rooms)
			{
				if (room.Valid)
					sum += room.SectorId;
			}
			Console.WriteLine(sum);


			// Part 2
			foreach (var room in rooms)
			{
				if (room.Valid)
				{
					var name = room.GetDecryptedName();
					if (name.StartsWith("north"))
						Console.WriteLine(name + " id:" + room.SectorId);
				}
			}




			Console.ReadLine();
		}
	}
}
