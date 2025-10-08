using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Events.WalletEvents
{
    public class BalanceIncreasedOfflineWaitingForApproveEvent : WalletEvent
    {
        public BalanceIncreasedOfflineWaitingForApproveEvent(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


    }
}
