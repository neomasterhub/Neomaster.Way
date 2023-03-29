using System;
using System.Threading;

namespace Threads.Abort
{
    internal class Program
    {
        static void Main()
        {
            var th1 = new Thread(() =>
            {
                while (true)
                {
                    Console.Write('*');
                    Thread.Sleep(200);
                }
            });
            var th2 = new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                th1.Abort();
            });

            th1.Start();
            th2.Start();
            th1.Join();

            Console.Write("[Aborted]");
            Console.ReadKey();

            // Output:
            // *********[Aborted].
        }
    }
}
