using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class ThreadsPriorities
    {
        /*
         The ThreadPriority enum provides the following 5 properties:

Lowest = 0: The Thread can be scheduled after threads with any other priority. That means threads with the Lowest Priority can be scheduled after threads with any other higher priority.
BelowNormal = 1: The Thread can be scheduled after threads with Normal priority and before those with Lowest Priority. That means threads with BelowNormal priority can be scheduled after threads with Normal priority and before threads with Lowest priority.
Normal = 2: The Thread can be scheduled after threads with AboveNormal priority and before those with BelowNormal Priority. Threads have Normal priority by default. That means threads with Normal priority can be scheduled after threads with AboveNormal priority and before threads with BelowNormal and Lowest priority.
AboveNormal = 3: The Thread can be scheduled after threads with the Highest priority and before those with Normal Priority. That means threads with AboveNormal priority can be scheduled after the thread with the Highest priority and before threads with Normal, BelowNormal, and Lowest priority.
Highest = 4: The Thread can be scheduled before threads with any other priority. That means threads with the Highest Priority can be scheduled before threads with any other priority.
         
         */
        public ThreadsPriorities() 
        {
            Thread thread1 = new Thread(ThreadsPrioritiesMethod)
            {
                Name = "Thread 1"
            };
            //Setting the thread Priority as Normal
            thread1.Priority = ThreadPriority.Normal;

            Thread thread2 = new Thread(ThreadsPrioritiesMethod)
            {
                Name = "Thread 2"
            };
            //Setting the thread Priority as Lowest
            thread2.Priority = ThreadPriority.Lowest;

            Thread thread3 = new Thread(ThreadsPrioritiesMethod)
            {
                Name = "Thread 3"
            };
            //Setting the thread Priority as Highest
            thread3.Priority = ThreadPriority.Highest;

            //Getting the thread Prioroty
            Console.WriteLine($"Thread 1 Priority: {thread1.Priority}");
            Console.WriteLine($"Thread 2 Priority: {thread2.Priority}");
            Console.WriteLine($"Thread 3 Priority: {thread3.Priority}");

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.ReadKey();
        }
        public static void ThreadsPrioritiesMethod()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Thread Name: {Thread.CurrentThread.Name} Printing {i}");
            }
        }
    }
}

//https://dotnettutorials.net/lesson/threads-priorities-in-csharp/

