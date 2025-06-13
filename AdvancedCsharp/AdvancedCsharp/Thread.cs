using System;
using System.Threading;

namespace MultithreadingApplication {
    class MainThreadProgram
    {
        static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "MainThread";
            Console.WriteLine("This is {0}", th.Name);

            //exploring other properties
            bool isBackGrnd = (bool)th.IsBackground;
            bool live = th.IsAlive;
            bool OfThreadPool = th.IsThreadPoolThread;
            Console.WriteLine("Currently running thread is: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Currently running thread's is: {0}", Thread.CurrentThread.ManagedThreadId);

            Thread thread = new Thread(() => PerformTask("Hello from new performere!!!"));
            thread.Start();

            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("Creating the child thread in the main");
            Thread newThread = new Thread(childref);
            newThread.Start();
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine("Sleeping is being proceeded..\n");
            }

            Console.ReadKey();
        }
        static void PerformTask(string message)
        {
            Console.WriteLine(message);
        }
    
    public static void CallToChildThread() {
         Console.WriteLine("Child thread starts");
         
         // the thread is paused for 5000 milliseconds
         int sleepfor = 5000; 
         
         Console.WriteLine("Child Thread Paused for {0} seconds", sleepfor / 1000);
         Thread.Sleep(sleepfor);
         Console.WriteLine("Child thread resumes");
      }
   }
}