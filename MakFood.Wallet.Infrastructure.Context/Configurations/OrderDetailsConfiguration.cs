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
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(o => o.OrderDetailId);
            builder.Property(c => c.OrderDetailId).ValueGeneratedNever();

            builder.Property(o => o.OrderAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
