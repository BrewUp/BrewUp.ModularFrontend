using BrewUp.Web.Modules.Shared.Extensions.Abstracts;
using BrewUp.Web.Modules.Shared.Extensions.Dtos;

namespace BrewUp.Web.Modules.Shared.Extensions.Concretes;

public sealed class WarehouseService : IWarehouseService
{
    public async Task<IEnumerable<WarehouseJson>> GetWarehousesAsync()
    {
        var warehouses = new List<WarehouseJson>
        {
            new()
            {
                WarehouseId = Guid.NewGuid().ToString(),
                WarehouseName = "BeerShop"
            }
        };

        return await Task.FromResult(warehouses);
    }
}