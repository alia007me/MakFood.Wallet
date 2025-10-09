using MakFood.Wallet.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Events.WalletEvents
{
    public class BalanceRefundedEvent : WalletEvent
    {
        public BalanceRefundedEvent(decimal amount, string toAccount)
        {
            Amount = amount;
            ToAccount = toAccount;
        }

        public decimal Amount { get; set; }
        public string ToAccount { get; set; }
    }
}
