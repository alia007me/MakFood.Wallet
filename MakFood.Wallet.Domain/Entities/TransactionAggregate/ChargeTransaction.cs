using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities.TransactionAggregate
{
    public class ChargeTransaction : Transaction
    {
        public ChargeTransaction(decimal transactionAmount, string transactionNumber, DateTime transactionDate,Guid walletId)
            : base(transactionAmount, transactionNumber, transactionDate)
        {
            WalletId = walletId;
        }

        public Guid TransactionId { get; private set; }


        public Guid WalletId { get; private set; }
        public Wallet Wallet { get; private set; }

    }
}
