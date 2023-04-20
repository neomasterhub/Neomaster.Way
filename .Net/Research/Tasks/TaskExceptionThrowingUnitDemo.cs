using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskExceptionThrowingUnitDemo : UnitDemoBase
{
    public TaskExceptionThrowingUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var task1 = Task.Run(() => throw new StackOverflowException("test 1"));
        var task2 = Task.Run(() => throw new StackOverflowException("test 2"));

        try
        {
            task1.Wait();
        }
        catch (AggregateException ae)
        {
            foreach (var ie in ae.InnerExceptions)
            {
                if (ie is StackOverflowException)
                {
                    Output.WriteLine(ie.Message); // handling
                }
                else
                {
                    throw; // unhandled
                }
            }
        }

        // Output:
        // test 1
    }
}
