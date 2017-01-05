using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
	public class OperationParser
	{
		public static Operation Parse(string strOp, bool descramble = false)
		{
			if(strOp.StartsWith("swap position"))
			{
				int pos1 = int.Parse(strOp.Substring("swap position ".Length, 1));
				int pos2 = int.Parse(strOp.Substring("swap position x with position ".Length, 1));
				return Operation.CreateSwapPositions(pos1, pos2, descramble);
			}
			else if(strOp.StartsWith("swap letter"))
			{
				char letter1 = strOp.Substring("swap letter ".Length, 1)[0];
				char letter2 = strOp.Substring("swap letter f with letter ".Length, 1)[0];
				return Operation.CreateSwapLetters(letter1, letter2, descramble);
			}
			else if (strOp.StartsWith("rotate right"))
			{
				var direction = Operation.Direction.Right;
				int steps = int.Parse(strOp.Substring("rotate right ".Length, 1));
				return Operation.CreateRotateSteps(direction, steps, descramble);
			}
			else if (strOp.StartsWith("rotate left"))
			{
				var direction = Operation.Direction.Left;
				int steps = int.Parse(strOp.Substring("rotate left ".Length, 1));
				return Operation.CreateRotateSteps(direction, steps, descramble);
			}
			else if (strOp.StartsWith("rotate based on position of letter"))
			{
				char letter = strOp.Substring("rotate based on position of letter ".Length, 1)[0];
				return Operation.CreateRotateByLetter(letter, descramble);
			}
			else if (strOp.StartsWith("reverse positions"))
			{
				int pos1 = int.Parse(strOp.Substring("reverse positions ".Length, 1));
				int pos2 = int.Parse(strOp.Substring("reverse positions 1 through ".Length, 1));
				return Operation.CreateReverse(pos1, pos2, descramble);
			}
			else if (strOp.StartsWith("move position"))
			{
				int pos1 = int.Parse(strOp.Substring("move position ".Length, 1));
				int pos2 = int.Parse(strOp.Substring("move position 1 to position ".Length, 1));
				return Operation.CreateMove(pos1, pos2, descramble);
			}
			throw new NotSupportedException("Unkown operation:" + strOp);
		}
	}
}
