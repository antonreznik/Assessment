using assessment_platform_developer.Domain.Customers;

namespace assessment_platform_developer.Infrastructure.Interfaces.Customers
{
    public interface ICustomerCommandRepository
    {
        int Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
