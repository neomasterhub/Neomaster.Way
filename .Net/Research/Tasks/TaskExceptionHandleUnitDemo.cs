﻿using TestEngine6;
using Xunit;
using Xunit.Abstractions;

namespace Tasks;

public class TaskExceptionHandleUnitDemo : UnitDemoBase
{
    public TaskExceptionHandleUnitDemo(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void Demo()
    {
        var task = Task.Run(() => throw new StackOverflowException("test"));

        try
        {
            task.Wait();
        }
        catch (AggregateException ae)
        {
            try
            {
                ae.Handle(ie =>
                {
                    var handled = ie is StackOverflowException;

                    if (handled)
                    {
                        Output.WriteLine(ie.Message);
                    }

                    return handled;
                });
            }
            catch
            {
                throw; // unhandled
            }
        }

        // Output:
        // test
    }
}
