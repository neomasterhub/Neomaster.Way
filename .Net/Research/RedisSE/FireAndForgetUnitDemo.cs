﻿using StackExchange.Redis;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace RedisSE;

public class FireAndForgetUnitDemo : UnitDemoBase
{
    public FireAndForgetUnitDemo(ITestOutputHelper output)
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

        var a = db.StringSet("a", "A", TimeSpan.FromSeconds(2));
        var b = db.StringSet("b", "B", TimeSpan.FromSeconds(2), flags: CommandFlags.FireAndForget);

        Output.WriteLine($"a was set: {a}");
        Output.WriteLine($"b was set: {b}");

        // Output:
        // a was set: True
        // b was set: False
    }
}
