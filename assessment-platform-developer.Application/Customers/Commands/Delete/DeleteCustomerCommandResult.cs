using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommandResult : IMessageResult
    {
        public int CustomerId { get; private set; }

        public DeleteCustomerCommandResult(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
