using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    /// <summary>
    /// The Thread pool in C# is nothing but a collection of threads that can be reused to perform a number of tasks in the background. 
    /// Now when a request comes, then it directly goes to the thread pool and checks whether there are any free threads available or not. 
    /// If available, then it takes the thread object from the thread pool and executes the task as shown in the below image.
    /// </summary>
    internal class ThreadPoolSample
    {
        //we create one method that is MyMethod and as part of that method, we simply print the thread id,
        //whether the thread is a background thread or not, and whether it is from a thread pool or not.
        //And we want to execute this method 10 times using the thread pool threads.
        //So, here we use a simple for each loop and use the ThreadPool class and call that method.
        public ThreadPoolSample() {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
            }
            Console.Read();
        }
        public static void MyMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);
        }
        //---------------------

    }
}
//https://dotnettutorials.net/lesson/thread-pooling/