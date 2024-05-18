using assessment_platform_developer.Domain.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Implementations.Customers
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly CustomerDbContext _context;
        public CustomerQueryRepository()
        {
            _context = new CustomerDbContext();
        }

        public IEnumerable<Customer> GetAll() 
        {
            return _context.Customers.ToList().AsEnumerable();
        } 

        public Task<Customer> GetAsync(int id)
        {
            return _context.Customers.FindAsync(id);
        }
    }
}
