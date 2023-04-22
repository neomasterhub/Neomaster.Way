using Moq;
using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class LooseVsStrictUnitTests
{
    [Fact]
    public void Loose()
    {
        var sutMock = new Mock<IGetCurrentDayService>(MockBehavior.Loose);
        var sut = sutMock.Object;

        var actual = sut.Get();

        Assert.Equal(default(int), actual);
    }

    [Fact]
    public void Strict()
    {
        var sutMock = new Mock<IGetCurrentDayService>(MockBehavior.Strict);
        var sut = sutMock.Object;

        var actual = Record.Exception(() => sut.Get());

        Assert.IsType<MockException>(actual);

        // 'IGetCurrentDayService.GetDay() invocation failed with mock behavior Strict.
        // All invocations on the mock must have a corresponding setup.'
    }
}
