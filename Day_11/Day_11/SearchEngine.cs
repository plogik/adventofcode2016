using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
	class SearchEngine
	{
		private Node root;
		private List<Node> visited = new List<Node>();

		public Node Run(IWorld world)
		{
			root = world.GetStartState();
			return Find(world.GetTargetState());
		}

		// Breadth-First-Search
		public Node Find(Node needle)
		{
			var q = new Queue<Node>();

			root.Distance = 0;
			q.Enqueue(root);

			while (q.Count != 0)
			{
				var curr = q.Dequeue();
				foreach (var n in AdjacentTo(curr))
				{
					visited.Add(n);
					n.Parent = curr;

					if (n.Distance == -1)
					{
						n.Distance = curr.Distance + 1;
						q.Enqueue(n);

						if (n.Equals(needle))
						{
							return n; // Found
						}
					}
				}
			}
			return null; // Not found
		}

		List<Node> AdjacentTo(Node currNode)
		{
			var nodes = new List<Node>();

			if(currNode.Floor < 3)
			{
				var n = AboveBelow(currNode, true, 2);
				if(n.Count > 0) nodes.AddRange(n);
				n = AboveBelow(currNode, true, 1);
				if(n.Count > 0) nodes.AddRange(n);
			}
			if(currNode.Floor > 0)
			{
				var n = AboveBelow(currNode, false, 1);
				if (n.Count > 0) nodes.AddRange(n);
				n = AboveBelow(currNode, false, 2);
				if(n.Count > 0) nodes.AddRange(n);
			}
			return nodes;
		}

		List<Node> AboveBelow(Node currNode, bool above, int moveCount)
		{
			var found = new List<Node>();
			if (moveCount == 2)
			{
				for (int i = 1; i <= 256/*Node.Item.RUG*/; i <<= 1)
				{
					for (int n = i << 1; n <= 512/*Node.Item.PLG*/; n <<= 1)
					{
						if ((i & (int)currNode.Items[currNode.Floor]) == i &&
							(n & (int)currNode.Items[currNode.Floor]) == n)
						{
							var newNode = (Node)currNode.Clone();
							newNode.Floor = above ? currNode.Floor + 1 : currNode.Floor - 1;

							newNode.Items[currNode.Floor] &= ~(i | n);
							newNode.Items[newNode.Floor] |= (i | n);

							if (IsValid(newNode, newNode.Floor) && IsValid(newNode, currNode.Floor) && !visited.Contains(newNode))
							{
								found.Add(newNode);
							}
						}
					}
				}
			}
			else
			{
				// Move *one* item up or down
				for(int i = 1; i <= 512; i <<= 1)
				{
					if((i & (int)currNode.Items[currNode.Floor]) == i)
					{
						var newNode = (Node)currNode.Clone();
						newNode.Floor = above ? currNode.Floor + 1 : currNode.Floor - 1;

						newNode.Items[currNode.Floor] &= ~i;
						newNode.Items[newNode.Floor] |= i;

						if (IsValid(newNode, newNode.Floor) && IsValid(newNode, currNode.Floor) && !visited.Contains(newNode))
						{
							found.Add(newNode);
						}
					}
				}
			}
			return found;
		}

		bool IsValid(Node node, int floor)
		{
			int gens = node.Items[floor] >> 5;
			int chips = node.Items[floor] & 31;

			return (chips & ~gens) == 0 || gens == 0;
		}
	}
}
