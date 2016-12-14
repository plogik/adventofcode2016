
using System;

namespace Day_2_1
{
	public class KeypadDecoder
	{
		private int[,] keypad = {
			{ 1, 2, 3 },
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};

		// x, y
		private int[] position = { 1, 1 };

		private void Move(char operation)
		{
			switch(operation)
			{
				case 'U':
					position = new int[] 
					{
						position[0] - 1,
						position[1]
					};
					break;
				case 'D':
					position = new int[]
					{
						position[0] + 1,
						position[1]
					};
					break;
				case 'L':
					position = new int[]
					{
						position[0],
						position[1] - 1
					};
					break;
				case 'R':
					position = new int[]
					{
						position[0],
						position[1] + 1
					};
					break;
			}
			BoxPosition();
		}

		private void BoxPosition()
		{
			position = new int[] {
				Math.Min(2, Math.Max(0, position[0])),
				Math.Min(2, Math.Max(0, position[1]))
			};
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
				return keypad[position[0], position[1]];
			}
		}
	}
}
