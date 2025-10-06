using MakFood.Wallet.Domain.Model.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts
{
    public interface IChargeRepository
    {
        Task<string> ChargeBalanceOnlineAsync(ChargeBalanceOnlineWriteDto chargeBalance);
        Task<bool> ChargeBalanceOffline(ChargeBalanceOfflineWriteDto chargeBalance);
        Task<string> CheckChefResponseAsync(ChefResponseDto chefResponse);


    }
}
