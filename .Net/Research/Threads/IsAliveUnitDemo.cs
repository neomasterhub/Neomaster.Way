using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads;

public class IsAliveUnitDemo : UnitDemoBase
{
    public IsAliveUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "IsAlive in different thread life states")]
    public void Demo()
    {
        var th = new Thread(() => Thread.Sleep(200));

        Output.WriteLine($"Not started: {th.IsAlive}");

        th.Start();
        Thread.Sleep(100);

        Output.WriteLine($"Executing: {th.IsAlive}");

        Thread.Sleep(300);

        Output.WriteLine($"Executed: {th.IsAlive}");

        // Output:
        // Before start: False
        // Executing: True
        // Executed: False
    }
}
