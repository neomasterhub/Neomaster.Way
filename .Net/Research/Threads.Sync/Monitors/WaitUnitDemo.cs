using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Sync.Monitors;

public class WaitUnitDemo : UnitDemoBase
{
    private static readonly object _locked = new();
    private static readonly List<string> _threadStateLog = new();

    public WaitUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "Wait(timeout) with thread state logging")]
    public void Demo()
    {
        Thread threadStateLogger = null;

        var thread = new Thread(() =>
        {
            threadStateLogger.Start();

            lock (_locked)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (i == 3)
                    {
                        Monitor.Wait(_locked, 2000);
                        continue;
                    }

                    int j = int.MaxValue / 2;
                    while (j-- > 0)
                    {
                    }
                }
            }
        });

        threadStateLogger = new Thread(() =>
        {
            while (thread.IsAlive)
            {
                var state = $"{DateTime.Now.Second}: {thread.ThreadState}";

                if (_threadStateLog.LastOrDefault() != state)
                {
                    _threadStateLog.Add(state);
                }

                Thread.Sleep(500);
            }
        });

        thread.Start();
        thread.Join();

        Output.WriteLine(string.Join('\n', _threadStateLog));

        // Output:
        // 22: Running
        // 23: Running
        // 24: WaitSleepJoin
        // 25: WaitSleepJoin
        // 26: Running
        // 27: Running
    }
}
