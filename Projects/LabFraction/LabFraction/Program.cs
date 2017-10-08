using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(5, 7);

            Console.WriteLine("f1 * f2 = {0}", f1 * f2);
            Console.WriteLine("f1 * f2 = {0}", f1.Multiply(f2));
        }
    }
}
