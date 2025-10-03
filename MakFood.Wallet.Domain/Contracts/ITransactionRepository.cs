using MakFood.Wallet.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Guid walletid,string authority, Decimal transactionAmount);
        Task<Transaction> GetTransactionAsync(string authority);

    }
}
