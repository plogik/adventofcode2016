using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_4_1
{
	public class Room
	{
		public static Room FromString(string input)
		{
			var room = new Room();

			// checksum
			var regex = new Regex(@"(?<=\[).*(?=\])");
			room.Checksum = regex.Match(input).ToString();

			// id
			regex = new Regex(@"(?<=-)\d*(?=\[)");
			room.SectorId = int.Parse(regex.Match(input).ToString());

			room.Name = input.Substring(0, input.LastIndexOf('-')).Replace("-", string.Empty);

			return room;
		}

		public string GetDecryptedName()
		{
			var buffer = new StringBuilder();

			foreach(var c in Name)
			{
				buffer.Append((char)(((c - 'a') + SectorId) % 26 + 'a'));
			}
			return buffer.ToString();
		}

		public bool Valid
		{
			get
			{
				return ExpectedChecksum.Equals(Checksum);
			}
		}

		public string Name
		{
			get;
			private set;
		}

		public int SectorId
		{
			get;
			private set;
		}

		public string Checksum
		{
			get;
			private set;
		}

		public string ExpectedChecksum
		{
			get
			{
				var groups = (from c in Name
							  group c by c into g
							  select new
							  {
								  c = g.Key,
								  count = g.Count(),
								  name = g.Key
							  }).OrderByDescending(c => c.count).ThenBy(c => c.name);
				var builder = new StringBuilder();
				foreach(var group in groups)
				{
					builder.Append(group.c);
				}
				return builder.ToString().Substring(0, 5);
			}
		}
	}
}
