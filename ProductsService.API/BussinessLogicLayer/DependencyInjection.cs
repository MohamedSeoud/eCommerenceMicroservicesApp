using BusinessLogicLayer.Services;
using eCommerce.BusinessLogicLayer.Mappers;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using eCommerce.BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BussniessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBussinessLogicLayer(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);
        service.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();
        service.AddScoped<IProductsService, ProductsService>();
        return service;
    }

}
