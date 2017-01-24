using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
	public class Operation
	{
		public enum Direction { Left, Right }
		public enum Type { SwapPositions, SwapLetters, RotateSteps, RotateByLetter, Reverse, Move }

		protected Direction direction;
		protected Type type;
		protected int pos1, pos2, steps;
		protected char letter1, letter2;

		public static Operation CreateSwapPositions(int pos1, int pos2, bool descramble = false)
		{
			return descramble ? 
				new DescramblerOperation() { type = Type.SwapPositions, pos1 = pos1, pos2 = pos2 } :
				new Operation() { type = Type.SwapPositions, pos1 = pos1, pos2 = pos2 };
		}

		public static Operation CreateSwapLetters(char letter1, char letter2, bool descramble = false)
		{
			return descramble ?
				new DescramblerOperation() { type = Type.SwapLetters, letter1 = letter1, letter2 = letter2 }:
				new Operation() { type = Type.SwapLetters, letter1 = letter1, letter2 = letter2 };
		}

		public static Operation CreateRotateSteps(Direction direction, int steps, bool descramble = false)
		{
			return descramble ?
				new DescramblerOperation() { type = Type.RotateSteps, direction = direction, steps = steps }:
				new Operation() { type = Type.RotateSteps, direction = direction, steps = steps };
		}

		public static Operation CreateRotateByLetter(char letter, bool descramble = false)
		{
			return descramble ?
				new DescramblerOperation() { type = Type.RotateByLetter, letter1 = letter } :
				new Operation() { type = Type.RotateByLetter, letter1 = letter };
		}

		public static Operation CreateReverse(int pos1, int pos2, bool descramble = false)
		{
			return descramble ?
				new DescramblerOperation() { type = Type.Reverse, pos1 = pos1, pos2 = pos2 } :
				new Operation() { type = Type.Reverse, pos1 = pos1, pos2 = pos2 };
		}

		public static Operation CreateMove(int pos1, int pos2, bool descramble = false)
		{
			return descramble ?
				new DescramblerOperation() { type = Type.Move, pos1 = pos1, pos2 = pos2 }:
				new Operation() { type = Type.Move, pos1 = pos1, pos2 = pos2 };
		}

		public string Execute(string input)
		{
			switch(type)
			{
				case Type.SwapPositions:
					return SwapPositions(input.ToCharArray());
				case Type.SwapLetters:
					return SwapLetters(input.ToCharArray());
				case Type.RotateSteps:
					return RotateSteps(input.ToCharArray());
				case Type.RotateByLetter:
					return RotateByLetter(input.ToCharArray());
				case Type.Reverse:
					return Reverse(input.ToCharArray());
				case Type.Move:
					return Move(input.ToCharArray());
			}
			return null;
		}

		public Direction Dir
		{
			set
			{
				direction = value;
			}
			get
			{
				return direction;
			}
		}

		public Type Op
		{
			set
			{
				type = value;
			}
			get
			{
				return type;
			}
		}

		public int Pos1
		{
			get
			{
				return pos1;
			}
		}

		public int Pos2
		{
			get
			{
				return pos2;
			}
		}

		public int Steps
		{
			set
			{
				steps = value;
			}
			get
			{
				return steps;
			}
		}

		public char Letter1
		{
			set
			{
				letter1 = value;
			}
			get
			{
				return letter1;
			}
		}

		public char Letter2
		{
			get
			{
				return letter2;
			}
		}

		protected virtual string SwapPositions(char[] input)
		{
			char tmp = input[pos1];
			input[pos1] = input[pos2];
			input[pos2] = tmp;
			return new string(input);
		}
		protected virtual string SwapLetters(char[] input)
		{
			for(int i = 0; i < input.Length; i++)
			{
				if (input[i] == letter1)
					pos1 = i;
				if (input[i] == letter2)
					pos2 = i;
			}
			return SwapPositions(input);
		}
		protected virtual string RotateSteps(char[] input)
		{
			if (input.Length < 2)
				return new string(input);

			var result = (char[])input.Clone();
			var inCpy = (char[])result.Clone();
			for (int n = 0; n < steps; n++)
			{

				for (int i = 0; i < result.Length; i++)
				{
					if(direction == Direction.Right)
						result[(i + 1) % result.Length] = inCpy[i];
					else
						result[i] = inCpy[(i + 1) % result.Length];
				}
				inCpy = (char[])result.Clone();
			}
			return new string(result);
		}
		protected virtual string RotateByLetter(char[] input)
		{
			for(int i = 0; i < input.Length; i++)
			{
				if(input[i] == letter1)
				{
					steps = i;
					break;
				}
			}
			direction = Direction.Right;
			if (steps > 3)
				steps++;
			steps++;

			return RotateSteps(input);
		}
		protected virtual string Reverse(char[] input)
		{
			for (int i = 0; i <= (pos2 - pos1) / 2; i++)
			{
				var tmp = input[pos1 + i];
				input[pos1 + i] = input[pos2 - i];
				input[pos2 - i] = tmp;
			}
			return new string(input);
		}
		protected virtual string Move(char[] input)
		{
			// Yes i'm lazy
			var removed = input[pos1];
			var result = new string(input).Remove(pos1, 1);
			result = result.Insert(pos2, new string(new char[]{ removed }));

			return result;
		}
	}
}
