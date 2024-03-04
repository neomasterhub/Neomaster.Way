using Moq;
using Xunit;

namespace XUnitTools.ItMethods;

public class IsUnitTests : ItUnitTestBase
{
    [Fact]
    public void Test1()
    {
        var arg1HasBeenPassedToService1 = false;
        Mock
            .Setup(m => m.Get1(It.Is<int?>(x => x == 1)))
            .Callback(() => arg1HasBeenPassedToService1 = true);

        Sut.Get2(1);

        Assert.True(arg1HasBeenPassedToService1);
        Mock.Verify(m => m.Get1(It.Is<int?>(x => x == 1)), Times.Once);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void Test2(int? arg)
    {
        var argGt1HasBeenPassedToService1 = false;
        Mock
            .Setup(m => m.Get1(It.Is<int?>(x => x > 1)))
            .Callback(() => argGt1HasBeenPassedToService1 = true);

        Sut.Get2(arg);

        Assert.True(argGt1HasBeenPassedToService1);
        Mock.Verify(m => m.Get1(It.Is<int?>(x => x > 1)), Times.Once);
    }
}
