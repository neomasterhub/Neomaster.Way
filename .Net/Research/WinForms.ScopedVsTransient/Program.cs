using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinForms.ScopedVsTransient;

internal static class Program
{
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

        Application.Run(host.Services.GetRequiredService<Form1>());
    }
}
