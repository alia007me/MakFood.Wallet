using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Events.WalletEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Services
{
    public static class PayOrdearDeatailsService
    {
        public static decimal tryToPay(this Entities.Wallet wallet, OrderDetails orderDetails , CancellationToken ct)
        {
            if (orderDetails.isPaied == true) {
                throw new Exception("you paied this");
            }
            if (orderDetails.OrderAmount <= wallet.Balance) {
                wallet.Apply(new BalanceDecreasedEvent(orderDetails.OrderAmount));
                orderDetails.pay();
                return decimal.Zero;
            }
            else {
                return orderDetails.OrderAmount -wallet.Balance;
            }
        }
    }
}
