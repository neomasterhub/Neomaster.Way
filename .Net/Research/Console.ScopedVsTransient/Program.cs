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

/*
SCOPE 1

Scoped    : e9fbe8ad-d83e-4165-8676-24a0f4b64624
Transient : c114b771-31e3-4876-8770-61624479d156

Scoped    : e9fbe8ad-d83e-4165-8676-24a0f4b64624
Transient : f7d660ce-dc86-4e81-9e22-751439165919

SCOPE 2

Scoped    : 40f9ac7b-85fc-4b33-91e6-687cc064ae76
Transient : 4e548562-f4e4-443b-b12d-e166076d87a0

Scoped    : 40f9ac7b-85fc-4b33-91e6-687cc064ae76
Transient : bbd6741b-148e-4c2b-b2fe-e56ecfce5027

SCOPE 3

Scoped    : c4347aed-1ff5-4444-919a-6f2a6d5a2593
Transient : 4e00a00a-80bd-4dbe-b949-b9ee93f73509

Scoped    : c4347aed-1ff5-4444-919a-6f2a6d5a2593
Transient : a1daa97e-5f20-4047-b45d-9747ee849fed
*/
