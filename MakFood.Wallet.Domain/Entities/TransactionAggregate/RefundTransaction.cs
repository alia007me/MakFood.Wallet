using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities.TransactionAggregate
{
    public class RefundTransaction : Transaction
    {

        public RefundTransaction(Explanation Explanation,
            decimal transactionAmount, string transactionNumber, DateTime transactionDate) :
            base(transactionAmount, transactionNumber, transactionDate)
        {
            this.Explanation = Explanation;
        }

        public Guid TransactionId { get; private init; }
        public Explanation Explanation { get; private init; }

        public Guid AccountId { get; private init; }
        public Accounts TOAcount { get; private init; }



        public Guid WalletId { get; private init; }
        public Wallet Wallet { get; private init; }

    }
}
