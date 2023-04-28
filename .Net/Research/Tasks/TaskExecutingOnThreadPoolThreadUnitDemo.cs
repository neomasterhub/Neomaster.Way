using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskExecutingOnThreadPoolThreadUnitDemo : UnitDemoBase
{
    public TaskExecutingOnThreadPoolThreadUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        Task.Run(() => Output.WriteLine($"IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}"));

        // Output:
        // IsThreadPoolThread: True
    }
}
