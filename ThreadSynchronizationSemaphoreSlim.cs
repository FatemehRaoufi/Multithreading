namespace Multithreading
{
    /// <summary>
    /// The SemaphoreSlim Class in C# is recommended for synchronization within a single app. 
    /// A lightweight semaphore controls access to a pool of resources that is local to your application. 
    /// It represents a lightweight alternative to Semaphore that limits the number of threads that can access a resource 
    /// or pool of resources concurrently.
    /// </summary>
    internal class ThreadSynchronizationSemaphoreSlim
    {
        // Create the semaphore.
        //only 3 threads can access resource simulteniously

        public ThreadSynchronizationSemaphoreSlim()
        {

        }
        #region
        //In the below example, we have created a Function called SemaphoreSlimFunction
        //which gives access to a resource,
        //the Wait method blocks the current thread until it can access the resource,
        //and the Release method is required to release a resource once work is done.
        //To understand SemaphoreSlim,
        //we created five threads inside the Main method which will try to access SemaphoreSlimFunction simultaneously
        //but we limited the access to three threads using the SemaphoreSlim object.
        public void SemaphoreSlimMethod1()
        {
            for (int i = 1; i <= 5; i++)
            {
                int count = i;
                Thread t = new Thread(() => SemaphoreSlimDemo1("Thread " + count, 1000 * count));
                t.Start();
            }
            Console.ReadLine();
        }
        static void SemaphoreSlimDemo1(string name, int seconds)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 3);
            Console.WriteLine($"{name} Waits to access resource");
            semaphore.Wait();
            Console.WriteLine($"{name} was granted access to resource");
            Thread.Sleep(seconds);
            Console.WriteLine($"{name} is completed");
            semaphore.Release();
        }
        #endregion
        //------------------------------------------------------------------
        /// <summary>
        /// In the below example, we create one SemaphoreSlim instance with a maximum count of three threads 
        /// and an initial count of zero threads. The example then starts five tasks,all of which block waiting for the semaphore. 
        /// The main thread calls the Release(Int32) overload to increase the semaphore count to its maximum, which allows three tasks to enter the semaphore. 
        /// Each time the semaphore is released, the previous semaphore count is displayed.
        /// </summary>
        public void SemaphoreSlimMethod2()
        {
            // Create the semaphore.
            int initialCount = 0;
            int maximunCount = 3;
            SemaphoreSlim semaphore = new SemaphoreSlim(initialCount, maximunCount);
            // A padding interval to make the output more orderly.
            int padding = 0;
            Console.WriteLine($"{semaphore.CurrentCount} tasks can enter the semaphore");
            Task[] tasks = new Task[5];
            // Create and start five numbered tasks.
            for (int i = 0; i <= 4; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    // Each task begins by requesting the semaphore.
                    Console.WriteLine($"Task {Task.CurrentId} begins and waits for the semaphore");
                    int semaphoreCount;
                    semaphore.Wait();
                    try
                    {
                        Interlocked.Add(ref padding, 100);
                        Console.WriteLine($"Task {Task.CurrentId} enters the semaphore");
                        // The task just sleeps for 1+ seconds.
                        Thread.Sleep(1000 + padding);
                    }
                    finally
                    {
                        semaphoreCount = semaphore.Release();
                    }
                    Console.WriteLine($"Task {Task.CurrentId} releases the semaphore; previous count: {semaphoreCount}");
                });
            }
            // Wait for one second, to allow all the tasks to start and block.
            Thread.Sleep(1000);
            // Restore the semaphore count to its maximum value.
            Console.Write("Main thread calls Release(3) --> ");
            semaphore.Release(3);
            Console.WriteLine($"{semaphore.CurrentCount} tasks can enter the semaphore");
            // Main thread waits for the tasks to complete.
            Task.WaitAll(tasks);
            Console.WriteLine("Main thread Exits");
            Console.ReadKey();
        }
    }


}

//https://dotnettutorials.net/lesson/semaphoreslim-class-in-csharp/