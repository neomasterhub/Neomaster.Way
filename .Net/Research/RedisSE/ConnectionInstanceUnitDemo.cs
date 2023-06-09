﻿using System.Text.Json;
using StackExchange.Redis;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace RedisSE;

public class ConnectionInstanceUnitDemo : UnitDemoBase
{
    public ConnectionInstanceUnitDemo(ITestOutputHelper output)
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

        Output.WriteLine(JsonSerializer.Serialize(redis, new JsonSerializerOptions { WriteIndented = true }));

        // Output:
        // {
        //   "PreserveAsyncOrder": false,
        //   "IncludeDetailInExceptions": true,
        //   "IncludePerformanceCountersInExceptions": false,
        //   "TimeoutMilliseconds": 5000,
        //   "ClientName": "PC-WHITE(SE.Redis-v2.6.111.64013)",
        //   "Configuration": "localhost",
        //   "IsConnected": true,
        //   "IsConnecting": false,
        //   "OperationCount": 12,
        //   "StormLogThreshold": 15
        // }
    }
}
