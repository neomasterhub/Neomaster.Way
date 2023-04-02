using TestEngine6;
using Threads.Pool.ActivityTypes;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class CancelCancellationUnitDemo : UnitDemoBase
{
    public CancelCancellationUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "How to use CancellationToken.None")]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        var counter = new Counter(cts.Token);

        Output.WriteLine($"can be canceled: {counter.CancellationToken.CanBeCanceled}");
        counter.CancellationToken = CancellationToken.None;
        Output.WriteLine($"can be canceled: {counter.CancellationToken.CanBeCanceled}");

        ThreadPool.QueueUserWorkItem(_ => counter.CountAsync());
        cts.CancelAfter(50);

        Thread.Sleep(100);
        Output.WriteLine($"t1: {counter.Count}");
        Thread.Sleep(100);
        Output.WriteLine($"t2: {counter.Count}");

        // Output:
        // can be canceled: True
        // can be canceled: False
        // t1: 9
        // t2: 16
    }
}
