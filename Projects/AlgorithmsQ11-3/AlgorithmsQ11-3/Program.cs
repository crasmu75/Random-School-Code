using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsQ11_3
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[] hotel = { 0, 350, 500, 900, 1300, 1800};
			//Console.Out.Write("Smallest Penalty to your Father: ${0}\n", MinimumPenalty(hotel, 1));
			TimeD();
		}

		public static int MinimumPenalty(int[] hotel, int i)
		{
			double p;
			int minCost = Int32.MaxValue;

			if (i == hotel.Length - 1)
				return 0;

			for(int j = i+1; j < hotel.Length; j++)
			{
				p = hotel[j] - hotel[i];
				int cost = Convert.ToInt32(Math.Pow((400 - p), 2)) +  MinimumPenalty(hotel, j);
				minCost = Math.Min(cost, minCost);
			}

			return minCost;
		}

		public static int MinimumPenalty(int[] hotel)
		{
			return MinimumPenalty(hotel, 0);
		}

		public static int DynamicMinimumPenalty(int[] hotel, int i, Dictionary<int, int> cache)
		{
			double p;
			int minCost;
			if(cache.ContainsKey(i))
				return cache[i];
			else
				minCost = Int32.MaxValue;

			if (i == hotel.Length - 1)
				return 0;

			for (int j = i + 1; j < hotel.Length; j++)
			{
				p = hotel[j] - hotel[i];
				//Console.WriteLine("P: {0}", p);
				int cost = Convert.ToInt32(Math.Pow((400 - p), 2)) + DynamicMinimumPenalty(hotel, j, cache);
				minCost = Math.Min(cost, minCost);
			}

			cache[i] = minCost;
			return minCost;
		}

		public static void Time()
		{
			
			Stopwatch timer = new Stopwatch();
			TimeSpan ts = timer.Elapsed;

			int i = 1;

			while(ts.Seconds < 2.00)
			{
				i++;
				int[] hotel = new int[i];
				hotel[0] = 0;
				for (int j = 1; j < i; j++)
				{
					hotel[j] = hotel[j - 1] + 400;
				}

				timer.Reset();
				timer.Start();
				MinimumPenalty(hotel);
				timer.Stop();
				ts = timer.Elapsed;
				Console.WriteLine("Seconds: {0}", ts.Seconds);

			}

			Console.WriteLine("Size: {0}", i);
		}

		public static int DynamicMinimumPenalty(int[] hotel)
		{
			Dictionary<int, int> cache = new Dictionary<int,int>();
			return DynamicMinimumPenalty(hotel, 0, cache);
		}

		public static void TimeD()
		{
			
			Stopwatch timer = new Stopwatch();
			TimeSpan ts = timer.Elapsed;

			int i = 5000;

			while(ts.Seconds < 2.00)
			{
				i+=10;
				int[] hotel = new int[i];
				hotel[0] = 0;
				for (int j = 1; j < i; j++)
				{
					hotel[j] = hotel[j - 1] + 2;
				}

				timer.Reset();
				timer.Start();
				DynamicMinimumPenalty(hotel);
				timer.Stop();
				ts = timer.Elapsed;
				Console.WriteLine("Seconds: {0}", ts.Milliseconds);

			}

			Console.WriteLine("Size: {0}", i);
		}
	}
}
