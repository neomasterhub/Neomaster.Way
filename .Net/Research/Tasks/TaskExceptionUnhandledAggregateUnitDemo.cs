using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskExceptionUnhandledAggregateUnitDemo : UnitDemoBase
{
    public TaskExceptionUnhandledAggregateUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var task = Task.Run(() => throw new StackOverflowException("unhandled"));

        try
        {
            task.Wait();
        }
        catch (AggregateException ae)
        {
            try
            {
                ae.Handle(ie => ie is ArithmeticException);
            }
            catch (AggregateException aeUnhandled)
            {
                Output.WriteLine(aeUnhandled.InnerExceptions[0].Message);
            }
        }

        // Output:
        // unhandled
    }
}
