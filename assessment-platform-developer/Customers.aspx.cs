using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using assessment_platform_developer.Services;
using Container = SimpleInjector.Container;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;
using assessment_platform_developer.Application.Customers.Dto;
using assessment_platform_developer.Application.Customers.incomingDtos.Add;
using assessment_platform_developer.Application.Customers.Queries.GetAll;

namespace assessment_platform_developer
{
    public partial class Customers : Page
	{
		private static List<CustomerViewModel> customers = new List<CustomerViewModel>();

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                PopulateCustomerListBox();

                PopulateCustomerDropDownLists();
            }
			else
			{
                customers = (List<CustomerViewModel>)ViewState["Customers"];
			}
		}

		private void PopulateCustomerDropDownLists()
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


			var provinceList = Enum.GetValues(typeof(CanadianProvinces))
				.Cast<CanadianProvinces>()
				.Select(p => new ListItem
				{
					Text = p.ToString(),
					Value = ((int)p).ToString()
				})
				.ToArray();

			StateDropDownList.Items.Add(new ListItem(""));
			StateDropDownList.Items.AddRange(provinceList);
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

        protected void PopulateCustomerListBox()
		{
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];

            var mediator = testContainer.GetInstance<IMediator>();

            var result = mediator.Send(new GetAllCustomersQuery()).Result;

            ViewState["Customers"] = result.Customers;

            CustomersDDL.Items.Clear();

            CustomersDDL.Items.Add(new ListItem("Add new customer"));

            var storedCustomers = result.Customers.Select(c => new ListItem(c.Name, c.ID.ToString())).ToArray();
			
			if (storedCustomers.Length != 0)
			{
				CustomersDDL.Items.AddRange(storedCustomers);
				CustomersDDL.SelectedIndex = 0;
				return;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			var customer = new IncomingCustomerDto
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

			var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var mediator = testContainer.GetInstance<IMediator>();
            var result = mediator.Send(new AddCustomerCommand(customer)).Result;
			customers.Add(new CustomerViewModel(result.CustomerId, customer));

			CustomersDDL.Items.Add(new ListItem(customer.Name));

            CleanForm();
        }

		protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (int.TryParse(CustomersDDL.SelectedValue, out int selectedId))
			{
                var selectedCustomer = customers.FirstOrDefault(x => x.ID == selectedId);

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
				CleanForm();
            }
        }
    }
}