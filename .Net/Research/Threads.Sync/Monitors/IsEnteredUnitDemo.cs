using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Sync.Monitors;

public class IsEnteredUnitDemo : UnitDemoBase
{
    private static readonly object _locked = new();

    public IsEnteredUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "Monitor.IsEntered() before/in/after lock")]
    public void Demo()
    {
        var beforeLock = false;
        var inLock = false;
        var afterLock = false;

        var thread = new Thread(() =>
        {
            beforeLock = Monitor.IsEntered(_locked);

            lock (_locked)
            {
                inLock = Monitor.IsEntered(_locked);
            }

            afterLock = Monitor.IsEntered(_locked);
        });

        thread.Start();
        thread.Join();

        Output.WriteLine($"Before lock: {beforeLock}");
        Output.WriteLine($"In lock: {inLock}");
        Output.WriteLine($"Before lock: {afterLock}");

        // Output:
        // Before lock: False
        // In lock: True
        // Before lock: False
    }
}
