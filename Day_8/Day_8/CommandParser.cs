using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
	public class CommandParser
	{
		public static void PerformOp(Display display, string strCmd)
		{
			if(strCmd.StartsWith("rect"))
			{
				var operands = strCmd.Split(' ')[1].Split('x');
				display.OpRect(int.Parse(operands[0]), int.Parse(operands[1]));
			}
			else if(strCmd.StartsWith("rotate row"))
			{
				strCmd = strCmd.Replace(" by ", "x");
				strCmd = strCmd.Substring(13);
				var operands = strCmd.Split('x');
				display.OpRotateRow(int.Parse(operands[0]), int.Parse(operands[1]));
			}
			else if(strCmd.StartsWith("rotate column"))
			{
				strCmd = strCmd.Replace(" by ", "x");
				strCmd = strCmd.Substring(16);
				var operands = strCmd.Split('x');
				display.OpRotateColumn(int.Parse(operands[0]), int.Parse(operands[1]));
			}
		}
	}
}
