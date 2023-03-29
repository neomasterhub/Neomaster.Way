using System;
using System.Threading;

namespace Threads.AbortArg
{
    internal class Program
    {
        static void Main()
        {
            var th1 = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Console.Write('*');
                        Thread.Sleep(200);
                    }
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine(e.ExceptionState);
                }
            });
            var th2 = new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                th1.Abort($"[Aborted by thread {Thread.CurrentThread.ManagedThreadId}]");
            });

            th1.Start();
            th2.Start();
            th1.Join();

            Console.ReadKey();

            // Output:
            // *********[Aborted by thread ...].
        }
    }
}
