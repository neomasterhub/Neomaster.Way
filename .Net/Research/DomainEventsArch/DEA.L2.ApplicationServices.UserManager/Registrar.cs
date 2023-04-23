using Microsoft.Extensions.DependencyInjection;

namespace DEA.L2.ApplicationServices.UserManager;

public static class Registrar
{
    public static IServiceCollection AddUserManager(this IServiceCollection services) => services
        .AddScoped<IUserService, UserService>();
}
