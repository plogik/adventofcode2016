using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_1
{
	class Program
	{
		static void Main(string[] args)
		{
			var decoder = new KeypadDecoder();
			foreach(string sequence in File.ReadLines("Input.txt"))
			{
				decoder.Play(sequence);
				Console.Write(decoder.CurrentKey);
			}
			Console.ReadLine();
		}
	}
}
