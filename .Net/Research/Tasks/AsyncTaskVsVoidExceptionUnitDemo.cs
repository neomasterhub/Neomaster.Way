using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncTaskVsVoidExceptionUnitDemo : UnitDemoBase
{
    public AsyncTaskVsVoidExceptionUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static async void AsyncVoid()
    {
        await Task.Run(() => throw new ArithmeticException());
    }

    private static async Task AsyncTask()
    {
        await Task.Run(() => throw new ArithmeticException());
    }

    [Fact(DisplayName = "Should be failed")]
    public void Demo()
    {
        try
        {
            _ = AsyncTask();
        }
        catch (ArithmeticException)
        {
            Output.WriteLine("task ex");
        }

        try
        {
            AsyncVoid();
        }
        catch (ArithmeticException)
        {
            Output.WriteLine("void ex");
        }

        // Output:
        // System.ArithmeticException : Overflow or underflow in the arithmetic operation.
        // ... line 16
    }
}
