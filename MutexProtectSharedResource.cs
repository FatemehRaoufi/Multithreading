
using System.Threading;

namespace Multithreading
{
    /// <summary>
    /// Mutex in C# to Protect Shared Resource in Multithreading:
    /// When two or more threads need to access a shared resource at the same time, 
    /// the system needs a synchronization mechanism to ensure that only one thread at a time uses the resource. 
    /// Mutex is a synchronization mechanism that grants exclusive access to the shared resource to only one external thread. 
    /// If a thread acquires a mutex, the second thread that wants to acquire that mutex is suspended until the first thread releases the mutex.
    /// The following example shows how a local Mutex object is used to synchronize access to a protected resource. 
    /// Because each calling thread is blocked until it acquires ownership of the mutex, 
    /// it must call the ReleaseMutex method to release ownership of the mutex.
    /// </summary>
    ///

    internal class MutexProtectSharedResource
    {
        private static Mutex mutex = new Mutex();
        static Mutex _mutex;
        public MutexProtectSharedResource()
        {
            
        }

        public  void CallMutexDemo() {

            //Create multiple threads to understand Mutex
            for (int i = 1; i <= 5; i++)
            {
                Thread threadObject = new Thread(MutexDemo)
                {
                    Name = "Thread " + i
                };
                threadObject.Start();
            }
            //The Mutex Class is inherited from WaitHandle abstract class and the WaitHandle abstract class implements the IDisposable interface.
            //So, when you have finished using the type (in this case Mutex class), you should dispose of it either directly or indirectly:
            mutex.Dispose();

            Console.ReadKey();
        }
        public  void CallIsSingleInstance() {
            //If IsSingleInstance returns true continue with the Program else Exit the Program
            if (!IsSingleInstance())
            {
                Console.WriteLine("More than one instance"); // Exit program.
            }
            else
            {
                Console.WriteLine("One instance"); // Continue with program.
            }

            
            Console.ReadLine();

        }
        //------------------------------------------------------------------------------------
        //Method to implement syncronization using Mutex  
        static void MutexDemo()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter Critical Section for processing");
            try
            {
                //Blocks the current thread until the current WaitOne method receives a signal.  
                //Wait until it is safe to enter. 
                mutex.WaitOne();
                Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
                int millisecondsTimeout = 2000;
                Thread.Sleep(millisecondsTimeout);
                Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " is Completed its task");
            }
            finally
            {
                //Call the ReleaseMutex method to unblock so that other threads
                //that are trying to gain ownership of the mutex can enter  
                mutex.ReleaseMutex();
            }
        }
        static void AdvancedMutexDemo()
        {
            // Wait until it is safe to enter, and do not enter if the request times out.
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter Critical Section for processing");
            int millisecondsTimeout = 1000;

            if (mutex.WaitOne(millisecondsTimeout))
            {
                try
                {
                    Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
                    
                    Thread.Sleep(millisecondsTimeout);
                    Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " is Completed its task");
                }
                finally
                {
                    //Call the ReleaseMutex method to unblock so that other threads
                    //that are trying to gain ownership of the mutex can enter  
                    mutex.ReleaseMutex();
                    Console.WriteLine(Thread.CurrentThread.Name + " Has Released the mutex");
                }
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " will not acquire the mutex");
            }
        }

        //OpenExisting Method Example of Mutex Class
        static bool IsSingleInstance()
        {
            try
            {
                // Try to open Existing Mutex.
                //If MyMutex is not opened, then it will throw an exception
                Mutex.OpenExisting("MyMutex");
            }
            catch
            {
                // If exception occurred, there is no such mutex.
                _mutex = new Mutex(true, "MyMutex");
                // Only one instance.
                return true;
            }
            // More than one instance.
            return false;
        }
    }

}
//https://dotnettutorials.net/lesson/mutex-in-multithreading/


