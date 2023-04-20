using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskWaitUnitDemo : UnitDemoBase
{
    private static readonly Action<object> _callback = signal =>
    {
        while (true)
        {
            _resource += signal;
            Thread.Sleep(10);
        }
    };
    private static string _resource = string.Empty;

    public TaskWaitUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var cts = new CancellationTokenSource();
        Task.Run(() => cts.CancelAfter(200));

        var task1 = new Task(_callback, '-');
        var task2 = new Task(_callback, '|');

        task1.Start();
        task1.Wait(100);
        _resource += '*';

        task2.Start();
        try
        {
            task2.Wait(cts.Token);
        }
        catch (OperationCanceledException)
        {
            _resource += '*';
        }

        Output.WriteLine(_resource);
    }
}
