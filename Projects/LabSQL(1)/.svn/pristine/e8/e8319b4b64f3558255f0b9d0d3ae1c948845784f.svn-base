using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Closures
{
    class Program
    {
        /// <summary>
        ///   This program shows off the idea of a closure.  
        /// 
        ///   Closures embody the idea that when a function is assigned to a thread,
        ///   ALL of the data necessary to execute the function is kept with the
        ///   function.  
        ///   
        ///    Run the Code below, then see README for some thoughts.
        /// </summary>
        /// 
        /// <author>
        ///     Joe Zachary - original
        ///     H. James de St. Germain - modified, commented, expanded
        /// </author>
        /// 
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //
            // (1) Launch 10 threads and see what happens
            //
            Console.WriteLine("Sample 1: 10 threads using closure on i as variable");
            for (int i = 0; i < 10; i++)
            {
                new Thread(() => Console.WriteLine(i)).Start();
            }
            Console.WriteLine("Done with Loop");
            Console.ReadLine();


            //
            // (2) Same as 1, but using a "separate" variable
            //
            Console.WriteLine("Sample 2: 10 threads using closure on nn:");
            int nn;
            for (int i = 0; i < 10; i++)
            {
                nn = i;
                new Thread(() => Console.WriteLine(nn)).Start();
            }
            Console.WriteLine("Done with Loop");
            Console.ReadLine();

            //
            // (3) Same as 2, but let the ThreadPool handle it
            //
            Console.WriteLine("Sample 3: 10 threads using closure on 'shared' nn and ThreadPool");
            for (int i = 0; i < 10; i++)
            {
                nn = i;
                ThreadPool.QueueUserWorkItem((x) => Console.WriteLine(nn));
            }
            Console.WriteLine("Done with Loop");
            Console.ReadLine();

            //
            // (4) Same as 1, but with "local" (to loop) variable
            //
            Console.WriteLine("Sample 4: 10 threads using closure on 'local variable' n");
            for (int i = 0; i < 10; i++)
            {
                int n = i;
                new Thread(() => Console.WriteLine(n)).Start();
            }
            Console.WriteLine("Done with Loop");
            Console.ReadLine();

            //
            // (5) Better approach using threads (see function below)
            //
            Console.WriteLine("Sample 5: Function call to create thread");
            for (int i = 0; i < 10; i++)
            {
                FireThread1(i);
            }
            Console.WriteLine("Done with Loop");
            Console.ReadLine();

            //
            // (6) Better approach using Thread Pool (see function below)
            //
            Console.WriteLine("Sample 6: Function call to use Thread Pool");
            for (int i = 0; i < 10; i++)
            {
                FireThread2(i);
            }
            Console.WriteLine("Done with Loop");
            Console.ReadLine();
        }

        /// <summary>
        /// This function creates a thread to write a number to the console.
        /// 
        /// Notice that the created closure "holds on to" the local variable i (the parameter)
        /// </summary>
        /// <param name="i"> Identifier for thread (and number printed)</param>
        private static void FireThread1(int id)
        {
            new Thread(() => Console.WriteLine(id)).Start();
        }

        /// <summary>
        /// This function creates a thread USING THE THREAD POOL to write a number to the console.
        /// 
        /// Notice that the created closure "holds on to" the local variable i (the parameter)
        /// </summary>
        /// <param name="i"> Identifier for thread (and number printed)</param>

        private static void FireThread2(int id)
        {
            ThreadPool.QueueUserWorkItem((x) => Console.WriteLine(id));
        }
    }
}
