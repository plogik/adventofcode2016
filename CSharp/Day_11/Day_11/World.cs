using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using I = Day_11.Node.Item;

namespace Day_11
{
	class World : IWorld
	{
		public Node GetStartState()
		{
			return new Node()
			{
				Items = new int[]
				{
					(int)(I.PRG | I.PRM),
					(int)(I.COG | I.CUG | I.RUG | I.PLG),
					(int)(I.COM | I.CUM | I.RUM | I.PLM),
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
					(int)(I.PRG | I.PRM | I.COG | I.CUG | I.RUG | I.PLG | I.COM | I.CUM | I.RUM | I.PLM)
				},
				Floor = 3
			};
		}

	}
}
