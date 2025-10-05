using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Base
{
    public interface IEventSourcedEntity
    {
        Guid WalletId { get; }
        public IReadOnlyList<Event> Events { get; }
    }
}
