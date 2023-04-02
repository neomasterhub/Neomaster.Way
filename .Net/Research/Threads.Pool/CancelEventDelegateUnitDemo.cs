using TestEngine6;
using Threads.Pool.ActivityTypes;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class CancelEventDelegateUnitDemo : UnitDemoBase
{
    public CancelEventDelegateUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        cts.Token.Register(() => Output.WriteLine("canceled"));

        var counter = new Counter(cts.Token);
        ThreadPool.QueueUserWorkItem(_ => counter.CountAsync());

        cts.CancelAfter(50);
        Thread.Sleep(60);

        // Output:
        // canceled
    }
}
