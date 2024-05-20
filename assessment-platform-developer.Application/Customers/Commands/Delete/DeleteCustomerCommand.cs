using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IMessage<DeleteCustomerCommandResult>
    {
        public int Id { get; set; }
        

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
