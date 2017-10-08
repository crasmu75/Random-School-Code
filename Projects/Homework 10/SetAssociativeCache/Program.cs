// Author: Camille Rasmussen
// Assigment # 10 CS 3810
// December 2, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetAssociativeCache
{
	/// <summary>
	/// Simulates hits and misses on a Set-Associative Cache for a 900 bit
	/// cache size and user-inputted block size, number of ways, and number 
	/// of sets. 
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// prompt user for block size, number of ways and sets of those ways
			Console.Write("Enter block size in bytes: ");
			int blockSize = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of ways: ");
			int nWays = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of sets: ");
			int nSets = Convert.ToInt32(Console.ReadLine());

			// separate 16 bit binary address into tag, set, and offset
			int bitsForSet = Convert.ToInt32(Math.Ceiling(Math.Log(nSets, 2)));
			int bitsForOffset = Convert.ToInt32(Math.Ceiling(Math.Log(blockSize, 2)));
			int bitsForTag = 16 - bitsForOffset;

			// calculate bit sizes for the cache ways
			int bitsForDataBlock = blockSize * 8;
			int bitsForLRU = Convert.ToInt32(Math.Ceiling(Math.Log(nWays, 2)));
			int bitsPerWay = (1 + bitsForTag + bitsForDataBlock + bitsForLRU); // add the 1 bit for valid bit
			int totalBits = bitsPerWay * nWays * nSets;

			// check if these numbers will work
			if (totalBits > 900)
				Console.WriteLine("Total bits used exceeds cache capacity of 900, please try again later.");
			else
			{
				// new array of LinkedLists that hold the LRU(tags)
				LinkedList<int>[] sets = new LinkedList<int>[nSets];
				// populate this array with new LinkedLists
				for (int i = 0; i < sets.Length; i++)
				{
					// new list for LRU(tags) to keep track of least recently used
					sets[i] = new LinkedList<int>();
				}

				// hit time defaults to 1
				int missTime = 18 + blockSize;

				// fill the memory addresses array
				int[] memAddresses = {16, 20, 24, 28, 32, 36, 60, 64, 56, 60, 64, 68, 72, 
									 76, 92, 96, 100, 104, 108, 112, 136, 140};

				// show the table layout (block sizes, number of rows, etc)
				Console.WriteLine("\nSet-Associative Cache with {0} sets of {1} ways and {2} bytes per data block: ",
					nSets, nWays, blockSize);
				Console.WriteLine("Offset address bits: {0}\nSet address bits: {1}\n\nBits in the valid bit: 1\nBits in the tag: {2}",
					bitsForOffset, bitsForSet, bitsForTag);
				Console.WriteLine("Bits in the data block: {0}\nTotal bits used: {1}\nBits remaining: {2}\n",
					bitsForDataBlock, totalBits, 900 - totalBits);

				// compute and show how long each cache miss will take
				Console.WriteLine("Hit time: 1 cycle\nMiss time: {0} cycles", missTime);

				// remember to run the loop once and then start calculating 
				// (subsequent loops)
				Console.WriteLine("\nFirst round");
				RunLoop(memAddresses, missTime, nSets, blockSize, nWays, sets);

				// when running through the loop, calculate hit or miss and then calculate
				// depending on that, how many cycles each one took
				// add them up and display ending result
				Console.WriteLine("\nSecond round");
				RunLoop(memAddresses, missTime, nSets, blockSize, nWays, sets);
			}
		}

		
		/// <summary>
		/// Run the loop to cache and calculate average CPI
		/// </summary>
		/// <param name="addresses"></param>
		/// <param name="missTime"></param>
		/// <param name="nSets"></param>
		/// <param name="blockSize"></param>
		/// <param name="nWays"></param>
		/// <param name="sets"></param>
		private static void RunLoop(int[] addresses, int missTime,
			int nSets, int blockSize, int nWays, LinkedList<int>[] sets)
		{
			int cycleAccessTime = 0;
			// go through each memory address
			foreach (int addr in addresses)
			{
				int set = (addr / blockSize) % nSets;
				int tag = addr / blockSize;
				LinkedList<int> LRU = sets[set];

				// if this tag is in the cache
				if (LRU.Contains(tag))
				{
					Console.WriteLine("Accessing {0}\t(tag {1}): hit from\t\t set {2}",
						addr, tag, set + 1);
					cycleAccessTime++;
					// remove it where it is (we will add it to the end later)
					LRU.Remove(tag);
				}
				// this tag is not in the cache
				else
				{
					Console.WriteLine("Accessing {0}\t(tag {1}): miss - cached to\t set {2}",
						addr, tag, set + 1);
					cycleAccessTime += missTime;
					// if the cache is full, remove least recently used
					if (LRU.Count == nWays)
					{
						LRU.RemoveFirst();
					}
				}
				// make most recently used
				LRU.AddLast(tag);
			}
			// Calculate cycles and average CPI
			Console.WriteLine("\nCost in cycles for this repetition: {0}", cycleAccessTime);
			double averageCPI = (double)cycleAccessTime / addresses.Count();
			Console.WriteLine("Average CPI: {0}\n", averageCPI);
		}
	}
}
