using System.Globalization;
using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads;

public class InfoUnitDemo : UnitDemoBase
{
    public InfoUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private void ThreadInfo()
    {
        Output.WriteLine($"id: {Thread.CurrentThread.ManagedThreadId}");
        Output.WriteLine($"name: {Thread.CurrentThread.Name}");
        Output.WriteLine($"culture: {Thread.CurrentThread.CurrentCulture.Name}");
        Output.WriteLine($"is background: {Thread.CurrentThread.IsBackground}");
        Output.WriteLine(string.Empty);
    }

    [Fact(DisplayName = "Thread info: id, name, culture, is background")]
    public void Demo()
    {
        var th = new Thread(() => ThreadInfo())
        {
            Name = "My Thread",
            CurrentCulture = new CultureInfo("fr-FR"),
        };

        th.Start();

        Thread.Sleep(500);

        ThreadInfo();

        // Output:
        //
        // id: 27
        // name: My Thread
        // culture: fr-FR
        // is background: False
        //
        // id: 15
        // name: .NET Long Running Task
        // culture: ru-RU
        // is background: True
    }
}
