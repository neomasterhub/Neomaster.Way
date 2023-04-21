using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskResultUnitDemo : UnitDemoBase
{
    public TaskResultUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var task1 = Task<string>.Run(() =>
        {
            Thread.Sleep(100);

            return "test";
        });
        var task2 = Task.Run(() =>
        {
            Thread.Sleep(100);

            return "test";
        });

        var callback1Result = task1.Result;
        var callback2Result = task2.Result;

        Output.WriteLine(callback1Result);
        Output.WriteLine(callback2Result);

        // Output:
        // test
        // test
    }
}
