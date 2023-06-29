namespace Multithreading
{
    /// <summary>
    /// if we want more control over the number of external threads that can access our application code, 
    /// then we need to use the Semaphore class in C#.
    /// </summary>

    internal class ThreadSynchronizationSemaphore
    {
        public static Semaphore semaphore = null;
        public ThreadSynchronizationSemaphore()

        {

        }
        /// <summary>
        /// In the below example, 
        /// we are creating the semaphore instance to allow a maximum of two threads to access our application code 
        /// i.e. the code in between the WaitOne method and Release method.
        /// </summary>
        public void SemaphoreDemo()
        {
            try
            {
                //Try to Open the Semaphore if Exists, if not throw an exception
                semaphore = Semaphore.OpenExisting("SemaphoreDemo");
            }
            catch (Exception Ex)
            {
                //If Semaphore not Exists, create a semaphore instance
                //Here Maximum 2 external threads can access the code at the same time
                int initialCount = 2;
                int maximunCount = 2;
                string semaphoreName = "SemaphoreDemo";
                semaphore = new Semaphore(initialCount, maximunCount, semaphoreName);
            }
            Console.WriteLine("External Thread Trying to Acquiring");
            semaphore.WaitOne();
            //This section can be access by maximum two external threads: Start
            Console.WriteLine("External Thread Acquired");
            Console.ReadKey();
            //This section can be access by maximum two external threads: End
            semaphore.Release();

        }
        #region
        /// <summary>
        /// In the below example, we initialize a semaphore object with 2 initialcount 
        /// and maximum of 3 threads that can enter the critical section. 
        /// We start the for loop with runs from 0 to 10. 
        /// We started threads using the Thread class and the call shared resource DoSomeTask method.
        //Each thread calls the WaitOne method of semaphore object before doing the required task.
        //The WaitOne method will decrease the initialcount variable value by 1.
        //So, the WaitOne method will limit the number of threads to access the shared resource.
        //After completing the task each thread calls the Release method
        //which will increment initialcount variable value by 1 of the semaphore object.
        //This allows further threads to enter into a critical section.
        /// </summary>
        public void AdvancedSemaphoreDemo()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread threadObject = new Thread(DoSomeTask)
                {
                    Name = "Thread " + i
                };
                threadObject.Start();
            }
            Console.ReadKey();
        }
        static void DoSomeTask()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter into Critical Section for processing");
            int initialCount = 2;
            int maximunCount = 3;
            string semaphoreName = "SemaphoreDemo";
            semaphore = new Semaphore(initialCount, maximunCount, semaphoreName);
            try
            {
                //Blocks the current thread until the current WaitHandle receives a signal.   
                semaphore.WaitOne();
                //Decrease the Initial Count Variable by 1
                Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
                int millisecondsTimeout = 5000;
                Thread.Sleep(millisecondsTimeout);
                Console.WriteLine(Thread.CurrentThread.Name + "Exit.");
            }
            finally
            {
                //Release() method to release semaphore  
                //Increase the Initial Count Variable by 1
                semaphore.Release();
            }
        }
        #endregion
        //---------------------------------
    }
}

//https://dotnettutorials.net/lesson/semaphore-in-multithreading/