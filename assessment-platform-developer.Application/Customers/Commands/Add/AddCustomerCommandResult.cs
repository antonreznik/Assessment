using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.Commands.Add
{
    public class AddCustomerCommandResult : ICommandResult
    {
        public int CustomerId { get; private set; }

        public AddCustomerCommandResult(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
