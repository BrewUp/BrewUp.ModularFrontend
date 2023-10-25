using BrewUp.Web.Modules.Shared.Extensions.Abstracts;
using BrewUp.Web.Modules.Shared.Extensions.Dtos;

namespace BrewUp.Web.Modules.Shared.Extensions.Concretes;

public sealed class CustomerService : ICustomerService
{
    public async Task<IEnumerable<CustomerJson>> GetCustomersAsync()
    {
        var customers = new List<CustomerJson>
        {
            new()
            {
                CustomerId = Guid.NewGuid().ToString(),
                CustomerName = "Muflone Pub"
            }
        };

        return await Task.FromResult(customers);
    }
}