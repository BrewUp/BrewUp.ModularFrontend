using BrewUp.Web.Modules.Production.Extensions.Abstracts;
using BrewUp.Web.Modules.Production.Extensions.Dtos;
using BrewUp.Web.Shared.Abstracts;
using BrewUp.Web.Shared.Concretes;
using BrewUp.Web.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace BrewUp.Web.Modules.Production.Extensions.Concretes;

internal sealed class ProductionService : BaseHttpService, IProductionService
{
    public ProductionService(HttpClient httpClient, IHttpService httpService, AppConfiguration appConfiguration,
        ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
    {
    }

    public async Task<IEnumerable<ProductionOrderJson>> GetProductionOrdersAsync()
    {
        try
        {
            return await HttpService.Get<IEnumerable<ProductionOrderJson>>(
                $"{AppConfiguration.ProductionApiUri}v1/production");
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }

    public async Task SendStartProductionOrderAsync(OrderJson order)
    {
        try
        {
            await HttpService.Post($"{AppConfiguration.ProductionApiUri}v1/production/beers/brew", order);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }

    public async Task SendCompleteProductionOrderAsync(OrderJson order)
    {
        try
        {
            await HttpService.Put($"{AppConfiguration.ProductionApiUri}v1/production/beers/brew/{order.BatchNumber}",
                order);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }

    public async Task<IEnumerable<BeerLookupJson>> GetBeersAsync()
    {
        try
        {
            return await HttpService.Get<IEnumerable<BeerLookupJson>>(
                $"{AppConfiguration.ProductionApiUri}v1/production/beers");
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}