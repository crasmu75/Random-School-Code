using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionPropertiesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Method1();
            }
            catch(Exception e)
            {
                Console.WriteLine("\nException's toString - \n{0}", e.ToString());
                Console.WriteLine("\n\nMessage of Exception: \n{0}", e.Message);
                Console.WriteLine("\nStack trace of Exception: \n{0}", e.StackTrace);
                Console.WriteLine("\n\nMessage of Inner Exception: \n{0}", e.InnerException.Message);
                Console.WriteLine("\nStack trace of Inner Exception: \n{0}", e.InnerException.StackTrace);
                Console.WriteLine("\n\nMessage of Inner Exception of Inner Exception: \n{0}", e.InnerException.InnerException.Message);
                Console.WriteLine("\nStack trace of Inner Exception of Inner Exception: \n{0}", e.InnerException.InnerException.StackTrace);
            }
        }

        private static void Method1()
        {
            try
            {
                Console.WriteLine("In Method1: calling Method2");
                Method2();
            }
            catch(Exception e)
            {
                Console.WriteLine("In Method1 re-throwing the exception");
                throw new Exception("Rethrowing exception in Method1", e);
            }
        }

        private static void Method2()
        {
            Method3();
        }

        private static void Method3()
        {
            try
            {
                Console.WriteLine("In Method3 tying to convert a string to an integer");
                Convert.ToInt32("I am not a number");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("In Method3 re-throwing the exception");
                throw new Exception("Problem converting a string to an integer.", ex);
            }
        }
        
    }
}
