using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncParallelVoidsUnitDemo : UnitDemoBase
{
    private static readonly CancellationTokenSource _cts = new();
    private static readonly Action<char> _endlessWriter = c =>
    {
        while (!_cts.Token.IsCancellationRequested)
        {
            Thread.Sleep(10);
            _resource += c;
        }
    };
    private static string _resource = string.Empty;

    public AsyncParallelVoidsUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static async void Async1()
    {
        await Task.Run(() => _endlessWriter('.'));
    }

    private static async void Async2()
    {
        await Task.Run(() => _endlessWriter('*'));
    }

    [Fact]
    public void Demo()
    {
        Async1();
        Async2();

        Thread.Sleep(200);
        _cts.Cancel();

        Output.WriteLine(_resource);

        // Output:
        // **.*..***...*.*.**.
    }
}
