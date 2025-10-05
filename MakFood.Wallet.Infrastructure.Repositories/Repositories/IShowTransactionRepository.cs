using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Entities.TransactionAggregate;

namespace MakFood.Wallet.Application.Contracts
{
    public interface IShowTransactionRepository
    {
        Task<List<Transaction>> GetByWalletIdAsync(Guid walletId);
    }
}