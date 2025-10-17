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

            builder.HasMany(x=>x.Accounts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x=>x.Transactions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.OrderDetails)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
