using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
	public class DescramblerOperation : Operation
	{
		public DescramblerOperation() { }

		protected override string SwapPositions(char[] input)
		{
			char tmp = input[pos1];
			input[pos1] = input[pos2];
			input[pos2] = tmp;
			return new string(input);
		}
		protected override string SwapLetters(char[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == letter1)
					pos1 = i;
				if (input[i] == letter2)
					pos2 = i;
			}
			return SwapPositions(input);
		}
		protected override string RotateSteps(char[] input)
		{
			if (input.Length < 2)
				return new string(input);

			var result = (char[])input.Clone();
			var tmp = (char[])result.Clone();
			for (int n = 0; n < steps; n++)
			{

				for (int i = 0; i < input.Length; i++)
				{
					if (Dir == Direction.Left)
						result[(i + 1) % result.Length] = tmp[i];
					else
						result[i] = tmp[(i + 1) % result.Length];
				}
				tmp = (char[])result.Clone();
			}
			return new string(result);
		}
		protected override string RotateByLetter(char[] input)
		{
			var leftStep = new Operation() { Op = Type.RotateSteps, Dir = Direction.Left, Steps = 1 };
			var letterRotate = new Operation() { Op = Type.RotateByLetter, Letter1 = letter1 };

			var strInput = new string(input);
			var leftStepResult = strInput;
			var letterRotResult = letterRotate.Execute(leftStepResult);
			var skippedPos0Once = false;
			while (!strInput.Equals(letterRotResult))
			{
				leftStepResult = leftStep.Execute(leftStepResult);
				if (leftStepResult.IndexOf(letter1) == 0 && !skippedPos0Once)
				{
					// If we get here twice, the only possible solution is that the letter is at pos 0
					// So i'm guessing that is correct then. UPDATE: It was!
					skippedPos0Once = true;
					continue;
				}
				letterRotResult = letterRotate.Execute(leftStepResult);
			}
			return leftStepResult;
		}
		protected override string Reverse(char[] input)
		{
			for (int i = 0; i <= (pos2 - pos1) / 2; i++)
			{
				var tmp = input[pos1 + i];
				input[pos1 + i] = input[pos2 - i];
				input[pos2 - i] = tmp;
			}
			return new string(input);
		}
		protected override string Move(char[] input)
		{
			// Yes i'm lazy
			var removed = input[pos2];
			var result = new string(input).Remove(pos2, 1);
			result = result.Insert(pos1, new string(new char[] { removed }));

			return result;
		}
	}
}
