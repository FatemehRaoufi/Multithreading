using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Monitor1
    {
        private static readonly object lockPrintNumbers = new object();
        /// <summary>
        /// According to Microsoft, the Monitor Class in C# Provides a mechanism that synchronizes access to objects. 
        /// Let us simplify the above definition. In simple words, we can say that, like the lock, 
        /// we can also use this Monitor Class to protect the shared resources in a multi-threaded environment from concurrent access. 
        /// This can be done by acquiring an exclusive lock on the object so that only one thread can enter the critical section at any given point in time.
        /// </summary>
        public Monitor1()
        {
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(PrintNumbers)
                {
                    Name = "Child Thread " + i
                };
            }
            foreach (Thread t in Threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }
        
        public static void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section");

            try
            {
                Monitor.Enter(lockPrintNumbers);
                Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                int millisecondsTimeout = 100;
                
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(millisecondsTimeout);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(lockPrintNumbers);
                Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
            }
        }
    }
}
