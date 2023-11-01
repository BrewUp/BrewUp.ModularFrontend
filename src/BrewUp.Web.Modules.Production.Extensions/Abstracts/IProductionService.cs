using BrewUp.Web.Modules.Production.Extensions.Dtos;

namespace BrewUp.Web.Modules.Production.Extensions.Abstracts;

public interface IProductionService
{
	Task<IEnumerable<ProductionOrderJson>> GetProductionOrdersAsync();
	Task CloseProductionOrderAsync(string productionOrderId);
}