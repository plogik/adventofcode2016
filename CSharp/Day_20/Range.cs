using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20
{
	public class Range : IComparable<Range>
	{
		public Range(long lower, long upper)
		{
			Lower = lower;
			Upper = upper;
		}

		public long Lower
		{
			set;
			get;
		}

		public long Upper
		{
			get;
			set;
		}

		public bool Overlaps(Range other)
		{
			return (other.Lower <= Upper && other.Lower >= Lower) ||
				(other.Upper >= Lower && other.Upper <= Upper);
		}

		public bool Adjacent(Range other)
		{
			return (other.Lower < Lower && other.Upper == (Lower + 1)) ||
				other.Upper > Upper && other.Lower == (Upper + 1);
		}

		// Expands this range to accomodate the widest combination of this and other's bounds
		public void Merge(Range other)
		{
			Lower = Lower < other.Lower ? Lower : other.Lower;
			Upper = Upper > other.Upper ? Upper : other.Upper;
		}

		public override int GetHashCode()
		{
			var result = 17;
			result = result * 31 + (int)Lower;
			result = result * 31 + (int)Upper;
			return result;
		}

		public override bool Equals(object obj)
		{
			return obj is Range &&
				((Range)obj).Lower == Lower &&
				((Range)obj).Upper == Upper;
		}

		public override string ToString()
		{
			return String.Format("{{{0}, {1}}}", Lower, Upper);
		}

		public int CompareTo(Range other)
		{
			return Lower.CompareTo(other.Lower);
		}
	}
}
