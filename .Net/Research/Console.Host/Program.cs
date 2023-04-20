using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        // ... hostContext.Configuration ...
        services.AddScoped<IFoo, Foo>();
    })
    .Build();

var foo = builder.Services.GetRequiredService<IFoo>();

Console.WriteLine(foo.Get()); // Bar

builder.Run();
