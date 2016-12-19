using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
	public class Bot
	{
		public const int NotSet = -1;

		private int[] values = { NotSet, NotSet };

		public void AddValue(int value)
		{
			if (values.Where(x => x == value).Count() == 0)
			{
				int count = ValueCount;
				if (count > 1)
					throw new InvalidOperationException("A bot can hold maximum 2 values");
				values[count] = value;
			}
		}

		public int Id
		{
			get;
			set;
		}

		public int HighValue
		{
			get
			{
				return values.Max();
			}
		}

		public int LowValue
		{
			get
			{
				return values.Min();
			}
		}

		public int ValueCount
		{
			get
			{
				return values.Where(x => x != NotSet).Count();
			}
		}

		public void Clear()
		{
			values = new int[] { NotSet, NotSet };
		}

		public override bool Equals(object obj)
		{
			return obj is Bot &&
				((Bot)obj).Id == Id;
		}

		public override int GetHashCode()
		{
			return Id;
		}
	}
}
