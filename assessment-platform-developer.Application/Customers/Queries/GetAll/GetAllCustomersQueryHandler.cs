using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Queries.GetAll
{
    public class GetAllCustomersQueryHandler : IMessageHandler<GetAllCustomersQuery, GetAllCustomersQueryResult>
    {
        private readonly ICustomerQueryRepository _repository;

        public GetAllCustomersQueryHandler(ICustomerQueryRepository repository)
        {
            _repository = repository;
        }

        public GetAllCustomersQueryResult Handle(GetAllCustomersQuery data)
        {
            var result = _repository.GetAll();

            return new GetAllCustomersQueryResult(result);
        }
    }
}
