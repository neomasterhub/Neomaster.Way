namespace XUnitTools.ItMethods.ActivityTypes;

internal class Service2 : IService2
{
    private readonly IService1 _service1;

    public Service2(IService1 service1)
    {
        _service1 = service1;
    }

    public int? Get2(int? x) => _service1.Get1(x);
}
