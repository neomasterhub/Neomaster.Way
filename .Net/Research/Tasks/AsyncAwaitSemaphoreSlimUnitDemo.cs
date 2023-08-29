using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncAwaitSemaphoreSlimUnitDemo : UnitDemoBase
{
    private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
    private static readonly Random _random = new Random();
    private static readonly char[] _threadIds = { '.', '*', '#', '$', '@' };
    private static string _signals = string.Empty;
    private static string _safeSignals = string.Empty;

    public AsyncAwaitSemaphoreSlimUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private static async Task ActionAsync()
    {
        _signals += '[';
        _safeSignals += '[';

        for (var j = 1; j <= 5; j++)
        {
            _signals += j;
            _safeSignals += j;
            Thread.Sleep(_random.Next(10, 200));
        }

        _signals += ']';
        _safeSignals += ']';

        await Task.CompletedTask;
    }

    [Fact]
    public void Demo()
    {
        foreach (var threadId in _threadIds)
        {
            Task.Run(async () =>
            {
                for (var j = 1; j <= 5; j++)
                {
                    _signals += threadId;
                    Thread.Sleep(_random.Next(10, 200));
                }

                await _semaphoreSlim.WaitAsync();
                try
                {
                    await ActionAsync();
                }
                finally
                {
                    _semaphoreSlim.Release();
                }
            });
        }

        Thread.Sleep(3000);

        Output.WriteLine(_signals);
        Output.WriteLine(_safeSignals);

        // Output
        // .*@$##@#@$.##*.$[1@*2$.*$345][12345][12345][12345][12345]
        // [12345][12345][12345][12345][12345]
    }
}
