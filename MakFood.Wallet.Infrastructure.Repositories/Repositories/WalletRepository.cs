using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Enums;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly MakFoodWalletDbContext _context;

        public WalletRepository(MakFoodWalletDbContext context)
        {
            _context = context;
        }


        public async Task<Domain.Model.Entities.Wallet> GetWalletById(Guid Id,CancellationToken ct)
        {
            return await _context.Wallets.SingleOrDefaultAsync(x => x.WalletId == Id,ct);
        }

        public async Task AddTransactionAsync(Guid walletid, string transactionNumber, decimal transactionAmount
    , PaymentMethod paymentMethod, DateTime dateTime, PaymentStatus paymentStatus)
        {
            await _context.Transactions.AddAsync(new Domain.Model.Entities.Transaction(walletid, transactionAmount, transactionNumber, paymentMethod, dateTime, paymentStatus));
        }

        public async Task<Transaction> GetTransactionAsync(string authority)
        {
            var result = await _context.Transactions.SingleOrDefaultAsync(x => x.TransactionNumber == authority);
            return result;
        }
    }
}
