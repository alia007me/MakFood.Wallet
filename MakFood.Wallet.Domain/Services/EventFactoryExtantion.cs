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
                    case "BalanceDecreasedEvent":
                        
                        list.Add(JsonConvert.DeserializeObject<BalanceDecreasedEvent>(item.Content));
                        break;

                    case "BalanceIncreasedOfflineEvent":
                        list.Add(JsonConvert.DeserializeObject<BalanceIncreasedOfflineEvent>(item.Content));
                        break;
                    case "BalanceIncreasedOfflineWaitingForApproveEvent":
                        list.Add(JsonConvert.DeserializeObject<BalanceIncreasedOfflineWaitingForApproveEvent>(item.Content));
                        break;
                    case "BalanceIncreasedOnlineEvent":
                        list.Add(JsonConvert.DeserializeObject<BalanceIncreasedOnlineEvent>(item.Content));
                        break;
                    case "BalanceRefundedEvent":
                        list.Add(JsonConvert.DeserializeObject<BalanceRefundedEvent>(item.Content));
                        break;
                    default:
                        throw new Exception("that event is not exist!");
                }
            }
            return list;
        }
    }
}
