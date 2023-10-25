using BrewUp.Web.Modules.Pubs.Extensions.Abstracts;
using BrewUp.Web.Modules.Pubs.Extensions.Dtos;
using BrewUp.Web.Shared.Abstracts;
using BrewUp.Web.Shared.Concretes;
using BrewUp.Web.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace BrewUp.Web.Modules.Pubs.Extensions.Concretes;

internal sealed class BeerService : BaseHttpService, IBeerService
{
    public BeerService(HttpClient httpClient,
        IHttpService httpService,
        AppConfiguration appConfiguration,
        ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
    {
    }

    public async Task<IEnumerable<BeerJson>> GetBeersAsync()
    {
        try
        {
            var beers = new List<BeerJson>
            {
                new()
                {
                    BeerId = Guid.NewGuid().ToString(),
                    BeerName = "Muflone IPA",
                    Quantity = 10
                },
                new()
                {
                    BeerId = Guid.NewGuid().ToString(),
                    BeerName = "Muflone Weiss",
                    Quantity = 5
                },
                new()
                {
                    BeerId = Guid.NewGuid().ToString(),
                    BeerName = "Muflone RED",
                    Quantity = 30
                }
            };

            return await Task.FromResult(beers);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}