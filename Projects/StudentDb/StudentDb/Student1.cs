using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDb
{
    public partial class Student
    {
        public override string ToString()
        {
            return String.Format("{0,-9}   {1,-9}   {2,-9}{3,-9}{4,-9}   {5,-9}", 
                FirstName, LastName, Gpa, GraduationYear, PhoneNumber, Email);
        }
    }
}
