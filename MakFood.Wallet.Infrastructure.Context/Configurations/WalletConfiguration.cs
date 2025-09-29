using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Context.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet.Domain.Model.Entities.Wallet>
    {

        public void Configure(EntityTypeBuilder<Wallet.Domain.Model.Entities.Wallet> builder)
        {
            builder.ToTable("Wallets");
            builder.HasKey(w => w.WalletId);

            builder.Property(w => w.CustomerId)
                .IsRequired();

            builder.Property(w => w.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();


            builder.HasMany(w => w.Accounts)
                .WithOne(a => a.Wallet)
                .HasForeignKey(a => a.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.OrderDetails)
                .WithOne(o => o.Wallet)
                .HasForeignKey(o => o.WalletId);

            builder.HasMany(w => w.chargeTransactions)
                .WithOne(c => c.Wallet)
                .HasForeignKey(c => c.WalletId);

            builder.HasMany(w => w.refundTransactions)
                .WithOne(r => r.Wallet)
                .HasForeignKey(r => r.WalletId);
        }
    }
}
