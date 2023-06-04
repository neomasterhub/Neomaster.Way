using StackExchange.Redis;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace RedisSE;

public class ConnectionFailedWithoutThrowingExceptionUnitDemo : UnitDemoBase
{
    public ConnectionFailedWithoutThrowingExceptionUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var getConnection = () => ConnectionMultiplexer.Connect("host", options =>
        {
            options.ConnectTimeout = 0;
            options.AbortOnConnectFail = false;
        });

        try
        {
            var connection = getConnection.Invoke();

            Output.WriteLine($"is connected: {connection.IsConnected}");
        }
        catch
        {
            Output.WriteLine("exception");
        }

        // Output:
        // is connected: False
    }
}
