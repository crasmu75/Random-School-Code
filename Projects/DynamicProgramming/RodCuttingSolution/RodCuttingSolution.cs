using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class RodCuttingSolution
    {
        private static Random rand;

        public static void Main()
        {
            rand = new Random();
            int size = 10;
            int[] values = RandomArray(size + 1);
            Console.WriteLine(String.Join(", ", values)); 
            Console.WriteLine(String.Join(", ", DynamicRodProfitSolution(values).ToArray()));
        }

        private static int[] RandomArray(int size)
        {
            int[] result = new int[size];
            for (int i = 1; i < size; i++)
            {
                result[i] = 10 * i + i + (1 - rand.Next(3));
            }
            return result;
        }

        /// <summary>
        /// Returns the optimal lengths into which to cut a rod of length values.Length-1.
        /// The profit for a rod of length n is values[n].
        /// </summary>
        public static List<int> DynamicRodProfitSolution(int[] values)
        {
            var cache = new Dictionary<int, int>();
            var choices = new Dictionary<int, int>();
            DynamicRodProfitSolution(values, values.Length - 1, cache, choices);

            int n = values.Length - 1;
            var solution = new List<int>();
            while (n > 0)
            {
                solution.Add(choices[n]);
                n = n - choices[n];
            }
            return solution;
        }

        /// <summary>
        /// Returns the maximum profit possible from a rod of length n, and also
        /// stores into choices the optimal choice for each subproblem involved
        /// in the solution.
        /// </summary>
        public static int DynamicRodProfitSolution(int[] values, int n, Dictionary<int, int> cache, Dictionary<int, int> choices)
        {
            int result;
            if (cache.TryGetValue(n, out result))
            {
                return result;
            }

            int maxProfit = 0;
            int bestChoice = 0;
            for (int i = n; i > 0; i--)
            {
                int profit = values[i] + DynamicRodProfitSolution(values, n - i, cache, choices);
                if (profit >= maxProfit)
                {
                    maxProfit = Math.Max(profit, maxProfit);
                    bestChoice = i;
                }
            }
            cache[n] = maxProfit;
            choices[n] = bestChoice;
            return maxProfit;
        }

    }
}
