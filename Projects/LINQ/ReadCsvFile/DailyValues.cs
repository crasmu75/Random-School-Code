/**
 * DailyValues.cs
 * 3/4/2014
 * @author Camille Rasmussen
 **/

using System;
using System.IO;
using System.Collections.Generic;

namespace ReadCsvFile
{
    struct DailyValues
    {
        public DateTime Date { get; private set; }
        public decimal Open { get; private set; }
        public decimal High { get; private set; }
        public decimal Low { get; private set; }
        public decimal Close { get; private set; }
        public decimal Volume { get; private set; }
        public decimal AdjClose { get; private set; }

        public DailyValues(DateTime date, decimal open, decimal high, decimal low, 
            decimal close, decimal volume, decimal adjClose) : this()
        {            
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            AdjClose = adjClose;
        }

        public override string ToString()
        {
           return string.Format("O:{0} / H:{1} / L:{2} / C:{3} / V:{4} / AC:{5} / {6:d}",
                   Open, High, Low, Close, Volume, AdjClose, Date);
        }

        // reads stock values from csv file into a List
        public static List<DailyValues> GetStockValues(string filePath)
        {
           List<DailyValues> values = new List<DailyValues>();

           // TODO: add the data from the csv file
           try
           {
               var reader = new StreamReader(File.OpenRead(filePath));
               string line;
               int count = 0;
               while ((line = reader.ReadLine()) != null)
               {
                    if(count != 0)
                    {
                        values.Add(CreateNewDailyValues(line.Split(',')));
                    }
                    count++;
               }
               
           }
           catch (Exception ex)
           {
               if (ex is OutOfMemoryException || ex is IOException)
                   Console.WriteLine("ERROR: " + ex.Message);
               else
                   throw;
           }
          
           return values;
        }

        public static DailyValues CreateNewDailyValues(string[] theValues)
        {
            DailyValues newValue = new DailyValues(Convert.ToDateTime(theValues[0]), Convert.ToDecimal(theValues[1]), 
                Convert.ToDecimal(theValues[2]), Convert.ToDecimal(theValues[3]), Convert.ToDecimal(theValues[4]), 
                Convert.ToDecimal(theValues[5]), Convert.ToDecimal(theValues[6]));
            return newValue;
        }
    }
}
