using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestJobForUralsib.Domain.Models;

namespace TestJobForUralsib.Domain.Data.ModelsConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("Customer")
                .HasKey(c => c.ID);

            builder.Property(c => c.ID)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.Surname)
                .IsRequired();

            builder.HasMany(c => c.Orders);
        }
    }
}
