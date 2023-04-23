using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DEA.L2.ApplicationServices.EmailManager;

public static class Registrar
{
    public static IServiceCollection AddEmailManager(this IServiceCollection services) => services
        .AddScoped<IEmailService, EmailService>()
        .AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
}
