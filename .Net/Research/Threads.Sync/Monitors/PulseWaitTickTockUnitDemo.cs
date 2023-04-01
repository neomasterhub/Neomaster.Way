using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Sync.Monitors;

public class PulseWaitTickTockUnitDemo : UnitDemoBase
{
    private static readonly object _locked = new();
    private static readonly int _limit = 10;
    private static string _signals = string.Empty;

    public PulseWaitTickTockUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static void Beep(char signal)
    {
        lock (_locked)
        {
            while (_signals.Length < _limit)
            {
                _signals += signal;

                Monitor.Pulse(_locked);

                if (_signals.Length != _limit)
                {
                    Monitor.Wait(_locked);
                }
            }
        }
    }

    [Fact]
    public void Demo()
    {
        var tick = new Thread(() => Beep('*'));
        var tock = new Thread(() => Beep('.'));

        tick.Start();

        while (tick.ThreadState != ThreadState.WaitSleepJoin)
        {
        }

        tock.Start();

        tick.Join();
        tock.Join();

        Output.WriteLine($"limit: {_limit}");
        Output.WriteLine($"count: {_signals.Length}");
        Output.WriteLine($"signals: {_signals}");

        // Output:
        // limit: 10
        // count: 10
        // signals: *.*.*.*.*.
    }
}
