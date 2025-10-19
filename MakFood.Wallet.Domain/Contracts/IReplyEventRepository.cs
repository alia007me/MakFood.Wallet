using MakFood.Wallet.Domain.Model.Base;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts
{
    public interface IReplyEventRepository
    {
        Task<List<EventSource>> GetWaletEvent(Guid id, DateTime time, CancellationToken ct);

    }
}
