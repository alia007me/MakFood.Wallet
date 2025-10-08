using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Events.WalletEvents
{
    public class BalanceDecreasedEvent : WalletEvent
    {
        public BalanceDecreasedEvent(decimal amount)
        {
            Amount = amount;
        }

        public Decimal Amount { get; set; }
    }
}
