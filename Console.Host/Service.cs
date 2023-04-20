using Microsoft.Extensions.Configuration;

internal interface IFoo
{
    string Get();
}

internal class Foo : IFoo
{
    private readonly IConfiguration _configuration;

    public Foo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Get() => _configuration["Foo"];
}
