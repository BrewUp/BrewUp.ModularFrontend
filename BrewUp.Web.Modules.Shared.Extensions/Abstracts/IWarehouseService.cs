using BrewUp.Web.Modules.Shared.Extensions.Dtos;

namespace BrewUp.Web.Modules.Shared.Extensions.Abstracts;

public interface IWarehouseService
{
    Task<IEnumerable<WarehouseJson>> GetWarehousesAsync();
}