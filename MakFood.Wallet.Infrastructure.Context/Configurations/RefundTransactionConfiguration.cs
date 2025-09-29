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
    public class RefundTransactionConfiguration : IEntityTypeConfiguration<RefundTransaction>
    {
        public void Configure(EntityTypeBuilder<RefundTransaction> builder)
        {
            builder.ToTable("RefundTransactions");
            builder.HasKey(r => r.TransactionId);

            builder.Property(r => r.TransactionAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(r => r.TransactionNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.TransactionDate)
                .IsRequired();

            builder.HasOne(r => r.Wallet)
                .WithMany(w => w.refundTransactions)
                .HasForeignKey(r => r.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.TOAcount).WithMany(x => x.refundTransactions).HasForeignKey(x => x.AccountId);

            builder.Property(r => r.Explanation)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
