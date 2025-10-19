using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts
{
    public interface IWalletRepository
    {

        public Task AddWallet(Guid CustomerId);
        public Task<Domain.Model.Entities.Wallet> GetWalletById(Guid Id, CancellationToken ct);
        public Task UpdateWalletBalanceAsync(Domain.Model.Entities.Wallet wallet, CancellationToken ct);
        public void AddTransaction(Guid walletid, string transactionNumber, decimal transactionAmount
    , PaymentMethod paymentMethod, DateTime dateTime, PaymentStatus paymentStatus);
        public Task<Transaction> GetTransactionAsync(string authority);
        public uint TransactionCounts();
       
    }

}
