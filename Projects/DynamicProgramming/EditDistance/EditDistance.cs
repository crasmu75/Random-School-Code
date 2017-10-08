using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DynamicProgramming
{
    static class EditDistance
    {
        private static Random rand;
        private static int seed;

        public static void Main()
        {
            seed = new Random().Next();
            Time(n => 7 + n, MinEditDistance);
            Console.WriteLine();
            Time(n => 7 << n, DynamicMinEditDistance);
        }

        public static void Time(Func<int, int> Size, Func<string, string, int> MinEditMethod)
        {
            rand = new Random(seed);
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < 9; i++)
            {
                int size = Size(i);
                string r = RandomString(size);
                string s = RandomString(size);
                long previousTicks = timer.ElapsedTicks;
                timer.Reset();
                timer.Start();
                int distance = MinEditMethod(r, s);
                timer.Stop();
                Console.WriteLine(String.Format("Size = {0}, distance = {1}, {2}",
                    size,
                    distance,
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

        private static string RandomString(int size)
        {
            String s = "";
            for (int i = 0; i < size; i++)
            {
                s += (char)('A' + rand.Next(4));
            }
            return s;
        }

        /// <summary>
        /// Returns the minimum edit distance between r and s.
        /// </summary>
        public static int MinEditDistance(string r, string s)
        {
            return MinEditDistance(r, r.Length, s, s.Length);
        }

        /// <summary>
        /// Returns the minimum edit distance between the first n characters of r and 
        /// the first m characters of s.
        /// </summary>
        public static int MinEditDistance(string r, int n, string s, int m)
        {
            if (n == 0)
            {
                return m;
            }
            else if (m == 0)
            {
                return n;
            }
            else if (r[n-1] == s[m-1])
            {
                return MinEditDistance(r, n - 1, s, m - 1);
            }
            else
            {
                return
                   1 + Min(MinEditDistance(r, n - 1, s, m),
                           MinEditDistance(r, n, s, m - 1),
                           MinEditDistance(r, n - 1, s, m - 1));
            }
        }

        public static int DynamicMinEditDistance(string r, string s)
        {
            return DynamicMinEditDistance(r, r.Length, s, s.Length, new Dictionary<Pair, int>());
        }

        public static int DynamicMinEditDistance(string r, int n, string s, int m, Dictionary<Pair, int> cache)
        {
            Pair p = new Pair(n, m);
            int result;
            if (cache.TryGetValue(p, out result))
            {
                return result;
            }

            if (n == 0)
            {
                cache[p] = m;
            }
            else if (m == 0)
            {
                cache[p] = n;
            }
            else if (r[n-1] == s[m-1])
            {
                cache[p] = DynamicMinEditDistance(r, n - 1, s, m - 1, cache);
            }
            else
            {
                cache[p] = 1 + Min(DynamicMinEditDistance(r, n - 1, s, m, cache),
                                   DynamicMinEditDistance(r, n, s, m - 1, cache),
                                   DynamicMinEditDistance(r, n - 1, s, m - 1, cache));
            }
            return cache[p];
        }

        public static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
