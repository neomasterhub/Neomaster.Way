using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Sync.Monitors;

public class PulseAllUnitDemo : UnitDemoBase
{
    private static readonly object _locked = new();

    public PulseAllUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        int threads = 3;
        int impulses = 0;

        for (int i = 0; i < threads; i++)
        {
            var th = new Thread(() =>
            {
                lock (_locked)
                {
                    Monitor.Wait(_locked);
                    impulses++;
                }
            });

            th.Start();
        }

        Thread.Sleep(100);

        lock (_locked)
        {
            Monitor.PulseAll(_locked);
        }

        Output.WriteLine($"threads: {threads}");
        Output.WriteLine($"impulses: {impulses}");

        // Output:
        // threads: 3
        // impulses: 3
    }
}
