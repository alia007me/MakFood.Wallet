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



            builder.HasMany(w => w.Accounts)
                .WithOne(a => a.Wallet)
                .HasForeignKey(a => a.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.OrderDetails)
                .WithOne(o => o.Wallet)
                .HasForeignKey(o => o.WalletId);

        }
    }
}
