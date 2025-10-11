using MakFood.Wallet.Domain.Model.Base;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Context
{
    public class MakFoodWalletDbContext : DbContext
    {
        public MakFoodWalletDbContext(DbContextOptions<MakFoodWalletDbContext> options) : base(options)
        {

        }
        public DbSet<Wallet.Domain.Model.Entities.Wallet> Wallets { get; set; }
        public DbSet<EventSource> WalletEvents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountCodeConfiguration());
            modelBuilder.ApplyConfiguration(new EventSourceConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.Ignore<Event>();

        }
    }
}
