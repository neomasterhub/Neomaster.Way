using System.Net.NetworkInformation;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    })
    .Build();

var mediator = builder.Services.GetRequiredService<IMediator>();

await mediator.Publish(new Ping());

builder.Run();
