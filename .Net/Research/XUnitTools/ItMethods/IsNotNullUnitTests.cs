using Moq;
using Xunit;

namespace XUnitTools.ItMethods;

public class IsNotNullUnitTests : ItUnitTestBase
{
    [Fact]
    public void Test1()
    {
        var notNullHasBeenPassedToService1 = false;
        Mock
            .Setup(m => m.Get1(It.IsNotNull<int?>()))
            .Callback(() => notNullHasBeenPassedToService1 = true);

        Sut.Get2(1);

        Assert.True(notNullHasBeenPassedToService1);
        Mock.Verify(m => m.Get1(It.IsNotNull<int?>()), Times.Once);
    }

    [Fact]
    public void Test2()
    {
        var notNullHasBeenPassedToService1 = false;
        Mock
            .Setup(m => m.Get1(It.IsNotNull<int?>()))
            .Callback(() => notNullHasBeenPassedToService1 = true);

        Sut.Get2(null);

        Assert.False(notNullHasBeenPassedToService1);
        Mock.Verify(m => m.Get1(It.IsNotNull<int?>()), Times.Never);
    }
}
