using MakFood.Wallet.Domain.Model.Base;
using MakFood.Wallet.Domain.Model.Events.WalletEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities
{
    public class Wallet : IEventSourcedEntity
    {
        private readonly List<WalletEvent> _events = new List<WalletEvent>();
        public static Wallet Primitive => new Wallet();



        public Wallet() { }
        public Wallet(Guid CustomerId, Decimal Balance, Decimal AvailableBalance)
        {
            this.CustomerId = CustomerId;
            this.Balance = Balance;

        }
        public Guid WalletId { get; private init; }
        public Guid CustomerId { get; private init; }
        public Decimal Balance { get; private set; }
        public Decimal AvailableBalance => Balance - 10000;




        public IList<Accounts> Accounts { get; private set; } = new List<Accounts>();
        public IList<OrderDetails> OrderDetails { get; private set; } = new List<OrderDetails>();



        public IReadOnlyList<Event> Events => _events.AsReadOnly();



        public void Apply<T>(T @event) where T : WalletEvent
        {
            Apply((dynamic)@event);
        }


        public void Apply(MoneyIncreasedEvent @event)
        {
            this.Balance += @event.Amount;
            _events.Add(@event);    
        }

        public void Apply(MoneyDecreasedEvent @event)
        {
            this.Balance -= @event.Amount;
            _events.Add(@event);
        }

        public void Apply(MoneyRefundedEvent @event)
        {
            this.Balance -= @event.Amount;
            _events.Add(@event);
        }









    }
}
