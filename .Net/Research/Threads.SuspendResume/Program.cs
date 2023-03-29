#pragma warning disable CS0618
using System;
using System.Threading;

namespace Threads.SuspendResume
{
    internal class Program
    {
        private static int _i = 0;
        private static readonly int _max = 3;

        private static void Write(char symbol, Thread next)
        {
            Thread.CurrentThread.Suspend();

            while (true)
            {
                Console.Write(symbol);
                Thread.Sleep(500);

                if (++_i == _max)
                {
                    _i = 0;
                    next.Resume();
                    Thread.CurrentThread.Suspend();
                }
            }
        }

        static void Main()
        {
            Thread th1 = null;
            Thread th2 = null;

            th1 = new Thread(() => Write('-', th2));
            th2 = new Thread(() => Write('|', th1));

            th1.Start();
            th2.Start();

            while (th1.ThreadState != ThreadState.Suspended) ;

            th1.Resume();

            // Output:
            // ---|||---|||---|||
        }
    }
}
