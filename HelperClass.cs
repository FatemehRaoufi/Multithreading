
namespace Multithreading
{
    public class HelperClass
    {
        //  public HelperClass() { }
        static int millisecondsTimeout = 0;
        public void Method1()
        {
            Console.WriteLine("Method1 - Thread1 Started");
            millisecondsTimeout = 1000;
            Thread.Sleep(millisecondsTimeout);
            Console.WriteLine("Method1 - Thread 1 Ended");
        }
        public  void Method2()
        {
            Console.WriteLine("Method2 - Thread2 Started");
            millisecondsTimeout = 2000;
            Thread.Sleep(millisecondsTimeout);
            Console.WriteLine("Method2 - Thread2 Ended");
        }
        public  void Method3()
        {
            Console.WriteLine("Method3 - Thread3 Started");
            millisecondsTimeout = 5000;
            Thread.Sleep(millisecondsTimeout);
            Console.WriteLine("Method3 - Thread3 Ended");
        }
    }
}
