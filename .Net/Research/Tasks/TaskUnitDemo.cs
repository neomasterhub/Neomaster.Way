using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskUnitDemo : UnitDemoBase
{
    private static string _resource = string.Empty;

    public TaskUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static void CallbackCore(object state)
    {
        while (true)
        {
            _resource += state;
            Thread.Sleep(10);
        }
    }

    [Fact]
    public void Demo()
    {
        WaitCallback callback1 = state => CallbackCore(state);
        Action<object> callback2 = state => CallbackCore(state);

        Task.Run(() => callback1('-'));
        new Task(callback2, '|').Start();

        Thread.Sleep(100);

        Output.WriteLine(_resource);

        // Output:
        // |--||--||--
    }
}
