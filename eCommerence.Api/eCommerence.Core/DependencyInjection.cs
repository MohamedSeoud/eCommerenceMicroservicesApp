
using eCommerence.Core.IServicesContract;
using eCommerence.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerence.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserServices, UserService>();
        return services;

    }
}

