using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
	public class OutputRepository
	{
		private Dictionary<int, Stack<int>> outputs = new Dictionary<int, Stack<int>>();

		public void Add(int binNo, int value)
		{
			Stack<int> bin;
			if(!outputs.ContainsKey(binNo))
			{
				bin = new Stack<int>();
				outputs[binNo] = bin;
			}
			else
			{
				bin = outputs[binNo];
			}
			bin.Push(value);
		}

		public Stack<int> this[int binNo, bool create = true]
		{
			get
			{
				if(!outputs.ContainsKey(binNo) && create)
				{
					outputs[binNo] = new Stack<int>();
				}
				return outputs[binNo];
			}
		}
	}
}
