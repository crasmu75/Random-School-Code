using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DynamicProgramming
{
    class IncreasingSubsequence
    {
        private static Random rand;
        private static int seed;

        public static void Main()
        {
            seed = new Random().Next();
            Time(n => 100 + n, LongestSS);
            Console.WriteLine();
            Time(n => 100 << n, DynamicLongestSS);
        }

        public static void Time(Func<int, int> Size, Func<int[], int> LongestSSMethod)
        {
            rand = new Random(seed);
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < 9; i++)
            {
                int size = Size(i);
                int[] values = RandomArray(size, 10 * size);
                long previousTicks = timer.ElapsedTicks;
                timer.Reset();
                timer.Start();
                int longest = LongestSSMethod(values);
                timer.Stop();
                Console.WriteLine(String.Format("Size = {0}, length = {1}, {2}",
                    size,
                    longest,
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
        /// Returns the length of the longest increasing subsequence in A.
        /// </summary>
        public static int LongestSS (int[] A)
        {
            int maxLength = 0;
            for (int i = 0; i < A.Length; i++)
            {
                maxLength = Math.Max(maxLength, LongestSS(A, i));
            }
            return maxLength;
        }

        /// <summary>
        /// Returns the length of the longest increasing subsequence in A 
        /// that begins at index i.
        /// </summary>
        public static int LongestSS(int[] A, int i)
        {
            int maxLength = 0;
            for (int j = i + 1; j < A.Length; j++)
            {
                if (A[i] < A[j])
                {
                    maxLength = Math.Max(maxLength, LongestSS(A, j));
                }
            }
            return maxLength + 1;
        }

        public static int DynamicLongestSS(int[] A)
        {
            var cache = new Dictionary<int, int>();
            int maxLength = 0;
            for (int i = 0; i < A.Length; i++)
            {
                maxLength = Math.Max(maxLength, DynamicLongestSS(A, i, cache));
            }
            return maxLength;
        }

        public static int DynamicLongestSS(int[] A, int i, Dictionary<int,int> cache)
        {
            int result;
            if (cache.TryGetValue(i, out result))
            {
                return result;
            }

            int maxLength = 0;
            for (int j = i + 1; j < A.Length; j++)
            {
                if (A[i] < A[j])
                {
                    maxLength = Math.Max(maxLength, DynamicLongestSS(A, j, cache));
                }
            }
            cache[i] = maxLength + 1;
            return maxLength + 1;
        }
    }
}
