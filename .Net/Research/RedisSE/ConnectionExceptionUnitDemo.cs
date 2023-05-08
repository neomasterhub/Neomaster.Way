using StackExchange.Redis;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace RedisSE;

public class ConnectionExceptionUnitDemo : UnitDemoBase
{
    public ConnectionExceptionUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var getConnection = () => ConnectionMultiplexer.Connect("host", options => options.ConnectTimeout = 0);

        try
        {
            getConnection.Invoke();
        }
        catch (Exception e)
        {
            var eTypeName = e.GetType().Name;

            Output.WriteLine($"exception type: {eTypeName}");
            Output.WriteLine($"exception message: {e.Message}");
        }

        // Output:
        // exception type: RedisConnectionException
        // exception message: It was not possible to connect to the redis server(s).
        // Error connecting right now.
        // To allow this multiplexer to continue retrying until it's able to connect,
        // use abortConnect=false in your connection string or AbortOnConnectFail=false; in your code.
    }
}
