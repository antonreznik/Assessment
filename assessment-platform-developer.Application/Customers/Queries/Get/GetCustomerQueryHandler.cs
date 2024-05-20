using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Queries.Get
{
    public class GetCustomerQueryHandler : IMessageHandler<GetCustomerQuery, GetCustomerQueryResult>
    {
        private readonly ICustomerQueryRepository _repository;

        public GetCustomerQueryHandler(ICustomerQueryRepository repository)
        {
            _repository = repository;
        }

        public GetCustomerQueryResult Handle(GetCustomerQuery data)
        {
            var result = _repository.Get(data.Id);

            return new GetCustomerQueryResult(result);
        }
    }
}
