using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class AsyncAwaitLockUnitDemo : UnitDemoBase
{
    private static readonly object _lock = new object();
    private static readonly Random _random = new Random();
    private static readonly char[] _threadIds = { '.', '*', '#', '$', '@' };
    private static string _signals = string.Empty;
    private static string _safeSignals = string.Empty;

    public AsyncAwaitLockUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        foreach (var threadId in _threadIds)
        {
            Task.Run(() =>
            {
                for (var j = 1; j <= 5; j++)
                {
                    _signals += threadId;
                    Thread.Sleep(_random.Next(10, 200));
                }

                lock (_lock)
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
                }
            });
        }

        Thread.Sleep(3000);

        Output.WriteLine(_signals);
        Output.WriteLine(_safeSignals);

        // Output
        // *@.#$*#$..@*#.@.$[1#23@45]*#[1234$5][12345$][12345][12345]
        // [12345][12345][12345][12345][12345]
    }
}
