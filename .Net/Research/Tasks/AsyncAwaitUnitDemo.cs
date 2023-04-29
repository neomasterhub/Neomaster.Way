using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncAwaitUnitDemo : UnitDemoBase
{
    private static readonly Action _endlessDotWriter = () =>
    {
        while (true)
        {
            Thread.Sleep(10);
            _resource += '.';
        }
    };
    private static string _resource = string.Empty;

    public AsyncAwaitUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public async void Demo()
    {
        _ = Task.Run(_endlessDotWriter); // to avoid the warning

        _resource += '<';
        await Task.Delay(100);
        _resource += '>';

        _resource += '[';
        await Task.Delay(100);
        _resource += ']';

        Output.WriteLine(_resource);

        // Output:
        // <.......>[.......]
    }
}
