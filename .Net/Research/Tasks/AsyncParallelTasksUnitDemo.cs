using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncParallelTasksUnitDemo : UnitDemoBase
{
    private static readonly Action<char> _endlessWriter = c =>
    {
        while (true)
        {
            Thread.Sleep(10);
            _resource += c;
        }
    };
    private static string _resource = string.Empty;

    public AsyncParallelTasksUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static async Task Async1()
    {
        await Task.Run(() => _endlessWriter('.'));
    }

    private static async Task Async2()
    {
        await Task.Run(() => _endlessWriter('*'));
    }

    [Fact]
    public void Demo()
    {
        _ = Async1();
        _ = Async2();

        Thread.Sleep(200);

        Output.WriteLine(_resource);

        // Output:
        // **.*..***...*.*.**.
    }
}
