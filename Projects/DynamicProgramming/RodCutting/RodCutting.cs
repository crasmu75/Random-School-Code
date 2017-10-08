using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DynamicProgramming
{
    class RodCutting
    {
        private static Random rand;

        public static void Main()
        {
            Time(n => 20 + n, RodProfit);
            Console.WriteLine();
            Time(n => 20 << n, (s, f) => DynamicRodProfit(s, f, new Dictionary<int, int>()));
        }

        public static void Time(Func<int, int> Size, Func<int[], int, int> RodMethod)
        {
            rand = new Random(0);
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < 9; i++)
            {
                int size = Size(i);
                int[] values = RandomArray(size + 1, 10 * size);
                values[0] = 0;
                long previousTicks = timer.ElapsedTicks;
                timer.Reset();
                timer.Start();
                int profit = RodMethod(values, values.Length - 1);
                timer.Stop();
                Console.WriteLine(String.Format("Size = {0}, profit = {1}, {2}",
                    size,
                    profit,
                    TimeReport(timer, previousTicks)));
            }
        }

        public static string TimeReport(Stopwatch timer, long previousTicks)
        {
            double elapsedTime = (1.0 * timer.ElapsedTicks) / Stopwatch.Frequency;
            double previousTime = (1.0 * previousTicks) / Stopwatch.Frequency;
            string ratio = (previousTime == 0) ? "" : (elapsedTime / previousTime).ToString("F2");
            return String.Format("elapsed = {0} sec, ratio = {1}", elapsedTime.ToString("E2"), ratio);
        }

        private static int[] RandomArray(int size, int maxValue)
        {
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = rand.Next(maxValue) + 1;
            }
            return result;
        }

        /// <summary>
        /// Returns the maximum profit that can be made by cutting up and selling pieces of a rod
        /// of length values.Length-1.  The selling price of a rod of length m is values[m].
        /// </summary>
        public static int RodProfit(int[] values)
        {
            return RodProfit(values, values.Length - 1);
        }

        /// <summary>
        /// Returns the maximum profit that can be made by cutting up and selling pieces of a rod
        /// of length n.  The selling price of a rod of length m is values[m].
        /// </summary>
        public static int RodProfit(int[] values, int n)
        {
            int maxProfit = 0;
            for (int i = n; i > 0; i--)
            {
                int profit = values[i] + RodProfit(values, n - i);
                maxProfit = Math.Max(profit, maxProfit);
            }
            return maxProfit;
        }

        public static int DynamicRodProfit(int[] values)
        {
            return DynamicRodProfit(values, values.Length - 1, new Dictionary<int, int>());
        }

        public static int DynamicRodProfit(int[] values, int n, Dictionary<int, int> cache)
        {
            int result;
            if (cache.TryGetValue(n, out result))
            {
                return result;
            }

            int maxProfit = 0;
            for (int i = n; i > 0; i--)
            {
                int profit = values[i] + DynamicRodProfit(values, n - i, cache);
                maxProfit = Math.Max(profit, maxProfit);
            }
            cache[n] = maxProfit;
            return maxProfit;
        }

    }
}
