using BrewUp.Web.Modules.Production.Extensions.Abstracts;
using BrewUp.Web.Modules.Production.Extensions.Dtos;
using BrewUp.Web.Shared.Abstracts;
using BrewUp.Web.Shared.Concretes;
using BrewUp.Web.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace BrewUp.Web.Modules.Production.Extensions.Concretes;

public sealed class ProductionService : BaseHttpService, IProductionService
{
	public ProductionService(HttpClient httpClient,
		IHttpService httpService,
		AppConfiguration appConfiguration,
		ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
	{
	}

	public async Task<IEnumerable<ProductionOrderJson>> GetProductionOrdersAsync()
	{
		return await HttpService.Get<IEnumerable<ProductionOrderJson>>(
			$"{AppConfiguration.PubsApiUri}v1/production");
	}

	public async Task CloseProductionOrderAsync(string productionOrderId)
	{
		await HttpService.Put($"{AppConfiguration.PubsApiUri}v1/production/complete", productionOrderId);
	}
}