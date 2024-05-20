using assessment_platform_developer.Domain.Customers;
using System.Collections.Generic;

namespace assessment_platform_developer.Infrastructure.Interfaces.Customers
{
    public interface ICustomerQueryRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
    }
}
