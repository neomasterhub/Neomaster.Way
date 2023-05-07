namespace Console.ScopedVsTransient;

internal interface IService
{
    string GetInfo();
}

internal interface IScopedService : IService
{
}

internal interface ITransientService : IService
{
}

internal class Service : IScopedService, ITransientService
{
    private readonly Guid _guid;

    public Service()
    {
        _guid = Guid.NewGuid();
    }

    public string GetInfo()
    {
        return _guid.ToString();
    }
}
