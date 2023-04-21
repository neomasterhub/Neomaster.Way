using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WinForms.Host;

namespace DataManager;

internal static class Program
{
    public static IConfiguration Configuration;

    [STAThread]
    private static void Main()
    {
        Configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

        var services = new ServiceCollection();

        services
            .AddScoped<Form1>()
            .AddScoped<IFoo, Foo>();

        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        var form1 = serviceProvider.GetRequiredService<Form1>();
        Application.Run(form1);
    }
}
