using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Sync.Monitors;

public class PulseWaitTickTockWithNoiseUnitDemo : UnitDemoBase
{
    private static readonly object _locked = new();
    private static readonly int _limit = 10;
    private static int _count = 0;
    private static string _signals = string.Empty;

    public PulseWaitTickTockWithNoiseUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static void Beep(char signal)
    {
        lock (_locked)
        {
            while (_count < _limit)
            {
                _count++;
                _signals += signal;

                Thread.Sleep(100);

                Monitor.Pulse(_locked);

                if (_count != _limit)
                {
                    Monitor.Wait(_locked);
                }
            }
        }
    }

    [Fact(DisplayName = "Pulse(), Wait(), Tick tock with noise")]
    public void Demo()
    {
        var tick = new Thread(() => Beep('\''));
        var tock = new Thread(() => Beep('\"'));
        var noise = new Thread(() =>
        {
            while (tick.IsAlive && tock.IsAlive)
            {
                _signals += '.';

                Thread.Sleep(30);
            }
        });

        tick.Start();
        while (tick.ThreadState != ThreadState.WaitSleepJoin)
        {
        }

        tock.Start();
        noise.Start();
        noise.Join();

        Output.WriteLine($"limit: {_limit}");
        Output.WriteLine($"count: {_count}");
        Output.WriteLine($"signals: {_signals}");

        // Output:
        // limit: 10
        // count: 10
        // signals: '...."....'..."....'..."....'..."...'...."...
    }
}
