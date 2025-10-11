using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities
{
    public class Transaction
    {
        public Transaction(Guid walletId, decimal amount, string transactionNumber, PaymentMethod paymentMethod, DateTime dateTime, PaymentStatus status)
        {
            WalletId = walletId;
            Amount = amount;
            TransactionNumber = transactionNumber;
            PaymentMethod = paymentMethod;
            DateTime = dateTime;
            Status = status;
        }

        public int Id { get; private set; }
        public Guid WalletId { get; private set; }
        public Decimal Amount { get; private set; }
        public string TransactionNumber { get; private set; }
        public DateTime DateTime { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus Status { get; private set; }


        public void UpdateTransactionNumber(string transactionNumber)
        {
            TransactionNumber = transactionNumber;
        }

        public void Done()
        {
            Status = PaymentStatus.Done;
        }

        public void Cancelled()
        {
            Status = PaymentStatus.Cancelled;
        }

    }


    
}
