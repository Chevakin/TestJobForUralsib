using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TestJobForUralsib.Domain.Models;

namespace TestJobForUralsib.Domain.Data.ModelsConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Order")
                .HasKey(o => o.ID);

            builder.Property(o => o.ID)
                 .ValueGeneratedOnAdd();

            builder.Property(o => o.Date)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(o => o.AmountMoney)
                .IsRequired();

            //builder.Property(o => o.Customer)
            //    .HasColumnName("Customer_ID");
        }
    }
}
