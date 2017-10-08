using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateDemo
{
    public static class LengthConverter
    {
        // inch to cm
        public static double InchToCm(double d)
        {
            return d * 2.54;
        }

        // inch to m
        public static double InchToM(double d)
        {
            return d * 0.0254;
        }

        // feet to inch
        public static double FeetToInch(int i, int max)
        {
            if (i > max)
                throw new ArgumentException();
            return i * 12;
        }
    }
}
