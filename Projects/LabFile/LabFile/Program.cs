using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LabFile
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPoem("Poem.txt");
            SavePoemWithLineNumbers();
            PrintPoem("Poem1.txt");
        }

        private static void PrintPoem(String fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Console.WriteLine(reader.ReadToEnd()); //mouse over ReadToEnd to see what exceptions might be thrown
                }
            }
            catch (Exception ex) //want to be as specific as possible
            {
                if (ex is OutOfMemoryException || ex is IOException) //in C# the is operator is like instanceOf in java
                    Console.WriteLine("ERROR: " + ex.Message);
                else
                    throw;
                //throw ex; do not do this, it throws a whole new exception and you lose your stack trace
            }
        }

        private static void SavePoemWithLineNumbers()
        {
            try
            {
                using (StreamReader reader = new StreamReader("Poem.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("Poem1.txt"))
                    {
                        string line;
                        int count = 1;
                        while((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine("{0:00} {1}", count, line);
                            count++;
                        }
                    }
                }
            }
            catch (Exception ex) //want to be as specific as possible
            {
                if (ex is OutOfMemoryException || ex is IOException) //in C# the is operator is like instanceOf in java
                    Console.WriteLine("ERROR: " + ex.Message);
                else
                    throw;
                //throw ex; do not do this, it throws a whole new exception and you lose your stack trace
            }
        }
    }
}
