using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21.Tests
{
	[TestFixture]
	public class DescrambleOperationTests
	{
		[Test]
		public void DescrambleOperation_Test_SwapPos_1()
		{
			var input = "adcbefgh";

			var op = Operation.CreateSwapPositions(1, 3, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefgh", result);
		}

		[Test]
		public void DescrambleOperation_Test_SwapLetter_1()
		{
			var input = "abfdecgh";

			var op = Operation.CreateSwapLetters('c', 'f', true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefgh", result);
		}

		[Test]
		public void DescrambleOperation_Test_RotateSteps_Right()
		{
			var input = "ghabcdef";

			var op = Operation.CreateRotateSteps(Operation.Direction.Right, 2, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefgh", result);
		}

		[Test]
		public void DescrambleOperation_Test_RotateSteps_Left()
		{
			var input = "cdefghab";

			var op = Operation.CreateRotateSteps(Operation.Direction.Left, 2, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefgh", result);
		}

		[Test]
		public void DescrambleOperation_Test_RotateByLetter_1()
		{
			var input = "cdefab";

			var op = Operation.CreateRotateByLetter('d', true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdef", result);
		}
		[Test]
		public void DescrambleOperation_Test_RotateByLetter_2()
		{
			var input = "cdefghab";

			var op = Operation.CreateRotateByLetter('e', true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefgh", result);
		}
		[Test]
		public void DescrambleOperation_Test_RotateByLetter_3()
		{

			var input = "jklabcdefghi";

			var op = Operation.CreateRotateByLetter('c', true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefghijkl", result);
		}

		[Test]
		public void DescrambleOperation_Test_Reverse_1()
		{
			var input = "abcgfedh";

			var op = Operation.CreateReverse(3, 6, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefgh", result);
		}
		[Test]
		public void DescrambleOperation_Test_Reverse_2()
		{
			var input = "abedcfg";

			var op = Operation.CreateReverse(2, 4, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdefg", result);
		}

		[Test]
		public void DescrambleOperation_Test_Move_1()
		{
			var input = "acbdef";

			var op = Operation.CreateMove(1, 2, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdef", result);
		}
		[Test]
		public void DescrambleOperation_Test_Move_2()
		{
			var input = "adbcef";

			var op = Operation.CreateMove(3, 1, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdef", result);
		}

		[Test]
		public void DescrambleOperation_Test_Move_3()
		{
			var input = "bcdefa";

			var op = Operation.CreateMove(0, 5, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdef", result);
		}
		[Test]
		public void DescrambleOperation_Test_Move_4()
		{
			var input = "fabcde";

			var op = Operation.CreateMove(5, 0, true);
			var result = op.Execute(input);

			Assert.AreEqual("abcdef", result);
		}
	}
}
