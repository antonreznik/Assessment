using assessment_platform_developer.Domain.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Commands.Update
{
    internal class UpdateCustomerCommandHandler : IMessageHandler<UpdateCustomerCommand, UpdateCustomerCommandResult>
    {
        private readonly ICustomerCommandRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerCommandRepository repository)
        {
            _repository = repository;
        }

        public UpdateCustomerCommandResult Handle(UpdateCustomerCommand command)
        {
            _repository.Update(new Customer()
            {
                ID = command.ID,
                Name = command.Name,
                Address = command.Address,
                Email = command.Email,
                Phone = command.Phone,
                City = command.City,
                State = command.State,
                Zip = command.Zip,
                Country = command.Country,
                Notes = command.Notes,
                ContactName = command.ContactName,
                ContactPhone = command.ContactPhone,
                ContactEmail = command.ContactEmail,
                ContactTitle = command.ContactTitle,
                ContactNotes = command.ContactNotes
            });

            return new UpdateCustomerCommandResult(command.ID);
        }
    }
}
