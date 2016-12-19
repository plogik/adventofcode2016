using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10.Tests
{
	[TestFixture]
	class OutputRepositoryTests
	{
		[Test]
		public void OutputRepos_Test_1()
		{
			var repos = new OutputRepository();
			repos.Add(1, 1);
			repos.Add(2, 1);
			repos.Add(1, 2);

			Assert.AreEqual(2, repos[1].Count);
		}

		[Test]
		public void OutputRepos_Test_output_0()
		{
			var repos = new OutputRepository();
			var bin = repos[0];
			bin.Push(5);
			var sum = repos[0].Sum();

			Assert.AreEqual(5, sum);
		}
	}
}
