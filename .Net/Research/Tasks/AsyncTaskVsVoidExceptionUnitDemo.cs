using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncTaskVsVoidExceptionUnitDemo : UnitDemoBase
{
    private static bool _asyncTaskAfterSignal;
    private static bool _asyncVoidAfterSignal;

    public AsyncTaskVsVoidExceptionUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static async Task AsyncTask()
    {
        await Task.Run(() => throw new ArithmeticException());
    }

    private static async void AsyncVoid()
    {
        await Task.Run(() => throw new ArithmeticException());
    }

    [Fact(DisplayName = "Should be failed")]
    public async Task Demo()
    {
        try
        {
            await AsyncTask();
            _asyncTaskAfterSignal = true;
        }
        catch (ArithmeticException)
        {
            Output.WriteLine("task ex");
        }

        try
        {
            AsyncVoid();
            _asyncVoidAfterSignal = true;
        }
        catch (ArithmeticException)
        {
            Output.WriteLine("void ex");
        }

        Thread.Sleep(1000);

        Output.WriteLine($"{nameof(_asyncTaskAfterSignal)}: {_asyncTaskAfterSignal}");
        Output.WriteLine($"{nameof(_asyncVoidAfterSignal)}: {_asyncVoidAfterSignal}");

        // Output:
        // task ex
        // _asyncTaskAfterSignal: False
        // _asyncVoidAfterSignal: True
    }
}
