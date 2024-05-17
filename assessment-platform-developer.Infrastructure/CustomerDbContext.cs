using assessment_platform_developer.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace assessment_platform_developer.Infrastructure
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
