using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsQ7_4
{
	class Program
	{
		static void Main(string[] args)
		{
			PQ pq = new PQ(5);

			pq.insertOrUpdate(8, 5);
			pq.insertOrUpdate(9, 3);

			Console.WriteLine(pq.deleteMin());
			Console.WriteLine(pq.deleteMin());

			pq.insertOrUpdate(48, 4);
			pq.insertOrUpdate(3, 0);
			pq.insertOrUpdate(55, 0);

			Console.WriteLine(pq.deleteMin());
			Console.WriteLine(pq.deleteMin());
			Console.WriteLine(pq.deleteMin());
		}
	}
}
