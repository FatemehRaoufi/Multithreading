/*
How to Terminate a Thread in C#?

 Abort(): 
This method raises a System.
Threading.ThreadAbortException in the thread on which it is invoked, to begin the process of terminating the thread. 
Calling this method usually terminates the thread. 
It will throw ThreadStateException if the thread that is being aborted is currently suspended. 
It will throw SecurityException if the caller does not have the required permission.

Abort(object stateInfo): 
This method raises a System.Threading.
ThreadAbortException in the thread on which it is invoked, 
to begin the process of terminating the thread while also providing exception information about the thread termination. 
Calling this method usually terminates the thread. 
Here, the parameter stateInfo specifies an object that contains application-specific information, such as the state, 
which can be used by the thread being aborted. It will throw ThreadStateException if the thread that is being aborted is currently suspended. 
It will throw SecurityException if the caller does not have the required permission.
 */
namespace Multithreading
{
    internal class ThreadTerminate
    {

        public ThreadTerminate()
        {

        }
        /// <summary>
        /// This method raises a ThreadAbortException in the thread on which it is invoked, 
        /// to begin the process of terminating the thread. Generally, this method is used to terminate the thread.
        /// </summary>
        public void ThreadAbortEvent()
        {
            Thread thread = new Thread(ThreadAbortMethod);
            thread.Start();
            Console.WriteLine("Thread is Abort");
            // Abort thread Using Abort() method
            thread.Abort();
            Console.ReadKey();
        }
        static void ThreadAbortMethod()
        {
            for (int x = 0; x < 3; x++)
            {
                Console.WriteLine(x);
            }
        }
        //----------------------------------------
        /// <summary>
        /// This method raises a ThreadAbortException in the thread on which it is invoked, 
        /// to begin the process of terminating the thread while also providing exception information about the thread termination. 
        /// Generally, this method is used to terminate the thread
        /// </summary>
        public void AbortStateInfoEvent()
        {
            Thread thread = new Thread(AbortStateInfoMethod)
            {
                Name = "Thread 1"
            };
            thread.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Abort Thread Thread 1");
            thread.Abort(100);
            // Waiting for the thread to terminate.
            thread.Join();
            Console.WriteLine("Main thread is terminating");
            Console.ReadKey();
        }
        static void AbortStateInfoMethod()
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is Starting");
                for (int j = 1; j <= 100; j++)
                {
                    Console.Write(j + " ");
                    if ((j % 10) == 0)
                    {
                        Console.WriteLine();
                        Thread.Sleep(200);
                    }
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} Exiting Normally");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is aborted and the code is {ex.ExceptionState}");
            }
        }
        //------------------------------------------------------
        /// <summary>
        /// In the below example, we are calling the Abort() method on the running thread. 
        /// This will throw the ThreadAbortException and abort the thread on which the Abort() method is called. 
        /// Calling the Abort() method will throw a ThreadAbortException, 
        /// so we will enclose its statements within a try-catch block to catch the exception.
        /// </summary>
        public void AbortOnRunningThreadEvent()
        {
            //Creating an object Thread class
            Thread thread = new Thread(AbortOnRunningThreadMethod)
            {
                Name = "My Thread1"
            };
            thread.Start();
            //Making the main Thread sleep for 1 second
            //Giving the child thread enough time to start its execution
            Thread.Sleep(1000);
            //Calling the Abort() on thread object
            //This will abort the new thread and throw ThreadAbortException in it
            thread.Abort();
            Console.ReadKey();
        }
        static void AbortOnRunningThreadMethod()
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Started its Execution");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is printing {i}");
                    //Calling the Sleep() method to make it sleep and 
                    //suspend for 2 seconds after printing a number
                    Thread.Sleep(1000);
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Finished its Execution");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"ThreadAbortException Occurred, Message : {e.Message}");
            }
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Calling the Abort() method on a thread that hasn’t started yet:
        /// In the below example, we are calling the Abort() method on a thread before calling the Start() method on it. 
        /// Calling the Start() method on such a thread, later on, will not start it, but throw the ThreadStartException. 
        /// </summary>
        public void AborthasntStartedyetThreadEvent()
        {
            try
            {
                //Creating an object Thread class
                Thread MyThread = new Thread(AborthasntStartedyetThreadMethod)
                {
                    Name = "My Thread1"
                };
                //Calling the Abort() method on MyThread which hasn't started yet
                //This will leads to the ThreadStartException
                //And calling the Start() method on the same thread later on will abort it and throw ThreadStartException
                MyThread.Abort();
                //Calling the Start() method will not start the thread
                //but throw ThreadStartException and abort it.
                //Because the Abort() method was called on it before it could start
                MyThread.Start();
                Console.WriteLine("Main Thread has terminated");
            }
            catch (ThreadStartException e)
            {
                Console.WriteLine($"ThreadStartException Occurred, Message : {e.Message}");
            }

            Console.ReadKey();
        }
         static void AborthasntStartedyetThreadMethod()
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Started its Execution");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is printing {i}");
                    //Calling the Sleep() method to make it sleep and 
                    //suspend for 2 seconds after printing a number
                    Thread.Sleep(1000);
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Finished its Execution");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"ThreadAbortException Occurred, Message : {e.Message}");
            }
        }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Calling the Abort() method on a Thread that is in Blocked State in C#:
        /// When we call the Abort() method on a thread, which has started its execution, 
        /// but presently it is in either of the blocked states i.e. Wait State, Sleep State, or Join State, 
        /// will first interrupt the thread and then abort it by throwing ThreadAbortException.
        /// </summary>
        public void AbortBlockedThreadEvent()
        {
      
            //Creating an object Thread class
            Thread MyThread = new Thread(AbortBlockedThreadMethod)
            {
                Name = "My Thread1"
            };
            MyThread.Start();
            //Making the Main thread sleep for 500 milliseconds
            //Which gives enough time for its child start to start its execution
            Thread.Sleep(500);
            //Main thread calling Abort() on the child Thread which is in a blocked state
            //will throw ThreadAbortException 
            MyThread.Abort();

            //Main thread has called Join() method on the new thread
            //To wait until its execution is complete
            MyThread.Join();

            Console.WriteLine("Main Thread has terminated");
            Console.ReadKey();
        }
        public static void AbortBlockedThreadMethod()
        {

            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Started its Execution");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is printing {i}");
                    //Calling the Sleep() method on newly created thread
                    //To make it sleep and suspend for 3 seconds after printing a number
                    Thread.Sleep(3000);
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Finished its Execution");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"ThreadAbortException Occurred, Message : {e.Message}");
            }
        
    }
        //--------------------------------------------------------


    }
}
//https://dotnettutorials.net/lesson/how-to-terminate-a-thread-in-csharp/
