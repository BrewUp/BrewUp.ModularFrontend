using BrewUp.Web.Modules.Production.Extensions.Abstracts;
using BrewUp.Web.Modules.Production.Extensions.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Web.Modules.Production.Extensions;

public static class ProductionHelper
{
	public static IServiceCollection AddProductionModule(this IServiceCollection services)
	{
		services.AddScoped<IProductionService, ProductionService>();

		return services;
	}
}