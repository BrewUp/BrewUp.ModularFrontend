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
        return await HttpService.Get<IEnumerable<BeerJson>>(
            $"{AppConfiguration.PubsApiUri}v1/registries/beers");
    }
}