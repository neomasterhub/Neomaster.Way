using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class DisposableTestingUnitTests : IDisposable
{
    private readonly Stacks _stacks;

    public DisposableTestingUnitTests()
    {
        _stacks = new Stacks();
    }

    public void Dispose()
    {
        _stacks.Dispose();
    }

    [Fact]
    public void Test1()
    {
        Stacks.Ints.Add(1);
        Assert.Single(Stacks.Ints);
    }

    [Fact]
    public void Test2()
    {
        Stacks.Ints.Add(1);
        Assert.Single(Stacks.Ints);
    }

    [Fact]
    public void Test3()
    {
        Stacks.Ints.Add(1);
        Assert.Single(Stacks.Ints);
    }
}
