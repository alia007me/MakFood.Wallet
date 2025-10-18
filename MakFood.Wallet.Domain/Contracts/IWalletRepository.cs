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
        Task<Domain.Model.Entities.Wallet> GetWalletById(Guid Id,CancellationToken ct);
        void AddTransaction(Guid walletid, string transactionNumber, Decimal transactionAmount
    , PaymentMethod paymentMethod, DateTime dateTime, PaymentStatus paymentStatus);
        Task<Transaction> GetTransactionAsync(string transactionNumber);
        uint TransactionCounts();
    }

}
