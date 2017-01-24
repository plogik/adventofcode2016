using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
	public class Display
	{
		//private int rowCount;
		//private int columnCount;

		private bool[,] pixels;

		public Display(int rows, int columns)
		{
			pixels = new bool[rows, columns];
		}

		// rect AxB turns on all of the pixels in a rectangle at 
		// the top-left of the screen which is A wide and B tall.
		public void OpRect(int cols, int rows)
		{
			for(int col = 0; col < cols; col++)
			{
				for(int row = 0; row < rows; row++)
				{
					pixels[row, col] = true;
				}
			}
		}

		//rotate row y=A by B shifts all of the pixels in row A 
		// (0 is the top row) right by B pixels. Pixels that would 
		// fall off the right end appear at the left end of the row
		public void OpRotateRow(int row, int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				for (int column = pixels.GetLength(1) - 1; column > 0; column--)
				{
					var tmp = pixels[row, column];
					pixels[row, column] = pixels[row, (column + 1) % pixels.GetLength(1)];
					pixels[row, (column + 1) % pixels.GetLength(1)] = tmp;
				}
			}
		}

		//rotate column x=A by B shifts all of the pixels in column A
		// (0 is the left column) down by B pixels. Pixels that would 
		// fall off the bottom appear at the top of the column.
		public void OpRotateColumn(int column, int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				for (int row = pixels.GetLength(0) - 1; row > 0; row--)
				{
					var tmp = pixels[row, column];
					pixels[row, column] = pixels[(row + 1) % pixels.GetLength(0), column];
					pixels[(row + 1) % pixels.GetLength(0), column] = tmp;
				}
			}
		}

		public int PixelOnCount
		{
			get
			{
				int count = 0;
				foreach (var pixel in pixels)
				{
					if (pixel)
						count++;
				}
				return count;
			}
		}

		public override string ToString()
		{
			var buf = new StringBuilder();
			for (int i = 0; i < pixels.GetLength(0); i++)
			{
				for (int j = 0; j < pixels.GetLength(1); j++)
				{
					buf.Append(pixels[i, j] ? '#' : '.');
				}
				buf.Append(Environment.NewLine);
			}
			return buf.ToString();
		}
	}
}
