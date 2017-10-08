using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace DelegateDemo
{
   #region Conversion delegate
   #endregion

   class Program
   {
      static void Main(string[] args)
      {
         List<double> data = new List<double> { 2, 4, 6, 8, 10 };

         #region TODO a) create ConversionDelegate
          delegate myConversionDelegate;
         #endregion

         #region TODO b) create instance of ConversionDelegate and assign InchToCm; invoke delegate
         #endregion

         #region TODO b.1) implement ConvertList
         #endregion

         #region TODO b.2) convert list then call DisplayList
         #endregion
         
         #region TODO c) repeat for InchToM
         myConversionDelegate = LengthConverter.InchToM;
         DisplayList(ConvertList(data, myConversionDelegate), "Converted Data:");
         #endregion

         #region TODO c) What about FeetToInch? (adapter method, anonymous method)
         DisplayList(ConvertList(data, d => LengthConverter.FeetToInch((int)Math.Round(d)), "Converted Data: ");
         #endregion

         Console.WriteLine("\n");
      }

       private static double FeetToInchAdapter(double d)
      {
          return LengthConverter.FeetToInch((int)Math.Round(d), int.MaxValue);
      }

      #region private methods Part2
      private static void DisplayList<T>(List<T> list, string title)
      {
         Console.Write("{0}: ", title);
         foreach (T el in list)
            Console.Write("{0} ", el);
         Console.WriteLine();
      }

      #region private List<double> ConvertList(List<double> data, ConversionDelegate convert)
       #endregion
      #endregion
   }
}
