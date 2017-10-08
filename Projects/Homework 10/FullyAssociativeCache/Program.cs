// Author: Camille Rasmussen
// Assigment # 10 CS 3810
// December 2, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullyAssociativeCache
{
	/// <summary>
	/// Simulates hits and misses on a Fully-Associative Cache for a 900 bit
	/// cache size and user-inputted block size, number of ways, and number 
	/// of sets. 
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// Prompt user for number of rows for cache of 900 bits
			Console.Write("Enter block size in bytes: ");
			int blockSize = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of rows: ");
			int rows = Convert.ToInt32(Console.ReadLine());

			// separate 16 bit binary address into tags and offsets
			int bitsForOffset = Convert.ToInt32(Math.Ceiling(Math.Log(blockSize, 2)));
			int bitsForTag = 16 - bitsForOffset;

			// calculate bit sizes for cache rows
			int bitsForDataBlock = blockSize * 8;
			int bitsForLRU = Convert.ToInt32(Math.Ceiling(Math.Log(rows, 2)));
			int totalBits = (1 + bitsForTag + bitsForDataBlock + bitsForLRU) * rows;

			// check if these numbers will work
			if (totalBits > 900)
				Console.WriteLine("Total bits used exceeds cache capacity of 900, please try again later.");
			else
			{
				// new list for tags to keep track of least recently used
				LinkedList<int> LRU = new LinkedList<int>();

				// hit time defaults to 1
				int missTime = 18 + blockSize;

				// fill the memory addresses array and the tags array
				int[] memAddresses = {16, 20, 24, 28, 32, 36, 60, 64, 56, 60, 64, 68, 72, 
									 76, 92, 96, 100, 104, 108, 112, 136, 140};

				// show the table layout (block sizes, number of rows, etc)
				Console.WriteLine("\nFully-Associative Cache with {0} rows and {1} bytes per data block: ",
					rows, blockSize);
				Console.WriteLine("Offset address bits: {0}\n\nBits in the valid bit: 1\nBits in the tag: {1}", bitsForOffset, bitsForTag);
				Console.WriteLine("Bits in the data block: {0}\nBits for LRU: {1}\nTotal bits used: {2}\nBits remaining: {3}\n",
					bitsForDataBlock, bitsForLRU, totalBits, 900 - totalBits);

				// compute and show how long each cache miss will take
				Console.WriteLine("Hit time: 1 cycle\nMiss time: {0} cycles", missTime);

				// remember to run the loop once and then start calculating 
				// (subsequent loops)
				Console.WriteLine("\nFirst round");
				RunLoop(memAddresses, blockSize, LRU, missTime, rows);

				// when running through the loop, calculate hit or miss and then calculate
				// depending on that, how many cycles each one took
				// add them up and display ending result
				Console.WriteLine("\nSecond round");
				RunLoop(memAddresses, blockSize, LRU, missTime, rows);
			}
		}

		
		/// <summary>
		/// Run the loop to cache and calculate average CPI
		/// </summary>
		/// <param name="memAddresses"></param>
		/// <param name="blockSize"></param>
		/// <param name="LRU"></param>
		/// <param name="missTime"></param>
		/// <param name="rows"></param>
		private static void RunLoop(int[] memAddresses, int blockSize, LinkedList<int> LRU,
			int missTime, int rows)
		{
			int cycleAccessTime = 0;
			// go through each memory address
			foreach (int addr in memAddresses)
			{
				int tag = addr / blockSize;

				// if this tag is in the cache
				if (LRU.Contains(tag))
				{
					Console.WriteLine("Accessing {0}\t(tag {1}): hit", addr, tag);
					cycleAccessTime++;
					// remove it where it is (we will add it to the end later)
					LRU.Remove(tag);
				}
				// this tag is not in the cache
				else
				{
					Console.WriteLine("Accessing {0}\t(tag {1}): miss - cached", addr, tag);
					cycleAccessTime += missTime;
					// if the cache is full, remove least recently used
					if (LRU.Count == rows)
					{
						LRU.RemoveFirst();
					}
				}
				// make most recently used
				LRU.AddLast(tag);
			}
			// Calculate cycle time and average CPI
			Console.WriteLine("\nCost in cycles for this repetition: {0}", cycleAccessTime);
			double averageCPI = (double)cycleAccessTime / memAddresses.Count();
			Console.WriteLine("Average CPI: {0}\n", averageCPI);
		}
	}
}
