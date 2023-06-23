

namespace Multithreading
{
    public class ThreadFunction 
    { 
        private void DisplayNumbersWithObjParameter(object Max)
        {
            int Number = Convert.ToInt32(Max);
            for (int i = 1; i <= Number; i++)
            {
                Console.WriteLine("Method4 :" + i);
            }
        }
        public  ThreadFunction() 
        {
            //Thread Function with Parameter:

            // Thread displayNumbersWithParameters = new Thread(DisplayNumbersWithParameters);


            // We can also combine the above two statements into a single statement as shown below:
            Thread displayNumbersWithParameters = new Thread(new ParameterizedThreadStart(DisplayNumbersWithObjParameter));

            displayNumbersWithParameters.Start(5);

            //we can also Pass String Value to a Thread Function:
            //In this case, you will not get any compile-time error, but once you run the application,
            //then you will get a runtime error:


            //displayNumbersWithParameters.Start("Hi");
            Console.Read();
            //--------------------------------------------
        }

        /// <summary>
        /// Make the Thread Function Type-Safe
        /// </summary>
        private class NumberHelper 
        {
            internal NumberHelper()
            {

            }
            int _Number;

            internal NumberHelper(int Number)
            {
                _Number = Number;
            }

            public void DisplayNumbers()
            {
                for (int i = 1; i <= _Number; i++)
                {
                    Console.WriteLine("value : " + i);
                }
            }
           
        }
        public void ThreadFunctionSafe() 
        {
            int Max = 10;
            NumberHelper obj = new NumberHelper(Max);

            Thread T1 = new Thread(new ThreadStart(obj.DisplayNumbers));

            T1.Start();
            Console.Read();
        }
        //--------------------------------------------
        /// <summary>
        /// Retrieve Data from a Thread Function using Callback Method:
        /// </summary>
        /// <param name="Results"></param>

        //first, Creating the callback delegate with the same signature of the callback method.
        private delegate void ResultCallbackDelegate(int Results);
        private class CalculateHelper 
        {
           
            private int _Number;
            private ResultCallbackDelegate _resultCallbackDelegate;
            //Initializing the private variables through constructor
            //So while creating the instance you need to pass the value for Number and callback delegate
            public CalculateHelper(int Number, ResultCallbackDelegate resultCallbackDelagate)
            {
                _Number = Number;
                _resultCallbackDelegate = resultCallbackDelagate;
            }
            //This is the Thread function which will calculate the sum of the numbers
            public void CalculateSum()
            {
                int Result = 0;
                for (int i = 1; i <= _Number; i++)
                {
                    Result = Result + i;
                }
                //Before the end of the thread function call the callback method
                if (_resultCallbackDelegate != null)
                {
                    _resultCallbackDelegate(Result);
                }
            }

        }
        public void ThreadMethodCalc()
        {
            ResultCallbackDelegate resultCallbackDelegate = new ResultCallbackDelegate(ResultCallBackMethod);

            int Number = 10;
            //Creating the instance of NumberHelper class by passing the Number
            //the callback delegate instance
            CalculateHelper obj = new CalculateHelper(Number, resultCallbackDelegate);
            //Creating the Thread using ThreadStart delegate
            Thread T1 = new Thread(new ThreadStart(obj.CalculateSum));

            T1.Start();
            Console.Read();
        }
        public static void ResultCallBackMethod(int Result)
        {
            Console.WriteLine("The Result is " + Result);
        }
    }
}
// https://dotnettutorials.net/lesson/how-to-pass-data-to-the-thread-function-in-a-type-safe-manner/
//https://dotnettutorials.net/lesson/how-to-retrieve-data-from-a-thread-function/