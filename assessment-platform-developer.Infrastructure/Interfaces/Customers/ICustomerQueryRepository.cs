using assessment_platform_developer.Domain.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Interfaces.Customers
{
    public interface ICustomerQueryRepository
    {
        IEnumerable<Customer> GetAll();
        Task<Customer> GetAsync(int id);
    }
}
