using BrewUp.Web.Modules.Pubs.Extensions.Abstracts;
using BrewUp.Web.Modules.Pubs.Extensions.Dtos;
using BrewUp.Web.Shared.Abstracts;
using BrewUp.Web.Shared.Concretes;
using BrewUp.Web.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace BrewUp.Web.Modules.Pubs.Extensions.Concretes;

public sealed class PubService : BaseHttpService, IPubService
{
    public PubService(HttpClient httpClient, IHttpService httpService, AppConfiguration appConfiguration,
        ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
    {
    }
    
    public async Task<IEnumerable<PubJson>> GetPubsAsync()
    {
        return await HttpService.Get<IEnumerable<PubJson>>(
            $"{AppConfiguration.PubsApiUri}v1/masterdata/pubs");
    }
}