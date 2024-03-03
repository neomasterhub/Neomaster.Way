using Moq;
using Xunit;

namespace XUnitTools.ItMethods;

public class IsAnyUnitTests : ItUnitTestBase
{
    [Theory]
    [InlineData(null)]
    [InlineData(1)]
    [InlineData(2)]
    public void Test(int? arg)
    {
        var anyArgHasBeenPassedToService1 = false;
        Mock
            .Setup(m => m.Get1(It.IsAny<int?>()))
            .Callback(() => anyArgHasBeenPassedToService1 = true);

        Sut.Get2(arg);

        // 2 checks that the callback has been called:
        Assert.True(anyArgHasBeenPassedToService1);
        Mock.Verify(m => m.Get1(It.IsAny<int?>()), Times.Once);
    }
}
