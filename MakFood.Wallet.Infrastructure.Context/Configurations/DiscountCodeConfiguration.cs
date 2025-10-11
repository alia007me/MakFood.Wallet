using MakFood.Wallet.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Context.Configurations
{
    public class DiscountCodeConfiguration : IEntityTypeConfiguration<DiscountCode>
    {
        public void Configure(EntityTypeBuilder<DiscountCode> builder)
        {
            builder.ToTable("DiscountCodes");
            builder.HasKey(d => d.DiscountId);

            builder.Property(d => d.CustomerId)
                .IsRequired();

            builder.Property(d => d.MaximumDiscount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(d => d.MinimumDiscount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(d => d.Percentage)
                .IsRequired();

            builder.Property(d => d.ExpirationDate)
                .IsRequired();
        }
    }
}
