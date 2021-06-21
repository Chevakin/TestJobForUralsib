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

            //Выдает ошибку:
            //{"The property 'Customer.Information' is of type 'CustomerExtraInformation' which is not supported by the current database provider.
            //Either change the property CLR type, or ignore the property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'."}
            //
            //builder.Property(i => i.Information)
            //    .HasColumnName("Information_ID");

            builder.HasMany(c => c.Orders);
        }
    }
}
