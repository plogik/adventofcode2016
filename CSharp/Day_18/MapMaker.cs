using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_18
{
	public class MapMaker
	{
		public static char[] NextRow(char[] row)
		{
			var newRow = new char[row.Length];
			bool leftTrap, centerTrap, rightTrap;

			for(int i = 0; i < row.Length; i++)
			{
				leftTrap = i != 0 && row[i - 1] == '^';
				centerTrap = row[i] == '^';
				rightTrap = i != row.Length - 1 && row[i + 1] == '^';

				bool isTrap = (leftTrap && centerTrap && !rightTrap) ||
					(!leftTrap && centerTrap && rightTrap) ||
					(leftTrap && !centerTrap && !rightTrap) ||
					(!leftTrap && !centerTrap && rightTrap);

				newRow[i] = isTrap ? '^' : '.';
			}
			return newRow;
		}

		public static char[][] MakeMap(char[] firstRow, int rowCount)
		{
			var map = new char[rowCount][];

			map[0] = firstRow;

			for(int i = 1; i < rowCount; i++)
			{
				map[i] = NextRow(map[i - 1]);
			}
			return map;
		}
	}
}
