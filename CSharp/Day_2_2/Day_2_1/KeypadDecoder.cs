
using System;

namespace Day_2_2
{
	public class KeypadDecoder
	{
		private int[][] keypad = new int[5][];

		public KeypadDecoder()
		{
			keypad[0] = new int[] { 0, 0, 1, 0, 0};
			keypad[1] = new int[] { 0, 2, 3, 4, 0 };
			keypad[2] = new int[] { 5, 6, 7, 8, 9 };
			keypad[3] = new int[] { 0, 0xA, 0xB, 0xC, 0 };
			keypad[4] = new int[] { 0, 0, 0xD, 0, 0 };
			
		}

		// x, y
		private int[] position = { 0, 2 };

		private void Move(char operation)
		{
			int xDelta = 
				operation == 'L' ? -1 :
				operation == 'R' ? 1 : 0;
			int yDelta =
				operation == 'U' ? -1 :
				operation == 'D' ? 1 : 0;
			if(isValidMove(xDelta, yDelta))
			{
				position[0] += xDelta;
				position[1] += yDelta;
			}
		}

		private bool isValidMove(int xDelta, int yDelta)
		{
			bool valid = true;
			int proposedXPos = position[0] + xDelta;
			int proposedYPos = position[1] + yDelta;

			valid = proposedXPos >= 0 && proposedXPos < 5 &&
				proposedYPos >= 0 && proposedYPos < 5 &&
				keypad[proposedYPos][proposedXPos] != 0;

			return valid;
		}

		public void Play(string sequence)
		{
			foreach(char c in sequence)
			{
				Move(c);
			}
		}

		public int CurrentKey
		{
			get
			{
				//return keypad[position[0], position[1]];
				return keypad [position[1]] [position[0]];
			}
		}
	}
}
