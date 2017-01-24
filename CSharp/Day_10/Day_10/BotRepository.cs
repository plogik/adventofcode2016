using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
	public class BotRepository : IEnumerable<Bot>
	{
		private List<Bot> bots = new List<Bot>();

		public Bot this[int id, bool create = true]
		{
			get
			{
				var b = bots.FirstOrDefault(x => x.Id == id);
				if (b == null && create)
				{
					b = new Bot();
					bots.Add(b);
				}
				b.Id = id;
				return b;
			}
		}

		public void Add(Bot bot)
		{
			var b = bots.FirstOrDefault(x => x.Id == bot.Id);
			if (b != null)
			{
				bots.Remove(b);
			}
			bots.Add(bot);
		}

		public IEnumerator<Bot> GetEnumerator()
		{
			return bots.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return bots.GetEnumerator();
		}

		public int Count
		{
			get
			{
				return bots.Count;
			}
		}
	}
}
