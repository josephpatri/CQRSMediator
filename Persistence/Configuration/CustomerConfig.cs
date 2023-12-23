using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Mail).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(9);
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.ModifiedBy).HasMaxLength(30);
        }
    }
}
