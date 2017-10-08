using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFraction
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction Multiply(Fraction other)
        {
            int newNumer = this.numerator * other.numerator;
            int newDenom = this.denominator * other.denominator;

            return new Fraction(newNumer, newDenom);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return f1.Multiply((f2));
        }

        public override String ToString()
        {
            return this.numerator + "/" + this.denominator;
        }
    }
}
