﻿namespace Multithreading
{
    internal class ThreadSynchronizationLock1
    {
        static object lockObject = new object();
        public ThreadSynchronizationLock1()
        {
            Thread thread1 = new Thread(SomeMethod)
            {
                Name = "Thread 1"
            };
            Thread thread2 = new Thread(SomeMethod)
            {
                Name = "Thread 2"
            };
            Thread thread3 = new Thread(SomeMethod)
            {
                Name = "Thread 2"
            };
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadKey();
        }
        public static void SomeMethod()
        {
            // Locking the Shared Resource for Thread Synchronization
            lock (lockObject)
            {
                Console.Write("[Welcome To The ");
                int millisecondsTimeout = 10000;
                Thread.Sleep(millisecondsTimeout);
                Console.WriteLine("World of Dotnet!]");
            }
        }
    }
}
//https://dotnettutorials.net/lesson/thread-synchronization-in-csharp/