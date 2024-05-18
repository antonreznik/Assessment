using assessment_platform_developer.Domain.Customers;
using System;

namespace assessment_platform_developer.Application.Customers.Dto
{
    [Serializable]
    public class CustomerViewModel
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

        public CustomerViewModel(int customerId, IncomingCustomerDto incomingDto)
        {
            ID = customerId;
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

        public CustomerViewModel (Customer customer)
        {
            ID = customer.ID;
            Name = customer.Name;
            Address = customer.Address;
            Email = customer.Email;
            Phone = customer.Phone;
            City = customer.City;
            State = customer.State;
            Zip = customer.Zip;
            Country = customer.Country;
            Notes = customer.Notes;
            ContactName = customer.ContactName;
            ContactPhone = customer.ContactPhone;
            ContactEmail = customer.ContactEmail;
            ContactTitle = customer.ContactTitle;
            ContactNotes = customer.ContactNotes;
        }
    }
}