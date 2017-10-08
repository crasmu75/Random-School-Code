using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabLinq2Grouping
{
    public class Student
    {
        public string Name { get; set; }
        public string Major { get; set; }
        public int Year { get; set; }
        public bool Honor { get; set; }

        public Student(string n, string m, int y, bool h)
        {
            Name = n;
            Major = m;
            Year = y;
            Honor = h;
        }

        public override string ToString()
        {
            return string.Format("{0}{1} ({2}) .. {3}", Honor ? "*" : " ", Name, Year, Major);
        }
    }

}
