using DEA.L1.Domain.Model.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DEA.L3.Infrastructure.DAL;

public static class Registrar
{
    public static IServiceCollection AddDAL(this IServiceCollection services) => services
        .AddScoped<DBContext>()
        .AddScoped(typeof(IRepository<>), typeof(Repository<>));
}
