using MakFood.Wallet.Domain.Model.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline
{
    public class ChargeBalanceOfflineCommand : IRequest<ChargeBalanceOfflineCommandResponse>
    {
        public ChargeBalanceOfflineWriteDto request { get; set; }
    }
}
