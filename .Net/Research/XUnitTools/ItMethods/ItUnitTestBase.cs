using Autofac;
using Autofac.Extras.Moq;
using Moq;
using XUnitTools.ItMethods.ActivityTypes;

namespace XUnitTools.ItMethods;

public class ItUnitTestBase
{
    protected readonly IService2 Sut;
    protected readonly Mock<IService1> Mock;

    public ItUnitTestBase()
    {
        Mock = new Mock<IService1>();

        var autoMock = AutoMock.GetLoose(
            builder =>
            {
                builder.RegisterMock(Mock);
                builder.RegisterType<Service2>().As<IService2>();
            });

        Sut = autoMock.Create<IService2>();
    }
}
