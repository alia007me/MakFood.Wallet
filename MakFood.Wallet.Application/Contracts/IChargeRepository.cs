using MakFood.Wallet.Application.DTOs.ChargeBalanceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.Contracts
{
    public interface IChargeRepository
    {
        Task<string> ChargeBalanceOnlineAsync(ChargeBalanceWriteDTO chargeBalance);
        Task<bool> ChargeBalanceOfflineAsync(Guid id, decimal Amount);

    }
}
