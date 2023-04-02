using TestEngine6;
using Threads.Pool.ActivityTypes;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class CancelAfterUnitDemo : UnitDemoBase
{
    public CancelAfterUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        var counter = new Counter(cts.Token);

        ThreadPool.QueueUserWorkItem(_ => counter.CountAsync());
        cts.CancelAfter(50);

        Thread.Sleep(100);
        Output.WriteLine($"t1: {counter.Count}");
        Thread.Sleep(100);
        Output.WriteLine($"t2: {counter.Count}");

        // Output:
        // t1: B
        // t2: B
    }
}
