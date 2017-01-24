using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_16
{
	public class Calculator
	{
		private byte[] startData;

		public Calculator(byte[] startData)
		{
			this.startData = startData;
		}

		public void GenerateData(int len)
		{
			var data = startData;

			while(data.Length < len)
			{
				var tmp = (byte[])data.Clone();
				Array.Reverse(tmp);
				for (int i = 0; i < tmp.Length; i++)
				{
					tmp[i] = (byte)(tmp[i] == 0 ? 1 : 0);
				}
				data = data.Concat(new byte[] { 0 }).ToArray();
				data = data.Concat(tmp).ToArray();
			}
			Data = data.Take(len).ToArray();
		}

		public byte[] CalculateChecksum()
		{
			var checksum = new List<byte>((byte[])Data.Clone());
			do
			{
				// Use previous checksum as input
				var data = checksum.ToArray();
				// Clear previous checksum
				checksum = new List<byte>();
				for (int i = 0; i < data.Length - 1; i += 2)
				{
					checksum.Add((byte)(data[i] == data[i + 1] ? 1 : 0));
				}
			} while (checksum.Count() % 2 == 0);

			return checksum.ToArray();
		}

		public byte[] Data
		{
			get;
			set;
		}
	}
}
