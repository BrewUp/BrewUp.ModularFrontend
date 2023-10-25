using BrewUp.Web.Modules.Shared.Extensions.Abstracts;
using BrewUp.Web.Modules.Shared.Extensions.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Web.Modules.Shared.Extensions;

public static class SharedHelper
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IWarehouseService, WarehouseService>();

        return services;
    }
}