using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
	class PQ
	{
		HashSet<int>[] items;
		Dictionary<int, int> weights;

		public PQ(int m)
		{
			items = new HashSet<int>[m + 1];
			for (int i = 0; i <= m; i++)
				items[i] = new HashSet<int>();
			weights = new Dictionary<int, int>();
		}

		public void insertOrUpdate(int item, int weight) {
  if (weights.ContainsKey(item))
    items[weights[item]].Remove(item);
  weights[item] = weight;
  items[weight].Add(item);
}
		public int DeleteMin()
		{
			for (int i = 0; i <= items.Length; i++)
			{
				HashSet<int> set = items[i];
				if (set.Count != 0)
				{
					int first = set.First();
					set.Remove(first);
					return first;
				}
			}
			throw new InvalidOperationException();
		}

	}
}
