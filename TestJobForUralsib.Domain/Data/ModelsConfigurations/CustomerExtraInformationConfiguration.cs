using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestJobForUralsib.Domain.Models;

namespace TestJobForUralsib.Domain.Data.ModelsConfigurations
{
    public class CustomerExtraInformationConfiguration : IEntityTypeConfiguration<CustomerExtraInformation>
    {
        public void Configure(EntityTypeBuilder<CustomerExtraInformation> builder)
        {
            builder.ToTable("Customer_Information")
                .HasKey(i => i.ID);

            builder.Property(i => i.ID)
                .ValueGeneratedOnAdd();

            builder.Property(o => o.Phone)
                .IsRequired();
        }
    }
}
