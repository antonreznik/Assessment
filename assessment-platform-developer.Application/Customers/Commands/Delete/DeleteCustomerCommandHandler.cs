using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Commands.Delete
{
    internal class DeleteCustomerCommandHandler : IMessageHandler<DeleteCustomerCommand, DeleteCustomerCommandResult>
    {
        private readonly ICustomerCommandRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerCommandRepository repository)
        {
            _repository = repository;
        }

        public DeleteCustomerCommandResult Handle(DeleteCustomerCommand command)
        {
            _repository.Delete(command.Id);

            return new DeleteCustomerCommandResult(command.Id);
        }
    }
}
