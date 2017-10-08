using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLinq2Grouping
{
    class Program
    {
        #region student list
        private static List<Student> students = new List<Student> {
            new Student("Don", "CS", 2015, true),
            new Student("Dan", "CS", 2012, true),
            new Student("Dee", "CS", 2013, false),
            new Student("Bob", "CJ", 2013, false),
            new Student("Ben", "CJ", 2013, true),
            new Student("Jan", "FA", 2012, true),
            new Student("Jim", "FA", 2014, false),
            new Student("Rob", "EE", 2015, true),
            new Student("Ray", "EE", 2012, true)
         };
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Console.WriteLine("\nL I N Q   E X E R C I S E Part 2:");

            Console.WriteLine("\n\n======= Group students by honor (no group name):");
            groupStudentsByHonorNoGroupName();

            Console.WriteLine("\n\n======= Group students by honor (with group name):");
            groupStudentsByHonorWithGroupName();

            Console.WriteLine("\n\n======= Group students by major:");
            groupStudentsByMajor();

            Console.WriteLine("\n\n======= Group students by first letter of major:");
            groupStudentsByFirstLetterOfMajor();

            Console.WriteLine("\n\n======= Group student names by year:");
            GroupStudentNamesByYear();

            Console.WriteLine("\n\n======= Group student names by year (ordered by year):");
            GroupStudentNamesByYearOrdered();

            Console.WriteLine("\n\n======= Number of students per year:");
            NumberOfStudentsPerYear();

            Console.WriteLine("\n\n. . . press enter . . .");
            Console.Read();
        }
        #endregion

        // Use  http://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b  as a resource

        #region groupStudentsByHonor()
        private static void groupStudentsByHonorNoGroupName()
        {
            var honorGroups =
               from s in students
               group s by s.Honor;  // no group name

            foreach (var group in honorGroups)
            {
                Console.WriteLine("Honor: {0}", group.Key);
                foreach (Student s in group)
                {
                    Console.WriteLine("   {0} ", s);
                }
                Console.WriteLine();
            }
        }

        private static void groupStudentsByHonorWithGroupName()
        {
            var honorGroups =
               from s in students
               group s by s.Honor into g  // g is the group name
               select new { Honor = g.Key, Students = g };  // descriptive names

            foreach (var group in honorGroups)
            {
                Console.WriteLine("Honor: {0}", group.Honor);
                foreach (Student s in group.Students)
                {
                    Console.WriteLine("   {0} ", s);
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region groupStudentsByMajor()
        private static void groupStudentsByMajor()
        {
            var majorGroups =
               from s in students
               group s by s.Major;  // no group name

            foreach (var group in majorGroups)
            {
                Console.WriteLine("Major: {0}", group.Key);
                foreach (Student s in group)
                {
                    Console.WriteLine("   {0} ", s);
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region groupStudentsByFirstLetterOfMajor()
        private static void groupStudentsByFirstLetterOfMajor()
        {
            var majorLetterGroups =
               from s in students
               group s by s.Major[0];  // no group name

            foreach (var group in majorLetterGroups)
            {
                Console.WriteLine("First letter of Major: {0}", group.Key);
                foreach (Student s in group)
                {
                    Console.WriteLine("   {0} ", s);
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region GroupStudentNamesByYear
        private static void GroupStudentNamesByYear()
        {
            var yearGroups =
               from s in students
               group s by s.Year;  // no group name

            foreach (var group in yearGroups)
            {
                Console.WriteLine("Year: {0}", group.Key);
                foreach (Student s in group)
                {
                    Console.WriteLine("   {0} ", s);
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region GroupStudentNamesByYearOrdered
        private static void GroupStudentNamesByYearOrdered()
        {
            var yearGroups =
               from s in students
               orderby s.Year
               group s by s.Year;  // no group name

            foreach (var group in yearGroups)
            {
                Console.WriteLine("Year: {0}", group.Key);
                foreach (Student s in group)
                {
                    Console.WriteLine("   {0} ", s);
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region NumberOfStudentsPerYear
        private static void NumberOfStudentsPerYear()
        {
            var yearGroups =
               from s in students
               group s by s.Year into g
               select new { Year = g.Key, Count = g.Count() };

            foreach (var g in yearGroups)
            {
                Console.WriteLine("Year: {0}  Number of students: {1}", g.Year, g.Count);
                Console.WriteLine();
            }
        }
        #endregion
    }
}
