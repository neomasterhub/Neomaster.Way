using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DEA.L2.ApplicationServices.Audit;

public static class Regisatrar
{
    public static IServiceCollection AddAudit(this IServiceCollection services) => services
        .AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
}
