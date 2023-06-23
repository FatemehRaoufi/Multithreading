using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{

    public class ThreadStartDelegateSample
    {
        private static void DisplayNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }


        public ThreadStartDelegateSample()
        {

            ThreadStart displayNumbers = new ThreadStart(DisplayNumbers);
            //Passing the ThreadStart Delegate instance as a parameter to its constructor
            Thread threadDisplayNumbers = new Thread(displayNumbers);

            // We can also combine the above two statements into a single statement as shown below:
            // Thread thread = new Thread(new ThreadStart(DisplayNumbers));

            threadDisplayNumbers.Start();
            //-----------------------------------------------

            // It is also possible to create a Thread class instance by using the anonymous method as shown in the below example.
            // We know that Anonymous methods are created by using the delegate keyword and they are assigned to a type of delegate.
            // Creating Thread Class Instance using Lambda Expression:

            Thread threadDelegate = new Thread(delegate ()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Method2 :" + i);
                }
            });
            threadDelegate.Start();
            //-------------------------------------

            //Thread Class Instance using Lambda Expression:

            Thread threadLambda = new Thread(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Method3 :" + i);
                }
            });
            threadLambda.Start();
            Console.Read();

        }
        //------------------------------------------
        



    }

}
//https://dotnettutorials.net/lesson/constructors-of-thread-class-csharp/
