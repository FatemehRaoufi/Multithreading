using Multithreading;
using static Multithreading.ThreadFunction;

class Program
{
    static void Main(string[] args)
    {
        //ThreadSample threadSample = new ThreadSample();
        //ThreadStartDelegateSample threadStartDelegateSample = new ThreadStartDelegateSample();

        //NumberHelper numberHelper = new NumberHelper();
        // numberHelper.ThreadFunctionSafe();

        ThreadFunction threadFunction = new ThreadFunction();
        threadFunction.ThreadFunctionSafe();
        threadFunction.ThreadMethodCalc();
        

    }
}