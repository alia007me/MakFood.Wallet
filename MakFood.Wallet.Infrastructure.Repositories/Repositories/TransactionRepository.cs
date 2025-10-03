using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MakFoodWalletDbContext _context;

        public TransactionRepository(MakFoodWalletDbContext context)
        {
            _context = context;
        }

        public async Task AddTransactionAsync(Guid walletid, string authority, decimal transactionAmount)
        {
            await _context.Transactions.AddAsync(new Domain.Model.Entities.Transaction(walletid,transactionAmount,authority));
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> GetTransactionAsync(string authority)
        {
            var result = await _context.Transactions.SingleOrDefaultAsync(x => x.TransactionNumber == authority);
            return result;
        }


    }
}
