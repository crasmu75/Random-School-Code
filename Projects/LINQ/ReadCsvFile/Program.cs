/**
 * Program.cs
 * 4/3/2014
 * @author Camille Rasmussen
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ReadCsvFile
{
   class Program
   {
       static List<DailyValues> stockValues;
       static decimal average;

      static void Main(string[] args)
      {
         stockValues = DailyValues.GetStockValues("Toyota.csv");

         Console.WriteLine("\n= = =   Q u e s t i o n   a   = = = \n");
         questionA();

         Console.WriteLine("\n= = =   Q u e s t i o n   b   = = = \n");
         questionB();

         Console.WriteLine("\n= = =   Q u e s t i o n   c   = = = \n");
         questionC();

         Console.WriteLine("\n= = =   Q u e s t i o n   d   = = = \n");
         questionD();

         Console.WriteLine("\n= = =   Q u e s t i o n   e   = = = \n");
         questionE();

         Console.WriteLine();
      }

      #region question A - E
      // Find the highest and the lowest amount the stock ever traded for
      // and display the values together with the corresponding dates
      private static void questionA()
      {
          var highest =
              from v in stockValues
              orderby v.High descending
              select new { High = v.High, Date = v.Date };
          var lowest =
              from v in stockValues
              orderby v.Low
              select new { Low = v.Low, Date = v.Date };
          Console.WriteLine("Highest price traded: {0} on {1:yyyy/MM/dd}", highest.First().High, highest.First().Date);
          Console.WriteLine("Lowest price traded: {0} on {1:yyyy/MM/dd}", lowest.First().Low, lowest.First().Date);
      }

      // Calculate the average volume traded per day
      private static void questionB()
      {
          IEnumerable<decimal> volumes =
              from v in stockValues
              select v.Volume;
          average = volumes.Average();
          Console.WriteLine("Avg Volume traded per day: {0:0.0}", average);
      }

      // How many times was the trading volume higher than the average? How many times was it lower? 
      private static void questionC()
      {
          IEnumerable<DailyValues> higherThanAve =
             from v in stockValues
             where v.Volume > average
             select v;
          IEnumerable<DailyValues> lowerThanAve =
             from v in stockValues
             where v.Volume < average
             select v;

          Console.WriteLine("Volume > Average: {0} times", higherThanAve.Count());
          Console.WriteLine("Volume < Average: {0} times", lowerThanAve.Count());
      }

      // In descending order list the 10 highest ‘open values’ with the corresponding dates  
      private static void questionD()
      {
          var tenHighestVal =
              (from v in stockValues
              orderby v.Open descending
              select new { Value = v.Open, Date = v.Date }).Take(10);

          Console.WriteLine("10 highest opening values:");
          foreach(var thing in tenHighestVal)
          {
              Console.WriteLine("{0} {1:yyyy/MM/dd}", thing.Value, thing.Date);
          }
      }

      // Calculate the average volume traded for each of the calendar years
      private static void questionE()
      {
          var calendarYears =
             from v in stockValues
             orderby v.Date.Year
             group v by v.Date.Year into g
             select g;

          Console.WriteLine("Average Volume per calendar year: ");
          foreach (var gr in calendarYears)
          {
              var volumes =
                  from g in gr
                  select g.Volume;
              decimal avePerYears = volumes.Average();
              Console.WriteLine("{0} vol: {1:0.#}", gr.Key, avePerYears);
          }
      }
      #endregion
   }
}

