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

        public async Task<int> AddAsync(Customer customer)
        {
            var createdCustomer = _context.Customers.Add(customer);

            _context.SaveChanges();

            return createdCustomer.ID;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await GetCustomer(id);

            if(customer != null)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
        }

        public async Task UpdateAsync(Customer customer)
        {
            var customerFromDatabase = await GetCustomer(customer.ID);

            if(customerFromDatabase != null)
            {
                _context.Entry(customerFromDatabase).CurrentValues.SetValues(customer);

                _context.SaveChanges();
            }
        }

        private Task<Customer> GetCustomer(int id)
        {
            return _context.Customers.FindAsync(id);
        }
    }
}
