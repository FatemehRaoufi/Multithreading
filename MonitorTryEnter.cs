using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class MonitorTryEnter
    {
        private static readonly object lockPrintNumbers = new object();
        /// <summary>
        /// TryEnter(Object, TimeSpan, Boolean) Method of Monitor Class:
        /// attempts, for a specified amount of time, to acquire an exclusive lock on the specified object, 
        /// and automatically sets a value that indicates whether the lock was taken or not. 
        /// </summary>
        public MonitorTryEnter() 
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
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            bool lockTaken = false;

            try
            {
                Console.WriteLine(Thread.CurrentThread.Name + "Trying to enter into the critical section");
                Monitor.TryEnter(lockPrintNumbers, timeout, ref lockTaken);
                int millisecondsTimeout = 100;
                if (lockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "Entered into the critical section");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(millisecondsTimeout);
                        Console.Write(i + ",");
                    }
                    Console.WriteLine();
                }
                else
                {
                    // The lock was not acquired.
                    Console.WriteLine(Thread.CurrentThread.Name + "Lock was not acquired");
                }
            }
            finally
            {
                // To Ensure that the lock is released.
                if (lockTaken)
                {
                    Monitor.Exit(lockPrintNumbers);
                    Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
                }
            }
        }

    }
}
//https://dotnettutorials.net/lesson/multithreading-using-monitor/
