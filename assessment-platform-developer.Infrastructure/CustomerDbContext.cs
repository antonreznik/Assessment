using assessment_platform_developer.Domain.Customers;
using System.Data.Common;
using System.Data.Entity;

namespace assessment_platform_developer.Infrastructure
{
    public class CustomerDbContext : DbContext
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=assessment;Integrated Security=True;";
        public CustomerDbContext() : base(connectionString)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
