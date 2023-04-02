using TestEngine6;
using Threads.Pool.ActivityTypes;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class CancelTrueUnitDemo : UnitDemoBase
{
    public CancelTrueUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        cts.Token.Register(() => Output.WriteLine("canceled 1"));
        cts.Token.Register(() => throw new Exception());
        cts.Token.Register(() => Output.WriteLine("canceled 3"));

        var counter = new Counter(cts.Token);
        ThreadPool.QueueUserWorkItem(_ => counter.CountAsync());
        Record.Exception(() => cts.Cancel(true));

        // Output:
        // canceled 3
    }
}
