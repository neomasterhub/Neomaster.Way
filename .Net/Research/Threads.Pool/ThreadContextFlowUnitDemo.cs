using TestEngine6;
using Threads.Pool.ActivityTypes;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class ThreadContextFlowUnitDemo : UnitDemoBase
{
    private static readonly string _contextDataName = "parent status";
    private static readonly WaitCallback _callback = state =>
    {
        _resource += CallContext<int>.GetData(_contextDataName);
    };
    private static string _resource = string.Empty;

    public ThreadContextFlowUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        CallContext<int>.SetData(_contextDataName, 1);

        ExecutionContext.SuppressFlow();
        ThreadPool.QueueUserWorkItem(_callback);
        Thread.Sleep(10);

        ExecutionContext.RestoreFlow();
        ThreadPool.QueueUserWorkItem(_callback);
        Thread.Sleep(10);

        Output.WriteLine(_resource);

        // Output:
        // 01
    }
}
