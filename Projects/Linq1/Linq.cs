using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq1
{
   class Linq
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
         Console.WriteLine("\nL I N Q   E X E R C I S E"); 
         Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
         
         Console.WriteLine("\n\n1)List majors sorted:");
         ListSortedMajors();

         Console.WriteLine("\n\n1) Graduation years of FA students:");
         ListGraudationYearOfFaStudents();

         Console.WriteLine("\n\n2) Names and graduation years of CS students:");
         ListNamesAndGraudationYearOfCsStudents();

         Console.WriteLine("\n\n3) Names of CS students who graduate after 2012:");
         ListNamesOfCsStudentsGraduatingAfter2012();

         Console.WriteLine("\n\n4) All Graduation years without duplicates:");
         ListGraduationYearsWithoutDuplicates();

         Console.WriteLine("\n\n5) Graduation years withoug duplicates in descending order:");
         ListGraduationYearsWithoutDuplicatesDescending();

         Console.WriteLine("\n\n6) Group students by year:");
         GroupStudentsByYear();

         Console.WriteLine("\n\n7) Number of students per year:");
         NumberOfStudentsPerYear();

         Console.WriteLine("\n\n. . . press enter . . .");
         Console.Read();
      }

      private static void GroupStudentsByYear()
      {
          var studentsPerYear =
              from s in students
              orderby s.Year
              group s by s.Year;

          foreach(var group in studentsPerYear)
          {
              Console.WriteLine(group.Key);
              foreach(Student element in group)//it turns nice and blue and theres no wiggly line,
              {
                  Console.WriteLine("    {0}", element);
              }
          }
      }

       private static void NumberOfStudentsPerYear()
      {
          var studentsPerYear =
             from s in students
             orderby s.Year
             group s by s.Year into g
             select new { Year = g.Key, NumberOfStudents = g.Count() };

          foreach (var group in studentsPerYear)
          {
              Console.WriteLine("{0}: number of students: {1}", group.Year, group.NumberOfStudents);
          }
      }

       private static void ListSortedMajors()
      {
          var sortedMajors =
              from s in students
              orderby s.Major
              select new { s.Name, s.Major };

          Console.WriteLine(string.Join("\n", sortedMajors));
      }
      #endregion

      #region TODO 1
      // TODO 1:	Write a query that lists the graduation years of all fine art (FA) students 
      //          then run the program to test the results
      private static void ListGraudationYearOfFaStudents()
      {
          IEnumerable<int> gradYears =
              from s in students
              //where s.Major == "FA"
              select s.Year;

          Console.WriteLine(string.Join(", ", gradYears));
          Console.WriteLine(gradYears.ElementAt(0));
      }
      #endregion

      #region TODO 2
      // TODO 2:	Write a query that lists the names and graduation years of all computer science (CS) students
      //          then run the program to test the results
      private static void ListNamesAndGraudationYearOfCsStudents()
      {
          var namesAndGradYears =
              from s in students
              where s.Major == "CS"
              select new { s.Name, s.Year };

          Console.WriteLine(string.Join("\n", namesAndGradYears));
      }
      #endregion

      #region TODO 3
      // TODO 3:	Write a query that lists the names of CS students that graduate after 2012 
      //          then run the program to test the results 
      private static void ListNamesOfCsStudentsGraduatingAfter2012()
      {
          IEnumerable<string> names =
              from s in students
              where s.Major == "CS"
              where s.Year > 2012
              select s.Name;

          Console.WriteLine(string.Join(", ", names));
      }
      #endregion

      #region TODO 4
      // TODO 4:	Write a query that lists all graduation years but no duplicates
      //          then run the program to test the results 
      private static void ListGraduationYearsWithoutDuplicates()
      {
          IEnumerable<int> gradYears =
              (from s in students
              select s.Year).Distinct();

          Console.WriteLine(string.Join(", ", gradYears));
      }
      #endregion

      #region TODO 5
      // TODO 5:	Write a query that lists all graduation years - but no duplicates - in descending order
      //          then run the program to test the results 
      private static void ListGraduationYearsWithoutDuplicatesDescending()
      {
          IEnumerable<int> gradYears =
              (from s in students
               orderby s.Year descending
               select s.Year).Distinct();

          Console.WriteLine(string.Join(", ", gradYears));
      }
      #endregion
   }
}//students.GroupBy(x => x.Major);
