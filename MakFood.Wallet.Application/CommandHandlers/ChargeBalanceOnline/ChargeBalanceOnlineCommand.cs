using MakFood.Wallet.Domain.Model.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline
{
    public class ChargeBalanceOnlineCommand : IRequest<ChargeBalanceOnlineCommandResponse>
    {
        public ChargeBalanceOnlineWriteDto Write { get; set; }

    }
}
