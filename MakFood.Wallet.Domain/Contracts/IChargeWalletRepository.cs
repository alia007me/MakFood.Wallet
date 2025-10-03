using MakFood.Wallet.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts
{
    public interface IChargeWalletRepository
    {
        Task<Domain.Model.Entities.Wallet> GetWalletById(Guid Id,CancellationToken ct);
    }
}
