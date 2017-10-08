using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<int> numberList = new int[] { 0, 1, 3, 5, 7, 6, 6, 4, 4, 2, 2 };
            Console.WriteLine("Sum: {0}", numberList.Sum());
            Console.WriteLine("Number of numbers: {0}", numberList.Count());
            Console.WriteLine("Average: {0}", numberList.Average());
            Console.WriteLine("Largest of first four: {0}", numberList.Take(4).Max());
            IEnumerable<int> lastFour = numberList.Skip(numberList.Count-4).Take(4);
            Console.Write("Last four: ");
            foreach (int num in lastFour)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.WriteLine("Last of first four: {0}", numberList.Take(4).Last());
            Console.WriteLine("Smallest of last four: {0}", lastFour.Min());
        }
    }
}
