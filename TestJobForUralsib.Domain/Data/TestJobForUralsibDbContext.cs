using Microsoft.EntityFrameworkCore;
using TestJobForUralsib.Domain.Data.ModelsConfigurations;
using TestJobForUralsib.Domain.Models;

namespace TestJobForUralsib.Domain.Data
{
    public class TestJobForUralsibDbContext : DbContext
    {
        public TestJobForUralsibDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CustomerExtraInformation> CustomersInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new CustomerConfiguration())
                .ApplyConfiguration(new CustomerExtraInformationConfiguration())
                .ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
