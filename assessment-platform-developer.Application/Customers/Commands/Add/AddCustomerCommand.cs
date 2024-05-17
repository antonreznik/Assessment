using assessment_platform_developer.Application.Customers.Commands.Add;
using assessment_platform_developer.Application.Customers.Dto;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;

namespace assessment_platform_developer.Application.Customers.incomingDtos.Add
{
    public class AddCustomerCommand : ICommand<AddCustomerCommandResult>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTitle { get; set; }
        public string ContactNotes { get; set; }

        public AddCustomerCommand(IncomingCustomerDto incomingDto)
        {
            Name = incomingDto.Name;
            Address = incomingDto.Address;
            Email = incomingDto.Email;
            Phone = incomingDto.Phone;
            City = incomingDto.City;
            State = incomingDto.State;
            Zip = incomingDto.Zip;
            Country = incomingDto.Country;
            Notes = incomingDto.Notes;
            ContactName = incomingDto.ContactName;
            ContactPhone = incomingDto.ContactPhone;
            ContactEmail = incomingDto.ContactEmail;
            ContactTitle = incomingDto.ContactTitle;
            ContactNotes = incomingDto.ContactNotes;
        }
    }
}
