using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads;

public class JoinUnitDemo : UnitDemoBase
{
    public JoinUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "Sequential writing by joined threads")]
    public void Demo()
    {
        var output = string.Empty;
        var action = (char arg) =>
        {
            for (int i = 0; i < 5; i++)
            {
                output += arg;
            }
        };
        var th1 = new Thread(() => action.Invoke('*'));
        var th2 = new Thread(() =>
        {
            th1.Join();
            action.Invoke('.');
        });

        th1.Start();
        th2.Start();
        th2.Join();

        Output.WriteLine(output); // *****.....
    }
}
