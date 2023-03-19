using Xunit.Abstractions;

namespace TestEngine6;

public abstract class UnitDemoBase
{
    protected readonly ITestOutputHelper Output;

    public UnitDemoBase(ITestOutputHelper output)
    {
        Output = output;
    }
}
