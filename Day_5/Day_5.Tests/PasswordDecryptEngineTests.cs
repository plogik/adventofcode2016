using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5.Tests
{
	[TestFixture]
    public class PasswordDecryptEngineTests
    {
		[Test]
		public void Engine_Pt1_Scenario1()
		{
			var input = "abc";

			var pwd = PasswordDecryptEngine.GetPwd(input);

			Assert.AreEqual("18f47a30", pwd);
		}

		[Test]
		public void Engine_Pt2_Scenario1()
		{
			var input = "abc";

			var pwd = PasswordDecryptEngine.GetPt2Pwd(input);

			Assert.AreEqual("05ace8e3", pwd);
		}
	}
}
