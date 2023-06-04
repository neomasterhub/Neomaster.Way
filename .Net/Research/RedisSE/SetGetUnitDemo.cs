using StackExchange.Redis;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace RedisSE;

public class SetGetUnitDemo : UnitDemoBase
{
    public SetGetUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    /// <summary>
    /// Requires Redis to be running.
    /// </summary>
    [Fact]
    public void Demo()
    {
        var redis = ConnectionMultiplexer.Connect("localhost");
        var db = redis.GetDatabase();

        db.StringSet("x", "y", TimeSpan.FromMilliseconds(100));

        var y1 = db.StringGet("x");

        Thread.Sleep(200);

        var y2 = db.StringGet("x");

        Output.WriteLine($"x(t1): {y1}");
        Output.WriteLine($"x(t2): {y2}");

        // Output:
        // x(t1): y
        // x(t2):
    }
}
