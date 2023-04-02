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

    [Fact(DisplayName = "Registration of cancel event delegates")]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        cts.Token.Register(() => Output.WriteLine("canceled 1"));
        cts.Token.Register(() => Output.WriteLine("canceled 2"));
        cts.Token.Register(() => Output.WriteLine("canceled 3"));

        var counter = new Counter(cts.Token);
        ThreadPool.QueueUserWorkItem(_ => counter.CountAsync());

        cts.CancelAfter(50);
        Thread.Sleep(60);

        // Output:
        // canceled 3
        // canceled 2
        // canceled 1
    }
}
