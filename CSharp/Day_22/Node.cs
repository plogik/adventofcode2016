using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
	public class Node
	{
		public string Filesystem;
		public int Size;
		public int Used;
		public int Avail;
		public int UsedPercent;

		public static Node From(string input)
		{
			var parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			return new Node()
			{
				Filesystem = parts[0],
				Size = int.Parse(parts[1].Substring(0, parts[1].Length - 1)),
				Used = int.Parse(parts[2].Substring(0, parts[2].Length - 1)),
				Avail = int.Parse(parts[3].Substring(0, parts[3].Length - 1)),
				UsedPercent = int.Parse(parts[4].Substring(0, parts[4].Length - 1))
			};
		}
	}
}
