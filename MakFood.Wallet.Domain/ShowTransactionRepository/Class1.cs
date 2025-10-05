using MakFood.Wallet.Application.Contracts;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories
{
    public class ShowTransactionRepository : IShowTransactionRepository
    {
        private readonly MakFoodWalletDbContext _db;

        public ShowTransactionRepository(MakFoodWalletDbContext db)
        {
            _db = db;
        }



        public async Task<List<Transaction>> GetByWalletIdAsync(Guid walletId)
        {
            return await _db.Transactions
                .AsNoTracking()
                .Where(t => t.WalletId == walletId)
                .OrderByDescending(t => t.DateTime)
                .ToListAsync();
        }
    }
}