using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_1
{
	/// <summary>
	/// A1-1
	/// CS 4150 Algorithms
	/// @author Camille Rasmussen
	/// </summary>
	class Program
	{
		static SortedSet<int> balancedTree;
		static List<int> searchElements;
		public const int DURATION = 1000;

		/// <summary>
		/// Runs 11 different tests on 11 random binary search trees.
		/// The average time it takes to find a key in a particular tree is calculated and 
		/// printed out.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			for (int i = 0; i < 11; i++)
			{
				Console.WriteLine("On test {0}:", i);
				Console.WriteLine("Tree size: 2^{0}", i + 10);

				double totalTime = 0;
				GenerateRandomTree(i);
				totalTime += RunTest();
				GenerateRandomTree(i);
				totalTime += RunTest();
				GenerateRandomTree(i);
				totalTime += RunTest();
				GenerateRandomTree(i);
				totalTime += RunTest();
				GenerateRandomTree(i);
				totalTime += RunTest();

				Console.WriteLine("Took {0} milliseconds\n", totalTime / 5);
			}
		}

		/// <summary>
		/// Generates a binary tree filled with random integers, along with a List of those 
		/// integers for testing.
		/// </summary>
		/// <param name="index"></param>
		static void GenerateRandomTree(int index)
		{
			int treeSize = index + 10;
			balancedTree = new SortedSet<int>();
			searchElements = new List<int>();
			int numToAdd = 0;
			Random random = new Random();
			for (int i = 0; i < Math.Pow(2, treeSize); i++)
			{
				numToAdd = random.Next();
				while(!balancedTree.Add(numToAdd))
					numToAdd = random.Next();
				searchElements.Add(numToAdd);
			}
		}

		/// <summary>
		/// Runs the test on the binary tree.
		/// 
		/// Parts of this code was retrieved from code example done in class on 
		/// 1/14/16 by Joe Zachary
		/// </summary>
		/// <returns></returns>
		static double RunTest()
		{
			Stopwatch sw = new Stopwatch();

			// Keep increasing the number of repetitions until one second elapses.
			double elapsed = 0;
			long repetitions = 1;
			do
			{
				repetitions *= 2;
				sw.Restart();
				for (int i = 0; i < repetitions; i++)
				{
					foreach (int el in searchElements)
					{
						balancedTree.Contains(el);
					}
				}
				sw.Stop();
				elapsed = msecs(sw);
			} while (elapsed < DURATION);
			double totalAverage = elapsed / repetitions;

			// Create a stopwatch
			sw = new Stopwatch();

			// Keep increasing the number of repetitions until one second elapses.
			elapsed = 0;
			repetitions = 1;
			do
			{
				repetitions *= 2;
				sw.Restart();
				for (int i = 0; i < repetitions; i++)
				{
					foreach (int el in searchElements)
					{
						//balancedTree.Contains(el);
					}
				}
				sw.Stop();
				elapsed = msecs(sw);
			} while (elapsed < DURATION);
			double overheadAverage = elapsed / repetitions;

			// Return the difference, averaged over size
			return (totalAverage - overheadAverage) / searchElements.Count;
		}

		/// <summary>
		/// Returns the number of milliseconds that have elapsed on the Stopwatch.
		/// 
		/// Retrieved from code examples in class on 1/14/16 by Joe Zachary
		/// </summary>
		public static double msecs(Stopwatch sw)
		{
			return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
		}
	}
}
