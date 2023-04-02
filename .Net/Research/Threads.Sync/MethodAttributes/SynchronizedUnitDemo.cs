using System.Runtime.CompilerServices;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads.Sync.MethodAttributes;

public class SynchronizedUnitDemo : UnitDemoBase
{
    private static string _resource = string.Empty;

    public SynchronizedUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private void Write()
    {
        for (char c = 'A'; c < 'F'; c++)
        {
            _resource += c;
            Thread.Sleep(10);
        }

        _resource += ' ';
    }

    [Fact(DisplayName = "Sequential writing to a single resource")]
    public void Demo()
    {
        var threads = Enumerable.Range(1, 3)
            .Select(n => new Thread(Write))
            .ToList();

        threads.ForEach(th => th.Start());
        threads.ForEach(th => th.Join());

        Output.WriteLine(_resource);

        // Output:
        // ABCDE ABCDE ABCDE
    }
}
