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

        //ThreadFunction threadFunction = new ThreadFunction();
        //threadFunction.ThreadFunctionSafe();
        //threadFunction.ThreadMethodCalc();

        //JoinMethod joinMethod = new JoinMethod();

        //joinMethod.JoinMethodSample1();
        //joinMethod.JoinMethodSample2();

        //IsAlive isAlive =   new IsAlive();

        //ThreadSynchronizationSample1 threadSynchronizationSample1 = new ThreadSynchronizationSample1();
        //ThreadSynchronizationLock2 threadSynchronizationSample2 = new ThreadSynchronizationLock2();

        //ThreadSynchronizationMonitor threadSynchronizationMonitor = new ThreadSynchronizationMonitor();

        //TryEnterMonitor tryEnterMonitor = new TryEnterMonitor();

        //MutexProtectSharedResource mutexProtectSharedResource = new MutexProtectSharedResource();
        //mutexProtectSharedResource.CallMutexDemo();
        //mutexProtectSharedResource.CallIsSingleInstance();

        //ThreadSynchronizationSemaphore threadSynchronizationSemaphore = new ThreadSynchronizationSemaphore();
        //threadSynchronizationSemaphore.SemaphoreDemo();
        //threadSynchronizationSemaphore.AdvancedSemaphoreDemo();


        //ThreadSynchronizationSemaphoreSlim threadSynchronizationSemaphoreSlim = new ThreadSynchronizationSemaphoreSlim();
        //threadSynchronizationSemaphoreSlim.SemaphoreSlimMethod1();
        //threadSynchronizationSemaphoreSlim.SemaphoreSlimMethod2();

        PerformanceTesting performanceTesting = new PerformanceTesting();
        //performanceTesting.PerformanceTestingSingleThread();
        //performanceTesting.PerformanceTestingMultipleThreads();
        performanceTesting.PerformanceTestingThreadsVsThreadPool();

        // ThreadPoolSample threadPoolSample = new ThreadPoolSample();
        // threadPoolSample.
    }
}
//https://dotnettutorials.net/lesson/multithreading-using-monitor/
//https://dotnettutorials.net/course/csharp-dot-net-tutorials/