using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
	public class Node : ICloneable
	{
		[Flags]
		public enum Item
		{
			/* Chips */
			PRM = 1, COM = 2, CUM = 4, RUM = 8, PLM = 16,
			/* Generators */
			PRG = 32, COG = 64, CUG = 128, RUG = 256, PLG = 512
		};

		public Node()
		{
			Distance = -1;
		}
		public Node Parent
		{
			get;
			set;
		}
		public int[] Items
		{
			get;
			set;
		}
		public int Floor
		{
			get;
			set;
		}
		public int Distance
		{
			get;
			set;
		}

		public override bool Equals(object obj)
		{ 
			// Assumes 4 floors
			return obj is Node &&
				((Node)obj).Items[0] == Items[0] &&
				((Node)obj).Items[1] == Items[1] &&
				((Node)obj).Items[2] == Items[2] &&
				((Node)obj).Items[3] == Items[3] &&
				((Node)obj).Floor == Floor;
		}

		public override int GetHashCode()
		{
			int hash = Floor;
			foreach(var items in Items)
			{
				hash |= items;
			}
			return hash;
		}

		public override string ToString()
		{
			var buf = new StringBuilder().Append("E:").Append(Floor).Append(' ');
			
			for(int floor = 0; floor < Items.Length; floor++)
			{
				buf.Append('F').Append(floor).Append(':');

				buf.Append((Node.Item)Items[floor]);
				buf.Append(' ');
			}
			return buf.ToString();
		}

		public object Clone()
		{
			var n = new Node();
			n.Floor = Floor;
			n.Items = new int[Items.Length];
			for(int floor = 0; floor < Items.Length; floor++)
			{
				n.Items[floor] = Items[floor];
			}
			return n;
		}
	}
}
