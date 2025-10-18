using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class TransactionRepositor : ITransactionRepository
    {
        private readonly MakFoodWalletDbContext _makFoodWalletDbContext;

        public TransactionRepositor(MakFoodWalletDbContext makFoodWalletDbContext)
        {
            _makFoodWalletDbContext = makFoodWalletDbContext;
        }
 
               
        public async Task<List<Domain.Model.Entities.Transaction>> GetTransaction(Guid Id, DateTime dateTime)
        {
            return await _makFoodWalletDbContext.Transactions.AsNoTracking().Where(c=>c.WalletId == Id && c.DateTime <= dateTime )
                .OrderByDescending(C=>C.DateTime)
                .ToListAsync();
        }
    }
}

