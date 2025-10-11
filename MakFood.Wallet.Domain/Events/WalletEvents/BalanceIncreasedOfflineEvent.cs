using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Events.WalletEvents
{
    public class BalanceIncreasedOfflineEvent : WalletEvent
    {
        public BalanceIncreasedOfflineEvent(decimal amount, OfflineTransactionApprover transactionApprover)
        {
            Amount = amount;
            TransactionApprover = transactionApprover;
        }
        public decimal Amount { get; set; }
        public OfflineTransactionApprover TransactionApprover { get; set; }

    }
}
