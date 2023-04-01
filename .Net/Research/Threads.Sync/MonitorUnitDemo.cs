using System.Text;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Sync;

public class MonitorUnitDemo : UnitDemoBase
{
    private static readonly object _locked = new();
    private static readonly StringBuilder _resource = new();

    public MonitorUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static void Write(char c)
    {
        Monitor.Enter(_locked);

        for (int i = 0; i < 10; i++)
        {
            _resource.Append(c);
            Thread.Sleep(10); // To be executing when others start.
        }

        _resource.Append('\n');

        Monitor.Exit(_locked);
    }

    [Fact(DisplayName = "Sequential writing to a single resource")]
    public void Demo()
    {
        List<Thread> threads = new();

        for (var i = 'A'; i < 'F'; i++)
        {
            char c = i;
            threads.Add(new Thread(() => Write(c)));
        }

        threads.ForEach(th =>
        {
            th.Start();
            Thread.Sleep(10); // For order.
        });

        threads.ForEach(th => th.Join());

        Output.WriteLine(_resource.ToString());

        // Output:
        // AAAAAAAAAA
        // BBBBBBBBBB
        // CCCCCCCCCC
        // DDDDDDDDDD
        // EEEEEEEEEE
    }
}
