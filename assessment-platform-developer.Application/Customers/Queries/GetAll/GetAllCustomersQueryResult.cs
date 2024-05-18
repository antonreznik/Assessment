using assessment_platform_developer.Application.Customers.Dto;
using assessment_platform_developer.Domain.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;
using System.Collections.Generic;
using System.Linq;

namespace assessment_platform_developer.Application.Customers.Queries.GetAll
{
    public class GetAllCustomersQueryResult : IMessageResult
    {
        public List<CustomerViewModel> Customers { get; private set; }

        public GetAllCustomersQueryResult(IEnumerable<Customer> customers)
        {
            Customers = customers.Select(c => new CustomerViewModel(c)).ToList();
        }
    }
}
