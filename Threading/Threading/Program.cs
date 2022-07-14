using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        public static void CalltoChildThread()
        {
            Console.WriteLine("Child thread starts");
        }

        static void Main(string[] args)
        {

            ThreadStart childref = new ThreadStart(CalltoChildThread);
            Console.WriteLine("In main: creating the child thread");

            Thread childThread = new Thread(childref);
            childThread.Start();
            Console.ReadKey();

            //----------------------------------------------------------------------------\\

            //Creating threads
            Thread T1 = new Thread(Method1);
            T1.Name = "Thread 1";

            Thread T2 = new Thread(Method2);
            T2.Name = "Thread 2";

            Thread T3 = new Thread(Method3);
            T3.Name = "Thread 3";

            T1.Start();
            T2.Start();
            T3.Start();

            Console.Read();

            

        }

        //Methods starting and ending threads with processes
        static void Method1()
        {
            Console.WriteLine("Method 1 started using " + Thread.CurrentThread.Name);

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method 1 :" + i);
            }
            Console.WriteLine("Method 1 Ended using " + Thread.CurrentThread.Name);
        }

        static void Method2()
        {
            Console.WriteLine("Method 2 started using " + Thread.CurrentThread.Name);

            for (int i = 1; i <= 5; i++)
            {
                if(i == 3)
                {
                    Console.WriteLine("Performing Database Operation Started");
                    Thread.Sleep(10000); 
                    Console.WriteLine("Performing Database Operation Completed");
                }
                Console.WriteLine("Method 2 :" + i);
            }
            Console.WriteLine("Method 2 Ended using " + Thread.CurrentThread.Name);
        }

        static void Method3()
        {
            Console.WriteLine("Method 3 started using " + Thread.CurrentThread.Name);

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method 3 :" + i);
            }
            Console.WriteLine("Method 3 Ended using " + Thread.CurrentThread.Name);

        }

        static void AbortThread()
        {
            //Wont work here because seperate method
            //childThread.Abort();
            Console.ReadKey();
        }
    }
}
