using assessment_platform_developer.Domain.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Interfaces.Customers
{
    public interface ICustomerQueryRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        ValueTask<Customer> GetAsync(int id);
    }
}
