using TestEngine6;
using Threads.Pool.ActivityTypes;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class CancelUnitDemo : UnitDemoBase
{
    public CancelUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        var counter = new Counter(cts.Token);
        ThreadPool.QueueUserWorkItem(_ => counter.CountAsync());

        Thread.Sleep(100);
        cts.Cancel();

        Thread.Sleep(100);
        Output.WriteLine($"t1: {counter.Count}");
        Thread.Sleep(100);
        Output.WriteLine($"t2: {counter.Count}");

        // Output:
        // t1: A
        // t2: A
    }
}
