using assessment_platform_developer.Domain.Customers;
using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Interfaces.Customers
{
    public interface ICustomerCommandRepository
    {
        Task<int> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
}
