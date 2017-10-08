using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabIterator
{
   class Temperatures
   {
      // temperatures in Celsius
      double[] temperatures = { 25, 27.5, 29.1, 28.7, 26, 24.3, 25.7 };

      // iterators
      public IEnumerator<double> GetEnumerator()
      {
         foreach (double el in temperatures)
         {
            yield return el;
         }
      }

      public IEnumerable<double> GetKelvin()
      {
          foreach (double celsius in temperatures)
          {
              yield return celsius + 273.15;
          }
      }

      public IEnumerable<double> GetFahrenheit()
      {
           foreach(double celsius in temperatures)
           {
               yield return (1.8 * celsius + 32);
           }
      }

      public IEnumerable<String> CelsiusDayByDay()
      { 
          int i = 1;
          foreach(double temp in temperatures)
          {
              yield return String.Format("Day {0}: {1}C", i, temp);
              i++;
          }
      }
   }
}
