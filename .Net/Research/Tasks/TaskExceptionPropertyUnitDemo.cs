using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskExceptionPropertyUnitDemo : UnitDemoBase
{
    public TaskExceptionPropertyUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var task = Task.Run(() =>
        {
            Thread.Sleep(50);
            throw new StackOverflowException("test");
        });

        Output.WriteLine($"task.Exception: {task.Exception}");

        Thread.Sleep(100);

        Output.WriteLine($"task.Exception: {task.Exception?.InnerExceptions[0].Message}");

        // Output:
        // task.Exception:
        // task.Exception: test
    }
}
