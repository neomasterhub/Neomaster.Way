using System;
using System.Threading;

namespace Threads.Priority
{
    internal class Program
    {
        private static int _highestCount = 0;
        private static int _lowestCount = 0;
        private static readonly Thread _highest = new Thread(() =>
        {
            while (++_highestCount < int.MaxValue) ;

            _lowest.Abort();
        });
        private static readonly Thread _lowest = new Thread(() =>
        {
            while (++_lowestCount < int.MaxValue) ;

            _highest.Abort();
        });

        private static void Main()
        {
            _highest.Priority = ThreadPriority.Highest;
            _lowest.Priority = ThreadPriority.Lowest;

            _highest.Start();
            _lowest.Start();

            _highest.Join();
            _lowest.Join();

            Console.WriteLine("highestCount: " + _highestCount);
            Console.WriteLine("lowestCount:  " + _lowestCount);
            Console.ReadKey();

            // Output (HDD):
            // highestCount: 2147483647
            // lowestCount:  1411503389         
        }
    }
}
