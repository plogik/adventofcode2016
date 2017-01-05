using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21.Tests
{
	[TestFixture]
    public class OperationParserTest
    {
		[Test]
		public void OperationParser_Test_SwapPos_1()
		{
			var input = "swap position 5 with position 6";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(Operation.Type.SwapPositions, op.Op);
		}
		[Test]
		public void OperationParser_Test_SwapPos_2()
		{
			var input = "swap position 5 with position 6";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(5, op.Pos1);
		}
		[Test]
		public void OperationParser_Test_SwapPos_3()
		{
			var input = "swap position 5 with position 6";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(6, op.Pos2);
		}

		[Test]
		public void OperationParser_Test_SwapLetter_1()
		{
			var input = "swap letter f with letter h";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(Operation.Type.SwapLetters, op.Op);
		}
		[Test]
		public void OperationParser_Test_SwapLetter_2()
		{
			var input = "swap letter f with letter h";

			var op = OperationParser.Parse(input);

			Assert.AreEqual('f', op.Letter1);
		}
		[Test]
		public void OperationParser_Test_SwapLetter_3()
		{
			var input = "swap letter f with letter h";

			var op = OperationParser.Parse(input);

			Assert.AreEqual('h', op.Letter2);
		}

		[Test]
		public void OperationParser_Test_RotateByLetter_1()
		{
			var input = "rotate based on position of letter c";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(Operation.Type.RotateByLetter, op.Op);
		}
		[Test]
		public void OperationParser_Test_RotateByLetter_2()
		{
			var input = "rotate based on position of letter c";

			var op = OperationParser.Parse(input);

			Assert.AreEqual('c', op.Letter1);
		}

		[Test]
		public void OperationParser_Test_RotateSteps_1()
		{
			var input = "rotate right 7 steps";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(Operation.Type.RotateSteps, op.Op);
		}
		[Test]
		public void OperationParser_Test_RotateSteps_2()
		{
			var input = "rotate right 7 steps";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(Operation.Direction.Right, op.Dir);
		}
		[Test]
		public void OperationParser_Test_RotateSteps_3()
		{
			var input = "rotate right 7 steps";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(7, op.Steps);
		}

		[Test]
		public void OperationParser_Test_Reverse_1()
		{
			var input = "reverse positions 0 through 4";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(Operation.Type.Reverse, op.Op);
		}
		[Test]
		public void OperationParser_Test_Reverse_2()
		{
			var input = "reverse positions 0 through 4";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(0, op.Pos1);
		}
		[Test]
		public void OperationParser_Test_Reverse_3()
		{
			var input = "reverse positions 0 through 4";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(4, op.Pos2);
		}

		[Test]
		public void OperationParser_Test_Move_1()
		{
			var input = "move position 1 to position 0";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(Operation.Type.Move, op.Op);
		}
		[Test]
		public void OperationParser_Test_Move_2()
		{
			var input = "move position 1 to position 0";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(1, op.Pos1);
		}
		[Test]
		public void OperationParser_Test_Move_3()
		{
			var input = "move position 1 to position 0";

			var op = OperationParser.Parse(input);

			Assert.AreEqual(0, op.Pos2);
		}
	}
}
