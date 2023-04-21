using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinForms.Host;

namespace DataManager;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // ... hostContext.Configuration ...
                services
                    .AddScoped<Form1>()
                    .AddScoped<IFoo, Foo>();
            })
            .Build();

        Application.Run(host.Services.GetRequiredService<Form1>());
    }
}
