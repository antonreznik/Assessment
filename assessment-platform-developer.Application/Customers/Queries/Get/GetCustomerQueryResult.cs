using assessment_platform_developer.Application.Customers.Dto;
using assessment_platform_developer.Domain.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Queries.Get
{
    public class GetCustomerQueryResult : IMessageResult
    {
        public CustomerViewModel Customer { get; private set; }

        public GetCustomerQueryResult(Customer customer)
        {
            Customer = new CustomerViewModel(customer);
        }
    }
}
