using Autofac;
using Autofac.Extras.Moq;
using Moq;
using Xunit;
using XUnitTools.ItMethods.ActivityTypes;

namespace XUnitTools;

public class UnitTestsTemplate
{
    private readonly IService2 _sut;
    private readonly Mock<IService1> _mockService1;

    public UnitTestsTemplate()
    {
        _mockService1 = new Mock<IService1>();

        var autoMock = AutoMock.GetLoose(builder =>
        {
            builder.RegisterMock(_mockService1);
            builder.RegisterType<Service2>().As<IService2>();
        });

        _sut = autoMock.Create<IService2>();
    }

    [Fact]
    public void ShouldBeCreated()
    {
        Assert.NotNull(_sut);
        Assert.IsType<Service2>(_sut);
    }

    [Fact]
    public void ShouldGetService1Result()
    {
        // Arrange
        const int expected = 10;
        _mockService1
            .Setup(m => m.Get1(1))
            .Returns(expected);

        // Act
        var actual = _sut.Get2(1);

        // Assertion
        Assert.Equal(expected, actual);
    }
}
