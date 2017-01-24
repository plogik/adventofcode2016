using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
	class Scrambler
	{
		private string seed;
		private string password;

		public Scrambler(string seed)
		{
			this.seed = seed;
		}

		public void Scramble(string[] strOperations)
		{
			password = String.Copy(seed);
			foreach(var op in strOperations)
			{
				password = OperationParser.Parse(op).Execute(password);
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
		} 
	}
}
