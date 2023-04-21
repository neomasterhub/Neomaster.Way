using Autofac.Extras.Moq;
using Moq;
using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class AutoMockUnitTests
{
    private readonly AutoMock _autoMock;

    public AutoMockUnitTests()
    {
        var sutMock = new Mock<IGetCurrentDayService>(MockBehavior.Strict);
        sutMock
            .Setup(m => m.Get())
            .Returns(1);

        _autoMock = AutoMock.GetLoose(builder =>
        {
            builder.RegisterMock(sutMock);
        });
    }

    [Fact]
    public void Test()
    {
        var actual = _autoMock.Mock<IGetCurrentDayService>().Object.Get();

        Assert.Equal(1, actual);
    }
}
