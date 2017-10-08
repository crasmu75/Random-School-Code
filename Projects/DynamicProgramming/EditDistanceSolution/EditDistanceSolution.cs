using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    static class EditDistanceSolution
    {
        private static Random rand;

        public static void Main()
        {
            rand = new Random();
            string r = RandomString(10);
            string s = RandomString(10);
            r = "AAAAA";
            s = "A";
            var solution = DynamicMinEditDistanceSolution(r, s);
            Console.WriteLine(r);
            Console.WriteLine(s);
            Console.WriteLine(String.Join(", ", solution.ToArray()));
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
        /// Returns that list of edits that corresonds to the minimum edit distance 
        /// between r and s.
        /// </summary>
        public static List<string> DynamicMinEditDistanceSolution(string r, string s)
        {
            var cache = new Dictionary<Pair, int>();
            DynamicMinEditDistance(r, r.Length, s, s.Length, cache);
            int n = r.Length;
            int m = s.Length;
            var solution = new List<string>();
            while (n > 0 && m > 0)
            {
                if (r[n - 1] == s[m - 1])
                {
                    n--;
                    m--;
                }
                else
                {
                    int editCount = cache[new Pair(n, m)];
                    if (cache[new Pair(n - 1, m)] == editCount - 1)
                    {
                        solution.Add("D" + (n - 1));
                        n--;
                    }
                    else if (cache[new Pair(n, m - 1)] == editCount - 1)
                    {
                        solution.Add("I" + (n - 1) + s[m - 1]);
                        m--;
                    }
                    else if (cache[new Pair(n - 1, m - 1)] == editCount - 1)
                    {
                        solution.Add("R" + (n - 1) + s[m - 1]);
                        n--;
                        m--;
                    }
                }
            }

            while (n > m)
            {
                solution.Add("D" + (n - 1));
                n--;
            }

            while (m > n)
            {
                solution.Add("I" + (n - 1) + s[m - 1]);
                m--;
            }

            return solution;
        }

        /// <summary>
        /// Returns the minimum edit distance between the first n characters of r and
        /// the first m characters of s.
        /// </summary>
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
            else if (r[n - 1] == s[m - 1])
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
