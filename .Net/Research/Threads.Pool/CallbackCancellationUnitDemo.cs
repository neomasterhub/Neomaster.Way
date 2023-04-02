using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class CallbackCancellationUnitDemo : UnitDemoBase
{
    private static string _resource = string.Empty;

    public CallbackCancellationUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static void Write(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _resource += '*';
            Thread.Sleep(10);
        }
    }

    [Fact]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        ThreadPool.QueueUserWorkItem(_ => Write(cts.Token));

        Thread.Sleep(100);
        cts.Cancel();

        Thread.Sleep(100);
        Output.WriteLine(_resource);
        Thread.Sleep(100);
        Output.WriteLine(_resource);

        // Output:
        // ********
        // ********
    }
}
