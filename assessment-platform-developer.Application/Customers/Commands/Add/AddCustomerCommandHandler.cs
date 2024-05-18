using assessment_platform_developer.Application.Customers.incomingDtos.Add;
using assessment_platform_developer.Domain.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;
using System.Threading.Tasks;

namespace assessment_platform_developer.Application.Customers.Commands.Add
{
    public class AddCustomerCommandHandler : IMessageHandler<AddCustomerCommand, AddCustomerCommandResult>
    {
        private readonly ICustomerCommandRepository _repository;

        public AddCustomerCommandHandler(ICustomerCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddCustomerCommandResult> Handle(AddCustomerCommand command)
        {
            var customerId = await _repository.AddAsync(new Customer()
            {
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

            return new AddCustomerCommandResult(customerId);
        }
    }
}
