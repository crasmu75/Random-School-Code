using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsQ7_4
{
	class PQ
	{
		private HashSet<int>[] items;
		private Dictionary<int, int> weights;

		public PQ(int m)
		{
			items = new HashSet<int>[m+1];
			weights = new Dictionary<int, int>();

			for(int i = 0; i <= m; i++)
			{
				items[i] = new HashSet<int>();
			}
		}

		public void insertOrUpdate(int item, int weight)
		{
			int oldWeight;

			if (weights.ContainsKey(item))
			{
				oldWeight = weights[item];
				weights[item] = weight;
				items[oldWeight].Remove(item);
			}
			else
				weights.Add(item, weight);

			items[weight].Add(item);

			
		}

		public int deleteMin()
		{
			if(items.Length > 0)
				for (int i = 0; i < items.Length; i++)
				{
					if (items[i].Count != 0)
					{
						int j = items[i].First();
						items[i].Remove(j);
						weights.Remove(j);
						return j;
					}
				}

			throw new System.Exception("No items in priority queue.");
		}
	}
}
