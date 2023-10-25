using BrewUp.Web.Modules.Pubs.Extensions.Abstracts;
using BrewUp.Web.Modules.Pubs.Extensions.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Web.Modules.Pubs.Extensions;

public static class PubsHelper
{
    public static IServiceCollection AddPubsModule(this IServiceCollection services)
    {
        services.AddScoped<IBeerService, BeerService>();

        return services;
    }
}