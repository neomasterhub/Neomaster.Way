using DEA.L1.Domain.Model.Providers;
using DEA.L2.ApplicationServices.EmailManager;
using Microsoft.Extensions.DependencyInjection;

namespace DEA.L3.Infrastructure.EmailProvider;

public static class Registrar
{
    public static IServiceCollection AddEmailProvider(this IServiceCollection services) => services
        .AddEmailManager()
        .AddScoped<IEmailProvider, EmailProvider>();
}
