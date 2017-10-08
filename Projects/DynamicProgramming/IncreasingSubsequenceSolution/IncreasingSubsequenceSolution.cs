using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DynamicProgrammingSolution
{
    class IncreasingSubsequence
    {
        private static Random rand;

        public static void Main()
        {
            rand = new Random();
            var A = RandomArray(10, 20);
            var solution = DynamicLongestSSSolution(A);
            Console.WriteLine(String.Join(", ", A));
            Console.WriteLine (String.Join(", ", solution.ToArray()));
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
        /// Returns the longest increasing subsequence in A.
        /// </summary>
        public static List<int> DynamicLongestSSSolution(int[] A)
        {
            var cache = new Dictionary<int, int>();
            var choices = new Dictionary<int, int>();
            int maxLength = 0;
            int bestStart = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int length = DynamicLongestSSSolution(A, i, cache, choices);
                if (length > maxLength)
                {
                    bestStart = i;
                    maxLength = length;
                }
            }

            var solution = new List<int>();
            do
            {
                solution.Add(A[bestStart]);
                bestStart = choices[bestStart];
            }
            while (bestStart > 0);
            return solution;
        }

        /// <summary>
        /// Returns the length of the longest increasing subsequence beginning at i, and also
        /// stores into choices the index of the next element in the longest increasing subsequence
        /// beginning at each index that is considered.
        /// </summary>
        public static int DynamicLongestSSSolution(int[] A, int i, Dictionary<int,int> cache, Dictionary<int,int> choices)
        {
            int result;
            if (cache.TryGetValue(i, out result))
            {
                return result;
            }

            int maxLength = 0;
            int bestChoice = 0;

            for (int j = i + 1; j < A.Length; j++)
            {
                if (A[i] < A[j])
                {
                    int length = DynamicLongestSSSolution(A, j, cache, choices);
                    if (length > maxLength)
                    {
                        bestChoice = j;
                        maxLength = length;
                    }
                }
            }
            cache[i] = maxLength + 1;
            choices[i] = bestChoice;
            return maxLength + 1;
        }
    }
}
