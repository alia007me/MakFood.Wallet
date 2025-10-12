using MakFood.Wallet.Domain.Model.Base;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Events.WalletEvents;
using MakFood.Wallet.Domain.Model.Services.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MakFood.Wallet.Domain.Model.Services
{

    public static class EventFactoryExtantion
    {
        public static List<WalletEvent> GenerateEvent(List<EventSource>  eventSource)
        {
            var list = new List<WalletEvent>();
            foreach (var item in eventSource) {


                switch (item.EventName) {
                    case "MoneyDecreasedEvent":
                        
                        list.Add(JsonConvert.DeserializeObject<MoneyDecreasedEvent>(item.Content));
                        break;

                    case "MoneyIncreasedEvent":
                        list.Add(JsonConvert.DeserializeObject<MoneyIncreasedEvent>(item.Content));
                        break;
                    case "MoneyRefundedEvent":
                        list.Add(JsonConvert.DeserializeObject<MoneyRefundedEvent>(item.Content));
                        break;
                    default:
                        throw new Exception("that event is not exist!");
                }
            }
            return list;
        }
    }
}
