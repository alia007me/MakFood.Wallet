using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Base
{
    public class EventSource
    {
        private EventSource() { }   
        public EventSource(string eventName, Event content, Guid walletId)
        {
            EventName = eventName;
            Content = JsonConvert.SerializeObject(content);
            WalletId = walletId;
            OccurredDateTime = DateTime.Now;
        }

        public static EventSource Create(Event @event, Guid WalletId)
        {
            return new EventSource(@event.GetType().Name, @event, WalletId);
        }

        public int Id { get; private set; }
        public string EventName { get; private set; }
        public string Content { get; private set; }
        public Guid WalletId { get; private set; }
        public DateTime OccurredDateTime { get; private set; }
    }
}
