using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Container = SimpleInjector.Container;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;
using assessment_platform_developer.Application.Customers.Dto;
using assessment_platform_developer.Application.Customers.incomingDtos.Add;
using assessment_platform_developer.Application.Customers.Queries.GetAll;
using assessment_platform_developer.Application.Customers.Commands.Update;
using assessment_platform_developer.Application.Customers.Commands.Delete;
using assessment_platform_developer.Application.Customers.Queries.Get;
using assessment_platform_developer.Domain.Enums;
using System.Text.RegularExpressions;

namespace assessment_platform_developer
{
    public partial class Customers : Page
	{
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                PopulateCustomerListBox();

                PopulateCountriesDropDownList();

                PopulateProvincesDropDownList();
            }
        }

        protected void PopulateCustomerListBox()
		{
            var mediator = GetMediator();

            var result = mediator.Send(new GetAllCustomersQuery());

            CustomersDDL.Items.Clear();

            CustomersDDL.Items.Add(new ListItem("Add new customer"));

            var storedCustomers = result.Customers.Select(c => new ListItem(c.Name, c.ID.ToString())).ToArray();
			
			if (storedCustomers.Length != 0)
			{
				CustomersDDL.Items.AddRange(storedCustomers);
                DeselectCustomerDropdownList();
                return;
			}
		}

        protected void PopulateCountriesDropDownList()
        {
            var countryList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(c => new ListItem
                {
                    Text = c.ToString(),
                    Value = ((int)c).ToString()
                })
                .ToArray();

            CountryDropDownList.Items.AddRange(countryList);
            CountryDropDownList.SelectedValue = ((int)Countries.Canada).ToString();
        }

        protected void AddButton_Click(object sender, EventArgs e)
		{
            if (Page.IsValid)
            {
                var customer = MapFormToIncomingCusomerDto();

                var mediator = GetMediator();

                var result = mediator.Send(new AddCustomerCommand(customer));

                CustomersDDL.Items.Add(new ListItem(customer.Name, result.CustomerId.ToString()));

                CleanForm();
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var customer = MapFormToIncomingCusomerDto();

                customer.Id = int.Parse(CustomersDDL.SelectedValue);

                var mediator = GetMediator();

                mediator.Send(new UpdateCustomerCommand(customer));

                var customerInList = CustomersDDL.Items.FindByValue(customer.Id.ToString());

                customerInList.Text = customer.Name;

                DeselectCustomerDropdownList();

                CleanForm();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var customerId = int.Parse(CustomersDDL.SelectedValue);

            var mediator = GetMediator();

            mediator.Send(new DeleteCustomerCommand(customerId));

            var customerInList = CustomersDDL.Items.FindByValue(customerId.ToString());

            CustomersDDL.Items.Remove(customerInList);

            DeselectCustomerDropdownList();

            CleanForm();
        }

        protected void CustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
            PageTitle.Text = "Add customer";

            if (int.TryParse(CustomersDDL.SelectedValue, out int selectedId))
			{
                PageTitle.Text = "Update or Delete customer";
                AddButton.Visible = false;
				UpdateButton.Visible = true;
				DeleteButton.Visible = true;

                var mediator = GetMediator();

                var selectedCustomer = mediator.Send(new GetCustomerQuery(selectedId)).Customer;

                CustomerName.Text = selectedCustomer.Name;
                CustomerAddress.Text = selectedCustomer.Address;
                CustomerEmail.Text = selectedCustomer.Email;
                CustomerPhone.Text = selectedCustomer.Phone;
                CustomerCity.Text = selectedCustomer.City;
                StateDropDownList.SelectedIndex = int.Parse(selectedCustomer.State);
                CustomerZip.Text = selectedCustomer.Zip;
                CountryDropDownList.SelectedIndex = int.Parse(selectedCustomer.Country);
                CustomerNotes.Text = selectedCustomer.Notes;
                ContactName.Text = selectedCustomer.ContactName;
                ContactPhone.Text = selectedCustomer.ContactPhone;
                ContactEmail.Text = selectedCustomer.Email;
            }
			else
			{
				AddButton.Visible = true;
                UpdateButton.Visible = false;
                DeleteButton.Visible = false;
                CleanForm();
            }
        }

        protected void CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CountryDropDownList.SelectedValue, out int selectedId))
            {
                switch (selectedId)
                {
                    case (int)Countries.Canada:
                        PopulateProvincesDropDownList();
                        break;
                    case (int)Countries.UnitedStates:
                        PopulateStatesDropDownList();
                        break;
                    default: return;
                }
            }
        }

        protected void CustomZipValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (int.TryParse(CountryDropDownList.SelectedValue, out int selectedId))
            {
                switch (selectedId)
                {
                    case (int)Countries.Canada:
                        string canadaPattern = @"^[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d$";
                        Regex canadaRegex = new Regex(canadaPattern);
                        args.IsValid = canadaRegex.IsMatch(CustomerZip.Text.Trim());
                        break;
                    case (int)Countries.UnitedStates:
                        string usaPattern = @"^\d{5}(-\d{4})?$";
                        Regex usaRegex = new Regex(usaPattern);
                        args.IsValid = usaRegex.IsMatch(CustomerZip.Text.Trim());
                        break;
                    default: return;
                }
            }
        }

        private void PopulateProvincesDropDownList()
        {
            var provinceList = Enum.GetValues(typeof(CanadianProvinces))
                .Cast<CanadianProvinces>()
                .Select(p => new ListItem
                {
                    Text = p.ToString(),
                    Value = ((int)p).ToString()
                })
                .ToArray();
            StateDropDownList.Items.Clear();
            StateDropDownList.Items.AddRange(provinceList);
        }

        private void PopulateStatesDropDownList()
        {
            var stateList = Enum.GetValues(typeof(USStates))
                .Cast<USStates>()
                .Select(p => new ListItem
                {
                    Text = p.ToString(),
                    Value = ((int)p).ToString()
                })
                .ToArray();
            StateDropDownList.Items.Clear();
            StateDropDownList.Items.AddRange(stateList);
        }

        private void CleanForm()
        {
            CustomerName.Text = string.Empty;
            CustomerAddress.Text = string.Empty;
            CustomerEmail.Text = string.Empty;
            CustomerPhone.Text = string.Empty;
            CustomerCity.Text = string.Empty;
            StateDropDownList.SelectedIndex = 0;
            CustomerZip.Text = string.Empty;
            CountryDropDownList.SelectedIndex = 0;
            CustomerNotes.Text = string.Empty;
            ContactName.Text = string.Empty;
            ContactPhone.Text = string.Empty;
            ContactEmail.Text = string.Empty;
        }

        private IMediator GetMediator()
        {
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var mediator = testContainer.GetInstance<IMediator>();

            return mediator;
        }

        private IncomingCustomerDto MapFormToIncomingCusomerDto()
        {
            return new IncomingCustomerDto
            {
                Name = CustomerName.Text,
                Address = CustomerAddress.Text,
                City = CustomerCity.Text,
                State = StateDropDownList.SelectedValue,
                Zip = CustomerZip.Text,
                Country = CountryDropDownList.SelectedValue,
                Email = CustomerEmail.Text,
                Phone = CustomerPhone.Text,
                Notes = CustomerNotes.Text,
                ContactName = ContactName.Text,
                ContactPhone = CustomerPhone.Text,
                ContactEmail = CustomerEmail.Text
            };
        }

        private void DeselectCustomerDropdownList()
        {
            CustomersDDL.SelectedIndex = 0;
            CustomerDropDownList_SelectedIndexChanged(CustomersDDL, EventArgs.Empty);
        }
    }
}