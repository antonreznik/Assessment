using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandResult : IMessageResult
    {
        public int CustomerId { get; private set; }

        public UpdateCustomerCommandResult(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
