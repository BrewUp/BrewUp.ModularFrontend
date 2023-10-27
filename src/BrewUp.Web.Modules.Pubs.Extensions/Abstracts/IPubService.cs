using BrewUp.Web.Modules.Pubs.Extensions.Dtos;

namespace BrewUp.Web.Modules.Pubs.Extensions.Abstracts;

public interface IPubService
{
    Task<IEnumerable<PubJson>> GetPubsAsync();
}