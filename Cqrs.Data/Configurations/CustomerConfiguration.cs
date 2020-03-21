using System;
using System.Collections.Generic;
using System.Text;

using Cqrs.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cqrs.Data.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.ToTable("Customers");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Customer_id").HasDefaultValueSql("newId()");
            builder.Property(b => b.Name).HasColumnName("Customer_name").HasMaxLength(150)
                .IsRequired();

            builder.Property(b => b.Age).IsRequired();
            builder.Property(b => b.Address).HasColumnName("Address").HasMaxLength(255)
                .IsRequired();

            builder.Property(b => b.Email).HasColumnName("Email").HasMaxLength(255).IsRequired();

            builder.Property(e => e.Phone).HasColumnName("Phone_Number").HasMaxLength(20)
                .IsRequired();

        }
    }
}
