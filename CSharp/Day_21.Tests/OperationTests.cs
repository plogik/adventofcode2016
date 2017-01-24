using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21.Tests
{
	[TestFixture]
	public class OperationTests
	{
		[Test]
		public void Operation_Test_SwapPos_1()
		{
			var input = "abcdefgh";

			var op = Operation.CreateSwapPositions(1, 3);
			var result = op.Execute(input);

			Assert.AreEqual("adcbefgh", result);
		}

		[Test]
		public void Operation_Test_SwapLetter_1()
		{
			var input = "abcdefgh";

			var op = Operation.CreateSwapLetters('c', 'f');
			var result = op.Execute(input);

			Assert.AreEqual("abfdecgh", result);
		}

		[Test]
		public void Operation_Test_RotateSteps_Right()
		{
			var input = "abcdefgh";

			var op = Operation.CreateRotateSteps(Operation.Direction.Right, 2);
			var result = op.Execute(input);

			Assert.AreEqual("ghabcdef", result);
		}

		[Test]
		public void Operation_Test_RotateSteps_Left()
		{
			var input = "abcdefgh";

			var op = Operation.CreateRotateSteps(Operation.Direction.Left, 2);
			var result = op.Execute(input);

			Assert.AreEqual("cdefghab", result);
		}

		[Test]
		public void Operation_Test_RotateByLetter_1()
		{
			var input = "abcdef";

			var op = Operation.CreateRotateByLetter('d');
			var result = op.Execute(input);

			Assert.AreEqual("cdefab", result);
		}

		[Test]
		public void Operation_Test_RotateByLetter_2()
		{
			var input = "abcdefgh";

			var op = Operation.CreateRotateByLetter('e');
			var result = op.Execute(input);

			Assert.AreEqual("cdefghab", result);
		}

		[Test]
		public void Operation_Test_Reverse_1()
		{
			var input = "abcdefgh";

			var op = Operation.CreateReverse(3, 6);
			var result = op.Execute(input);

			Assert.AreEqual("abcgfedh", result);
		}
		[Test]
		public void Operation_Test_Reverse_2()
		{
			var input = "abcdefg";

			var op = Operation.CreateReverse(2, 4);
			var result = op.Execute(input);

			Assert.AreEqual("abedcfg", result);
		}

		[Test]
		public void Operation_Test_Move_1()
		{
			var input = "abcdef";

			var op = Operation.CreateMove(1, 2);
			var result = op.Execute(input);

			Assert.AreEqual("acbdef", result);
		}
		[Test]
		public void Operation_Test_Move_2()
		{
			var input = "abcdef";

			var op = Operation.CreateMove(2, 1);
			var result = op.Execute(input);

			Assert.AreEqual("acbdef", result);
		}

		[Test]
		public void Operation_Test_Move_3()
		{
			var input = "abcdef";

			var op = Operation.CreateMove(0, 5);
			var result = op.Execute(input);

			Assert.AreEqual("bcdefa", result);
		}
		[Test]
		public void Operation_Test_Move_4()
		{
			var input = "abcdef";

			var op = Operation.CreateMove(5, 0);
			var result = op.Execute(input);

			Assert.AreEqual("fabcde", result);
		}
	}
}
