using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads;

public class JoinTimeoutUnitDemo : UnitDemoBase
{
    public JoinTimeoutUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "Joining a thread after timeout.")]
    public void Demo()
    {
        var output = string.Empty;
        var action = (char arg) =>
        {
            for (int i = 0; i < 100; i++)
            {
                output += arg;
                Thread.Sleep(10);
            }
        };

        var th1 = new Thread(() => action.Invoke('.'));
        var th2 = new Thread(() =>
        {
            th1.Join(200);
            action.Invoke('*');
        });
        var th3 = new Thread(() =>
        {
            th2.Join(400);
            action.Invoke('|');
        });

        th1.Start();
        th2.Start();
        th3.Start();
        th3.Join();

        Output.WriteLine(output[..60]);

        // Output:
        // ..............***..**..**..*.*..**.*.||..|**|..|*|..|*.*||*.
        //               ^ th2 timeout end      ^ th3 timeout end
    }
}
