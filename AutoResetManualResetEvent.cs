using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Multithreading
{

    internal class AutoResetManualResetEvent
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        /// <summary>
        /// Let us first understand what is Signalling Methodology 
        /// and then we will understand how to implement the Signalling Methodology using AutoResetEvent and ManualResetEvent in C#. 
        /// Let us understand this with an example. Please have a look at the below image. Let’s say we have two threads Thread1 and Thread2. 
        /// And we need to implement thread synchronization between these two threads. 
        /// For thread synchronization, here thread2 sends a signal to thread1 saying that please go under Wait mode. 
        /// And then thread2 continues doing its work. And once thread2 finishes its work, 
        /// again it sends a signal to thread1 saying that you can resume your work from where you halted.
        /// </summary>

        public AutoResetManualResetEvent() { }

        /// <summary>  
        /// AutoResetEvent:
        /// In the below example, we have two threads. 
        /// The Main thread will invoke the main method and the NewThread which will invoke the SomeMethod method. 
        /// The main method will invoke the new thread and the new thread actually go and run the SomeMethod. 
        /// And the SomeMethod will first print the first statement i.e. Starting….. 
        /// and then it invokes the WaitOne() method which Put the current thread 
        /// i.e.NewThread into the waiting state until it receives the signal. Then inside the static void Main method, 
        /// when we press the enter key, it will invoke the Set method which will send a signal to other threads to resume their work 
        /// i.e. send the signal to NewThread to resume its work, and the new thread then prints Finishing…….. 
        /// on the console window.
        /// </summary>
        public void AutoResetEvent()
        {
            Thread newThread = new Thread(AutoResetEventMethod)
            {
                Name = "NewThread"
            };
            newThread.Start(); //It will invoke the SomeMethod in a different thread
            //To See how the SomeMethod goes in halt mode
            //Once we enter any key it will call set method and the SomeMethod will Resume its work
            Console.ReadLine();
            //It will send a signal to other threads to resume their work
            autoResetEvent.Set();
        }
        static void AutoResetEventMethod()
        {
            Console.WriteLine("Starting........");
            //Put the current thread into waiting state until it receives the signal
            autoResetEvent.WaitOne(); //It will make the thread in halt mode
            Console.WriteLine("Finishing........");
            Console.ReadLine(); //To see the output in the console
        }

        //-------------------------------------------


        public void ManualResetEvent()
        {
            Thread newThread = new Thread(ManualResetEventMethod)
            {
                Name = "NewThread"
            };
            newThread.Start(); //It will invoke the SomeMethod in a different thread
            //To See how the SomeMethod goes in halt mode
            //Once we enter any key it will call set method and the SomeMethod will Resume its work
            Console.ReadLine();
            //It will send a signal to other threads to resume their work
            manualResetEvent.Set();
        }
        static void ManualResetEventMethod()
        {
            Console.WriteLine("Starting........");
            //Put the current thread into waiting state until it receives the signal
            manualResetEvent.WaitOne(); //It will make the thread in halt mode
            Console.WriteLine("Finishing........");
            Console.ReadLine(); //To see the output in the console
        }

        //------------------------------------------------
        /// <summary>
        ///  Differences between AutoResetEvent and ManualResetEvent in C#:
        /// Let us understand the differences with some examples. 
        /// In AutoResetEvent, for every WaitOne method, there should be a Set method. 
        /// That means if we are using the WaitOne method 2 times, then we should use the Set method 2 times. 
        /// If we use the Set method 1 time, then the 2nd WaitOne method will be hung in the waiting state and will not be released.  
        ///<summary>
        public void MultiSetWaitOneAutoResetEvent()
        {
            Thread newThread = new Thread(MultiSetWaitOneAutoResetEventMethod)
            {
                Name = "NewThread"
            };
            newThread.Start(); //It will invoke the SomeMethod in a different thread
            //To See how the SomeMethod goes in halt state let sleep the main thread for 3 secs
            Thread.Sleep(3000);
            Console.WriteLine("Releasing the WaitOne 1 by Set 1");
            autoResetEvent.Set(); //Set 1 will relase the Wait 1
            /*
             If we have two WaitOne methods and we have one Set method, 
             then the second WaitOne method will hang in the sleep mode and will not release,
             but if we  using ManualResetEvent then it will work.
             */
            //To See how the SomeMethod goes in halt state let sleep the main thread for 3 secs
            Thread.Sleep(5000);
            Console.WriteLine("Releasing the WaitOne 2 by Set 2");
            autoResetEvent.Set(); //Set 2 will relase the Wait 2
            Console.ReadKey();
        }
        static void MultiSetWaitOneAutoResetEventMethod()
        {
            Console.WriteLine("Starting 1........");
            autoResetEvent.WaitOne(); //Wait 1
            Console.WriteLine("Finishing 1........");
            Console.WriteLine();
            Console.WriteLine("Starting 2........");
            autoResetEvent.WaitOne(); //Wait 2
            Console.WriteLine("Finishing 2........");
        }
        //---------------------------------------------
        /// <summary>
        
        /// That is one Set method in ManualResetEvent can release all the WaitOne methods. 
        /// For a better understanding, please have a look at the below example
        /// </summary>
        public void MultiSetWaitOneManualResetEvent()
        {
            Thread newThread = new Thread(MultiSetWaitOneManualResetEventMethod)
            {
                Name = "NewThread"
            };
            newThread.Start(); //It will invoke the SomeMethod in a different thread
            //To See how the SomeMethod goes in halt state let sleep the main thread for 3 secs
            Thread.Sleep(3000);
            Console.WriteLine("Releasing the WaitOne 1 by Set 1");
            manualResetEvent.Set(); //Set will release all the WaitOne

            Console.ReadKey();
        }
        static void MultiSetWaitOneManualResetEventMethod()
        {
            Console.WriteLine("Starting 1........");
            manualResetEvent.WaitOne(); //Wait 1
            Console.WriteLine("Finishing 1........");
            Console.WriteLine();
            Console.WriteLine("Starting 2........");
            manualResetEvent.WaitOne(); //Wait 2
            Console.WriteLine("Finishing 2........");
        }
    }
}

    //------------------------------------


//https://dotnettutorials.net/lesson/autoresetevent-and-manualresetevent-in-csharp/

