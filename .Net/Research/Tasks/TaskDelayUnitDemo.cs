using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskDelayUnitDemo : UnitDemoBase
{
    private static readonly Action _endlessDotWriter = () =>
    {
        while (true)
        {
            Thread.Sleep(10);
            _resource += '.';
        }
    };
    private static readonly Action _endlessIdle = () =>
    {
        while (true)
        {
        }
    };
    private static string _resource = string.Empty;

    public TaskDelayUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        Task.Run(_endlessDotWriter);

        _resource += '<';

        Task.Delay(100).Wait();

        _resource += '>';

        _resource += '<';

        Task.Run(_endlessIdle).Wait(100);

        _resource += '>';

        Output.WriteLine(_resource);

        // Output:
        // <.......><.......>
    }
}
