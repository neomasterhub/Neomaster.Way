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

        Output.WriteLine(th.IsAlive.ToString()); // False

        th.Start();
        Thread.Sleep(100);

        Output.WriteLine(th.IsAlive.ToString()); // True

        Thread.Sleep(300);

        Output.WriteLine(th.IsAlive.ToString()); // False
    }
}
