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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.WalletId)
                   .IsRequired();

            builder.Property(x => x.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.TransactionNumber)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.ToTable("Transactions");
        }
    }
}
