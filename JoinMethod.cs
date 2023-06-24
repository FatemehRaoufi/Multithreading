using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    public class JoinMethod
    {
        HelperClass helperClass = new HelperClass();
        //JoinMethod: Sample1:
        public JoinMethod()
        {

        }
        //------------------------
        public void JoinMethodSample1()
        {
            Console.WriteLine("Main Thread Started");
            //Main Thread creating three child threads
            //Thread thread1 = new Thread(Method1);
            Thread thread1 = new Thread(helperClass.Method1);
            Thread thread2 = new Thread(helperClass.Method2);
            Thread thread3 = new Thread(helperClass.Method3);

            thread1.Start();
            thread2.Start();
            thread3.Start();
            //If dont use Join, first Method1 executed , 2. Main Method Excecuted , 3. Method2  und 4. Method3 executed
            thread1.Join(); //Block Main Thread until thread1 completes its execution
            thread2.Join(); //Block Main Thread until thread2 completes its execution
            thread3.Join(); //Block Main Thread until thread3 completes its execution

            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }
        //-----------------------
        //JoinMethod: Sample2:
        public void JoinMethodSample2()
        {
            Console.WriteLine("Main Thread Started");
            //Main Thread creating three child threads

            //Thread thread1 = new Thread(Method1);

            Thread thread1 = new Thread(helperClass.Method1);
            Thread thread2 = new Thread(helperClass.Method2);
            Thread thread3 = new Thread(helperClass.Method3);

            thread1.Start();
            thread2.Start();
            thread3.Start();
            //Now, Main Thread will block for 3 seconds and wait thread2 to complete its execution
            if (thread2.Join(TimeSpan.FromSeconds(3)))
            {
                Console.WriteLine("Thread 2 Execution Completed in 3 second");
            }
            else
            {
                Console.WriteLine("Thread 2 Execution Not Completed in 3 second");
            }
            //Now, Main Thread will block for 3 seconds and wait thread3 to complete its execution
            if (thread3.Join(3000))
            {
                Console.WriteLine("Thread 3 Execution Completed in 3 second");
            }
            else
            {
                Console.WriteLine("Thread 3 Execution Not Completed in 3 second");
            }
            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }
        //---------------------------------------------------------------
        /*
         static void Method1()
        {
            Console.WriteLine("Method1 - Thread1 Started");
            Thread.Sleep(1000);
            Console.WriteLine("Method1 - Thread 1 Ended");
        }
         */
    }


}
//https://dotnettutorials.net/lesson/join-method-of-thread-class/