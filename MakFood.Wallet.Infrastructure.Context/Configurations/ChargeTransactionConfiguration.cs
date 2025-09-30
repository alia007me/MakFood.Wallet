using MakFood.Wallet.Domain.Model.Entities.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Context.Configurations
{
    public class ChargeTransactionConfiguration : IEntityTypeConfiguration<ChargeTransaction>
    {
        public void Configure(EntityTypeBuilder<ChargeTransaction> builder)
        {
            builder.ToTable("ChargeTransactions");
            builder.HasKey(c => c.TransactionId);

            builder.Property(c => c.TransactionAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(x => x.ChargeStatus)
                .HasColumnName("ChargeModel")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.ChargeState)
                .HasColumnName("ChargeState")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(c => c.TransactionNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.TransactionDate)
                .IsRequired();

            builder.HasOne(c => c.Wallet)
                .WithMany(w => w.chargeTransactions)
                .HasForeignKey(c => c.WalletId);
        }
    }
}
