using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class TrySetForegroundUnitDemo : UnitDemoBase
{
    private static string _resource = string.Empty;

    public TrySetForegroundUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "Failed to set thread pool thread to foreground")]
    public void Demo()
    {
        WaitCallback callback = state =>
        {
            Thread.CurrentThread.IsBackground = false;

            while (true)
            {
                _resource += state;
                Thread.Sleep(10);
            }
        };

        if (ThreadPool.QueueUserWorkItem(callback, "+"))
        {
            Thread.Sleep(100);
        }

        Output.WriteLine(_resource);

        // Output:
        // ++++++++
    }
}
