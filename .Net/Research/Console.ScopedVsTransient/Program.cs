using Microsoft.Extensions.DependencyInjection;
using ScopedVsTransient;

var services = new ServiceCollection();
services.AddScoped<IScopedService, Service>();
services.AddTransient<ITransientService, Service>();
services.AddTransient<Client>();

var serviceProvider = services.BuildServiceProvider();

for (var i = 1; i <= 3; i++)
{
    Console.WriteLine($"SCOPE {i}\n");

    var scope = serviceProvider.CreateScope();

    var client1 = scope.ServiceProvider.GetRequiredService<Client>();
    var client2 = scope.ServiceProvider.GetRequiredService<Client>();

    client1.PrintServicesInfo();
    client2.PrintServicesInfo();
}
