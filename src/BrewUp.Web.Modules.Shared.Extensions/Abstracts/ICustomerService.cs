using BrewUp.Web.Modules.Shared.Extensions.Dtos;

namespace BrewUp.Web.Modules.Shared.Extensions.Abstracts;

public interface ICustomerService
{
    Task<IEnumerable<CustomerJson>> GetCustomersAsync();
}