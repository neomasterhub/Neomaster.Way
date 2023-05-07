using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinForms.ScopedVsTransient;

internal static class Program
{
    private static IServiceProvider _serviceProvider;

    public static IServiceProvider ScopeServiceProvider => _serviceProvider.CreateScope().ServiceProvider;

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) => services

                // Forms
                .AddSingleton<Form1>()
                .AddTransient<ClientForm>()

                // Services
                .AddScoped<IScopedService, Service>()
                .AddTransient<ITransientService, Service>()
                .AddTransient<Client>())
            .Build();

        _serviceProvider = host.Services;

        Application.Run(host.Services.GetRequiredService<Form1>());
    }
}
