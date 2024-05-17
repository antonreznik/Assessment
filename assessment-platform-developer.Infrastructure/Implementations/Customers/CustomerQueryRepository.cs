using assessment_platform_developer.Domain.Customers;
using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Customer>> GetAllAsync() 
        {
            return (await _context.Customers.ToListAsync()).AsEnumerable();
        } 

        public ValueTask<Customer> GetAsync(int id)
        {
            return _context.Customers.FindAsync(id);
        }
    }
}
