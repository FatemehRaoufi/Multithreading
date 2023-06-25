using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Monitor2
    {
        private static readonly object lockPrintNumberst = new object();
        /// <summary>
        /// The following example shows how to use Enter(lockObject, ref IslockTaken) method of the Monitor class in C#. 
        /// The following example is the same as the previous example except here we are using the overloaded version of the Enter method 
        /// which takes two parameters. 
        /// The second boolean parameter specifies whether the thread acquires a lock or not, 
        /// true indicates that it acquires a lock on the object 
        /// and false indicates that it does not acquire a lock on the object 
        /// and again in the finally block we are checking the boolean value and accordingly we are releasing the lock. 
        /// </summary>
        public Monitor2()
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
            Console.WriteLine(Thread.CurrentThread.Name + "Trying to enter into the critical section");
            bool IsLockTaken = false;

            try
            {
                Monitor.Enter(lockPrintNumberst, ref IsLockTaken);
                int millisecondsTimeout = 100;

                if (IsLockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "Entered into the critical section");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(millisecondsTimeout);
                        Console.Write(i + ",");
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                if (IsLockTaken)
                {
                    Monitor.Exit(lockPrintNumberst);
                    Console.WriteLine(Thread.CurrentThread.Name + "Exit from critical section");
                }
            }
        }


    }
}
