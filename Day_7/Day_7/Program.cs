using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_7
{
	class Program
	{
		static void Main(string[] args)
		{
			int validCount = 0;
			int validSSLCount = 0;
			foreach(var line in File.ReadAllLines("input.txt"))
			{
				var parser = new TLSParser(line);
				if (parser.IsValidTLS())
				{
					validCount++;
				}
				if(parser.IsValidSSL())
				{
					validSSLCount++;
				}

			}
			Console.WriteLine("Valid TLS count:" + validCount);
			Console.WriteLine("Valid SSL count:" + validSSLCount);

			Console.ReadLine();
			
		}
	}
}
