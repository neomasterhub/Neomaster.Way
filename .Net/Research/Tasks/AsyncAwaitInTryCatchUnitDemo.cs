using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncAwaitInTryCatchUnitDemo : UnitDemoBase
{
    public AsyncAwaitInTryCatchUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public async void Demo()
    {
        try
        {
            await Task.Run(() => throw new ArithmeticException("test"));
        }
        catch (ArithmeticException e)
        {
            Output.WriteLine(e.Message);
        }

        // Output:
        // test
    }
}
