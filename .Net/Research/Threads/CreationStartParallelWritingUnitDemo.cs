using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Threads;

public class CreationStartParallelWritingUnitDemo : UnitDemoBase
{
    private static string _threadsOutput = string.Empty;

    public CreationStartParallelWritingUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    private void WriteChar(object value)
    {
        while (true)
        {
            _threadsOutput += value.ToString();
            Thread.Sleep(500);
        }
    }

    private void WriteStar()
    {
        while (true)
        {
            _threadsOutput += "*";
            Thread.Sleep(100);
        }
    }

    [Fact(DisplayName = "Creation, start, parallel writing")]
    public void Demo()
    {
        var th1 = new Thread(WriteStar);
        var th2 = new Thread(new ParameterizedThreadStart(WriteChar));

        th1.Start();
        th2.Start("@");

        int i = 50;
        while (i-- > 0)
        {
            _threadsOutput += ".";
            Thread.Sleep(20);
        }

        Output.WriteLine(_threadsOutput); // *.@...*...*....*...*..@.*...*...*...*...*.@..*....*...*...*...@*
    }
}
