using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabIterator
{
   class Program
   {
      static void Main(string[] args)
      {
         #region window size
         Console.WindowWidth = 110;
         Console.WindowHeight = 40;
         #endregion

         Temperatures temperatures = new Temperatures();

         Console.WriteLine("\nIterator:");
         foreach (double el in temperatures)
         {
            Console.Write("{0:0.0} ", el);
         }

         Console.WriteLine("\n\nGetKelvin:");
         foreach (double el in temperatures.GetKelvin())
         {
             Console.Write("{0:0.0} ", el);
         }

         Console.WriteLine("\n\nGetFahrenheit:");
         foreach(double el in temperatures.GetFahrenheit())
         {
             Console.Write("{0:0.0} ", el);
         }

         Console.WriteLine("\n\nCelciusDayByDay:");
         foreach(String el in temperatures.CelsiusDayByDay())
         {
             Console.Write("{0}; ", el);
         }

         // complete the test code 

         Console.WriteLine("\n");  
      }
   }
}
