namespace Multithreading
{
    /// <summary>
    /// Foreground threads:
    /// Foreground threads are those threads that keep running even after the main application exits or quits. 
    /// That means if the Main thread leaves the application, then still the foreground threads are running to complete their assigned task. 
    /// So, the foreground threads in C# do not care whether the main thread is alive or not, it completes only when it finishes its assigned work. 
    /// That means the life of a foreground thread in C# does not depend upon the main thread. 
    /// The foreground thread has the ability to prevent the current application from terminating. 
    /// The CLR will not shut down the application until all the Foreground Threads have finished their assigned work. 
    /// The main thread is a foreground thread.
    /// 
    /// Background Thread in C#:
    /// Background Threads are those threads that will quit if our main application quits.
    /// Or in simple words, we can say that the life of the background thread will depend upon the life of the main thread.In short, 
    /// if our main application quits, then the background threads will also quit.
    /// Background threads are viewed by the CLR and if all foreground threads have terminated, 
    /// then all the background threads are automatically stopped when the application quits.


    /// </summary>
    internal class ForegroundBackgroundThreads
    {
        public ForegroundBackgroundThreads()
        {
        }
        public void BackgroundMethod1()
        {
            // A thread created here to run Method1 Parallely
            Thread thread1 = new Thread(Method1);
            Console.WriteLine($"Thread1 is a Background thread:  {thread1.IsBackground}");
            thread1.Start();
            //The control will come here and will exit 
            //the main thread or main application
            Console.WriteLine("Main Thread Exited");
        }

        public void BackgroundMethod2()
        {
            // A thread created here to run Method1 Parallely
            Thread thread1 = new Thread(Method1)
            {
                //Thread becomes background thread
                IsBackground = true
            };

            Console.WriteLine($"Thread1 is a Background thread:  {thread1.IsBackground}");
            thread1.Start();
            //The control will come here and will exit 
            //the main thread or main application
            Console.WriteLine("Main Thread Exited");
            //As the Main thread (i.e. foreground thread exits the application)
            //Automatically, the background thread quits the application
        }

        // Static method
        static void Method1()
        {
            Console.WriteLine("Method1 Started");
            int millisecondsTimeout = 1000;
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Method1 is in Progress!!");
                Thread.Sleep(millisecondsTimeout);
            }
            Console.WriteLine("Method1 Exited");
            Console.WriteLine("Press any key to Exit.");
            Console.ReadKey();
        }
        //------------------------------------------
        //Multiple Foreground Threads and one Background Thread:
        /// <summary>
        /// In the below example, 
        /// the main thread is by default a foreground thread and the main thread creates a thread1 object to call Method1. 
        /// Here, thread1 is also a foreground thread. Then from Method2, we created a foreground thread to call Method3. 
        /// Here, once all the foreground threads 
        /// i.e. Main thread and thread1 quit, then automatically the background thread 
        /// i.e. thread2 quits the application without completing its task (sometimes the task might be completed).
        /// </summary>
        public void MultipleForegroundThreads()
        {
            // A thread created here to run Method1 Parallely
            Thread thread1 = new Thread(Method2)
            {
            };
            Console.WriteLine($"Thread1 is a Background thread:  {thread1.IsBackground}");
            thread1.Start();
            //The control will come here and will exit 
            //the main thread or main application
            Console.WriteLine("Main Thread Exited");
            //As the Main thread (i.e. foreground thread exits the application)
            //Automatically, the background thread quits the application
        }
        // Static method
        static void Method2()
        {
            Console.WriteLine("Method2 Started");
            Thread thread2 = new Thread(Method3)
            {
                IsBackground = true
            };
            thread2.Start();
            int millisecondsTimeout = 3000;
            Thread.Sleep(millisecondsTimeout);
            Console.WriteLine("Method2 Exited");
        }
        // Static method
        static void Method3()
        {
            Console.WriteLine("Method3 Started");
            int millisecondsTimeout = 1000;
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Method3 is in Progress!!");
                Thread.Sleep(millisecondsTimeout);
            }
            Console.WriteLine("Method3 Exited");
            Console.WriteLine("Press any key to Exit.");
            Console.ReadKey();
        }
        //------------------------------------
        /// <summary>
        /// In the below example, we are showing the behavior of foreground and background threads in C#. 
        /// The code example will create a foreground thread and a background thread. 
        /// The foreground thread keeps the process running until completes it’s for loop and terminates. 
        /// The foreground thread has finished execution, the process is terminated before the background thread has completed execution.
        /// </summary>
        public void BackgroundForegroundThreadsMethod()
        {
            ThreadingTest foregroundTest = new ThreadingTest(5);
            //Creating a Coreground Thread
            Thread foregroundThread = new Thread(new ThreadStart(foregroundTest.RunLoop));
            ThreadingTest backgroundTest = new ThreadingTest(50);
            //Creating a Background Thread
            Thread backgroundThread = new Thread(new ThreadStart(backgroundTest.RunLoop))
            {
                IsBackground = true
            };
            foregroundThread.Start();
            backgroundThread.Start();
        }
        class ThreadingTest
        {
            readonly int maxIterations;
            public ThreadingTest(int maxIterations)
            {
                this.maxIterations = maxIterations;
            }
            public void RunLoop()
            {
                for (int i = 0; i < maxIterations; i++)
                {
                    Console.WriteLine($"{0} count: {i}", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread", i);
                    Thread.Sleep(250);
                }
                Console.WriteLine("{0} finished counting.", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread");
            }
        }

    }
}

//https://dotnettutorials.net/lesson/foreground-and-background-threads-in-csharp/

