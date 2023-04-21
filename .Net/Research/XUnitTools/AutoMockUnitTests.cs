using Autofac.Extras.Moq;
using Moq;
using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class AutoMockUnitTests
{
    private static readonly int[] _expected = { 10, 20 };
    private static int _expectedIndex;
    private readonly AutoMock _autoMock;

    public AutoMockUnitTests()
    {
        var sutMock = new Mock<IGetCurrentDayService>();
        var expected = _expected[_expectedIndex];
        sutMock
            .Setup(m => m.Get())
            .Returns(expected);

        _autoMock = AutoMock.GetLoose(builder =>
        {
            builder.RegisterMock(sutMock);
        });

        _expectedIndex++;
    }

    [Fact]
    public void Test1()
    {
        var actual = _autoMock.Mock<IGetCurrentDayService>().Object.Get();

        Assert.Equal(10, actual);
    }

    [Fact]
    public void Test2()
    {
        var actual = _autoMock.Mock<IGetCurrentDayService>().Object.Get();

        Assert.Equal(20, actual);
    }
}
