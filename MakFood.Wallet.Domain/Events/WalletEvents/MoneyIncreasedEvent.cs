using MakFood.Wallet.Domain.Model.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Events.WalletEvents
{
    public class MoneyIncreasedEvent : WalletEvent
    {
        public MoneyIncreasedEvent(decimal amount, PaymentMethod paymentMethod)
        {
            Amount = amount;
            PaymentMethod = paymentMethod;
        }

        public Decimal Amount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]

        public PaymentMethod PaymentMethod { get; set; }

    }
}
