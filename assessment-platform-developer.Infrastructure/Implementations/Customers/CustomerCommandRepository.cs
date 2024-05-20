using assessment_platform_developer.Domain.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Implementations.Customers
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerCommandRepository()
        {
            _context = new CustomerDbContext();
        }

        public int Add(Customer customer)
        {
            var createdCustomer = _context.Customers.Add(customer);

            _context.SaveChanges();

            return createdCustomer.ID;
        }

        public void Delete(int id)
        {
            var customer = GetCustomer(id);

            if(customer != null)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var customerFromDatabase = GetCustomer(customer.ID);

            if(customerFromDatabase != null)
            {
                _context.Entry(customerFromDatabase).CurrentValues.SetValues(customer);

                _context.SaveChanges();
            }
        }

        private Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }
    }
}
