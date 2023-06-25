using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class IsAliveMethod
    {

        /// <summary>
        /// The IsAlive property gets a value indicating the execution status of the current thread. 
        /// It returns true if the thread has been started and has not terminated normally or aborted; otherwise, false. 
        /// That means the IsAlive property of the Thread class returns true if the thread is still executing else returns false.
        /// </summary>

        HelperClass helperClass = new HelperClass();
        public IsAliveMethod() {

            Console.WriteLine("Main Thread Started");

            
            Thread thread1 = new Thread(helperClass.Method1);
           
            thread1.Start();

            if (thread1.IsAlive)
            {
                Console.WriteLine("Thread1 Method1 is still Executing");
            }
            else
            {
                Console.WriteLine("Thread1 Method1 Completed its work");
            }
            //Wait Till thread1 to complete its execution
            thread1.Join();
            if (thread1.IsAlive)
            {
                Console.WriteLine("Thread1 Method1 is still Executing");
            }
            else
            {
                Console.WriteLine("Thread1 Method1 Completed its work");
            }
            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }
       

    }
}
