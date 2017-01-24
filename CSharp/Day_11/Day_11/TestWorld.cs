using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using I = Day_11.Node.Item;

namespace Day_11
{
	class TestWorld : IWorld
	{
		public Node GetStartState()
		{
			return new Node()
			{
				Items = new int[]
				{
					(int)(I.PLM | I.PRM),
					(int)I.PLG,
					(int)I.PRG,
					0
				},
				Floor = 0
			};
		}

		public Node GetTargetState()
		{
			return new Node()
			{
				Items = new int[]
				{
					0,
					0,
					0,
					(int)I.PLM | (int)I.PRM | (int)I.PLG | (int)I.PRG
				},
				Floor = 3
			};
		}
	}
}
