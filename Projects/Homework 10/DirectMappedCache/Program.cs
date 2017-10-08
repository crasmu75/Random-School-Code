// Author: Camille Rasmussen
// Assigment # 10 CS 3810
// December 2, 2014

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectMappedCache
{
	/// <summary>
	/// Simulates hits and misses on a Direct-Mapped Cache for a 900 bit
	/// cache size and user-inputted block size, number of ways, and number 
	/// of sets. 
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// prompt user for number of rows for cache of 900 bits
			// instantiate the tags array with as many spots as there are rows
			Console.Write("Enter block size in bytes: ");
			int blockSize = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of rows: ");
			int rows = Convert.ToInt32(Console.ReadLine());
			int[] tags = new int[rows];

			// separate 16 bit binary address into tags, (row numbers), and offsets
			int bitsForOffset = Convert.ToInt32(Math.Ceiling(Math.Log(blockSize, 2)));
			int bitsForIndex = Convert.ToInt32(Math.Ceiling(Math.Log(rows, 2)));
			int bitsForTag = 16 - (bitsForOffset + bitsForIndex);

			// calculate bit sizes for cache rows
			int bitsForDataBlock = blockSize * 8;
			int totalBits = (1 + bitsForTag + bitsForDataBlock) * rows;

			// check if these numbers will work
			if (totalBits > 900)
				Console.WriteLine("Total bits used exceeds cache capacity of 900, please try again later.");
			else
			{
				// fill the memory addresses array
				int[] memAddresses = {16, 20, 24, 28, 32, 36, 60, 64, 56, 60, 64, 68, 72, 
									 76, 92, 96, 100, 104, 108, 112, 136, 140};

				// hit time defaults to 1
				int missTime = 18 + blockSize;

				// show the table layout (block sizes, number of rows, etc)
				Console.WriteLine("\nDirect-Mapped Cache with {0} rows and {1} bytes per data block: ",
					rows, blockSize);
				Console.WriteLine("Offset address bits: {0}\nRow address bits: {1}\n\nBits in the valid bit: 1\nBits in the tag: {2}", bitsForOffset, bitsForIndex, bitsForTag);
				Console.WriteLine("Bits in the data block: {0}\nTotal bits used: {1}\nBits remaining: {2}\n",
					bitsForDataBlock, totalBits, 900 - totalBits);

				// compute and show how long each cache miss will take
				Console.WriteLine("Hit time: 1 cycle\nMiss time: {0} cycles", missTime);

				// invalidate all tags 
				for (int i = 0; i < tags.Length; i++)
				{
					tags[i] = -1;
				}

				// remember to run the loop once and then start calculating 
				// (subsequent loops)
				Console.WriteLine("\nFirst round");
				RunLoop(memAddresses, blockSize, rows, missTime, tags);

				// when running through the loop, calculate hit or miss and then calculate
				// depending on that, how many cycles each one took
				// add them up and display ending result
				Console.WriteLine("\nSecond round");
				RunLoop(memAddresses, blockSize, rows, missTime, tags);
			}
		}

		/// <summary>
		/// Run the loop to cache and calculate average CPI
		/// </summary>
		/// <param name="memAddresses"></param>
		/// <param name="blockSize"></param>
		/// <param name="rows"></param>
		/// <param name="missTime"></param>
		/// <param name="tags"></param>
		private static void RunLoop(int[] memAddresses, int blockSize, int rows, 
			int missTime, int[] tags)
		{
			Console.WriteLine("\nSecond round");
			int cycleAccessTime = 0;
			// go through each memory address
			foreach (int addr in memAddresses)
			{
				int row = (addr / blockSize) % rows;
				int tag = addr / (blockSize * rows);

				// if this tag is in the cache
				if (tags[row] == tag)
				{
					Console.WriteLine("Accessing {0}\t(tag {1}): hit from\t\t row {2}", addr, tag, row);
					cycleAccessTime++;
				}
				// this tag is not in the cache
				else
				{
					Console.WriteLine("Accessing {0}\t(tag {1}): miss - cached to\t row {2}", addr, tag, row);
					cycleAccessTime += missTime;
					// add it to the cache
					tags[row] = tag;
				}
			}
			// Calculate cycle time and average CPI
			Console.WriteLine("\nCost in cycles for this repetition: {0}", cycleAccessTime);
			double averageCPI = (double)cycleAccessTime / memAddresses.Count();
			Console.WriteLine("Average CPI: {0}\n", averageCPI);
		}
	}
}
