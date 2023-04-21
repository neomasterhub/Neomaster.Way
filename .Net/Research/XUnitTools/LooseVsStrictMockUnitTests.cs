using Moq;
using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class LooseVsStrictMockUnitTests
{
    [Fact]
    public void Loose()
    {
        var sutMock = new Mock<IGetCurrentDatetimeInfoService>(MockBehavior.Loose);
        var sut = sutMock.Object;

        var actual = sut.GetDay();

        Assert.Equal(default(int), actual);
    }

    [Fact]
    public void Strict()
    {
        var sutMock = new Mock<IGetCurrentDatetimeInfoService>(MockBehavior.Strict);
        var sut = sutMock.Object;

        var actual = Record.Exception(() => sut.GetDay());

        Assert.IsType<MockException>(actual);

        // 'IGetCurrentDayService.GetDay() invocation failed with mock behavior Strict.
        // All invocations on the mock must have a corresponding setup.'
    }
}
