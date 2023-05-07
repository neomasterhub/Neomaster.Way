using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinForms.ScopedVsTransient;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) => services
                .AddScoped<Form1>()
                .AddScoped<IScopedService, Service>()
                .AddTransient<ITransientService, Service>()
                .AddTransient<Client>())
            .Build();

        ServiceProvider = host.Services;

        Application.Run(host.Services.GetRequiredService<Form1>());
    }
}
