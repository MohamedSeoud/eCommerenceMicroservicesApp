
using eCommerence.Core.IRepositoryContract;
using eCommerence.Infrastructure.DbContext;
using eCommerence.Infrastructure.RepositoryContract;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerence.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<DapperDbContext>();
        return services;

    }
}

