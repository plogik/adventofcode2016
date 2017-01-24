using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
	public class RepeaterDescrambler
	{
		private string[] messages;
		private string descrambled;

		public RepeaterDescrambler(string[] messages)
		{
			this.messages = messages;
		}

		public void DescramblePt1()
		{
			int columnCount = messages[0].Length;
			var buf = new StringBuilder();
			for(int i = 0; i < columnCount; i++)
			{
				buf.Append(MostCommonInPosition(i));
			}
			descrambled = buf.ToString();
		}

		public void DescramblePt2()
		{
			int columnCount = messages[0].Length;
			var buf = new StringBuilder();
			for (int i = 0; i < columnCount; i++)
			{
				buf.Append(LeastCommonInPosition(i));
			}
			descrambled = buf.ToString();
		}

		public string Descrambled
		{
			get
			{
				return descrambled;
			}
		}

		private char MostCommonInPosition(int pos)
		{
			return (from m in messages
						  group m[pos] by m[pos] into g
						  select new
						  {
							  m = g.Key,
							  count = g.Count()
						  }).OrderByDescending(m => m.count).First().m;

		}

		private char LeastCommonInPosition(int pos)
		{
			return (from m in messages
					group m[pos] by m[pos] into g
					select new
					{
						m = g.Key,
						count = g.Count()
					}).OrderBy(m => m.count).First().m;

		}
	}
}
