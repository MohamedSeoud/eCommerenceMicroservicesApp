
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryContract;
using eCommerce.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                o => o.EnableStringComparisonTranslations() // Enable translations for StringComparison
            );
        });


        service.AddScoped<IProductRepository, ProductRepository>();
        return service;
    }

}
