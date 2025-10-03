using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities
{
    public class Transaction
    {
        public Transaction(Guid walletId, decimal amount, string transactionNumber)
        {
            WalletId = walletId;
            Amount = amount;
            TransactionNumber = transactionNumber;
        }

        public int Id { get; private set; }
        public Guid WalletId { get; private set; }
        public Decimal Amount { get; private set; }
        public string TransactionNumber { get; private set; }


        public void UpdateTransactionNumber(string transactionNumber)
        {
            TransactionNumber = transactionNumber;
        }

    }


    
}
