using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Queries.Get
{
    public class GetCustomerQuery : IMessage<GetCustomerQueryResult>
    {
        public int Id { get; set; }

        public GetCustomerQuery(int id)
        {
            Id = id;
        }
    }
}
