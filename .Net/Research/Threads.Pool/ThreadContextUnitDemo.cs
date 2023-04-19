using TestEngine6;
using Threads.Pool.ActivityTypes;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Pool;

public class ThreadContextUnitDemo : UnitDemoBase
{
    private static readonly string _contextDataName = "parent status";
    private static readonly WaitCallback _callback = state =>
    {
        while (true)
        {
            _resource += CallContext<ContextData>.GetData(_contextDataName).Id;

            Thread.Sleep(10);
        }
    };
    private static string _resource = string.Empty;

    public ThreadContextUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        CallContext<ContextData>.SetData(_contextDataName, new ContextData(1));

        if (ThreadPool.QueueUserWorkItem(_callback))
        {
            Thread.Sleep(50);

            _resource += '*';
            CallContext<ContextData>.SetData(_contextDataName, new ContextData(2));

            Thread.Sleep(50);
        }

        Output.WriteLine(_resource);

        // Output:
        // 11111*1111
    }

    private class ContextData
    {
        public ContextData(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
