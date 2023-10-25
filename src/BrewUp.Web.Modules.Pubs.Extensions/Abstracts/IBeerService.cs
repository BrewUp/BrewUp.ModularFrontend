using BrewUp.Web.Modules.Pubs.Extensions.Dtos;

namespace BrewUp.Web.Modules.Pubs.Extensions.Abstracts;

public interface IBeerService
{
    Task<IEnumerable<BeerJson>> GetBeersAsync();
}