using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class BackgroundUnitDemo : UnitDemoBase
{
    private static string _resource = string.Empty;

    public BackgroundUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "Thread pool thread is always background")]
    public void Demo()
    {
        WaitCallback callback = state =>
        {
            while (true)
            {
                _resource += state;
                Thread.Sleep(10);
            }
        };

        if (ThreadPool.QueueUserWorkItem(callback, "*"))
        {
            Thread.Sleep(100);
        }

        Output.WriteLine(_resource);

        // Output:
        // *******
    }
}
