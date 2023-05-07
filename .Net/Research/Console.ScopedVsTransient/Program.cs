using Microsoft.Extensions.DependencyInjection;
using ScopedVsTransient;

var services = new ServiceCollection();
services.AddScoped<IScopedService, Service>();
services.AddTransient<ITransientService, Service>();
services.AddTransient<Client>();

var serviceProvider = services.BuildServiceProvider();

for (var i = 0; i < 3; i++)
{
    var scope = serviceProvider.CreateScope();

    var client1 = scope.ServiceProvider.GetRequiredService<Client>();
    var client2 = scope.ServiceProvider.GetRequiredService<Client>();

    Console.WriteLine(client.GetServicesInfo());
}
